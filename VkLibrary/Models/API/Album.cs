using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;
using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация об альбоме - вложение.
    /// </summary>
    public class Album : IAttachment
    {
        /// <summary>
        /// Тип вложения.
        /// </summary>
        public AttachmentType Type => AttachmentType.Album;

        /// <summary>
        /// Идентификатор владельца.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Обложка альбома.
        /// </summary>
        [DataMember]
        [JsonProperty("thumb")]
        public Photo Thumb { get; set; }

        /// <summary>
        /// Идентификатор владельца альбома.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Название альбома.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Описание альбома.
        /// </summary>
        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Дата создания альбома.
        /// </summary>
        [DataMember]
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Дата последнего обновления альбома.
        /// </summary>
        [DataMember]
        [JsonProperty("updated")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Количество фотографий в альбоме.
        /// </summary>
        [DataMember]
        [JsonProperty("size")]
        public int Size { get; set; }
    }
}
