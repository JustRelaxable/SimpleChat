using Newtonsoft.Json;
using SimpleChatSharedCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatServerSideCode
{
    static class SocketUtilities
    {

        public static void SendFromManager(this Socket socket, Net_Base packet)
        {

            var data = JsonConvert.SerializeObject(packet);
            var encodedData = Encoding.ASCII.GetBytes(data);

            byte[] dataToSend = new byte[1024];

            AesManaged aes = new AesManaged();
            aes.Padding = PaddingMode.Zeros;
            ICryptoTransform encryptor = aes.CreateEncryptor("1234567812345678".GetASCIIBytes(), "1234567812345678".GetASCIIBytes());

            using (MemoryStream ms = new MemoryStream(dataToSend))
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
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
    }
}
