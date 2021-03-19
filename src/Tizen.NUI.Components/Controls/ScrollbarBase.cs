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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The ScrollbarBase is an abstract class that can be linked to the scrollable objects
    /// indicating the current scrolled position of the scrollable object.
    /// This only contains non-graphical functionalities of basic scrollbar.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class ScrollbarBase : Control
    {
        #region Constructors

        /// <summary>
        /// Create an empty ScrollbarBase.
        /// </summary>
        protected ScrollbarBase()
        {
        }

        /// <summary>
        /// Create an empty Scrollbar with a ViewStyle instance to set style properties.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ScrollbarBase(ControlStyle style) : base(style)
        {
        }

        /// <summary>
        /// Static constructor to initialize bindable properties when loading.
        /// </summary>
        static ScrollbarBase()
        {
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Removes a view from its parent ScrollableBase. If a view has no parent, this method does nothing.
        /// </summary>
        public new void Unparent()
        {
            (GetParent() as ScrollableBase)?.BaseRemove(this);
        }

        /// <summary>
        /// Update content length and position at once.
        /// </summary>
        /// <param name="contentLength">The total length of the content.</param>
        /// <param name="viewportLength">The length of the viewport representing the amount of visible content.</param>
        /// <param name="position">The destination position of the View in content length. This is the View's top position if the scroller is vertical, otherwise, View's left position.</param>
        /// <param name="durationMs">The time it takes to scroll in milliseconds.</param>
        /// <param name="alphaFunction">The timing function used in animation. It describes the rate of change of the animation parameter over time. (e.g. EaseOut)</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Update(float contentLength, float viewportLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null);

        /// <summary>
        /// Update content length and position at once.
        /// </summary>
        /// <param name="contentLength">The total length of the content.</param>
        /// <param name="position">The destination position of the View in content length. This is the View's top position if the scroller is vertical, otherwise, View's left position.</param>
        /// <param name="durationMs">The time it takes to scroll in milliseconds.</param>
        /// <param name="alphaFunction">The timing function used in animation. It describes the rate of change of the animation parameter over time. (e.g. EaseOut)</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Update(float contentLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null);

        /// <summary>
        /// Scroll content to a specific position.
        /// </summary>
        /// <param name="position">The destination to scroll.</param>
        /// <param name="durationMs">The time it takes to scroll in milliseconds.</param>
        /// <param name="alphaFunction">The timing function used in animation. It describes the rate of change of the animation parameter over time. (e.g. EaseOut)</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void ScrollTo(float position, uint durationMs = 0, AlphaFunction alphaFunction = null);

        /// <summary>
        /// Initialize the scroll bar.
        /// </summary>
        /// <param name="contentLength">The length of the scrollable content area.</param>
        /// <param name="viewportLength">The length of the viewport representing the amount of visible content.</param>
        /// <param name="currentPosition">The current position of the viewport in scrollable content area. This is the viewport's top position if the scroller is vertical, otherwise, left.</param>
        /// <param name="isHorizontal">Whether the direction of scrolling is horizontal or not. It is vertical by default.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Initialize(float contentLength, float viewportLength, float currentPosition, bool isHorizontal = false);

        /// <summary>
        /// Scroll position given to ScrollTo or Update.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float ScrollPosition { get; }

        /// <summary>
        /// Current scroll position in the middle of ScrollTo or Update animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float ScrollCurrentPosition { get; }

        #endregion Methods
    }
}
