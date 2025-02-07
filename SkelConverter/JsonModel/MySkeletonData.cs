using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spine;
using static Spine.Skeleton;

namespace SkelConverter.JsonModel
{
    public class MySkeletonData
    {
        public Skeleton? skeleton { get; set; }
        public IEnumerable<BoneData>? bones { get; set; }
        public IEnumerable<SlotData>? slots { get; set; }
        public IEnumerable<IKData>? ik { get; set; }
        public IEnumerable<TransformData>? transform { get; set; }
        public IEnumerable<PathData>? path { get; set; }
        public IEnumerable<PhysicsData>? physics { get; set; }
        public IEnumerable<SkinData>? skins { get; set; }
        public Dictionary<string, EventData>? events { get; set; }
        public Dictionary<string, Dictionary<string, AnimationData>>? animations { get; set; }
    }
}
