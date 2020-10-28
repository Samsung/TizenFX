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

using System.Collections.Generic;

namespace Tizen.NUI
{

    /// <summary>
    /// [Draft] Class to hold layout position data
    /// </summary>
    internal struct LayoutPositionData
    {
        /// <summary>
        /// [Draft] Initialized constructor
        /// </summary>
        /// <param name="left">Left position.</param>
        /// <param name="top">Top position.</param>
        /// <param name="right">Right position.</param>
        /// <param name="bottom">Bottom position.</param>
        /// <param name="animated">If an animation is required to the given positions.</param>
        public LayoutPositionData( float left, float top, float right, float bottom, bool animated )
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
            _animated = animated;
        }

        private float _left;
        private float _top;
        private float _right;
        private float _bottom;
        private bool _animated;
    };

    /// <summary>
    /// [Draft] Class to hold Layout data for each entity being laid out.
    /// </summary>
    internal class LayoutData
    {
        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        public LayoutData()
        {
            LayoutPositionDataList = new List<LayoutPositionData>();
        }

        private List<LayoutPositionData> layoutPositionDataList;

        internal List<LayoutPositionData> LayoutPositionDataList { get => layoutPositionDataList; set => layoutPositionDataList = value; }
    } // LayoutData

} // namespace Tizen.NUI
