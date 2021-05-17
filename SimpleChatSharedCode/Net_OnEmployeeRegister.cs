using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChatSharedCode
{
    class Net_OnEmployeeRegister : Net_Base
    {
        public Net_OnEmployeeRegister(Status _status) : base(OpCode.OnEmployeeRegister,_status)
        {

        }
    }
}
