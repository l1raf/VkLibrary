using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;
using VkLibrary.Enums;
using Newtonsoft.Json.Converters;
using System;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о фотографии - вложение
    /// </summary>
    public class Photo : IAttachment
    {
        /// <summary>
        /// Тип вложения.
        /// </summary>
        public AttachmentType Type => AttachmentType.Photo;

        /// <summary>
        /// Идентификатор фотографии.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор альбома, в котором находится фотография.
        /// </summary>
        [DataMember]
        [JsonProperty("album_id")]
        public int AlbumId { get; set; }

        /// <summary>
        /// Идентификатор владельца фотографии.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, загрузившего фото (если фотография размещена в сообществе). 
        /// Для фотографий, размещенных от имени сообщества, user_id = 100.
        /// </summary>
        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Массив с копиями изображения в разных размерах.
        /// </summary>
        [DataMember]
        [JsonProperty("sizes")]
        public List<Size> Sizes { get; set; }

        /// <summary>
        /// Текст описания фотографии.
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Title { get; set; }

        /// <summary>
        /// Дата добавления.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Date { get; set; }
    }
}
