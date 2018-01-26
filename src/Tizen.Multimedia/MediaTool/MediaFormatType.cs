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
    /// Specifies the media format types.
    /// </summary>
    /// <seealso cref="MediaFormat"/>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaFormatType
    {
        /// <summary>
        /// Audio media format.
        /// </summary>
        Audio = 0x01000000,

        /// <summary>
        /// Video media format.
        /// </summary>
        Video = 0x02000000,

        /// <summary>
        /// Container media format.
        /// </summary>
        Container = 0x04000000,

        /// <summary>
        /// Text media format.
        /// </summary>
        Text = 0x03000000,
    }
}
