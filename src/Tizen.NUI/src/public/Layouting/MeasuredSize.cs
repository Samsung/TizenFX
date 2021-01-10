/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] Class that encodes a measurement and a measure state, which is set if the measured size is too small.
    /// </summary>
    public struct MeasuredSize
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="measuredSize">size parameter</param>
        /// <param name="state">State</param>
        /// <since_tizen> 6 </since_tizen>
        public MeasuredSize(LayoutLength measuredSize, MeasuredSize.StateType state)
        {
            Size = measuredSize;
            State = state;
        }

        /// <summary>
        /// Creates a MeasuredSize from a LayoutLength
        /// </summary>
        /// <param name="measuredSize">LayoutLength to create </param>
        /// <since_tizen> 6 </since_tizen>
        /// <returns> Returns a MeasuredSize object</returns>
        public static implicit operator MeasuredSize(LayoutLength measuredSize)
        {
            return new MeasuredSize(measuredSize, StateType.MeasuredSizeOK);
        }

        /// <summary>
        /// LayoutLength size property
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LayoutLength Size { get; set; }

        /// <summary>
        /// Measured state for this size.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StateType State { get; set; }

        /// <summary>
        /// Measured states for a Size value.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum StateType
        {
            /// <summary>
            /// The measured size is good
            /// </summary>
            MeasuredSizeOK,
            /// <summary>
            /// The measured size is too small
            /// </summary>
            MeasuredSizeTooSmall
        }
    }
}
