using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConfigSystem {
    public interface IConfigFactory {
        List<JsonConverter> Converters { get; }
        JsonSerializer JsonSerializer { get; }
        
        T BuildFromJson<T>(string json) where T : BaseConfig;
    }
}