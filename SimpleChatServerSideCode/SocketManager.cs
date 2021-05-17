using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using SimpleChatSharedCode;

namespace SimpleChatServerSideCode
{
    class SocketManager
    {
        private Socket serverSocket;
        public SocketManager()
        {
            serverSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 53869));
            serverSocket.Listen();
        }

        public void Accept()
        {
            while (true)
            {
                var socket = serverSocket.Accept();
                ReceiveAsync(socket);
                //sockets.Add(socket);
            }
        }
        public async void ReceiveAsync(Socket socket)
        {
            try
            {
                byte[] rec_bytes = new byte[1024];
                ArraySegment<byte> bytesSeg = new ArraySegment<byte>(rec_bytes);
                int bytesRec = await socket.ReceiveAsync(bytesSeg, SocketFlags.None);
                string data = Encoding.ASCII.GetString(rec_bytes, 0, bytesRec);
                Net_Base basePacket = JsonConvert.DeserializeObject<Net_Base>(data);

                switch (basePacket.OpCode)
                {
                    case OpCode.Debug:
                        Console.WriteLine("Debugging Works");
                        break;
                    case OpCode.EmployeeRegister:
                        await CheckEmployeeRegister(socket, data);
                        break;
                    case OpCode.EmployeeLogin:
                        await CheckEmployeeLogin(socket, data);
                        break;
                    case OpCode.GetOnlineEmployees:
                        CheckGetOnlineEmployee(socket, data);
                        break;
                    case OpCode.SendMessage:
                        CheckSendMessage(socket, data);
                        break;
                    default:
                        break;
                }

                ReceiveAsync(socket);
            }
            catch (Exception)
            {
                EmployeeManager.RemoveOnlineEmployee(socket);
                //Socket Disconnected?
            }

        }

        private static void CheckSendMessage(Socket socket, string data)
        {
            Net_SendMessage sendMessage = JsonConvert.DeserializeObject<Net_SendMessage>(data);
            Net_OnSendMessage receiveMessage;
            if (EmployeeManager.IsValidToken(socket, sendMessage.Token))
            {
                if (sendMessage.IsServerMessage)
                {
                    var socketList = EmployeeManager.GetOnlineEmployeeSockets();
                    Net_OnSendMessage onSendMessage = new Net_OnSendMessage(sendMessage.Message, EmployeeManager.GetEmployeeFromSocket(socket).Email, sendMessage.To, true, Status.Successful);
                    foreach (var sc in socketList)
                    {
                        sc.Send(onSendMessage.GetByte());
                    }
                }
                else
                {
                    var sender = EmployeeManager.GetEmployeeFromSocket(socket);
                    receiveMessage = new Net_OnSendMessage(sendMessage.Message, sender.Email, sendMessage.To,false, Status.Successful);
                    var receiverSocket = EmployeeManager.GetSocketFromMail(sendMessage.To);
                    receiverSocket.Send(receiveMessage.GetByte());
                    socket.Send(receiveMessage.GetByte());
                }
            }
            else
            {
                receiveMessage = new Net_OnSendMessage(null, null, null,false, Status.Error);
                socket.Send(receiveMessage.GetByte());
            }
        }

        private static void CheckGetOnlineEmployee(Socket socket, string data)
        {
            Net_GetOnlineEmployees getOnlineEmployees = JsonConvert.DeserializeObject<Net_GetOnlineEmployees>(data);
            Net_OnGetOnlineEmployees onGetOnlineEmployees;
            if (EmployeeManager.IsValidToken(socket, getOnlineEmployees.Token))
            {
                var emailList = EmployeeManager.GetOnlineEmployees();
                onGetOnlineEmployees = new Net_OnGetOnlineEmployees(emailList,Status.Successful);
            }
            else
            {
                onGetOnlineEmployees = new Net_OnGetOnlineEmployees(null, Status.Error);
            }
            socket.Send(onGetOnlineEmployees.GetByte());
        }

        private static async Task CheckEmployeeLogin(Socket socket, string data)
        {
            Net_EmployeeLogin loginData = JsonConvert.DeserializeObject<Net_EmployeeLogin>(data);
            var response = await WebAPI.instance.EmployeeLoginAsync(JsonConvert.SerializeObject(loginData));
            var responseData = JsonConvert.DeserializeObject<Net_OnEmployeeLogin>(response.GetFirstStringRecord());
            switch (responseData.Status)
            {
                case Status.SuccessfulLogin:
                    if (!EmployeeManager.HasEmployeeSignedIn(socket))
                    {
                        string token = Utilities.RandomString(10);
                        EmployeeManager.AddOnlineEmployee(new OnlineEmployee(socket, loginData.Email, token));
                        responseData.Token = token;
                    }
                    else
                    {
                        responseData.Status = Status.AlreadyLoggedIn;
                    }
                    socket.Send(responseData.GetByte());
                    break;
                case Status.WrongEmailOrPassword:
                    socket.Send(responseData.GetByte());
                    break;
                default:
                    break;
            }
        }

        private static async Task CheckEmployeeRegister(Socket socket, string data)
        {
            Net_EmployeeRegister registerData = JsonConvert.DeserializeObject<Net_EmployeeRegister>(data);
            var response = await WebAPI.instance.EmployeeRegisterAsync(JsonConvert.SerializeObject(registerData));
            socket.Send(response.ToArray()[0].GetASCIIBytes());
        }
    }
}
