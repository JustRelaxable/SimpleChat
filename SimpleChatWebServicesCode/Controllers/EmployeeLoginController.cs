using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleChatSharedCode;
using SimpleChatWebServicesCode.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleChatWebServicesCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLoginController : ControllerBase
    {
        // POST api/<EmployeeLoginController>
        [HttpPost]
        public IEnumerable<string> Post([FromBody] string value)
        {
            try
            {
                var employeeLogin = JsonConvert.DeserializeObject<Net_EmployeeLogin>(value);
                if(SqlDatabases.company.Employees.Any(x=>x.Email == employeeLogin.Email && x.PasswordHash == employeeLogin.PasswordHash))
                {
                    //GiveToken On Server Side
                    SqlDatabases.company.Logs.Add(new Net_Log($"Successful login by {employeeLogin.Email}.", LogType.SuccesfulLogin));
                    SqlDatabases.company.SaveChanges();
                    return new List<string> { JsonConvert.SerializeObject(new Net_OnEmployeeLogin(null,Status.SuccessfulLogin)) };
                }
                else
                {
                    SqlDatabases.company.Logs.Add(new Net_Log($"Wrong password given by {employeeLogin.Email}.", LogType.WrongPassword));
                    SqlDatabases.company.SaveChanges();
                    return new List<string> { JsonConvert.SerializeObject(new Net_OnEmployeeLogin(null,Status.WrongEmailOrPassword)) };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
