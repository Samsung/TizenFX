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
    /// Defines a value type of vector3.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct UIVector3 : IEquatable<UIVector3>
    {
        /// <summary>
        /// The zero vector3.
        /// </summary>
        public static readonly UIVector3 Zero = new (0.0f, 0.0f, 0.0f);

        /// <summary>
        /// Initializes a new instance of the <see cref="UIVector3"/> struct.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        public UIVector3(float x, float y) : this(x, y, 0f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIVector3"/> struct.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        /// <param name="z">The z value.</param>
        public UIVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Gets the x component of the vector3.
        /// </summary>
        public float X
        {
            get;
        }

        /// <summary>
        /// Gets the y component of the vector3.
        /// </summary>
        public float Y
        {
            get;
        }

        /// <summary>
        /// Gets the z component of the vector3.
        /// </summary>
        public float Z
        {
            get;
        }

        public readonly bool IsZero => X == 0 && Y == 0 && Z == 0;

        /// <summary>
        /// Gets the width component of the vector3.
        /// </summary>
        public float Width => X;

        /// <summary>
        /// Gets the height component of the vector3.
        /// </summary>
        public float Height => Y;

        /// <summary>
        /// Gets the depth component of the vector3.
        /// </summary>
        public float Depth => Z;

        /// <summary>
        /// Converts the UIVector2 to UIVector3 class implicitly.
        /// </summary>
        /// <param name="uiVector2">A UIVector2 to be converted to UIVector3</param>
        public static implicit operator UIVector3(UIVector2 uiVector2)
        {
            return new UIVector3(uiVector2.X, uiVector2.Y, 0f);
        }

        /// <summary>
        /// Converts the UIVector3 to Vector3 class implicitly.
        /// </summary>
        /// <param name="uiVector3">A UIVector3 to be converted to Vector3</param>
        public static implicit operator Vector3(UIVector3 uiVector3)
        {
            return new Vector3(uiVector3.X, uiVector3.Y, uiVector3.Z);
        }

        /// <summary>
        /// Whether this is equivalent to other.
        /// </summary>
        public bool Equals(UIVector3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        ///  <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is UIColor other)
            {
                return Equals(other);
            }
            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ (Y.GetHashCode() * 397) ^ Z.GetHashCode();
        }

        /// <summary>
        /// Compares two UIVector3 for equality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are equal, otherwise false.</returns>
        public static bool operator ==(UIVector3 operand1, UIVector3 operand2)
        {
            return operand1.Equals(operand2);
        }

        /// <summary>
        /// Compares two UIVector3 for inequality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are not equal, otherwise false.</returns>
        public static bool operator !=(UIVector3 operand1, UIVector3 operand2)
        {
            return !operand1.Equals(operand2);
        }

        /// <summary>
        /// Adds the specified <see cref="UIVector3"/> to the current <see cref="UIVector3"/>.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>A new <see cref="UIVector3"/> with the added values.</returns>
        public static UIVector3 operator +(UIVector3 left, UIVector3 right) => new UIVector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        /// <summary>
        /// Subtracts the specified <see cref="UIVector3"/> from the current <see cref="UIVector3"/>.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>A new <see cref="UIVector3"/> with the subtracted values.</returns>
        public static UIVector3 operator -(UIVector3 left, UIVector3 right) => new UIVector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        internal readonly Vector3 ToReferenceType() => new Vector3(X, Y, Z);
    }
}
