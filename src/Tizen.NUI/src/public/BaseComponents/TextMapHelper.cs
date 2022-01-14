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