using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConfigSystem {
    public class ConfigFactory : IConfigFactory {
        private readonly JsonSerializer jsonSerializer;
        
        public List<JsonConverter> Converters { get; }
        
        public ConfigFactory(List<JsonConverter> converters) {
            Converters = converters ?? new();
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