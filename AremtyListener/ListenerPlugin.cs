using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AremtyCore.Plugins;
using System.Configuration;

namespace AremtyListener
{
    [Plugin]
    class ListenerPlugin : PluginBase
    {
        private const string BASE_URL = "http://+:{0}";

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
            
        }

        public override void Stop()
        {

        }

    }
}
