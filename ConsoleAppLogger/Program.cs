using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace ConsoleAppLogger
{
    class Program
    {
        static void Main(string[] args)
        {           
            string token = "FXcAsIMjUpPZYZyjqFtWnSJhnYHDTeHK";
            LogzIoService.LogCa("testmessage", token);
            LogzIoService.LogUs("testmessage", token);
        }       
    }
}
