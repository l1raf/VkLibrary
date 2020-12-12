using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о постах на стене.
    /// </summary>
    public class Wall
    {
        /// <summary>
        /// Число постов на стене.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Список постов на стене.
        /// </summary>
        [DataMember]
        [JsonProperty("items")]
        public List<Post> Posts { get; set; }

        /// <summary>
        /// Список пользователей.
        /// </summary>
        [DataMember]
        [JsonProperty("profiles")]
        public List<Person> Profiles { get; set; }

        /// <summary>
        /// Список групп.
        /// </summary>
        [DataMember]
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
    }
}
