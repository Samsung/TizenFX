using System.Numerics;
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
    /// Index of BlendShape feature.
    /// MotionValue should be float type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BlendShapeIndex : MotionIndex
    {
        /// <summary>
        /// Create an initialized motion index.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendShapeIndex()
        {
        }

        /// <summary>
        /// The key of BlendShape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyKey BlendShapeId { get; set; } = null;

        /// <summary>
        /// Convert from index to DALi engine using blend shape uniform name.
        /// </summary>
        internal static string GetPropertyNameFromIndex(int index)
        {
            if (index >= 0)
            {
                return "uBlendShapeWeight[" + index.ToString() + "]";
            }
            return null;
        }

        /// <summary>
        /// Get uniform name of blendshape.
        /// </summary>
        internal override string GetPropertyName(ModelNode node)
        {
            if (BlendShapeId != null)
            {
                if (BlendShapeId.Type == PropertyKey.KeyType.Index)
                {
                    return GetPropertyNameFromIndex(BlendShapeId.IndexKey);
                }
                if (node != null)
                {
                    // TODO : Not implement yet. We should make API that get the blendshape index from node by name.
                }
            }
            return null;
        }
    }
}
