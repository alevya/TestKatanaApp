using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHost.Modules.HandlersModule;

namespace WebHost.Components.WebUI
{
    [HttpEmbeddedResource("/", "WebHost.Components.WebUI.Resources.App.index.html", "text/html")]

    [Plugin]
    public class WebUI : PluginBase
    {
        public WebUI()
        {
            
        }

        public override void InitPlugin()
        {
            base.InitPlugin();
        }

        [HttpCommand("/1")]
        public object Get(HttpRequestParams reqParam)
        {
            return "Test Api";
        }

    }
}