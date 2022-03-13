using Newtonsoft.Json;

namespace ConfigSystem {
    
    public abstract class BaseConfig {
        
        [JsonProperty]
        public abstract string Type { get; }
        
    }
}