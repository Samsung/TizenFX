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

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// Specialized <see cref="MotionTransformIndex"/> to control avatar joint transform.
    /// </summary>
    /// <example>
    /// <code>
    /// AvatarJointTransformIndex position = new AvatarJointTransformIndex(avatar.JointMapper, JointType.Head, MotionTransformIndex.TransformTypes.Position);
    ///
    /// // We can change the property later.
    /// AvatarJointTransformIndex orientation = new AvatarJointTransformIndex(avatar.JointMapper);
    /// orientation.AvatarJointType = (uint)JointType.Neck;
    /// orientation.TransformType = MotionTransformIndex.TransformTypes.Orientation;
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class AvatarJointTransformIndex : MotionTransformIndex
    {
        internal AvatarPropertyMapper nameMapper = null;
        internal uint jointType;

        /// <summary>
        /// Create an initialized avatar joint transform index.
        /// </summary>
        /// <param name="mapper">Name mapper for this index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarJointTransformIndex(AvatarPropertyMapper mapper) : base()
        {
            nameMapper = mapper;
        }

        /// <summary>
        /// Create an initialized avatar joint transform index with input node id, and transform type.
        /// </summary>
        /// <param name="mapper">Name mapper for this index</param>
        /// <param name="modelNodeId">Node ID for this motion index</param>
        /// <param name="transformType">Transform property type for this motion index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarJointTransformIndex(AvatarPropertyMapper mapper, PropertyKey modelNodeId, TransformTypes transformType) : base(new PropertyKey(GetPropertyNameFromMapper(mapper, modelNodeId)), transformType)
        {
            nameMapper = mapper;
        }

        /// <summary>
        /// Create an initialized avatar joint transform index with input node id, and transform type.
        /// </summary>
        /// <param name="mapper">Name mapper for this index</param>
        /// <param name="jointType">Type of joint for this motion index</param>
        /// <param name="transformType">Transform property type for this motion index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal AvatarJointTransformIndex(AvatarPropertyMapper mapper, JointType jointType, TransformTypes transformType) : this(mapper, (uint)jointType, transformType)
        {
        }

        /// <summary>
        /// Create an initialized avatar joint transform index with input node id, and transform type.
        /// </summary>
        /// <param name="mapper">Name mapper for this index</param>
        /// <param name="jointType">Type of joint for this motion index</param>
        /// <param name="transformType">Transform property type for this motion index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarJointTransformIndex(AvatarPropertyMapper mapper, uint jointType, TransformTypes transformType) : base(new PropertyKey(GetPropertyNameFromMapper(mapper, jointType)), transformType)
        {
            nameMapper = mapper;
            this.jointType = jointType;
        }

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

        private static string GetPropertyNameFromMapper(AvatarPropertyMapper mapper, uint jointType)
        {
            return mapper?.GetPropertyName(jointType) ?? "";
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

                using PropertyKey nodeId = new(GetPropertyNameFromMapper(nameMapper, jointType));
                base.ModelNodeId = nodeId;
            }
        }

        /// <summary>
        /// TODO : Explain me
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AvatarJointType
        {
            get
            {
                return jointType;
            }
            set
            {
                jointType = value;

                using PropertyKey nodeId = new(GetPropertyNameFromMapper(nameMapper, jointType));
                base.ModelNodeId = nodeId;
            }
        }

        /// <summary>
        /// Hijack property to control Avatar specified logic.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new PropertyKey ModelNodeId
        {
            get
            {
                return base.ModelNodeId;
            }
            set
            {
                if (value != null)
                {
                    if (value.Type == PropertyKey.KeyType.Index)
                    {
                        jointType = (uint)value.IndexKey;
                    }
                    using PropertyKey nodeId = new(GetPropertyNameFromMapper(nameMapper, value));
                    base.ModelNodeId = nodeId;
                }
                else
                {
                    base.ModelNodeId = value;
                }
            }
        }
    }
}
