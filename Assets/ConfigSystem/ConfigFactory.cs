using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConfigSystem {
    public class ConfigFactory : IConfigFactory {
        private readonly Dictionary<string, Func<Hashtable, BaseConfig>> configTypeFactory = new ();
        private readonly JsonSerializer jsonSerializer;
        
        public List<JsonConverter> Converters { get; protected set; } = new();
        
        public ConfigFactory() {
            jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings {
                Converters = Converters
            });
        }
        
        public virtual T BuildFromJson<T>(string json) where T : BaseConfig {
            using StringReader stringReader = new(json);
            using JsonTextReader jsonReader = new(stringReader);
            return jsonSerializer.Deserialize<T>(jsonReader);
        }
    }
}