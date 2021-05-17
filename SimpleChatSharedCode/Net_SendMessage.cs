using System;
using System.Collections.Generic;
using System.Text;
using SimpleChatSharedCode;
using Newtonsoft.Json;

namespace SimpleChatSharedCode
{
    class Net_SendMessage : Net_Base
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public string To { get; set; }
        public bool IsServerMessage { get; set; }

        [JsonConstructor]
        public Net_SendMessage()
        {

        }
        public Net_SendMessage(string _message,string _to,string _token,bool _isServerMessage) : base(OpCode.SendMessage)
        {
            Token = _token;
            Message = _message;
            To = _to;
            IsServerMessage = _isServerMessage;
        }
    }
}
