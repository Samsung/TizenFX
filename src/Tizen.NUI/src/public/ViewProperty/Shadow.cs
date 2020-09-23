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

using System;
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// Represents a shadow with color and blur radius for a View.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Shadow : ShadowBase, ICloneable
    {
        private static readonly Color noColor = new Color(0, 0, 0, 0);

        private static readonly Color defaultColor = new Color(0, 0, 0, 0.5f);

        /// <summary>
        /// Create a Shadow with default values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Shadow() : base()
        {
            BlurRadius = 0;
            Color = defaultColor;
        }

        /// <summary>
        /// Create a Shadow with custom values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Shadow(float blurRadius, Vector2 offset, Color color, Vector2 extents) : base(offset, extents)
        {
            BlurRadius = blurRadius;
            Color = new Color(color);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Shadow(Shadow other) : this(other.BlurRadius, other.Offset, other.Color, other.Extents)
        {
        }

        /// <summary>
        /// Create a Shadow from a propertyMap.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Shadow(PropertyMap propertyMap) : base(propertyMap)
        {
        }

        /// <summary>
        /// The color for the shadow.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color { get; set; }

        /// <summary>
        /// The blur radius value for the shadow. Bigger value, much blurry.
        /// </summary>
        /// <remark>
        /// Negative value is ignored. (no blur)
        /// </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BlurRadius { get; set; }

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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool SetPropertyMap(PropertyMap propertyMap)
        {
            if (!base.SetPropertyMap(propertyMap))
            {
                return false;
            }

            Color = noColor;
            propertyMap.Find(ColorVisualProperty.MixColor)?.Get(Color);

            float blurRadius = 0;
            propertyMap.Find(ColorVisualProperty.BlurRadius)?.Get(out blurRadius);
            BlurRadius = blurRadius;

            return true;
        }
    }
}


