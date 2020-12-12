using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о репостах записи.
    /// </summary>
    public class Reposts
    {
        /// <summary>
        /// Количестов репостов.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Наличие репоста от текущего пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("user_reposted")]
        public bool? UserReposted { get; set; }
    }
}
