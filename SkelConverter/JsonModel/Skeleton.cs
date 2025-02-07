using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class Skeleton
    {
        public string? hash { get; set; }

        public string? spine { get; set; }

        public float? x { get; set; }

        public float? y { get; set; }

        public float? width { get; set; }

        public float? height { get; set; }

        public float? referenceScale { get; set; }

        public float? fps { get; set; }

        public string? images { get; set; }

        public string? audio { get; set; }
    }
}
