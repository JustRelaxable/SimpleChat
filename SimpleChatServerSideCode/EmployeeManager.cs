using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatServerSideCode
{
    class EmployeeManager
    {
        private static EmployeeManager instance;
        Dictionary<Socket, OnlineEmployee> socketDictionary = new Dictionary<Socket, OnlineEmployee>();
        Dictionary<string, Socket> mailDictionary = new Dictionary<string, Socket>();

        static EmployeeManager()
        {
            instance = new EmployeeManager();
        }

        public static bool HasEmployeeSignedIn(Socket socket)
        {
            return instance.socketDictionary.ContainsKey(socket);
        }

        public static void AddOnlineEmployee(OnlineEmployee employee)
        {
            instance.socketDictionary.Add(employee.Socket, employee);
            instance.mailDictionary.Add(employee.Email, employee.Socket);
        }

        public static bool IsValidToken(Socket socket,string token)
        {
            var employee = new OnlineEmployee();
            if(instance.socketDictionary.TryGetValue(socket,out employee))
            {
                return employee.Token == token;
            }
            else
            {
                return false;
            }
        }

        public static void RemoveOnlineEmployee(Socket _socket)
        {
            var employee = instance.socketDictionary[_socket];
            instance.mailDictionary.Remove(employee.Email);
            instance.socketDictionary.Remove(_socket);
        }
        
        public static List<string> GetOnlineEmployees()
        {
            var data = instance.socketDictionary.Values.ToArray();
            List<string> mailList = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                mailList.Add(data[i].Email);
            }
            return mailList;
        }

        public static OnlineEmployee GetEmployeeFromSocket(Socket socket)
        {
            return instance.socketDictionary[socket];
        }

        public static Socket GetSocketFromMail(string mail)
        {
            return instance.mailDictionary[mail];
        }

        public static List<Socket> GetOnlineEmployeeSockets()
        {
            return instance.socketDictionary.Keys.ToList();
        }

        public static bool IsEmployeeSuperuser(Socket socket)
        {
            return instance.socketDictionary[socket].IsSuperuser;
        }
    }

    class OnlineEmployee
    {
        public Socket Socket { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool IsSuperuser { get; set; }
        public DateTime LoginTime { get; set; }

        public OnlineEmployee(Socket _socket,string _email,string _token,bool _isSuperuser)
        {
            Socket = _socket;
            Email = _email;
            Token = _token;
            IsSuperuser = _isSuperuser;
            LoginTime = DateTime.UtcNow;
        }
        public OnlineEmployee()
        {

        }
    }
}
