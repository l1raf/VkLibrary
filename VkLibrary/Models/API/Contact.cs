using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация из блока контактов публичной страницы.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        [DataMember]
        [JsonProperty("desc")]
        public string Position { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        [DataMember]
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Адрес e-mail.
        /// </summary>
        [DataMember]
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
