using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
	/// <summary>
	/// Основная информация о родственнике пользователя.
	/// </summary>
	public class Relative
    {
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		[DataMember]
		[JsonProperty("id")]
		public int Id { get; set; }

		/// <summary>
		/// Тип родственной связи.
		/// </summary>
		[DataMember]
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Имя родственника.
		/// </summary>
		[DataMember]
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
