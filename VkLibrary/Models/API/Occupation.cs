using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о текущем роде занятия пользователя.
    /// </summary>
    public class Occupation
    {
        /// <summary>
        /// Тип.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Идентификатор школы, вуза, сообщества компании (в которой пользователь работает).
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Название школы, вуза или места работы.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
