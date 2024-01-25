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
    /// Specifies the audio channels.
    /// </summary>
    /// <seealso cref="AudioCapture"/>
    /// <seealso cref="AsyncAudioCapture"/>
    /// <seealso cref="AudioPlayback"/>
    /// <since_tizen> 3 </since_tizen>
    public enum AudioChannel
    {
        /// <summary>
        /// Mono.
        /// </summary>
        Mono = 0x80,

        /// <summary>
        /// Stereo.
        /// </summary>
        Stereo,

        /// <summary>
        /// 3 audio channels
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        MultiChannel3,

        /// <summary>
        /// 4 audio channels
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        MultiChannel4,

        /// <summary>
        /// 5 audio channels
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        MultiChannel5,

        /// <summary>
        /// 6 audio channels
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        MultiChannel6,

        /// <summary>
        /// 7 audio channels
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        MultiChannel7,

        /// <summary>
        /// 8 audio channels
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        MultiChannel8,

        /// <summary>
        /// 9 audio channels
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        MultiChannel9,

        /// <summary>
        /// 10 audio channels
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        MultiChannel10,

        /// <summary>
        /// 11 audio channels
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        MultiChannel11,

        /// <summary>
        /// 12 audio channels
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        MultiChannel12,

        /// <summary>
        /// 13 audio channels
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        MultiChannel13,

        /// <summary>
        /// 14 audio channels
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        MultiChannel14,

        /// <summary>
        /// 15 audio channels
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        MultiChannel15,

        /// <summary>
        /// 16 audio channels
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        MultiChannel16
    }
}
