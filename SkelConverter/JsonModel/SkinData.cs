using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class SkinData
    {
        public string? name { get; set; }
        public IEnumerable<string>? bones { get; set; }
        public IEnumerable<string>? ik { get; set; }
        public IEnumerable<string>? transform { get; set; }
        public IEnumerable<string>? path { get; set; }
        public IEnumerable<string>? physics { get; set; }
        public Dictionary<string, Dictionary<string, AttachmentData>>? attachments { get; set; }
    }
}
