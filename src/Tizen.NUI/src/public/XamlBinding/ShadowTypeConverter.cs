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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// The shadow type converter
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.ShadowTypeConverter")]
    [TypeConversion(typeof(Shadow))]
    public class ShadowTypeConverter : TypeConverter
    {
        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "The ownership of created color, offset and extents are moved to a shadow object.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            // "blurRadius | color [| offset] [| extents]"
            // Examples
            // "1.0 | #AABBCCFF"
            // "6.2 | #AABBCC | 5, 5"
            // "8.0 | #AABBCC | 5, 5 | 7, 8"

            if (string.IsNullOrEmpty(value))
            {
                return new Shadow(0.0f, Color.Transparent);
            }

            var items = value.Split('|');

            if (items.Length < 2 || items.Length > 4)
            {
                return new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Shadow)}");
            }

            var blurRadius = Single.Parse(items[0].Trim(), CultureInfo.InvariantCulture);
            var color = new Color(items[1].Trim());
            Vector2 offset = null;
            Vector2 extents = null;

            if (items.Length > 2)
            {
                offset = Vector2TypeConverter.FromString(items[2].Trim());
            }

            if (items.Length == 4)
            {
                extents = Vector2TypeConverter.FromString(items[3].Trim());
            }

            return new Shadow(blurRadius, color, offset, extents);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ConvertToString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var shadow = (Shadow)value;
            string result = shadow.BlurRadius.ToString() + " | " + shadow.Color.ToString();

            result += " | " + (shadow.Offset == null ? "0, 0" : Vector2TypeConverter.ToString(shadow.Offset));
            result += " | " + (shadow.Extents == null ? "0, 0" : Vector2TypeConverter.ToString(shadow.Extents));

            return result;
        }
    }

    /// The shadow type converter
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.ImageShadowTypeConverter")]
    [TypeConversion(typeof(ImageShadow))]
    public class ImageShadowTypeConverter : TypeConverter
    {
        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "The ownership of created offset and extents are moved to a shadow object.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            // "imageUrl [| offset] [| extents]"
            // Examples
            // "*Resource*/image.9.png"
            // "*Resource*/image.9.png | 5, 5"
            // "*Resource*/image.9.png | 5, 5 | 7, 8"

            if (string.IsNullOrEmpty(value))
            {
                return new ImageShadow(String.Empty);
            }

            var items = value.Split('|');

            if (items.Length < 1 || items.Length > 3)
            {
                return new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(ImageShadow)}");
            }

            var url = items[0].Trim();
            Vector2 offset = null;
            Vector2 extents = null;

            if (items.Length > 1)
            {
                offset = Vector2TypeConverter.FromString(items[1].Trim());
            }

            if (items.Length == 3)
            {
                extents = Vector2TypeConverter.FromString(items[2].Trim());
            }

            return new ImageShadow(url, offset, extents);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ConvertToString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var imageShadow = (ImageShadow)value;
            string result = imageShadow.Url;

            result += " / " + (imageShadow.Offset == null ? "0, 0" : Vector2TypeConverter.ToString(imageShadow.Offset));
            result += " / " + (imageShadow.Extents == null ? "0, 0" : Vector2TypeConverter.ToString(imageShadow.Extents));

            return result;
        }
    }
}
