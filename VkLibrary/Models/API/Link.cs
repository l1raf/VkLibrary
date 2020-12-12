using Newtonsoft.Json;
using System.Runtime.Serialization;
using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о ссылках - вложение.
    /// </summary>
    public class Link : IAttachment
    {
        /// <summary>
        /// Тип вложения.
        /// </summary>
        public AttachmentType Type => AttachmentType.Link;

        /// <summary>
        /// URL ссылки.
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Заголовок ссылки.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Описание ссылки.
        /// </summary>
        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Подпись ссылки (если имеется).
        /// </summary>
        [DataMember]
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// Изображение превью (если имеется).
        /// </summary>
        [DataMember]
        [JsonProperty("photo")]
        public Photo Photo { get; set; }
    }
}
