using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using WebHost.Modules;
using System.Collections.Concurrent;
using System.ComponentModel.Composition.Hosting;
using System.Web.Hosting;
using WebHost.Modules.HandlersModule;

namespace WebHost
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        [ImportMany("HttpCommand")]
        public Lazy<Func<HttpRequestParams, object>, IHttpCommandAttribute>[] RequestReceived { get; set; }

        private ConcurrentDictionary<string, IHandler> _handlers = new ConcurrentDictionary<string, IHandler>();


        public void Configuration(IAppBuilder appBuilder)
        {

            string path = HostingEnvironment.MapPath("~/");
            var catalog = new AggregateCatalog();
            var subCatalog = new DirectoryCatalog(path);
            catalog.Catalogs.Add(subCatalog);
            var container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(this);

            appBuilder
                //.Use(new Func<AppFunc, AppFunc>(next =>
                
                //    new AppFunc(env =>
                //        {
                //            return next(env);
                //        }
                //    )))
                .Use(typeof(LoggerModule), "Logger module")
                .Use<HandlersModule>(_handlers)
                .Use<Error404Module>();



        }
    }
}