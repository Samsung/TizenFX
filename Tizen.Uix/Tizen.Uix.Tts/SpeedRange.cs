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


namespace Tizen.Uix.Tts
{
    /// <summary>
    /// This class holds the Spped Range Values
    /// </summary>
    public class SpeedRange
    {
        internal SpeedRange(int min, int normal, int max)
        {
            this.Min = min;
            this.Normal = normal;
            this.Max = max;
        }

        /// <summary>
        /// The Max Spped Range Value
        /// </summary>
        public int Max
        {
            get;
            internal set;
        }

        /// <summary>
        /// The Min Spped Range Value
        /// </summary>
        public int Min
        {
            get;
            internal set;
        }

        /// <summary>
        /// The Normal Spped Range Value
        /// </summary>
        public int Normal
        {
            get;
            internal set;
        }
    }
}
