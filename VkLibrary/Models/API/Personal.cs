using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о полях из раздела «Жизненная позиция».
    /// </summary>
    public class Personal
    {
        /// <summary>
        /// Политические предпочтения.
        /// </summary>
        [DataMember]
        [JsonProperty("political")]
        public PoliticalView Political { get; set; }

        /// <summary>
        /// Языки.
        /// </summary>
        [DataMember]
        [JsonProperty("langs")]
        public List<string> Languages { get; set; }

        /// <summary>
        /// Мировоззрение.
        /// </summary>
        [DataMember]
        [JsonProperty("religion")]
        public string Religion { get; set; }

        /// <summary>
        /// Источники вдохновения.
        /// </summary>
        [DataMember]
        [JsonProperty("inspired_by")]
        public string InspiredBy { get; set; }

        /// <summary>
        /// Главное в людях.
        /// </summary>
        [DataMember]
        [JsonProperty("people_main")]
        public PeopleMain PeopleMain { get; set; }

        /// <summary>
        /// Главное в жизни.
        /// </summary>
        [DataMember]
        [JsonProperty("life_main")]
        public LifeMain LifeMain { get; set; }

        /// <summary>
        /// Отношение к курению.
        /// </summary>
        [DataMember]
        [JsonProperty("smoking")]
        public View Smoking { get; set; }

        /// <summary>
        /// Отношение к алкоголю.
        /// </summary>
        [DataMember]
        [JsonProperty("alcohol")]
        public View Alcohol { get; set; }
    }
}
