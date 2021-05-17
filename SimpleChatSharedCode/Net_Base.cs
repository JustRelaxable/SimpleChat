using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimpleChatSharedCode
{
    [System.Serializable]
    class Net_Base
    {
        public OpCode OpCode { get; set; }
        public Status Status { get; set; }

        [JsonConstructor]
        public Net_Base()
        {

        }
        public Net_Base(OpCode _opcode,Status _status = Status.None)
        {
            OpCode = _opcode;
            Status = _status;
        }
    }
}
