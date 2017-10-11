using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using AremtyCore;
using NLog;

namespace AremtyCore
{
    public class ServiceApplication
    {
        #region Init

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private ServiceApplicationContext _appContext;

        public void Init()
        {
            try
            {
                //Load plugins dll
                LoadPlugins();


                foreach (var plugin  in _appContext.GetPlugins())
                {
                    _logger.Info("init plugin: {0}", plugin.GetType().FullName);
                    plugin.Init();
                }
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error initializing the application when loading plug-ins");
                throw;
            }
        }

        #endregion

        #region Methods

        private void LoadPlugins()
        {
            _logger.Info("Load plugins");
            var aggCatalog = new AggregateCatalog();
            var pluginsDir = new DirectoryInfo(AppSettings.PluginsPath);

            foreach (var dir  in pluginsDir.GetDirectories() )
            {
                
            }

        }
        #endregion
    }
}
