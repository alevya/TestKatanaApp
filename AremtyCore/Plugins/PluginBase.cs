using System;
using System.ComponentModel.Composition;
using System.Linq;
using NLog;

namespace AremtyCore.Plugins
{
    public abstract class PluginBase
    {
        #region Init
        [Import(typeof(IServiceApplicationContext))]
        private IServiceApplicationContext _context;

        protected PluginBase()
        {
            Logger = LogManager.GetLogger(GetType().FullName);
        }

        #endregion

        #region Interfaces Methods

        public virtual void Init()
        {
            
        }

        public virtual void Start()
        {
        }

        public virtual void Stop()
        {
            
        }

        #endregion

        #region aux

        protected Logger Logger { get; }

        protected IServiceApplicationContext Context => _context;

        public void Run<T>(T[] actions, Action<T> task)
        {
            if(actions == null || !actions.Any()) return;

            foreach (var action in actions)
            {
                try
                {
                    task(action);
                }
                catch (Exception e)
                {
                    Logger.Error(e, e.Message);
                }
            }
        }

        #endregion
    }


}
