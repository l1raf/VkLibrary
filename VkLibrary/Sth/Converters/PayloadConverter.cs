using System;
using Newtonsoft.Json;
using VkLibrary.Models.InternalModels;

namespace VkLibrary.Sth.Converters
{
    internal class PayloadConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FollowingPayload) || t == typeof(FollowingPayload?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new FollowingPayload { Integer = integerValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<PayloadPayload[][][]>(reader);
                    return new FollowingPayload { Objects = arrayValue };
            }
            throw new Exception("Cannot unmarshal type TemperaturesPayload");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (FollowingPayload)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.Objects != null)
            {
                serializer.Serialize(writer, value.Objects);
                return;
            }
            throw new Exception("Cannot marshal type TemperaturesPayload");
        }

        public static readonly PayloadConverter Singleton = new PayloadConverter();
    }
}
