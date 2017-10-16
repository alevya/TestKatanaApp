using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Hosting;
using AremtyCore;
using WebHost;

//[assembly: OwinStartup(typeof(WebHostOwin.Startup))]
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

            
            var aremtyApp = new ServiceApplication();
            aremtyApp.Init();
            aremtyApp.StartServices();

            aremtyApp.StopServices();
        }


    }
}
