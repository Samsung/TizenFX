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
 */

using System;
using Tizen.NUI;
using Tizen.NUI.Scene3D;
using Tizen.NUI.AIAvatar;


namespace AIAvatar
{
    public class EyeBlinkMotionData : ICustomMotionData
    {
        private MotionData motionData;
        private MotionValue eyeBlinkMotionValue;

        private BlendShapeIndex headBlendShapeEyeLeft;
        private BlendShapeIndex headBlendShapeEyeRight;
        private BlendShapeIndex eyelashBlendShapeEyeLeft;
        private BlendShapeIndex eyelashBlendShapeEyeRight;

        private int duration;
        private const int DefaultBlinkDuration = 4000;
        public EyeBlinkMotionData()
        {
            Initialize();
        }


        public void Initialize()
        {           
            CreateEyeBlinkData();
            motionData = GenerateMotionData(DefaultBlinkDuration);
        }

        public MotionData GetMotionData(int durationMilliseconds = DefaultBlinkDuration)
        {
            if (motionData == null)
            {
                throw new InvalidOperationException("Animation is not initialized.");
            }

            if (durationMilliseconds != duration)
            {
                motionData?.Dispose();
                motionData = GenerateMotionData(durationMilliseconds);
            }

            return motionData;
        }


        private MotionData GenerateMotionData(int durationMilliseconds)
        {
            duration = durationMilliseconds;

            var motionData = new MotionData(duration);

            motionData.Add(headBlendShapeEyeLeft, eyeBlinkMotionValue);
            motionData.Add(headBlendShapeEyeRight, eyeBlinkMotionValue);
            motionData.Add(eyelashBlendShapeEyeLeft, eyeBlinkMotionValue);
            motionData.Add(eyelashBlendShapeEyeRight, eyeBlinkMotionValue);

            return motionData;
        }

        private void CreateEyeBlinkData()
        {
            using var keyFrames = new KeyFrames();
            using var alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOut);
            
            keyFrames.Add(0.0f, 0.0f, alphaFunction);
            keyFrames.Add(0.1f, 0.0f, alphaFunction);
            keyFrames.Add(0.15f, 1.0f, alphaFunction);
            keyFrames.Add(0.2f, 0.0f, alphaFunction);
            keyFrames.Add(0.3f, 0.0f, alphaFunction);
            keyFrames.Add(0.325f, 1.0f, alphaFunction);
            keyFrames.Add(0.35f, 0.0f, alphaFunction);
            keyFrames.Add(1.0f, 0.0f, alphaFunction);


            eyeBlinkMotionValue = new MotionValue(keyFrames);

            using var headNodeID = new PropertyKey("head_GEO");
            using var eyelashNodeID = new PropertyKey("eyelash_GEO");
            using var eyeBlinkLeftBlendShapeID = new PropertyKey("EyeBlink_Left");
            using var eyeBlinkRightBlendShapeID = new PropertyKey("EyeBlink_Right");
            

            headBlendShapeEyeLeft = new BlendShapeIndex(headNodeID, eyeBlinkLeftBlendShapeID);
            headBlendShapeEyeRight = new BlendShapeIndex(headNodeID, eyeBlinkRightBlendShapeID);
            eyelashBlendShapeEyeLeft = new BlendShapeIndex(eyelashNodeID, eyeBlinkLeftBlendShapeID);
            eyelashBlendShapeEyeRight = new BlendShapeIndex(eyelashNodeID, eyeBlinkRightBlendShapeID);
        }


    }
}
