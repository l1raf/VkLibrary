using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о подписчиках пользователя.
    /// </summary>
    public class Followers
    {
        /// <summary>
        /// Количество подписчиков пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Список подписчиков пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("items")]
        public List<Person> FollowersList { get; set; }
    }
}
