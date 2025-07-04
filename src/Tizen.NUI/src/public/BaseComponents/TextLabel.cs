/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
        internal class TextLabelLayout : LayoutItem
        {
            private float lastWidth = 0;
            private float lastHeight = 0;

            public void OnAsyncTextRendered(object sender, AsyncTextRenderedEventArgs e)
            {
                SetMeasuredDimensions(new LayoutLength(e.Width), new LayoutLength(e.Height));
                RequestLayout();
            }

            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                // Padding will be automatically applied by DALi TextLabel.
                float totalWidth = widthMeasureSpec.Size.AsDecimal();
                float totalHeight = heightMeasureSpec.Size.AsDecimal();

                if (Owner is TextLabel label && label.RenderMode == TextRenderMode.AsyncAuto)
                {
                    label.AddAsyncTextRendered();
                    if (label.NeedRequestAsyncRender || (lastWidth != totalWidth) || (lastHeight != totalHeight))
                    {
                        lastWidth = totalWidth;
                        lastHeight = totalHeight;

                        if (widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                        {
                            if (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                            {
                                label.RequestAsyncRenderWithFixedSize(totalWidth, totalHeight);
                            }
                            else
                            {
                                if (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Unspecified)
                                {
                                    totalHeight = float.PositiveInfinity;
                                }
                                label.RequestAsyncRenderWithFixedWidth(totalWidth, totalHeight);
                            }
                        }
                        else
                        {
                            if (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                            {
                                // TODO : Async Render with "Constraint Width" and "Fixed Height" is not currently supported in DALi Text.
                                var minWidth = Owner.GetMinimumWidth();
                                var maxWidth = Owner.GetMaximumWidth();
                                var naturalSize = Owner.GetNaturalSize();
                                float tempWidth = naturalSize != null ? naturalSize.Width : 0;
                                totalWidth = Math.Max(Math.Min(tempWidth, maxWidth < 0 ? Int32.MaxValue : maxWidth), minWidth);
                                label.RequestAsyncRenderWithFixedSize(totalWidth, totalHeight);
                            }
                            else
                            {
                                if (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Unspecified)
                                {
                                    totalHeight = float.PositiveInfinity;
                                }
                                label.RequestAsyncRenderWithConstraint(totalWidth, totalHeight);
                            }
                        }

                        float width = label.SizeWidth;
                        float height = label.SizeHeight;
                        SetMeasuredDimensions(new LayoutLength(width), new LayoutLength(height));
                    }
                }
                else
                {
                    if (widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                    {
                        if (heightMeasureSpec.Mode != MeasureSpecification.ModeType.Exactly)
                        {
                            var padding = Owner.Padding;
                            totalHeight = Owner.GetHeightForWidth(totalWidth - (padding.Start + padding.End));
                            heightMeasureSpec = new MeasureSpecification(new LayoutLength(totalHeight), MeasureSpecification.ModeType.Exactly);
                        }
                    }
                    else
                    {
                        var minWidth = Owner.GetMinimumWidth();
                        var minHeight = Owner.GetMinimumHeight();
                        var maxWidth = Owner.GetMaximumWidth();
                        var maxHeight = Owner.GetMaximumHeight();
                        var naturalSize = Owner.GetNaturalSize();

                        if (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                        {
                            // GetWidthForHeight is not implemented.
                            float width = naturalSize != null ? naturalSize.Width : 0;
                            // Since priority of MinimumSize is higher than MaximumSize in DALi, here follows it.
                            totalWidth = Math.Max(Math.Min(width, maxWidth < 0 ? Int32.MaxValue : maxWidth), minWidth);
                            widthMeasureSpec = new MeasureSpecification(new LayoutLength(totalWidth), MeasureSpecification.ModeType.Exactly);
                        }
                        else
                        {
                            float width = naturalSize != null ? naturalSize.Width : 0;
                            // Since priority of MinimumSize is higher than MaximumSize in DALi, here follows it.
                            totalWidth = Math.Max(Math.Min(width, maxWidth < 0 ? Int32.MaxValue : maxWidth), minWidth);

                            var padding = Owner.Padding;
                            float height = Owner.GetHeightForWidth(totalWidth - (padding.Start + padding.End));
                            totalHeight = Math.Max(Math.Min(height, maxHeight < 0 ? Int32.MaxValue : maxHeight), minHeight);

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

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool IsPaddingHandledByNative()
            {
                return true;
            }
        }

        static TextLabel() 
        { 
            if (NUIApplication.IsUsingXaml)
            {
                TranslatableTextProperty = BindableProperty.Create(nameof(TranslatableText), typeof(string), typeof(TextLabel), string.Empty, 
                    propertyChanged: SetInternalTranslatableTextProperty, defaultValueCreator: GetInternalTranslatableTextProperty);

                TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextLabel), string.Empty, 
                    propertyChanged: SetInternalTextProperty, defaultValueCreator: GetInternalTextProperty);

                FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextLabel), string.Empty, 
                    propertyChanged: SetInternalFontFamilyProperty, defaultValueCreator: GetInternalFontFamilyProperty);

                FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextLabel), null, 
                    propertyChanged: SetInternalFontStyleProperty, defaultValueCreator: GetInternalFontStyleProperty);

                PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextLabel), default(float), 
                    propertyChanged: SetInternalPointSizeProperty, defaultValueCreator: GetInternalPointSizeProperty);

                MultiLineProperty = BindableProperty.Create(nameof(MultiLine), typeof(bool), typeof(TextLabel), false, 
                    propertyChanged: SetInternalMultiLineProperty, defaultValueCreator: GetInternalMultiLineProperty);

                HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextLabel), HorizontalAlignment.Begin, 
                    propertyChanged: SetInternalHorizontalAlignmentProperty, defaultValueCreator: GetInternalHorizontalAlignmentProperty);

                VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment), typeof(TextLabel), VerticalAlignment.Bottom, 
                    propertyChanged: SetInternalVerticalAlignmentProperty, defaultValueCreator: GetInternalVerticalAlignmentProperty);

                TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(TextLabel), null, 
                    propertyChanged: SetInternalTextColorProperty, defaultValueCreator: GetInternalTextColorProperty);

                AnchorColorProperty = BindableProperty.Create(nameof(TextLabel.AnchorColor), typeof(Color), typeof(TextLabel), null, 
                    propertyChanged: SetInternalAnchorColorProperty, defaultValueCreator: GetInternalAnchorColorProperty);

                AnchorClickedColorProperty = BindableProperty.Create(nameof(TextLabel.AnchorClickedColor), typeof(Color), typeof(TextLabel), null, 
                    propertyChanged: SetInternalAnchorClickedColorProperty, defaultValueCreator: GetInternalAnchorClickedColorProperty);

                RemoveFrontInsetProperty = BindableProperty.Create(nameof(RemoveFrontInset), typeof(bool), typeof(TextLabel), false, 
                    propertyChanged: SetInternalRemoveFrontInsetProperty, defaultValueCreator: GetInternalRemoveFrontInsetProperty);

                RemoveBackInsetProperty = BindableProperty.Create(nameof(RemoveBackInset), typeof(bool), typeof(TextLabel), false, 
                    propertyChanged: SetInternalRemoveBackInsetProperty, defaultValueCreator: GetInternalRemoveBackInsetProperty);

                EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool), typeof(TextLabel), false, 
                    propertyChanged: SetInternalEnableMarkupProperty, defaultValueCreator: GetInternalEnableMarkupProperty);

                EnableAutoScrollProperty = BindableProperty.Create(nameof(EnableAutoScroll), typeof(bool), typeof(TextLabel), false, 
                    propertyChanged: SetInternalEnableAutoScrollProperty, defaultValueCreator: GetInternalEnableAutoScrollProperty);

                AutoScrollSpeedProperty = BindableProperty.Create(nameof(AutoScrollSpeed), typeof(int), typeof(TextLabel), default(int), 
                    propertyChanged: SetInternalAutoScrollSpeedProperty, defaultValueCreator: GetInternalAutoScrollSpeedProperty);

                AutoScrollLoopCountProperty = BindableProperty.Create(nameof(AutoScrollLoopCount), typeof(int), typeof(TextLabel), default(int), 
                    propertyChanged: SetInternalAutoScrollLoopCountProperty, defaultValueCreator: GetInternalAutoScrollLoopCountProperty);

                AutoScrollGapProperty = BindableProperty.Create(nameof(AutoScrollGap), typeof(float), typeof(TextLabel), default(float), 
                    propertyChanged: SetInternalAutoScrollGapProperty, defaultValueCreator: GetInternalAutoScrollGapProperty);

                LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float), typeof(TextLabel), default(float), 
                    propertyChanged: SetInternalLineSpacingProperty, defaultValueCreator: GetInternalLineSpacingProperty);

                RelativeLineHeightProperty = BindableProperty.Create(nameof(RelativeLineHeight), typeof(float), typeof(TextLabel), default(float), 
                    propertyChanged: SetInternalRelativeLineHeightProperty, defaultValueCreator: GetInternalRelativeLineHeightProperty);

                UnderlineProperty = BindableProperty.Create(nameof(Underline), typeof(PropertyMap), typeof(TextLabel), null, 
                    propertyChanged: SetInternalUnderlineProperty, defaultValueCreator: GetInternalUnderlineProperty);

                ShadowProperty = BindableProperty.Create(nameof(Shadow), typeof(PropertyMap), typeof(TextLabel), null, 
                    propertyChanged: SetInternalShadowProperty, defaultValueCreator: GetInternalShadowProperty);

                TextShadowProperty = BindableProperty.Create(nameof(TextShadow), typeof(TextShadow), typeof(TextLabel), null, 
                    propertyChanged: SetInternalTextShadowProperty, defaultValueCreator: GetInternalTextShadowProperty);

                EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextLabel), string.Empty, 
                    propertyChanged: SetInternalEmbossProperty, defaultValueCreator: GetInternalEmbossProperty);

                OutlineProperty = BindableProperty.Create(nameof(Outline), typeof(PropertyMap), typeof(TextLabel), null, 
                    propertyChanged: SetInternalOutlineProperty, defaultValueCreator: GetInternalOutlineProperty);

                PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float), typeof(TextLabel), default(float), 
                    propertyChanged: SetInternalPixelSizeProperty, defaultValueCreator: GetInternalPixelSizeProperty);

                EllipsisProperty = BindableProperty.Create(nameof(Ellipsis), typeof(bool), typeof(TextLabel), false, 
                    propertyChanged: SetInternalEllipsisProperty, defaultValueCreator: GetInternalEllipsisProperty);

                EllipsisPositionProperty = BindableProperty.Create(nameof(EllipsisPosition), typeof(EllipsisPosition), typeof(TextLabel), EllipsisPosition.End, 
                    propertyChanged: SetInternalEllipsisPositionProperty, defaultValueCreator: GetInternalEllipsisPositionProperty);

                AutoScrollLoopDelayProperty = BindableProperty.Create(nameof(AutoScrollLoopDelay), typeof(float), typeof(TextLabel), default(float), 
                    propertyChanged: SetInternalAutoScrollLoopDelayProperty, defaultValueCreator: GetInternalAutoScrollLoopDelayProperty);

                AutoScrollStopModeProperty = BindableProperty.Create(nameof(AutoScrollStopMode), typeof(AutoScrollStopMode), typeof(TextLabel), AutoScrollStopMode.FinishLoop, 
                    propertyChanged: SetInternalAutoScrollStopModeProperty, defaultValueCreator: GetInternalAutoScrollStopModeProperty);

                LineWrapModeProperty = BindableProperty.Create(nameof(LineWrapMode), typeof(LineWrapMode), typeof(TextLabel), LineWrapMode.Word, 
                    propertyChanged: SetInternalLineWrapModeProperty, defaultValueCreator: GetInternalLineWrapModeProperty);

                VerticalLineAlignmentProperty = BindableProperty.Create(nameof(VerticalLineAlignment), typeof(VerticalLineAlignment), typeof(TextLabel), VerticalLineAlignment.Bottom, 
                    propertyChanged: SetInternalVerticalLineAlignmentProperty, defaultValueCreator: GetInternalVerticalLineAlignmentProperty);

                MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(MatchSystemLanguageDirection), typeof(bool), typeof(TextLabel), false, 
                    propertyChanged: SetInternalMatchSystemLanguageDirectionProperty, defaultValueCreator: GetInternalMatchSystemLanguageDirectionProperty);

                CharacterSpacingProperty = BindableProperty.Create(nameof(CharacterSpacing), typeof(float), typeof(TextLabel), default(float), 
                    propertyChanged: SetInternalCharacterSpacingProperty, defaultValueCreator: GetInternalCharacterSpacingProperty);

                TextFitProperty = BindableProperty.Create(nameof(TextFit), typeof(PropertyMap), typeof(TextLabel), null, 
                    propertyChanged: SetInternalTextFitProperty, defaultValueCreator: GetInternalTextFitProperty);

                MinLineSizeProperty = BindableProperty.Create(nameof(MinLineSize), typeof(float), typeof(TextLabel), default(float), 
                    propertyChanged: SetInternalMinLineSizeProperty, defaultValueCreator: GetInternalMinLineSizeProperty);

                FontSizeScaleProperty = BindableProperty.Create(nameof(FontSizeScale), typeof(float), typeof(TextLabel), default(float), 
                    propertyChanged: SetInternalFontSizeScaleProperty, defaultValueCreator: GetInternalFontSizeScaleProperty);

                EnableFontSizeScaleProperty = BindableProperty.Create(nameof(EnableFontSizeScale), typeof(bool), typeof(TextLabel), default(bool), 
                    propertyChanged: SetInternalEnableFontSizeScaleProperty, defaultValueCreator: GetInternalEnableFontSizeScaleProperty);

                ShadowOffsetProperty = BindableProperty.Create(nameof(ShadowOffset), typeof(Tizen.NUI.Vector2), typeof(TextLabel), null, 
                    propertyChanged: SetInternalShadowOffsetProperty, defaultValueCreator: GetInternalShadowOffsetProperty);

                ShadowColorProperty = BindableProperty.Create(nameof(ShadowColor), typeof(Tizen.NUI.Vector4), typeof(TextLabel), null, 
                    propertyChanged: SetInternalShadowColorProperty, defaultValueCreator: GetInternalShadowColorProperty);

                UnderlineEnabledProperty = BindableProperty.Create(nameof(UnderlineEnabled), typeof(bool), typeof(TextLabel), false, 
                    propertyChanged: SetInternalUnderlineEnabledProperty, defaultValueCreator: GetInternalUnderlineEnabledProperty);

                UnderlineColorProperty = BindableProperty.Create(nameof(UnderlineColor), typeof(Tizen.NUI.Vector4), typeof(TextLabel), null, 
                    propertyChanged: SetInternalUnderlineColorProperty, defaultValueCreator: GetInternalUnderlineColorProperty);

                UnderlineHeightProperty = BindableProperty.Create(nameof(UnderlineHeight), typeof(float), typeof(TextLabel), 0.0f, 
                    propertyChanged: SetInternalUnderlineHeightProperty, defaultValueCreator: GetInternalUnderlineHeightProperty);

                CutoutProperty = BindableProperty.Create(nameof(Cutout), typeof(bool), typeof(TextLabel), false,
                    propertyChanged: SetInternalCutoutProperty, defaultValueCreator: GetInternalCutoutProperty);
            }
        }

        static internal new void Preload()
        {
            // Do not call View.Preload(), since we already call it

            Property.Preload();
            // Do nothing. Just call for load static values.
        }

        static private string defaultStyleName = "Tizen.NUI.BaseComponents.TextLabel";
        static private string defaultFontFamily = "BreezeSans";
        private string textLabelSid;
        private TextLabelSelectorData selectorData;
        private string fontFamily = defaultFontFamily;
        private float fontSizeScale = 1.0f;
        private bool textIsEmpty = true;

        private bool hasSystemLanguageChanged;
        private bool hasSystemFontSizeChanged;
        private bool hasSystemFontTypeChanged;
        private bool hasAsyncTextRendered;

        private Color internalTextColor;
        private Color internalAnchorColor;
        private Color internalAnchorClickedColor;

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextLabel() : this(Interop.TextLabel.New(ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel(TextLabelStyle viewStyle) : this(Interop.TextLabel.New(ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true, viewStyle)
        {
        }

        /// <summary>
        /// Creates the TextLabel with setting the status of shown or hidden.
        /// </summary>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
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
            textIsEmpty = string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// Creates the TextLabel with setting the status of shown or hidden.
        /// </summary>
        /// <param name="text">The text to display</param>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel(string text, bool shown) : this(Interop.TextLabel.New(text, ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            textIsEmpty = string.IsNullOrEmpty(text);
            SetVisible(shown);
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
        /// Requests asynchronous rendering of text with a fixed size.
        /// </summary>
        /// <param name="width">The width of text to render.</param>
        /// <param name="height">The height of text to render.</param>
        /// <remarks>
        /// Only works when AsyncAuto and AsyncManual.<br />
        /// If another request occurs before the requested render is completed, the previous request will be canceled.<br />
        /// In AsyncAuto, the manual request is not canceled by an auto request caused by OnRealyout.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestAsyncRenderWithFixedSize(float width, float height)
        {
            Interop.TextLabel.RequestAsyncRenderWithFixedSize(SwigCPtr, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Requests asynchronous text rendering with a fixed width.
        /// </summary>
        /// <param name="width">The width of text to render.</param>
        /// <param name="heightConstraint">The maximum available height of text to render.</param>
        /// <remarks>
        /// Only works when AsyncAuto and AsyncManual.<br />
        /// The height is determined by the content of the text when rendered with the given width.<br />
        /// The result will be the same as the height returned by GetHeightForWidth.<br />
        /// If the heightConstraint is given, the maximum height will be the heightConstraint.<br />
        /// If another request occurs before the requested render is completed, the previous request will be canceled.<br />
        /// In AsyncAuto, the manual request is not canceled by an auto request caused by OnRealyout.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestAsyncRenderWithFixedWidth(float width, float heightConstraint = float.PositiveInfinity)
        {
            Interop.TextLabel.RequestAsyncRenderWithFixedWidth(SwigCPtr, width, heightConstraint);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Requests asynchronous rendering with the maximum available width using the given widthConstraint.
        /// </summary>
        /// <param name="widthConstraint">The maximum available width of text to render.</param>
        /// <param name="heightConstraint">The maximum available height of text to render.</param>
        /// <remarks>
        /// Only works when AsyncAuto and AsyncManual.<br />
        /// If the width of the text content is smaller than the widthConstraint, the width will be determined by the width of the text.<br />
        /// If the width of the text content is larger than the widthConstraint, the width will be determined by the widthConstraint.<br />
        /// The height is determined by the content of the text when rendered with the given width.<br />
        /// In this case, the result will be the same as the height returned by GetHeightForWidth.<br />
        /// If the heightConstraint is given, the maximum height will be the heightConstraint.<br />
        /// If another request occurs before the requested render is completed, the previous request will be canceled.<br />
        /// In AsyncAuto, the manual request is not canceled by an auto request caused by OnRealyout.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestAsyncRenderWithConstraint(float widthConstraint, float heightConstraint = float.PositiveInfinity)
        {
            Interop.TextLabel.RequestAsyncRenderWithConstraint(SwigCPtr, widthConstraint, heightConstraint);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Requests asynchronous text natural size computation.
        /// </summary>
        /// <remarks>
        /// If another request occurs before the requested natural size computation is completed, the previous request will be canceled.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestAsyncNaturalSize()
        {
            Interop.TextLabel.RequestAsyncNaturalSize(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Requests asynchronous computation of the height of the text based on the given width.
        /// </summary>
        /// <param name="width">The width of text to compute.</param>
        /// <remarks>
        /// If another request occurs before the requested height for width computation is completed, the previous request will be canceled.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestAsyncHeightForWidth(float width)
        {
            Interop.TextLabel.RequestAsyncHeightForWidth(SwigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(TranslatableTextProperty);
                }
                else
                {
                    return GetInternalTranslatableText();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TranslatableTextProperty, value);
                }
                else 
                {
                    SetInternalTranslatableText(value);
                }
            }
        }

        private void SetInternalTranslatableText(string text)
        {
            selectorData?.TranslatableText?.Reset(this);
            SetTranslatableText(text);
        }

        private string GetInternalTranslatableText()
        {
            return translatableText;
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
                translatableText = NUIApplication.MultilingualResourceManager?.GetString(textLabelSid, new CultureInfo(SystemLocaleLanguageChangedManager.LocaleLanguage.Replace("_", "-")));
                if (translatableText != null)
                {
                    Text = translatableText;
                    AddSystemSettingsLocaleLanguageChanged();
                }
                else
                {
                    Text = "";
                    RemoveSystemSettingsLocaleLanguageChanged();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(TextProperty);
                }
                else
                {
                    return GetInternalText();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextProperty, value);
                }
                else 
                {
                    SetInternalText(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalText(string text)
        {
            selectorData?.Text?.Reset(this);
            SetText(text);
        }

        private string GetInternalText()
        {
            // Do not try to get string if we know that previous text was empty.
            return textIsEmpty ? "" : Object.InternalGetPropertyString(SwigCPtr, Property.TEXT);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(FontFamilyProperty);
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
                    selectorData?.FontFamily?.Reset(this);
                    SetFontFamily(value);
                }
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
                if (string.Equals(fontFamily, value)) return;
                fontFamily = value;

                string newFontFamily;
                if (fontFamily == Tizen.NUI.FontFamily.UseSystemSetting)
                {
                    newFontFamily = SystemFontTypeChangedManager.FontType;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(FontStyleProperty);
                }
                else
                {
                    return GetInternalFontStyle();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontStyleProperty, value);
                }
                else 
                {
                    SetInternalFontStyle(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalFontStyle(PropertyMap map)
        {
            if (map != null)
            {
                using var pv = new PropertyValue(map);
                Object.SetProperty(SwigCPtr, Property.FontStyle, pv);
                RequestLayout();
            }
        }

        private PropertyMap GetInternalFontStyle()
        {
            PropertyMap temp = new PropertyMap();
            using (var prop = Object.GetProperty(SwigCPtr, Property.FontStyle))
            {
                prop.Get(temp);
            }
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontStyleProperty, fontStyleMap);
                }
                else
                {
                    SetInternalFontStyle(fontStyleMap);
                }
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
            if (NUIApplication.IsUsingXaml)
            {
                var fontStyleMap = (PropertyMap)GetValue(FontStyleProperty);
                fontStyle = TextMapHelper.GetFontStyleStruct(fontStyleMap);
            }
            else
            {
                using var fontStyleMap = GetInternalFontStyle();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(PointSizeProperty);
                }
                else
                {
                    return GetInternalPointSize();
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
                    SetInternalPointSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPointSize(float newValue)
        {
            selectorData?.PointSize?.Reset(this);
            SetPointSize(newValue);
        }

        private float GetInternalPointSize()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.PointSize);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(MultiLineProperty);
                }
                else
                {
                    return GetInternalMultiLine();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MultiLineProperty, value);
                }
                else 
                {
                    SetInternalMultiLine(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalMultiLine(bool newValue)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.MultiLine, newValue);
            RequestLayout();
        }

        private bool GetInternalMultiLine()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.MultiLine);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignment)GetValue(HorizontalAlignmentProperty);
                }
                else
                {
                    return GetInternalHorizontalAlignment();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HorizontalAlignmentProperty, value);
                }
                else 
                {
                    SetInternalHorizontalAlignment(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalHorizontalAlignment(HorizontalAlignment newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.HorizontalAlignment, (int)newValue);
        }

        private HorizontalAlignment GetInternalHorizontalAlignment()
        {
            string temp = Object.InternalGetPropertyString(SwigCPtr, Property.HorizontalAlignment);
            if (System.String.IsNullOrEmpty(temp))
            {
                return HorizontalAlignment.Begin; // Return default value.
            }

            if (temp.Equals("BEGIN"))
            {
                return HorizontalAlignment.Begin;
            }
            else if (temp.Equals("CENTER"))
            {
                return HorizontalAlignment.Center;
            }
            else
            {
                return HorizontalAlignment.End;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (VerticalAlignment)GetValue(VerticalAlignmentProperty);
                }
                else
                {
                    return GetInternalVerticalAlignment();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(VerticalAlignmentProperty, value);
                }
                else 
                {
                    SetInternalVerticalAlignment(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalVerticalAlignment(VerticalAlignment newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.VerticalAlignment, (int)newValue);
        }

        private VerticalAlignment GetInternalVerticalAlignment()
        {
            string temp = Object.InternalGetPropertyString(SwigCPtr, Property.VerticalAlignment);
            if (System.String.IsNullOrEmpty(temp))
            {
                return VerticalAlignment.Top; // Return default value.
            }

            if (temp.Equals("TOP"))
            {
                return VerticalAlignment.Top;
            }
            else if (temp.Equals("CENTER"))
            {
                return VerticalAlignment.Center;
            }
            else
            {
                return VerticalAlignment.Bottom;
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
                Color temp;
                if (NUIApplication.IsUsingXaml)
                {
                    temp = (Color)GetValue(TextColorProperty);
                }
                else
                {
                    temp = GetInternalTextColor();
                }
                return new Color(OnTextColorChanged, temp.R, temp.G, temp.B, temp.A);
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextColorProperty, value);
                }
                else 
                {
                    SetInternalTextColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalTextColor(Color newValue)
        {
            selectorData?.TextColor?.Reset(this);
            SetTextColor((Color)newValue);
        }

        private Color GetInternalTextColor()
        {
            if (internalTextColor == null)
            {
                internalTextColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Property.TextColor, internalTextColor.SwigCPtr);
            return internalTextColor;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ShadowOffsetProperty) as Vector2;
                }
                else
                {
                    return InternalShadowOffset;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ShadowOffsetProperty, value);
                }
                else 
                {
                    InternalShadowOffset = value;
                }
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
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(ShadowProperty, shadowMap);
                    }
                    else
                    {
                        SetInternalShadow(shadowMap);
                    }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ShadowColorProperty) as Vector4;
                }
                else
                {
                    return InternalShadowColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ShadowColorProperty, value);
                }
                else 
                {
                    InternalShadowColor = value;
                }
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
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(ShadowProperty, shadowMap);
                    }
                    else
                    {
                        SetInternalShadow(shadowMap);
                    }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(UnderlineEnabledProperty);
                }
                else
                {
                    return InternalUnderlineEnabled;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UnderlineEnabledProperty, value);
                }
                else 
                {
                    InternalUnderlineEnabled = value;
                }
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
                    var underlineMap = Underline;
                    underlineMap.Merge(map);
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(UnderlineProperty, underlineMap);
                    }
                    else
                    {
                        SetInternalUnderline(underlineMap);
                    }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(UnderlineColorProperty) as Vector4;
                }
                else
                {
                    return InternalUnderlineColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UnderlineColorProperty, value);
                }
                else 
                {
                    InternalUnderlineColor = value;
                }
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
                    var underlineMap = Underline;
                    underlineMap.Merge(map);
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(UnderlineProperty, underlineMap);
                    }
                    else
                    {
                        SetInternalUnderline(underlineMap);
                    }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(UnderlineHeightProperty);
                }
                else
                {
                    return InternalUnderlineHeight;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UnderlineHeightProperty, value);
                }
                else 
                {
                    InternalUnderlineHeight = value;
                }
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
                    var underlineMap = Underline;
                    underlineMap.Merge(map);
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(UnderlineProperty, underlineMap);
                    }
                    else
                    {
                        SetInternalUnderline(underlineMap);
                    }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableMarkupProperty);
                }
                else
                {
                    return GetInternalEnableMarkup();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableMarkupProperty, value);
                }
                else 
                {
                    SetInternalEnableMarkup(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableMarkup(bool newValue)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableMarkup, newValue);
        }

        private bool GetInternalEnableMarkup()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableMarkup);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableAutoScrollProperty);
                }
                else
                {
                    return GetInternalEnableAutoScroll();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableAutoScrollProperty, value);
                }
                else 
                {
                    SetInternalEnableAutoScroll(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableAutoScroll(bool newValue)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableAutoScroll, newValue);
        }

        private bool GetInternalEnableAutoScroll()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableAutoScroll);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(AutoScrollSpeedProperty);
                }
                else
                {
                    return GetInternalAutoScrollSpeed();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutoScrollSpeedProperty, value);
                }
                else 
                {
                    SetInternalAutoScrollSpeed(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAutoScrollSpeed(int newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.AutoScrollSpeed, newValue);
        }

        private int GetInternalAutoScrollSpeed()
        {
            return Object.InternalGetPropertyInt(SwigCPtr, Property.AutoScrollSpeed);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(AutoScrollLoopCountProperty);
                }
                else
                {
                    return GetInternalAutoScrollLoopCount();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutoScrollLoopCountProperty, value);
                }
                else 
                {
                    SetInternalAutoScrollLoopCount(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAutoScrollLoopCount(int newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.AutoScrollLoopCount, newValue);
        }

        private int GetInternalAutoScrollLoopCount()
        {
            return Object.InternalGetPropertyInt(SwigCPtr, Property.AutoScrollLoopCount);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(AutoScrollGapProperty);
                }
                else
                {
                    return GetInternalAutoScrollGap();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutoScrollGapProperty, value);
                }
                else 
                {
                    SetInternalAutoScrollGap(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAutoScrollGap(float newValue)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.AutoScrollGap, newValue);
        }

        private float GetInternalAutoScrollGap()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.AutoScrollGap);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(LineSpacingProperty);
                }
                else
                {
                    return GetInternalLineSpacing();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LineSpacingProperty, value);
                }
                else 
                {
                    SetInternalLineSpacing(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalLineSpacing(float newValue)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.LineSpacing, (float)newValue);
            RequestLayout();
        }

        private float GetInternalLineSpacing()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.LineSpacing);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(RelativeLineHeightProperty);
                }
                else
                {
                    return GetInternalRelativeLineHeight();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RelativeLineHeightProperty, value);
                }
                else 
                {
                    SetInternalRelativeLineHeight(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalRelativeLineHeight(float newValue)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.RelativeLineHeight, newValue);
        }

        private float GetInternalRelativeLineHeight()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.RelativeLineHeight);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(UnderlineProperty);
                }
                else
                {
                    return GetInternalUnderline();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UnderlineProperty, value);
                }
                else 
                {
                    SetInternalUnderline(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalUnderline(PropertyMap map)
        {
            if (map != null)
            {
                using var pv = new PropertyValue(map);
                Object.SetProperty(SwigCPtr, Property.UNDERLINE, pv);
            }
        }

        private PropertyMap GetInternalUnderline()
        {
            PropertyMap temp = new PropertyMap();
            using (var prop = Object.GetProperty(SwigCPtr, Property.UNDERLINE))
            {
                prop.Get(temp);
            }
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UnderlineProperty, underlineMap);
                }
                else
                {
                    SetInternalUnderline(underlineMap);
                }
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
            if (NUIApplication.IsUsingXaml)
            {
                var underlineMap = (PropertyMap)GetValue(UnderlineProperty);
                underline = TextMapHelper.GetUnderlineStruct(underlineMap);
            }
            else
            {
                using var underlineMap = GetInternalUnderline();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(ShadowProperty);
                }
                else
                {
                    return GetInternalShadow();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ShadowProperty, value);
                }
                else 
                {
                    SetInternalShadow(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalShadow(PropertyMap map)
        {
            if (map != null)
            {
                using var pv = new PropertyValue(map);
                Object.SetProperty(SwigCPtr, Property.SHADOW, pv);
            }
        }

        private PropertyMap GetInternalShadow()
        {
            PropertyMap temp = new PropertyMap();
            using (var prop = Object.GetProperty(SwigCPtr, Property.SHADOW))
            {
                prop.Get(temp);
            }
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ShadowProperty, shadowMap);
                }
                else
                {
                    SetInternalShadow(shadowMap);
                }
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
            if (NUIApplication.IsUsingXaml)
            {
                var shadowMap = (PropertyMap)GetValue(ShadowProperty);
                shadow = TextMapHelper.GetShadowStruct(shadowMap);
            }
            else
            {
                using var shadowMap = GetInternalShadow();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (TextShadow)GetValue(TextShadowProperty);
                }
                else
                {
                    return GetInternalTextShadow();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextShadowProperty, value);
                }
                else 
                {
                    SetInternalTextShadow(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalTextShadow(TextShadow shadow)
        {
            selectorData?.TextShadow?.Reset(this);
            SetTextShadow(shadow);
        }

        private TextShadow GetInternalTextShadow()
        {
            using PropertyMap temp = new PropertyMap();
            using var prop = Object.GetProperty(SwigCPtr, Property.SHADOW);
            prop.Get(temp);
            return temp.Empty() ? null : new TextShadow(temp);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(EmbossProperty);
                }
                else
                {
                    return GetInternalEmboss();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EmbossProperty, value);
                }
                else 
                {
                    SetInternalEmboss(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEmboss(string newValue)
        {
            if (newValue != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.EMBOSS, newValue);
            }
        }

        private string GetInternalEmboss()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.EMBOSS);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(OutlineProperty);
                }
                else
                {
                    return GetInternalOutline();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OutlineProperty, value);
                }
                else 
                {
                    SetInternalOutline(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalOutline(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.OUTLINE, pv);
            }
        }

        private PropertyMap GetInternalOutline()
        {
            PropertyMap temp = new PropertyMap();
            using (var prop = Object.GetProperty(SwigCPtr, Property.OUTLINE))
            {
                prop.Get(temp);
            }
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OutlineProperty, outlineMap);
                }
                else
                {
                    SetInternalOutline(outlineMap);
                }
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
            using (var outlineMap = NUIApplication.IsUsingXaml ? (PropertyMap)GetValue(OutlineProperty) : (PropertyMap)GetInternalOutlineProperty(this))
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(PixelSizeProperty);
                }
                else
                {
                    return GetInternalPixelSize();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PixelSizeProperty, value);
                }
                else 
                {
                    SetInternalPixelSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPixelSize(float newValue)
        {
            selectorData?.PixelSize?.Reset(this);
            SetPixelSize(newValue);
        }

        private float GetInternalPixelSize()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.PixelSize);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EllipsisProperty);
                }
                else
                {
                    return GetInternalEllipsis();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EllipsisProperty, value);
                }
                else 
                {
                    SetInternalEllipsis(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEllipsis(bool newValue)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.ELLIPSIS, newValue);
        }

        private bool GetInternalEllipsis()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.ELLIPSIS);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (EllipsisPosition)GetValue(EllipsisPositionProperty);
                }
                else
                {
                    return GetInternalEllipsisPosition();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EllipsisPositionProperty, value);
                }
                else 
                {
                    SetInternalEllipsisPosition(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEllipsisPosition(EllipsisPosition newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.EllipsisPosition, (int)newValue);
        }

        private EllipsisPosition GetInternalEllipsisPosition()
        {
            return (EllipsisPosition)Object.InternalGetPropertyInt(SwigCPtr, Property.EllipsisPosition);
        }

        /// <summary>
        /// The EllipsisMode property.
        /// </summary>
        /// <remarks>
        /// This property is valid when Ellipsis is true.<br />
        /// Truncate(default), if the text exceeds the layout, it will be truncated with an ellipsis.<br />
        /// AutoScroll, if the text exceeds the layout, it will be auto scroll animated.<br />
        /// EllipsisMode.AutoScroll shares the properties of AutoScroll Animation: AutoScrollSpeed, AutoScrollLoopCount, AutoScrollGap, AutoScrollLoopDelay<br />
        /// EllipsisMode.AutoScroll forces the setting of AutoScrollStopMode to Immediate.<br />
        /// To dynamically turn off EllipsisMode.AutoScroll, set EllipsisMode.Truncate.<br />
        /// Cannot be used simultaneously with EnableAutoScroll.<br />
        /// This property supports get/set operations in XAML scripts, but does not support XAML Data Binding functionality.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EllipsisMode EllipsisMode
        {
            get
            {
                return (EllipsisMode)Object.InternalGetPropertyInt(this.SwigCPtr, TextLabel.Property.EllipsisMode);
            }
            set
            {
                Object.InternalSetPropertyInt(this.SwigCPtr, TextLabel.Property.EllipsisMode, (int)value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether the auto scroll animation is playing or not.
        /// </summary>
        /// <remarks>
        /// This property supports get operations in XAML scripts, but does not support XAML Data Binding functionality.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsScrolling
        {
            get => Object.InternalGetPropertyBool(SwigCPtr, Property.IsScrolling);
        }

        /// <summary>
        /// Renders a texture at a specified scale to prevent text rendering quality degradation when scaling up with View.Scale.
        /// </summary>
        /// <remarks>
        /// RenderScale is only available in TextRenderMode.AsyncAuto and TextRenderMode.AsyncManual.<br />
        /// It is only valid when set to 1.0 or greater.<br />
        /// This property scales up the point size and texture size to the specified scale.<br />
        /// For example, the results of the rendered textures below are nearly identical:<br />
        /// FontSize: 20, RenderScale: 1.5<br />
        /// FontSize: 20, FontSizeScale: 1.5<br />
        /// However, the texture rendered with the specified RenderScale is downscaled to the original(1.0 scale) size and applied to the visual transform.<br />
        /// When the texture is increased by View.Scale, its size becomes 100%, ensuring high-quality rendering.<br />
        /// To achieve optimal text rendering results when using View.Scale, RenderScale should be set to the same value.
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the RenderScale.
        /// <code>
        /// label.FocusGained += (s, e) =>
        /// {
        ///     float scaleUp = 1.5f;
        ///     label.RenderScale = scaleUp;
        ///     scaleAnimation = new Animation(200);
        ///     scaleAnimation.AnimateTo(label, "scale", new Vector3(scaleUp, scaleUp, 1.0f));
        ///     scaleAnimation.Play();
        /// };
        /// label.FocusLost += (s, e) =>
        /// {
        ///     float normalScale = 1.0f;
        ///     label.RenderScale = normalScale;
        ///     scaleAnimation = new Animation(200);
        ///     scaleAnimation.AnimateTo(label, "scale", new Vector3(normalScale, normalScale, 1.0f));
        ///     scaleAnimation.Play();
        /// };
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float RenderScale
        {
            get
            {
                return (float)Object.InternalGetPropertyFloat(this.SwigCPtr, Property.RenderScale);
            }
            set
            {
                Object.InternalSetPropertyFloat(this.SwigCPtr, Property.RenderScale, (float)value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// A factor of pixel snap.
        /// </summary>
        /// <remarks>
        /// It should be 0.0 ~ 1.0.<br />
        /// Controls the degree of pixel snapping applied to the visual position.<br />
        /// A value of 0.0 means no snapping is applied (original position is preserved), while 1.0 applies full pixel alignment.<br />
        /// Intermediate values blend smoothly between the original and snapped positions using linear interpolation (mix) in the vertex shader.<br />
        /// Typical usage:<br />
        /// To ensure both smooth animations and sharp visual alignment,<br />
        /// transition the pixelSnapFactor value gradually from 0.0 to 1.0 during or after animations.<br />
        /// This allows the snapping to engage seamlessly without visible jitter or popping, maintaining both visual quality and motion fluidity.<br />
        /// Use 0.0 during animation to avoid snapping artifacts.<br />
        /// Gradually increase to 1.0 as the animation settles, for crisp pixel alignment.
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the PixelSnapFactor with RenderScale.
        /// <code>
        /// label.FocusGained += (s, e) =>
        /// {
        ///     float scaleUp = 1.5f;
        ///     label.RenderScale = scaleUp;
        ///     scaleAnimation = new Animation(200);
        ///     scaleAnimation.AnimateTo(label, "scale", new Vector3(scaleUp, scaleUp, 1.0f));
        ///     scaleAnimation.Play();
        ///
        ///     pixelSnapAnimation = new Animation(200);
        ///     pixelSnapAnimation.AnimateTo(label, "pixelSnapFactor", 1.0f);
        ///     pixelSnapAnimation.Play();
        /// };
        /// label.FocusLost += (s, e) =>
        /// {
        ///     float normalScale = 1.0f;
        ///     label.RenderScale = normalScale;
        ///     scaleAnimation = new Animation(200);
        ///     scaleAnimation.AnimateTo(label, "scale", new Vector3(normalScale, normalScale, 1.0f));
        ///     scaleAnimation.Play();
        ///
        ///     pixelSnapAnimation = new Animation(200);
        ///     pixelSnapAnimation.AnimateTo(label, "pixelSnapFactor", 0.0f);
        ///     pixelSnapAnimation.Play();
        /// };
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float PixelSnapFactor
        {
            get
            {
                return (float)Object.InternalGetPropertyFloat(this.SwigCPtr, Property.PixelSnapFactor);
            }
            set
            {
                Object.InternalSetPropertyFloat(this.SwigCPtr, Property.PixelSnapFactor, (float)value);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(AutoScrollLoopDelayProperty);
                }
                else
                {
                    return GetInternalAutoScrollLoopDelay();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutoScrollLoopDelayProperty, value);
                }
                else 
                {
                    SetInternalAutoScrollLoopDelay(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAutoScrollLoopDelay(float newValue)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.AutoScrollLoopDelay, newValue);
        }

        private float GetInternalAutoScrollLoopDelay()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.AutoScrollLoopDelay);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (AutoScrollStopMode)GetValue(AutoScrollStopModeProperty);
                }
                else
                {
                    return GetInternalAutoScrollStopMode();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutoScrollStopModeProperty, value);
                }
                else 
                {
                    SetInternalAutoScrollStopMode(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAutoScrollStopMode(AutoScrollStopMode newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.AutoScrollStopMode, (int)newValue);
        }

        private AutoScrollStopMode GetInternalAutoScrollStopMode()
        {
            string temp = Object.InternalGetPropertyString(SwigCPtr, Property.AutoScrollStopMode);
            return temp.GetValueByDescription<AutoScrollStopMode>();
        }

        /// <summary>
        /// Gets the line count of the text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int LineCount
        {
            get => Object.InternalGetPropertyInt(SwigCPtr, Property.LineCount);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (LineWrapMode)GetValue(LineWrapModeProperty);
                }
                else
                {
                    return GetInternalLineWrapMode();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LineWrapModeProperty, value);
                }
                else 
                {
                    SetInternalLineWrapMode(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalLineWrapMode(LineWrapMode newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.LineWrapMode, (int)newValue);
        }

        private LineWrapMode GetInternalLineWrapMode()
        {
            return (LineWrapMode)Object.InternalGetPropertyInt(SwigCPtr, Property.LineWrapMode);
        }

        /// <summary>
        /// The direction of the text such as left to right or right to left.
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextDirection TextDirection
        {
            get => (TextDirection)Object.InternalGetPropertyInt(SwigCPtr, Property.TextDirection);
        }

        /// <summary>
        /// The vertical line alignment of the text.
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalLineAlignment VerticalLineAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (VerticalLineAlignment)GetValue(VerticalLineAlignmentProperty);
                }
                else
                {
                    return GetInternalVerticalLineAlignment();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(VerticalLineAlignmentProperty, value);
                }
                else 
                {
                    SetInternalVerticalLineAlignment(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalVerticalLineAlignment(VerticalLineAlignment newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.VerticalLineAlignment, (int)newValue);
        }

        private VerticalLineAlignment GetInternalVerticalLineAlignment()
        {
            return (VerticalLineAlignment)Object.InternalGetPropertyInt(SwigCPtr, Property.VerticalLineAlignment);
        }

        /// <summary>
        /// The text alignment to match the direction of the system language.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool MatchSystemLanguageDirection
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(MatchSystemLanguageDirectionProperty);
                }
                else
                {
                    return GetInternalMatchSystemLanguageDirection();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MatchSystemLanguageDirectionProperty, value);
                }
                else 
                {
                    SetInternalMatchSystemLanguageDirection(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalMatchSystemLanguageDirection(bool newValue)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.MatchSystemLanguageDirection, newValue);
        }

        private bool GetInternalMatchSystemLanguageDirection()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.MatchSystemLanguageDirection);
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
        /// This will be public opened after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
        public PropertyMap TextFit
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(TextFitProperty);
                }
                else
                {
                    return GetInternalTextFit();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextFitProperty, value);
                }
                else 
                {
                    SetInternalTextFit(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalTextFit(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.TextFit, pv);
            }
        }

        private PropertyMap GetInternalTextFit()
        {
            PropertyMap temp = new PropertyMap();
            using (var prop = Object.GetProperty(SwigCPtr, Property.TextFit))
            {
                prop.Get(temp);
            }
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextFitProperty, textFitMap);
                }
                else
                {
                    SetInternalTextFit(textFitMap);
                }
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
            if (NUIApplication.IsUsingXaml)
            {
                var textFitMap = (PropertyMap)GetValue(TextFitProperty);
                textFit = TextMapHelper.GetTextFitStruct(textFitMap);
            }
            else
            {
                using var textFitMap = GetInternalTextFit();
                textFit = TextMapHelper.GetTextFitStruct(textFitMap);
            }
            return textFit;
        }

        /// <summary>
        /// Set TextFitArray to TextLabel. <br />
        /// TextFitArray finds and applies the largest PointSize that fits among OptionList.
        /// </summary>
        /// <param name="textFitArray">The TextFitArray</param>
        /// <remarks>
        /// TextFitArray tries binary search by default. <br />
        /// The precondition for TextFitArray to perform binary search is sorting in ascending order of MinLineSize. <br />
        /// Because if MinLineSize is not sorted in ascending order, <br />
        /// binary search cannot guarantee that it will always find the best value. <br />
        /// In this case, the search sequentially starts from the largest PointSize. <br />
        /// If TextFitArrayOption's MinLineSize is set to null or 0, <br />
        /// TextFitArray is calculated without applying MinLineSize. <br />
        /// If TextFitArray is enabled, TextLabel's MinLineSize property is ignored. <br />
        /// See <see cref="Tizen.NUI.Text.TextFitArray"/> and <see cref="Tizen.NUI.Text.TextFitArrayOption"/>.
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetTextFitArray method. <br />
        /// <code>
        /// var textFitArray = new Tizen.NUI.Text.TextFitArray();
        /// textFitArray.Enable = true;
        /// textFitArray.OptionList = new List&lt;Tizen.NUI.Text.TextFitArrayOption&gt;()
        /// {
        ///     new Tizen.NUI.Text.TextFitArrayOption(12, 18),
        ///     new Tizen.NUI.Text.TextFitArrayOption(24, 40),
        ///     new Tizen.NUI.Text.TextFitArrayOption(28, 48),
        ///     new Tizen.NUI.Text.TextFitArrayOption(32, 56),
        ///     new Tizen.NUI.Text.TextFitArrayOption(50, 72),
        /// };
        /// label.SetTextFitArray(textFitArray);
        /// </code>
        /// <br />
        /// The table below shows cases where binary search is possible and where it is not possible. <br />
        /// <code>
        /// [Binary search possible]
        /// |            | List index  |  0 |  1 |  2 |  3 |
        /// | OptionList | PointSize   | 24 | 28 | 32 | 48 |
        /// |            | MinLineSize | 40 | 48 | 48 | 62 | &lt;&lt; MinLineSize sorted in ascending order
        ///                                    ^    ^
        ///                                    same values ​are not a problem
        ///
        /// [Binary search not possible]
        /// |            | List index  |  0 |  1 |  2 |  3 |
        /// | OptionList | PointSize   | 24 | 28 | 32 | 48 |
        /// |            | MinLineSize | 40 | 48 | 38 | 62 | &lt;&lt; MinLineSize is not sorted in ascending order
        ///                                         ^
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTextFitArray(TextFitArray textFitArray)
        {
            bool enable = textFitArray.Enable;
            int optionListSize = textFitArray.OptionList?.Count ?? 0;

            float[] pointSizeArray = new float[optionListSize];
            float[] minLineSizeArray = new float[optionListSize];

            for (int i = 0 ; i < optionListSize ; i ++)
            {
                TextFitArrayOption option = textFitArray.OptionList[i];
                pointSizeArray[i] = option.PointSize;
                minLineSizeArray[i] = option.MinLineSize ?? 0;
            }

            Interop.TextLabel.SetTextFitArray(SwigCPtr, enable, (uint)optionListSize, pointSizeArray, minLineSizeArray);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get TextFitArray from TextLabel.
        /// </summary>
        /// <returns>The TextFitArray</returns>
        /// <remarks>
        /// See <see cref="Tizen.NUI.Text.TextFitArray"/> and <see cref="Tizen.NUI.Text.TextFitArrayOption"/>.
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the GetTextFitArray method. <br />
        /// <code>
        /// Tizen.NUI.Text.TextFitArray textFitArray = label.GetTextFitArray();
        /// bool enable = textFitArray.Enable;
        /// var optionList = textFitArray.OptionList;
        /// foreach(Tizen.NUI.Text.TextFitArrayOption option in optionList)
        /// {
        ///     float pointSize = option.PointSize;
        ///     float minLinesize = option.MinLineSize;
        /// }
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextFitArray GetTextFitArray()
        {
            using PropertyMap textFitArrayMap = new PropertyMap(Interop.TextLabel.GetTextFitArray(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            TextFitArray textFitArray;
            textFitArray = TextUtils.GetMapToTextFitArray(textFitArrayMap);
            return textFitArray;
        }

        /// <summary>
        /// The MinLineSize property.<br />
        /// The height of the line in points. <br />
        /// If the font size is larger than the line size, it works with the font size. <br />
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MinLineSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(MinLineSizeProperty);
                }
                else
                {
                    return GetInternalMinLineSize();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MinLineSizeProperty, value);
                }
                else 
                {
                    SetInternalMinLineSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalMinLineSize(float size)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.MinLineSize, size);
            RequestLayout();
        }

        private float GetInternalMinLineSize()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.MinLineSize);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(CharacterSpacingProperty);
                }
                else
                {
                    return GetInternalCharacterSpacing();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CharacterSpacingProperty, value);
                }
                else 
                {
                    SetInternalCharacterSpacing(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCharacterSpacing(float space)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.CharacterSpacing, space);
        }

        private float GetInternalCharacterSpacing()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.CharacterSpacing);
        }

        /// <summary>
        /// The AnchorColor property.<br />
        /// The color of the anchor.<br />
        /// This property is used as the default color of the markup anchor tag.<br />
        /// If there is a color attribute in the markup anchor tag, the markup attribute takes precedence.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textLabel.AnchorColor.X = 0.1f;) is possible.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color AnchorColor
        {
            get
            {
                Color color;
                if (NUIApplication.IsUsingXaml)
                {
                    color = (Color)GetValue(AnchorColorProperty);
                }
                else
                {
                    color = GetInternalAnchorColor();
                }
                return new Color(OnAnchorColorChanged, color.R, color.G, color.B, color.A);
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AnchorColorProperty, value);
                }
                else 
                {
                    SetInternalAnchorColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAnchorColor(Color color)
        {
            if (color != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, Property.AnchorColor, color.SwigCPtr);
            }
        }

        private Color GetInternalAnchorColor()
        {
            if (internalAnchorColor == null)
            {
                internalAnchorColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Property.TextColor, internalAnchorColor.SwigCPtr);
            return internalAnchorColor;
        }

        /// <summary>
        /// The AnchorClickedColor property.<br />
        /// The color of the clicked anchor.<br />
        /// This property is used as the default clicked color of the markup anchor tag.<br />
        /// If there is a color attribute in the markup anchor tag, the markup attribute takes precedence.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textLabel.AnchorClickedColor.X = 0.1f;) is possible.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color AnchorClickedColor
        {
            get
            {
                Color color;
                if (NUIApplication.IsUsingXaml)
                {
                    color = (Color)GetValue(AnchorClickedColorProperty);
                }
                else
                {
                    color = GetInternalAnchorClickedColor();
                }
                return new Color(OnAnchorClickedColorChanged, color.R, color.G, color.B, color.A);
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AnchorClickedColorProperty, value);
                }
                else 
                {
                    SetInternalAnchorClickedColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAnchorClickedColor(Color color)
        {
            if (color != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, Property.AnchorClickedColor, color.SwigCPtr);
            }
        }

        private Color GetInternalAnchorClickedColor()
        {
            if (internalAnchorClickedColor == null)
            {
                internalAnchorClickedColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Property.TextColor, internalAnchorClickedColor.SwigCPtr);
            return internalAnchorClickedColor;
        }

        /// <summary>
        /// The RemoveFrontInset property.<br />
        /// This property is used when the xBearing of first glyph must not be trimmed.<br />
        /// When set to false, The gap between (0, 0) from the first glyph's leftmost pixel is included in the width of text label.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemoveFrontInset
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(RemoveFrontInsetProperty);
                }
                else
                {
                    return GetInternalRemoveFrontInset();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RemoveFrontInsetProperty, value);
                }
                else 
                {
                    SetInternalRemoveFrontInset(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalRemoveFrontInset(bool remove)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.RemoveFrontInset, remove);
        }

        private bool GetInternalRemoveFrontInset()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.RemoveFrontInset);
        }

        /// <summary>
        /// The RemoveBackInset property.<br />
        /// This property is used when the advance of last glyph must not be trimmed.<br />
        /// When set to false, The gap between the last glyph's rightmost pixel and X coordinate that next glyph will be placed is included in the width of text label.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemoveBackInset
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(RemoveBackInsetProperty);
                }
                else
                {
                    return GetInternalRemoveBackInset();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RemoveBackInsetProperty, value);
                }
                else 
                {
                    SetInternalRemoveBackInset(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalRemoveBackInset(bool newValue)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.RemoveBackInset, newValue);
        }

        private bool GetInternalRemoveBackInset()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.RemoveBackInset);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(FontSizeScaleProperty);
                }
                else
                {
                    return InternalFontSizeScale;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontSizeScaleProperty, value);
                }
                else 
                {
                    InternalFontSizeScale = value;
                }
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
                if (fontSizeScale == value) return;
                fontSizeScale = value;

                float newFontSizeScale;
                if (fontSizeScale == Tizen.NUI.FontSizeScale.UseSystemSetting)
                {
                    var systemSettingsFontSize = SystemFontSizeChangedManager.FontSize;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableFontSizeScaleProperty);
                }
                else
                {
                    return GetInternalEnableFontSizeScale();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableFontSizeScaleProperty, value);
                }
                else 
                {
                    SetInternalEnableFontSizeScale(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableFontSizeScale(bool enable)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableFontSizeScale, enable);
            RequestLayout();
        }

        private bool GetInternalEnableFontSizeScale()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableFontSizeScale);
        }

        /// <summary>
        /// The cutout property.
        /// </summary>
        /// <remarks>
        /// When Cutout is set to true, Elements such as background or shadow behind the text become transparent.<br />
        /// Therefore, when you adjust the transparency of text, you can see the back through the entire TextLabel.<br />
        /// It is recommended to set Cutout to false when Text's transparency is 1.<br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the Cutout method. <br />
        /// Pixels in which glyph exists become transparent and the back of TextLabel become visible.<br />
        /// <code>
        /// TextLabel label = new TextLabel()
        /// {
        ///     Cutout = true,
        ///     TextColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        /// };
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Cutout
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(CutoutProperty);
                }
                else
                {
                    return GetInternalCutout();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CutoutProperty, value);
                }
                else
                {
                    SetInternalCutout(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCutout(bool cutout)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.Cutout, cutout);
        }

        private bool GetInternalCutout()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.Cutout);
        }

        /// <summary>
        /// The RenderMode property.
        /// </summary>
        /// <remarks>
        /// Sync : default, synchronous text loading.<br />
        /// AsyncAuto : automatically requests an asynchronous text load in OnRelayout.<br />
        /// AsyncManual : users should manually request rendering using the async text method.<br />
        /// All text rendering processes (update/layout/render) are performed asynchronously in AsyncAuto and AsyncManual.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextRenderMode RenderMode
        {
            get
            {
                return (TextRenderMode)Object.InternalGetPropertyInt(this.SwigCPtr, TextLabel.Property.RenderMode);
            }
            set
            {
                Object.InternalSetPropertyInt(this.SwigCPtr, TextLabel.Property.RenderMode, (int)value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether the last async rendering result is a manual render. <br />
        /// If it's false, the render result was automatically requested by OnRelayout.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ManualRendered
        {
            get => Object.InternalGetPropertyBool(SwigCPtr, Property.ManualRendered);
        }

        /// <summary>
        /// Whether a render request is required when render mode is AsyncManual.
        /// </summary>
        private bool NeedRequestAsyncRender
        {
            get => Object.InternalGetPropertyBool(SwigCPtr, Property.NeedRequestAsyncRender);
        }

        /// <summary>
        /// Number of lines after latest asynchronous computing or rendering of text.
        /// </summary>
        /// <example>
        /// The following example demonstrates how to obtain the LineCount asynchronously.
        /// <code>
        /// label.RequestAsyncHeightForWidth(label.Size.Width);
        /// label.AsyncHeightForWidthComputed += (s, e) =>
        /// {
        ///    int lineCount = label.AsyncLineCount;
        /// };
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int AsyncLineCount
        {
            get => Object.InternalGetPropertyInt(SwigCPtr, Property.AsyncLineCount);
        }

        /// <summary>
        /// The LayoutDirectionPolicy property.
        /// </summary>
        /// <remarks>
        /// Inherit : The text layout direction is inherited. If you change the layout direction, it will be aligned with the changed layout direction.<br />
        /// Locale : The text layout direction is determined by the locale of the system language.<br />
        /// Contents : The text layout direction is determined by the text itself.<br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLayoutDirectionPolicy LayoutDirectionPolicy
        {
            get
            {
                return (TextLayoutDirectionPolicy)Object.InternalGetPropertyInt(this.SwigCPtr, TextLabel.Property.LayoutDirectionPolicy);
            }
            set
            {
                Object.InternalSetPropertyInt(this.SwigCPtr, TextLabel.Property.LayoutDirectionPolicy, (int)value);
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

        /// <summary>
        /// Registers FontVariationsProperty with string tag.
        /// </summary>
        /// <param name="tag">The tag of font variation.</param>
        /// <returns>The index of the font variation.</returns>
        /// <remarks>
        /// The returned index can be used with setting property or animations.
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetFontStyle method.
        /// <code>
        /// TextLabel label = new TextLabel();
        /// int index = label.RegisterFontVariationProperty("wght");
        /// Animation anim = new Animation(1000);
        /// anim.AnimateTo(label, "wght", 900.0f);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RegisterFontVariationProperty(string tag)
        {
            int index = Interop.TextLabel.RegisterFontVariationProperty(SwigCPtr, tag);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return index;
        }

        /// <summary>
        /// Sets Font Variation with string tag.
        /// </summary>
        /// <param name="tag">The tag of font variation.</param>
        /// <param name="value">The value of font variation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFontVariation(string tag, float value)
        {
            int index = RegisterFontVariationProperty(tag);
            Object.InternalSetPropertyFloat(SwigCPtr, index, value);
        }

        /// <summary>
        /// Sets Font Variation with index.
        /// </summary>
        /// <param name="index">The index of font variation property.</param>
        /// <param name="value">The value of font variation.</param>
        /// <remarks>
        /// To use the index, RegisterFontVariationProperty must precede it.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFontVariation(int index, float value)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, index, value);
        }

        /// <summary>
        /// Sets mask Effect to given view.
        /// </summary>
        /// <param name="control">The control to set mask effect.</param>
        /// <note>
        /// SetMaskEffect uses the TextLabel's camera to render both label and control.<br />
        /// To apply the mask correctly, align the control's size and position with the TextLabel.<br />
        /// </note>
        /// <remarks>
        /// After this operation, the Textlabel will be parent of the control.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMaskEffect(View control)
        {
            Interop.TextLabel.SetMaskEffect(SwigCPtr, control.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            internalAnchorColor?.Dispose();
            internalAnchorClickedColor?.Dispose();

            RemoveSystemSettingsLocaleLanguageChanged();
            RemoveSystemSettingsFontTypeChanged();
            RemoveSystemSettingsFontSizeChanged();
            RemoveAsyncTextRendered();

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                selectorData?.Reset(this);
            }

            if (this.HasBody())
            {
                if (textLabelAnchorClickedCallbackDelegate != null)
                {
                    using var signal = AnchorClickedSignal();
                    signal.Disconnect(textLabelAnchorClickedCallbackDelegate);
                }

                if (textLabelTextFitChangedCallbackDelegate != null)
                {
                    using var signal = TextFitChangedSignal();
                    signal.Disconnect(textLabelTextFitChangedCallbackDelegate);
                }

                if (textLabelAsyncTextRenderedCallbackDelegate != null)
                {
                    Interop.TextLabel.AsyncTextRenderedDisconnect(this.SwigCPtr, textLabelAsyncTextRenderedCallbackDelegate.ToHandleRef(this));
                    textLabelAsyncTextRenderedCallbackDelegate = null;
                }

                if (textLabelAsyncNaturalSizeComputedCallbackDelegate != null)
                {
                    Interop.TextLabel.AsyncNaturalSizeComputedDisconnect(this.SwigCPtr, textLabelAsyncNaturalSizeComputedCallbackDelegate.ToHandleRef(this));
                    textLabelAsyncNaturalSizeComputedCallbackDelegate = null;
                }

                if (textLabelAsyncHeightForWidthComputedCallbackDelegate != null)
                {
                    Interop.TextLabel.AsyncHeightForWidthComputedDisconnect(this.SwigCPtr, textLabelAsyncHeightForWidthComputedCallbackDelegate.ToHandleRef(this));
                    textLabelAsyncHeightForWidthComputedCallbackDelegate = null;
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
            return new TextLabelLayout();
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

        private void AddSystemSettingsLocaleLanguageChanged()
        {
            if (!hasSystemLanguageChanged)
            {
                SystemLocaleLanguageChangedManager.Add(SystemSettingsLocaleLanguageChanged);
                hasSystemLanguageChanged = true;
            }
        }
        
        private void RemoveSystemSettingsLocaleLanguageChanged()
        {
            if (hasSystemLanguageChanged)
            {
                SystemLocaleLanguageChangedManager.Remove(SystemSettingsLocaleLanguageChanged);
                hasSystemLanguageChanged = false;
            }
        }

        private void SystemSettingsFontSizeChanged(object sender, FontSizeChangedEventArgs e)
        {
            float newFontSizeScale = TextUtils.GetFontSizeScale(e.Value);
            SetInternalFontSizeScale(newFontSizeScale);
        }

        private void AddSystemSettingsFontSizeChanged()
        {
            if (!hasSystemFontSizeChanged)
            {
                SystemFontSizeChangedManager.Add(SystemSettingsFontSizeChanged);
                hasSystemFontSizeChanged = true;
            }
        }

        private void RemoveSystemSettingsFontSizeChanged()
        {
            if (hasSystemFontSizeChanged)
            {
                SystemFontSizeChangedManager.Remove(SystemSettingsFontSizeChanged);
                hasSystemFontSizeChanged = false;
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
                SystemFontTypeChangedManager.Add(SystemSettingsFontTypeChanged);
                hasSystemFontTypeChanged = true;
            }
        }
        
        private void RemoveSystemSettingsFontTypeChanged()
        {
            if (hasSystemFontTypeChanged)
            {
                SystemFontTypeChangedManager.Remove(SystemSettingsFontTypeChanged);
                hasSystemFontTypeChanged = false;
            }
        }

        private void AddAsyncTextRendered()
        {
            if (!hasAsyncTextRendered && Layout is TextLabelLayout layoutItem && layoutItem != null)
            {
                AsyncTextRendered += layoutItem.OnAsyncTextRendered;
                hasAsyncTextRendered = true;
            }
        }

        private void RemoveAsyncTextRendered()
        {
            if (hasAsyncTextRendered && Layout is TextLabelLayout layoutItem && layoutItem != null)
            {
                AsyncTextRendered -= layoutItem.OnAsyncTextRendered;
                hasAsyncTextRendered = false;
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
            internal static readonly int AnchorColor = Interop.TextLabel.AnchorColorGet();
            internal static readonly int AnchorClickedColor = Interop.TextLabel.AnchorClickedColorGet();
            internal static readonly int RemoveFrontInset = Interop.TextLabel.RemoveFrontInsetGet();
            internal static readonly int RemoveBackInset = Interop.TextLabel.RemoveBackInsetGet();
            internal static readonly int Cutout = Interop.TextLabel.CutoutGet();
            internal static readonly int RenderMode = Interop.TextLabel.RenderModeGet();
            internal static readonly int LayoutDirectionPolicy = Interop.TextLabel.LayoutDirectionPolicyGet();
            internal static readonly int ManualRendered = Interop.TextLabel.ManualRenderedGet();
            internal static readonly int NeedRequestAsyncRender = Interop.TextLabel.NeedRequestAsyncRenderGet();
            internal static readonly int AsyncLineCount = Interop.TextLabel.AsyncLineCountGet();
            internal static readonly int EllipsisMode = Interop.TextLabel.EllipsisModeGet();
            internal static readonly int IsScrolling = Interop.TextLabel.IsScrollingGet();
            internal static readonly int RenderScale = Interop.TextLabel.RenderScaleGet();
            internal static readonly int PixelSnapFactor = Interop.TextLabel.PixelSnapFactorGet();


            internal static void Preload()
            {
                // Do nothing. Just call for load static values.
            }
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
        private void OnAnchorColorChanged(float r, float g, float b, float a)
        {
            AnchorColor = new Color(r, g, b, a);
        }
        private void OnAnchorClickedColorChanged(float r, float g, float b, float a)
        {
            AnchorClickedColor = new Color(r, g, b, a);
        }
    }
}
