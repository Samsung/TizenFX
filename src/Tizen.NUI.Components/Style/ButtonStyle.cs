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
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ButtonStyle is a class which saves Button's ux data.
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
            ((ButtonStyle)bindable).iconPadding = null == newValue ? null : new Extents((Extents)newValue);
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
            ((ButtonStyle)bindable).textPadding = null == newValue ? null : new Extents((Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.textPadding;
        });

        private bool? isSelectable;
        private bool? isSelected;
        private bool? isEnabled;
        private Button.IconOrientation? iconRelativeOrientation = Button.IconOrientation.Left;
        private Extents iconPadding;
        private Extents textPadding;

        static ButtonStyle() { }

        /// <summary>
        /// Creates a new instance of a ButtonStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ButtonStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a ButtonStyle with style.
        /// </summary>
        /// <param name="style">Create ButtonStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public ButtonStyle(ButtonStyle style) : base(style)
        {
        }

        /// <summary>
        /// Overlay image's Style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Overlay { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Text's Style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TextLabelStyle Text { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Icon's Style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Icon { get; set; } = new ImageViewStyle();

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
            get => ((Extents)GetValue(IconPaddingProperty)) ?? (iconPadding = new Extents());
            set => SetValue(IconPaddingProperty, value);
        }

        /// <summary>
        /// Text padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Extents TextPadding
        {
            get  => ((Extents)GetValue(TextPaddingProperty)) ?? (textPadding = new Extents());
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

            if (bindableObject is ButtonStyle buttonStyle)
            {
                Overlay.CopyFrom(buttonStyle.Overlay);
                Text.CopyFrom(buttonStyle.Text);
                Icon.CopyFrom(buttonStyle.Icon);
            }
        }

        /// <summary>
        /// Create corresponding ButtonExtension.
        /// This is to be called by a Button.
        /// You may override this function to customize button's behavior.
        /// </summary>
        /// <return>The new ButtonExtension instance.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ButtonExtension CreateExtension()
        {
            return null;
        }

        /// <summary>
        /// Dispose ButtonStyle and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                iconPadding?.Dispose();
                textPadding?.Dispose();
            }

            base.Dispose(type);
        }
    }
}
