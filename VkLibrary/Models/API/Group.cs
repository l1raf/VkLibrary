using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о сообществе.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Идентификатор сообщества.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Название сообщества.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Короткий адрес.
        /// </summary>
        [DataMember]
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// Является ли сообщество закрытым.
        /// Возможные значения:
        /// 0 - открытое, 1 - закрыторе, 2 - частное.
        /// </summary>
        [DataMember]
        [JsonProperty("is_closed")]
        public int IsClosed { get; set; }

        /// <summary>
        /// Тип сообщества: group, page, event.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Информация из блока контактов публичной страницы.
        /// </summary>
        [DataMember]
        [JsonProperty("contacts")]
        public List<Contact> Contacts { get; set; }

        /// <summary>
        /// URL главной фотографии с размером 50x50px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_50")]
        public Uri Photo50 { get; set; }

        /// <summary>
        /// URL главной фотографии с размером 100х100px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_100")]
        public Uri Photo100 { get; set; }

        /// <summary>
        /// URL главной фотографии в максимальном размере.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_200")]
        public Uri Photo200 { get; set; }
    }
}
