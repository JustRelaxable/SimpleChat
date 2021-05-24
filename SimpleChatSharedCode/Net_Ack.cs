using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChatSharedCode
{
    class Net_Ack : Net_Base
    {

        public Net_Ack() : base(OpCode.Ack)
        {

        }
    }
}
