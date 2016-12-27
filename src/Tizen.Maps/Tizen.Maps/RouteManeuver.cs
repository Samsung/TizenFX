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

namespace Tizen.Maps
{
    /// <summary>
    /// Route Maneuver information, used in Route Search requests
    /// </summary>
    public class RouteManeuver
    {
        private Interop.RouteDirection _direction;
        private Interop.RouteTurnType _turntype;
        private Geocoordinates _position;
        private string _road = string.Empty;
        private string _instruction = string.Empty;
        private string _locale = string.Empty;
        private int _timeToNextInstruction;
        private double _distanceToNextInstruction;

        internal RouteManeuver(IntPtr nativeHandle)
        {
            var handle = new Interop.RouteManeuverHandle(nativeHandle);

            var err = Interop.RouteManeuver.GetDirectionId(handle, out _direction);
            err.WarnIfFailed("Failed to get direction type for this maneuver");

            err = Interop.RouteManeuver.GetTurnType(handle, out _turntype);
            err.WarnIfFailed("Failed to get turn type for this maneuver");

            err = Interop.RouteManeuver.GetTimeToNextInstruction(handle, out _timeToNextInstruction);
            err.WarnIfFailed("Failed to get time to next instruction for this maneuver");

            err = Interop.RouteManeuver.GetDistanceToNextInstruction(handle, out _distanceToNextInstruction);
            err.WarnIfFailed("Failed to get distance to next instruction for this maneuver");

            string instruction;
            err = Interop.RouteManeuver.GetInstructionText(handle, out instruction);
            if (err.WarnIfFailed("Failed to get instruction text for this maneuver"))
            {
                _instruction = instruction;
            }

            string locale;
            err = Interop.RouteManeuver.GetLocale(handle, out locale);
            if (err.WarnIfFailed("Failed to get locale for this maneuver"))
            {
                _locale = locale;
            }

            string road;
            err = Interop.RouteManeuver.GetRoadName(handle, out road);
            if (err.WarnIfFailed("Failed to get road name for this maneuver"))
            {
                _road = road;
            }

            IntPtr positionHandle;
            err = Interop.RouteManeuver.GetPosition(handle, out positionHandle);
            if (err.WarnIfFailed("Failed to get position for this maneuver"))
            {
                _position = new Geocoordinates(positionHandle);
            }
        }

        /// <summary>
        /// Direction type for this maneuver
        /// </summary>
        public DirectionType Direction { get { return (DirectionType)_direction; } }

        /// <summary>
        /// Turn type for this maneuver
        /// </summary>
        public TurnInstruction Turn { get { return (TurnInstruction)_turntype; } }

        /// <summary>
        /// Position for this maneuver
        /// </summary>
        public Geocoordinates Position { get { return _position; } }

        /// <summary>
        /// Name of the road for this maneuver
        /// </summary>
        public string Road { get { return string.IsNullOrEmpty(_road) ? "" : _road; } }

        /// <summary>
        /// Instruction text for this maneuver
        /// </summary>
        public string Instruction { get { return string.IsNullOrEmpty(_instruction) ? "" : _instruction; } }

        /// <summary>
        /// Locale for this maneuver
        /// </summary>
        public string Locale { get { return string.IsNullOrEmpty(_locale) ? "" : _locale; } }

        /// <summary>
        /// Time to next instruction for this maneuver
        /// </summary>
        public int TimeToNextInstruction { get { return _timeToNextInstruction; } }

        /// <summary>
        /// Distance to next instruction for this maneuver
        /// </summary>
        public double DistanceToNextInstruction { get { return _distanceToNextInstruction; } }
    }
}
