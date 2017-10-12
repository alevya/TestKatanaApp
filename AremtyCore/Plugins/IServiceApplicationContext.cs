using System.Collections.Generic;

namespace AremtyCore.Plugins
{
    public interface IServiceApplicationContext
    {
        IReadOnlyCollection<PluginBase> GetPlugins();
        T GetPlugin<T>() where T : PluginBase;

    } 
}
