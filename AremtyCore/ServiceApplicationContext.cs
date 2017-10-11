using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using AremtyCore.Plugins;

namespace AremtyCore
{
    [Export(typeof(IServiceApplicationContext))]
    public class ServiceApplicationContext : IServiceApplicationContext
    {
        protected HashSet<PluginBase> Plugins { get; set; }

        public IReadOnlyCollection<PluginBase> GetPlugins()
        {
            return new ReadOnlyCollection<PluginBase>(Plugins.ToList());
        }

        public T GetPlugin<T>() where T : PluginBase
        {
            return Plugins.FirstOrDefault(item => item is T) as T;
        }
    }
}
