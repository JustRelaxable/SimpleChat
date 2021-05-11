using System;
using System.Net.Http;
using System.Linq;

namespace ServerSideCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Use WebAPI class in order to reach API methods.
            Console.WriteLine(WebAPI.instance.WeatherForecastAsync().Result);
        }
    }
}
