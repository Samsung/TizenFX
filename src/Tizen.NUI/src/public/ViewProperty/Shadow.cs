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
using Tizen.NUI.Visuals;

namespace Tizen.NUI
{

    /// <summary>
    /// Represents a shadow with color and blur radius for a View.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(Tizen.NUI.Binding.ShadowTypeConverter))]
    public class Shadow : ShadowBase, ICloneable
    {
        internal static readonly Color noColor = new Color(0, 0, 0, 0);

        internal static readonly Color defaultColor = new Color(0, 0, 0, 0.5f);

        private Visuals.ColorVisual shadowVisual;

        /// <summary>
        /// Create a Shadow with default values.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Shadow() : base()
        {
            BlurRadius = 0;
            CutoutPolicy = ColorVisualCutoutPolicyType.None;
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
        public Shadow(float blurRadius, Color color, Vector2 offset = null, Vector2 extents = null) : this(blurRadius, ColorVisualCutoutPolicyType.None, color, offset, extents)
        {
        }

        /// <summary>
        /// Create a Shadow with custom values.
        /// </summary>
        /// <param name="blurRadius">The blur radius value for the shadow. Bigger value, much blurry.</param>
        /// <param name="cutoutPolicy">The policy of the shadow cutout.</param>
        /// <param name="color">The color for the shadow.</param>
        /// <param name="offset">Optional. The position offset value (x, y) from the top left corner. See <see cref="ShadowBase.Offset"/>.</param>
        /// <param name="extents">Optional. The shadow will extend its size by specified amount of length. See <see cref="ShadowBase.Extents"/>.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Shadow(float blurRadius, ColorVisualCutoutPolicyType cutoutPolicy, Color color, Vector2 offset = null, Vector2 extents = null) : base(offset, extents)
        {
            BlurRadius = blurRadius;
            CutoutPolicy = cutoutPolicy;
            Color = color == null ? new Color(defaultColor) : new Color(color);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when other is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Shadow(Shadow other) : this(other == null ? throw new ArgumentNullException(nameof(other)) : other.BlurRadius, other.CutoutPolicy, other.Color, other.Offset, other.Extents)
        {
        }

        /// <summary>
        /// Create a Shadow from a property map.
        /// </summary>
        internal Shadow(PropertyMap propertyMap) : base(propertyMap)
        {
            Color = new Color(noColor);
            using (PropertyValue mixColorValue = propertyMap.Find(ColorVisualProperty.MixColor))
            {
                mixColorValue?.Get(Color);
            }

            float blurRadius = 0;
            using (PropertyValue blurRadiusValue = propertyMap.Find(ColorVisualProperty.BlurRadius))
            {
                blurRadiusValue?.Get(out blurRadius);
            }
            BlurRadius = blurRadius;

            int cutoutPolicy = (int)ColorVisualCutoutPolicyType.None;
            using (PropertyValue cutoutPolicyValue = propertyMap.Find(ColorVisualProperty.CutoutPolicy))
            {
                cutoutPolicyValue?.Get(out cutoutPolicy);
            }
            CutoutPolicy = (ColorVisualCutoutPolicyType)cutoutPolicy;
        }

        /// <summary>
        /// The color for the shadow.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Color Color { get; internal set; }

        /// <summary>
        /// The blur radius value for the shadow. Bigger value, much blurry.
        /// </summary>
        /// <remarks>
        /// Negative value is ignored. (no blur)
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public float BlurRadius { get; internal set; }

        /// <summary>
        /// The Cutout policy for this shadow.
        /// </summary>
        /// <remarks>
        /// ColorVisualCutoutPolicyType.None = Fully render the shadow color (Default)<br/>
        /// ColorVisualCutoutPolicyType.CutoutView = Do not render inside bounding box of view<br/>
        /// ColorVisualCutoutPolicyType.CutoutViewWithCornerRadius = Do not render inside view, consider corner radius value<br/>
        /// We don't support this property for xaml yet.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorVisualCutoutPolicyType CutoutPolicy { get; internal set;}

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
                hash = (hash * 7) + (CutoutPolicy.GetHashCode());
                return hash;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone()
        {
            return OnClone();
        }

        internal virtual object OnClone()
        {
            return new Shadow(this);
        }

        internal override bool IsEmpty()
        {
            return (Color == null || Color.A == 0);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override PropertyMap GetPropertyMap()
        {
            var map = base.GetPropertyMap();

            map.Set(Visual.Property.Type, (int)Visual.Type.Color);

            map.Set(ColorVisualProperty.MixColor, Color ?? noColor);

            map.Set(ColorVisualProperty.BlurRadius, BlurRadius < 0 ? 0 : BlurRadius);

            map.Set(ColorVisualProperty.CutoutPolicy, (int)CutoutPolicy);

            return map;
        }

        internal virtual Visuals.ColorVisual GetShadowVisual()
        {
            if(shadowVisual == null)
            {
                shadowVisual = new Visuals.ColorVisual();
            }

            shadowVisual.Color = this.Color;
            shadowVisual.BlurRadius = this.BlurRadius;
            shadowVisual.OffsetX = this.Offset?.X ?? 0.0f;
            shadowVisual.OffsetY = this.Offset?.Y ?? 0.0f;
            shadowVisual.OffsetXPolicy = VisualTransformPolicyType.Absolute;
            shadowVisual.OffsetYPolicy = VisualTransformPolicyType.Absolute;
            shadowVisual.Origin = Visual.AlignType.Center;
            shadowVisual.PivotPoint = Visual.AlignType.Center;
            shadowVisual.ExtraWidth = this.Extents?.Width ?? 0.0f;
            shadowVisual.ExtraHeight = this.Extents?.Height ?? 0.0f;
            shadowVisual.CutoutPolicy = ColorVisualCutoutPolicyType.CutoutViewWithCornerRadius;

            return shadowVisual;
        }
    }
}


