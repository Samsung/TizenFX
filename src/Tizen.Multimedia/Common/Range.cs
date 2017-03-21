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
        /// Initializes a new instance of the Range with the specified values.
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
        /// Gets or sets minimum value of the range.
        /// </summary>
        public int Min
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets maximum value of the range.
        /// </summary>
        public int Max
        {
            get;
            set;
        }

        /// <summary>
        /// Gets length of the range.
        /// </summary>
        public int Length => Max - Min;

        /// <summary>
        /// Determines if the specified value is inside of the range.
        /// </summary>
        /// <param name="value">A value to check.</param>
        /// <returns>true if the value is inside of the range; otherwise false.</returns>
        public bool IsInside(int value)
        {
            return Min <= value && value <= Max;
        }

        public override string ToString() => $"Min={Min.ToString()}, Max={Max.ToString()}";

        public override int GetHashCode()
        {
            return new { Min, Max }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Range && this == (Range)obj;
        }

        public static bool operator ==(Range lhs, Range rhs)
        {
            return lhs.Min == rhs.Min && lhs.Max == rhs.Max;
        }

        public static bool operator !=(Range lhs, Range rhs)
        {
            return !(lhs == rhs);
        }
    }
}

