using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о стране.
    /// </summary>
    public class Country
    {
        /// <summary>
        ///  Идентификатор страны.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Название страны.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
