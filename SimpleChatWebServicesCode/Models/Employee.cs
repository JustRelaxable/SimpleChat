using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleChatWebServicesCode.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string PasswordHash { get; set; }
        public bool IsSuperuser { get; set; }
    }
}
