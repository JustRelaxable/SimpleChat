using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChatSharedCode
{
    public enum OpCode
    {
        Debug,
        EmployeeRegister,OnEmployeeRegister,
        EmployeeLogin,OnEmployeeLogin,
        GetOnlineEmployees,OnGetOnlineEmployees,
        SendMessage,OnSendMessage,
        GetDBlogs,OnGetDBLogs,
        Ack
    }
}
