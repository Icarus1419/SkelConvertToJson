using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class IKData
    {
        public string? name { get; set; }
        public int? order { get; set; }
        public bool? skin { get; set; }
        public IEnumerable<string>? bones { get; set; }
        public string? target { get; set; }
        public float? mix { get; set; }
        public float? softness { get; set; }
        public bool? bendPositive { get; set; }
        public bool? compress { get; set; }
        public bool? stretch { get; set; }
        public bool? uniform { get; set; }
    }
}
