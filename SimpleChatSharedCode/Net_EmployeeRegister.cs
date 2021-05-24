using System;
using System.Collections.Generic;
using System.Text;
using SimpleChatSharedCode;

namespace SimpleChatSharedCode
{
    [System.Serializable]
    class Net_EmployeeRegister : Net_Base
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public Net_EmployeeRegister(string _email,string _passwordHash) : base(OpCode.EmployeeRegister)
        {
            Email = _email;
            PasswordHash = _passwordHash;
        }
    }
}
