/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] A type that represents a layout length. Currently, this implies pixels, but could be extended to handle device dependant sizes, etc.
    /// </summary>
    public struct LayoutLength : IEquatable<LayoutLength>
    {
        private float value;

        /// <summary>
        /// [Draft] Constructor from an int
        /// </summary>
        /// <param name="value">Int to initialize with.</param>
        /// <since_tizen> 6 </since_tizen>
        public LayoutLength(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// [Draft] Constructor from a float
        /// </summary>
        /// <param name="value">Float to initialize with.</param>
        /// <since_tizen> 6 </since_tizen>
        public LayoutLength(float value)
        {
            this.value = value;
        }

        /// <summary>
        /// [Draft] Constructor from a LayoutLength
        /// </summary>
        /// <param name="layoutLength">LayoutLength object to initialize with.</param>
        /// <since_tizen> 6 </since_tizen>
        public LayoutLength(LayoutLength layoutLength)
        {
            value = layoutLength.value;
        }

        /// <summary>
        /// [Draft] Return value as rounded value (whole number), best used as final output
        /// </summary>
        /// <returns>The layout length value as a rounded whole number.</returns>
        /// <since_tizen> 6 </since_tizen>
        public float AsRoundedValue()
        {
            return (float)Math.Round((decimal)value, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// [Draft] Return value as the raw decimal value, best used for calculations
        /// </summary>
        /// <returns>The layout length value as the raw decimal value.</returns>
        /// <since_tizen> 6 </since_tizen>
        public float AsDecimal()
        {
            return value;
        }

        /// <summary>
        /// [Draft] The == operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value</param>
        /// <returns>true if LayoutLengths are equal</returns>
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
        public static bool operator !=(LayoutLength arg1, LayoutLength arg2)
        {
            return !arg1.Equals(arg2);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal LayoutLength, else false.</returns>
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
        public bool Equals(LayoutLength layoutLength)
        {
            return (Math.Abs(value - layoutLength.value) <= float.Epsilon);
        }

        /// <summary>
        /// A hash code for the current object.
        /// </summary>
        /// <returns>Calculated hash code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return (int)Math.Ceiling(value);
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the addition.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static LayoutLength operator +(LayoutLength arg1, LayoutLength arg2)
        {
            return new LayoutLength(arg1.value + arg2.value);
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the addition.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static LayoutLength operator +(LayoutLength arg1, int arg2)
        {
            return new LayoutLength(arg1.value + (float)arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the subtraction.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static LayoutLength operator -(LayoutLength arg1, LayoutLength arg2)
        {
            return new LayoutLength(arg1.value - arg2.value);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the subtraction.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static LayoutLength operator -(LayoutLength arg1, int arg2)
        {
            return new LayoutLength(arg1.value - (float)arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the multiplication.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static LayoutLength operator *(LayoutLength arg1, LayoutLength arg2)
        {
            return new LayoutLength(arg1.value * arg2.value);
        }

        /// <summary>
        /// Th multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The int value to scale the LayoutLength.</param>
        /// <returns>The LayoutLength containing the result of the scaling.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static LayoutLength operator *(LayoutLength arg1, int arg2)
        {
            return new LayoutLength(arg1.value * arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the division.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static LayoutLength operator /(LayoutLength arg1, LayoutLength arg2)
        {
            return new LayoutLength(arg1.value / arg2.value);
        }

        /// <summary>
        /// Th division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The int value to scale the vector by.</param>
        /// <returns>The LayoutLength containing the result of the scaling.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static LayoutLength operator /(LayoutLength arg1, int arg2)
        {
            return new LayoutLength(arg1.value / (float)arg2);
        }
    }
}
