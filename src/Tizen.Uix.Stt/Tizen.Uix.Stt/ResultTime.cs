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


using static Interop.Stt;

namespace Tizen.Uix.Stt
{
    /// <summary>
    /// This Class represents the result of recognition result from the engine.
    /// </summary>
    public class ResultTime
    {
        internal ResultTime(int index, TimeEvent e, string text, long startTime, long endTime)
        {
            Index = index;
            TokenEvent = e;
            Text = text;
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// The result index
        /// </summary>
        public int Index
        {
            get;
            internal set;
        }

        /// <summary>
        /// The token event
        /// </summary>
        public TimeEvent TokenEvent
        {
            get;
            internal set;
        }

        /// <summary>
        /// The result text
        /// </summary>
        public string Text
        {
            get;
            internal set;
        }

        /// <summary>
        /// The start time of result text
        /// </summary>
        public long StartTime
        {
            get;
            internal set;
        }

        /// <summary>
        /// The end time of result text
        /// </summary>
        public long EndTime
        {
            get;
            internal set;
        }
    }
}
