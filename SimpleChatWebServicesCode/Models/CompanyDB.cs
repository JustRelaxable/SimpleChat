using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleChatWebServicesCode.Models
{
    public class CompanyDB : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Log> Logs { get; set; }
        public CompanyDB(string conn) : base(conn)
        {

        }
    }
}
