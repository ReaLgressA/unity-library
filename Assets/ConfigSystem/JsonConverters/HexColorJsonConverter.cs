using System;
using Newtonsoft.Json;
using UnityEngine;

namespace ConfigSystem.JsonConverters {
    public class HexColorJsonConverter : JsonConverter<Color> {
        private readonly bool isOkayToBeNull;
        
        public HexColorJsonConverter(bool isOkayToBeNull = false) {
            this.isOkayToBeNull = isOkayToBeNull;
        }
        
        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer) {
            string colorHexString = ColorUtility.ToHtmlStringRGBA(value);
            writer.WriteValue(colorHexString);
        }

        public override Color ReadJson(JsonReader reader,
                                       Type objectType,
                                       Color existingValue,
                                       bool hasExistingValue,
                                       JsonSerializer serializer) {

            string colorHexString = reader.Value as string;
            if (!string.IsNullOrWhiteSpace(colorHexString) 
                && ColorUtility.TryParseHtmlString(colorHexString, out Color parsedValue)) {
                return parsedValue;
            }
            if (!isOkayToBeNull) {
                Debug.LogError($"Failed to parse hex color from string '{colorHexString}'");
            }
            return existingValue;
        }
    }
    
}