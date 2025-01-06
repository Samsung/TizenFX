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
        public Shadow(float blurRadius) : this(blurRadius, L.Color.Black, Vector2.Zero, Vector2.Zero)
        {
        }

        /// <summary>
        /// Create a Shadow.
        /// </summary>
        /// <param name="blurRadius">The blur radius value for the shadow. Bigger value, much blurry.</param>
        /// <param name="color">The color for the shadow.</param>
        /// <param name="offset">Optional. The position offset value (x, y) from the top left corner.</param>
        /// <param name="extents">Optional. The shadow will extend its size by specified amount of length.</param>
        public Shadow(float blurRadius, L.Color color, Vector2 offset, Vector2 extents)
        {
            BlurRadius = blurRadius;
            Color = color;
            Offset = offset;
            Extents = extents;
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
            set;
        }

        /// <summary>
        /// The color for the shadow.
        /// </summary>
        public L.Color Color
        {
            get;
            set;
        }

        /// <summary>
        /// The position offset value (x, y) from the top left corner.
        /// </summary>
        public Vector2 Offset
        {
            get;
            set;
        }

        /// <summary>
        /// The shadow will extend its size by specified amount of length.<br />
        /// If the value is negative then the shadow will shrink.
        /// For example, when View's size is (100, 100) and the Shadow's Extents is (5, -5),
        /// the output shadow will have size (105, 95).
        /// </summary>
        public Vector2 Extents
        {
            get;
            set;
        }

        internal readonly NUI.Shadow ToShadow() => new NUI.Shadow(BlurRadius, Color.ToReferenceType(), Offset.ToReferenceType(), Extents.ToReferenceType());
    }
}
