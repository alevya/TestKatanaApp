using System.Collections.Generic;

namespace AremtyCore.Plugins
{
    interface IServiceApplicationContext
    {
        IReadOnlyCollection<PluginBase> GetPlugins();
        T GetPlugin<T>() where T : PluginBase;

    } 
}
