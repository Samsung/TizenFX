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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides data for the <see cref="MediaStreamConfiguration.SeekingOccurred"/> event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MediaStreamSeekingOccurredEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the MediaStreamSeekingOccurredEventArgs class.
        /// </summary>
        /// <param name="offset">The value indicating the new position to seek.</param>
        /// <since_tizen> 3 </since_tizen>
        public MediaStreamSeekingOccurredEventArgs(ulong offset)
        {
            Offset = offset;
        }

        /// <summary>
        /// Gets the next new play position as a result of seeking operation.
        /// </summary>
        /// <remarks>
        /// The next playback position after SetPlayPositionAsync could be a little bit different with its input position.<br/>
        /// So user should push the next media data using this time offset in nanoseconds.
        /// </remarks>
        /// <seealso cref="Player.SetPlayPositionAsync"/>
        /// <seealso cref="Player.SetPlayPositionNanosecondsAsync"/>
        /// <since_tizen> 3 </since_tizen>
        public ulong Offset { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString() => $"Offset : { Offset.ToString() }";
    }
}
