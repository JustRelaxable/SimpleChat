using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleChatSharedCode;
using Newtonsoft.Json;
using System.Net.Http;
using SimpleChatWebServicesCode.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleChatWebServicesCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRegisterController : ControllerBase
    {
        [HttpPut]
        public IEnumerable<string> Put([FromBody] string value)
        {
            try
            {
                Net_EmployeeRegister registerData = JsonConvert.DeserializeObject<Net_EmployeeRegister>(value);
                var employees = SqlDatabases.company.Employees;
                var logs = SqlDatabases.company.Logs;
                if (employees.Any(x=>x.IdentityNumber == registerData.IdentityNumber))
                {
                    if(string.IsNullOrEmpty(employees.Single(x => x.IdentityNumber == registerData.IdentityNumber && x.Email == registerData.Email).PasswordHash))
                    {
                        employees.Single(x => x.IdentityNumber == registerData.IdentityNumber).PasswordHash = registerData.PasswordHash;
                        logs.Add(new Net_Log($"Employee {registerData.Email} has registered to the system.", LogType.Register));
                        SqlDatabases.company.SaveChanges();
                        return new List<string>() { JsonConvert.SerializeObject(new Net_OnEmployeeRegister(Status.Successful))};
                    }
                    else
                    {
                        logs.Add(new Net_Log($"Re-Register attempt by employee {registerData.Email}.", LogType.ReRegister));
                        SqlDatabases.company.SaveChanges();
                        return new List<string>() { JsonConvert.SerializeObject(new Net_OnEmployeeRegister(Status.EmployeeAlreadyExist)) };
                    }
                }
                else
                {
                    logs.Add(new Net_Log($"Wrong Identity given by {registerData.Email}.", LogType.WrongIdentity));
                    SqlDatabases.company.SaveChanges();
                    return new List<string>() { JsonConvert.SerializeObject(new Net_OnEmployeeRegister(Status.IdentityNumberNotFound)) };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
