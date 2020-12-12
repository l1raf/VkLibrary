using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о комментариях.
    /// </summary>
    public class Comments
    {
        /// <summary>
        /// Количество комментариев к посту.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Может ли текущий пользователь комментировать пост.
        /// </summary>
        [DataMember]
        [JsonProperty("can_post")]
        public bool? CanPost { get; set; }

        /// <summary>
        /// Могут ли сообщества комментировать пост.
        /// </summary>
        [DataMember]
        [JsonProperty("groups_can_post")]
        public bool? GroupsCanPost { get; set; }
    }
}
