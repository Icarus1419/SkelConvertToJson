using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class TransformData
    {
        public string? name { get; set; }
        public int? order { get; set; }
        public bool? skin { get; set; }
        public IEnumerable<string>? bones { get; set; }
        public string? target { get; set; }
        public bool? local { get; set; }
        public bool? relative { get; set; }
        public float? rotation { get; set; }
        public float? x { get; set; }
        public float? y { get; set; }
        public float? scaleX { get; set; }
        public float? scaleY { get; set; }
        public float? shearY { get; set; }
        public float? mixRotate { get; set; }
        public float? mixX { get; set; }
        public float? mixY { get; set; }
        public float? mixScaleX { get; set; }
        public float? mixScaleY { get; set; }
        public float? mixShearY { get; set; }
    }
}
