/* Copyright (c) 2025 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// The LayoutDimension structure defines the size of a view in layout.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct LayoutDimension
    {
        private bool isFixedValue;
        private float value;

        private LayoutDimension(float value)
        {
            if (value == LayoutParamPolicies.WrapContent || value == LayoutParamPolicies.MatchParent)
            {
                isFixedValue = false;
            }
            else
            {
                isFixedValue = true;
            }
            this.value = value;
        }

        /// <summary>
        /// Gets whether the size is fixed value or not. If it's fixed value, then the value is valid.
        /// </summary>
        public bool IsFixedValue
        {
            get => isFixedValue;
        }

        /// <summary>
        /// Creates a LayoutDimension from a float value. It's used implicitly. For example, LayoutDimension layoutWidth = 100; // Fixed value 100.0f.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator LayoutDimension(float value)
        {
            return new LayoutDimension(value);
        }

        /// <summary>
        /// Converts LayoutDimension to float. It's used implicitly. For example, float width = layoutWidth; // Only valid when layoutWidth is fixed value. Otherwise, it will cause compile error.
        /// </summary>
        /// <param name="layoutDimension">The LayoutDimension converted to float.</param>
        public static implicit operator float(LayoutDimension layoutDimension)
        {
            return layoutDimension.value;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (isFixedValue)
            {
                if (obj is float v)
                {
                    return value == v;
                }
            }
            else
            {
                if (obj is LayoutDimension ld)
                {
                    return value == ld.value;
                }
            }

            return false;
        }

        /// <summary>
        /// Equality operator for LayoutDimension. It compares two LayoutDimensions. If both are fixed values, then it compares their values.
        /// </summary>
        /// <param name="a">A <see cref="LayoutDimension"/> on the left hand side.</param>
        /// <param name="b">A <see cref="LayoutDimension"/> on the right hand side.</param>
        /// <returns></returns>
        public static bool operator ==(LayoutDimension a, LayoutDimension b)
        {
            if (a.isFixedValue == b.isFixedValue)
            {
                return a.value == b.value;
            }

            return false;
        }

        /// <summary>
        /// Inequality operator for LayoutDimension. It compares two LayoutDimensions. If both are fixed values, then it compares their values.
        /// </summary>
        /// <param name="a">A <see cref="LayoutDimension"/> on the left hand side.</param>
        /// <param name="b">A <see cref="LayoutDimension"/> on the right hand side.</param>
        /// <returns></returns>
        public static bool operator !=(LayoutDimension a, LayoutDimension b)
        {
            if (a.isFixedValue == b.isFixedValue)
            {
                return a.value != b.value;
            }

            return false;
        }

        /// <summary>
        /// Comparison operators for LayoutDimension. It compares two LayoutDimensions. If both are fixed values, then it compares their values. Otherwise, it returns false.
        /// </summary>
        /// <param name="a">A <see cref="LayoutDimension"/> on the left hand side.</param>
        /// <param name="b">A <see cref="LayoutDimension"/> on the right hand side.</param>
        /// <returns></returns>
        public static bool operator <(LayoutDimension a, LayoutDimension b)
        {
            if (a.isFixedValue && b.isFixedValue)
            {
                return a.value < b.value;
            }

            return false;
        }

        /// <summary>
        /// Comparison operators for LayoutDimension. It compares two LayoutDimensions. If both are fixed values, then it compares their values. Otherwise, it returns false.
        /// </summary>
        /// <param name="a">A <see cref="LayoutDimension"/> on the left hand side.</param>
        /// <param name="b">A <see cref="LayoutDimension"/> on the right hand side.</param>
        /// <returns></returns>
        public static bool operator >(LayoutDimension a, LayoutDimension b)
        {
            if (a.isFixedValue && b.isFixedValue)
            {
                return a.value > b.value;
            }

            return false;
        }

        /// <summary>
        /// Comparison operators for LayoutDimension. It compares two LayoutDimensions. If both are fixed values, then it compares their values. Otherwise, it returns false.
        /// </summary>
        /// <param name="a">A <see cref="LayoutDimension"/> on the left hand side.</param>
        /// <param name="b">A <see cref="LayoutDimension"/> on the right hand side.</param>
        /// <returns></returns>
        public static bool operator <=(LayoutDimension a, LayoutDimension b)
        {
            if (a.isFixedValue && b.isFixedValue)
            {
                return a.value <= b.value;
            }

            return false;
        }

        /// <summary>
        /// Comparison operators for LayoutDimension. It compares two LayoutDimensions. If both are fixed values, then it compares their values. Otherwise, it returns false.
        /// </summary>
        /// <param name="a">A <see cref="LayoutDimension"/> on the left hand side.</param>
        /// <param name="b">A <see cref="LayoutDimension"/> on the right hand side.</param>
        /// <returns></returns>
        public static bool operator >=(LayoutDimension a, LayoutDimension b)
        {
            if (a.isFixedValue && b.isFixedValue)
            {
                return a.value >= b.value;
            }

            return false;
        }

        /// <summary>
        /// Addition operator for LayoutDimension. If the size is fixed value, then it adds the value to the given float. Otherwise, it returns the given float. For example, float width = layoutWidth + 10; // Only valid when layoutWidth is fixed value. Otherwise, it will cause compile error.
        /// </summary>
        /// <param name="a">A <see cref="LayoutDimension"/> on the left hand side.</param>
        /// <param name="b">A <see cref="float"/> on the right hand side.</param>
        /// <returns>The sum of the fixed value of LayoutDimension and a float value.</returns>
        public static float operator +(LayoutDimension a, float b)
        {
            if (a.isFixedValue)
            {
                return a.value + b;
            }

            return b;
        }

        /// <summary>
        /// Addition operator for LayoutDimension. If the size is fixed value, then it adds the value to the given float. Otherwise, it returns the given float. For example, float width = 10 + layoutWidth; // Only valid when layoutWidth is fixed value. Otherwise, it will cause compile error.
        /// </summary>
        /// <param name="a">A <see cref="float"/> on the left hand side.</param>
        /// <param name="b">A <see cref="LayoutDimension"/> on the right hand side.</param>
        /// <returns>The sum of a float value and the fixed value of LayoutDimension.</returns>
        public static float operator +(float a, LayoutDimension b)
        {
            if (b.isFixedValue)
            {
                return a + b.value;
            }

            return a;
        }

        /// <summary>
        /// Subtraction operator for LayoutDimension. If the size is fixed value, then it subtracts the value from the given float. Otherwise, it returns the negative of the given float. For example, float width = layoutWidth - 10; // Only valid when layoutWidth is fixed value. Otherwise, it will cause compile error.
        /// </summary>
        /// <param name="a">A <see cref="LayoutDimension"/> on the left hand side.</param>
        /// <param name="b">A <see cref="float"/> on the right hand side.</param>
        /// <returns>The subtraction of the fixed value of LayoutDimension and a float value.</returns>
        public static float operator -(LayoutDimension a, float b)
        {
            if (a.isFixedValue)
            {
                return a.value - b;
            }

            return -b;
        }

        /// <summary>
        /// Subtraction operator for LayoutDimension. If the size is fixed value, then it subtracts the value from the given float. Otherwise, it returns the given float. For example, float width = 10 - layoutWidth; // Only valid when layoutWidth is fixed value. Otherwise, it will cause compile error.
        /// </summary>
        /// <param name="a">A <see cref="float"/> on the left hand side.</param>
        /// <param name="b">A <see cref="LayoutDimension"/> on the right hand side.</param>
        /// <returns>The subtraction of a float value and the fixed value of LayoutDimension.</returns>
        public static float operator -(float a, LayoutDimension b)
        {
            if (b.isFixedValue)
            {
                return a - b.value;
            }

            return a;
        }

        /// <summary>
        /// Multiplication operator for LayoutDimension. If the size is fixed value, then it multiplies the value with the given float. Otherwise, it returns the negative of the given float. For example, float width = layoutWidth * 10; // Only valid when layoutWidth is fixed value. Otherwise, it will cause compile error.
        /// </summary>
        /// <param name="a">A <see cref="LayoutDimension"/> on the left hand side.</param>
        /// <param name="b">A <see cref="float"/> on the right hand side.</param>
        /// <returns>The multiplication of the fixed value of LayoutDimension and a float value.</returns>
        public static float operator *(LayoutDimension a, float b)
        {
            if (a.isFixedValue)
            {
                return a.value * b;
            }

            return -b;
        }

        /// <summary>
        /// Multiplication operator for LayoutDimension. If the size is fixed value, then it multiplies the value with the given float. Otherwise, it returns the given float. For example, float width = 10 * layoutWidth; // Only valid when layoutWidth is fixed value. Otherwise, it will cause compile error.
        /// </summary>
        /// <param name="a">A <see cref="float"/> on the left hand side.</param>
        /// <param name="b">A <see cref="LayoutDimension"/> on the right hand side.</param>
        /// <returns>The multiplication of a float value and the fixed value of LayoutDimension.</returns>
        public static float operator *(float a, LayoutDimension b)
        {
            if (b.isFixedValue)
            {
                return a * b.value;
            }

            return a;
        }

        /// <summary>
        /// Division operator for LayoutDimension. If the size is fixed value, then it divides the value by the given float. Otherwise, it returns the negative of the given float. For example, float width = layoutWidth / 10; // Only valid when layoutWidth is fixed value. Otherwise, it will cause compile error.
        /// </summary>
        /// <param name="a">A <see cref="LayoutDimension"/> on the left hand side.</param>
        /// <param name="b">A <see cref="float"/> on the right hand side.</param>
        /// <returns>The division of the fixed value of LayoutDimension and a float value.</returns>
        public static float operator /(LayoutDimension a, float b)
        {
            if (a.isFixedValue)
            {
                return a.value / b;
            }

            return -b;
        }

        /// <summary>
        /// Division operator for LayoutDimension. If the size is fixed value, then it divides the value by the given float. Otherwise, it returns the given float. For example, float width = 10 / layoutWidth; // Only valid when layoutWidth is fixed value. Otherwise, it will cause compile error.
        /// </summary>
        /// <param name="a">A <see cref="float"/> on the left hand side.</param>
        /// <param name="b">A <see cref="LayoutDimension"/> on the right hand side.</param>
        /// <returns>The division of a float value and the fixed value of LayoutDimension.</returns>
        public static float operator /(float a, LayoutDimension b)
        {
            if (b.isFixedValue)
            {
                return a / b.value;
            }

            return a;
        }

        /// <summary>
        /// Constant value that indicates WrapContent for LayoutDimension. For example, LayoutDimension layoutWidth = LayoutDimension.WrapContent;
        /// </summary>
        public const float WrapContent = LayoutParamPolicies.WrapContent;

        /// <summary>
        /// Constant value that indicates MatchParent for LayoutDimension. For example, LayoutDimension layoutWidth = LayoutDimension.MatchParent;
        /// </summary>
        public const float MatchParent = LayoutParamPolicies.MatchParent;
    }
}
