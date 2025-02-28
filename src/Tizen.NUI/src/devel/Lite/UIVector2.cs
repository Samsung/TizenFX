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

namespace Tizen.NUI
{
    /// <summary>
    /// Defines a value type of vector2.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct UIVector2
    {
        /// <summary>
        /// The zero vector2.
        /// </summary>
        public static readonly UIVector2 Zero = new (0.0f, 0.0f);

        /// <summary>
        /// Initializes a new instance of the <see cref="UIVector2"/> struct.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        public UIVector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets the x component of the vector2.
        /// </summary>
        public float X
        {
            get;
        }

        /// <summary>
        /// Gets the y component of the vector2.
        /// </summary>
        public float Y
        {
            get;
        }

        public readonly bool IsZero => X == 0 && Y == 0;

        /// <summary>
        /// Gets the width component of the vector2.
        /// </summary>
        public float Width => X;

        /// <summary>
        /// Gets the height component of the vector2.
        /// </summary>
        public float Height => Y;

        /// <summary>
        /// Converts the UIVector2 to Vector3 class implicitly.
        /// </summary>
        /// <param name="uiVector2">A UIVector2 to be converted to Vector3</param>
        public static implicit operator Vector3(UIVector2 uiVector2)
        {
            return new Vector3(uiVector2.X, uiVector2.Y, 0f);
        }


        internal readonly NUI.Vector2 ToReferenceType() => new NUI.Vector2(X, Y);
    }
}
