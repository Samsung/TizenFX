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

namespace Tizen.NUI
{

    /// <summary>
    /// The Shadow composed of image for View
    /// </summary>
    [Tizen.NUI.Binding.TypeConverter(typeof(Tizen.NUI.Binding.ImageShadowTypeConverter))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImageShadow : ShadowBase, ICloneable
    {
        private static readonly Rectangle noBorder = new Rectangle();

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow() : base()
        {
            Border = new Rectangle(noBorder);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow(string url, Vector2 offset = null, Vector2 extents = null) : this(url, null, offset, extents)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow(string url, Rectangle border, Vector2 offset = null, Vector2 extents = null) : base(offset, extents)
        {
            Url = url;
            Border = border == null ? null : new Rectangle(border);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when other is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow(ImageShadow other) : this(other == null ? throw new ArgumentNullException(nameof(other)) : other.Url, other.Border, other.Offset, other.Extents)
        {
        }

        /// <summary>
        /// Create a Shadow from a propertyMap.
        /// </summary>
        internal ImageShadow(PropertyMap propertyMap) : base(propertyMap)
        {
            Border = noBorder;
            PropertyValue pValue = propertyMap.Find(ImageVisualProperty.Border);
            pValue?.Get(Border);
            pValue?.Dispose();

            string url = null;
            pValue = propertyMap.Find(ImageVisualProperty.URL);
            pValue?.Get(out url);
            pValue?.Dispose();
            Url = url;
        }

        /// <summary>
        /// The string conversion
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator ImageShadow(string value)
        {
            return new ImageShadow()
            {
                Url = value
            };
        }

        /// <summary>
        /// The url for the shadow image to load.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Url { get; internal set; }

        /// <summary>
        /// Optional.<br />
        /// The border area of the n-patch image.
        /// Set left, right, bottom, top length of the border you don't want to stretch in the image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle Border { get; internal set; }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
        {
            if (!base.Equals(other))
            {
                return false;
            }

            var otherShadow = (ImageShadow)other;

            if (!((Url == null) ? otherShadow.Url == null : Url.Equals(otherShadow.Url)))
            {
                return false;
            }

            return Border.Equals(otherShadow.Border);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = base.GetHashCode();
                hash = (hash * 7) + (Url == null ? 0 : Url.GetHashCode());
                hash = (hash * 7) + (Border.GetHashCode());
                return hash;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new ImageShadow(this);

        internal override bool IsEmpty()
        {
            return string.IsNullOrEmpty(Url);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override PropertyMap GetPropertyMap()
        {
            var map = base.GetPropertyMap();

            map[Visual.Property.Type] = new PropertyValue((int)Visual.Type.Image);

            if (Rectangle.IsNullOrZero(Border))
            {
                map[Visual.Property.Type] = new PropertyValue((int)Visual.Type.Image);
            }
            else
            {
                map[Visual.Property.Type] = new PropertyValue((int)Visual.Type.NPatch);
            }

            map[ImageVisualProperty.Border] = PropertyValue.CreateWithGuard(Border);

            string urlString = Url;
            if (Url.StartsWith("*Resource*"))
            {
                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                urlString = Url.Replace("*Resource*", resource);
            }

            map[ImageVisualProperty.URL] = PropertyValue.CreateWithGuard(urlString);

            return map;
        }
    }
}


