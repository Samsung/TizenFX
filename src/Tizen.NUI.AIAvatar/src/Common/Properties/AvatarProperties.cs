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

using System;
using System.ComponentModel;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.AIAvatar
{

    /// <summary>
    /// The Avatar class contains an inner AvatarProperties class.
    /// This class manages AvatarProperty information using the AvatarPropertyMapper class.
    /// By default, it includes jointMapper, blendShapeMapper, and nodeMapper, which automatically generate Properties based on model information.
    /// This structure enables users to work with Avatar properties in a more convenient way.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal abstract class AvatarProperties
    {
        private AvatarPropertyMapper jointMapper;
        private AvatarPropertyMapper blendShapeMapper;
        private AvatarPropertyMapper nodeMapper;

        internal event EventHandler<AvatarProperties> PropertiesChanged;

        /// <summary>
        /// The JointMapper property gets or sets the AvatarPropertyMapper responsible for mapping joint information in the Avatar model.
        /// When setting this property, any changes made will trigger the AvatarPropertiesChanged event if it has been subscribed to.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarPropertyMapper JointMapper
        {
            get
            {
                return jointMapper;
            }
            set
            {
                jointMapper = value;
                PropertiesChanged?.Invoke(jointMapper, this);
            }
        }

        /// <summary>
        /// The BlendShapeMapper property gets or sets the AvatarPropertyMapper responsible for managing blend shape information in the Avatar model.
        /// When setting this property, any changes made will trigger the AvatarPropertiesChanged event if it has been subscribed to.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarPropertyMapper BlendShapeMapper
        {
            get
            {
                return blendShapeMapper;
            }
            set
            {
                blendShapeMapper = value;
                PropertiesChanged?.Invoke(blendShapeMapper, this);
            }
        }

        /// <summary>
        /// The NodeMapper property gets or sets the AvatarPropertyMapper responsible for managing node information in the Avatar model.
        /// When setting this property, any changes made will trigger the AvatarPropertiesChanged event if it has been subscribed to.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarPropertyMapper NodeMapper
        {
            get
            {
                return nodeMapper;
            }
            set
            {
                nodeMapper = value;
                PropertiesChanged?.Invoke(nodeMapper, this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the AvatarProperties class with the specified joint mapper, blend shape mapper, and node mapper.
        /// These mappers are used to map between the Avatar's underlying model data and its corresponding properties.
        /// </summary>
        /// <param name="jointMapper">The AvatarPropertyMapper for joints.</param>
        /// <param name="blendShapeMapper">The AvatarPropertyMapper for blend shapes.</param>
        /// <param name="nodeMapper">The AvatarPropertyMapper for nodes.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarProperties(AvatarPropertyMapper jointMapper, AvatarPropertyMapper blendShapeMapper, AvatarPropertyMapper nodeMapper)
        {
            JointMapper = new AvatarPropertyMapper(jointMapper);
            BlendShapeMapper = new AvatarPropertyMapper(blendShapeMapper);
            NodeMapper = new AvatarPropertyMapper(nodeMapper);
        }

        /// <summary>
        /// This method generates a MotionIndex to be used in animations based on the NodeType and BlendShapeType using the model information of an Avatar.
        /// </summary>
        /// <param name="nodeType">Node type</param>
        /// <param name="blendShapeType">Blend shape type</param>
        /// <returns>The generated MotionIndex</returns>
        public MotionIndex CreateBlendShapeMotionIndex(NodeType nodeType, BlendShapeType blendShapeType)
        {
            var motionIndex = new AvatarBlendShapeIndex(NodeMapper, nodeType, BlendShapeMapper, blendShapeType);
            return motionIndex;
        }
    }
}
