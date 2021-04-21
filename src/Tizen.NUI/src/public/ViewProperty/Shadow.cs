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
    /// Represents a shadow with color and blur radius for a View.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(Tizen.NUI.Binding.ShadowTypeConverter))]
    public class Shadow : ShadowBase, ICloneable
    {
        private static readonly Color noColor = new Color(0, 0, 0, 0);

        private static readonly Color defaultColor = new Color(0, 0, 0, 0.5f);

        /// <summary>
        /// Create a Shadow with default values.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Shadow() : base()
        {
            BlurRadius = 0;
            Color = defaultColor;
        }

        /// <summary>
        /// Create a Shadow with custom values.
        /// </summary>
        /// <param name="blurRadius">The blur radius value for the shadow. Bigger value, much blurry.</param>
        /// <param name="color">The color for the shadow.</param>
        /// <param name="offset">Optional. The position offset value (x, y) from the top left corner. See <see cref="ShadowBase.Offset"/>.</param>
        /// <param name="extents">Optional. The shadow will extend its size by specified amount of length. See <see cref="ShadowBase.Extents"/>.</param>
        /// <since_tizen> 9 </since_tizen>
        public Shadow(float blurRadius, Color color, Vector2 offset = null, Vector2 extents = null) : base(offset, extents)
        {
            BlurRadius = blurRadius;
            Color = color == null ? new Color(defaultColor) : new Color(color);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when other is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Shadow(Shadow other) : this(other == null ? throw new ArgumentNullException(nameof(other)) : other.BlurRadius, other.Color, other.Offset, other.Extents)
        {
        }

        /// <summary>
        /// Create a Shadow from a property map.
        /// </summary>
        internal Shadow(PropertyMap propertyMap) : base(propertyMap)
        {
            Color = noColor;
            PropertyValue pValue = propertyMap.Find(ColorVisualProperty.MixColor);
            pValue?.Get(Color);
            pValue?.Dispose();

            float blurRadius = 0;
            pValue = propertyMap.Find(ColorVisualProperty.BlurRadius);
            pValue?.Get(out blurRadius);
            pValue?.Dispose();
            BlurRadius = blurRadius;
        }

        /// <summary>
        /// The color for the shadow.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Color Color { get; internal set; }

        /// <summary>
        /// The blur radius value for the shadow. Bigger value, much blurry.
        /// </summary>
        /// <remark>
        /// Negative value is ignored. (no blur)
        /// </remark>
        /// <since_tizen> 9 </since_tizen>
        public float BlurRadius { get; internal set; }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
        {
            if (!base.Equals(other))
            {
                return false;
            }

            var otherShadow = (Shadow)other;

            if (!((Color == null) ? otherShadow.Color == null : Color.Equals(otherShadow.Color)))
            {
                return false;
            }

            return BlurRadius.Equals(otherShadow.BlurRadius);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = base.GetHashCode();
                hash = (hash * 7) + (Color == null ? 0 : Color.GetHashCode());
                hash = (hash * 7) + (BlurRadius.GetHashCode());
                return hash;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Shadow(this);

        internal override bool IsEmpty()
        {
            return (Color == null || Color.A == 0);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override PropertyMap GetPropertyMap()
        {
            var map = base.GetPropertyMap();

            map[Visual.Property.Type] = new PropertyValue((int)Visual.Type.Color);

            map[ColorVisualProperty.MixColor] = new PropertyValue(Color ?? noColor);

            map[ColorVisualProperty.BlurRadius] = new PropertyValue(BlurRadius < 0 ? 0 : BlurRadius);

            return map;
        }
    }
}


