/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd.
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

/*
 * Copyright (C) 2017 The Android Open Source Project
 *
 * Modified by Joogab Yun(joogab.yun@samsung.com)
 */

using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Utility
{
    /// <summary>
    /// Accumulating Velocity Tracker
    /// </sumary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AccumulatingVelocityTrackerStrategy : VelocityTrackerStrategy
    {
        /// <summary>
        /// Positions and event time information
        /// </summary>
        protected struct Movement
        {
            public uint EventTime;
            public float Position;
            public Movement(uint pEventTime, float pPosition)
            {
                EventTime = pEventTime;
                Position = pPosition;
            }
        };

        private const int mHistorySize = 20;
        private uint mMaximumTime;
        private uint mLastEventTime = 0;
        private float mLastPosition = 0;
        private uint mAssumePointerStoppedTime = 40; // 40ms
        protected SortedDictionary<int, List<Movement>> mMovements;


        /// <summary>
        /// Create an instance of AccumulatingVelocityTrackerStrategy.
        /// </sumary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccumulatingVelocityTrackerStrategy(uint maximumTime) : base()
        {
            mMaximumTime = maximumTime;
            mMovements = new SortedDictionary<int, List<Movement>>();
        }

        /// <summary>
        /// Adds movement information
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void AddMovement(uint eventTime, int pointerId, float position)
        {
            if (!mMovements.ContainsKey(pointerId))
            {
                mMovements.Add(pointerId, new List<Movement>());
            }

            List<Movement> movements = mMovements[pointerId];
            int size = movements.Count;
            if (size > 0)
            {
                if (eventTime - mLastEventTime > mAssumePointerStoppedTime)
                {
                    mMovements.Clear();
                    return;
                }

                if (mLastPosition == position)
                {
                    return;
                }

                if (movements[size - 1].EventTime == eventTime)
                {
                    movements.RemoveAt(size - 1);
                }

                if (size > mHistorySize)
                {
                    movements.RemoveAt(0);
                }
            }


            mLastEventTime = eventTime;
            mLastPosition = position;
            movements.Add(new Movement(eventTime, position));

            // Clear moves that are not among the latest moves.
            while (movements.Count > 0 && eventTime - movements[0].EventTime > mMaximumTime)
            {
                movements.RemoveAt(0);
            }
        }

        /// <summary>
        /// Resets the velocity tracker state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Clear()
        {
            mMovements.Clear();
        }
    }
}
