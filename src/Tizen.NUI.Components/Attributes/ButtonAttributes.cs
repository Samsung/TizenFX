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
    /// ButtonAttributes is a class which saves Button's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ButtonStyle : ControlStyle
    {
        private bool? isSelectable;
        private bool? isSelected;
        private bool? isEnabled;
        private Button.IconOrientation? iconRelativeOrientation;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectableProperty = BindableProperty.Create("IsSelectable", typeof(bool?), typeof(ButtonStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            buttonStyle.isSelectable = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.isSelectable;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool?), typeof(ButtonStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            buttonStyle.isSelected = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.isSelected;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create("IsEnabled", typeof(bool?), typeof(ButtonStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            buttonStyle.isEnabled = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.isEnabled;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconRelativeOrientationProperty = BindableProperty.Create("IconRelativeOrientation", typeof(Button.IconOrientation?), typeof(ButtonStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            buttonStyle.iconRelativeOrientation = (Button.IconOrientation?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.iconRelativeOrientation;
        });

        /// <summary>
        /// Creates a new instance of a ButtonStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ButtonStyle() : base()
        {
            InitSubAttributes();
        }
        /// <summary>
        /// Creates a new instance of a ButtonStyle with style.
        /// </summary>
        /// <param name="style">Create ButtonStyle by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ButtonStyle(ButtonStyle style) : base(style)
        {
            if(style == null)
            {
                return;
            }

            IsSelectable = style.IsSelectable;
            IconRelativeOrientation = style.IconRelativeOrientation;

            InitSubAttributes();

            Overlay.CopyFrom(style.Overlay);
            Text.CopyFrom(style.Text);
            Icon.CopyFrom(style.Icon);
        }
        /// <summary>
        /// Overlay image's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Overlay
        {
            get;
            set;
        }
        /// <summary>
        /// Text's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle Text
        {
            get;
            set;
        }
        /// <summary>
        /// Icon's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Icon
        {
            get;
            set;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSelectable
        {
            get
            {
                bool? temp = (bool?)GetValue(IsSelectableProperty);
                return temp;
            }
            set
            {
                SetValue(IsSelectableProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSelected
        {
            get
            {
                bool? temp = (bool?)GetValue(IsSelectedProperty);
                return temp;
            }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }

        /// <summary>
        /// Flag to decide button can be selected or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsEnabled
        {
            get
            {
                bool? temp = (bool?)GetValue(IsEnabledProperty);
                return temp;
            }
            set
            {
                SetValue(IsEnabledProperty, value);
            }
        }

        /// <summary>
        /// Icon relative orientation.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button.IconOrientation? IconRelativeOrientation
        {
            get
            {
                Button.IconOrientation? temp = (Button.IconOrientation?)GetValue(IconRelativeOrientationProperty);
                return temp;
            }
            set
            {
                SetValue(IconRelativeOrientationProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            ButtonStyle buttonAttributes = bindableObject as ButtonStyle;

            if (null != buttonAttributes)
            {
                if (null != buttonAttributes.Overlay)
                {
                    Overlay.CopyFrom(buttonAttributes.Overlay);
                }

                if (null != buttonAttributes.Text)
                {
                    Text.CopyFrom(buttonAttributes.Text);
                }

                if (null != buttonAttributes.Icon)
                {
                    Icon.CopyFrom(buttonAttributes.Icon);
                }
            }
        }

        private void InitSubAttributes()
        {
            Overlay = new ImageViewStyle()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };
            Overlay.PropertyChanged += SubStyleCalledEvent;

            Text = new TextLabelStyle()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Text.PropertyChanged += SubStyleCalledEvent;

            Icon = new ImageViewStyle()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            Icon.PropertyChanged += SubStyleCalledEvent;
        }

        private void SubStyleCalledEvent(object sender, global::System.EventArgs e)
        {
            OnPropertyChanged();
        }
    }
}
