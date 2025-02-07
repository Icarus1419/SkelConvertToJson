using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mail;
using SkelConverter.JsonModel;
using Spine;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkelConverter
{
    public static class SkelReader
    {
        public static SkeletonData ReadSkelData(string? atlasPath, string? skelPath)
        {
            if (atlasPath == null || !File.Exists(atlasPath)) throw new ArgumentException($"The atlas FilePath[{atlasPath}] is Error.");
            if (skelPath == null || !File.Exists(skelPath)) throw new ArgumentException($"The skel FilePath[{skelPath}] is Error.");
            var textureLoader = new MyTextureLoader();
            var atlas = new Atlas(atlasPath, textureLoader);

            var binary = new SkeletonBinary(atlas);
            return binary.ReadSkeletonData(skelPath);
        }

        public static MySkeletonData ConvertToJsonSkeletonData(SkeletonData skeletonData, bool saveSkinData = false, bool saveEventData = false, bool saveAnimData = false)
        {
            var mySkeletonData = new MySkeletonData();

            #region Skelton Data
            mySkeletonData.skeleton = new()
            {
                hash = skeletonData.Hash,
                spine = skeletonData.Version,
                x = skeletonData.X,
                y = skeletonData.Y,
                width = skeletonData.Width,
                height = skeletonData.Height,
                referenceScale = skeletonData.ReferenceScale,
                fps = skeletonData.Fps,
                images = skeletonData.ImagesPath,
                audio = skeletonData.AudioPath,
            };
            #endregion
            #region Bone Data
            mySkeletonData.bones = skeletonData.Bones.Select(i => new JsonModel.BoneData
            {
                parent = i.Parent?.Name,
                name = i.Name,
                length = i.Length,
                x = i.X,
                y = i.Y,
                rotation = i.Rotation,
                scaleX = i.ScaleX,
                scaleY = i.ScaleY,
                shearX = i.ShearX,
                shearY = i.ShearY,
                inherit = i.Inherit.ToString(),
                skin = i.SkinRequired,

            });
            #endregion
            #region Slot Data
            mySkeletonData.slots = skeletonData.Slots.Select(i => new JsonModel.SlotData
            {
                name = i.Name,
                bone = i.BoneData.Name,
                color = $"{Convert.ToInt32(i.R * 255):X2}{Convert.ToInt32(i.G * 255):X2}{Convert.ToInt32(i.B * 255):X2}{Convert.ToInt32(i.A * 255):X2}",
                dark = $"{Convert.ToInt32(i.R2 * 255):X2}{Convert.ToInt32(i.G2 * 255):X2}{Convert.ToInt32(i.B2 * 255):X2}",
                attachment = i.AttachmentName,
                blend = i.BlendMode.ToString(),
            });
            #endregion
            #region IK Data
            mySkeletonData.ik = skeletonData.IkConstraints.Select(i => new IKData
            {
                name = i.Name,
                order = i.Order,
                skin = i.SkinRequired,
                bones = i.Bones.Select(j => j.Name),
                target = i.Target.Name,
                mix = i.Mix,
                softness = i.Softness,
                bendPositive = i.BendDirection == 1,
                compress = i.Compress,
                stretch = i.Stretch,
                uniform = i.Uniform,
            });
            #endregion
            #region Transform Data
            mySkeletonData.transform = skeletonData.TransformConstraints.Select(i => new TransformData
            {
                name = i.Name,
                order = i.Order,
                skin = i.SkinRequired,
                bones = i.Bones.Select(j => j.Name),
                target = i.Target.Name,

                local = i.Local,
                relative = i.Relative,

                rotation = i.OffsetRotation,
                x = i.OffsetX,
                y = i.OffsetY,
                scaleX = i.OffsetScaleX,
                scaleY = i.OffsetScaleY,
                shearY = i.OffsetShearY,

                mixRotate = i.MixRotate,
                mixX = i.MixX,
                mixY = i.MixY,
                mixScaleX = i.MixScaleX,
                mixScaleY = i.MixScaleY,
                mixShearY = i.MixShearY,
            });
            #endregion
            #region Path Data
            mySkeletonData.path = skeletonData.PathConstraints.Select(i => new PathData
            {
                name = i.Name,
                order = i.Order,
                skin = i.SkinRequired,
                bones = i.Bones.Select(j => j.Name),
                target = i.Target.Name,

                positionMode = i.PositionMode.ToString(),
                spacingMode = i.SpacingMode.ToString(),
                rotateMode = i.RotateMode.ToString(),

                rotation = i.OffsetRotation,
                position = i.Position,
                spacing = i.Spacing,
                mixRotate = i.RotateMix,
                mixX = i.MixX,
                mixY = i.MixY,
            });
            #endregion
            #region Physics Data
            mySkeletonData.physics = skeletonData.PhysicsConstraints.Select(i => new PhysicsData
            {
                name = i.Name,
                order = i.Order,
                skin = i.SkinRequired,
                bone = i.Bone.Name,

                x = i.X,
                y = i.Y,
                rotate = i.Rotate,
                scaleX = i.ScaleX,
                shearX = i.ShearX,
                limit = i.Limit,
                fps = 1f / i.Step,
                strength = i.Strength,
                damping = i.Damping,
                mass = 1f / i.MassInverse,
                wind = i.Wind,
                gravity = i.Gravity,
                mix = i.Mix,
                inertiaGlobal = i.InertiaGlobal,
                strengthGlobal = i.StrengthGlobal,
                dampingGlobal = i.DampingGlobal,
                massGlobal = i.MassGlobal,
                windGlobal = i.WindGlobal,
                gravityGlobal = i.GravityGlobal,
                mixGlobal = i.MixGlobal,
            });
            #endregion
            #region Skin Data
            if (saveSkinData) mySkeletonData.skins = skeletonData.Skins.Select(i => new SkinData
            {
                name = i.Name,
                bones = i.Bones.Select(j => j.Name),
                ik = i.Constraints.Where(j => mySkeletonData.ik.Select(k => k.name).Contains(j.Name)).Select(j => j.Name),
                transform = i.Constraints.Where(j => mySkeletonData.transform.Select(k => k.name).Contains(j.Name)).Select(j => j.Name),
                path = i.Constraints.Where(j => mySkeletonData.path.Select(k => k.name).Contains(j.Name)).Select(j => j.Name),
                physics = i.Constraints.Where(j => mySkeletonData.physics.Select(k => k.name).Contains(j.Name)).Select(j => j.Name),
                attachments = ConverSkinAttachmentData(i.Attachments, skeletonData.Slots),
            });
            #endregion
            #region Event Data
            if (saveEventData)
            {
                mySkeletonData.events = [];
                foreach (var _event in skeletonData.Events)
                {
                    var eventData = new JsonModel.EventData
                    {
                        Int = _event.Int,
                        Float = _event.Float,
                        String = _event.String,
                        audio = _event.AudioPath,
                        volume = _event.Volume,
                        balance = _event.Balance,
                    };
                    mySkeletonData.events.Add(_event.Name, eventData);
                }
            }
            #endregion
            #region Animation Data
            if (saveAnimData)
            {
                // Too complicated to parse, About 600 lines of logical code. Maybe do this later.  
            }
            #endregion

            return mySkeletonData;
        }
        private static Dictionary<string, Dictionary<string, AttachmentData>> ConverSkinAttachmentData(IEnumerable<Skin.SkinEntry> attachments, IEnumerable<Spine.SlotData> slotDatas)
        {
            var result = new Dictionary<string, Dictionary<string, AttachmentData>>();
            foreach (var attachment in attachments)
            {
                var attachmentType = "Region";
                var attachmentData = new AttachmentData();
                if (attachment.Attachment is RegionAttachment) attachmentType = "Region";
                else if (attachment.Attachment is BoundingBoxAttachment) attachmentType = "Boundingbox";
                else if (attachment.Attachment is MeshAttachment) attachmentType = "Mesh";
                else if (attachment.Attachment is PathAttachment) attachmentType = "Path";
                else if (attachment.Attachment is PointAttachment) attachmentType = "Point";
                else if (attachment.Attachment is ClippingAttachment) attachmentType = "Clipping";

                attachmentData.name = attachment.Attachment.Name;
                attachmentData.type = attachmentType;

                switch (attachmentType)
                {
                    case "Region":
                    default:
                        {
                            var oriAttachment = attachment.Attachment as RegionAttachment;
                            if (oriAttachment == null) continue;

                            attachmentData.path = oriAttachment.Path;
                            attachmentData.sequence = ConvertToJsonSequenceData(oriAttachment.Sequence);

                            attachmentData.x = oriAttachment.X;
                            attachmentData.y = oriAttachment.Y;
                            attachmentData.scaleX = oriAttachment.ScaleX;
                            attachmentData.scaleY = oriAttachment.ScaleY;
                            attachmentData.rotation = oriAttachment.Rotation;
                            attachmentData.width = oriAttachment.Width;
                            attachmentData.height = oriAttachment.Height;
                            attachmentData.color = $"{Convert.ToInt32(oriAttachment.R * 255):X2}{Convert.ToInt32(oriAttachment.G * 255):X2}{Convert.ToInt32(oriAttachment.B * 255):X2}{Convert.ToInt32(oriAttachment.A * 255):X2}";
                        }
                        break;
                    case "Boundingbox":
                        {
                            var oriAttachment = attachment.Attachment as BoundingBoxAttachment;
                            if (oriAttachment == null) continue;

                            attachmentData.vertexCount = oriAttachment.WorldVerticesLength;
                            attachmentData.vertices = oriAttachment.Vertices;
                        }
                        break;
                    case "Mesh":
                        {
                            var oriAttachment = attachment.Attachment as MeshAttachment;
                            if (oriAttachment == null) continue;

                            attachmentData.path = oriAttachment.Path;
                            attachmentData.sequence = ConvertToJsonSequenceData(oriAttachment.Sequence);

                            attachmentData.color = $"{Convert.ToInt32(oriAttachment.R * 255):X2}{Convert.ToInt32(oriAttachment.G * 255):X2}{Convert.ToInt32(oriAttachment.B * 255):X2}{Convert.ToInt32(oriAttachment.A * 255):X2}";
                            attachmentData.width = oriAttachment.Width;
                            attachmentData.height = oriAttachment.Height;

                            attachmentData.parent = oriAttachment.ParentMesh?.Name;

                            attachmentData.uvs = oriAttachment.UVs;
                            attachmentData.vertices = oriAttachment.Vertices;
                            attachmentData.triangles = oriAttachment.Triangles;

                            attachmentData.hull = oriAttachment.HullLength >> 1;
                            attachmentData.edges = oriAttachment.Edges;
                        }
                        break;
                    case "Path":
                        {
                            var oriAttachment = attachment.Attachment as PathAttachment;
                            if (oriAttachment == null) continue;

                            attachmentData.closed = oriAttachment.Closed;
                            attachmentData.constantSpeed = oriAttachment.ConstantSpeed;

                            attachmentData.vertexCount = oriAttachment.WorldVerticesLength;
                            attachmentData.vertices = oriAttachment.Vertices;

                            attachmentData.lengths = oriAttachment.Lengths;
                        }
                        break;
                    case "Point":
                        {
                            var oriAttachment = attachment.Attachment as PointAttachment;
                            if (oriAttachment == null) continue;

                            attachmentData.x = oriAttachment.X;
                            attachmentData.y = oriAttachment.Y;
                            attachmentData.rotation = oriAttachment.Rotation;
                        }
                        break;
                    case "Clipping":
                        {
                            var oriAttachment = attachment.Attachment as ClippingAttachment;
                            if (oriAttachment == null) continue;

                            attachmentData.end = oriAttachment.EndSlot.Name;

                            attachmentData.vertexCount = oriAttachment.WorldVerticesLength;
                            attachmentData.vertices = oriAttachment.Vertices;
                        }
                        break;
                }

                var slotData = slotDatas.FirstOrDefault(i => i.Index == attachment.SlotIndex);
                if (slotData == default) continue;
                if (!result.ContainsKey(slotData.Name)) result.Add(slotData.Name, new() { { attachmentData.name, attachmentData } });
                else result[slotData.Name].Add(attachmentData.name, attachmentData);
            }
            return result;
        }
        private static SequenceData? ConvertToJsonSequenceData(Sequence sequence)
        {
            if (sequence == null) return null;
            return new()
            {
                count = sequence.Regions.Length,
                start = sequence.Start,
                setup = sequence.SetupIndex,
                digits = sequence.Digits,

            };
        }

    }
}
