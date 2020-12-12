using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using VkLibrary.Models.API;

namespace VkLibrary.Sth.Converters
{
    internal class AttachmentJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var attachments = new List<IAttachment>();
            var arr = serializer.Deserialize<JArray>(reader);

            foreach (var obj in arr.OfType<JObject>())
            {
                switch (obj["type"].ToString())
                {
                    case "audio":
                        attachments.Add(obj["audio"].ToObject<Audio>());
                        break;
                    case "doc":
                        attachments.Add(obj["doc"].ToObject<Document>());
                        break;
                    case "link":
                        attachments.Add(obj["link"].ToObject<Link>());
                        break;
                    case "note":
                        attachments.Add(obj["note"].ToObject<Note>());
                        break;
                    case "photo":
                        attachments.Add(obj["photo"].ToObject<Photo>());
                        break;
                    case "video":
                        attachments.Add(obj["video"].ToObject<Video>());
                        break;
                    case "poll":
                        attachments.Add(obj["poll"].ToObject<Poll>());
                        break;
                    case "album":
                        attachments.Add(obj["album"].ToObject<Video>());
                        break;
                    default:
                        break;
                }
            }

            return new List<IAttachment>(attachments);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(List<>).IsAssignableFrom(objectType);
        }
    }
}
