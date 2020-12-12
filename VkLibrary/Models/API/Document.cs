using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;
using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о документе - вложение.
    /// </summary>
    public class Document : IAttachment
    {
        /// <summary>
        /// Тип вложения.
        /// </summary>
        public AttachmentType Type => AttachmentType.Document;

        /// <summary>
        /// Идентификаор документа. 
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор владельца.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Название документа.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Размер документа в байтах.
        /// </summary>
        [DataMember]
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Расширение документа. 
        /// </summary>
        [DataMember]
        [JsonProperty("ext")]
        public string Ext { get; set; }

        /// <summary>
        /// Адрес документа, по которому его можно загрузить.
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Дата добавления.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Тип документа.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public DocType DocType { get; set; }
    }    
}
