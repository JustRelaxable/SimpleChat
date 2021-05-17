using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace SimpleChatWebServicesCode
{
    public static class SqlInformation
    {
        public static string connectionString = "Server=tcp:cmpe322.database.windows.net,1433;Initial Catalog=CompanyDB;Persist Security Info=False;User ID=cmpe322;Password='@/mv;_$/T8g7';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        static SqlInformation()
        {
            
        }
    }
}
