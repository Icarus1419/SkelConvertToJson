using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class PhysicsData
    {
        public string? name { get; set; }
        public int? order { get; set; }
        public bool? skin { get; set; }
        public string? bone { get; set; }

        public float? x { get; set; }
        public float? y { get; set; }
        public float? rotate { get; set; }
        public float? scaleX { get; set; }
        public float? shearX { get; set; }
        public float? limit { get; set; }
        public float? fps { get; set; }
        public float? inertia { get; set; }
        public float? strength { get; set; }
        public float? damping { get; set; }
        public float? mass { get; set; }
        public float? wind { get; set; }
        public float? gravity { get; set; }
        public float? mix { get; set; }
        public bool? inertiaGlobal { get; set; }
        public bool? strengthGlobal { get; set; }
        public bool? dampingGlobal { get; set; }
        public bool? massGlobal { get; set; }
        public bool? windGlobal { get; set; }
        public bool? gravityGlobal { get; set; }
        public bool? mixGlobal { get; set; }
    }
}
