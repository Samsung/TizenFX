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
        private static string GetCamelCase(string pascalCase)
        {
            if (!string.IsNullOrEmpty(pascalCase))
            {
                char[] charArray = pascalCase.ToCharArray();
                charArray[0] = Char.ToLower(charArray[0]);
                pascalCase = new string(charArray);
            }

            return pascalCase;
        }

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
        /// This method converts a FontStyle struct to a PropertyMap and returns it.
        /// The returned map can be used for set FontStyle PropertyMap in the SetFontStyle method.
        /// <param name="fontStyle">The FontStyle struct value.</param>
        /// <returns> A PropertyMap for FontStyle property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetFontStyleMap(FontStyle fontStyle)
        {
            var map = new PropertyMap();
            var width = new PropertyValue(GetFontWidthString(fontStyle.Width));
            var weight = new PropertyValue(GetFontWeightString(fontStyle.Weight));
            var slant = new PropertyValue(GetFontSlantString(fontStyle.Slant));

            map.Add("width", width);
            map.Add("weight", weight);
            map.Add("slant", slant);

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
            string width = "none";
            string weight = "none";
            string slant = "none";
            map.Find(0, "width")?.Get(out width);
            map.Find(0, "weight")?.Get(out weight);
            map.Find(0, "slant")?.Get(out slant);

            var fontStyle = new FontStyle();
            fontStyle.Width = GetFontWidthType(width);
            fontStyle.Weight = GetFontWeightType(weight);
            fontStyle.Slant = GetFontSlantType(slant);

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
            var map = new PropertyMap();
            var accepted = inputFilter.Accepted != null ? new PropertyValue(inputFilter.Accepted) : new PropertyValue("");
            var rejected = inputFilter.Rejected != null ? new PropertyValue(inputFilter.Rejected) : new PropertyValue("");
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
            string accepted = "";
            string rejected = "";
            map.Find(0)?.Get(out accepted);
            map.Find(1)?.Get(out rejected);

            var inputFilter = new InputFilter();
            inputFilter.Accepted = accepted;
            inputFilter.Rejected = rejected;

            return inputFilter;

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

            map.Add("enable", new PropertyValue(underline.Enable));

            if (underline.Color != null)
                map.Add("color", new PropertyValue(underline.Color));

            if (underline.Height != null)
                map.Add("height", new PropertyValue((float)underline.Height));

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
            Color color = new Color();
            map.Find(0, "enable").Get(out bool enable);
            map.Find(0, "color").Get(color);
            map.Find(0, "height").Get(out float height);

            var underline = new Underline();
            underline.Enable = enable;
            underline.Color = color;
            underline.Height = height;

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
                map.Add("offset", new PropertyValue(shadow.Offset));

            if (shadow.Color != null)
                map.Add("color", new PropertyValue(shadow.Color));

            if (shadow.BlurRadius != null)
                map.Add("blurRadius", new PropertyValue((float)shadow.BlurRadius));

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
            Vector2 offset = new Vector2();
            Color color = new Color();
            map.Find(0, "offset").Get(offset);
            map.Find(0, "color").Get(color);
            map.Find(0, "blurRadius").Get(out float blurRadius);

            var shadow = new Tizen.NUI.Text.Shadow();
            shadow.Offset = offset;
            shadow.Color = color;
            shadow.BlurRadius = blurRadius;

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
                map.Add("color", new PropertyValue(outline.Color));

            if (outline.Width != null)
                map.Add("width", new PropertyValue((float)outline.Width));

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
            Color color = new Color();
            map.Find(0, "color").Get(color);
            map.Find(0, "width").Get(out float width);

            var outline = new Outline();
            outline.Color = color;
            outline.Width = width;

            return outline;
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
        /// This method converts a TextFit struct to a PropertyMap and returns it.
        /// The returned map can be used for set TextFit PropertyMap in the SetTextFit method.
        /// <param name="textFit">The TextFit struct value.</param>
        /// <returns> A PropertyMap for TextFit property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetTextFitMap(TextFit textFit)
        {
            var map = new PropertyMap();
            map.Add("enable", new PropertyValue(textFit.Enable));
            map.Add("fontSizeType", new PropertyValue(GetFontSizeString(textFit.FontSizeType)));

            if (textFit.MinSize != null)
                map.Add("minSize", new PropertyValue((float)textFit.MinSize));

            if (textFit.MaxSize != null)
                map.Add("maxSize", new PropertyValue((float)textFit.MaxSize));

            if (textFit.StepSize != null)
                map.Add("stepSize", new PropertyValue((float)textFit.StepSize));

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
            bool enable = false;
            float minSize = 0.0f;
            float maxSize = 0.0f;
            float stepSize = 0.0f;
            float fontSize = 0.0f;
            string fontSizeType = null;
            map.Find(0, "enable")?.Get(out enable);
            map.Find(0, "minSize")?.Get(out minSize);
            map.Find(0, "maxSize")?.Get(out maxSize);
            map.Find(0, "stepSize")?.Get(out stepSize);
            map.Find(0, "fontSize")?.Get(out fontSize);
            map.Find(0, "fontSizeType")?.Get(out fontSizeType);

            var textFit = new TextFit();
            textFit.Enable = enable;
            textFit.MinSize = minSize;
            textFit.MaxSize = maxSize;
            textFit.StepSize = stepSize;
            textFit.FontSize = fontSize;
            textFit.FontSizeType = GetFontSizeType(fontSizeType);

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
                map.Add("text", new PropertyValue(placeholder.Text));

            if (placeholder.TextFocused != null)
                map.Add("textFocused", new PropertyValue(placeholder.TextFocused));

            if (placeholder.Color != null)
                map.Add("color", new PropertyValue(placeholder.Color));

            if (placeholder.FontFamily != null)
                map.Add("fontFamily", new PropertyValue(placeholder.FontFamily));

            if (placeholder.FontStyle != null)
                map.Add("fontStyle", new PropertyValue(GetFontStyleMap((FontStyle)placeholder.FontStyle)));

            if (placeholder.PointSize != null && placeholder.PixelSize != null)
                map.Add("pointSize", new PropertyValue((float)placeholder.PointSize));

            else if (placeholder.PointSize != null)
                map.Add("pointSize", new PropertyValue((float)placeholder.PointSize));

            else if (placeholder.PixelSize != null)
                map.Add("pixelSize", new PropertyValue((float)placeholder.PixelSize));

            map.Add("ellipsis", new PropertyValue(placeholder.Ellipsis));

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
            string text = "";
            string textFocused = "";
            Color color = new Color();
            string fontFamily = null;
            var fontStyle = new PropertyMap();
            PropertyValue pointSizeValue = null;
            PropertyValue pixelSizeValue = null;
            bool ellipsis = false;

            map.Find(0)?.Get(out text);
            map.Find(1)?.Get(out textFocused);
            map.Find(2)?.Get(color);
            map.Find(3)?.Get(out fontFamily);
            map.Find(4)?.Get(fontStyle);
            pointSizeValue = map.Find(5);
            pixelSizeValue = map.Find(6);
            map.Find(7)?.Get(out ellipsis);

            var placeholder = new Placeholder();
            placeholder.Text = text;
            placeholder.TextFocused = textFocused;
            placeholder.Color = color;
            placeholder.FontFamily = fontFamily;
            placeholder.Ellipsis = ellipsis;
            placeholder.FontStyle = GetFontStyleStruct(fontStyle);

            if (pointSizeValue != null)
            {
                pointSizeValue.Get(out float pointSize);
                placeholder.PointSize = pointSize;
            }

            if (pixelSizeValue != null)
            {
                pixelSizeValue.Get(out float pixelSize);
                placeholder.PixelSize = pixelSize;
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

            map.Add(0, new PropertyValue((int)hiddenInput.Mode));

            if (hiddenInput.SubstituteCharacter != null)
                map.Add(1, new PropertyValue(Convert.ToInt32(hiddenInput.SubstituteCharacter)));

            if (hiddenInput.SubstituteCount != null)
                map.Add(2, new PropertyValue((int)hiddenInput.SubstituteCount));

            if (hiddenInput.ShowLastCharacterDuration != null)
                map.Add(3, new PropertyValue((int)hiddenInput.ShowLastCharacterDuration));

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
            PropertyValue value = null;

            var hiddenInput = new HiddenInput();

            value = map.Find(0);
            if (value != null)
            {
                value.Get(out int mode);
                hiddenInput.Mode = (HiddenInputModeType)mode;
            }

            value = map.Find(1);
            if (value != null)
            {
                value.Get(out int substituteCharacter);
                hiddenInput.SubstituteCharacter = Convert.ToChar(substituteCharacter);
            }

            value = map.Find(2);
            if (value != null)
            {
                value.Get(out int substituteCount);
                hiddenInput.SubstituteCount = substituteCount;
            }

            value = map.Find(3);
            if (value != null)
            {
                value.Get(out int showLastCharacterDuration);
                hiddenInput.ShowLastCharacterDuration = showLastCharacterDuration;
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
            return new PropertyMap().Add("filename", new PropertyValue(fileName));
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
            string leftImageUrl = null;
            string rightImageUrl = null;

            var selectionHandleImage = new SelectionHandleImage();

            leftImageMap.Find(0, "filename")?.Get(out leftImageUrl);
            rightImageMap.Find(0, "filename")?.Get(out rightImageUrl);

            selectionHandleImage.LeftImageUrl = leftImageUrl;
            selectionHandleImage.RightImageUrl = rightImageUrl;

            return selectionHandleImage;
        }
    }
}