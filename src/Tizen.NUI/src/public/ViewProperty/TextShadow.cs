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
        private PropertyMap propertyMap = null;

        internal delegate void PropertyChangedCallback(TextShadow instance);
        internal PropertyChangedCallback OnPropertyChanged = null;

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextShadow(Color color, Vector2 offset, float blurRadius)
        {
            propertyMap = new PropertyMap();

            Color = color;
            propertyMap["color"] = PropertyValue.CreateWithGuard(Color);

            Offset = offset;
            propertyMap["offset"] = PropertyValue.CreateWithGuard(Offset);

            BlurRadius = blurRadius;
            propertyMap["blurRadius"] = new PropertyValue(BlurRadius);
        }

        /// <summary>
        /// Deep copy method
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone()
        {
            return new TextShadow(Color, Offset, BlurRadius);
        }

        /// <summary>
        /// Deep copy method (static)
        /// This provides nullity check.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static object Clone(TextShadow instance)
        {
            return instance == null ? null : new TextShadow(instance.Color, instance.Offset, instance.BlurRadius);
        }

        /// <summary>
        /// The color for the shadow of text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color { get; } = Color.Black;

        /// <summary>
        /// The offset for the shadow of text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Offset { get; } = Vector2.Zero;

        /// <summary>
        /// The blur radius of the shadow of text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BlurRadius { get; } = 0.0f;

        internal TextShadow(TextShadow other, PropertyChangedCallback callback = null)
        {
            propertyMap = new PropertyMap();

            Color = other.Color;
            propertyMap["color"] = PropertyValue.CreateWithGuard(Color);

            Offset = other.Offset;
            propertyMap["offset"] = PropertyValue.CreateWithGuard(Offset);

            BlurRadius = other.BlurRadius;
            propertyMap["blurRadius"] = new PropertyValue(BlurRadius);

            OnPropertyChanged = callback;
        }

        static internal PropertyValue ToPropertyValue(TextShadow instance)
        {
            if (instance == null)
            {
                return new PropertyValue();
            }

            return new PropertyValue(instance.propertyMap);
        }
    }
}
