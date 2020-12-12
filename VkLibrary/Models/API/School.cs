using Newtonsoft.Json;
using System.Runtime.Serialization;
using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о школе пользователя.
    /// </summary>
    public class School
    {
        /// <summary>
        /// Идентификатор школы.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор страны, в которой расположена школа.
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public int Country { get; set; }

        /// <summary>
        /// Идентификатор города, в котором расположена школа.
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public int City { get; set; }

        /// <summary>
        /// Наименование школы.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Год начала обучения.
        /// </summary>
        [DataMember]
        [JsonProperty("year_from")]
        public int YearFrom { get; set; }

        /// <summary>
        /// Год окончания обучения.
        /// </summary>
        [DataMember]
        [JsonProperty("year_to")]
        public int YearTo { get; set; }

        /// <summary>
        /// Буква класса.
        /// </summary>
        [DataMember]
        [JsonProperty("Class")]
        public string Class { get; set; }

        /// <summary>
        /// Год выпуска.
        /// </summary>
        [DataMember]
        [JsonProperty("year_graduated")]
        public int YearGraduated { get; set; }

        /// <summary>
        /// Идентификатор типа.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public SchoolType Type { get; set; }

        /// <summary>
        /// Название типа.
        /// </summary>
        [DataMember]
        [JsonProperty("type_str")]
        public string TypeStr { get; set; }
    }
}
