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
using System.Runtime.InteropServices;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Scene3D
{
    public partial class Model
    {
        internal Animation InternalGenerateMotionDataAnimation(MotionData motionData, int durationMilliSeconds)
        {
            if (motionData == null || motionData.MotionValues == null)
            {
                Tizen.Log.Error("NUI", $"MotionData was null\n");
                return null;
            }

            Lazy<Animation> ret = new Lazy<Animation>(() => new Animation(durationMilliSeconds));

            foreach (var indexValuePair in motionData.MotionValues)
            {
                var motionIndex = indexValuePair.Item1;
                var motionValue = indexValuePair.Item2;

                if (motionIndex == null || motionValue == null || motionValue.Type == MotionValue.ValueType.Invalid)
                {
                    continue;
                }

                // TODO : Make we use ModelNode instead of Animatable. Currently, ModelNode have some problem.
                if (motionIndex.ModelNodeId != null)
                {
                    Animatable modelNode = null;
                    if (motionIndex.ModelNodeId.Type == PropertyKey.KeyType.String)
                    {
                        modelNode = FindChildAnimatableByName(motionIndex.ModelNodeId.StringKey);
                    }
                    else if (motionIndex.ModelNodeId.Type == PropertyKey.KeyType.Index)
                    {
                        // TODO : Not implement yet.
                    }

                    if (modelNode != null)
                    {
                        KeyFrames keyFrames = null;
                        if (motionValue.Type == MotionValue.ValueType.KeyFrames)
                        {
                            keyFrames = motionValue.KeyFramesValue;
                        }
                        else if (motionValue.Type == MotionValue.ValueType.Property)
                        {
                            // Generate stable keyframe animation here.
                            keyFrames = new KeyFrames();
                            keyFrames.Add(0.0f, motionValue.Value);
                            keyFrames.Add(1.0f, motionValue.Value);
                        }

                        if (keyFrames != null)
                        {
                            string animatedPropertyName = motionIndex.GetPropertyName(modelNode as ModelNode);
                            if (!string.IsNullOrEmpty(animatedPropertyName))
                            {
                                ret.Value.AnimateBetween(modelNode, animatedPropertyName, keyFrames);
                            }
                        }
                    }
                }
                else
                {
                    if (motionIndex is BlendShapeIndex)
                    {
                        var blendShapeIndex = motionIndex as BlendShapeIndex;
                        if (blendShapeIndex.BlendShapeId?.Type == PropertyKey.KeyType.String)
                        {
                            // TODO : Not implement yet. (Set all blendshapes by string)
                        }
                    }
                }
            }

            return ret.IsValueCreated ? ret.Value : null;
        }

        internal void InternalSetMotionData(MotionData motionData)
        {
            if (motionData == null || motionData.MotionValues == null)
            {
                Tizen.Log.Error("NUI", $"MotionData was null\n");
                return;
            }

            foreach (var indexValuePair in motionData.MotionValues)
            {
                var motionIndex = indexValuePair.Item1;
                var motionValue = indexValuePair.Item2;

                if (motionIndex == null || motionValue == null || motionValue.Type == MotionValue.ValueType.Invalid)
                {
                    continue;
                }

                if (motionIndex.ModelNodeId != null)
                {
                    // TODO : Make we use ModelNode instead of Animatable. Currently, ModelNode have some problem.
                    Animatable modelNode = null;
                    if (motionIndex.ModelNodeId.Type == PropertyKey.KeyType.String)
                    {
                        modelNode = FindChildAnimatableByName(motionIndex.ModelNodeId.StringKey);
                    }
                    else if (motionIndex.ModelNodeId.Type == PropertyKey.KeyType.Index)
                    {
                        // TODO : Not implement yet.
                    }

                    if (modelNode != null)
                    {
                        PropertyValue value = null;
                        if (motionValue.Type == MotionValue.ValueType.KeyFrames)
                        {
                            // TODO : Not implement yet.
                        }
                        else if (motionValue.Type == MotionValue.ValueType.Property)
                        {
                            value = motionValue.Value;
                        }

                        if (value != null)
                        {
                            string propertyName = motionIndex.GetPropertyName(modelNode as ModelNode);
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                modelNode.SetProperty(propertyName, value);
                            }
                        }
                    }
                }
                else
                {
                    if (motionIndex is BlendShapeIndex)
                    {
                        var blendShapeIndex = motionIndex as BlendShapeIndex;
                        if (blendShapeIndex.BlendShapeId?.Type == PropertyKey.KeyType.String)
                        {
                            // TODO : Not implement yet. (Set all blendshapes by string)
                        }
                    }
                }
            }
        }
    }
}
