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
using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Defines a value type of vector2.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct UIVector2 : IEquatable<UIVector2>
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
            init;
        }

        /// <summary>
        /// Gets the y component of the vector2.
        /// </summary>
        public float Y
        {
            get;
            init;
        }

        public readonly bool IsZero => X == 0 && Y == 0;

        /// <summary>
        /// Gets the width component of the vector2.
        /// </summary>
        public float Width
        {
            get => X;
            init => X = value;
        }

        /// <summary>
        /// Gets the height component of the vector2.
        /// </summary>
        public float Height
        {
            get => Y;
            init => Y = value;
        }

        /// <summary>
        /// Compares two value for equality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are equal, otherwise false.</returns>
        public static bool operator ==(UIVector2 operand1, UIVector2 operand2)
        {
            return operand1.Equals(operand2);
        }

        /// <summary>
        /// Compares two value for inequality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are not equal, otherwise false.</returns>
        public static bool operator !=(UIVector2 operand1, UIVector2 operand2)
        {
            return !operand1.Equals(operand2);
        }

        /// <summary>
        /// Whether this is equivalent to other.
        /// </summary>
        public bool Equals(UIVector2 other)
        {
            return X == other.X && Y == other.Y;
        }

        ///  <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is UIVector2 other)
            {
                return Equals(other);
            }
            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                return X.GetHashCode() ^ (Y.GetHashCode() * 397);
            }
        }

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
