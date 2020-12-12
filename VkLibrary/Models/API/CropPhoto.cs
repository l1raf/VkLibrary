using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основные данные о точках, по которым вырезаны профильная 
    /// и миниатюрная фотографии пользователя, при наличии.
    /// </summary>
    public class CropPhoto
    {
        /// <summary>
        /// Объект фотографии пользователя, из которой вырезается главное фото профиля.
        /// </summary>
        [DataMember]
        [JsonProperty("photo")]
        public Photo Photo { get; set; }

        /// <summary>
        /// Вырезанная фотография пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("crop")]
        public Coordinates Crop { get; set; }

        /// <summary>
        /// Миниатюрная квадратная фотография, вырезанная из фотографии crop.
        /// </summary>
        [DataMember]
        [JsonProperty("rect")]
        public Coordinates Rect { get; set; }
    }
}
