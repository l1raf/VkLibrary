using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Информация о военной службе пользователя.
    /// </summary>
    public class Military
    {
        /// <summary>
        /// Номер части.
        /// </summary>
        [DataMember]
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Идентификатор части в базе данных.
        /// </summary>
        [DataMember]
        [JsonProperty("unit_id")]
        public int UnitId { get; set; }

        /// <summary>
        /// Идентификатор страны, в которой находится часть.
        /// </summary>
        [DataMember]
        [JsonProperty("country_id")]
        public int CountryId { get; set; }

        /// <summary>
        /// Год начала службы.
        /// </summary>
        [DataMember]
        [JsonProperty("from")]
        public int From { get; set; }

        /// <summary>
        /// Год окончания службы.
        /// </summary>
        [DataMember]
        [JsonProperty("until")]
        public int Until { get; set; }
    }
}
