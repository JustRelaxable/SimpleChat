using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimpleChatSharedCode
{
    class Net_OnSendMessage : Net_Base
    {
        public string From { get; set; }
        public string To { get; set; }

        public string Message { get; set; }
        public bool IsServerMessage { get; set; }

        [JsonConstructor]
        public Net_OnSendMessage()
        {

        }

        public Net_OnSendMessage(string _message,string _from,string _to,bool _isServerMessage,Status _status) : base(OpCode.OnSendMessage,_status)
        {
            To = _to;
            From = _from;
            Message = _message;
            IsServerMessage = _isServerMessage;
        }
    }
}
