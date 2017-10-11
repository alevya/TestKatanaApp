using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SelfHostOwin
{
    class Program
    {
        private static string BASE_URL_HTTP_FORMAT = "http://127.0.0.1:{0}";
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: BaseUrl))
            {
                Console.WriteLine("Server start...");
                Console.ReadLine();
                //HttpClient client = new HttpClient();
                //var response = client.GetAsync(BaseUrl + "/numbers").Result;
                //Console.WriteLine(response);
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }

        private static string BaseUrl
        {
            get
            {
                var port = "80";
                return string.Format(BASE_URL_HTTP_FORMAT, port);
            }
        }
    }
}
