using System.Collections.Generic;
using UnityEngine;
using ConfigSystem.Utility;
using Newtonsoft.Json;

namespace ConfigSystem {
    public class ConfigManager : IConfigManager {
        private readonly IConfigFactory configFactory;
        private readonly Dictionary<string, BaseConfig> loadedConfigs = new();

        public IConfigFactory ConfigFactory => configFactory;
        
        public ConfigManager(IConfigFactory configFactory) {
            this.configFactory = configFactory;
            foreach (JsonConverter converter in configFactory.Converters)
            {
                if (converter is IConfigManagerDependant configManagerUser) {
                    configManagerUser.ConfigManager = this;
                }
            }
        }

        public T LoadFromStreamingAssets<T>(string path) where T : BaseConfig {
            if (string.IsNullOrWhiteSpace(path)) {
                Debug.LogError("LoadFromStreamingAssets: path is null or empty!");
                return null;
            }
            
            if (loadedConfigs.ContainsKey(path)) {
                return loadedConfigs[path] as T;
            }

            string json = StringExtensions.ReadTextFile(path);
            if (json == null) {
                return null;
            }

            T config = configFactory.BuildFromJson<T>(json);
            if (config != null) {
                loadedConfigs.Add(path, config);
            } else {
                Debug.LogError($"Failed to load config '{typeof(T)}' by path: '{path}'");
            }

            return config;
        }
    }
}