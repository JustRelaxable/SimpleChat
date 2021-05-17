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
        public string IdentityNumber { get; set; }
        public string PasswordHash { get; set; }

        public Net_EmployeeRegister(string _email,string _idno,string _passwordHash) : base(OpCode.EmployeeRegister)
        {
            Email = _email;
            IdentityNumber = _idno;
            PasswordHash = _passwordHash;
        }
    }
}
