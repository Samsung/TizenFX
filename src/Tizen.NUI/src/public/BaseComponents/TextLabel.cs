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
using Tizen.NUI.Text;
using Tizen.NUI.Binding;

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
                        float width = naturalSize != null ? naturalSize.Width : 0;
                        totalWidth = Math.Min(Math.Max(width, minSize.Width), (maxSize.Width < 0 ? Int32.MaxValue : maxSize.Width));
                        widthMeasureSpec = new MeasureSpecification(new LayoutLength(totalWidth), MeasureSpecification.ModeType.Exactly);
                    }
                    else
                    {
                        float width = naturalSize != null ? naturalSize.Width : 0;
                        float height = naturalSize != null ? naturalSize.Height : 0;
                        totalWidth = Math.Min(Math.Max(width, minSize.Width), (maxSize.Width < 0 ? Int32.MaxValue : maxSize.Width));
                        totalHeight = Math.Min(Math.Max(height, minSize.Height), (maxSize.Height < 0 ? Int32.MaxValue : maxSize.Height));

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

        private static SystemFontTypeChanged systemFontTypeChanged = new SystemFontTypeChanged();
        private static SystemLocaleLanguageChanged systemLocaleLanguageChanged = new SystemLocaleLanguageChanged();
        static private string defaultStyleName = "Tizen.NUI.BaseComponents.TextLabel";
        static private string defaultFontFamily = "BreezeSans";
        private string textLabelSid = null;
        private TextLabelSelectorData selectorData;
        private string fontFamily = defaultFontFamily;
        private float fontSizeScale = 1.0f;
        private bool hasSystemLanguageChanged = false;
        private bool hasSystemFontSizeChanged = false;
        private bool hasSystemFontTypeChanged = false;

        private Color internalTextColor;

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextLabel() : this(Interop.TextLabel.New(ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel(TextLabelStyle viewStyle) : this(Interop.TextLabel.New(ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true, viewStyle)
        {
        }

        /// <summary>
        /// Creates the TextLabel with setting the status of shown or hidden.
        /// </summary>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel(bool shown) : this(Interop.TextLabel.New(ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        /// <param name="text">The text to display</param>
        /// <since_tizen> 3 </since_tizen>
        public TextLabel(string text) : this(Interop.TextLabel.New(text, ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true)
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
        public TextLabel(string text, bool shown) : this(Interop.TextLabel.New(text, ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true)
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

        private bool HasStyle()
        {
            return ThemeManager.GetStyle(this.GetType()) == null ? false : true;
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
                    if (hasSystemLanguageChanged == false)
                    {
                        systemLocaleLanguageChanged.Add(SystemSettingsLocaleLanguageChanged);
                        hasSystemLanguageChanged = true;
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

        private string InternalFontFamily
        {
            get
            {
                if (HasStyle())
                    return fontFamily;
                else
                    return Object.InternalGetPropertyString(this.SwigCPtr, TextLabel.Property.FontFamily);
            }
            set
            {
                string newFontFamily;

                if (string.Equals(fontFamily, value)) return;

                fontFamily = value;
                if (fontFamily == Tizen.NUI.FontFamily.UseSystemSetting)
                {
                    try
                    {
                        newFontFamily = SystemSettings.FontType;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} Exception caught.", e);
                        newFontFamily = defaultFontFamily;
                    }
                    AddSystemSettingsFontTypeChanged();
                }
                else
                {
                    newFontFamily = fontFamily;
                    RemoveSystemSettingsFontTypeChanged();
                }

                SetInternalFontFamily(newFontFamily);
            }
        }

        private void SetInternalFontFamily(string fontFamily)
        {
            Object.InternalSetPropertyString(this.SwigCPtr, TextLabel.Property.FontFamily, (string)fontFamily);
            RequestLayout();
        }

        /// <summary>
        /// The FontStyle property.<br />
        /// The requested font style to use.<br />
        /// The fontStyle map contains the following keys :<br />
        /// <list type="table">
        /// <item><term>width (string)</term><description>The width key defines occupied by each glyph. (values: ultraCondensed, extraCondensed, condensed, semiCondensed, normal, semiExpanded, expanded, extraExpanded, ultraExpanded)</description></item>
        /// <item><term>weight (string)</term><description>The weight key defines the thickness or darkness of the glyphs. (values: thin, ultraLight, extraLight, light, demiLight, semiLight, book, normal, regular, medium, demiBold, semiBold, bold, ultraBold, extraBold, black, heavy, extraBlack)</description></item>
        /// <item><term>slant (string)</term><description>The slant key defines whether to use italics. (values: normal, roman, italic, oblique)</description></item>
        /// </list>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
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
        /// Set FontStyle to TextLabel. <br />
        /// </summary>
        /// <param name="fontStyle">The FontStyle</param>
        /// <remarks>
        /// SetFontStyle specifies the requested font style through <see cref="Tizen.NUI.Text.FontStyle"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetFontStyle method.
        /// <code>
        /// var fontStyle = new Tizen.NUI.Text.FontStyle();
        /// fontStyle.Width = FontWidthType.Expanded;
        /// fontStyle.Weight = FontWeightType.Bold;
        /// fontStyle.Slant = FontSlantType.Italic;
        /// label.SetFontStyle(fontStyle);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFontStyle(FontStyle fontStyle)
        {
            using (var fontStyleMap = TextMapHelper.GetFontStyleMap(fontStyle))
            {
                SetValue(FontStyleProperty, fontStyleMap);
            }
        }

        /// <summary>
        /// Get FontStyle from TextLabel. <br />
        /// </summary>
        /// <returns>The FontStyle</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.FontStyle"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontStyle GetFontStyle()
        {
            FontStyle fontStyle;
            using (var fontStyleMap = (PropertyMap)GetValue(FontStyleProperty))
            {
                fontStyle = TextMapHelper.GetFontStyleStruct(fontStyleMap);
            }
            return fontStyle;
        }

        /// <summary>
        /// The PointSize property.<br />
        /// The size of font in points.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Binding.TypeConverter(typeof(PointSizeTypeConverter))]
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
        [Obsolete("Do not use this ShadowOffset(Deprecated). Use Shadow instead.")]
        public Vector2 ShadowOffset
        {
            get
            {
                return GetValue(ShadowOffsetProperty) as Vector2;
            }
            set
            {
                SetValue(ShadowOffsetProperty, value);
            }
        }

        private Vector2 InternalShadowOffset
        {
            get
            {
                float x = 0.0f, y = 0.0f;
                using (var propertyValue = Shadow.Find(TextLabel.Property.SHADOW, "offset"))
                using (var shadowOffset = new Vector2())
                {
                    if (null != propertyValue)
                    {
                        propertyValue.Get(shadowOffset);
                        x = shadowOffset.X;
                        y = shadowOffset.Y;
                    }
                }
                return new Vector2(OnShadowOffsetChanged, x, y);
            }
            set
            {
                using (var map = new PropertyMap())
                {
                    map.Add("offset", value);

                    var shadowMap = Shadow;
                    shadowMap.Merge(map);

                    SetValue(ShadowProperty, shadowMap);
                    NotifyPropertyChanged();
                }
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
        [Obsolete("Do not use this ShadowColor(Deprecated). Use Shadow instead.")]
        public Vector4 ShadowColor
        {
            get
            {
                return GetValue(ShadowColorProperty) as Vector4;
            }
            set
            {
                SetValue(ShadowColorProperty, value);
            }
        }

        private Vector4 InternalShadowColor
        {
            get
            {
                float x = 0.0f, y = 0.0f, z = 0.0f, w = 0.0f;
                using (var propertyValue = Shadow.Find(TextLabel.Property.SHADOW, "color"))
                using (var shadowColor = new Vector4())
                {
                    if (null != propertyValue)
                    {
                        propertyValue.Get(shadowColor);
                        x = shadowColor.X;
                        y = shadowColor.Y;
                        z = shadowColor.Z;
                        w = shadowColor.W;
                    }
                }
                return new Vector4(OnShadowColorChanged, x, y, z, w);
            }
            set
            {
                using (var map = new PropertyMap())
                {
                    map.Add("color", value);
                    var shadowMap = Shadow;
                    shadowMap.Merge(map);
                    SetValue(ShadowProperty, shadowMap);
                    NotifyPropertyChanged();
                }
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
        [Obsolete("Do not use this UnderlineEnabled(Deprecated). Use Underline instead.")]
        public bool UnderlineEnabled
        {
            get
            {
                return (bool)GetValue(UnderlineEnabledProperty);
            }
            set
            {
                SetValue(UnderlineEnabledProperty, value);
            }
        }

        private bool InternalUnderlineEnabled
        {
            get
            {
                bool underlineEnabled = false;
                using (var propertyValue = Underline.Find(TextLabel.Property.UNDERLINE, "enable"))
                {
                    if (propertyValue != null)
                    {
                        propertyValue.Get(out underlineEnabled);
                    }
                }
                return underlineEnabled;
            }
            set
            {
                using (var map = new PropertyMap())
                {
                    map.Add("enable", value);
                    var undelineMap = Underline;
                    undelineMap.Merge(map);
                    SetValue(UnderlineProperty, undelineMap);
                    NotifyPropertyChanged();
                }
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
        [Obsolete("Do not use this UnderlineColor(Deprecated). Use Underline instead.")]
        public Vector4 UnderlineColor
        {
            get
            {
                return GetValue(UnderlineColorProperty) as Vector4;
            }
            set
            {
                SetValue(UnderlineColorProperty, value);
            }
        }

        private Vector4 InternalUnderlineColor
        {
            get
            {
                float x = 0.0f, y = 0.0f, z = 0.0f, w = 0.0f;
                using (var propertyValue = Underline.Find(TextLabel.Property.UNDERLINE, "color"))
                using (var underlineColor = new Vector4())
                {
                    if (null != propertyValue)
                    {
                        propertyValue.Get(underlineColor);
                        x = underlineColor.X;
                        y = underlineColor.Y;
                        z = underlineColor.Z;
                        w = underlineColor.W;
                    }
                }
                return new Vector4(OnUnderlineColorChanged, x, y, z, w);
            }
            set
            {
                using (var map = new PropertyMap())
                {
                    map.Add("color", value);
                    var undelineMap = Underline;
                    undelineMap.Merge(map);
                    SetValue(UnderlineProperty, undelineMap);
                    NotifyPropertyChanged();
                }
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
        [Obsolete("Do not use this UnderlineHeight(Deprecated). Use Underline instead.")]
        public float UnderlineHeight
        {
            get
            {
                return (float)GetValue(UnderlineHeightProperty);
            }
            set
            {
                SetValue(UnderlineHeightProperty, value);
            }
        }

        private float InternalUnderlineHeight
        {
            get
            {
                float underlineHeight = 0.0f;
                using (var propertyValue = Underline.Find(TextLabel.Property.UNDERLINE, "height"))
                {
                    if (null != propertyValue)
                    {
                        propertyValue.Get(out underlineHeight);
                    }
                }
                return underlineHeight;
            }
            set
            {
                using (var map = new PropertyMap())
                {
                    map.Add("height", value);
                    var undelineMap = Underline;
                    undelineMap.Merge(map);
                    SetValue(UnderlineProperty, undelineMap);
                    NotifyPropertyChanged();
                }
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
        /// The relative height of the line (a factor that will be multiplied by text height). <br />
        /// If the value is less than 1, the lines could to be overlapped.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float RelativeLineHeight
        {
            get
            {
                return (float)GetValue(RelativeLineHeightProperty);
            }
            set
            {
                SetValue(RelativeLineHeightProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Underline property.<br />
        /// The default underline parameters.<br />
        /// The underline map contains the following keys :<br />
        /// <list type="table">
        /// <item><term>enable (bool)</term><description>Whether the underline is enabled (the default value is false)</description></item>
        /// <item><term>color (Color)</term><description>The color of the underline (If not provided then the color of the text is used)</description></item>
        /// <item><term>height (float)</term><description>The height in pixels of the underline (the default value is 1.f)</description></item>
        /// </list>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
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
        /// Set Underline to TextLabel. <br />
        /// </summary>
        /// <param name="underline">The Underline</param>
        /// <remarks>
        /// SetUnderline specifies the underline of the text through <see cref="Tizen.NUI.Text.Underline"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetUnderline method.
        /// <code>
        /// var underline = new Tizen.NUI.Text.Underline();
        /// underline.Enable = true;
        /// underline.Color = new Color("#3498DB");
        /// underline.Height = 2.0f;
        /// label.SetUnderline(underline);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetUnderline(Underline underline)
        {
            using (var underlineMap = TextMapHelper.GetUnderlineMap(underline))
            {
                SetValue(UnderlineProperty, underlineMap);
            }
        }

        /// <summary>
        /// Get Underline from TextLabel. <br />
        /// </summary>
        /// <returns>The Underline</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.Underline"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Underline GetUnderline()
        {
            Underline underline;
            using (var underlineMap = (PropertyMap)GetValue(UnderlineProperty))
            {
                underline = TextMapHelper.GetUnderlineStruct(underlineMap);
            }
            return underline;
        }

        /// <summary>
        /// The Shadow property.<br />
        /// The default shadow parameters.<br />
        /// The shadow map contains the following keys :<br />
        /// <list type="table">
        /// <item><term>color (Color)</term><description>The color of the shadow (the default color is Color.Black)</description></item>
        /// <item><term>offset (Vector2)</term><description>The offset in pixels of the shadow (If not provided then the shadow is not enabled)</description></item>
        /// <item><term>blurRadius (float)</term><description>The radius of the Gaussian blur for the soft shadow (If not provided then the soft shadow is not enabled)</description></item>
        /// </list>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
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
        /// Set Shadow to TextLabel. <br />
        /// </summary>
        /// <param name="shadow">The Shadow</param>
        /// <remarks>
        /// SetShadow specifies the shadow of the text through <see cref="Tizen.NUI.Text.Shadow"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetShadow method.
        /// <code>
        /// var shadow = new Tizen.NUI.Text.Shadow();
        /// shadow.Offset = new Vector2(3, 3);
        /// shadow.Color = new Color("#F1C40F");
        /// shadow.BlurRadius = 4.0f;
        /// label.SetShadow(shadow);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetShadow(Tizen.NUI.Text.Shadow shadow)
        {
            using (var shadowMap = TextMapHelper.GetShadowMap(shadow))
            {
                SetValue(ShadowProperty, shadowMap);
            }
        }

        /// <summary>
        /// Get Shadow from TextLabel. <br />
        /// </summary>
        /// <returns>The Shadow</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.Shadow"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.Text.Shadow GetShadow()
        {
            Tizen.NUI.Text.Shadow shadow;
            using (var shadowMap = (PropertyMap)GetValue(ShadowProperty))
            {
                shadow = TextMapHelper.GetShadowStruct(shadowMap);
            }
            return shadow;
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
        /// The outline map contains the following keys :<br />
        /// <list type="table">
        /// <item><term>color (Color)</term><description>The color of the outline (the default color is Color.White)</description></item>
        /// <item><term>width (float)</term><description>The width in pixels of the outline (If not provided then the outline is not enabled)</description></item>
        /// </list>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
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
        /// Set Outline to TextLabel. <br />
        /// </summary>
        /// <param name="outline">The Outline</param>
        /// <remarks>
        /// SetOutline specifies the outline of the text through <see cref="Tizen.NUI.Text.Outline"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetOutline method.
        /// <code>
        /// var outline = new Tizen.NUI.Text.Outline();
        /// outline.Width = 2.0f;
        /// outline.Color = new Color("#45B39D");
        /// label.SetOutline(outline);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetOutline(Outline outline)
        {
            using (var outlineMap = TextMapHelper.GetOutlineMap(outline))
            {
                SetValue(OutlineProperty, outlineMap);
            }
        }

        /// <summary>
        /// Get Outline from TextLabel. <br />
        /// </summary>
        /// <returns>The Outline</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.Outline"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Outline GetOutline()
        {
            Outline outline;
            using (var outlineMap = (PropertyMap)GetValue(OutlineProperty))
            {
                outline = TextMapHelper.GetOutlineStruct(outlineMap);
            }
            return outline;
        }

        /// <summary>
        /// Set Strikethrough to TextLabel. <br />
        /// </summary>
        /// <param name="strikethrough">The Strikethrough</param>
        /// <remarks>
        /// SetStrikethrough specifies the strikethrough of the text through <see cref="Tizen.NUI.Text.Strikethrough"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetStrikethrough method.
        /// <code>
        /// var strikethrough = new Tizen.NUI.Text.Strikethrough();
        /// strikethrough.Enable = true;
        /// strikethrough.Color = new Color("#3498DB");
        /// strikethrough.Height = 2.0f;
        /// label.SetStrikethrough(strikethrough);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStrikethrough(Strikethrough strikethrough)
        {
            using (var map = TextMapHelper.GetStrikethroughMap(strikethrough))
            using (var propertyValue = new PropertyValue(map))
            {
                SetProperty(TextLabel.Property.Strikethrough, propertyValue);
            }
        }

        /// <summary>
        /// Get Strikethrough from TextLabel. <br />
        /// </summary>
        /// <returns>The Strikethrough</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.Strikethrough"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Strikethrough GetStrikethrough()
        {
            Strikethrough strikethrough;
            using (var propertyValue = GetProperty(TextLabel.Property.Strikethrough))
            using (var map = new PropertyMap())
            {
                propertyValue.Get(map);
                strikethrough = TextMapHelper.GetStrikethroughStruct(map);
            }
            return strikethrough;
        }

        /// <summary>
        /// The PixelSize property.<br />
        /// The size of font in pixels.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Binding.TypeConverter(typeof(FloatGraphicsTypeConverter))]
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
        /// The ellipsis position of the text.
        /// Specifies which portion of the text should be replaced with an ellipsis when the text size exceeds the layout size.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public EllipsisPosition EllipsisPosition
        {
            get
            {
                return (EllipsisPosition)GetValue(EllipsisPositionProperty);
            }
            set
            {
                SetValue(EllipsisPositionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollLoopDelay property.<br />
        /// The amount of time to delay the starting time of auto scrolling and further loops.<br />
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
        /// The auto scrolling stop behaviour.<br />
        /// The default value is AutoScrollStopMode.FinishLoop. <br />
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
                int lineCount = 0;
                using (var propertyValue = GetProperty(TextLabel.Property.LineCount))
                {
                    propertyValue.Get(out lineCount);
                }
                return lineCount;
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
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextDirection TextDirection
        {
            get
            {
                int textDirection = 0;
                using (var propertyValue = GetProperty(TextLabel.Property.TextDirection))
                {
                    propertyValue.Get(out textDirection);
                }
                return (TextDirection)textDirection;
            }
        }

        /// <summary>
        /// The vertical line alignment of the text.
        /// </summary>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
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
        /// <list type="table">
        /// <item><term>enable (bool)</term><description>True to enable the text fit or false to disable (the default value is false)</description></item>
        /// <item><term>minSize (float)</term><description>Minimum Size for text fit (the default value is 10.f)</description></item>
        /// <item><term>maxSize (float)</term><description>Maximum Size for text fit (the default value is 100.f)</description></item>
        /// <item><term>stepSize (float)</term><description>Step Size for font increase (the default value is 1.f)</description></item>
        /// <item><term>fontSize (string)</term><description>The size type of font, You can choose between "pointSize" or "pixelSize". (the default value is "pointSize")</description></item>
        /// </list>
        /// </summary>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
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
        /// Set TextFit to TextLabel. <br />
        /// </summary>
        /// <param name="textFit">The TextFit</param>
        /// <remarks>
        /// SetTextFit specifies the textFit of the text through <see cref="Tizen.NUI.Text.TextFit"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetTextFit method.
        /// <code>
        /// var textFit = new Tizen.NUI.Text.TextFit();
        /// textFit.Enable = true;
        /// textFit.MinSize = 10.0f;
        /// textFit.MaxSize = 100.0f;
        /// textFit.StepSize = 5.0f;
        /// textFit.FontSizeType = FontSizeType.PointSize;
        /// label.SetTextFit(textFit);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTextFit(TextFit textFit)
        {
            using (var textFitMap = TextMapHelper.GetTextFitMap(textFit))
            {
                SetValue(TextFitProperty, textFitMap);
            }
        }

        /// <summary>
        /// Get TextFit from TextLabel. <br />
        /// </summary>
        /// <returns>The TextFit</returns>
        /// <remarks>
        /// TextFit is always returned based on PointSize. <br />
        /// If the user sets FontSizeType to PixelSize, then MinSize, MaxSize, and StepSize are converted based on PointSize and returned. <br />
        /// <see cref="Tizen.NUI.Text.TextFit"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextFit GetTextFit()
        {
            TextFit textFit;
            using (var textFitMap = (PropertyMap)GetValue(TextFitProperty))
            {
                textFit = TextMapHelper.GetTextFitStruct(textFitMap);
            }
            return textFit;
        }

        /// <summary>
        /// The MinLineSize property.<br />
        /// The height of the line in points. <br />
        /// If the font size is larger than the line size, it works with the font size. <br />
        /// </summary>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
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
        /// The spaces between characters in Pixels.
        /// <remarks>
        /// A positive value will make the characters far apart (expanded) and a negative value will bring them closer (condensed).<br />
        /// The default value is 0.f which does nothing.
        ///</remarks>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CharacterSpacing
        {
            get
            {
                return (float)GetValue(CharacterSpacingProperty);
            }
            set
            {
                SetValue(CharacterSpacingProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The FontSizeScale property for scaling the specified font size up or down. <br />
        /// The default value is 1.0. <br />
        /// The given font size scale value is used for multiplying the specified font size before querying fonts. <br />
        /// If FontSizeScale.UseSystemSetting, will use the SystemSettings.FontSize internally. <br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float FontSizeScale
        {
            get
            {
                return (float)GetValue(FontSizeScaleProperty);
            }
            set
            {
                SetValue(FontSizeScaleProperty, value);
                NotifyPropertyChanged();
            }
        }

        private float InternalFontSizeScale
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
                    AddSystemSettingsFontSizeChanged();
                }
                else
                {
                    newFontSizeScale = fontSizeScale;
                    RemoveSystemSettingsFontSizeChanged();
                }

                SetInternalFontSizeScale(newFontSizeScale);
            }
        }

        private void SetInternalFontSizeScale(float fontSizeScale)
        {

            Object.InternalSetPropertyFloat(this.SwigCPtr, TextLabel.Property.FontSizeScale, (float)fontSizeScale);
            RequestLayout();
        }

        /// <summary>
        /// The EnableFontSizeScale property.<br />
        /// Whether the font size scale is enabled. (The default value is true)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableFontSizeScale
        {
            get
            {
                return (bool)GetValue(EnableFontSizeScaleProperty);
            }
            set
            {
                SetValue(EnableFontSizeScaleProperty, value);
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
        /// Do not use this, that will be deprecated. Use as keyword instead.
        [Obsolete("Do not use this, that will be deprecated. Use as keyword instead. " +
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

            internalTextColor?.Dispose();

            if (hasSystemLanguageChanged)
            {
                systemLocaleLanguageChanged.Remove(SystemSettingsLocaleLanguageChanged);
            }

            RemoveSystemSettingsFontTypeChanged();
            RemoveSystemSettingsFontSizeChanged();

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                selectorData?.Reset(this);
            }

            if (this.HasBody())
            {
                if (textLabelTextFitChangedCallbackDelegate != null)
                {
                    TextFitChangedSignal().Disconnect(textLabelTextFitChangedCallbackDelegate);
                }
            }

            base.Dispose(type);
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

        internal override LayoutItem CreateDefaultLayout()
        {
            return new TextLayout();
        }

        /// <summary>
        /// Invoked whenever the binding context of the textlabel changes. Implement this method to add class handling for this event.
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

        private void SystemSettingsLocaleLanguageChanged(object sender, LocaleLanguageChangedEventArgs e)
        {
            Text = NUIApplication.MultilingualResourceManager?.GetString(textLabelSid, new CultureInfo(e.Value.Replace("_", "-")));
        }

        private void SystemSettingsFontSizeChanged(object sender, FontSizeChangedEventArgs e)
        {
            float newFontSizeScale = TextUtils.GetFontSizeScale(e.Value);
            SetInternalFontSizeScale(newFontSizeScale);
        }

        private void AddSystemSettingsFontSizeChanged()
        {
            if (hasSystemFontSizeChanged != true)
            {
                try
                {
                    SystemFontSizeChangedManager.Add(SystemSettingsFontSizeChanged);
                    hasSystemFontSizeChanged = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasSystemFontSizeChanged = false;
                }
            }
        }

        private void RemoveSystemSettingsFontSizeChanged()
        {
            if (hasSystemFontSizeChanged == true)
            {
                try
                {
                    SystemFontSizeChangedManager.Remove(SystemSettingsFontSizeChanged);
                    hasSystemFontSizeChanged = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasSystemFontSizeChanged = true;
                }
            }
        }

        private void SystemSettingsFontTypeChanged(object sender, FontTypeChangedEventArgs e)
        {
            SetInternalFontFamily(e.Value);
        }

        private void AddSystemSettingsFontTypeChanged()
        {
            if (HasStyle() && !hasSystemFontTypeChanged)
            {
                try
                {
                    systemFontTypeChanged.Add(SystemSettingsFontTypeChanged);
                    hasSystemFontTypeChanged = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasSystemFontTypeChanged = false;
                }
            }
        }
        
        private void RemoveSystemSettingsFontTypeChanged()
        {
            if (hasSystemFontTypeChanged)
            {
                try
                {
                    systemFontTypeChanged.Remove(SystemSettingsFontTypeChanged);
                    hasSystemFontTypeChanged = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasSystemFontTypeChanged = true;
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
            internal static readonly int RelativeLineHeight = Interop.TextLabel.RelativeLineHeightGet();
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
            internal static readonly int EnableFontSizeScale = Interop.TextLabel.EnableFontSizeScaleGet();
            internal static readonly int EllipsisPosition = Interop.TextLabel.EllipsisPositionGet();
            internal static readonly int Strikethrough = Interop.TextLabel.StrikethroughGet();
            internal static readonly int CharacterSpacing = Interop.TextLabel.CharacterSpacingGet();
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
