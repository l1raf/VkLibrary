using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о голосовании - вложение.
    /// </summary>
    public class Poll : IAttachment
    {
        /// <summary>
        /// Тип вложения.
        /// </summary>
        public AttachmentType Type => AttachmentType.Poll;

        /// <summary>
        /// Идентификатор опроса.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор владельца опроса.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Идентификатор автора опроса.
        /// </summary>
        [DataMember]
        [JsonProperty("author_id")]
        public int AuthorId { get; set; }

        /// <summary>
        /// Фотография — фон сниппета опроса.
        /// </summary>
        [DataMember]
        [JsonProperty("photo")]
        public Photo Photo { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        [DataMember]
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Текст вопроса.
        /// </summary>
        [DataMember]
        [JsonProperty("question")]
        public string Question { get; set; }

        /// <summary>
        /// Идентификаторы друзей, которые проголосовали в опросе.
        /// </summary>
        [DataMember]
        [JsonProperty("friends")]
        public List<int> Friends { get; set; }

        /// <summary>
        /// Количество голосов.
        /// </summary>
        [DataMember]
        [JsonProperty("votes")]
        public int Votes { get; set; }

        /// <summary>
        /// Является ли опрос анонимным.
        /// </summary>
        [DataMember]
        [JsonProperty("anonymous")]
        public bool? Anonymous { get; set; }
    }
}
