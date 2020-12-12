using Newtonsoft.Json;
using VkLibrary.Sth.Converters;

namespace VkLibrary.Models.InternalModels
{
    internal class FollowingJson
    {
        [JsonProperty("payload")]
        public FollowingPayload[] Payload { get; set; }
    }

    internal partial struct PayloadPayload
    {
        public long? Integer;
        public string String;

        public static implicit operator PayloadPayload(long Integer) => new PayloadPayload { Integer = Integer };
        public static implicit operator PayloadPayload(string String) => new PayloadPayload { String = String };
    }

    [JsonConverter(typeof(PayloadConverter))]
    internal partial struct FollowingPayload
    {
        public PayloadPayload[][][] Objects;
        public long? Integer;

        public static implicit operator FollowingPayload(PayloadPayload[][][] AnythingArrayArrayArray) => new FollowingPayload { Objects = AnythingArrayArrayArray };
        public static implicit operator FollowingPayload(long Integer) => new FollowingPayload { Integer = Integer };
    }
}
