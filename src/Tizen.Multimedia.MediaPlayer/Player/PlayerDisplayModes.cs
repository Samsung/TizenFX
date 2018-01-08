/*
 * Copyright (c) 2016 Samsung Electronics Co.; Ltd All Rights Reserved
 *
 * Licensed under the Apache License; Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing; software
 * distributed under the License is distributed on an AS IS BASIS;
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND; either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Tizen.Multimedia
{
    /// <summary>
    /// Specifies display modes for <see cref="Player"/>.
    /// </summary>
    /// <remarks>
    /// The modes are implemented as integers, rather than as an enumeration, to allow for extensibility.
    /// </remarks>
    /// <seealso cref="PlayerDisplaySettings.Mode"/>
    /// <since_tizen>4</since_tizen>
    public static class PlayerDisplayModes
    {
        /// <summary>
        /// Letter box.
        /// </summary>
        public const int LetterBox = 0;

        /// <summary>
        /// Original size.
        /// </summary>
        public const int OriginalSize = 1;

        /// <summary>
        /// Full-screen.
        /// </summary>
        public const int FullScreen = 2;

        /// <summary>
        /// Cropped full-screen.
        /// </summary>
        public const int CroppedFull = 3;

        /// <summary>
        /// Original size (if surface size is larger than video size(width/height)) or
        /// letter box (if video size(width/height) is larger than surface size).
        /// </summary>
        public const int OriginalOrLetterBox = 4;

        /// <summary>
        /// Region of interest.
        /// </summary>
        /// <seealso cref="PlayerDisplaySettings.SetRoi(Rectangle)"/>
        public const int Roi = 5;
    }
}
