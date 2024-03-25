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

using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Scene3D;

namespace Tizen.AIAvatar
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class JointTransformer
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JointTransformer() 
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Init(Animation animation)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Play(IAnimationModuleData data)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Pause()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Destroy()
        {
        }

        private void SetJointMotion(AvatarProperties properties, JointType jointType, MotionTransformIndex.TransformTypes type, Rotation rotation)
        {
            var motionTransform = new AvatarJointTransformIndex(properties.JointMapper, jointType, type);
            var motionData = new MotionData();
            motionData.Add(
                motionTransform,
                new MotionValue()
                {
                    //TODO : Tizen_7.0에 pitch, yaw, roll patch 추가하기
                    //PropertyValue = new PropertyValue(new Rotation(new Radian(pitch), new Radian(yaw), new Radian(roll))),
                }
            );
            //avatar.SetMotionData(motionData);
        }

        private void SetJointMotion(string keyValue, float pitch, float yaw, float roll)
        {
            var motionData = new MotionData();
            motionData.Add(
                new MotionTransformIndex()
                {
                    ModelNodeId = new PropertyKey(keyValue),
                    TransformType = MotionTransformIndex.TransformTypes.Orientation,
                },
                new MotionValue()
                {
                    //TODO : Tizen_7.0에 pitch, yaw, roll patch 추가하기
                    //PropertyValue = new PropertyValue(new Rotation(new Radian(pitch), new Radian(yaw), new Radian(roll))),
                }
            );
            //avatar.SetMotionData(motionData);
        }

        private void SetJointMotion(string keyValue, MotionTransformIndex.TransformTypes type, Rotation rotation)
        {
            var motionData = new MotionData();
            motionData.Add(
                new MotionTransformIndex()
                {
                    ModelNodeId = new PropertyKey(keyValue),
                    TransformType = type,
                },
                new MotionValue()
                {
                    PropertyValue = new PropertyValue(rotation),
                }
            );
            //avatar.SetMotionData(motionData);
        }
    }
}
