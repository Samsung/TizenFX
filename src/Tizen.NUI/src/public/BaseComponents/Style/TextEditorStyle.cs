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
using System;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The style class for TextEditor.
    /// This can decorate a TextEditor instance.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextEditorStyle : ViewStyle
    {
        /// <summary> The bindable property of FontFamily. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).fontFamily = (string)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).fontFamily);

        /// <summary> The bindable property of PointSize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).pointSize = (float?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).pointSize);

        /// <summary> The bindable property of PixelSize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).pixelSize = (float?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).pixelSize);

        /// <summary> The bindable property of TextColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Vector4), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).textColor = (Vector4)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).textColor);

        /// <summary> The bindable property of PlaceholderTextColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create(nameof(PlaceholderTextColor), typeof(Color), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).placeholderTextColor = (Color)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).placeholderTextColor);

        /// <summary> The bindable property of PrimaryCursorColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty PrimaryCursorColorProperty = BindableProperty.Create(nameof(PrimaryCursorColor), typeof(Vector4), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).primaryCursorColor = (Vector4)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).primaryCursorColor);

        /// <summary> The bindable property of HorizontalAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).horizontalAlignment = (HorizontalAlignment?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).horizontalAlignment);

        /// <summary> The bindable property of VerticalAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).verticalAlignment = (VerticalAlignment?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).verticalAlignment);

        /// <summary> The bindable property of SecondaryCursorColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SecondaryCursorColorProperty = BindableProperty.Create(nameof(SecondaryCursorColor), typeof(Vector4), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).secondaryCursorColor = (Vector4)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).secondaryCursorColor);

        /// <summary> The bindable property of EnableCursorBlink. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty EnableCursorBlinkProperty = BindableProperty.Create(nameof(EnableCursorBlink), typeof(bool?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).enableCursorBlink = (bool?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).enableCursorBlink);

        /// <summary> The bindable property of CursorBlinkInterval. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty CursorBlinkIntervalProperty = BindableProperty.Create(nameof(CursorBlinkInterval), typeof(float?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).cursorBlinkInterval = (float?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).cursorBlinkInterval);

        /// <summary> The bindable property of CursorBlinkDuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty CursorBlinkDurationProperty = BindableProperty.Create(nameof(CursorBlinkDuration), typeof(float?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).cursorBlinkDuration = (float?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).cursorBlinkDuration);

        /// <summary> The bindable property of CursorWidth. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static BindableProperty CursorWidthProperty = null;

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static BindableProperty GetCursorWidthProperty()
        {
            if(CursorWidthProperty == null)
            {
                CursorWidthProperty = BindableProperty.Create(nameof(CursorWidth), typeof(int?), typeof(TextEditorStyle), null,
                    propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).cursorWidth = (int?)newValue,
                    defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).cursorWidth);
            }
            return CursorWidthProperty;
        }

        /// <summary> The bindable property of GrabHandleColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty GrabHandleColorProperty = BindableProperty.Create(nameof(GrabHandleColor), typeof(Color), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).grabHandleColor = (Color)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).grabHandleColor);

        /// <summary> The bindable property of GrabHandleImage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty GrabHandleImageProperty = BindableProperty.Create(nameof(GrabHandleImage), typeof(string), typeof(TextEditorStyle), String.Empty,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).grabHandleImage = (string)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).grabHandleImage);

        /// <summary> The bindable property of GrabHandlePressedImage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty GrabHandlePressedImageProperty = BindableProperty.Create(nameof(GrabHandlePressedImage), typeof(string), typeof(TextEditorStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).grabHandlePressedImage = (string)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).grabHandlePressedImage);

        /// <summary> The bindable property of SelectionHandleImageLeft. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SelectionHandleImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).selectionHandleImageLeft = (PropertyMap)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).selectionHandleImageLeft);

        /// <summary> The bindable property of SelectionHandleImageRight. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SelectionHandleImageRightProperty = BindableProperty.Create(nameof(SelectionHandleImageRight), typeof(PropertyMap), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).selectionHandleImageRight = (PropertyMap)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).selectionHandleImageRight);

        /// <summary> The bindable property of ScrollThreshold. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ScrollThresholdProperty = BindableProperty.Create(nameof(ScrollThreshold), typeof(float?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).scrollThreshold = (float?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).scrollThreshold);

        /// <summary> The bindable property of ScrollSpeed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ScrollSpeedProperty = BindableProperty.Create(nameof(ScrollSpeed), typeof(float?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).scrollSpeed = (float?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).scrollSpeed);

        /// <summary> The bindable property of SelectionHighlightColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static BindableProperty SelectionHighlightColorProperty = null;

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static BindableProperty GetSelectionHighlightColorProperty()
        {
            if(SelectionHighlightColorProperty == null)
            {
                SelectionHighlightColorProperty = BindableProperty.Create(nameof(SelectionHighlightColor), typeof(Vector4), typeof(TextEditorStyle), null,
                    propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).selectionHighlightColor = (Vector4)newValue,
                    defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).selectionHighlightColor);
            }
            return SelectionHighlightColorProperty;
        }

        /// <summary> The bindable property of DecorationBoundingBox. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty DecorationBoundingBoxProperty = BindableProperty.Create(nameof(DecorationBoundingBox), typeof(Rectangle), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).decorationBoundingBox = (Rectangle)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).decorationBoundingBox);

        /// <summary> The bindable property of InputColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputColorProperty = BindableProperty.Create(nameof(InputColor), typeof(Vector4), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).inputColor = (Vector4)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).inputColor);


        /// <summary> The bindable property of InputFontFamily. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputFontFamilyProperty = BindableProperty.Create(nameof(InputFontFamily), typeof(string), typeof(TextEditorStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).inputFontFamily = (string)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).inputFontFamily);

        /// <summary> The bindable property of InputPointSize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputPointSizeProperty = BindableProperty.Create(nameof(InputPointSize), typeof(float?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).inputPointSize = (float?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).inputPointSize);

        /// <summary> The bindable property of InputUnderline. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputUnderlineProperty = BindableProperty.Create(nameof(InputUnderline), typeof(string), typeof(TextEditorStyle), String.Empty,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).inputUnderline = (string)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).inputUnderline);

        /// <summary> The bindable property of InputShadow. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputShadowProperty = BindableProperty.Create(nameof(InputShadow), typeof(string), typeof(TextEditorStyle), String.Empty,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).inputShadow = (string)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).inputShadow);

        /// <summary> The bindable property of Emboss. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextEditorStyle), String.Empty,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).emboss = (string)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).emboss);

        /// <summary> The bindable property of InputEmboss. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputEmbossProperty = BindableProperty.Create(nameof(InputEmboss), typeof(string), typeof(TextEditorStyle), String.Empty,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).inputEmboss = (string)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).inputEmboss);

        /// <summary> The bindable property of InputOutline. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputOutlineProperty = BindableProperty.Create(nameof(InputOutline), typeof(string), typeof(TextEditorStyle), String.Empty,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).inputOutline = (string)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).inputOutline);

        /// <summary> The bindable property of SmoothScroll. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SmoothScrollProperty = BindableProperty.Create(nameof(SmoothScroll), typeof(bool?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).smoothScroll = (bool?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).smoothScroll);

        /// <summary> The bindable property of SmoothScrollDuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SmoothScrollDurationProperty = BindableProperty.Create(nameof(SmoothScrollDuration), typeof(float?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).smoothScrollDuration = (float?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).smoothScrollDuration);

        /// <summary> The bindable property of EnableScrollBar. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty EnableScrollBarProperty = BindableProperty.Create(nameof(EnableScrollBar), typeof(bool?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).enableScrollBar = (bool?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).enableScrollBar);

        /// <summary> The bindable property of ScrollBarShowDuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ScrollBarShowDurationProperty = BindableProperty.Create(nameof(ScrollBarShowDuration), typeof(float?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).scrollBarShowDuration = (float?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).scrollBarShowDuration);

        /// <summary> The bindable property of ScrollBarFadeDuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ScrollBarFadeDurationProperty = BindableProperty.Create(nameof(ScrollBarFadeDuration), typeof(float?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).scrollBarFadeDuration = (float?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).scrollBarFadeDuration);

        /// <summary> The bindable property of EnableSelection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = BindableProperty.Create(nameof(EnableSelection), typeof(bool?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).enableSelection = (bool?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).enableSelection);

        /// <summary> The bindable property of MatchSystemLanguageDirection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(MatchSystemLanguageDirection), typeof(bool?), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).matchSystemLanguageDirection = (bool?)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).matchSystemLanguageDirection);

        /// <summary> The bindable property of FontStyleProperty. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextEditorStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((TextEditorStyle)bindable).fontStyle = (PropertyMap)newValue,
            defaultValueCreator: (bindable) => ((TextEditorStyle)bindable).fontStyle);

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = BindableProperty.Create(nameof(Ellipsis), typeof(bool?), typeof(TextEditorStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.ellipsis = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.ellipsis;
        });

        /// <summary> The bindable property of LineSpacingProperty. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float?), typeof(TextEditorStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.lineSpacing = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.lineSpacing;
        });

        /// <summary> The bindable property of MinLineSizeProperty. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinLineSizeProperty = BindableProperty.Create(nameof(MinLineSize), typeof(float?), typeof(TextEditorStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.minLineSize = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.minLineSize;
        });

        /// <summary> The bindable property of RelativeLineHeightProperty. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RelativeLineHeightProperty = BindableProperty.Create(nameof(RelativeLineHeight), typeof(float?), typeof(TextEditorStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.relativeLineHeight = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.relativeLineHeight;
        });

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = BindableProperty.Create(nameof(FontSizeScale), typeof(float?), typeof(TextEditorStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.fontSizeScale = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.fontSizeScale;
        });

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static BindableProperty SelectionPopupStyleProperty = null;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty GetSelectionPopupStyleProperty()
        {
            if(SelectionPopupStyleProperty == null)
            {
                SelectionPopupStyleProperty = BindableProperty.Create(nameof(SelectionPopupStyle), typeof(PropertyMap), typeof(TextEditorStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var textEditorStyle = (TextEditorStyle)bindable;
                    textEditorStyle.selectionPopupStyle = (PropertyMap)newValue;
                },
                defaultValueCreator: (bindable) =>
                {
                    var textEditorStyle = (TextEditorStyle)bindable;
                    return textEditorStyle.selectionPopupStyle;
                });
            }
            return SelectionPopupStyleProperty;
        }

        private HorizontalAlignment? horizontalAlignment;
        private VerticalAlignment? verticalAlignment;
        private Vector4 secondaryCursorColor;
        private bool? enableCursorBlink;
        private float? cursorBlinkInterval;
        private float? cursorBlinkDuration;
        private int? cursorWidth;
        private Color grabHandleColor;
        private string grabHandleImage;
        private string grabHandlePressedImage;
        private PropertyMap selectionHandleImageLeft;
        private PropertyMap selectionHandleImageRight;
        private float? scrollThreshold;
        private float? scrollSpeed;
        private Vector4 selectionHighlightColor;
        private Rectangle decorationBoundingBox;
        private Vector4 inputColor;
        private string inputFontFamily;
        private float? inputPointSize;
        private string inputUnderline;
        private string inputShadow;
        private string emboss;
        private string inputEmboss;
        private string inputOutline;
        private bool? smoothScroll;
        private float? smoothScrollDuration;
        private bool? enableScrollBar;
        private float? scrollBarShowDuration;
        private float? scrollBarFadeDuration;
        private float? pixelSize;
        private bool? enableSelection;
        private bool? matchSystemLanguageDirection;
        private string fontFamily;
        private Vector4 textColor;
        private float? pointSize;
        private Color placeholderTextColor;
        private Vector4 primaryCursorColor;
        private PropertyMap fontStyle;
        private PropertyMap selectionPopupStyle;
        private bool? ellipsis;
        private float? lineSpacing;
        private float? minLineSize;
        private float? relativeLineHeight;
        private float? fontSizeScale;

        static TextEditorStyle() { }

        /// <summary>
        /// Create an empty instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextEditorStyle() : base()
        {
        }

        /// <summary>
        /// The FontFamily property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        /// <summary>
        /// The HorizontalAlignment property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? HorizontalAlignment
        {
            get => (HorizontalAlignment?)GetValue(HorizontalAlignmentProperty);
            set => SetValue(HorizontalAlignmentProperty, value);
        }

        /// <summary>
        /// The VerticalAlignment property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? VerticalAlignment
        {
            get => (VerticalAlignment?)GetValue(VerticalAlignmentProperty);
            set => SetValue(VerticalAlignmentProperty, value);
        }

        /// <summary>
        /// The SecondaryCursorColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SecondaryCursorColor
        {
            get => (Vector4)GetValue(SecondaryCursorColorProperty);
            set => SetValue(SecondaryCursorColorProperty, value);
        }

        /// <summary>
        /// The EnableCursorBlink property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableCursorBlink
        {
            get => (bool?)GetValue(EnableCursorBlinkProperty);
            set => SetValue(EnableCursorBlinkProperty, value);
        }

        /// <summary>
        /// The CursorBlinkInterval property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkInterval
        {
            get => (float?)GetValue(CursorBlinkIntervalProperty);
            set => SetValue(CursorBlinkIntervalProperty, value);
        }

        /// <summary>
        /// The CursorBlinkDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkDuration
        {
            get => (float?)GetValue(CursorBlinkDurationProperty);
            set => SetValue(CursorBlinkDurationProperty, value);
        }

        /// <summary>
        /// The CursorWidth property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CursorWidth
        {
            get
            {
                if(NUIApplication.DisableBindableProperty)
                {
                    return this.cursorWidth;
                }
                else
                {
                    return (int?)GetValue(GetCursorWidthProperty());
                }
            }
            set
            {
                if (NUIApplication.DisableBindableProperty)
                {
                    this.cursorWidth = value;
                }
                else
                {
                    SetValue(GetCursorWidthProperty(), value);
                }
            }
        }

        /// <summary>
        /// The GrabHandleColor property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color GrabHandleColor
        {
            get => (Color)GetValue(GrabHandleColorProperty);
            set => SetValue(GrabHandleColorProperty, value);
        }

        /// <summary>
        /// The GrabHandleImage property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GrabHandleImage
        {
            get => (string)GetValue(GrabHandleImageProperty);
            set => SetValue(GrabHandleImageProperty, value);
        }

        /// <summary>
        /// The GrabHandlePressedImage property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GrabHandlePressedImage
        {
            get => (string)GetValue(GrabHandlePressedImageProperty);
            set => SetValue(GrabHandlePressedImageProperty, value);
        }

        /// <summary>
        /// The SelectionHandleImageLeft property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionHandleImageLeft
        {
            get => (PropertyMap)GetValue(SelectionHandleImageLeftProperty);
            set => SetValue(SelectionHandleImageLeftProperty, value);
        }

        /// <summary>
        /// The SelectionHandleImageRight property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionHandleImageRight
        {
            get => (PropertyMap)GetValue(SelectionHandleImageRightProperty);
            set => SetValue(SelectionHandleImageRightProperty, value);
        }

        /// <summary>
        /// The ScrollThreshold property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollThreshold
        {
            get => (float?)GetValue(ScrollThresholdProperty);
            set => SetValue(ScrollThresholdProperty, value);
        }

        /// <summary>
        /// The ScrollSpeed property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollSpeed
        {
            get => (float?)GetValue(ScrollSpeedProperty);
            set => SetValue(ScrollSpeedProperty, value);
        }

        /// <summary>
        /// The SelectionHighlightColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SelectionHighlightColor
        {
            get
            {
                if(NUIApplication.DisableBindableProperty)
                {
                    return this.selectionHighlightColor;
                }
                else
                {
                    return (Vector4)GetValue(GetSelectionHighlightColorProperty());
                }
            }
            set
            {
                if (NUIApplication.DisableBindableProperty)
                {
                    this.selectionHighlightColor = value;
                }
                else
                {
                    SetValue(GetSelectionHighlightColorProperty(), value);
                }
            }
        }

        /// <summary>
        /// The DecorationBoundingBox property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle DecorationBoundingBox
        {
            get => (Rectangle)GetValue(DecorationBoundingBoxProperty);
            set => SetValue(DecorationBoundingBoxProperty, value);
        }

        /// <summary>
        /// The InputColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 InputColor
        {
            get => (Vector4)GetValue(InputColorProperty);
            set => SetValue(InputColorProperty, value);
        }

        /// <summary>
        /// The InputFontFamily property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputFontFamily
        {
            get => (string)GetValue(InputFontFamilyProperty);
            set => SetValue(InputFontFamilyProperty, value);
        }

        /// <summary>
        /// The InputPointSize property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? InputPointSize
        {
            get => (float?)GetValue(InputPointSizeProperty);
            set => SetValue(InputPointSizeProperty, value);
        }

        /// <summary>
        /// The InputUnderline property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputUnderline
        {
            get => (string)GetValue(InputUnderlineProperty);
            set => SetValue(InputUnderlineProperty, value);
        }

        /// <summary>
        /// The InputShadow property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputShadow
        {
            get => (string)GetValue(InputShadowProperty);
            set => SetValue(InputShadowProperty, value);
        }

        /// <summary>
        /// The Emboss property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Emboss
        {
            get => (string)GetValue(EmbossProperty);
            set => SetValue(EmbossProperty, value);
        }

        /// <summary>
        /// The InputEmboss property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputEmboss
        {
            get => (string)GetValue(InputEmbossProperty);
            set => SetValue(InputEmbossProperty, value);
        }

        /// <summary>
        /// The InputOutline property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputOutline
        {
            get => (string)GetValue(InputOutlineProperty);
            set => SetValue(InputOutlineProperty, value);
        }

        /// <summary>
        /// The SmoothScroll property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SmoothScroll
        {
            get => (bool?)GetValue(SmoothScrollProperty);
            set => SetValue(SmoothScrollProperty, value);
        }

        /// <summary>
        /// The SmoothScrollDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? SmoothScrollDuration
        {
            get => (float?)GetValue(SmoothScrollDurationProperty);
            set => SetValue(SmoothScrollDurationProperty, value);
        }

        /// <summary>
        /// The EnableScrollBar property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableScrollBar
        {
            get => (bool?)GetValue(EnableScrollBarProperty);
            set => SetValue(EnableScrollBarProperty, value);
        }

        /// <summary>
        /// The ScrollBarShowDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollBarShowDuration
        {
            get => (float?)GetValue(ScrollBarShowDurationProperty);
            set => SetValue(ScrollBarShowDurationProperty, value);
        }

        /// <summary>
        /// The ScrollBarFadeDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollBarFadeDuration
        {
            get => (float?)GetValue(ScrollBarFadeDurationProperty);
            set => SetValue(ScrollBarFadeDurationProperty, value);
        }

        /// <summary>
        /// The PixelSize property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PixelSize
        {
            get => (float?)GetValue(PixelSizeProperty);
            set => SetValue(PixelSizeProperty, value);
        }

        /// <summary>
        /// The EnableSelection property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableSelection
        {
            get => (bool?)GetValue(EnableSelectionProperty);
            set => SetValue(EnableSelectionProperty, value);
        }

        /// <summary>
        /// The text alignment to match the direction of the system language.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? MatchSystemLanguageDirection
        {
            get => (bool?)GetValue(MatchSystemLanguageDirectionProperty);
            set => SetValue(MatchSystemLanguageDirectionProperty, value);
        }

        /// <summary>
        /// The TextColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 TextColor
        {
            get => (Vector4)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        /// <summary>
        /// The PointSize property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PointSize
        {
            get => (float?)GetValue(PointSizeProperty);
            set => SetValue(PointSizeProperty, value);
        }

        /// <summary>
        /// The Placeholder text color.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color PlaceholderTextColor
        {
            get => (Color)GetValue(PlaceholderTextColorProperty);
            set => SetValue(PlaceholderTextColorProperty, value);
        }

        /// <summary>
        /// The PrimaryCursorColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 PrimaryCursorColor
        {
            get => (Vector4)GetValue(PrimaryCursorColorProperty);
            set => SetValue(PrimaryCursorColorProperty, value);
        }

        /// <summary>
        /// The FontStyle property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap FontStyle
        {
            get => (PropertyMap)GetValue(FontStyleProperty);
            set => SetValue(FontStyleProperty, value);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Ellipsis
        {
            get => (bool?)GetValue(EllipsisProperty);
            set => SetValue(EllipsisProperty, value);
        }

        /// <summary>
        /// the line spacing to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? LineSpacing
        {
            get => (float?)GetValue(LineSpacingProperty);
            set => SetValue(LineSpacingProperty, value);
        }

        /// <summary>
        /// the minimum line size to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? MinLineSize
        {
            get => (float?)GetValue(MinLineSizeProperty);
            set => SetValue(MinLineSizeProperty, value);
        }

        /// <summary>
        /// the relative line height to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? RelativeLineHeight
        {
            get => (float?)GetValue(RelativeLineHeightProperty);
            set => SetValue(RelativeLineHeightProperty, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? FontSizeScale
        {
            get => (float?)GetValue(FontSizeScaleProperty);
            set => SetValue(FontSizeScaleProperty, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionPopupStyle
        {
            get
            {
                if (NUIApplication.DisableBindableProperty)
                {
                    return this.selectionPopupStyle;
                }
                else
                {
                    return (PropertyMap)GetValue(GetSelectionPopupStyleProperty()); 
                }
            }
            set
            {
                if (NUIApplication.DisableBindableProperty)
                {
                    this.selectionPopupStyle = value;
                }
                else
                {
                    SetValue(GetSelectionPopupStyleProperty(), value);
                }
            }
        }
    }
}
