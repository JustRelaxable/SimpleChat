using System;
using System.Net.Http;
using System.Linq;
using SimpleChatSharedCode;
using System.Threading;
using Newtonsoft.Json;

namespace SimpleChatServerSideCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Use WebAPI class in order to reach API methods.
            //Net_EmployeeRegister employeeInformation = new Net_EmployeeRegister() { IdentityNumber = "12345678900", PasswordHash = "XD" };
            //var data = WebAPI.instance.EmployeeRegisterAsync(JsonConvert.SerializeObject(employeeInformation)).Result;
            //Console.WriteLine(data.ToArray()[0]);

            SocketManager socketManager = new SocketManager();
            ThreadStart threadStart = socketManager.Accept;
            Thread t = new Thread(threadStart);
            t.Start();
            t.Join();
            
        }
    }
}
