/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

namespace Tizen.AIAvatar
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AvatarProperties
    {
        private AvatarPropertyMapper jointMapper;
        private AvatarPropertyMapper blendShapeMapper;
        private AvatarPropertyMapper nodeMapper;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarProperties(AvatarPropertyMapper jointMapper, AvatarPropertyMapper blendShapeMapper, AvatarPropertyMapper nodeMapper)
        {
            JointMapper = new AvatarPropertyMapper(jointMapper);
            BlendShapeMapper = new AvatarPropertyMapper(blendShapeMapper);
            NodeMapper = new AvatarPropertyMapper(nodeMapper);
        }

        internal event EventHandler<AvatarProperties> AvatarPropertiesChanged;

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
                AvatarPropertiesChanged?.Invoke(jointMapper, this);
            }
        }

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
                AvatarPropertiesChanged?.Invoke(blendShapeMapper, this);
            }
        }

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
                AvatarPropertiesChanged?.Invoke(nodeMapper, this);
            }
        }
    }
}
