using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SkelConverter.JsonModel
{
    public class AttachmentData
    {
        public string? name { get; set; }

        public string type { get; set; }

        #region AttachmentType.Region
        public string? path { get; set; }
        public SequenceData? sequence { get; set; }
        public float? x { get; set; }
        public float? y { get; set; }
        public float? scaleX { get; set; }
        public float? scaleY { get; set; }
        public float? rotation { get; set; }
        public float? width { get; set; }
        public float? height { get; set; }
        public string? color { get; set; }
        #endregion
        #region AttachmentType.Boundingbox
        public float[]? vertices { get; set; }
        public int? vertexCount { get; set; }
        #endregion
        #region AttachmentType.Mesh AttachmentType.Linkedmesh
        public string? parent { get; set; }
        public string? skin { get; set; }
        public bool? timelines { get; set; }
        public float[]? uvs { get; set; }
        public int[]? triangles { get; set; }
        public int? hull { get; set; }
        public int[]? edges { get; set; }
        #endregion
        #region AttachmentType.Path
        public bool? closed { get; set; }
        public bool? constantSpeed { get; set; }
        public float[]? lengths { get; set; }
        #endregion
        #region AttachmentType.Point

        #endregion
        #region AttachmentType.Clipping
        public string? end { get; set; }
        #endregion
    }
}
