/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] A type that represents a layout length. Currently, this implies pixels, but could be extended to handle device dependant sizes, etc.
    /// </summary>
    public struct LayoutLength
    {
        private float _value;

        /// <summary>
        /// [Draft] Constructor from an int
        /// </summary>
        /// <param name="value">Int to initialize with.</param>
        public LayoutLength(int value)
        {
            _value = value;
        }

        /// <summary>
        /// [Draft] Constructor from a float
        /// </summary>
        /// <param name="value">Float to initialize with.</param>
        public LayoutLength(float value)
        {
            _value = value;
        }

        /// <summary>
        /// [Draft] Constructor from a LayoutLength
        /// </summary>
        /// <param name="layoutLength">LayoutLength object to initialize with.</param>
        public LayoutLength(LayoutLength layoutLength)
        {
            _value = layoutLength._value;
        }

        /// <summary>
        /// [Draft] Return value as rounded value (whole number), best used as final output
        /// </summary>
        /// <returns>The layout length value as a rounded whole number.</returns>
        public float AsRoundedValue()
        {
            return (float)Math.Round((decimal)_value, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// [Draft] Return value as the raw decimal value, best used for calculations
        /// </summary>
        /// <returns>The layout length value as the raw decimal value.</returns>
        public float AsDecimal()
        {
            return _value;
        }

        /// <summary>
        /// [Draft] The == operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value</param>
        /// <returns>true if LayoutLengths are equal</returns>
        public static bool operator ==(LayoutLength arg1, LayoutLength arg2)
        {
            return arg1.Equals(arg2);
        }

        /// <summary>
        /// [Draft] The != operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value</param>
        /// <returns>true if LayoutLengths are not equal</returns>
        public static bool operator !=(LayoutLength arg1, LayoutLength arg2)
        {
            return !arg1.Equals(arg2);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal LayoutLength, else false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is LayoutLength)
            {
                return this.Equals((LayoutLength)obj);
            }
            return false;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="layoutLength">The LayoutLength to compare with the current LayoutLength.</param>
        /// <returns>true if equal LayoutLengths, else false.</returns>
        public bool Equals(LayoutLength layoutLength)
        {
            return (Math.Abs(_value - layoutLength._value ) <= float.Epsilon);
        }

        /// <summary>
        /// A hash code for the current object.
        /// </summary>
        public override int GetHashCode()
        {
            return (int)Math.Ceiling(_value);
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the addition.</returns>
        public static LayoutLength operator +(LayoutLength arg1, LayoutLength arg2)
        {
            return new LayoutLength( arg1._value + arg2._value );
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the addition.</returns>
        public static LayoutLength operator +(LayoutLength arg1, int arg2)
        {
            return new LayoutLength(arg1._value + (float)arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the subtraction.</returns>
        public static LayoutLength operator -(LayoutLength arg1, LayoutLength arg2)
        {
            return new LayoutLength(arg1._value - arg2._value);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the subtraction.</returns>
        public static LayoutLength operator -(LayoutLength arg1, int arg2)
        {
            return new LayoutLength(arg1._value - (float)arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the multiplication.</returns>
        public static LayoutLength operator *(LayoutLength arg1, LayoutLength arg2)
        {
            return new LayoutLength(arg1._value * arg2._value);
        }

        /// <summary>
        /// Th multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The int value to scale the LayoutLength.</param>
        /// <returns>The LayoutLength containing the result of the scaling.</returns>
        public static LayoutLength operator *(LayoutLength arg1, int arg2)
        {
            return new LayoutLength(arg1._value * arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the division.</returns>
        public static LayoutLength operator /(LayoutLength arg1, LayoutLength arg2)
        {
            return new LayoutLength(arg1._value /  arg2._value);
        }

        /// <summary>
        /// Th division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The int value to scale the vector by.</param>
        /// <returns>The LayoutLength containing the result of the scaling.</returns>
        public static LayoutLength operator /(LayoutLength arg1, int arg2)
        {
            return new LayoutLength(arg1._value / (float)arg2);
        }
    }
}
