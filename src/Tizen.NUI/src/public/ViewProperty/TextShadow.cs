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
    /// The Text Shadow for TextLabel.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextShadow : Internal.ICloneable
    {
        private Color color = Color.Black;
        private Vector2 offset = Vector2.Zero;
        private float blurRadius = 0.0f;

        private PropertyMap propertyMap = null;

        internal delegate void PropertyChangedCallback(TextShadow instance);
        internal PropertyChangedCallback OnPropertyChanged = null;

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextShadow()
        {
            propertyMap = new PropertyMap();
        }

        /// <summary>
        /// Deep copy method
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone()
        {
            return new TextShadow()
            {
                Offset = offset,
                Color = color,
                BlurRadius = blurRadius,
            };
        }

        /// <summary>
        /// Deep copy method (static)
        /// This provides nullity check.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static object Clone(TextShadow instance)
        {
            return instance == null ? null : new TextShadow()
            {
                Offset = instance.Offset,
                Color = instance.Color,
                BlurRadius = instance.BlurRadius,
            };
        }

        /// <summary>
        /// The color for the shadow of text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                UpdateColor();
            }
        }

        /// <summary>
        /// The offset for the shadow of text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Offset
        {
            get
            {
                return offset;
            }
            set
            {
                offset = value;
                UpdateOffset();
            }
        }

        /// <summary>
        /// The blur radius of the shadow of text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BlurRadius
        {
            get
            {
                return blurRadius;
            }
            set
            {
                blurRadius = value;
                UpdateBlurRadius();
            }
        }

        internal TextShadow(TextShadow other, PropertyChangedCallback callback = null)
        {
            Color = other.Color;
            BlurRadius = other.BlurRadius;
            OnPropertyChanged = callback;

            propertyMap = new PropertyMap();
        }

        static internal PropertyValue ToPropertyValue(TextShadow instance)
        {
            if (instance == null)
            {
                return new PropertyValue();
            }

            PropertyMap pm = instance.propertyMap;

            return new PropertyValue(pm);
        }

        private void UpdateOffset()
        {
            propertyMap["offset"] = PropertyValue.CreateWithGuard(offset);
            OnPropertyChanged?.Invoke(this);
        }

        private void UpdateColor()
        {
            propertyMap["color"] = PropertyValue.CreateWithGuard(color);
            OnPropertyChanged?.Invoke(this);
        }

        private void UpdateBlurRadius()
        {
            propertyMap["blurRadius"] = new PropertyValue(blurRadius);
            OnPropertyChanged?.Invoke(this);
        }
    }
}
