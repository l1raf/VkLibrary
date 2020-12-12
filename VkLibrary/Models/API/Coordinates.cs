using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Координаты фотографии.
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Координата X левого верхнего угла в процентах.
        /// </summary>
        [DataMember]
        [JsonProperty("x")]
        public double X { get; set; }

        /// <summary>
        /// Координата Y левого верхнего угла в процентах.
        /// </summary>
        [DataMember]
        [JsonProperty("y")]
        public double Y { get; set; }

        /// <summary>
        /// Координата X правого нижнего угла в процентах.
        /// </summary>
        [DataMember]
        [JsonProperty("x2")]
        public double X2 { get; set; }

        /// <summary>
        /// Координата Y правого нижнего угла в процентах.
        /// </summary>
        [DataMember]
        [JsonProperty("y2")]
        public double Y2 { get; set; }
    }
}
