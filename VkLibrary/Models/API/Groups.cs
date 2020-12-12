using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о группах пользователя.
    /// </summary>
    public class Groups
    {
        /// <summary>
        /// Количество групп пользоватея.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Список групп пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("items")]
        public List<Group> GroupsList { get; set; }
    }
}
