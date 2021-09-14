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
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// Data class that contains information about a list of path commands.
    /// For each command from the commands array, an appropriate number of points in points array should be specified.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class PathCommands
    {
        private IEnumerable<PathCommandType> commands; //The array of commands.
        private IEnumerable<float> points; //The array of points.

        /// <summary>
        /// Initialize PathCommands.
        /// </summary>
        /// <param name="commands">The array of commands.</param>
        /// <param name="points">The array of points.</param>
        /// <exception cref="ArgumentNullException"> Thrown when commands or points are null. </exception>
        /// <since_tizen> 9 </since_tizen>
        public PathCommands(IEnumerable<PathCommandType> commands, IEnumerable<float> points)
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
            this.points = points;
        }

        /// <summary>
        /// The commands array.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when commands is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        public IEnumerable<PathCommandType> Commands
        {
            get
            {
                return commands;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                commands = value;
            }
        }

        /// <summary>
        /// The points array
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when points is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        public IEnumerable<float> Points
        {
            get
            {
                return points;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                points = value;
            }
        }
    }
}

