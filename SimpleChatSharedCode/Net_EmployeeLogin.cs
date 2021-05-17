using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChatSharedCode
{
    class Net_EmployeeLogin : Net_Base
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }


        public Net_EmployeeLogin(string _email,string _passwordHash) : base(OpCode.EmployeeLogin)
        {
            Email = _email;
            PasswordHash = _passwordHash;
        }
    }
}
