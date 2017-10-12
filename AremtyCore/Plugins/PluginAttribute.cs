using System;
using System.ComponentModel.Composition;

namespace AremtyCore.Plugins
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginAttribute : ExportAttribute
    {
        public PluginAttribute() : base(typeof(PluginBase))
        {
            
        }
    }
}
