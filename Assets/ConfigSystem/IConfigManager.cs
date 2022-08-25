namespace ConfigSystem {
    public interface IConfigManager {
        
        IConfigFactory ConfigFactory { get; }
        
        T LoadFromStreamingAssets<T>(string path) where T : BaseConfig;
        T LoadFromJson<T>(string json) where T : BaseConfig;
    }
}