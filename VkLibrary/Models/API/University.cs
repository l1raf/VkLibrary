using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация об университете пользователя.
    /// </summary>
    public class University
    {
        /// <summary>
        /// Идентификатор университета.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор страны, в которой расположен университет.
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public int Country { get; set; }

        /// <summary>
        /// Идентификатор города, в котором расположен университет.
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public int City { get; set; }

        /// <summary>
        /// Наименование университета.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор факультета.
        /// </summary>
        [DataMember]
        [JsonProperty("faculty")]
        public int Faculty { get; set; }

        /// <summary>
        /// Наименование факультета.
        /// </summary>
        [DataMember]
        [JsonProperty("faculty_name")]
        public string FacultyName { get; set; }

        /// <summary>
        /// Идентификатор кафедры.
        /// </summary>
        [DataMember]
        [JsonProperty("chair")]
        public int Chair { get; set; }

        /// <summary>
        /// Наименование кафедры.
        /// </summary>
        [DataMember]
        [JsonProperty("chair_name")]
        public string ChairName { get; set; }

        /// <summary>
        /// Год окончания обучения.
        /// </summary>
        [DataMember]
        [JsonProperty("graduation")]
        public int Graduation { get; set; }

        /// <summary>
        /// Форма обучения.
        /// </summary>
        [DataMember]
        [JsonProperty("education_form")]
        public string EducationForm { get; set; }

        /// <summary>
        /// Статус обучения.
        /// </summary>
        [DataMember]
        [JsonProperty("education_status")]
        public string EducationStatus { get; set; }
    }
}
