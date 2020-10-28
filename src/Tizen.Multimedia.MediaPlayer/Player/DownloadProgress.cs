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

namespace Tizen.Multimedia
{

    /// <summary>
    /// Represents data for a downloading status.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct DownloadProgress
    {
        /// <summary>
        /// Initializes a new instance of the DownloadProgress struct.
        /// </summary>
        /// <param name="start">The position that downloading started in percentage.</param>
        /// <param name="current">The position indicating the current downloading progress in percentage.</param>
        /// <since_tizen> 3 </since_tizen>
        public DownloadProgress(int start, int current)
        {
            Start = start;
            Current = current;
            Log.Debug(PlayerLog.Tag, "start : " + start + ", current : " + current);
        }

        /// <summary>
        /// Gets or sets the starting position.
        /// </summary>
        /// <value>The position that downloading started in percentage.</value>
        /// <since_tizen> 3 </since_tizen>
        public int Start
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current position(The end position of received data).
        /// </summary>
        /// <value>The position indicating the current downloading progress in percentage.</value>
        /// <since_tizen> 3 </since_tizen>
        public int Current
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString()
        {
            return $"Start={ Start.ToString() }, Current={ Current.ToString() }";
        }
    }
}
