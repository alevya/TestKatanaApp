using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using WebHost.Modules;


namespace WebHost
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            //Creation, configuration and installation of modules for the pipeline

            //var config = new HttpConfiguration();
            //config.Routes.MapHttpRoute("default", "{controller}");
            //appBuilder.UseWebApi(config);

            appBuilder
                .Use(new Func<AppFunc, AppFunc>(next =>
                
                    new AppFunc(env =>
                        {
                            return next(env);
                        }
                    )))
                .Use(typeof(LoggerModule), "Logger module")
                .Use<Error404Module>();



        }
    }
}