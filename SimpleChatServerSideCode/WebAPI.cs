using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServerSideCode
{
    static class WebAPI
    {
        public static WebServicesAPI instance { get; private set; }
        static WebAPI()
        {
            instance = new WebServicesAPI("https://localhost:44387/", new HttpClient());
        }
    }
}
