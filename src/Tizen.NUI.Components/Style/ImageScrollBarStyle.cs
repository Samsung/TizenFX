/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ScrollBarStyle is a class which saves Scrollbar's ux data.
    /// </summary>
    /// <remarks>
    /// Please note that this class will be replaced with ScrollbarStyle class in the near future.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollBarStyle : ControlStyle
    {
        static ScrollBarStyle() { }

        /// <summary>
        /// Creates a new instance of a ScrollBarStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBarStyle() : base()
        {
            InitSubStyle();
            Direction = ScrollBar.DirectionType.Horizontal;
        }

        /// <summary>
        /// Creates a new instance of a ScrollBarStyle with style.
        /// </summary>
        /// <param name="style">Create ScrollBarStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBarStyle(ScrollBarStyle style) : base(style)
        {
            if (null == style) return;

            InitSubStyle();

            this.CopyFrom(style);
        }

        /// <summary>
        /// Get or set track image style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Track { get; set; }

        /// <summary>
        /// Get or set thumb image style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Thumb { get; set; }

        /// <summary>
        /// Get or set direction type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar.DirectionType? Direction { get; set; }

        /// <summary>
        /// Get or set duration.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Duration { get; set; }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            ScrollBarStyle scrollBarStyle = bindableObject as ScrollBarStyle;

            if (null != scrollBarStyle)
            {
                if (null != scrollBarStyle.Track)
                {
                    Track?.CopyFrom(scrollBarStyle.Track);
                }

                if (null != scrollBarStyle.Thumb)
                {
                    Thumb?.CopyFrom(scrollBarStyle.Thumb);
                }

                Direction = scrollBarStyle.Direction;
                Duration = scrollBarStyle.Duration;
            }
        }

        private void InitSubStyle()
        {
            Track = new ImageViewStyle()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };

            Thumb = new ImageViewStyle()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                WidthResizePolicy = ResizePolicyType.Fixed,
                HeightResizePolicy = ResizePolicyType.Fixed
            };
        }
    }
}
