using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Hosting;
using Microsoft.Owin;
using Owin;
using WebHost;


[assembly: OwinStartup(typeof(Startup))]
[assembly: PreApplicationStartMethod(typeof(Startup), "StartupMethod")]

namespace WebHost
{
    public class Startup
    {
        private static readonly DirectoryInfo _pluginsDirectory;
        static Startup()
        {
            string pluginPath = HostingEnvironment.MapPath("~/Plugins");
            ConfigurationManager.AppSettings["pluginsDirectory"] = pluginPath;

            if (pluginPath == null)
            {
                throw new DirectoryNotFoundException("Plugins");
            }
            _pluginsDirectory = new DirectoryInfo(pluginPath);
        }

        public static void StartupMethod()
        {
            //Directory.CreateDirectory(_pluginsDirectory.FullName);

            
            //var aremtyApp = new ServiceApplication();
            //ListenerPlugin lp = new ListenerPlugin();
            //lp.Start();
            //aremtyApp.Init();
            //aremtyApp.StartServices();
            //Console.ReadLine();

            //aremtyApp.StopServices();
        }

        public void Configuration(IAppBuilder app)
        {
            //app.Run(context =>
            //{
            //    var err = new Error404Module(null);
            //    return err.Invoke()
            //});
            //app.Use<Error404Module>();
        }


    }
}
