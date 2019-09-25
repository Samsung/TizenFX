/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Specifies the channel position of <see cref="MediaFormatAudioMimeType.Pcm"/> media format.
    /// </summary>
    /// <remarks>This type is based on SMPTE 2036-2-2008 standard.</remarks>
    /// <seealso cref="MediaFormatAudioMimeType"/>
    /// <since_tizen> 6 </since_tizen>
    public enum MediaFormatAudioChannelPosition
    {
        /// <summary>
        /// This is used for position-less channels.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        None = -3,

        /// <summary>
        /// Mono channel.
        /// </summary>
        /// <remarks>If user want to set this value, <see cref="AudioMediaFormat.Channel"/> should be 1.</remarks>
        /// <since_tizen> 6 </since_tizen>
        Mono = -2,

        /// <summary>
        /// Invalid position.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Invaild = -1,

        /// <summary>
        /// A loudspeaker position located at far left and centered vertically with the middle layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        FrontLeft = 0,

        /// <summary>
        /// A loudspeaker position located at far right and centered vertically with the middle layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        FrontRight,

        /// <summary>
        /// A loudspeaker position located at the middle layer corresponding to the center of the television
        /// screen as viewed from the seating area.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        FrontCenter,

        /// <summary>
        /// A Low Frequency Effects(band-limited low frequency channel) loudspeaker position located at
        /// the bottom layer and normally far left front, when LFE2 is used.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        LFE1,

        /// <summary>
        /// A loudspeaker position located at far left back of the middle layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        BackLeft,

        /// <summary>
        /// A loudspeaker position located at far right back of the middle layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        BackRight,

        /// <summary>
        /// A loudspeaker position located mid-way between the front center and front left of the middle layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        FrontLeftOrCenter,

        /// <summary>
        /// A loudspeaker position located mid-way between the front center and front right of the middle layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        FrontRightOrCenter,

        /// <summary>
        /// A loudspeaker position located at center back of the middle layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        BackCenter,

        /// <summary>
        /// A Low Frequency Effects(band-limited low frequency channel) loudspeaker position located at the
        /// bottom layer, and is normally at far right front of the bottom layer, when LFE1 is used. 
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        LFE2,

        /// <summary>
        /// A loudspeaker position located at left side of the middle layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        SideLeft,

        /// <summary>
        /// A loudspeaker position located at right side of the middle layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        SideRight,

        /// <summary>
        /// A loudspeaker position located at far left front of the top layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        TopFrontLeft,

        /// <summary>
        /// A loudspeaker position located at far right front of the top layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        TopFrontRight,

        /// <summary>
        /// A loudspeaker position located at center front of the top layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        TopFrontCenter,

        /// <summary>
        /// A loudspeaker position located at the center of the top layer directly above the seating area.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        TopCenter,

        /// <summary>
        /// A loudspeaker position located at far left back of the top layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        TopBackLeft,

        /// <summary>
        /// A loudspeaker position located at far right back of the top layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        TopBackRight,

        /// <summary>
        /// A loudspeaker position located at left side of the top layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        TopSideLeft,

        /// <summary>
        /// A loudspeaker position located at right side of the top layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        TopSideRight,

        /// <summary>
        /// A loudspeaker position located at center back of the top layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        TopBackCenter,

        /// <summary>
        /// A loudspeaker position located at center front of the bottom layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        BottomFrontCenter,

        /// <summary>
        /// A loudspeaker position located at far left front of the bottom layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        BottomFrontLeft,

        /// <summary>
        /// A loudspeaker position located at far right front of the bottom layer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        BottomFrontRight,

        /// <summary>
        /// A loudspeaker position located between front left and side left.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        WideLeft,

        /// <summary>
        /// A loudspeaker position located between front right and side right.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        WideRight,

        /// <summary>
        /// A loudspeaker position located between back left and side left.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        SurroundLeft,

        /// <summary>
        /// A loudspeaker position located between back right and side right.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        SurroundRight
    }
}
