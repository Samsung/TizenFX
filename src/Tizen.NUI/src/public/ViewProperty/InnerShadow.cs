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
    /// Represents a inner shadow with inside extents for a View.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InnerShadow : Shadow
    {
        /// <summary>
        /// Create a InnerShadow with default values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InnerShadow() : base()
        {
        }

        /// <summary>
        /// Create a InnerShadow with extents values.
        /// </summary>
        /// <param name="insetExtents">The Inset extents for the inner shadow.</param>
        /// <param name="blurRadius">The blur radius value for the shadow. Bigger value, much blurry.</param>
        /// <param name="color">The color for the shadow.</param>
        /// <param name="cutoutPolicy">The policy of the shadow cutout. Default is ColorVisualCutoutPolicyType.CutoutOutsideWithCornerRadius</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InnerShadow(UIExtents insetExtents, float blurRadius, Color color, ColorVisualCutoutPolicyType cutoutPolicy = ColorVisualCutoutPolicyType.CutoutOutsideWithCornerRadius) : this(GenerateInnerShadowByExtents(insetExtents, blurRadius, color, cutoutPolicy))
        {
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when other is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InnerShadow(InnerShadow other) : this(other == null ? throw new ArgumentNullException(nameof(other)) : other.ShadowWidth, other.BlurRadius, other.CutoutPolicy, other.Color, other.Offset, other.Extents)
        {
        }

        /// <summary>
        /// Create a InnerShadow with custom values.
        /// </summary>
        /// <param name="shadowWidth">The Width value for the shadow.</param>
        /// <param name="blurRadius">The blur radius value for the shadow. Bigger value, much blurry.</param>
        /// <param name="cutoutPolicy">The policy of the shadow cutout.</param>
        /// <param name="color">The color for the shadow.</param>
        /// <param name="offset">Optional. The position offset value (x, y) from the top left corner. See <see cref="ShadowBase.Offset"/>.</param>
        /// <param name="extents">Optional. The shadow will extend its size by specified amount of length. See <see cref="ShadowBase.Extents"/>.</param>
        internal InnerShadow(float shadowWidth, float blurRadius, ColorVisualCutoutPolicyType cutoutPolicy, Color color, Vector2 offset = null, Vector2 extents = null) : base(blurRadius, cutoutPolicy, color, offset, extents)
        {
            ShadowWidth = shadowWidth;
        }

        /// <summary>
        /// Create a Shadow from a property map.
        /// </summary>
        internal InnerShadow(PropertyMap propertyMap) : base(propertyMap)
        {
            ShadowWidth = 0.0f;
            using (PropertyValue shadowWidthValue = propertyMap.Find(Visual.Property.BorderlineWidth))
            {
                shadowWidthValue?.Get(ShadowWidth);
            }

            // Override the MixColor
            Color = new Color(Shadow.noColor);;
            using (PropertyValue borderlineColorValue = propertyMap.Find(Visual.Property.BorderlineColor))
            {
                borderlineColorValue?.Get(Color);
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
        {
            if (!base.Equals(other))
            {
                return false;
            }

            var otherInnerShadow = (InnerShadow)other;

            return ShadowWidth.Equals(otherInnerShadow.ShadowWidth);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = base.GetHashCode();
                hash = (hash * 7) + (ShadowWidth.GetHashCode());
                return hash;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override PropertyMap GetPropertyMap()
        {
            var map = base.GetPropertyMap();

            // Override the MixColor
            map.Set(ColorVisualProperty.MixColor, Color.Transparent);

            map.Set(Visual.Property.BorderlineColor, Color ?? Color.Transparent);
            map.Set(Visual.Property.BorderlineWidth, ShadowWidth);
            map.Set(Visual.Property.BorderlineOffset, -1.0f);

            return map;
        }

        internal override object OnClone()
        {
            return new InnerShadow(this);
        }

        /// <summary>
        /// The width of shadow, which internally calculated by extents.
        /// This value only be used when we want to copy the internal shadow.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal float ShadowWidth { get; set; }

        /// <summary>
        /// Internal helper functions to calculate inner shadow properties by extents.
        /// </summary>
        internal static float CalculateShadowWidthByExtents(UIExtents insetExtents, float blurRadius)
        {
            const float margin = 1.0f;
            float maxInset = Math.Max(insetExtents.Start, Math.Max(insetExtents.End, Math.Max(insetExtents.Top, insetExtents.Bottom)));
            return Math.Max(maxInset, 0.0f) + blurRadius + margin;
        }
        internal static Vector2 CalculateOffsetByExtents(UIExtents insetExtents)
        {
            // Offset from center of view.
            return new Vector2((insetExtents.Start - insetExtents.End) * 0.5f, (insetExtents.Top - insetExtents.Bottom) * 0.5f);
        }
        internal static Vector2 CalculateExtraSizeByExtents(UIExtents insetExtents, float shadowWidth, float blurRadius)
        {
            return new Vector2(shadowWidth * 2.0f - insetExtents.Start - insetExtents.End, shadowWidth * 2.0f - insetExtents.Top - insetExtents.Bottom);
        }

        internal static InnerShadow GenerateInnerShadowByExtents(UIExtents insetExtents, float blurRadius, Color color, ColorVisualCutoutPolicyType cutoutPolicy)
        {
            var shadowWidth = CalculateShadowWidthByExtents(insetExtents, blurRadius);
            using var offset = CalculateOffsetByExtents(insetExtents);
            using var extents = CalculateExtraSizeByExtents(insetExtents, shadowWidth, blurRadius);

            return new InnerShadow(shadowWidth, blurRadius, cutoutPolicy, color, offset, extents);
        }
    }
}
