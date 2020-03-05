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
    /// <since_tizen> 8 </since_tizen>
    public class ButtonStyle : ControlStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectableProperty = BindableProperty.Create(nameof(IsSelectable), typeof(bool?), typeof(ButtonStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool?), typeof(ButtonStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool?), typeof(ButtonStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty IconRelativeOrientationProperty = BindableProperty.Create(nameof(IconRelativeOrientation), typeof(Button.IconOrientation?), typeof(ButtonStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            buttonStyle.iconRelativeOrientation = (Button.IconOrientation?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.iconRelativeOrientation;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconPaddingProperty = BindableProperty.Create(nameof(IconPadding), typeof(Extents), typeof(ButtonStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            if (null == buttonStyle.iconPadding) buttonStyle.iconPadding = new Extents(buttonStyle.OnIconPaddingChanged, 0, 0, 0, 0);
            buttonStyle.iconPadding.CopyFrom(null == newValue ? new Extents() : (Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.iconPadding;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextPaddingProperty = BindableProperty.Create(nameof(TextPadding), typeof(Extents), typeof(ButtonStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            if (null == buttonStyle.textPadding) buttonStyle.textPadding = new Extents(buttonStyle.OnTextPaddingChanged, 0, 0, 0, 0);
            buttonStyle.textPadding.CopyFrom(null == newValue ? new Extents() : (Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.textPadding;
        });

        private bool? isSelectable;
        private bool? isSelected;
        private bool? isEnabled;
        private Button.IconOrientation? iconRelativeOrientation;
        private Extents iconPadding;
        private Extents textPadding;

        static ButtonStyle() { }

        /// <summary>
        /// Creates a new instance of a ButtonStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ButtonStyle() : base()
        {
            InitSubStyle();
        }

        /// <summary>
        /// Creates a new instance of a ButtonStyle with style.
        /// </summary>
        /// <param name="style">Create ButtonStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public ButtonStyle(ButtonStyle style) : base(style)
        {
            if(style == null)
            {
                return;
            }

            InitSubStyle();

            this.CopyFrom(style);
        }
        /// <summary>
        /// Overlay image's Style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Overlay { get; set; }

        /// <summary>
        /// Text's Style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TextLabelStyle Text { get; set; }

        /// <summary>
        /// Icon's Style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Icon { get; set; }

        /// <summary>
        /// Flag to decide Button can be selected or not.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool? IsSelectable
        {
            get => (bool?)GetValue(IsSelectableProperty);
            set => SetValue(IsSelectableProperty, value);
        }

        /// <summary>
        /// Flag to decide selected state in Button.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool? IsSelected
        {
            get => (bool?)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        /// <summary>
        /// Flag to decide button can be selected or not.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool? IsEnabled
        {
            get => (bool?)GetValue(IsEnabledProperty);
            set => SetValue(IsEnabledProperty, value);
        }

        /// <summary>
        /// Icon relative orientation.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Button.IconOrientation? IconRelativeOrientation
        {
            get => (Button.IconOrientation?)GetValue(IconRelativeOrientationProperty);
            set => SetValue(IconRelativeOrientationProperty, value);
        }

        /// <summary>
        /// Icon padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Extents IconPadding
        {
            get
            {
                Extents padding = (Extents)GetValue(IconPaddingProperty);
                return (null != padding) ? padding : iconPadding = new Extents(OnIconPaddingChanged, 0, 0, 0, 0);
            }
            set => SetValue(IconPaddingProperty, value);
        }

        /// <summary>
        /// Text padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Extents TextPadding
        {
            get
            {
                Extents padding = (Extents)GetValue(TextPaddingProperty);
                return (null != padding) ? padding : textPadding = new Extents(OnTextPaddingChanged, 0, 0, 0, 0);
            }
            set => SetValue(TextPaddingProperty, value);
        }

        /// <summary>
        /// Style's clone function.
        /// </summary>
        /// <param name="bindableObject">The style that need to copy.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            ButtonStyle buttonStyle = bindableObject as ButtonStyle;

            if (null != buttonStyle)
            {
                if (null != buttonStyle.Overlay)
                {
                    Overlay?.CopyFrom(buttonStyle.Overlay);
                }

                if (null != buttonStyle.Text)
                {
                    Text?.CopyFrom(buttonStyle.Text);
                }

                if (null != buttonStyle.Icon)
                {
                    Icon?.CopyFrom(buttonStyle.Icon);
                }

                IsSelectable = buttonStyle.IsSelectable;
                IconRelativeOrientation = buttonStyle.IconRelativeOrientation;
            }
        }

        private void InitSubStyle()
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
                WidthResizePolicy = ResizePolicyType.FitToChildren,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
            };
            Icon.PropertyChanged += SubStyleCalledEvent;
        }

        private void SubStyleCalledEvent(object sender, global::System.EventArgs e)
        {
            OnPropertyChanged();
        }

        private void OnIconPaddingChanged(ushort start, ushort end, ushort top, ushort bottom)
        {
            IconPadding = new Extents(start, end, top, bottom);
        }

        private void OnTextPaddingChanged(ushort start, ushort end, ushort top, ushort bottom)
        {
            TextPadding = new Extents(start, end, top, bottom);
        }
    }
}
