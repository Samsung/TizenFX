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
using System;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;
using Tizen.NUI.Binding;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Use a toast to provide simple messages when the user does not need to make an additional action or confirmation.
    /// Unlike other popups, a toast only has the body field as it is just used for providing simple feedback to user actions.
    /// A toast will automatically disappear after a certain time.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [Obsolete("Deprecated in API8; Will be removed in API10")]
    public partial class Toast : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Toast FromText(string text, uint duration)
        {
            Toast toast = new Toast();
            toast.Message = text;
            toast.Duration = duration;
            return toast;
        }

        private Window window = null;
        /// <summary> text labels </summary>
        protected TextLabel[] textLabels = null;
        private TextLabel textLabel = null;
        private string strText = null;
        private Timer timer = null;
        private readonly uint duration = 3000;

        static Toast()
        {
            if (NUIApplication.IsUsingXaml)
            {
                MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(Toast), string.Empty,
                    propertyChanged: SetInternalMessageProperty, defaultValueCreator: GetInternalMessageProperty);
                DurationProperty = BindableProperty.Create(nameof(Duration), typeof(uint), typeof(Toast), default(uint),
                    propertyChanged: SetInternalDurationProperty, defaultValueCreator: GetInternalDurationProperty);
                TextArrayProperty = BindableProperty.Create(nameof(TextArray), typeof(string[]), typeof(Toast), null,
                    propertyChanged: SetInternalTextArrayProperty, defaultValueCreator: GetInternalTextArrayProperty);
                PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(Toast), default(float),
                    propertyChanged: SetInternalPointSizeProperty, defaultValueCreator: GetInternalPointSizeProperty);
                FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(Toast), default(string),
                    propertyChanged: SetInternalFontFamilyProperty, defaultValueCreator: GetInternalFontFamilyProperty);
                TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Toast), null,
                    propertyChanged: SetInternalTextColorProperty, defaultValueCreator: GetInternalTextColorProperty);
                TextAlignmentProperty = BindableProperty.Create(nameof(TextAlignment), typeof(HorizontalAlignment), typeof(Toast), default(HorizontalAlignment),
                    propertyChanged: SetInternalTextAlignmentProperty, defaultValueCreator: GetInternalTextAlignmentProperty);
                TextPaddingProperty = BindableProperty.Create(nameof(TextPadding), typeof(Extents), typeof(Toast), null,
                    propertyChanged: SetInternalTextPaddingProperty, defaultValueCreator: GetInternalTextPaddingProperty);
                TextLineHeightProperty = BindableProperty.Create(nameof(TextLineHeight), typeof(uint), typeof(Toast), default(uint),
                    propertyChanged: SetInternalTextLineHeightProperty, defaultValueCreator: GetInternalTextLineHeightProperty);
                TextLineSpaceProperty = BindableProperty.Create(nameof(TextLineSpace), typeof(uint), typeof(Toast), default(uint),
                    propertyChanged: SetInternalTextLineSpaceProperty, defaultValueCreator: GetInternalTextLineSpaceProperty);
            }
        }

        /// <summary>
        /// Construct Toast with null.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Toast() : base()
        {
        }

        /// <summary>
        /// The constructor of the Toast class with specific Style.
        /// </summary>
        /// <param name="toastStyle">Construct Style</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(ToastStyle toastStyle) : base(toastStyle)
        {
        }

        /// <summary>
        /// Constructor of the Toast class with special style.
        /// </summary>
        /// <param name="style"> style name </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(string style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets the text array of toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// It will be removed in API10
        [SuppressMessage("Microsoft.Performance", "CA1819: Properties should not return arrays")]
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public string[] TextArray
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TextArrayProperty) as string[];
                }
                else
                {
                    return InternalTextArray;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextArrayProperty, value);
                }
                else
                {
                    InternalTextArray = value;
                }
                NotifyPropertyChanged();
            }
        }
        private string[] InternalTextArray
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets text point size in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public float PointSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(PointSizeProperty);
                }
                else
                {
                    return InternalPointSize;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PointSizeProperty, value);
                }
                else
                {
                    InternalPointSize = value;
                }
                NotifyPropertyChanged();
            }
        }
        private float InternalPointSize
        {
            get
            {
                return (float)textLabel?.PointSize;
            }
            set
            {
                if (null != textLabel)
                {
                    textLabel.PointSize = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets text font family in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public string FontFamily
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(FontFamilyProperty) as string;
                }
                else
                {
                    return InternalFontFamily;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontFamilyProperty, value);
                }
                else
                {
                    InternalFontFamily = value;
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalFontFamily
        {
            get
            {
                return textLabel?.FontFamily;
            }
            set
            {
                if (null != textLabel)
                {
                    textLabel.FontFamily = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets text color in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Color TextColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TextColorProperty) as Color;
                }
                else
                {
                    return InternalTextColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextColorProperty, value);
                }
                else
                {
                    InternalTextColor = value;
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalTextColor
        {
            get
            {
                return textLabel?.TextColor;
            }
            set
            {
                if (null != textLabel)
                {
                    textLabel.TextColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets text horizontal alignment in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public HorizontalAlignment TextAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignment)GetValue(TextAlignmentProperty);
                }
                else
                {
                    return InternalTextAlignment;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextAlignmentProperty, value);
                }
                else
                {
                    InternalTextAlignment = value;
                }
                NotifyPropertyChanged();
            }
        }
        private HorizontalAlignment InternalTextAlignment
        {
            get
            {
                return textLabel?.HorizontalAlignment ?? HorizontalAlignment.Center;
            }
            set
            {
                if (null != textLabel)
                {
                    textLabel.HorizontalAlignment = value;
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Post(Window win)
        {
            window = win;
            window.Add(this);
            this.PositionX = (window.Size.Width - this.Size.Width) / 2;
            this.PositionY = (window.Size.Height - this.Size.Height) / 2;
            timer.Start();
        }

        /// <summary>
        /// Gets or sets the text toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Message
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(MessageProperty);
                }
                else
                {
                    return GetInternalMessage();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MessageProperty, value);
                }
                else
                {
                    SetInternalMessage(value);
                }
            }
        }

        private void SetInternalMessage(string newValue)
        {
            if (newValue != null)
            {
                strText = newValue;
                if (null != textLabel)
                {
                    textLabel.Text = strText;
                }
            }
        }

        private string GetInternalMessage()
        {
            return strText;
        }

        /// <summary>
        /// Gets or sets text padding in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Extents TextPadding
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TextPaddingProperty) as Extents;
                }
                else
                {
                    return InternalTextPadding;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextPaddingProperty, value);
                }
                else
                {
                    InternalTextPadding = value;
                }
                NotifyPropertyChanged();
            }
        }
        private Extents InternalTextPadding
        {
            get
            {
                return textLabel?.Padding;
            }
            set
            {
                if (null != value && null != textLabel)
                {
                    textLabel.Padding.CopyFrom(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets text line height in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public uint TextLineHeight
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (UInt32)GetValue(TextLineHeightProperty);
                }
                else
                {
                    return InternalTextLineHeight;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextLineHeightProperty, value);
                }
                else
                {
                    InternalTextLineHeight = value;
                }
                NotifyPropertyChanged();
            }
        }
        private uint InternalTextLineHeight { get; set; }

        /// <summary>
        /// Gets or sets text line space in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public uint TextLineSpace
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (uint)GetValue(TextLineSpaceProperty);
                }
                else
                {
                    return InternalTextLineSpace;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextLineSpaceProperty, value);
                }
                else
                {
                    InternalTextLineSpace = value;
                }
                NotifyPropertyChanged();
            }
        }
        private uint InternalTextLineSpace { get; set; }

        /// <summary>
        /// Gets or sets duration of toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public uint Duration
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (uint)GetValue(DurationProperty);
                }
                else
                {
                    return GetInternalDuration();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DurationProperty, value);
                }
                else
                {
                    SetInternalDuration(value);
                }
            }
        }

        private void SetInternalDuration(uint newValue)
        {
            if (timer == null)
            {
                timer = new Timer(duration);
            }
            timer.Interval = newValue;
        }

        private uint GetInternalDuration()
        {
            return timer == null ? duration : timer.Interval;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            WidthResizePolicy = ResizePolicyType.FitToChildren;
            HeightResizePolicy = ResizePolicyType.FitToChildren;

            textLabel = new TextLabel()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextColor = Color.White,
            };
            this.Add(textLabel);

            this.VisibilityChanged += OnVisibilityChanged;
            timer = new Timer(duration);
            timer.Tick += OnTick;
        }

        /// <summary>
        /// Apply style to toast.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            if (viewStyle is ToastStyle toastStyle)
            {
                textLabel.ApplyStyle(toastStyle.Text);
            }
        }

        /// <summary>
        /// Dispose ToastPopup.
        /// </summary>
        /// <param name="type">dispose types.</param>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
        protected override void Dispose(DisposeTypes type)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                this.VisibilityChanged -= OnVisibilityChanged;
                if (null != timer)
                {
                    timer.Tick -= OnTick;
                    timer.Dispose();
                    timer = null;
                }

                if (null != textLabel)
                {
                    Utility.Dispose(textLabel);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Get Toast style.
        /// </summary>
        /// <returns>The default toast style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new ToastStyle();
        }

        private bool OnTick(object sender, EventArgs e)
        {
            Hide();
            return false;
        }

        private void OnVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (true == e.Visibility)
            {
                window?.Add(this);
                timer.Start();
            }
            else
            {
                window?.Remove(this);
            }
        }
    }
}
