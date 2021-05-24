using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimpleChatSharedCode
{
    class Net_OnGetDBLogs : Net_Base
    {
        public List<Net_Log> Logs { get; set; }
        public byte PackageNumber { get; set; }
        public byte Packages { get; set; }
        [JsonConstructor]
        public Net_OnGetDBLogs()
        {

        }
        public Net_OnGetDBLogs(List<Net_Log> _logs,byte _packageNumber,byte _packages,Status _status) : base(OpCode.OnGetDBLogs,_status)
        {
            Logs =  _logs;
            PackageNumber = _packageNumber;
            Packages = _packages;
        }
    }
}
