using System;

namespace ConfigSystem.Utility
{
    public static class StringExtensions
    {
        public static string ReadTextFile(string pathJson)
        {
            try
            {
                string json = IOHelpers.ReadFileAsString(pathJson);
                return json;
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError($"Failed to readJson: {pathJson}\n{ex.StackTrace}");
            }
            return null;
        }
    }
}
