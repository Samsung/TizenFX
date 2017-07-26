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
    /// This class holds the speed range values.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class SpeedRange
    {
        internal SpeedRange(int min, int normal, int max)
        {
            this.Min = min;
            this.Normal = normal;
            this.Max = max;
        }

        /// <summary>
        /// The max speed range value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Max
        {
            get;
            internal set;
        }

        /// <summary>
        /// The min speed range value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Min
        {
            get;
            internal set;
        }

        /// <summary>
        /// The normal speed range value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Normal
        {
            get;
            internal set;
        }
    }
}
