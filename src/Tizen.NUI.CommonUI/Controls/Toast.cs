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

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// Use a toast to provide simple messages when the user does not need to make an additional action or confirmation.
    /// Unlike other popups, a toast only has the body field as it is just used for providing simple feedback to user actions.
    /// A toast will automatically disappear after a certain time.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Toast : Control
    {
        /// <summary>
        /// textLabels.
        /// </summary>
        protected TextLabel[] textLabels = null;
        private ToastAttributes toastAttributes = null;
        private string[] textArray = null;
        private NPatchVisual toastBackground = null;
        private Timer timer = null;

        private readonly int maxTextAreaWidth = 808;
        private readonly uint textLineHeight = 56;
        private readonly uint textLineSpace = 4;
        private readonly float textPointSize = 38;
        private readonly int textPaddingLeft = 96;
        private readonly int textPaddingRight = 96;
        private readonly int textPaddingTop = 38;
        private readonly int textPaddingBottom = 38;
        private readonly uint duration = 3000;

        /// <summary>
        /// Construct Toast with null.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast() : base()
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Toast class with specific Attributes.
        /// </summary>
        /// <param name="attributes">Construct Attributes</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(ToastAttributes attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// Constructor of the Toast class with special style.
        /// </summary>
        /// <param name="style"> style name </param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Gets or sets the text array of toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] TextArray
        {
            get
            {
                return textArray;
            }
            set
            {
                if (null != value)
                {
                    textArray = value;
                    SetToastText();
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Gets or sets text point size in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float PointSize
        {
            get
            {
                return toastAttributes.TextAttributes?.PointSize?.All ?? textPointSize;
            }
            set
            {
                CreateTextAttributes();
                if (null == toastAttributes.TextAttributes.PointSize)
                {
                    toastAttributes.TextAttributes.PointSize = new FloatSelector();
                }
                toastAttributes.TextAttributes.PointSize.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets text font family in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get
            {
                return toastAttributes.TextAttributes?.FontFamily;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.FontFamily = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets text color in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TextColor
        {
            get
            {
                return toastAttributes.TextAttributes?.TextColor?.All;
            }
            set
            {
                CreateTextAttributes();
                if (null == toastAttributes.TextAttributes.TextColor)
                {
                    toastAttributes.TextAttributes.TextColor = new ColorSelector();
                }
                toastAttributes.TextAttributes.TextColor.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets text horizontal alignment in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment TextAlignment
        {
            get
            {
                return toastAttributes.TextAttributes?.HorizontalAlignment ?? HorizontalAlignment.Center;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.HorizontalAlignment = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets background image resource of toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackgroundImageURL
        {
            get
            {
                return toastAttributes.BackgroundImageAttributes?.ResourceUrl?.All;
            }
            set
            {
                if (null != value)
                {
                    CreateBackgroundAttributes();
                    if (null == toastAttributes.BackgroundImageAttributes?.ResourceUrl)
                    {
                        toastAttributes.BackgroundImageAttributes.ResourceUrl = new StringSelector();
                    }

                    toastAttributes.BackgroundImageAttributes.ResourceUrl.All = value;
                    SetToastBackground();
                }
            }
        }

        /// <summary>
        /// Gets or sets background image's border of toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle BackgroundImageBorder
        {
            get
            {
                return toastAttributes.BackgroundImageAttributes?.Border?.All;
            }
            set
            {
                if (null != value)
                {
                    CreateBackgroundAttributes();
                    if (null == toastAttributes.BackgroundImageAttributes.Border)
                    {
                        toastAttributes.BackgroundImageAttributes.Border = new RectangleSelector();
                    }
                    toastAttributes.BackgroundImageAttributes.Border.All = value;
                    SetToastBackground();
                }
            }
        }

        /// <summary>
        /// Gets or sets text left padding in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingLeft
        {
            get
            {
                return toastAttributes.TextAttributes?.PaddingLeft ?? textPaddingLeft;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.PaddingLeft = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets text right padding in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingRight
        {
            get
            {
                return toastAttributes.TextAttributes?.PaddingRight ?? textPaddingRight;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.PaddingRight = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets text top padding in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingTop
        {
            get
            {
                return toastAttributes.TextAttributes?.PaddingTop ?? textPaddingTop;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.PaddingTop = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets text bottom padding in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingBottom
        {
            get
            {
                return toastAttributes.TextAttributes?.PaddingBottom ?? textPaddingBottom;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.PaddingBottom = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets text line height in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TextLineHeight
        {
            get
            {
                return toastAttributes.TextLineHeight ?? textLineHeight;
            }
            set
            {
                toastAttributes.TextLineHeight = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets text line space in toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TextLineSpace
        {
            get
            {
                return toastAttributes.TextLineSpace ?? textLineSpace;
            }
            set
            {
                toastAttributes.TextLineSpace = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets duration of toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Duration
        {
            get
            {
                return toastAttributes.Duration ?? duration;
            }
            set
            {
                toastAttributes.Duration = value;
                timer.Interval = value;
            }
        }

        /// <summary>
        /// Dispose ToastPopup.
        /// </summary>
        /// <param name="type">dispose types.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                if (null != textLabels)
                {
                    for (int i=0; i<textLabels.Length; i++)
                    {
                        Utility.Dispose(textLabels[i]);
                    }
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Relayout control's elements
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            if (null == toastAttributes)
            {
                return;
            }
            if (null != toastAttributes.TextAttributes)
            {
                for (int i = 0; i < textLabels.Length; i++)
                {
                    ApplyAttributes(textLabels[i], toastAttributes.TextAttributes);
                }
            }
            LayoutChild();
        }

        /// <summary>
        /// LayoutChild include textLabel.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void LayoutChild()
        {
            int _textPaddingLeft = toastAttributes.TextAttributes?.PaddingLeft ?? textPaddingLeft;
            int _textPaddingRight = toastAttributes.TextAttributes?.PaddingRight ?? _textPaddingLeft;
            int _textPaddingTop = toastAttributes.TextAttributes?.PaddingTop ?? textPaddingTop;
            int _textPaddingBottom = toastAttributes.TextAttributes?.PaddingBottom ?? _textPaddingTop;

            int _textAreaWidth = this.Size2D.Width - _textPaddingLeft - _textPaddingRight;
            int _textAreaHeight = this.Size2D.Height - _textPaddingTop - _textPaddingBottom;
            int _textLineSpace = (int)(toastAttributes.TextLineSpace ?? textLineSpace);
            int _textLineHeight = (int)(toastAttributes.TextLineHeight ?? textLineHeight);
            int _positionY = 0;

            _textAreaWidth = _textAreaWidth > maxTextAreaWidth ? maxTextAreaWidth : _textAreaWidth;
            if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                for (int i = 0; i < textLabels?.Length; i++)
                {
                    textLabels[i].Position2D = new Position2D(_textPaddingLeft, _textPaddingTop + _positionY);
                    textLabels[i].Size2D = new Size2D(_textAreaWidth, _textLineHeight);
                    _positionY += _textLineHeight + _textLineSpace;
                }
            }
            else
            {
                for (int i = 0; i < textLabels?.Length; i++)
                {
                    textLabels[i].ParentOrigin = Tizen.NUI.ParentOrigin.TopRight;
                    textLabels[i].PivotPoint = Tizen.NUI.PivotPoint.TopRight;
                    textLabels[i].PositionUsesPivotPoint = true;
                    textLabels[i].Position2D = new Position2D(-_textPaddingLeft, _textPaddingTop + _positionY);
                    textLabels[i].Size2D = new Size2D(_textAreaWidth, _textLineHeight);
                    _positionY += _textLineHeight + _textLineSpace;
                }
            }
        }

        /// <summary>
        /// Get Toast attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ToastAttributes();
        }

        private void Initialize()
        {
            toastAttributes = attributes as ToastAttributes;
            if (null == toastAttributes)
            {
                throw new Exception("Toast attribute parse error.");
            }
            ApplyAttributes(this, toastAttributes);

            toastBackground = new NPatchVisual();
            SetToastBackground();

            this.VisibilityChanged += OnVisibilityChanged;
            timer = new Timer(toastAttributes.Duration ?? duration);
            timer.Tick += OnTick;
            timer.Start();
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
                timer.Start();
            }
        }

        private void SetToastText()
        {
            for (int i = 0; i < textLabels?.Length; i++)
            {
                if (null != textLabels[i])
                {
                    this.Remove(textLabels[i]);
                    textLabels[i].Dispose();
                    textLabels[i] = null;
                }
            }

            textLabels = new TextLabel[textArray.Length];
            for (int i = 0; i < textArray.Length; i++)
            {
                textLabels[i] = new TextLabel();
                textLabels[i].Text = textArray[i];
                textLabels[i].BackgroundColor = Color.Blue;
                this.Add(textLabels[i]);
            }
        }

        private void SetToastBackground()
        {
            if (null != toastAttributes?.BackgroundImageAttributes?.ResourceUrl)
            {
                toastBackground.URL = toastAttributes.BackgroundImageAttributes.ResourceUrl.All;
            }
            if (null != toastAttributes?.BackgroundImageAttributes?.Border)
            {
                toastBackground.Border = toastAttributes.BackgroundImageAttributes.Border.All;
            }
            this.Background = toastBackground.OutputVisualMap;
        }

        private void CreateBackgroundAttributes()
        {
            if (null == toastAttributes.BackgroundImageAttributes)
            {
                toastAttributes.BackgroundImageAttributes = new ImageAttributes();
            }
        }

        private void CreateTextAttributes()
        {
            if (null == toastAttributes.TextAttributes)
            {
                toastAttributes.TextAttributes = new TextAttributes();
            }
        }
    }
}
