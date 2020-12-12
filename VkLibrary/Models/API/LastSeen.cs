using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Информация о времени последнего посещения.
    /// </summary>
    public class LastSeen
    {
        /// <summary>
        /// Время последнего посещения.
        /// </summary>
        [DataMember]
        [JsonProperty("time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Time { get; set; }

        /// <summary>
        /// Тип платформы.
        /// </summary>
        [DataMember]
        [JsonProperty("platform")]
        public int Platform { get; set; }
    }
}
