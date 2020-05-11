/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The common interface for scroll bar classes.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IScrollBar
    {
        /// <summary>
        /// Initialize the scroll bar.
        /// </summary>
        /// <param name="contentLength">The total length of the content.</param>
        /// <param name="viewSize">The size of View that contains the content to scroll.</param>
        /// <param name="currentPosition">The start position of the View in content length. This is the View's top position if the scroller is vertical, otherwise, View's left position.</param>
        /// <param name="isHorizontal">Whether the direction of scrolling is horizontal or not. It is vertical if the value is false.</param>
        /// <returns>The generated View instance of the ScrollBar.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        View Initialize(float contentLength, Size viewSize, float currentPosition, bool isHorizontal = false);

        /// <summary>
        /// Update content length and position at once.
        /// </summary>
        /// <param name="contentLength">The total length of the content.</param>
        /// <param name="position">The destination position of the View in content length. This is the View's top position if the scroller is vertical, otherwise, View's left position.</param>
        /// <param name="durationMs">The time it takes to scroll in milliseconds.</param>
        /// <param name="alphaFunction">The timing function used in animation. It describes the rate of change of the animation parameter over time. (e.g. EaseOut)</param>
        /// <remarks>Please note that, for now, only alpha functions created with BuiltinFunctions are valid when animating. Otherwise, it will be treated as a linear alpha function. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Update(float contentLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null);

        /// <summary>
        /// Scroll content to a specific position.
        /// </summary>
        /// <param name="position">The destination to scroll.</param>
        /// <param name="durationMs">The time it takes to scroll in milliseconds.</param>
        /// <param name="alphaFunction">The timing function used in animation. It describes the rate of change of the animation parameter over time. (e.g. EaseOut)</param>
        /// <remarks>Please note that, for now, only alpha functions created with BuiltinFunctions are valid when animating. Otherwise, it will be treated as a linear alpha function. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ScrollTo(float position, uint durationMs = 0, AlphaFunction alphaFunction = null);
    }
}
