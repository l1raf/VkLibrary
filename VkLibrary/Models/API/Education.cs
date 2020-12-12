using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о высшем учебном заведении пользователя.
    /// </summary>
    public class Education
    {
        /// <summary>
        /// Идентификатор ВУЗа, в котором учится пользователь.
        /// </summary>
        [DataMember]
        [JsonProperty("university")]
        public int University { get; set; }

        /// <summary>
        /// Название ВУЗа, в котором учится пользователь.
        /// </summary>
        [DataMember]
        [JsonProperty("university_name")]
        public string UniversityName { get; set; }

        /// <summary>
        /// Идентификатор факультета, на котором учится пользователь.
        /// </summary>
        [DataMember]
        [JsonProperty("faculty")]
        public int Faculty { get; set; }

        /// <summary>
        /// Название факультета, на котором учится пользователь.
        /// </summary>
        [DataMember]
        [JsonProperty("faculty_name")]
        public string FacultyName { get; set; }

        /// <summary>
        /// Год окончания обучения.
        /// </summary>
        [DataMember]
        [JsonProperty("graduation")]
        public int Graduation { get; set; }
    }
}
