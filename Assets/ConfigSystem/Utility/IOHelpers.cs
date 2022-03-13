using System.IO;
using UnityEngine;

namespace ConfigSystem.Utility
{
    public static class IOHelpers
    {
        public static string ReadFileAsString(string filepath, bool isSilent = false)
        {
            string path = Path.Combine(Application.streamingAssetsPath, filepath);
            return ReadStringFromPath(path, isSilent);
        }

        public static string ReadPersistentFileAsString(string filepath, bool isSilent = false)
        {
            string path = Path.Combine(Application.persistentDataPath, filepath);
            return ReadStringFromPath(path, isSilent);
        }

        public static string ReadStringFromPath(string path, bool isSilent)
        {
            if (Application.platform == RuntimePlatform.Android) {
                UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(path);
                www.SendWebRequest();
                while (!www.isDone) { }
                return www.downloadHandler.text;
            } else if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }

            if (!isSilent)
            {
                Debug.LogError($"StreamingAssetReader:ReadAsString file not found: {path}");
            }

            return null;
        }

        public static void WriteStringToPersistentFile(string filepath, string content)
        {
            string path = Path.Combine(Application.persistentDataPath, filepath);
            Debug.Log($"WriteStringToPersistentFile: {path}");
            File.WriteAllText(path, content);
        }
    }
}
