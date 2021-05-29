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
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Security.Authentication;

namespace SimpleChatClientSideCode
{
    static class SocketManager
    {
        public static Socket ClientSocket { get; private set; }
        /*
        private static readonly string ClientCertificateFile = @"C:\Users\JustRelaxable\Desktop\Source\SslClient\SslClient\client.pfx";
        private static readonly string ClientCertificatePassword = null;
        private static readonly string ServerCertificateName = "MyServer";
        static X509Certificate2 clientCertificate = new X509Certificate2(ClientCertificateFile, ClientCertificatePassword);
        static X509CertificateCollection clientCertificateCollection = new X509CertificateCollection(new X509Certificate[] { clientCertificate });
        */
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
                
                byte[] dataToSend = new byte[1024];

                AesManaged aes = new AesManaged();
                aes.Padding = PaddingMode.Zeros;
                ICryptoTransform encryptor = aes.CreateEncryptor("1234567812345678".GetASCIIBytes(), "1234567812345678".GetASCIIBytes());

                using (MemoryStream ms = new MemoryStream(dataToSend))
                {
                    using (CryptoStream cs = new CryptoStream(ms,encryptor,CryptoStreamMode.Write))
                    {
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(data + "\0");
                                sw.Flush();
                            }
                    }
                }
                
                /*
                using (var sslStream = new SslStream(new NetworkStream(socket), false, App_CertificateValidation))
                {
                    sslStream.AuthenticateAsClient(ServerCertificateName, clientCertificateCollection, SslProtocols.Tls12, false);
                    sslStream.Write(encodedData);
                }
                */
                socket.Send(dataToSend);
            }
            else
            {
                throw new Exception();
            }
        }

        private static bool App_CertificateValidation(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None) { return true; }
            if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors) { return true; } //we don't have a proper certificate tree
            Console.WriteLine("*** SSL Error: " + sslPolicyErrors.ToString());
            return false;
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
                ReceiveAsync();
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
                        SocketManager.ClientSocket.SendFromManager(new Net_Ack());
                        break;
                    case OpCode.OnEmployeeLogin:
                        EventManager.OnEmployeeLogin(JsonConvert.DeserializeObject<Net_OnEmployeeLogin>(data));
                        SocketManager.ClientSocket.SendFromManager(new Net_Ack());
                        break;
                    case OpCode.OnGetOnlineEmployees:
                        EventManager.OnGetOnlineEmployees(JsonConvert.DeserializeObject<Net_OnGetOnlineEmployees>(data));
                        SocketManager.ClientSocket.SendFromManager(new Net_Ack());
                        break;
                    case OpCode.OnSendMessage:
                        EventManager.OnSendMessage(JsonConvert.DeserializeObject<Net_OnSendMessage>(data));
                        SocketManager.ClientSocket.SendFromManager(new Net_Ack());
                        break;
                    case OpCode.OnGetDBLogs:
                        EventManager.OnGetDBLogs(JsonConvert.DeserializeObject<Net_OnGetDBLogs>(data));
                        SocketManager.ClientSocket.SendFromManager(new Net_Ack());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }

        }
    }
}
