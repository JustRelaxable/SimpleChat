using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using SimpleChatSharedCode;
using Newtonsoft.Json;
using System.IO;
using System.Net.Security;

namespace SimpleChatClientSideCode
{
    static class SocketManager
    {
        public static Socket ClientSocket { get; private set; }
        static SocketManager()
        {
            ClientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            ClientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 53869));
            ReceiveAsync();
        }
        public static void SendFromManager(this Socket socket,Net_Base packet)
        {
            if(socket == ClientSocket)
            {
                var data = JsonConvert.SerializeObject(packet);
                var encodedData = Encoding.ASCII.GetBytes(data);
                socket.Send(encodedData);
            }
            else
            {
                throw new Exception();
            }
        }
        public static async Task<string> ReceiveFromManagerAsync(this Socket socket)
        {
            byte[] rec_bytes = new byte[1024];
            ArraySegment<byte> bytesSeg = new ArraySegment<byte>(rec_bytes);
            int bytesRec = await socket.ReceiveAsync(bytesSeg, SocketFlags.None);
            return Encoding.ASCII.GetString(rec_bytes, 0, bytesRec);
        }

        public static async void ReceiveAsync()
        {
            try
            {
                byte[] rec_bytes = new byte[1024];
                ArraySegment<byte> bytesSeg = new ArraySegment<byte>(rec_bytes);
                int bytesRec = await ClientSocket.ReceiveAsync(bytesSeg, SocketFlags.None);
                //int bytesRec = await SslStream.ReadAsync(bytesSeg);
                string data = Encoding.ASCII.GetString(rec_bytes, 0, bytesRec);
                Net_Base basePacket = JsonConvert.DeserializeObject<Net_Base>(data);
                

                switch (basePacket.OpCode)
                {
                    case OpCode.Debug:
                        MessageBox.Show("Debug");
                        break;
                    case OpCode.OnEmployeeRegister:
                        EventManager.OnEmployeeRegister(JsonConvert.DeserializeObject<Net_OnEmployeeRegister>(data));
                        break;
                    case OpCode.OnEmployeeLogin:
                        EventManager.OnEmployeeLogin(JsonConvert.DeserializeObject<Net_OnEmployeeLogin>(data));
                        break;
                    case OpCode.OnGetOnlineEmployees:
                        EventManager.OnGetOnlineEmployees(JsonConvert.DeserializeObject<Net_OnGetOnlineEmployees>(data));
                        break;
                    case OpCode.OnSendMessage:
                        EventManager.OnSendMessage(JsonConvert.DeserializeObject<Net_OnSendMessage>(data));
                        break;
                    default:
                        break;
                }
                ReceiveAsync();
            }
            catch (Exception)
            {
            }

        }
    }
}
