/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    public class ImageShadow : ShadowBase, Tizen.NUI.ICloneable
    {
        private string url;

        private Rectangle border;

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow() : base()
        {
            propertyMap[Visual.Property.Type] = new PropertyValue((int)Visual.Type.NPatch);
        }

        internal ImageShadow(ImageShadow other, PropertyChangedCallback callback = null) : base(other)
        {
            propertyMap[Visual.Property.Type] = new PropertyValue((int)Visual.Type.NPatch);

            Url = other.Url;
            Border = other.Border;
            OnPropertyChanged = callback;
        }

        /// <summary>
        /// The string conversion
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator ImageShadow(string value)
        {
            ImageShadow imageShadow = new ImageShadow()
            {
                Url = value ?? "",
            };
            return imageShadow;
        }

        /// <summary>
        /// Deep copy method
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone()
        {
            return new ImageShadow() {
                Offset = offset,
                Extents = extents,
                Url = url,
                Border = border
            };
        }

        /// <summary>
        /// Deep copy method (static)
        /// This provides nullity check.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public object Clone(ImageShadow instance)
        {
            return instance == null ? null : new ImageShadow() {
                Offset = instance.offset,
                Extents = instance.extents,
                Url = instance.url,
                Border = instance.border
            };
        }

        private void OnBorderChanged(int x, int y, int width, int height)
        {
            UpdateBorder();
        }

        private void UpdateUrl()
        {
            propertyMap[ImageVisualProperty.URL] = PropertyValue.CreateWithGuard(url);
            OnPropertyChanged?.Invoke(this);
        }

        private void UpdateBorder()
        {
            propertyMap[ImageVisualProperty.Border] = PropertyValue.CreateWithGuard(border);
            OnPropertyChanged?.Invoke(this);
        }

        /// <summary>
        /// The url for the shadow image to load.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                UpdateUrl();
            }
        }

        /// <summary>
        /// Optional.<br />
        /// The border area of the n-patch image.
        /// Set left, right, bottom, top length of the border you don't want to stretch in the image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle Border
        {
            get
            {
                return border;
            }
            set
            {
                border = value == null? null : new Rectangle(OnBorderChanged, value);
                UpdateBorder();
            }
        }

        override internal bool IsValid()
        {
            return !string.IsNullOrEmpty(url);
        }
    }
}


