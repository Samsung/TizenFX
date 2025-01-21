/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.L
{
    /// <summary>
    /// Defines a value type of shadow.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct Shadow
    {
        /// <summary>
        /// Create a Shadow.
        /// </summary>
        /// <param name="blurRadius">The blur radius value for the shadow. Bigger value, much blurry.</param>
        /// <param name="offsetX">Optional. The x offset value from the top left corner. The default is 0.</param>
        /// <param name="offsetY">Optional. The y offset value from the top left corner. The default is 0.</param>
        /// <param name="extraWidth">Optional. The shadow will extend its size by specified amount of length. The default is 0.</param>
        /// <param name="extraHeight">Optional. The shadow will extend its size by specified amount of length. The default is 0.</param>
        /// <param name="cutoutPolicy">The policy of the shadow cutout. The default is <see cref="ColorVisualCutoutPolicyType.None"/>.</param>
        public Shadow(float blurRadius, float offsetX = 0, float offsetY = 0, float extraWidth = 0, float extraHeight = 0, ColorVisualCutoutPolicyType cutoutPolicy = ColorVisualCutoutPolicyType.None)
            : this(blurRadius, L.Color.Black, offsetX, offsetY, extraWidth, extraHeight, cutoutPolicy)
        {
        }

        /// <summary>
        /// Create a Shadow.
        /// </summary>
        /// <param name="blurRadius">The blur radius value for the shadow. Bigger value, much blurry.</param>
        /// <param name="color">The color for the shadow.</param>
        /// <param name="offsetX">Optional. The x offset value from the top left corner. The default is 0.</param>
        /// <param name="offsetY">Optional. The y offset value from the top left corner. The default is 0.</param>
        /// <param name="extraWidth">Optional. The shadow will extend its size by specified amount of length. The default is 0.</param>
        /// <param name="extraHeight">Optional. The shadow will extend its size by specified amount of length. The default is 0.</param>
        /// <param name="cutoutPolicy">The policy of the shadow cutout. The default is <see cref="ColorVisualCutoutPolicyType.None"/>.</param>
        public Shadow(float blurRadius, L.Color color, float offsetX = 0, float offsetY = 0, float extraWidth = 0, float extraHeight = 0, ColorVisualCutoutPolicyType cutoutPolicy = ColorVisualCutoutPolicyType.None)
        {
            BlurRadius = blurRadius;
            Color = color;
            OffsetX = offsetX;
            OffsetY = offsetY;
            ExtraWidth = extraWidth;
            ExtraHeight = extraHeight;
            CutoutPolicy = cutoutPolicy;
        }

        /// <summary>
        /// The blur radius value for the shadow. Bigger value, much blurry.
        /// </summary>
        /// <remarks>
        /// Negative value is ignored. (no blur)
        /// </remarks>
        public float BlurRadius
        {
            get;
            init;
        }

        /// <summary>
        /// The color for the shadow.
        /// </summary>
        public L.Color Color
        {
            get;
            init;
        }

        /// <summary>
        /// The position offset value (x, y) from the top left corner.
        /// </summary>
        public float OffsetX
        {
            get;
            init;
        }

        /// <summary>
        /// The position offset value (x, y) from the top left corner.
        /// </summary>
        public float OffsetY
        {
            get;
            init;
        }

        /// <summary>
        /// The shadow will extend its size by specified amount of length.<br />
        /// If the value is negative then the shadow will shrink.
        /// For example, when View's size is (100, 100) and the Shadow's extra size are 5 and -5 respectively,
        /// the output shadow will have size (105, 95).
        /// </summary>
        public float ExtraWidth
        {
            get;
            init;
        }

        /// <summary>
        /// The shadow will extend its size by specified amount of length.<br />
        /// If the value is negative then the shadow will shrink.
        /// For example, when View's size is (100, 100) and the Shadow's extra size are 5 and -5 respectively,
        /// the output shadow will have size (105, 95).
        /// </summary>
        public float ExtraHeight
        {
            get;
            init;
        }

        /// <summary>
        /// The Cutout policy for this shadow.
        /// </summary>
        /// <remarks>
        /// ColorVisualCutoutPolicyType.None = Fully render the shadow color (Default)<br/>
        /// ColorVisualCutoutPolicyType.CutoutView = Do not render inside bounding box of view<br/>
        /// ColorVisualCutoutPolicyType.CutoutViewWithCornerRadius = Do not render inside view, consider corner radius value<br/>
        /// </remarks>
        public ColorVisualCutoutPolicyType CutoutPolicy
        {
            get;
            init;
        }

        internal readonly NUI.Shadow ToShadow() => new NUI.Shadow(BlurRadius, Color.ToReferenceType(), new (OffsetX, OffsetY), new (ExtraWidth, ExtraHeight));

        internal readonly PropertyMap BuildMap(View attachedView)
        {
            using var transform = new PropertyMap()
                .Append((int)VisualTransformPropertyType.Offset, new L.Vector2(OffsetX, OffsetY))
                .Append((int)VisualTransformPropertyType.OffsetPolicy, new L.Vector2((int)VisualTransformPolicyType.Absolute, (int)VisualTransformPolicyType.Absolute))
                .Append((int)VisualTransformPropertyType.ExtraSize, new L.Vector2(ExtraWidth, ExtraHeight))
                .Append((int)VisualTransformPropertyType.Origin, (int)Visual.AlignType.Center)
                .Append((int)VisualTransformPropertyType.AnchorPoint, (int)Visual.AlignType.Center);

            PropertyMap map = new PropertyMap()
                .Append(Visual.Property.Type, (int)Visual.Type.Color)
                .Append(ColorVisualProperty.MixColor, Color)
                .Append(ColorVisualProperty.BlurRadius, BlurRadius < 0 ? 0 : BlurRadius)
                .Append(ColorVisualProperty.CutoutPolicy, (int)CutoutPolicy)
                .Append(Visual.Property.Transform, transform);

            if (attachedView.CornerRadius != null || attachedView.CornerRadius != Vector4.Zero)
            {
                map.Append(Visual.Property.CornerRadius, attachedView.CornerRadius);
                map.Append(Visual.Property.CornerRadiusPolicy, (int)attachedView.CornerRadiusPolicy);
            }

            if (attachedView.CornerSquareness != null || attachedView.CornerSquareness != Vector4.Zero)
            {
                map.Append(Visual.Property.CornerSquareness, attachedView.CornerSquareness);
            }

            return map;
        }
    }
}
