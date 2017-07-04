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
    /// Represents synchronized lyrics information of media.
    /// </summary>
    public class SyncLyrics
    {
        /// <summary>
        /// Initialize a new instance of the MetadataExtractor class with the specified lyrics and timestamp.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="lyrics">The text of synclyrics to set.</param>
        /// <param name="timestamp">The timestamp of synclyrics to set.</param>
        public SyncLyrics(string lyrics, uint timestamp)
        {
            Lyrics = lyrics;
            Timestamp = timestamp;
        }

        /// <summary>
        /// The text representation of the lyrics.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Lyrics { get; }

        /// <summary>
        /// The time information of the lyrics.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Timestamp { get; }
    }
}
