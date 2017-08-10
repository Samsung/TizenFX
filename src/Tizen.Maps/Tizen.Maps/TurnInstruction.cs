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

namespace Tizen.Maps
{
    /// <summary>
    /// Turn Instruction type for route maneuver
    /// </summary>
    /// <since_tizen>3</since_tizen>
    public enum TurnInstruction
    {
        /// <summary>
        /// Indicates unknown instruction.
        /// </summary>
        None = Interop.RouteTurnType.None,
        /// <summary>
        /// Indicates instruction to move straight.
        /// </summary>
        Straight = Interop.RouteTurnType.Straight,
        /// <summary>
        /// Indicates instruction to bear right.
        /// </summary>
        BearRight = Interop.RouteTurnType.BearRight,
        /// <summary>
        /// Indicates instruction to turn slightly to the right.
        /// </summary>
        LightRight = Interop.RouteTurnType.LightRight,
        /// <summary>
        /// Indicates instruction to turn right.
        /// </summary>
        Right = Interop.RouteTurnType.Right,
        /// <summary>
        /// Indicates instruction to turn hard to the right.
        /// </summary>
        HardRight = Interop.RouteTurnType.HardRight,
        /// <summary>
        /// Indicates instruction to u-turn to the right.
        /// </summary>
        UturnRight = Interop.RouteTurnType.UturnRight,
        /// <summary>
        /// Indicates instruction to u-turn to the left.
        /// </summary>
        UturnLeft = Interop.RouteTurnType.UturnLeft,
        /// <summary>
        /// Indicates instruction to turn hard to the left.
        /// </summary>
        HardLeft = Interop.RouteTurnType.HardLeft,
        /// <summary>
        /// Indicates instruction to turn left.
        /// </summary>
        Left = Interop.RouteTurnType.Left,
        /// <summary>
        /// Indicates instruction to turn slightly to the left.
        /// </summary>
        LightLeft = Interop.RouteTurnType.LightLeft,
        /// <summary>
        /// Indicates instruction to bear left.
        /// </summary>
        BearLeft = Interop.RouteTurnType.BearLeft,
        /// <summary>
        /// Indicates instruction to take right fork.
        /// </summary>
        RightFork = Interop.RouteTurnType.RightFork,
        /// <summary>
        /// Indicates instruction to take left fork.
        /// </summary>
        LeftFork = Interop.RouteTurnType.LeftFork,
        /// <summary>
        /// Indicates instruction to take straight fork.
        /// </summary>
        StraightFork = Interop.RouteTurnType.StraightFork,
    }
}
