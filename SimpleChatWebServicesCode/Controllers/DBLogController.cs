using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleChatSharedCode;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleChatWebServicesCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBLogController : ControllerBase
    {
        // POST api/<DBLogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<Net_Log>(value);
                SqlDatabases.company.Logs.Add(data);
                SqlDatabases.company.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            } 
        }
    }
}
