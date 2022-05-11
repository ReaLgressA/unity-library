using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConfigSystem {
    public interface IConfigFactory {
        List<JsonConverter> Converters { get; }
        JsonSerializer JsonSerializer { get; }
        JsonSerializerSettings SerializerSettings { get; }
        
        T BuildFromJson<T>(string json) where T : BaseConfig;
    }
}