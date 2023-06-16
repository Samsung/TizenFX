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
        private List<(MotionIndex, MotionValue)> motionValues { get; set; } = null;

        /// <summary>
        /// Owned motion value list.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Do not use this MotionValues property directly. Use Add and GetIndex, GetValue instead.")]
        public List<(MotionIndex, MotionValue)> MotionValues
        {
            get
            {
                return motionValues;
            }
            set
            {
                motionValues = value;
            }
        }

        /// <summary>
        /// Append pair of MotionIndex and MotionValue end of list.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(MotionIndex index, MotionValue value)
        {
            if(motionValues == null)
            {
                motionValues = new List<(MotionIndex, MotionValue)>();
            }
            motionValues.Add((index, value));
        }

        /// <summary>
        /// Get MotionIndex at index'th. null if invalid index inputed
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionIndex GetIndex(uint index)
        {
            if(motionValues != null && index < motionValues.Count)
            {
                return motionValues[(int)index].Item1;
            }
            return null;
        }

        /// <summary>
        /// Get MotionValue at index'th. null if invalid index inputed
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionValue GetValue(uint index)
        {
            if(motionValues != null && index < motionValues.Count)
            {
                return motionValues[(int)index].Item2;
            }
            return null;
        }

        /// <summary>
        /// Clear all inputed values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            motionValues = null;
        }

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
            if (motionValues != null)
            {
                foreach (var indexValuePair in motionValues)
                {
                    indexValuePair.Item1?.Dispose();
                    indexValuePair.Item2?.Dispose();
                }
                motionValues = null;
            }
        }
    }
}
