using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;
using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о заметках - вложение.
    /// </summary>
    public class Note : IAttachment
    {
        /// <summary>
        /// Тип вложения.
        /// </summary>
        public AttachmentType Type => AttachmentType.Note;

        /// <summary>
        /// Идентификатор заметки.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор владельца заметки.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Заголовок заметки.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Текст заметки.
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Дата создания заметки.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Количество комментариев.
        /// </summary>
        [DataMember]
        [JsonProperty("comments")]
        public int Comments { get; set; }

        /// <summary>
        /// URL страницы для отображения заметки.
        /// </summary>
        [DataMember]
        [JsonProperty("view_url")]
        public string ViewUrl { get; set; }
    }
}
