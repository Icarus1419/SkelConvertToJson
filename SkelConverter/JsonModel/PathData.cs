using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class PathData
    {
        public string? name { get; set; }
        public int? order { get; set; }
        public bool? skin { get; set; }
        public IEnumerable<string>? bones { get; set; }
        public string? target { get; set; }

        public string? positionMode { get; set; }
        public string? spacingMode { get; set; }
        public string? rotateMode { get; set; }

        public float? rotation { get; set; }
        public float? position { get; set; }
        public float? spacing { get; set; }
        public float? mixRotate { get; set; }
        public float? mixX { get; set; }
        public float? mixY { get; set; }
    }
}
