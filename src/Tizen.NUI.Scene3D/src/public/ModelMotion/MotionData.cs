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

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// List of each motion value.
    /// </summary>
    /// <remark>
    /// We don't check MotionValue type is matched with MotionIndex.
    /// </remark>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MotionData : IDisposable
    {
        /// <summary>
        /// Owned motion value list.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<(MotionIndex, MotionValue)> MotionValues { get; set; } = null;

        /// <summary>
        /// Create an initialized motion data.
        /// </summary>
        public MotionData()
        {
        }

        /// <summary>
        /// IDisposable.Dipsose.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            if (MotionValues != null)
            {
                foreach (var indexValuePair in MotionValues)
                {
                    indexValuePair.Item1?.Dispose();
                    indexValuePair.Item2?.Dispose();
                }
            }
        }
    }
}
