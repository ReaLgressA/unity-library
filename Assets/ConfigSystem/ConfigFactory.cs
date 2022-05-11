using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace ConfigSystem {
    public class ConfigFactory : IConfigFactory {
        private readonly JsonSerializer jsonSerializer;
        
        public List<JsonConverter> Converters { get; }

        public JsonSerializer JsonSerializer => jsonSerializer;
        
        public ConfigFactory(List<JsonConverter> converters) {
            Converters = converters ?? new();
            jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings {
                Converters = Converters
            });
        }
        
        public virtual T BuildFromJson<T>(string json) where T : BaseConfig {
            using StringReader stringReader = new(json);
            using JsonTextReader jsonReader = new(stringReader);
            try {
                return jsonSerializer.Deserialize<T>(jsonReader);
            } catch (Exception ex) {
                Debug.LogException(ex);
                return null;
            }
        }
    }
}