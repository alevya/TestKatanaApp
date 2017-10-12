using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Text;
using AremtyCore;
using AremtyCore.Plugins;
using NLog;

namespace AremtyCore
{
    public class ServiceApplication
    {
        #region Init

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Import(typeof(IServiceApplicationContext))]
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

        public void StartServices()
        {
            try
            {
                foreach (var plugin in _appContext.GetPlugins())
                {
                    _logger.Info("Start plugin: {0}", plugin.GetType().FullName);
                    plugin.Start();
                }
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error on start plugin");
                throw;
            }
            _logger.Info("All plugins starting");

        }

        public void StopServices()
        {
            foreach (var plugin in _appContext.GetPlugins())
            {
                try
                {
                    _logger.Info("Stop plugin: {0}", plugin.GetType().FullName);
                    plugin.Stop();
                }
                catch (Exception e)
                {
                    _logger.Info(e, "Error on stop plugin");
                }
                
            }

            _logger.Info("All plugins stopping");
        }

        private void LoadPlugins()
        {
            _logger.Info("Load plugins");

            var hsDirectories = new HashSet<string>();
            var aggCatalog = new AggregateCatalog();
            var pluginsDir = new DirectoryInfo(AppSettings.PluginsPath);

            //Пока загрузка из директории, в которую собираются плагины
            foreach (var dir  in pluginsDir.GetDirectories() )
            {
                var sDir = new DirectoryCatalog(dir.FullName);
                aggCatalog.Catalogs.Add(sDir);
                hsDirectories.Add(dir.FullName);
            }

            //AppDomain.CurrentDomain.SetupInformation.PrivateBinPath = string.Join(";", hsDirectories);
            var container = new CompositionContainer(aggCatalog);
            container.SatisfyImportsOnce(this);

        }
        #endregion
    }
}
