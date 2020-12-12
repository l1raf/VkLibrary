using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о друзьях пользователя.
    /// </summary>
    public class Friends
    {
        /// <summary>
        /// Количество друзей пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Список друзей пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("items")]
        public List<Person> FriendsList { get; set; }
    }
}
