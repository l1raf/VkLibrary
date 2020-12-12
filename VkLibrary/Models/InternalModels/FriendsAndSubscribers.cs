using Newtonsoft.Json;
using VkLibrary.Sth.Converters;

namespace VkLibrary.Models.InternalModels
{
    internal partial class FriendsAndSubscribers
    {
        [JsonProperty("all")]
        public All[][] All { get; set; }

        [JsonProperty("subscribers")]
        public All[][] Subscribers { get; set; }
    }

    [JsonConverter(typeof(AllConverter))]
    internal partial struct All
    {
        public bool? Bool;
        public string String;

        public static implicit operator All(bool Bool) => new All { Bool = Bool };
        public static implicit operator All(string String) => new All { String = String };
    }
}
