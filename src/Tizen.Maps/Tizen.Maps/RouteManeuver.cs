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
    /// Route maneuver information used in route search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class RouteManeuver
    {
        private Interop.RouteDirection _direction;
        private Interop.RouteTurnType _turntype;
        private Geocoordinates _coordinates;
        private string _road;
        private string _instruction;
        private string _locale;
        private int _timeToNextInstruction;
        private double _distanceToNextInstruction;

        internal RouteManeuver(Interop.RouteManeuverHandle handle)
        {
            _direction = handle.Direction;
            _turntype = handle.TurnType;
            _coordinates = new Geocoordinates(handle.Coordinates);
            _road = handle.RoadName;
            _instruction = handle.Instruction;
            _locale = handle.Locale;
            _timeToNextInstruction = handle.TimeToNextInstruction;
            _distanceToNextInstruction = handle.DistanceToNextInstruction;
        }

        /// <summary>
        /// Gets the direction type for this maneuver.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DirectionType Direction { get { return (DirectionType)_direction; } }

        /// <summary>
        /// Gets the turn type for this maneuver.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TurnInstruction Turn { get { return (TurnInstruction)_turntype; } }

        /// <summary>
        /// Gets a geographical coordinates position for this maneuver.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Geocoordinates Position { get { return _coordinates; } }

        /// <summary>
        /// Gets a name of the road for this maneuver.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Road { get { return _road; } }

        /// <summary>
        /// Gets an instruction text for this maneuver.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Instruction { get { return _instruction; } }

        /// <summary>
        /// Gets a locale for this maneuver.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Locale { get { return _locale; } }

        /// <summary>
        /// Gets the  time to next instruction for this maneuver.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int TimeToNextInstruction { get { return _timeToNextInstruction; } }

        /// <summary>
        /// Gets the distance to next instruction for this maneuver.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double DistanceToNextInstruction { get { return _distanceToNextInstruction; } }
    }
}
