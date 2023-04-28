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
using System.Collections.Generic;
using Tizen.NUI;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Index of motion value. It will be used to specify the target of motion applied.
    ///
    /// There are two kinds of MotionIndex : MotionTransformIndex and BlendShapeIndex.
    /// MotionTransformIndex will be used for control the ModelNode's Position / Orientation / Scale, or each components.
    /// BlendShapeIndex will be used for control some blendshape animation.
    ///
    /// We can use this class below cases
    /// - ModelNodeId (string key) , MotionTransformIndex         : Target is ModelNode's transform property
    /// - ModelNodeId (int key)    , MotionTransformIndex         : Target is ModelNode's transform property [not implemented yet]
    /// - ModelNodeId (string key) , BlendShapeIndex (int key)    : Target is ModelNode's BlendShape
    /// - ModelNodeId (string key) , BlendShapeIndex (string key) : Target is ModelNode's BlendShape [not implemented yet]
    /// - ModelNodeId (int key)    , BlendShapeIndex (int key)    : Target is ModelNode's BlendShape [not implemented yet]
    /// - ModelNodeId (int key)    , BlendShapeIndex (string key) : Target is ModelNode's BlendShape [not implemented yet]
    /// - ModelNodeId (null)       , BlendShapeIndex (string key) : Target is all BlendShape [not implemented yet]
    /// All other cases are invalid.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class MotionIndex : IDisposable
    {
        /// <summary>
        /// The id of ModelNode. If you want to apply to all ModelNodes who has BlendShape string, let this value as null.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyKey ModelNodeId { get; set; } = null;

        /// <summary>
        /// Abstract API to get uniform name of index, or null if invalid. Only can be used for internal API
        /// </summary>
        abstract internal string GetPropertyName(ModelNode node);

        /// <summary>
        /// IDisposable.Dipsose.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            ModelNodeId?.Dispose();
            ModelNodeId = null;
        }
    }
}
