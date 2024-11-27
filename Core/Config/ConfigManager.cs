using Newtonsoft.Json;
using System.IO;

namespace AutomationFramework.Core.Config
{
    public static class ConfigManager
    {
        private static readonly string ConfigFilePath = "Resources/Config.json";

        public static T GetConfigValue<T>(string key)
        {
            var configData = File.ReadAllText(ConfigFilePath);
            var config = JsonConvert.DeserializeObject<dynamic>(configData);
            return (T)config[key];
        }
    }
}
