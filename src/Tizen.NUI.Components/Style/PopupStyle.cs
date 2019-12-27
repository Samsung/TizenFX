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
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PopupStyle : ControlStyle
    {
        static PopupStyle() { }

        /// <summary>
        /// Creates a new instance of a PopupStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PopupStyle() : base()
        {
            InitSubStyle();
        }

        /// <summary>
        /// Creates a new instance of a PopupStyle with style.
        /// </summary>
        /// <param name="style">Create PopupStyle by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PopupStyle(PopupStyle style) : base(style)
        {
            InitSubStyle();
            this.CopyFrom(style);
        }

        /// <summary>
        /// Title Text's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle Title
        {
            get;
            set;
        }

        /// <summary>
        /// Shadow offset.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ShadowExtents
        {
            get;
            set;
        }

        /// <summary>
        /// Popup button's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ButtonStyle Buttons
        {
            get;
            set;
        }

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            PopupStyle popupAttributes = bindableObject as PopupStyle;
            if (popupAttributes != null)
            {
                if (popupAttributes.Title != null)
                {
                    Title.CopyFrom(popupAttributes.Title);
                }

                if (popupAttributes.Buttons != null)
                {
                    Buttons.CopyFrom(popupAttributes.Buttons);
                }

                if (popupAttributes.ShadowExtents != null)
                {
                    ShadowExtents = new Extents(popupAttributes.ShadowExtents.Start, popupAttributes.ShadowExtents.End, popupAttributes.ShadowExtents.Top, popupAttributes.ShadowExtents.Bottom);
                }
            }
        }

        private void InitSubStyle()
        {
            ShadowExtents = new Extents(24, 24, 24, 24);
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
