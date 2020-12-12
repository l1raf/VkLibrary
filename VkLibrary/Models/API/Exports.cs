using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace VkLibrary.Models.API
{
	/// <summary>
	/// Внешние сервисы, в которые настроен экспорт из ВК.
	/// </summary>
	public class Exports
    {
		/// <summary>
		/// Twitter
		/// </summary>
		[DataMember]
		[JsonProperty("twitter")]
		public bool Twitter { get; set; }

		/// <summary>
		/// Facebook
		/// </summary>
		[DataMember]
		[JsonProperty("facebook")]
		public bool Facebook { get; set; }

		/// <summary>
		/// LiveJournal
		/// </summary>
		[DataMember]
		[JsonProperty("livejournal")]
		public bool Livejournal { get; set; }

		/// <summary>
		/// Instagram
		/// </summary>
		[DataMember]
		[JsonProperty("instagram")]
		public bool Instagram { get; set; }
	}
}
