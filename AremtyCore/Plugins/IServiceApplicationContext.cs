using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AremryCore.Plugins
{
    interface IServiceApplicationContext
    {
        IReadOnlyCollection<PluginBase> GetPlugins();
        T GetPlugin<T>() where T : PluginBase;

    } 
}
