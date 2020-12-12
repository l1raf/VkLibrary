using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о просмотрах.
    /// </summary>
    public class Views
    {
        /// <summary>
        /// Число просмотров записи.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
