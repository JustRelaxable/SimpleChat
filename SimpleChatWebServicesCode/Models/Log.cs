using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleChatWebServicesCode.Models
{
    public class Log
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string LogData { get; set; }
        public LogType LogType { get; set; }

        public Log(string _logdata,LogType _logtype)
        {
            DateTime = DateTime.UtcNow;
            LogData = _logdata;
            LogType = _logtype;
        }
    }

    public enum LogType
    {
        Register,SuccesfulLogin,ReRegister,WrongIdentity,WrongPassword
    }
}
