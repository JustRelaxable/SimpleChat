using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimpleChatSharedCode
{
    class Net_OnEmployeeLogin : Net_Base
    {
        public string Token { get; set; }

        [JsonConstructor]
        public Net_OnEmployeeLogin()
        {

        }

        public Net_OnEmployeeLogin(string _token,Status _status) : base(OpCode.OnEmployeeLogin,_status)
        {
            Token = _token;
        }
    }
}
