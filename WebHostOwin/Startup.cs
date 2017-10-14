using System;
using System.EnterpriseServices;
using System.Threading.Tasks;
using AremtyCore;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebHostOwin.Startup))]

namespace WebHostOwin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var aremtyApp = new ServiceApplication();
            aremtyApp.Init();
            aremtyApp.StartServices();

            Console.WriteLine("Service is start. Press ENTER key to exit");
            Console.ReadLine();

            aremtyApp.StopServices();
        }
    }
}
