using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Owin;
using WebHost.Modules;
using System.Collections.Concurrent;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Web.Hosting;
using WebHost.Modules.HandlersModule;

namespace WebHost
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        [ImportMany("HttpCommand")]
        public Lazy<Func<HttpRequestParams, object>, IHttpCommandAttribute>[] RequestReceived { get; set; }

        [ImportMany(typeof(PluginBase))]
        public HashSet<PluginBase> Plugins { get; set; }

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
                .Use(typeof(LoggerModule), "Logger module")
                .Use<HandlersModule>(_handlers)
                .Use<Error404Module>();



        }

        private ConcurrentDictionary<string, IHandler> _registerHandlers()
        {
            var handlers = new ConcurrentDictionary<string, IHandler>();
            foreach (var item in RequestReceived)
            {
                var url = item.Metadata.Url;
                var h = new ApiHandler(item.Value);
                handlers.TryAdd(url, h);
            }

            foreach (var item in Plugins )
            {
                var type = item.GetType();
                foreach (var attr in type.GetCustomAttributes<HttpResourceAttribute>())
                {
                    var resorceHandler = new ResourceHandler(type.Assembly, attr);
                    handlers.TryAdd(attr.Url, resorceHandler);
                }
            }

            return handlers;
        }
    }
}