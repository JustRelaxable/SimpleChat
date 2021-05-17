using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleChatSharedCode;

namespace SimpleChatClientSideCode
{
    class EventManager
    {
        public static event EventHandler<Net_OnEmployeeRegister> EmployeeRegister;
        public static event EventHandler<Net_OnEmployeeLogin> EmployeeLogin;
        public static event EventHandler<Net_OnGetOnlineEmployees> GetOnlineEmployees;
        public static event EventHandler<Net_OnSendMessage> SendMessage;
        
        public static void OnSendMessage(Net_OnSendMessage response)
        {
            SendMessage.Invoke(null, response);
        }
        public static void OnGetOnlineEmployees(Net_OnGetOnlineEmployees response)
        {
            GetOnlineEmployees.Invoke(null, response);
        }

        public static void OnEmployeeLogin(Net_OnEmployeeLogin response)
        {
            EmployeeLogin.Invoke(null,response);
        }

        public static void OnEmployeeRegister(Net_OnEmployeeRegister response)
        {
            EmployeeRegister.Invoke(null,response);
        }
    }
}
