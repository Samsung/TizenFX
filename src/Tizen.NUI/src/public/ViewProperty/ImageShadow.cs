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
    public class ImageShadow : TransformablePropertyMap
    {
        private string url;

        private Rectangle border;

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow() : base()
        {
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

        override internal string ToDebugString()
        {
            string result = "";
            // TODO
            return result;
        }

        override internal bool IsValid()
        {
            return url != null;
        }

        static internal new PropertyValue ToPropertyValue(TransformablePropertyMap instance)
        {
            if (instance == null || !instance.IsValid())
            {
                return new PropertyValue();
            }

            instance.propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.NPatch));

            return new PropertyValue(instance.propertyMap);
        }
    }
}


