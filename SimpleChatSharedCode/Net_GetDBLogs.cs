using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimpleChatSharedCode
{
    [System.Serializable]
    class Net_GetDBLogs : Net_Base
    {
        public string Token { get; set; }
        [JsonConstructor]
        public Net_GetDBLogs()
        {

        }
        public Net_GetDBLogs(string _token) : base(OpCode.GetDBlogs)
        {
            Token = _token;
        }
    }
}
