using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleChatSharedCode;
using System.Threading.Tasks;

namespace SimpleChatWebServicesCode.Models
{
    public class CompanyDB : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Net_Log> Logs { get; set; }
        public CompanyDB(string conn) : base(conn)
        {

        }
    }
}
