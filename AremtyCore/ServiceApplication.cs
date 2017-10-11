using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Fluent;

namespace AremryCore
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
