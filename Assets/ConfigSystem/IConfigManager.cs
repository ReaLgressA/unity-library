namespace ConfigSystem {
    public interface IConfigManager {
        T LoadFromStreamingAssets<T>(string path) where T : BaseConfig;
    }
}