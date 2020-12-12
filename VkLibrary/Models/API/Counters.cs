using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Количество различных объектов у пользователя. 
    /// </summary>
    public class Counters
    {
        /// <summary>
        /// Количество альбомов пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("albums")]
        public int Albums { get; set; }

        /// <summary>
        /// Количество видеозаписей пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("videos")]
        public int Videos { get; set; }

        /// <summary>
        /// Количество видеозаписей с пользователем.
        /// </summary>
        [DataMember]
        [JsonProperty("user_videos")]
        public int UserVideos { get; set; }

        /// <summary>
        /// Количество заметок пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("notes")]
        public int Notes { get; set; }

        /// <summary>
        /// Количество общих друзей.
        /// </summary>
        [DataMember]
        [JsonProperty("mutual_friends")]
        public int MutualFriends { get; set; }

        /// <summary>
        /// Количество друзей онлайн.
        /// </summary>
        [DataMember]
        [JsonProperty("online_friends")]
        public int OnlineFriends { get; set; }

        /// <summary>
        /// Количество аудиозаписей пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("audios")]
        public int Audios { get; set; }

        /// <summary>
        /// Количество фотографий пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("photos")]
        public int Photos { get; set; }

        /// <summary>
        /// Количество групп пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("groups")]
        public int Groups { get; set; }

        /// <summary>
        /// Количество подписчиков пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("followers")]
        public int Followers { get; set; }

        /// <summary>
        /// Количество подписок пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("subscriptions")]
        public int Subscriptions { get; set; }

        /// <summary>
        /// Количество интересных страниц пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("pages")]
        public int Pages { get; set; }

        /// <summary>
        /// Количество подарков пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("gifts")]
        public int Gifts { get; set; }
    }
}
