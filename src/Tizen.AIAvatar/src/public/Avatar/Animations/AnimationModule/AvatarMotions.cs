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
using Tizen.NUI;
using Tizen.NUI.Scene3D;
using Vowel2Animation;

namespace Tizen.AIAvatar
{
    internal class AvatarMotions
    {
        private MotionData eyeMotionData;
        private const int blinkDuration = 200;

        internal AvatarMotions(AvatarProperties properties)
        {
            CreateEyeBlinkMotionData(properties);
        }

        internal MotionData EyeMotionData { get { return eyeMotionData; } }

        private void CreateEyeBlinkMotionData(AvatarProperties avatarProperties)
        {
            var keyFrames = new KeyFrames();
            keyFrames.Add(0.1f, 0.0f);
            keyFrames.Add(0.5f, 1.0f);
            keyFrames.Add(0.9f, 0.0f);

            var headBlendShapeEyeLeft = new AvatarBlendShapeIndex(avatarProperties.NodeMapper, NodeType.HeadGeo, avatarProperties.BlendShapeMapper, BlendShapeType.EyeBlinkLeft);
            var headBlendShapeEyeRight = new AvatarBlendShapeIndex(avatarProperties.NodeMapper, NodeType.HeadGeo, avatarProperties.BlendShapeMapper, BlendShapeType.EyeBlinkRight);
            var eyelashBlendShapeEyeLeft = new AvatarBlendShapeIndex(avatarProperties.NodeMapper, NodeType.EyelashGeo, avatarProperties.BlendShapeMapper, BlendShapeType.EyeBlinkLeft);
            var eyelashBlendShapeEyeRight = new AvatarBlendShapeIndex(avatarProperties.NodeMapper, NodeType.EyelashGeo, avatarProperties.BlendShapeMapper, BlendShapeType.EyeBlinkRight);

            eyeMotionData = new MotionData(blinkDuration);
            if (headBlendShapeEyeLeft != null)
            {
                eyeMotionData.Add(headBlendShapeEyeLeft, new MotionValue(keyFrames));
            }
            if (headBlendShapeEyeRight != null)
            {
                eyeMotionData.Add(headBlendShapeEyeRight, new MotionValue(keyFrames));
            }
            if (eyelashBlendShapeEyeLeft != null)
            {
                eyeMotionData.Add(eyelashBlendShapeEyeLeft, new MotionValue(keyFrames));
            }
            if (eyelashBlendShapeEyeRight != null)
            {
                eyeMotionData.Add(eyelashBlendShapeEyeRight, new MotionValue(keyFrames));
            }
        }
    }
}
