using System;
using Newtonsoft.Json;
using VkLibrary.Models.InternalModels;

namespace VkLibrary.Sth.Converters
{
    internal class AllConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(All) || t == typeof(All?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return new All { Bool = boolValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new All { String = stringValue };
                default:
                    return new All();
            }
            throw new Exception("Cannot unmarshal type All");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (All)untypedValue;
            if (value.Bool != null)
            {
                serializer.Serialize(writer, value.Bool.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception("Cannot marshal type All");
        }

        public static readonly AllConverter Singleton = new AllConverter();
    }
}

