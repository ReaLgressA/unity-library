using System;
using Newtonsoft.Json;
using UnityEngine;

namespace ConfigSystem.JsonConverters {
    public class HexColorJsonConverter : JsonConverter<Color> {
        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer) {
            string colorHexString = ColorUtility.ToHtmlStringRGBA(value);
            writer.WriteValue(colorHexString);
        }

        public override Color ReadJson(JsonReader reader,
                                       Type objectType,
                                       Color existingValue,
                                       bool hasExistingValue,
                                       JsonSerializer serializer) {

            string colorHexString = reader.ReadAsString();
            if (!ColorUtility.TryParseHtmlString(colorHexString, out Color defaultValue)) {
                Debug.LogError($"Failed to parse hex color form string '{colorHexString}'");
            }
            return defaultValue;
        }
    }
    
}