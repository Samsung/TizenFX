/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a range(min, max) value.
    /// </summary>
    public struct Range
    {
        /// <summary>
        /// Initializes a new instance of the range with the specified values.
        /// </summary>
        /// <param name="min">Minimum value of the range.</param>
        /// <param name="max">Maximum value of the range.</param>
        /// <exception cref="ArgumentException"><paramref name="max"/> is less than <paramref name="min"/>.</exception>
        public Range(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentException($"min can't be greater than max.");
            }
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Gets or sets the minimum value of the range.
        /// </summary>
        public int Min
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum value of the range.
        /// </summary>
        public int Max
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the length of the range.
        /// </summary>
        public int Length => Max - Min;

        /// <summary>
        /// Determines if the specified value is within the range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>true if the value is within the range; otherwise false.</returns>
        public bool IsInside(int value)
        {
            return Min <= value && value <= Max;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => $"Min={Min.ToString()}, Max={Max.ToString()}";

        /// <summary>
        /// Gets the hash code for this instance of <see cref="Range"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="Range"/>.</returns>
        public override int GetHashCode()
        {
            return new { Min, Max }.GetHashCode();
        }

        /// <summary>
        /// Compares an object to an instance of <see cref="Range"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the two ranges are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Range && this == (Range)obj;
        }

        /// <summary>
        /// Compares two instances of <see cref="Range"/> for equality.
        /// </summary>
        /// <param name="range1">A <see cref="Range"/> to compare.</param>
        /// <param name="range2">A <see cref="Range"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="Range"/> are equal; otherwise false.</returns>
        public static bool operator ==(Range range1, Range range2)
        {
            return range1.Min == range2.Min && range1.Max == range2.Max;
        }

        /// <summary>
        /// Compares two instances of <see cref="Range"/> for inequality.
        /// </summary>
        /// <param name="range1">A <see cref="Range"/> to compare.</param>
        /// <param name="range2">A <see cref="Range"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="Range"/> are not equal; otherwise false.</returns>
        public static bool operator !=(Range range1, Range range2)
        {
            return !(range1 == range2);
        }
    }
}

