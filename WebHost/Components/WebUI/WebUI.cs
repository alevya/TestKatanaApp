using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHost.Modules.HandlersModule;

namespace WebHost.Components.WebUI
{
    public class WebUI
    {
        public WebUI()
        {
            
        }

        [HttpCommand("/")]
        public object Get(HttpRequestParams reqParam)
        {
            return "Test Api";
        }
    }
}