using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class AnimationData
    {
        public object? slots { get; set; }
        public object? bones { get; set; }
        public object? ik { get; set; }
        public object? transform { get; set; }
        public object? path { get; set; }
        public object? physics { get; set; }
        public object? attachments { get; set; }
        public object? drawOrder { get; set; }
        public object? events { get; set; }
    }
}
