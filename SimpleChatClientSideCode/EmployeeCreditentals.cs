using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatClientSideCode
{
    class EmployeeCreditentals
    {
        public static string Token { get; set; }
        public static string Email { get; set; }

        static EmployeeCreditentals()
        {
            Email = "";
            Token = "";
        }
    }
}
