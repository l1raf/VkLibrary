using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о карьере пользователя.
    /// </summary>
    public class Career
    {
        /// <summary>
        /// Идентификатор сообщества (если доступно, иначе company).
        /// </summary>
        [DataMember]
        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        /// <summary>
        /// Название компании (если доступно, иначе group_id).
        /// </summary>
        [DataMember]
        [JsonProperty("compamy")]
        public string Company { get; set; }

        /// <summary>
        ///  Идентификатор страны.
        /// </summary>
        [DataMember]
        [JsonProperty("compamy_id")]
        public int CountryId { get; set; }

        /// <summary>
        /// Идентификатор города (если доступно, иначе city_name).
        /// </summary>
        [DataMember]
        [JsonProperty("city_id")]
        public int CityId { get; set; }

        /// <summary>
        /// Название города (если доступно, иначе city_id).
        /// </summary>
        [DataMember]
        [JsonProperty("city_name")]
        public string CityName { get; set; }

        /// <summary>
        /// Год начала работы.
        /// </summary>
        [DataMember]
        [JsonProperty("from")]
        public int From { get; set; }

        /// <summary>
        /// Год окончания работы.
        /// </summary>
        [DataMember]
        [JsonProperty("until")]
        public int Until { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        [DataMember]
        [JsonProperty("position")]
        public string Position { get; set; }
    }
}
