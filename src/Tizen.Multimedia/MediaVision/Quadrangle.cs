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
    /// This class represents location of the object bounded by quadrangle defined by four 2D points.
    /// </summary>
    public class Quadrangle
    {
        internal Quadrangle()
        {

        }

        /// <summary>
        /// The constructor of the Quadrangle class
        /// </summary>
        /// <param name="points">four points that define object bounding quadrangle</param>
        public Quadrangle(Point[] points)
        {
            if (points.Length != 4)
            {
                throw new ArgumentException("Invalid parameter");
            }

            Points = points;
        }

        /// <summary>
        /// Gets four points that define object bounding quadrangle
        /// </summary>
        public Point[] Points { get; internal set; }

        internal new string ToString()
        {
            return string.Format("[{0}, {1}, {2}, {3}]", Points[0].ToString(), Points[1].ToString(),
                Points[2].ToString(), Points[3].ToString());
        }
    }
}
