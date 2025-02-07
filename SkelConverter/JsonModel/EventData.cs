using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class EventData
    {
        [JsonPropertyName("int")]
        public int? Int { get; set; }
        [JsonPropertyName("float")]
        public float? Float { get; set; }
        [JsonPropertyName("string")]
        public string? String { get; set; }
        public string? audio { get; set; }
        public float? volume { get; set; }
        public float? balance { get; set; }
    }
}
