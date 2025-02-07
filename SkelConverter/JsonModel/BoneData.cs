using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class BoneData
    {
        public string? parent { get; set; }
        public string? name { get; set; }
        public float? length { get; set; }
        public float? x { get; set; }
        public float? y { get; set; }
        public float? rotation { get; set; }
        public float? scaleX { get; set; }
        public float? scaleY { get; set; }
        public float? shearX { get; set; }
        public float? shearY { get; set; }
        public string? inherit { get; set; }
        public bool? skin { get; set; }

        ////!----- NON ESSENTIALS
        //public bool NonEssential { get; set; } = 1;

        //[JsonProperty("color")]
        //public string? Color { get; set; } = 1;

        //[JsonProperty("icon")]
        //public string? Icon { get; set; } = 1;

        //[JsonProperty("visible")]
        //public bool? Visible { get; set; } = 1;
    }
}
