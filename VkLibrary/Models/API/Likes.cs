using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о лайках к записи.
    /// </summary>
    public class Likes
    {
        /// <summary>
        /// Количество лайков.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Наличие лайка от текущего пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("user_likes")]
        public bool? UserLikes { get; set; }

        /// <summary>
        /// Может ли текущий пользователь лайкать пост.
        /// </summary>
        [DataMember]
        [JsonProperty("can_like")]
        public bool? CanLike { get; set; }

        /// <summary>
        /// Может ли текущий пользователь сделать репост.
        /// </summary>
        [DataMember]
        [JsonProperty("can_publish")]
        public int CanPublish { get; set; }
    }
}
