using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class SlotData
    {
        public string? name { get; set; }
        public string? bone { get; set; }
        public string? color { get; set; }
        public string? dark { get; set; }
        public string? attachment { get; set; } = null;
        public string? blend { get; set; }
        //public bool? visible { get; set; } = true;
    }
}
