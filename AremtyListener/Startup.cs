using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AremtyListener.Startup))]
namespace AremtyListener
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<Error404Module>();
        }

        
    }
}
