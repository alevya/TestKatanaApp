using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AremtyCore.Plugins;
using System.Configuration;
using Owin;
using Microsoft.Owin.Hosting;


namespace AremtyListener
{
    [Plugin]
    public class ListenerPlugin : PluginBase
    {
        private const string BASE_URL = "http://+:{0}";
        private IDisposable _srv;

        private static string BaseUrl
        {
            get
            {
                var port = ConfigurationManager.AppSettings["AremtyListener.Port"] ?? "55555";
                return string.Format(BASE_URL, port);
            }
        }

        public override void Start()
        {
            _srv = WebApp.Start<Startup>(BaseUrl);
        }

        public override void Stop()
        {
            _srv.Dispose();
        }

    }
}
