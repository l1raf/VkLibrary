using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация об указанных в профиле сервисах пользователя.
    /// </summary>
    public class Connections
    {
        /// <summary>
        /// Никнейм пользователя в Facebook.
        /// </summary>
        [DataMember]
        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        /// <summary>
        /// Никнейм пользователя в Skype.
        /// </summary>
        [DataMember]
        [JsonProperty("skype")]
        public string Skype { get; set; }

        /// <summary>
        /// Имя пользователя в Facebook.
        /// </summary>
        [DataMember]
        [JsonProperty("facebook_name")]
        public string FacebookName { get; set; }

        /// <summary>
        /// Никнейм пользователя в Twitter.
        /// </summary>
        [DataMember]
        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        /// <summary>
        /// Никнейм пользователя в Instagram.
        /// </summary>
        [DataMember]
        [JsonProperty("instagram")]
        public string Instagram { get; set; }
    }
}
