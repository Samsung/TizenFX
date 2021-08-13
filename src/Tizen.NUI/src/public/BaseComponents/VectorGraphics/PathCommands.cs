/* 
* Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// Data class that contains information about a list of path commands.
    /// For each command from the commands array, an appropriate number of points in points array should be specified.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PathCommands
    {
        private PathCommandType[] commands; //The array of commands.
        private uint commandCount; //The number of commands.
        private float[] points; //The array of points.
        private uint pointCount; //The number of points.

        /// <summary>
        /// Initialize PathCommands.
        /// </summary>
        /// <param name="commands">The array of commands.</param>
        /// <param name="commandCount">The number of commands.</param>
        /// <param name="points">The array of points.</param>
        /// <param name="pointCount">The number of points.</param>
        /// <exception cref="ArgumentNullException"> Thrown when commands or points are null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PathCommands(PathCommandType[] commands, uint commandCount, float[] points, uint pointCount)
        {
            if (commands == null)
            {
                throw new ArgumentNullException(nameof(commands));
            }
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }
            this.commands = commands;
            this.commandCount = commandCount;
            this.points = points;
            this.pointCount = pointCount;
        }

        /// <summary>
        /// Enumeration specifying the values of the path commands.
        /// Not to be confused with the path commands from the svg path element (like M, L, Q, H and many others).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum PathCommandType
        {
            /// <summary>
            /// Ends the current sub-path and connects it with its initial point. This command doesn't expect any points.
            /// </summary>
            Close = 0,
            /// <summary>
            /// Sets a new initial point of the sub-path and a new current point. This command expects 1 point: the starting position.
            /// </summary>
            MoveTo,
            /// <summary>
            /// Draws a line from the current point to the given point and sets a new value of the current point. This command expects 1 point: the end-position of the line.
            /// </summary>
            LineTo,
            /// <summary>
            /// Draws a cubic Bezier curve from the current point to the given point using two given control points and sets a new value of the current point. This command expects 3 points: the 1st control-point, the 2nd control-point, the end-point of the curve.
            /// </summary>
            CubicTo
        }

        /// <summary>
        /// The commands array.
        /// </summary>
        /// <returns>The array of commands.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PathCommandType[] GetCommands()
        {
            return commands;
        }

        /// <summary>
        /// The number of commands.
        /// </summary>
        /// <returns>The number of commands.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetCommandCount()
        {
            return commandCount;
        }

        /// <summary>
        /// The points array
        /// </summary>
        /// <returns>The array of points.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float[] GetPoints()
        {
            return points;
        }

        /// <summary>
        /// The number of points.
        /// </summary>
        /// <returns>The number of points.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetPointCount()
        {
            return pointCount;
        }
    }
}

