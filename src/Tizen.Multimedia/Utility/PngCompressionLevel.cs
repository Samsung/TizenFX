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

namespace Tizen.Multimedia.Utility
{
    /// <summary>
    /// PNG Image Compression Level
    /// </summary>
    public enum PngCompression
    {
        /// <summary>
        /// No Compression
        /// </summary>
        NoCompression = Interop.PngCompression.NoCompression,
        /// <summary>
        /// Compression Level 1. Best speed
        /// </summary>
        Level1 = Interop.PngCompression.Level1,
        /// <summary>
        /// Compression Level 2
        /// </summary>
        Level2 = Interop.PngCompression.Level2,
        /// <summary>
        /// Compression Level 3
        /// </summary>
        Level3 = Interop.PngCompression.Level3,
        /// <summary>
        /// Compression Level 4
        /// </summary>
        Level4 = Interop.PngCompression.Level4,
        /// <summary>
        /// Compression Level 5
        /// </summary>
        Level5 = Interop.PngCompression.Level5,
        /// <summary>
        /// Compression Level 6
        /// </summary>
        Level6 = Interop.PngCompression.Level6,
        /// <summary>
        /// Compression Level 7
        /// </summary>
        Level7 = Interop.PngCompression.Level7,
        /// <summary>
        /// Compression Level 8
        /// </summary>
        Level8 = Interop.PngCompression.Level8,
        /// <summary>
        /// Compression Level 9
        /// </summary>
        Level9 = Interop.PngCompression.Level9,
    }
}
