using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConfigSystem {
    public interface IConfigFactory {
        public List<JsonConverter> Converters { get; }
        T BuildFromJson<T>(string json) where T : BaseConfig;
    }
}