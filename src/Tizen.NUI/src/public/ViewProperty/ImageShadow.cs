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

 using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// The Shadow composed of image for View
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImageShadow : ShadowBase
    {
        private static readonly Rectangle noBorder = new Rectangle();

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow() : base()
        {
            Border = noBorder;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow(string url, Rectangle border, Vector2 offset, Vector2 extents) : base(offset, extents)
        {
            Url = url;
            Border = border;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow(ImageShadow other) : this(other.Url, other.Border, other.Offset, other.Extents)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ImageShadow(PropertyMap propertyMap) : base(propertyMap)
        {
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
        public string Url { get; set; }

        /// <summary>
        /// Optional.<br />
        /// The border area of the n-patch image.
        /// Set left, right, bottom, top length of the border you don't want to stretch in the image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle Border { get; set; }

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

            map[ImageVisualProperty.URL] = PropertyValue.CreateWithGuard(Url);

            return map;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool SetPropertyMap(PropertyMap propertyMap)
        {
            if (!base.SetPropertyMap(propertyMap))
            {
                return false;
            }

            Border = noBorder;
            propertyMap.Find(ImageVisualProperty.Border)?.Get(Border);

            string url = null;
            propertyMap.Find(ImageVisualProperty.URL)?.Get(out url);
            Url = url;

            return true;
        }
    }
}


