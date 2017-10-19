using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Owin;
using WebHost.Modules;


namespace WebHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            //Creation, configuration and installation of modules for the pipeline

            //var config = new HttpConfiguration();
            //config.Routes.MapHttpRoute("default", "{controller}");
            //appBuilder.UseWebApi(config);

            appBuilder.Use<Error404Module>();


        }
    }
}