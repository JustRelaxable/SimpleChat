using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChatSharedCode
{
    class Net_GetOnlineEmployees : Net_Base
    {
        public string Token { get; set; }
        public Net_GetOnlineEmployees(string _token) : base(OpCode.GetOnlineEmployees)
        {
            Token = _token;
        }
    }
}
