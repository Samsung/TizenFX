﻿/*
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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Use a toast to provide simple messages when the user does not need to make an additional action or confirmation.
    /// Unlike other popups, a toast only has the body field as it is just used for providing simple feedback to user actions.
    /// A toast will automatically disappear after a certain time.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [Obsolete("Deprecated in API8; Will be removed in API10")]
    public class Toast : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(Toast), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.strText = (string)(newValue);
                if (null != instance.textLabel)
                {
                    instance.textLabel.Text = instance.strText;
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Toast)bindable;
            return instance.strText;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DurationProperty = BindableProperty.Create(nameof(Duration), typeof(uint), typeof(Toast), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.toastStyle.Duration = (uint)newValue;
                if (instance.timer == null)
                {
                    instance.timer = new Timer(instance.duration);
                }
                instance.timer.Interval = (uint)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Toast)bindable;
            return instance.toastStyle.Duration ?? instance.duration;
        });

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
        private ToastStyle toastStyle => ViewStyle as ToastStyle;

        /// <summary>
        /// Return a copied Style instance of Toast
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the Toast.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ToastStyle Style
        {
            get
            {
                var result = new ToastStyle(toastStyle);
                result.CopyPropertiesFromView(this);
                result.Text.CopyPropertiesFromView(textLabel);
                return result;
            }
        }
        static Toast() { }

        /// <summary>
        /// Construct Toast with null.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Toast() : base()
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Toast class with specific Style.
        /// </summary>
        /// <param name="toastStyle">Construct Style</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(ToastStyle toastStyle) : base(toastStyle)
        {
            Initialize();
        }

        /// <summary>
        /// Constructor of the Toast class with special style.
        /// </summary>
        /// <param name="style"> style name </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Gets or sets the text array of toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public string[] TextArray
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
            this.Position.X = (window.Size.Width - this.Size.Width) / 2;
            this.Position.Y = (window.Size.Height - this.Size.Height) / 2;
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
                return (string)GetValue(MessageProperty);
            }
            set
            {
                SetValue(MessageProperty, value);
            }
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
        public uint TextLineHeight { get; set; }

        /// <summary>
        /// Gets or sets text line space in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public uint TextLineSpace { get; set; }

        /// <summary>
        /// Gets or sets duration of toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public uint Duration
        {
            get
            {
                return (uint)GetValue(DurationProperty);
            }
            set
            {
                SetValue(DurationProperty, value);
            }
        }

        /// <summary>
        /// Apply style to toast.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            ToastStyle toastStyle = viewStyle as ToastStyle;

            if (null != toastStyle)
            {
                if (null == textLabel)
                {
                    textLabel = new TextLabel();
                    this.Add(textLabel);
                }
                textLabel.ApplyStyle(toastStyle.Text);
            }
        }

        /// <summary>
        /// Dispose ToastPopup.
        /// </summary>
        /// <param name="type">dispose types.</param>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        protected override void Dispose(DisposeTypes type)
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

        private void Initialize()
        {
            if (null == textLabel)
            {
                textLabel = new TextLabel();
                this.Add(textLabel);
            }

            this.VisibilityChanged += OnVisibilityChanged;
            timer = new Timer(toastStyle.Duration ?? duration);
            timer.Tick += OnTick;
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
