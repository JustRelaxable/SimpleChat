using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleChatWebServicesCode.Models;

namespace SimpleChatWebServicesCode
{
    public static class SqlDatabases
    {
        public static CompanyDB company;
        static SqlDatabases()
        {
            company = new CompanyDB(SqlInformation.connectionString);
            company.Database.CreateIfNotExists();
        }
    }
}
