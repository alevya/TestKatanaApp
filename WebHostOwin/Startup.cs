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

            //ServiceApplication app = new ServiceApplication();
            //app.Init();

            app.Run(context =>
            {
                //context.Response.ContentType = "text/html; charset=utf-8";
                //return context.Response.WriteAsync("<h2>Hello, world!</h2>");
                return Task.Delay(0);
            });
        }
    }
}
