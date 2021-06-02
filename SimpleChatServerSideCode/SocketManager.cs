using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using SimpleChatSharedCode;
using System.Security.Cryptography;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;

namespace SimpleChatServerSideCode
{
    class SocketManager
    {
        private Socket serverSocket;
        /*
        private static readonly string ServerCertificateFile = @"C:\Users\JustRelaxable\Desktop\Source\SslServer\SslServer\server.pfx";
        private static readonly string ServerCertificatePassword = null;
        X509Certificate2 serverCertificate = new X509Certificate2(ServerCertificateFile, ServerCertificatePassword);
        */
        public SocketManager(string ip)
        {
            serverSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), 53869));
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
        public async Task ReceiveAsync(Socket socket)
        {
            try
            {
                /*
                using (var sslStream = new SslStream(new NetworkStream(socket), false, App_CertificateValidation))
                {
                    sslStream.AuthenticateAsServer(serverCertificate, true, SslProtocols.Tls12, false);

                    while (true)
                    {
                        var inputBuffer = new byte[1024];
                        var inputBytes = 0;
                        while (inputBytes == 0)
                        {
                            inputBytes = sslStream.Read(inputBuffer, 0, inputBuffer.Length);
                        }
                        var inputMessage = Encoding.ASCII.GetString(inputBuffer, 0, inputBytes);
                    }
                }
                */
                
                byte[] rec_bytes = new byte[1024];
                ArraySegment<byte> bytesSeg = new ArraySegment<byte>(rec_bytes);
                int bytesRec = await socket.ReceiveAsync(bytesSeg, SocketFlags.None);
                

                
                byte[] d = new byte[1024];

                AesManaged aes = new AesManaged();
                aes.Padding = PaddingMode.Zeros;
                ICryptoTransform encryptor = aes.CreateDecryptor("1234567812345678".GetASCIIBytes(), "1234567812345678".GetASCIIBytes());
                
                string data2;
                using (MemoryStream ms = new MemoryStream(rec_bytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                            {
                                data2 = sr.ReadLine();
                                data2 = data2.Split('\0')[0];
                            }
                    }
                }
                
                //var data2 = "";

                

                string data = Encoding.ASCII.GetString(rec_bytes, 0, bytesRec);


                Net_Base basePacket = JsonConvert.DeserializeObject<Net_Base>(data2);

                switch (basePacket.OpCode)
                {
                    case OpCode.Debug:
                        Console.WriteLine("Debugging Works");
                        break;
                    case OpCode.EmployeeRegister:
                        await CheckEmployeeRegister(socket, data2);
                        break;
                    case OpCode.EmployeeLogin:
                        await CheckEmployeeLogin(socket, data2);
                        break;
                    case OpCode.GetOnlineEmployees:
                        CheckGetOnlineEmployee(socket, data2);
                        break;
                    case OpCode.SendMessage:
                        CheckSendMessage(socket, data2);
                        break;
                    case OpCode.GetDBlogs:
                        await CheckGetDBLogs(socket, data2);
                        break;
                    default:
                        break;
                }

                ReceiveAsync(socket);
            }
            catch (Exception)
            {
                var employee = EmployeeManager.GetEmployeeFromSocket(socket);
                Net_Log log = new Net_Log($"Employee {employee.Email} has logged out. Session time:{DateTime.UtcNow - employee.LoginTime}", LogType.LogOut);
                WebAPI.instance.DBLogAsync(JsonConvert.SerializeObject(log));
                EmployeeManager.RemoveOnlineEmployee(socket);
                //Socket Disconnected?
            }

        }

        private async Task CheckGetDBLogs(Socket socket, string data2)
        {
            Net_GetDBLogs getDBLogs = JsonConvert.DeserializeObject<Net_GetDBLogs>(data2);
            if (EmployeeManager.IsEmployeeSuperuser(socket) && EmployeeManager.IsValidToken(socket, getDBLogs.Token))
            {
                var response = await WebAPI.instance.GetDBLogsAsync();
                var responseList = response.ToList();

                byte packages = (byte)(responseList.Count / 5);
                packages = packages >= 4 ? (byte)3 : packages;
                for (int i = 0; i <= packages; i++)
                {
                    List<Net_Log> logs = new List<Net_Log>();
                    var fragment = responseList.GetRange(i * 5, 5);
                    for (int a = 0; a < fragment.Count; a++)
                    {
                        Net_Log log = JsonConvert.DeserializeObject<Net_Log>(fragment[a]);
                        logs.Add(log);
                    }
                    Net_OnGetDBLogs onGetDBLogs = new Net_OnGetDBLogs(logs, (byte)i, packages, Status.Successful);
                    socket.SendFromManager(onGetDBLogs);
                    ReceiveAck(socket);
                }
            }
            else
            {
                socket.SendFromManager(new Net_OnGetDBLogs(null, 0, 0, Status.Error));
            }
        }

        public bool ReceiveAck(Socket socket)
        {
            try
            {
                /*
                using (var sslStream = new SslStream(new NetworkStream(socket), false, App_CertificateValidation))
                {
                    sslStream.AuthenticateAsServer(serverCertificate, true, SslProtocols.Tls12, false);

                    while (true)
                    {
                        var inputBuffer = new byte[1024];
                        var inputBytes = 0;
                        while (inputBytes == 0)
                        {
                            inputBytes = sslStream.Read(inputBuffer, 0, inputBuffer.Length);
                        }
                        var inputMessage = Encoding.ASCII.GetString(inputBuffer, 0, inputBytes);
                    }
                }
                */

                byte[] rec_bytes = new byte[1024];
                ArraySegment<byte> bytesSeg = new ArraySegment<byte>(rec_bytes);
                int bytesRec = socket.Receive(bytesSeg, SocketFlags.None);



                byte[] d = new byte[1024];

                AesManaged aes = new AesManaged();
                aes.Padding = PaddingMode.Zeros;
                ICryptoTransform encryptor = aes.CreateDecryptor("1234567812345678".GetASCIIBytes(), "1234567812345678".GetASCIIBytes());

                string data2;
                using (MemoryStream ms = new MemoryStream(rec_bytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            data2 = sr.ReadLine();
                            data2 = data2.Split('\0')[0];
                        }
                    }
                }

                //var data2 = "";



                string data = Encoding.ASCII.GetString(rec_bytes, 0, bytesRec);
                Net_Base basePacket = JsonConvert.DeserializeObject<Net_Base>(data2);

                switch (basePacket.OpCode)
                {
                    case OpCode.Ack:
                        return true;
                    default:
                        return ReceiveAck(socket);
                }
            }
            catch (Exception)
            {
                return false;
                //Socket Disconnected?
            }

        }

        private static bool App_CertificateValidation(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None) { return true; }
            if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors) { return true; } //we don't have a proper certificate tree
            Console.WriteLine("*** SSL Error: " + sslPolicyErrors.ToString());
            return false;
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
                    Net_Log log = new Net_Log($"Employee {EmployeeManager.GetEmployeeFromSocket(socket).Email} has sent message to the Server chat.",LogType.ServerChatMessage);
                    WebAPI.instance.DBLogAsync(JsonConvert.SerializeObject(log));
                    foreach (var sc in socketList)
                    {
                        sc.SendFromManager(onSendMessage);
                    }
                }
                else
                {
                    var sender = EmployeeManager.GetEmployeeFromSocket(socket);
                    receiveMessage = new Net_OnSendMessage(sendMessage.Message, sender.Email, sendMessage.To,false, Status.Successful);
                    var receiverSocket = EmployeeManager.GetSocketFromMail(sendMessage.To);

                    Net_Log log = new Net_Log($"Employee {EmployeeManager.GetEmployeeFromSocket(socket).Email} has sent message to {EmployeeManager.GetEmployeeFromSocket(receiverSocket).Email}.", LogType.PrivateMessage);
                    WebAPI.instance.DBLogAsync(JsonConvert.SerializeObject(log));

                    receiverSocket.SendFromManager(receiveMessage);
                    socket.SendFromManager(receiveMessage);
                }
            }
            else
            {
                receiveMessage = new Net_OnSendMessage(null, null, null,false, Status.Error);
                socket.SendFromManager(receiveMessage);
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
            socket.SendFromManager(onGetOnlineEmployees);
        }

        private static async Task CheckEmployeeLogin(Socket socket, string data)
        {
            Net_EmployeeLogin loginData = JsonConvert.DeserializeObject<Net_EmployeeLogin>(data);
            
            var response = await WebAPI.instance.EmployeeLoginAsync(JsonConvert.SerializeObject(loginData));
            var responseData = JsonConvert.DeserializeObject<Net_OnEmployeeLogin>(response.GetFirstStringRecord());
            switch (responseData.Status)
            {
                case Status.SuccessfulLogin:
                    if (!EmployeeManager.HasEmployeeSignedIn(loginData.Email))
                    {
                        string token = Utilities.RandomString(10);
                        EmployeeManager.AddOnlineEmployee(new OnlineEmployee(socket, loginData.Email, token,responseData.IsSuperuser));
                        responseData.Token = token;
                    }
                    else
                    {
                        responseData.Status = Status.AlreadyLoggedIn;
                    }
                    socket.SendFromManager(responseData);
                    break;
                case Status.WrongEmailOrPassword:
                    socket.SendFromManager(responseData);
                    break;
                default:
                    break;
            }
        }

        private static async Task CheckEmployeeRegister(Socket socket, string data)
        {
            Net_EmployeeRegister registerData = JsonConvert.DeserializeObject<Net_EmployeeRegister>(data);
            var response = await WebAPI.instance.EmployeeRegisterAsync(JsonConvert.SerializeObject(registerData));
            socket.SendFromManager(JsonConvert.DeserializeObject<Net_OnEmployeeRegister>(response.ToArray()[0]));
        }
    }
}
