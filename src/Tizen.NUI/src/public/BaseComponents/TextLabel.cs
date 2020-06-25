/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
        static TextLabel() { }

        private string textLabelSid = null;
        private bool systemlangTextFlag = false;

        private CloneableViewSelector<TextShadow> textShadow;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle Style => ViewStyle as TextLabelStyle;

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextLabel() : this(Interop.TextLabel.TextLabel_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel(TextLabelStyle viewStyle) : this(Interop.TextLabel.TextLabel_New__SWIG_0(), true, viewStyle)
        {
        }

        /// <summary>
        /// Creates the TextLabel with setting the status of shown or hidden.
        /// </summary>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel(bool shown) : this(Interop.TextLabel.TextLabel_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        /// <param name="text">The text to display</param>
        /// <since_tizen> 3 </since_tizen>
        public TextLabel(string text) : this(Interop.TextLabel.TextLabel_New__SWIG_1(text), true)
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
        public TextLabel(string text, bool shown) : this(Interop.TextLabel.TextLabel_New__SWIG_1(text), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        internal TextLabel(TextLabel handle, bool shown = true) : this(Interop.TextLabel.new_TextLabel__SWIG_1(TextLabel.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (!shown)
            {
                SetVisible(false);
            }
        }

        internal TextLabel(global::System.IntPtr cPtr, bool cMemoryOwn, ViewStyle viewStyle, bool shown = true) : base(Interop.TextLabel.TextLabel_SWIGUpcast(cPtr), cMemoryOwn, viewStyle)
        {
            if (!shown)
            {
                SetVisible(false);
            }
        }

        internal TextLabel(global::System.IntPtr cPtr, bool cMemoryOwn, bool shown = true) : base(Interop.TextLabel.TextLabel_SWIGUpcast(cPtr), cMemoryOwn)
        {
            if (!shown)
            {
                SetVisible(false);
            }
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
                string temp = (string)GetValue(TranslatableTextProperty);
                return textLabelSid;
            }
            set
            {
                if (NUIApplication.MultilingualResourceManager == null)
                {
                    throw new ArgumentNullException("ResourceManager about multilingual is null");
                }
                string translatableText = null;
                textLabelSid = value;
                translatableText = NUIApplication.MultilingualResourceManager?.GetString(textLabelSid, new CultureInfo(SystemSettings.LocaleLanguage.Replace("_", "-")));
                if (translatableText != null)
                {
                    Text = translatableText;
                    if (systemlangTextFlag == false)
                    {
                        SystemSettings.LocaleLanguageChanged += new WeakEventHandler<LocaleLanguageChangedEventArgs>(SystemSettings_LocaleLanguageChanged).Handler;
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
                NotifyPropertyChangedAndRequestLayout();
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
                NotifyPropertyChangedAndRequestLayout();
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
                NotifyPropertyChangedAndRequestLayout();
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
                NotifyPropertyChangedAndRequestLayout();
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
                NotifyPropertyChangedAndRequestLayout();
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
                NotifyPropertyChangedAndRequestLayout();
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
                var value = (TextShadow)GetValue(TextShadowProperty);
                return value == null ? null : new TextShadow(value, OnTextShadowChanged);
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
                NotifyPropertyChangedAndRequestLayout();
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
                GetProperty(TextLabel.Property.LINE_COUNT).Get(out temp);
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
                GetProperty(TextLabel.Property.TEXT_DIRECTION).Get(out temp);
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
                NotifyPropertyChangedAndRequestLayout();
            }
        }

        /// <summary>
        /// Downcasts a handle to textLabel handle
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
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
            TextLabel ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as TextLabel;

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TextLabel obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TextLabel.delete_TextLabel(swigCPtr);
        }

        /// <summary>
        /// Get attribues, it is abstract function and must be override.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new TextLabelStyle();
        }

        internal static readonly BindableProperty TranslatableTextSelectorProperty = BindableProperty.Create("TranslatableTextSelector", typeof(Selector<string>), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            textLabel.TranslatableTextSelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.TranslatableTextSelector;
        });
        internal static readonly BindableProperty TextSelectorProperty = BindableProperty.Create("TextSelector", typeof(Selector<string>), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            textLabel.textSelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.textSelector;
        });
        internal static readonly BindableProperty FontFamilySelectorProperty = BindableProperty.Create("FontFamilySelector", typeof(Selector<string>), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            textLabel.fontFamilySelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.fontFamilySelector;
        });
        internal static readonly BindableProperty PointSizeSelectorProperty = BindableProperty.Create("PointSizeSelector", typeof(Selector<float?>), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            textLabel.pointSizeSelector.Clone((Selector<float?>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.pointSizeSelector;
        });
        internal static readonly BindableProperty TextColorSelectorProperty = BindableProperty.Create("TextColorSelector", typeof(Selector<Color>), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            textLabel.textColorSelector.Clone((Selector<Color>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.textColorSelector;
        });

        private TriggerableSelector<string> translatableTextSelector;
        private TriggerableSelector<string> TranslatableTextSelector
        {
            get
            {
                if (null == translatableTextSelector)
                {
                    translatableTextSelector = new TriggerableSelector<string>(this, TranslatableTextProperty);
                }
                return translatableTextSelector;
            }
        }

        private TriggerableSelector<string> _textSelector;
        private TriggerableSelector<string> textSelector
        {
            get
            {
                if (null == _textSelector)
                {
                    _textSelector = new TriggerableSelector<string>(this, TextProperty);
                }
                return _textSelector;
            }
        }

        private TriggerableSelector<string> _fontFamilySelector;
        private TriggerableSelector<string> fontFamilySelector
        {
            get
            {
                if (null == _fontFamilySelector)
                {
                    _fontFamilySelector = new TriggerableSelector<string>(this, FontFamilyProperty);
                }
                return _fontFamilySelector;
            }
        }

        private TriggerableSelector<Color> _textColorSelector;
        private TriggerableSelector<Color> textColorSelector
        {
            get
            {
                if (null == _textColorSelector)
                {
                    _textColorSelector = new TriggerableSelector<Color>(this, TextColorProperty);
                }
                return _textColorSelector;
            }
        }

        private TriggerableSelector<float?> _pointSizeSelector;
        private TriggerableSelector<float?> pointSizeSelector
        {
            get
            {
                if (null == _pointSizeSelector)
                {
                    _pointSizeSelector = new TriggerableSelector<float?>(this, PointSizeProperty);
                }
                return _pointSizeSelector;
            }
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

        private void  NotifyPropertyChangedAndRequestLayout()
        {
            NotifyPropertyChanged();
            Layout?.RequestLayout();
        }

        internal new class Property
        {
            internal static readonly int RENDERING_BACKEND = Interop.TextLabel.TextLabel_Property_RENDERING_BACKEND_get();
            internal static readonly int TEXT = Interop.TextLabel.TextLabel_Property_TEXT_get();
            internal static readonly int FONT_FAMILY = Interop.TextLabel.TextLabel_Property_FONT_FAMILY_get();
            internal static readonly int FONT_STYLE = Interop.TextLabel.TextLabel_Property_FONT_STYLE_get();
            internal static readonly int POINT_SIZE = Interop.TextLabel.TextLabel_Property_POINT_SIZE_get();
            internal static readonly int MULTI_LINE = Interop.TextLabel.TextLabel_Property_MULTI_LINE_get();
            internal static readonly int HORIZONTAL_ALIGNMENT = Interop.TextLabel.TextLabel_Property_HORIZONTAL_ALIGNMENT_get();
            internal static readonly int VERTICAL_ALIGNMENT = Interop.TextLabel.TextLabel_Property_VERTICAL_ALIGNMENT_get();
            internal static readonly int TEXT_COLOR = Interop.TextLabel.TextLabel_Property_TEXT_COLOR_get();
            internal static readonly int ENABLE_MARKUP = Interop.TextLabel.TextLabel_Property_ENABLE_MARKUP_get();
            internal static readonly int ENABLE_AUTO_SCROLL = Interop.TextLabel.TextLabel_Property_ENABLE_AUTO_SCROLL_get();
            internal static readonly int AUTO_SCROLL_SPEED = Interop.TextLabel.TextLabel_Property_AUTO_SCROLL_SPEED_get();
            internal static readonly int AUTO_SCROLL_LOOP_COUNT = Interop.TextLabel.TextLabel_Property_AUTO_SCROLL_LOOP_COUNT_get();
            internal static readonly int AUTO_SCROLL_GAP = Interop.TextLabel.TextLabel_Property_AUTO_SCROLL_GAP_get();
            internal static readonly int LINE_SPACING = Interop.TextLabel.TextLabel_Property_LINE_SPACING_get();
            internal static readonly int UNDERLINE = Interop.TextLabel.TextLabel_Property_UNDERLINE_get();
            internal static readonly int SHADOW = Interop.TextLabel.TextLabel_Property_SHADOW_get();
            internal static readonly int EMBOSS = Interop.TextLabel.TextLabel_Property_EMBOSS_get();
            internal static readonly int OUTLINE = Interop.TextLabel.TextLabel_Property_OUTLINE_get();
            internal static readonly int PIXEL_SIZE = Interop.TextLabel.TextLabel_Property_PIXEL_SIZE_get();
            internal static readonly int ELLIPSIS = Interop.TextLabel.TextLabel_Property_ELLIPSIS_get();
            internal static readonly int AUTO_SCROLL_STOP_MODE = Interop.TextLabel.TextLabel_Property_AUTO_SCROLL_STOP_MODE_get();
            internal static readonly int AUTO_SCROLL_LOOP_DELAY = Interop.TextLabel.TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get();
            internal static readonly int LINE_COUNT = Interop.TextLabel.TextLabel_Property_LINE_COUNT_get();
            internal static readonly int LINE_WRAP_MODE = Interop.TextLabel.TextLabel_Property_LINE_WRAP_MODE_get();
            internal static readonly int TEXT_DIRECTION = Interop.TextLabel.TextLabel_Property_TEXT_DIRECTION_get();
            internal static readonly int VERTICAL_LINE_ALIGNMENT = Interop.TextLabel.TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get();
            internal static readonly int MATCH_SYSTEM_LANGUAGE_DIRECTION = Interop.TextLabel.TextLabel_Property_MATCH_SYSTEM_LANGUAGE_DIRECTION_get();
            internal static readonly int TEXT_FIT = Interop.TextLabel.TextLabel_Property_TEXT_FIT_get();
            internal static readonly int MIN_LINE_SIZE = Interop.TextLabel.TextLabel_Property_MIN_LINE_SIZE_get();
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

        private void OnTextShadowChanged(TextShadow instance)
        {
            TextShadow = instance;
        }

        private void OnControlStateChangedForShadow(object obj, ControlStateChangedEventArgs controlStateChangedInfo)
        {
            UpdateTextShadowVisual();
        }

        private void UpdateTextShadowVisual()
        {
            TextShadow shadow = (textShadow != null && !textShadow.IsEmpty()) ? textShadow.GetValue() : textShadow?.GetValue();
            Object.SetProperty(swigCPtr, Property.SHADOW, TextShadow.ToPropertyValue(shadow));
        }
    }
}
