using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace AremtyCore
{
    public static class AppSettings
    {
        private static string AppSettingsValue(string key, string defaultValue = null)
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        public static string ExecutablePath
        {
            get
            {
                string exePath = Assembly.GetExecutingAssembly().Location;
                return Path.GetDirectoryName(exePath);
            }
        }

        public static string PluginsDirectory => AppSettingsValue("pluginsDirectory", "Plugins");

        public static string PluginsPath => Path.IsPathRooted(PluginsDirectory)
                                                    ? PluginsDirectory
                                                    : Path.Combine(ExecutablePath, PluginsDirectory);

    }
}
