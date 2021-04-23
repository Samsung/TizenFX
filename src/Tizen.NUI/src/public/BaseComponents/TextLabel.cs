/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

extern alias TizenSystemSettings;
using TizenSystemSettings.Tizen.System;

using System;
using System.Globalization;
using System.ComponentModel;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A control which renders a short text string.<br />
    /// Text labels are lightweight, non-editable, and do not respond to the user input.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextLabel : View
    {
        private class TextLayout : LayoutItem
        {
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                // Padding will be automatically applied by DALi TextLabel.
                float totalWidth = widthMeasureSpec.Size.AsDecimal();
                float totalHeight = heightMeasureSpec.Size.AsDecimal();

                if (widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                {
                    if (heightMeasureSpec.Mode != MeasureSpecification.ModeType.Exactly)
                    {
                        totalHeight = Owner.GetHeightForWidth(totalWidth);
                        heightMeasureSpec = new MeasureSpecification(new LayoutLength(totalHeight), MeasureSpecification.ModeType.Exactly);
                    }
                }
                else
                {
                    var minSize = Owner.MinimumSize;
                    var maxSize = Owner.MaximumSize;
                    var naturalSize = Owner.GetNaturalSize();

                    if (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                    {
                        // GetWidthForHeight is not implemented.
                        totalWidth = Math.Min(Math.Max(naturalSize.Width, minSize.Width), (maxSize.Width < 0 ? Int32.MaxValue : maxSize.Width));
                        widthMeasureSpec = new MeasureSpecification(new LayoutLength(totalWidth), MeasureSpecification.ModeType.Exactly);
                    }
                    else
                    {
                        totalWidth = Math.Min(Math.Max(naturalSize.Width, minSize.Width), (maxSize.Width < 0 ? Int32.MaxValue : maxSize.Width));
                        totalHeight = Math.Min(Math.Max(naturalSize.Height, minSize.Height), (maxSize.Height < 0 ? Int32.MaxValue : maxSize.Height));

                        heightMeasureSpec = new MeasureSpecification(new LayoutLength(totalHeight), MeasureSpecification.ModeType.Exactly);
                        widthMeasureSpec = new MeasureSpecification(new LayoutLength(totalWidth), MeasureSpecification.ModeType.Exactly);
                    }
                }

                MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
                MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

                SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(totalWidth), widthMeasureSpec, childWidthState),
                                       ResolveSizeAndState(new LayoutLength(totalHeight), heightMeasureSpec, childHeightState));
            }
        }

        static TextLabel() { }

        private string textLabelSid = null;
        private bool systemlangTextFlag = false;
        private TextLabelSelectorData selectorData;
        private float fontSizeScale = 1.0f;
        private bool hasFontSizeChangedCallback = false;

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextLabel() : this(Interop.TextLabel.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel(TextLabelStyle viewStyle) : this(Interop.TextLabel.New(), true, viewStyle)
        {
        }

        /// <summary>
        /// Creates the TextLabel with setting the status of shown or hidden.
        /// </summary>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel(bool shown) : this(Interop.TextLabel.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        /// <param name="text">The text to display</param>
        /// <since_tizen> 3 </since_tizen>
        public TextLabel(string text) : this(Interop.TextLabel.New(text), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates the TextLabel with setting the status of shown or hidden.
        /// </summary>
        /// <param name="text">The text to display</param>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel(string text, bool shown) : this(Interop.TextLabel.New(text), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        internal TextLabel(TextLabel handle, bool shown = true) : this(Interop.TextLabel.NewTextLabel(TextLabel.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (!shown)
            {
                SetVisible(false);
            }
        }

        internal TextLabel(global::System.IntPtr cPtr, bool cMemoryOwn, ViewStyle viewStyle, bool shown = true) : base(cPtr, cMemoryOwn, viewStyle)
        {
            if (!shown)
            {
                SetVisible(false);
            }
        }

        internal TextLabel(global::System.IntPtr cPtr, bool cMemoryOwn, bool shown = true) : base(cPtr, cMemoryOwn, null)
        {
            if (!shown)
            {
                SetVisible(false);
            }
        }

        /// <summary>
        /// Create internal layout of TextLabel
        /// </summary>
        internal LayoutItem CreateTextLayout()
        {
            return new TextLayout();
        }

        /// <summary>
        /// The TranslatableText property.<br />
        /// The text can set the SID value.<br />
        /// </summary>
        /// <exception cref='ArgumentNullException'>
        /// ResourceManager about multilingual is null.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public string TranslatableText
        {
            get
            {
                return (string)GetValue(TranslatableTextProperty);
            }
            set
            {
                SetValue(TranslatableTextProperty, value);
            }
        }
        private string translatableText
        {
            get
            {
                return textLabelSid;
            }
            set
            {
                if (NUIApplication.MultilingualResourceManager == null)
                {
                    throw new ArgumentNullException(null, "ResourceManager about multilingual is null");
                }
                string translatableText = null;
                textLabelSid = value;
                translatableText = NUIApplication.MultilingualResourceManager?.GetString(textLabelSid, new CultureInfo(SystemSettings.LocaleLanguage.Replace("_", "-")));
                if (translatableText != null)
                {
                    Text = translatableText;
                    if (systemlangTextFlag == false)
                    {
                        SystemSettings.LocaleLanguageChanged += SystemSettings_LocaleLanguageChanged;
                        systemlangTextFlag = true;
                    }
                }
                else
                {
                    Text = "";
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Text property.<br />
        /// The text to display in the UTF-8 format.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The FontFamily property.<br />
        /// The requested font family to use.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The FontStyle property.<br />
        /// The requested font style to use.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap FontStyle
        {
            get
            {
                return (PropertyMap)GetValue(FontStyleProperty);
            }
            set
            {
                SetValue(FontStyleProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PointSize property.<br />
        /// The size of font in points.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PointSize
        {
            get
            {
                return (float)GetValue(PointSizeProperty);
            }
            set
            {
                SetValue(PointSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The MultiLine property.<br />
        /// The single-line or multi-line layout option.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool MultiLine
        {
            get
            {
                return (bool)GetValue(MultiLineProperty);
            }
            set
            {
                SetValue(MultiLineProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The HorizontalAlignment property.<br />
        /// The line horizontal alignment.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return (HorizontalAlignment)GetValue(HorizontalAlignmentProperty);
            }
            set
            {
                SetValue(HorizontalAlignmentProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The VerticalAlignment property.<br />
        /// The line vertical alignment.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VerticalAlignment VerticalAlignment
        {
            get
            {
                return (VerticalAlignment)GetValue(VerticalAlignmentProperty);
            }
            set
            {
                SetValue(VerticalAlignmentProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The TextColor property.<br />
        /// The color of the text.<br />
        /// Animation framework can be used to change the color of the text when not using mark up.<br />
        /// Cannot animate the color when text is auto scrolling.<br />
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textLabel.TextColor.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Color TextColor
        {
            get
            {
                Color temp = (Color)GetValue(TextColorProperty);
                return new Color(OnTextColorChanged, temp.R, temp.G, temp.B, temp.A);
            }
            set
            {
                SetValue(TextColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ShadowOffset property.<br />
        /// The drop shadow offset 0 indicates no shadow.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Shadow instead.
        /// The property cascade chaining set is possible. For example, this (textLabel.ShadowOffset.X = 0.1f;) is possible.
        /// </remarks>
        [Obsolete("Please do not use this ShadowOffset(Deprecated). Please use Shadow instead.")]
        public Vector2 ShadowOffset
        {
            get
            {
                Vector2 shadowOffset = new Vector2();
                Shadow.Find(TextLabel.Property.SHADOW, "offset")?.Get(shadowOffset);
                return new Vector2(OnShadowOffsetChanged, shadowOffset.X, shadowOffset.Y);
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Insert("offset", new PropertyValue(value));

                PropertyMap shadowMap = Shadow;
                shadowMap.Merge(temp);

                SetValue(ShadowProperty, shadowMap);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ShadowColor property.<br />
        /// The color of a drop shadow.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Shadow instead.
        /// The property cascade chaining set is possible. For example, this (textLabel.ShadowColor.X = 0.1f;) is possible.
        /// </remarks>
        [Obsolete("Please do not use this ShadowColor(Deprecated). Please use Shadow instead.")]
        public Vector4 ShadowColor
        {
            get
            {
                Vector4 shadowColor = new Vector4();
                Shadow.Find(TextLabel.Property.SHADOW, "color")?.Get(shadowColor);
                return new Vector4(OnShadowColorChanged, shadowColor.X, shadowColor.Y, shadowColor.Z, shadowColor.W);
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Insert("color", new PropertyValue(value));

                PropertyMap shadowMap = Shadow;
                shadowMap.Merge(temp);

                SetValue(ShadowProperty, shadowMap);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The UnderlineEnabled property.<br />
        /// The underline enabled flag.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Underline instead.
        /// </remarks>
        [Obsolete("Please do not use this UnderlineEnabled(Deprecated). Please use Underline instead.")]
        public bool UnderlineEnabled
        {
            get
            {
                bool underlineEnabled = false;
                Underline.Find(TextLabel.Property.UNDERLINE, "enable")?.Get(out underlineEnabled);
                return underlineEnabled;
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Add("enable", new PropertyValue(value));

                PropertyMap undelineMap = Underline;
                undelineMap.Merge(temp);

                SetValue(UnderlineProperty, undelineMap);
                NotifyPropertyChanged();

            }
        }

        /// <summary>
        /// The UnderlineColor property.<br />
        /// Overrides the underline height from font metrics.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Underline instead.
        /// The property cascade chaining set is possible. For example, this (textLabel.UnderlineColor.X = 0.1f;) is possible.
        /// </remarks>
        [Obsolete("Please do not use this UnderlineColor(Deprecated). Please use Underline instead.")]
        public Vector4 UnderlineColor
        {
            get
            {
                Vector4 underlineColor = new Vector4();
                Underline.Find(TextLabel.Property.UNDERLINE, "color")?.Get(underlineColor);
                return new Vector4(OnUnderlineColorChanged, underlineColor.X, underlineColor.Y, underlineColor.Z, underlineColor.W);
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Insert("color", new PropertyValue(value));

                PropertyMap undelineMap = Underline;
                undelineMap.Merge(temp);

                SetValue(UnderlineProperty, undelineMap);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The UnderlineHeight property.<br />
        /// Overrides the underline height from font metrics.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Underline instead.
        /// </remarks>
        [Obsolete("Please do not use this UnderlineHeight(Deprecated). Please use Underline instead.")]
        public float UnderlineHeight
        {
            get
            {
                float underlineHeight = 0.0f;
                Underline.Find(TextLabel.Property.UNDERLINE, "height")?.Get(out underlineHeight);
                return underlineHeight;
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Insert("height", new PropertyValue(value));

                PropertyMap undelineMap = Underline;
                undelineMap.Merge(temp);

                SetValue(UnderlineProperty, undelineMap);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The EnableMarkup property.<br />
        /// Whether the mark-up processing is enabled.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableMarkup
        {
            get
            {
                return (bool)GetValue(EnableMarkupProperty);
            }
            set
            {
                SetValue(EnableMarkupProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The EnableAutoScroll property.<br />
        /// Starts or stops auto scrolling.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableAutoScroll
        {
            get
            {
                return (bool)GetValue(EnableAutoScrollProperty);
            }
            set
            {
                SetValue(EnableAutoScrollProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollSpeed property.<br />
        /// Sets the speed of scrolling in pixels per second.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int AutoScrollSpeed
        {
            get
            {
                return (int)GetValue(AutoScrollSpeedProperty);
            }
            set
            {
                SetValue(AutoScrollSpeedProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollLoopCount property.<br />
        /// Number of complete loops when scrolling enabled.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int AutoScrollLoopCount
        {
            get
            {
                return (int)GetValue(AutoScrollLoopCountProperty);
            }
            set
            {
                SetValue(AutoScrollLoopCountProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollGap property.<br />
        /// Gap before scrolling wraps.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float AutoScrollGap
        {
            get
            {
                return (float)GetValue(AutoScrollGapProperty);
            }
            set
            {
                SetValue(AutoScrollGapProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The LineSpacing property.<br />
        /// The default extra space between lines in points.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float LineSpacing
        {
            get
            {
                return (float)GetValue(LineSpacingProperty);
            }
            set
            {
                SetValue(LineSpacingProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Underline property.<br />
        /// The default underline parameters.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Underline
        {
            get
            {
                return (PropertyMap)GetValue(UnderlineProperty);
            }
            set
            {
                SetValue(UnderlineProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Shadow property.<br />
        /// The default shadow parameters.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Shadow
        {
            get
            {
                return (PropertyMap)GetValue(ShadowProperty);
            }
            set
            {
                SetValue(ShadowProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Describes a text shadow for a TextLabel.
        /// It is null by default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextShadow TextShadow
        {
            get
            {
                return (TextShadow)GetValue(TextShadowProperty);
            }
            set
            {
                SetValue(TextShadowProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Emboss property.<br />
        /// The default emboss parameters.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Emboss
        {
            get
            {
                return (string)GetValue(EmbossProperty);
            }
            set
            {
                SetValue(EmbossProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Outline property.<br />
        /// The default outline parameters.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Outline
        {
            get
            {
                return (PropertyMap)GetValue(OutlineProperty);
            }
            set
            {
                SetValue(OutlineProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PixelSize property.<br />
        /// The size of font in pixels.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PixelSize
        {
            get
            {
                return (float)GetValue(PixelSizeProperty);
            }
            set
            {
                SetValue(PixelSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Ellipsis property.<br />
        /// Enable or disable the ellipsis.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Ellipsis
        {
            get
            {
                return (bool)GetValue(EllipsisProperty);
            }
            set
            {
                SetValue(EllipsisProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollLoopDelay property.<br />
        /// Do something.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float AutoScrollLoopDelay
        {
            get
            {
                return (float)GetValue(AutoScrollLoopDelayProperty);
            }
            set
            {
                SetValue(AutoScrollLoopDelayProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollStopMode property.<br />
        /// Do something.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AutoScrollStopMode AutoScrollStopMode
        {
            get
            {
                return (AutoScrollStopMode)GetValue(AutoScrollStopModeProperty);
            }
            set
            {
                SetValue(AutoScrollStopModeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The line count of the text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int LineCount
        {
            get
            {
                int temp = 0;
                GetProperty(TextLabel.Property.LineCount).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// The LineWrapMode property.<br />
        /// line wrap mode when the text lines over layout width.<br />
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public LineWrapMode LineWrapMode
        {
            get
            {
                return (LineWrapMode)GetValue(LineWrapModeProperty);
            }
            set
            {
                SetValue(LineWrapModeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The direction of the text such as left to right or right to left.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextDirection TextDirection
        {
            get
            {
                int temp = 0;
                GetProperty(TextLabel.Property.TextDirection).Get(out temp);
                return (TextDirection)temp;
            }
        }

        /// <summary>
        /// The vertical line alignment of the text.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalLineAlignment VerticalLineAlignment
        {
            get
            {
                return (VerticalLineAlignment)GetValue(VerticalLineAlignmentProperty);
            }
            set
            {
                SetValue(VerticalLineAlignmentProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The text alignment to match the direction of the system language.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool MatchSystemLanguageDirection
        {
            get
            {
                return (bool)GetValue(MatchSystemLanguageDirectionProperty);
            }
            set
            {
                SetValue(MatchSystemLanguageDirectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The text fit parameters.<br />
        /// The textFit map contains the following keys :<br />
        /// - enable (bool type) : True to enable the text fit or false to disable(the default value is false)<br />
        /// - minSize (float type) : Minimum Size for text fit(the default value is 10.f)<br />
        /// - maxSize (float type) : Maximum Size for text fit(the default value is 100.f)<br />
        /// - stepSize (float type) : Step Size for font increase(the default value is 1.f)<br />
        /// - fontSize (string type) : The size type of font, You can choose between "pointSize" or "pixelSize". (the default value is "pointSize")<br />
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap TextFit
        {
            get
            {
                return (PropertyMap)GetValue(TextFitProperty);
            }
            set
            {
                SetValue(TextFitProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The MinLineSize property.<br />
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MinLineSize
        {
            get
            {
                return (float)GetValue(MinLineSizeProperty);
            }
            set
            {
                SetValue(MinLineSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The FontSizeScale property. <br />
        /// The default value is 1.0. <br />
        /// If FontSizeScale.UseSystemSetting, will use the SystemSettings.FontSize internally. <br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float FontSizeScale
        {
            get
            {
                return fontSizeScale;
            }
            set
            {
                float newFontSizeScale;

                if (fontSizeScale == value) return;

                fontSizeScale = value;
                if (fontSizeScale == Tizen.NUI.FontSizeScale.UseSystemSetting)
                {
                    SystemSettingsFontSize systemSettingsFontSize;

                    try
                    {
                        systemSettingsFontSize = SystemSettings.FontSize;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} Exception caught.", e);
                        systemSettingsFontSize = SystemSettingsFontSize.Normal;
                    }
                    newFontSizeScale = TextUtils.GetFontSizeScale(systemSettingsFontSize);
                    addFontSizeChangedCallback();
                }
                else
                {
                    newFontSizeScale = fontSizeScale;
                    removeFontSizeChangedCallback();
                }

                SetValue(FontSizeScaleProperty, newFontSizeScale);
                NotifyPropertyChanged();
            }
        }

        private TextLabelSelectorData EnsureSelectorData() => selectorData ?? (selectorData = new TextLabelSelectorData());

        /// <summary>
        /// Downcasts a handle to textLabel handle
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"> Thrown when handle is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        /// Please do not use! this will be deprecated!
        /// Instead please use as keyword.
        [Obsolete("Please do not use! This will be deprecated! Please use as keyword instead! " +
            "Like: " +
            "BaseHandle handle = new TextLabel(\"Hello World!\"); " +
            "TextLabel label = handle as TextLabel")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TextLabel DownCast(BaseHandle handle)
        {
            if (null == handle)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            TextLabel ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as TextLabel;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (systemlangTextFlag)
            {
                SystemSettings.LocaleLanguageChanged -= SystemSettings_LocaleLanguageChanged;
            }

            removeFontSizeChangedCallback();

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                selectorData?.Reset(this);
            }

            base.Dispose(type);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TextLabel obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TextLabel.DeleteTextLabel(swigCPtr);
        }

        /// <summary>
        /// Get attribues, it is abstract function and must be override.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new TextLabelStyle();
        }

        /// <summary>
        /// Invoked whenever the binding context of the textlabel changes. Implement this method to add class handling for this event.
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

        private void SystemSettings_LocaleLanguageChanged(object sender, LocaleLanguageChangedEventArgs e)
        {
            Text = NUIApplication.MultilingualResourceManager?.GetString(textLabelSid, new CultureInfo(e.Value.Replace("_", "-")));
        }

        private void SystemSettingsFontSizeChanged(object sender, FontSizeChangedEventArgs e)
        {
            float newFontSizeScale = TextUtils.GetFontSizeScale(e.Value);
            SetValue(FontSizeScaleProperty, newFontSizeScale);
        }

        private void addFontSizeChangedCallback()
        {
            if (hasFontSizeChangedCallback != true)
            {
                try
                {
                    SystemSettings.FontSizeChanged += SystemSettingsFontSizeChanged;
                    hasFontSizeChangedCallback = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasFontSizeChangedCallback = false;
                }
            }
        }

        private void removeFontSizeChangedCallback()
        {
            if (hasFontSizeChangedCallback == true)
            {
                try
                {
                    SystemSettings.FontSizeChanged -= SystemSettingsFontSizeChanged;
                    hasFontSizeChangedCallback = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasFontSizeChangedCallback = true;
                }
            }
        }

        private void RequestLayout()
        {
            Layout?.RequestLayout();
        }

        internal new class Property
        {
            internal static readonly int TEXT = Interop.TextLabel.TextGet();
            internal static readonly int FontFamily = Interop.TextLabel.FontFamilyGet();
            internal static readonly int FontStyle = Interop.TextLabel.FontStyleGet();
            internal static readonly int PointSize = Interop.TextLabel.PointSizeGet();
            internal static readonly int MultiLine = Interop.TextLabel.MultiLineGet();
            internal static readonly int HorizontalAlignment = Interop.TextLabel.HorizontalAlignmentGet();
            internal static readonly int VerticalAlignment = Interop.TextLabel.VerticalAlignmentGet();
            internal static readonly int TextColor = Interop.TextLabel.TextColorGet();
            internal static readonly int EnableMarkup = Interop.TextLabel.EnableMarkupGet();
            internal static readonly int EnableAutoScroll = Interop.TextLabel.EnableAutoScrollGet();
            internal static readonly int AutoScrollSpeed = Interop.TextLabel.AutoScrollSpeedGet();
            internal static readonly int AutoScrollLoopCount = Interop.TextLabel.AutoScrollLoopCountGet();
            internal static readonly int AutoScrollGap = Interop.TextLabel.AutoScrollGapGet();
            internal static readonly int LineSpacing = Interop.TextLabel.LineSpacingGet();
            internal static readonly int UNDERLINE = Interop.TextLabel.UnderlineGet();
            internal static readonly int SHADOW = Interop.TextLabel.ShadowGet();
            internal static readonly int EMBOSS = Interop.TextLabel.EmbossGet();
            internal static readonly int OUTLINE = Interop.TextLabel.OutlineGet();
            internal static readonly int PixelSize = Interop.TextLabel.PixelSizeGet();
            internal static readonly int ELLIPSIS = Interop.TextLabel.EllipsisGet();
            internal static readonly int AutoScrollStopMode = Interop.TextLabel.AutoScrollStopModeGet();
            internal static readonly int AutoScrollLoopDelay = Interop.TextLabel.AutoScrollLoopDelayGet();
            internal static readonly int LineCount = Interop.TextLabel.LineCountGet();
            internal static readonly int LineWrapMode = Interop.TextLabel.LineWrapModeGet();
            internal static readonly int TextDirection = Interop.TextLabel.TextDirectionGet();
            internal static readonly int VerticalLineAlignment = Interop.TextLabel.VerticalLineAlignmentGet();
            internal static readonly int MatchSystemLanguageDirection = Interop.TextLabel.MatchSystemLanguageDirectionGet();
            internal static readonly int TextFit = Interop.TextLabel.TextFitGet();
            internal static readonly int MinLineSize = Interop.TextLabel.MinLineSizeGet();
            internal static readonly int FontSizeScale = Interop.TextLabel.FontSizeScaleGet();
        }

        private void OnShadowColorChanged(float x, float y, float z, float w)
        {
            ShadowColor = new Vector4(x, y, z, w);
        }
        private void OnShadowOffsetChanged(float x, float y)
        {
            ShadowOffset = new Vector2(x, y);
        }
        private void OnTextColorChanged(float r, float g, float b, float a)
        {
            TextColor = new Color(r, g, b, a);
        }
        private void OnUnderlineColorChanged(float x, float y, float z, float w)
        {
            UnderlineColor = new Vector4(x, y, z, w);
        }
    }
}
