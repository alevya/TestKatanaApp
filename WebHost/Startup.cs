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
using System.IO;
using System.Web.Hosting;
using WebHost.Modules.HandlersModule;

namespace WebHost
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        [ImportMany("{DD74B74D-BEDD-48EC-981C-D85FEEBC55A6}")]
        public Lazy<Func<HttpRequestParams, object>, IHttpCommandAttribute>[] RequestReceived { get; set; }

        private ConcurrentDictionary<string, IHandler> _handlers = new ConcurrentDictionary<string, IHandler>();


        public void Configuration(IAppBuilder appBuilder)
        {
            var dirs = new HashSet<string>();
            string path = HostingEnvironment.MapPath("~/");

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new ApplicationCatalog());
            //var subCatalog = new DirectoryCatalog(path);

            var dirRoot = new DirectoryInfo(path); 
            foreach (var dir in dirRoot.GetDirectories())
            {
                var sDir = new DirectoryCatalog(dir.FullName);
                catalog.Catalogs.Add(sDir);
                dirs.Add(dir.FullName);
            }
            //catalog.Catalogs.Add(subCatalog);
            AppDomain.CurrentDomain.SetupInformation.PrivateBinPath = string.Join(";", dirs);
            var container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(this);

            _handlers = _registerHandlers();
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

        private ConcurrentDictionary<string, IHandler> _registerHandlers()
        {
            var handlers = new ConcurrentDictionary<string, IHandler>();
            foreach (var item in RequestReceived)
            {
                
            }
            return handlers;
        }
    }
}