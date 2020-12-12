using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о размере изображения.
    /// </summary>
    public class Size
    {
        /// <summary>
        /// Обозначение размера и пропорций копии.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// url копии изображения.
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Ширина копии в пикселях.
        /// </summary>
        [DataMember]
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Высота копии в пикселях.
        /// </summary>
        [DataMember]
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
