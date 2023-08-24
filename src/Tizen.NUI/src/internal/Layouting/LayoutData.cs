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

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] Class to hold layout animation and position data
    /// </summary>
    internal struct LayoutData
    {
        /// <summary>
        /// [Draft] Initialized constructor
        /// </summary>
        /// <param name="item">Layout item.</param>
        /// <param name="condition">Condition for the position values.</param>
        /// <param name="left">Left position.</param>
        /// <param name="top">Top position.</param>
        /// <param name="right">Right position.</param>
        /// <param name="bottom">Bottom position.</param>
        public LayoutData(LayoutItem item, TransitionCondition condition, float left, float top, float right, float bottom)
        {
            Item = item;
            ConditionForAnimation = condition;
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public LayoutItem Item { get; }

        public TransitionCondition ConditionForAnimation { get; }

        public float Left { get; }
        public float Top { get; }
        public float Right { get; }
        public float Bottom { get; }

    };

} // namespace Tizen.NUI
