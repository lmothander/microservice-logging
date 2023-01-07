using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleAppLogger
{
    public static class LogzIoService
    {        
        static void Log(string message, string token, string region)
        {
            var data = MessageToHttpTextContent(message);
            using (var client = new HttpClient())
            {
                var result = client.PostAsync(TokenToUrl(token, region), data).Result;
            }
        }        

        public static void LogCa(string message, string token)
        {
            Log(message, token, "-ca");
        }

        public static void LogEa(string message, string token)
        {
            Log(message, token, "-eu");
        }

        public static void LogUs(string message, string token)
        {
            Log(message, token, string.Empty);
        }

        static HttpContent MessageToHttpTextContent(string message)
        {
            String val = string.Format("{{\"message\": \"{0}\" }}", message);
            return new StringContent(val, Encoding.UTF8, "text/plain");
        }

        static string TokenToUrl(string token, string region)
        {
            var url = new UriBuilder();
            url.Host = string.Format("listener{0}.logz.io", region);
            url.Scheme = Uri.UriSchemeHttps;
            url.Query = string.Format("token={0}", token);
            return url.Uri.ToString();
        }
    }
}
