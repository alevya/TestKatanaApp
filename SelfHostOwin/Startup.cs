using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

//[assembly:OwinStartup(typeof(SelfHostOwin.Startup))]
namespace SelfHostOwin
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           app.Run(context =>
           {
               context.Response.ContentType = "text/html; charset=utf-8";
               return context.Response.WriteAsync("<h2>Hello, world!</h2>");
           });
        }
    }
}
