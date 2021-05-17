using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChatSharedCode
{
    class Net_OnGetOnlineEmployees : Net_Base
    {
        public List<string> EmployeeMails { get; set; }
        public Net_OnGetOnlineEmployees(List<string> _list,Status _status) : base(OpCode.OnGetOnlineEmployees,_status)
        {
            EmployeeMails = _list;
        }
    }
}
