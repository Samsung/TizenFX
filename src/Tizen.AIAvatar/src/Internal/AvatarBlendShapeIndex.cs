/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Scene3D;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// Specialized <see cref="BlendShapeIndex"/> to control avatar blend shape.
    /// </summary>
    /// <example>
    /// <code>
    /// AvatarBlendShapeIndex leftEyeBlink = new AvatarBlendShapeIndex(avatar.BlendShapeMapper, BlendShapeType.EyeBlinkLeft);
    ///
    /// // We can change the property later.
    /// AVatarBlendShapeIndex rightEyeBlink = new AvatarJointTransformIndex(avatar.BlendShapeMapper);
    /// rightEyeBlink.AvatarBlendShapeType = (uint)BlendShapeType.EyeBlinkRight;
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class AvatarBlendShapeIndex : BlendShapeIndex
    {
        internal AvatarPropertyMapper nameMapper = null;
        internal uint blendShapeType;

        /// <summary>
        /// Create an initialized avatar blend shape index.
        /// </summary>
        /// <param name="mapper">Name mapper for this index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarBlendShapeIndex(AvatarPropertyMapper mapper) : base()
        {
            nameMapper = mapper;
        }

        /// <summary>
        /// Create an initialized avatar blend shape index with input blend shape ID.
        /// </summary>
        /// <param name="mapper">Name mapper for this index</param>
        /// <param name="blendShapeId">Blend shape ID for this motion index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarBlendShapeIndex(AvatarPropertyMapper mapper, PropertyKey blendShapeId) : base(new PropertyKey(GetPropertyNameFromMapper(mapper, blendShapeId)))
        {
            nameMapper = mapper;
        }

        /// <summary>
        /// Create an initialized avatar blend shape index with blend shape type.
        /// </summary>
        /// <param name="mapper">Name mapper for this index</param>
        /// <param name="blendShapeType">Type of blend shape for this motion index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal AvatarBlendShapeIndex(AvatarPropertyMapper blendShapeMapper, BlendShapeType blendShapeType) : this(blendShapeMapper, (uint)blendShapeType)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper">Name mapper for this index</param>
        /// <param name="blendShapeType">Type of blend shape for this motion index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarBlendShapeIndex(AvatarPropertyMapper mapper, uint blendShapeType) : base(new PropertyKey(GetPropertyNameFromMapper(mapper, blendShapeType)))
        {
            nameMapper = mapper;
            this.blendShapeType = blendShapeType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper">Name mapper for this index</param>
        /// <param name="blendShapeType">Type of blend shape for this motion index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal AvatarBlendShapeIndex(AvatarPropertyMapper nodeMapper, NodeType nodeType, AvatarPropertyMapper blendShapeMapper, BlendShapeType blendShapeType) : base(new PropertyKey(GetPropertyNameFromMapper(nodeMapper, (uint)nodeType)), new PropertyKey(GetPropertyNameFromMapper(blendShapeMapper, (uint)blendShapeType)))
        {
            nameMapper = blendShapeMapper;
            this.blendShapeType = (uint)blendShapeType;
        }

        /// <summary>
        /// Get the name of given index.
        /// </summary>
        /// <param name="mapper">Name mapper for given index</param>
        /// <param name="id">Target ID what we want to get name</param>
        /// <returns>Name, or null if invalid</returns>
        private static string GetPropertyNameFromMapper(AvatarPropertyMapper mapper, PropertyKey id)
        {
            if (id == null)
            {
                return "";
            }
            if (id.Type == PropertyKey.KeyType.String)
            {
                return id.StringKey;
            }
            return mapper?.GetPropertyName((uint)id.IndexKey) ?? "";
        }

        /// <summary>
        /// Get the name of given JointType.
        /// </summary>
        /// <param name="mapper">Name mapper for given index</param>
        /// <param name="blendShapeType">Type of joint what we want to get name</param>
        /// <returns>Name, or null if invalid</returns>
        private static string GetPropertyNameFromMapper(AvatarPropertyMapper mapper, uint blendShapeType)
        {
            return mapper?.GetPropertyName(blendShapeType) ?? "";
        }

        /// <summary>
        /// TODO : Explain me
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarPropertyMapper NameMapper
        {
            get
            {
                return nameMapper;
            }
            set
            {
                nameMapper = value;

                using PropertyKey blendShapeId = new(GetPropertyNameFromMapper(nameMapper, blendShapeType));
                base.BlendShapeId = blendShapeId;
            }
        }

        /// <summary>
        /// TODO : Explain me
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AvatarBlendShapeType
        {
            get
            {
                return blendShapeType;
            }
            set
            {
                blendShapeType = value;

                using PropertyKey blendShapeId = new(GetPropertyNameFromMapper(nameMapper, blendShapeType));
                base.BlendShapeId = blendShapeId;
            }
        }

        /// <summary>
        /// Hijack property to control Avatar specified logic.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new PropertyKey BlendShapeId
        {
            get
            {
                return base.BlendShapeId;
            }
            set
            {
                if (value != null)
                {
                    if (value.Type == PropertyKey.KeyType.Index)
                    {
                        blendShapeType = (uint)value.IndexKey;
                    }
                    using PropertyKey blendShapeId = new(GetPropertyNameFromMapper(nameMapper, value));
                    base.BlendShapeId = blendShapeId;
                }
                else
                {
                    base.BlendShapeId = value;
                }
            }
        }
    }
}
