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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ControlStyle is a base class of NUI.Components style.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ControlStyle : ViewStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create("ControlBackgroundImage", typeof(Selector<string>), typeof(ControlStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var controlStyle = (ControlStyle)bindable;
            if (null == controlStyle.backgroundImage) controlStyle.backgroundImage = new Selector<string>();
            controlStyle.backgroundImage.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var controlStyle = (ControlStyle)bindable;
            return controlStyle.backgroundImage;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create("ControlBackgroundColor", typeof(Selector<Color>), typeof(ControlStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var controlStyle = (ControlStyle)bindable;
            if (null == controlStyle.backgroundColor) controlStyle.backgroundColor = new Selector<Color>();
            controlStyle.backgroundColor.Clone((Selector<Color>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var controlStyle = (ControlStyle)bindable;
            return controlStyle.backgroundColor;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageBorderProperty = BindableProperty.Create("ControlBackgroundImageBorder", typeof(Selector<Rectangle>), typeof(ControlStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var controlStyle = (ControlStyle)bindable;
            if (null == controlStyle.backgroundImageBorder) controlStyle.backgroundImageBorder = new Selector<Rectangle>();
            controlStyle.backgroundImageBorder.Clone((Selector<Rectangle>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var controlStyle = (ControlStyle)bindable;
            return controlStyle.backgroundImageBorder;
        });
        private Selector<string> backgroundImage;
        private Selector<Rectangle> backgroundImageBorder;
        private Selector<Color> backgroundColor;
        /// <summary>
        /// Creates a new instance of a ControlStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ControlStyle() : base()
        {
            InitSubstyle();
        }

        /// <summary>
        /// Creates a new instance of a ControlStyle with style.
        /// </summary>
        /// <param name="style">Create ControlStyle by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ControlStyle(ControlStyle style) : base(style)
        {
            if(null == style) return;

            InitSubstyle();

            this.CopyFrom(style);
        }

        /// <summary>Background image resource.</summary>
        /// This will be public opened in tizen__6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Selector<string> BackgroundImage
        {
            get
            {
                Selector<string> image = (Selector<string>)GetValue(BackgroundImageProperty);
                return (null != image) ? image : backgroundImage = new Selector<string>();
            }
            set => SetValue(BackgroundImageProperty, value);
        }

        /// <summary>Background image border.</summary>
        /// This will be public opened in tizen__6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Selector<Rectangle> BackgroundImageBorder
        {
            get
            {
                Selector<Rectangle> boder = (Selector<Rectangle>)GetValue(BackgroundImageBorderProperty);
                return (null != boder) ? boder : backgroundImageBorder = new Selector<Rectangle>();
            }
            set => SetValue(BackgroundImageBorderProperty, value);
        }

        /// <summary>Background image color. </summary>
        /// This will be public opened in tizen__6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Selector<Color> BackgroundColor
        {
            get
            {
                Selector<Color> color = (Selector<Color>)GetValue(BackgroundColorProperty);
                return (null != color) ? color : backgroundColor = new Selector<Color>();
            }
            set => SetValue(BackgroundColorProperty, value);
        }

        /// <summary>
        /// Shadow image's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen__6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Shadow { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            ControlStyle controlStyle = bindableObject as ControlStyle;

            if (null != controlStyle)
            {
                if (null != controlStyle.Shadow)
                {
                    Shadow.CopyFrom(controlStyle.Shadow);
                }
                if (null != controlStyle.BackgroundImage)
                {
                    if (null == BackgroundImage) BackgroundImage = new Selector<string>();
                    BackgroundImage.Clone(controlStyle.BackgroundImage);
                }
                if (null != controlStyle.BackgroundImageBorder)
                {
                    if (null == BackgroundImageBorder) BackgroundImageBorder = new Selector<Rectangle>();
                    BackgroundImageBorder.Clone(controlStyle.BackgroundImageBorder);
                }
                if (null != controlStyle.BackgroundColor)
                {
                    if (null == BackgroundColor) BackgroundColor = new Selector<Color>();
                    BackgroundColor.Clone(controlStyle.BackgroundColor);
                }
            }
        }

        private void InitSubstyle()
        {
            Shadow = new ImageViewStyle()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };
            Shadow.PropertyChanged += SubStyleCalledEvent;
        }

        private void SubStyleCalledEvent(object sender, global::System.EventArgs e)
        {
            OnPropertyChanged();
        }
    }
}
