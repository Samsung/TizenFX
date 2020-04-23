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
    /// PopupStyle is a class which saves Popup's ux data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class PopupStyle : ControlStyle
    {
        static PopupStyle() { }

        /// <summary>
        /// Creates a new instance of a PopupStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public PopupStyle() : base()
        {
            InitSubStyle();
        }

        /// <summary>
        /// Creates a new instance of a PopupStyle with style.
        /// </summary>
        /// <param name="style">Create PopupStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public PopupStyle(PopupStyle style) : base(style)
        {
            InitSubStyle();
            this.CopyFrom(style);
        }

        /// <summary>
        /// Title Text's style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TextLabelStyle Title { get; set; }

        /// <summary>
        /// Popup button's style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ButtonStyle Buttons { get; set; }

        /// <summary>
        /// Style's clone function.
        /// </summary>
        /// <param name="bindableObject">The style that need to copy.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            PopupStyle popupStyle = bindableObject as PopupStyle;
            if (popupStyle != null)
            {
                if (popupStyle.Title != null)
                {
                    Title?.CopyFrom(popupStyle.Title);
                }

                if (popupStyle.Buttons != null)
                {
                    Buttons?.CopyFrom(popupStyle.Buttons);
                }
            }
        }

        private void InitSubStyle()
        {
            // TODO Apply proper shadow as a default for a Popup
            BoxShadow = new Shadow()
            {
                BlurRadius = 5,
                Offset = new Vector2(5, 5),
            };

            Title = new TextLabelStyle()
            {
                Size = new Size(0, 0),
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Bottom
            };

            Buttons = new ButtonStyle()
            {
                Size = new Size(0, 0),
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                Overlay = new ImageViewStyle()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                },

                Text = new TextLabelStyle()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
        }
    }
}
