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
using Tizen.NUI.Text;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// TextMapHelper converts PropertyMap to struct and struct to PropertyMap.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TextMapHelper
    {
        /// <summary>
        /// It returns a string value according to FontWidthType.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontWidthType">The FontWidthType enum value.</param>
        /// <returns> A string value for FontStyle.Width property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetFontWidthString(FontWidthType fontWidthType)
        {
            string value = GetCamelCase(fontWidthType.ToString());
            return string.IsNullOrEmpty(value) ? "none" : value;
        }

        /// <summary>
        /// It returns a string value according to FontWeightType.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontWeightType">The FontWeightType enum value.</param>
        /// <returns> A string value for FontStyle.Weight property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetFontWeightString(FontWeightType fontWeightType)
        {
            string value = GetCamelCase(fontWeightType.ToString());
            return string.IsNullOrEmpty(value) ? "none" : value;
        }

        /// <summary>
        /// It returns a string value according to FontSlantType.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontSlantType">The FontSlantType enum value.</param>
        /// <returns> A string value for FontStyle.Slant property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetFontSlantString(FontSlantType fontSlantType)
        {
            string value = GetCamelCase(fontSlantType.ToString());
            return string.IsNullOrEmpty(value) ? "none" : value;
        }

        /// <summary>
        /// It returns a string value according to FontSizeType.
        /// The returned value can be used for TextFit PropertyMap.
        /// <param name="fontSizeType">The FontSizeType enum value.</param>
        /// <returns> A string value for TextFit.FontSizeType property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetFontSizeString(FontSizeType fontSizeType)
        {
            string value = GetCamelCase(fontSizeType.ToString());
            return string.IsNullOrEmpty(value) ? "pointSize" : value;
        }

        /// <summary>
        /// It returns a FontWidthType value according to fontWidthString.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontWidthString">The FontWidth string value.</param>
        /// <returns> A FontWidthType value for FontStyle.Width property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontWidthType GetFontWidthType(string fontWidthString)
        {
            FontWidthType value;
            if (!(Enum.TryParse(fontWidthString, true, out value) && Enum.IsDefined(typeof(FontWidthType), value)))
            {
                value = FontWidthType.None; // If parsing fails, set a default value.
            }

            return value;
        }

        /// <summary>
        /// It returns a FontWeightType value according to fontWeightString.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontWeightString">The FontWeight string value.</param>
        /// <returns> A FontWeightType value for FontStyle.Weight property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontWeightType GetFontWeightType(string fontWeightString)
        {
            FontWeightType value;
            if (!(Enum.TryParse(fontWeightString, true, out value) && Enum.IsDefined(typeof(FontWeightType), value)))
            {
                value = FontWeightType.None; // If parsing fails, set a default value.
            }

            return value;
        }

        /// <summary>
        /// It returns a FontSlantType value according to fontSlantString.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontSlantString">The FontSlant string value.</param>
        /// <returns> A FontSlantType value for FontStyle.Slant property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontSlantType GetFontSlantType(string fontSlantString)
        {
            FontSlantType value;
            if (!(Enum.TryParse(fontSlantString, true, out value) && Enum.IsDefined(typeof(FontSlantType), value)))
            {
                value = FontSlantType.None; // If parsing fails, set a default value.
            }

            return value;
        }

        /// <summary>
        /// It returns a FontSizeType value according to fontSizeString.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontSizeString">The FontSizeType string value.</param>
        /// <returns> A FontSizeType value for TextFit.FontSizeType property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontSizeType GetFontSizeType(string fontSizeString)
        {
            FontSizeType value;
            if (!(Enum.TryParse(fontSizeString, true, out value) && Enum.IsDefined(typeof(FontSizeType), value)))
            {
                value = FontSizeType.PointSize; // If parsing fails, set a default value.
            }

            return value;
        }

        /// <summary>
        /// This method converts a FontStyle struct to a PropertyMap and returns it.
        /// The returned map can be used for set FontStyle PropertyMap in the SetFontStyle method.
        /// <param name="fontStyle">The FontStyle struct value.</param>
        /// <returns> A PropertyMap for FontStyle property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetFontStyleMap(FontStyle fontStyle)
        {
            var map = new PropertyMap();
            map.Add("width", GetFontWidthString(fontStyle.Width));
            map.Add("weight", GetFontWeightString(fontStyle.Weight));
            map.Add("slant", GetFontSlantString(fontStyle.Slant));

            return map;
        }

        /// <summary>
        /// This method converts a FontStyle map to a struct and returns it.
        /// The returned struct can be returned to the user as a FontStyle in the GetFontStyle method.
        /// <param name="map">The FontStyle PropertyMap.</param>
        /// <returns> A FontStyle struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontStyle GetFontStyleStruct(PropertyMap map)
        {
            var fontStyle = new FontStyle();
            if (null != map)
            {
                var defaultValue = "none";
                fontStyle.Width = GetFontWidthType(GetStringFromMap(map, "width", defaultValue));
                fontStyle.Weight = GetFontWeightType(GetStringFromMap(map, "weight", defaultValue));
                fontStyle.Slant = GetFontSlantType(GetStringFromMap(map, "slant", defaultValue));
            }

            return fontStyle;
        }

        /// <summary>
        /// This method converts a InputFilter struct to a PropertyMap and returns it. <br />
        /// The returned map can be used for set InputFilter PropertyMap in the SetInputFilter method. <br />
        /// <param name="inputFilter">The InputFilter struct value.</param>
        /// <returns> A PropertyMap for InputFilter property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetInputFilterMap(InputFilter inputFilter)
        {
            var defaultValue = "";

            var map = new PropertyMap();
            var accepted = inputFilter.Accepted == null ? defaultValue : inputFilter.Accepted;
            var rejected = inputFilter.Rejected == null ? defaultValue : inputFilter.Rejected;
            map.Add(0, accepted);
            map.Add(1, rejected);

            return map;
        }

        /// <summary>
        /// This method converts a InputFilter map to a struct and returns it. <br />
        /// The returned struct can be returned to the user as a InputFilter in the GetInputFilter method. <br />
        /// <param name="map">The InputFilter PropertyMap.</param>
        /// <returns> A InputFilter struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static InputFilter GetInputFilterStruct(PropertyMap map)
        {
            var inputFilter = new InputFilter();
            if (null != map)
            {
                var defaultValue = "";
                inputFilter.Accepted = GetStringFromMap(map, 0, defaultValue);
                inputFilter.Rejected = GetStringFromMap(map, 1, defaultValue);
            }

            return inputFilter;
        }

        /// <summary>
        /// This method converts a Strikethrough struct to a PropertyMap and returns it.
        /// The returned map can be used for set Strikethrough PropertyMap in the SetStrikethrough method.
        /// <param name="strikethrough">The Strikethrough struct value.</param>
        /// <returns> A PropertyMap for Strikethrough property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetStrikethroughMap(Strikethrough strikethrough)
        {
            var map = new PropertyMap();

            map.Add("enable", strikethrough.Enable);

            if (strikethrough.Color != null)
                map.Add("color", strikethrough.Color);

            if (strikethrough.Height != null)
                map.Add("height", (float)strikethrough.Height);

            return map;
        }

        /// <summary>
        /// This method converts a Strikethrough map to a struct and returns it.
        /// The returned struct can be returned to the user as a Strikethrough in the GetUnderline method.
        /// <param name="map">The Strikethrough PropertyMap.</param>
        /// <returns> A Strikethrough struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Strikethrough GetStrikethroughStruct(PropertyMap map)
        {
            var strikethrough = new Strikethrough();
            if (null != map)
            {
                strikethrough.Enable = GetBoolFromMap(map, "enable", false);
                strikethrough.Color = GetColorFromMap(map, "color");
                strikethrough.Height = GetFloatFromMap(map, "height", 0.0f);
            }

            return strikethrough;
        }


        /// <summary>
        /// This method converts a Underline struct to a PropertyMap and returns it.
        /// The returned map can be used for set Underline PropertyMap in the SetUnderline method.
        /// <param name="underline">The Underline struct value.</param>
        /// <returns> A PropertyMap for Underline property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetUnderlineMap(Underline underline)
        {
            var map = new PropertyMap();

            map.Add("enable", underline.Enable);
            map.Add("type", (int)underline.Type);

            if (underline.Color != null)
                map.Add("color", underline.Color);

            if (underline.Height != null)
                map.Add("height", (float)underline.Height);
            
            if (underline.DashWidth != null)
                map.Add("dashWidth", (float)underline.DashWidth);

            if (underline.DashGap != null)
                map.Add("dashGap", (float)underline.DashGap);

            return map;
        }

        /// <summary>
        /// This method converts a Underline map to a struct and returns it.
        /// The returned struct can be returned to the user as a Underline in the GetUnderline method.
        /// <param name="map">The Underline PropertyMap.</param>
        /// <returns> A Underline struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Underline GetUnderlineStruct(PropertyMap map)
        {
            var underline = new Underline();
            if (null != map)
            {
                underline.Enable = GetBoolFromMap(map, "enable", false);
                underline.Type = (UnderlineType)GetIntFromMap(map, "type", 0);
                underline.Color = GetColorFromMap(map, "color");
                underline.Height = GetFloatFromMap(map, "height", 0.0f);
                underline.DashWidth = GetNullableFloatFromMap(map, "dashWidth");
                underline.DashGap = GetNullableFloatFromMap(map, "dashGap");
            }

            return underline;
        }

        /// <summary>
        /// This method converts a Shadow struct to a PropertyMap and returns it.
        /// The returned map can be used for set Shadow PropertyMap in the SetShadow method.
        /// <param name="shadow">The Shadow struct value.</param>
        /// <returns> A PropertyMap for Shadow property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetShadowMap(Tizen.NUI.Text.Shadow shadow)
        {
            var map = new PropertyMap();

            if (shadow.Offset != null)
                map.Add("offset", shadow.Offset);

            if (shadow.Color != null)
                map.Add("color", shadow.Color);

            if (shadow.BlurRadius != null)
                map.Add("blurRadius", (float)shadow.BlurRadius);

            return map;
        }

        /// <summary>
        /// This method converts a Shadow map to a struct and returns it.
        /// The returned struct can be returned to the user as a Shadow in the GetShadow method.
        /// <param name="map">The Shadow PropertyMap.</param>
        /// <returns> A Shadow struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Tizen.NUI.Text.Shadow GetShadowStruct(PropertyMap map)
        {
            var shadow = new Tizen.NUI.Text.Shadow();
            if (null != map)
            {
                shadow.Offset = GetVector2FromMap(map, "offset");
                shadow.Color = GetColorFromMap(map, "color");
                shadow.BlurRadius = GetFloatFromMap(map, "blurRadius", 0.0f);
            }

            return shadow;
        }

        /// <summary>
        /// This method converts a Outline struct to a PropertyMap and returns it.
        /// The returned map can be used for set Outline PropertyMap in the SetOutline method.
        /// <param name="outline">The Outline struct value.</param>
        /// <returns> A PropertyMap for Outline property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetOutlineMap(Outline outline)
        {
            var map = new PropertyMap();

            if (outline.Color != null)
                map.Add("color", outline.Color);

            if (outline.Width != null)
                map.Add("width", (float)outline.Width);

            return map;
        }

        /// <summary>
        /// This method converts a Outline map to a struct and returns it.
        /// The returned struct can be returned to the user as a Outline in the GetOutline method.
        /// <param name="map">The Outline PropertyMap.</param>
        /// <returns> A Outline struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Outline GetOutlineStruct(PropertyMap map)
        {
            var outline = new Outline();
            if (null != map)
            {
                outline.Color = GetColorFromMap(map, "color");
                outline.Width = GetFloatFromMap(map, "width", 0.0f);
            }

            return outline;
        }

        /// <summary>
        /// This method converts a TextFit struct to a PropertyMap and returns it.
        /// The returned map can be used for set TextFit PropertyMap in the SetTextFit method.
        /// <param name="textFit">The TextFit struct value.</param>
        /// <returns> A PropertyMap for TextFit property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetTextFitMap(TextFit textFit)
        {
            var map = new PropertyMap();
            map.Add("enable", textFit.Enable);
            map.Add("fontSizeType", GetFontSizeString(textFit.FontSizeType));

            if (textFit.MinSize != null)
                map.Add("minSize", (float)textFit.MinSize);

            if (textFit.MaxSize != null)
                map.Add("maxSize", (float)textFit.MaxSize);

            if (textFit.StepSize != null)
                map.Add("stepSize", (float)textFit.StepSize);

            return map;
        }

        /// <summary>
        /// This method converts a TextFit map to a struct and returns it.
        /// The returned struct can be returned to the user as a TextFit in the GetTextFit method.
        /// <param name="map">The TextFit PropertyMap.</param>
        /// <returns> A TextFit struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TextFit GetTextFitStruct(PropertyMap map)
        {
            var textFit = new TextFit();
            if (null != map)
            {
                var defaultValue = "PointSize";
                textFit.Enable = GetBoolFromMap(map, "enable", false);
                textFit.MinSize = GetFloatFromMap(map, "minSize", 0.0f);
                textFit.MaxSize = GetFloatFromMap(map, "maxSize", 0.0f);
                textFit.StepSize = GetFloatFromMap(map, "stepSize", 0.0f);
                textFit.FontSize = GetFloatFromMap(map, "fontSize", 0.0f);
                textFit.FontSizeType = GetFontSizeType(GetStringFromMap(map, "fontSizeType", defaultValue));
            }

            return textFit;
        }

        /// <summary>
        /// This method converts a Placeholder struct to a PropertyMap and returns it.
        /// The returned map can be used for set Placeholder PropertyMap in the SetPlaceholder method.
        /// <param name="placeholder">The Placeholder struct value.</param>
        /// <returns> A PropertyMap for Placeholder property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetPlaceholderMap(Placeholder placeholder)
        {
            var map = new PropertyMap();

            if (placeholder.Text != null)
                map.Add("text", placeholder.Text);

            if (placeholder.TextFocused != null)
                map.Add("textFocused", placeholder.TextFocused);

            if (placeholder.Color != null)
                map.Add("color", placeholder.Color);

            if (placeholder.FontFamily != null)
                map.Add("fontFamily", placeholder.FontFamily);

            if (placeholder.FontStyle != null)
            {
                using (var fontStyleMap = GetFontStyleMap((FontStyle)placeholder.FontStyle))
                using (var fontStyleValue = new PropertyValue(fontStyleMap))
                {
                    map.Add("fontStyle", fontStyleValue);
                }
            }

            if (placeholder.PointSize != null && placeholder.PixelSize != null)
                map.Add("pointSize", (float)placeholder.PointSize);

            else if (placeholder.PointSize != null)
                map.Add("pointSize", (float)placeholder.PointSize);

            else if (placeholder.PixelSize != null)
                map.Add("pixelSize", (float)placeholder.PixelSize);

            map.Add("ellipsis", placeholder.Ellipsis);

            return map;
        }

        /// <summary>
        /// This method converts a Placeholder map to a struct and returns it.
        /// The returned struct can be returned to the user as a Placeholder in the GetPlaceholder method.
        /// <param name="map">The Placeholder PropertyMap.</param>
        /// <returns> A Placeholder struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Placeholder GetPlaceholderStruct(PropertyMap map)
        {
            var placeholder = new Placeholder();
            if (null != map)
            {
                var defaultText = "";
                placeholder.Text = GetStringFromMap(map, 0, defaultText);
                placeholder.TextFocused = GetStringFromMap(map, 1, defaultText);
                placeholder.Color = GetColorFromMap(map, 2);
                placeholder.FontFamily = GetStringFromMap(map, 3, defaultText);
                using (var fontStyleMap = GetMapFromMap(map, 4))
                {
                    placeholder.FontStyle = GetFontStyleStruct(fontStyleMap);
                }
                placeholder.PointSize = GetNullableFloatFromMap(map, 5);
                placeholder.PixelSize = GetNullableFloatFromMap(map, 6);
                placeholder.Ellipsis = GetBoolFromMap(map, 7, false);
            }

            return placeholder;
        }

        /// <summary>
        /// This method converts a HiddenInput struct to a PropertyMap and returns it.
        /// The returned map can be used for set HiddenInputSettings PropertyMap in the SetHiddenInput method.
        /// <param name="hiddenInput">The HiddenInput struct value.</param>
        /// <returns> A PropertyMap for HiddenInput property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetHiddenInputMap(HiddenInput hiddenInput)
        {
            var map = new PropertyMap();

            map.Add(0, (int)hiddenInput.Mode);

            if (hiddenInput.SubstituteCharacter != null)
                map.Add(1, Convert.ToInt32(hiddenInput.SubstituteCharacter));

            if (hiddenInput.SubstituteCount != null)
                map.Add(2, (int)hiddenInput.SubstituteCount);

            if (hiddenInput.ShowLastCharacterDuration != null)
                map.Add(3, (int)hiddenInput.ShowLastCharacterDuration);

            return map;
        }

        /// <summary>
        /// This method converts a HiddenInputSettings map to a struct and returns it.
        /// The returned struct can be returned to the user as a HiddenInput in the GetHiddenInput method.
        /// <param name="map">The HiddenInput PropertyMap.</param>
        /// <returns> A HiddenInput struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HiddenInput GetHiddenInputStruct(PropertyMap map)
        {
            var hiddenInput = new HiddenInput();
            if (null != map)
            {
                int defaultVlaue = 0;
                hiddenInput.Mode = (HiddenInputModeType)GetIntFromMap(map, 0, defaultVlaue);

                int? substituteCharacter = GetNullableIntFromMap(map, 1);
                if (substituteCharacter != null)
                    hiddenInput.SubstituteCharacter = Convert.ToChar(substituteCharacter);

                hiddenInput.SubstituteCount = GetNullableIntFromMap(map, 2);
                hiddenInput.ShowLastCharacterDuration = GetNullableIntFromMap(map, 3);
            }

            return hiddenInput;
        }

        /// <summary>
        /// This method converts a fileName string to a PropertyMap and returns it.
        /// The returned map can be used for set SelectionHandleImageLeft, SelectionHandleImageRight PropertyMap in the SetSelectionHandleImage method.
        /// <param name="fileName">The file path string value for SelectionHandleImage.</param>
        /// <returns> A PropertyMap for SelectionHandleImageLeft, SelectionHandleImageRight properties. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetFileNameMap(string fileName)
        {
            return new PropertyMap().Add("filename", fileName);
        }

        /// <summary>
        /// This method converts a SelectionHandleImageLeft, SelectionHandleImageRight map to a struct and returns it.
        /// The returned struct can be returned to the user as a SelectionHandleImage in the GetSelectionHandleImage method.
        /// <param name="leftImageMap">The SelectionHandleImageLeft PropertyMap.</param>
        /// <param name="rightImageMap">The SelectionHandleImageRight PropertyMap.</param>
        /// <returns> A SelectionHandleImage struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SelectionHandleImage GetSelectionHandleImageStruct(PropertyMap leftImageMap, PropertyMap rightImageMap)
        {
            var defaultValue = "";

            var selectionHandleImage = new SelectionHandleImage();
            if (null != leftImageMap)
                selectionHandleImage.LeftImageUrl = GetStringFromMap(leftImageMap, "filename", defaultValue);

            if (null != rightImageMap)
                selectionHandleImage.RightImageUrl = GetStringFromMap(rightImageMap, "filename", defaultValue);

            return selectionHandleImage;
        }

        internal static string GetCamelCase(string pascalCase)
        {
            if (!string.IsNullOrEmpty(pascalCase))
            {
                char[] charArray = pascalCase.ToCharArray();
                charArray[0] = Char.ToLower(charArray[0]);
                pascalCase = new string(charArray);
            }

            return pascalCase;
        }

        internal static string GetStringFromMap(PropertyMap map, string key, string defaultValue)
        {
            string value = defaultValue;
            using (var propertyValue = map.Find(0, key))
            {
                if (null != propertyValue) propertyValue.Get(out value);
            }
            return value;
        }

        internal static string GetStringFromMap(PropertyMap map, int key, string defaultValue)
        {
            string value = defaultValue;
            using (var propertyValue = map.Find(key))
            {
                if (null != propertyValue) propertyValue.Get(out value);
            }
            return value;
        }

        internal static bool GetBoolFromMap(PropertyMap map, string key, bool defaultValue)
        {
            bool value = defaultValue;
            using (var propertyValue = map.Find(0, key))
            {
                if (null != propertyValue) propertyValue.Get(out value);
            }
            return value;
        }

        internal static bool GetBoolFromMap(PropertyMap map, int key, bool defaultValue)
        {
            bool value = defaultValue;
            using (var propertyValue = map.Find(key))
            {
                if (null != propertyValue) propertyValue.Get(out value);
            }
            return value;
        }

        internal static int GetIntFromMap(PropertyMap map, int key, int defaultValue)
        {
            int value = defaultValue;
            using (var propertyValue = map.Find(key))
            {
                if (null != propertyValue) propertyValue.Get(out value);
            }
            return value;
        }

        internal static int GetIntFromMap(PropertyMap map, string key, int defaultValue)
        {
            int value = defaultValue;
            using (var propertyValue = map.Find(0, key))
            {
                if (null != propertyValue) propertyValue.Get(out value);
            }
            return value;
        }

        internal static float GetFloatFromMap(PropertyMap map, string key, float defaultValue)
        {
            float value = defaultValue;
            using (var propertyValue = map.Find(0, key))
            {
                if (null != propertyValue) propertyValue.Get(out value);
            }
            return value;
        }

        internal static Color GetColorFromMap(PropertyMap map, string key)
        {
            Color value = new Color();
            using (var propertyValue = map.Find(0, key))
            {
                if (null != propertyValue) propertyValue.Get(value);
            }
            return value;
        }

        internal static Color GetColorFromMap(PropertyMap map, int key)
        {
            Color value = new Color();
            using (var propertyValue = map.Find(key))
            {
                if (null != propertyValue) propertyValue.Get(value);
            }
            return value;
        }

        internal static Vector2 GetVector2FromMap(PropertyMap map, string key)
        {
            Vector2 value = new Vector2();
            using (var propertyValue = map.Find(0, key))
            {
                if (null != propertyValue) propertyValue.Get(value);
            }
            return value;
        }

        internal static PropertyMap GetMapFromMap(PropertyMap map, int key)
        {
            PropertyMap value = new PropertyMap();
            using (var propertyValue = map.Find(key))
            {
                if (null != propertyValue) propertyValue.Get(value);
            }
            return value;
        }

        internal static int? GetNullableIntFromMap(PropertyMap map, int key)
        {
            using (var propertyValue = map.Find(key))
            {
                if (propertyValue == null)
                    return null;

                propertyValue.Get(out int value);
                return value;
            }
        }

        internal static float? GetNullableFloatFromMap(PropertyMap map, int key)
        {
            using (var propertyValue = map.Find(key))
            {
                if (propertyValue == null)
                    return null;

                propertyValue.Get(out float value);
                return value;
            }
        }

        internal static float? GetNullableFloatFromMap(PropertyMap map, string key)
        {
            using (var propertyValue = map.Find(0, key))
            {
                if (propertyValue == null)
                    return null;

                propertyValue.Get(out float value);
                return value;
            }
        }

        internal static bool IsValue(PropertyMap map, int key)
        {
            using (var propertyValue = map.Find(key))
            {
                if (propertyValue == null)
                    return false;

                return true;
            }
        }
    }
}