using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleChatWebServicesCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDBLogsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var last20 = SqlDatabases.company.Logs.OrderByDescending(x => x.ID).Take(20).ToArray();
            List<string> response = new List<string>();

            if (last20.Length > 0)
            {
                foreach (var item in last20)
                {
                    var data = JsonConvert.SerializeObject(item);
                    response.Add(data);
                }
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
