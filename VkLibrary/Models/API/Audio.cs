using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;
using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация об аудиозаписи - вложение.
    /// </summary>
    public class Audio : IAttachment
    {
        /// <summary>
        /// Тип вложения.
        /// </summary>
        public AttachmentType Type => AttachmentType.Audio;

        /// <summary>
        /// Идентификатор аудиозаписи.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор владельца аудиозаписи.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Исполнитель.
        /// </summary>
        [DataMember]
        [JsonProperty("artist")]
        public string Artist { get; set; }

        /// <summary>
        /// Название композиции.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Длительность аудиозапии в секундах.
        /// </summary>
        [DataMember]
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Ссылка на mp3.
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Идентификатор текста аудиозаписи, если доступно.
        /// </summary>
        [DataMember]
        [JsonProperty("lyrics_id")]
        public int? LyricsId { get; set; }

        /// <summary>
        /// Идентификатор альбома, в котором находится аудиозапись, если присвоен.
        /// </summary>
        [DataMember]
        [JsonProperty("album_id")]
        public int? AlbumId { get; set; }

        /// <summary>
        /// Идентификатор жанра.
        /// </summary>
        [DataMember]
        [JsonProperty("genre_id")]
        public Genre Genre { get; set; }

        /// <summary>
        /// Дата добавления.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Включена ли опция «Не выводить при поиске».
        /// </summary>
        [DataMember]
        [JsonProperty("no_search")]
        public bool? NoSearch { get; set; }
    }
}
