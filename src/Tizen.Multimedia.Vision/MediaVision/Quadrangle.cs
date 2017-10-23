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

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents a region with 4 <see cref="Point"/>s.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Quadrangle
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Quadrangle"/> class with an array of <see cref="Point"/>.
        /// </summary>
        /// <remarks><paramref name="points"/> must have 4 elements.</remarks>
        /// <param name="points">Four points that define the object bounding quadrangle.</param>
        /// <exception cref="ArgumentException">The length of <paramref name="points"/> is not 4.</exception>
        /// <since_tizen> 3 </since_tizen>
        public Quadrangle(Point[] points)
        {
            if (points.Length != 4)
            {
                throw new ArgumentException($"{nameof(points)} must have 4 elements.");
            }

            Points = points;
        }

        /// <summary>
        /// Gets four points that define the object bounding quadrangle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Point[] Points { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
            $"[{{{Points[0].ToString()}}}, {{{Points[1].ToString()}}}, {{{Points[2].ToString()}}}, {{{Points[3].ToString()}}}]";
    }
}
