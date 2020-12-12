using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о городе.
    /// </summary>
    public class City
    {
        /// <summary>
        ///  Идентификатор города.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Название города.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
