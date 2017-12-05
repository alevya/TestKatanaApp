using System;
using System.ComponentModel.Composition;

namespace WebHost
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PluginAttribute : ExportAttribute
    {
        public PluginAttribute() : base(typeof(PluginBase))
        {
            
        }
    }

    public abstract class PluginBase
    {
        protected PluginBase()
        {
            
        }

        public virtual void InitPlugin()
        {
            
        }
    }
}