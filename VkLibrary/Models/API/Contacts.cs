using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Информация о телефонных номерах пользователя.
    /// </summary>
    public class Contacts
    {
        /// <summary>
        /// Мобильный телефон пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Домашний телефон пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("home_phone")]
        public string HomePhone { get; set; }
    }
}
