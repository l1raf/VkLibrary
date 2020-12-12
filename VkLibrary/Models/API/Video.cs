using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;
using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о видеозаписи - вложение.
    /// </summary>
    public class Video : IAttachment
    {
        /// <summary>
        /// Тип вложения.
        /// </summary>
        public AttachmentType Type => AttachmentType.Video;

        /// <summary>
        /// Ключ доступа к объекту.
        /// </summary>
        [DataMember]
        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// Может ли пользователь добавить видеозапись к себе.
        /// </summary>
        [DataMember]
        [JsonProperty("can_add")]
        public bool? CanAdd { get; set; }

        /// <summary>
        /// Количество комментариев.
        /// </summary>
        [DataMember]
        [JsonProperty("comments")]
        public int Comments { get; set; }

        /// <summary>
        /// Дата создания видеозаписи.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Дата добавления видеозаписи пользователем или группой.
        /// </summary>
        [DataMember]
        [JsonProperty("adding_date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? AddingDate { get; set; }

        /// <summary>
        /// Текст описания видеозаписи.
        /// </summary>
        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Длительность ролика в секундах.
        /// </summary>
        [DataMember]
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Может ли пользователь редактировать видеозапись.
        /// </summary>
        [DataMember]
        [JsonProperty("can_edit")]
        public bool CanEdit { get; set; }

        /// <summary>
        /// Приватная ли видеозапись.
        /// </summary>
        [DataMember]
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// URL страницы с плеером, который можно использовать 
        /// для воспроизведения ролика в браузере. 
        /// </summary>
        [DataMember]
        [JsonProperty("player")]
        public string Player { get; set; }

        /// <summary>
        /// Название платформы (для видеозаписей, добавленных с внешних сайтов).
        /// </summary>
        [DataMember]
        [JsonProperty("platform")]
        public string Platform { get; set; }

        /// <summary>
        /// Идентификатор видеозаписи.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор владельца видеозаписи.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Название видеозаписи.
        /// </summary>
        [DataMember]
        [JsonProperty("Title")]
        public string Title { get; set; }

        /// <summary>
        /// Количество просмотров видеозаписи.
        /// </summary>
        [DataMember]
        [JsonProperty("views")]
        public int Views { get; set; }
    }
}
