using System;
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


                foreach (var plugin  in _appContext.GetPlugins())
                {
                    _logger.Info("init plugin: {0}", plugin.GetType().FullName);
                    plugin.Init();
                }
            }
            catch (Exception e)
            {
                _logger.Error(e, "Ошибка инициализации приложения при загрузке плагинов");
                throw;
            }
        }

        #endregion
    }
}
