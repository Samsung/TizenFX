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

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Specifies the audio codecs for <see cref="ScreenMirroring"/>.
    /// </summary>
    /// <seealso cref="ScreenMirroringAudioInfo"/>
    /// <since_tizen> 4 </since_tizen>
    public enum ScreenMirroringAudioCodec
    {
        /// <summary>
        /// The screen mirroring is not negotiated yet.
        /// </summary>
        None,
        /// <summary>
        /// AAC codec.
        /// </summary>
        Aac,
        /// <summary>
        /// AC3 codec.
        /// </summary>
        Ac3,
        /// <summary>
        /// LPCM codec.
        /// </summary>
        Lpcm
    }

    /// <summary>
    /// Specifies the video codecs for <see cref="ScreenMirroring"/>.
    /// </summary>
    /// <seealso cref="ScreenMirroringVideoInfo"/>
    /// <since_tizen> 4 </since_tizen>
    public enum ScreenMirroringVideoCodec
    {
        /// <summary>
        /// The screen mirroring is not negotiated yet.
        /// </summary>
        None,
        /// <summary>
        /// H.264 codec.
        /// </summary>
        H264
    }

    /// <summary>
    /// Specifies the available combinations of resolutions and fps for <see cref="ScreenMirroring"/>.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Flags]
    public enum ScreenMirroringResolutions
    {
        /// <summary>
        /// W-1920, H-1080, 30 fps.
        /// </summary>
        R1920x1080P30 = (1 << 0),
        /// <summary>
        /// W-1280, H-720, 30 fps.
        /// </summary>
        R1280x720P30 = (1 << 1),
        /// <summary>
        /// W-960, H-540, 30 fps.
        /// </summary>
        R960x540P30 = (1 << 2),
        /// <summary>
        /// W-864, H-480, 30 fps.
        /// </summary>
        R864x480P30 = (1 << 3),
        /// <summary>
        /// W-720, H-480, 60 fps.
        /// </summary>
        R720x480P60 = (1 << 4),
        /// <summary>
        /// W-640, H-480, 60 fps.
        /// </summary>
        R640x480P60 = (1 << 5),
        /// <summary>
        /// W-640, H-360, 30 fps.
        /// </summary>
        R640x360P30 = (1 << 6)
    }

    /// <summary>
    /// Specifies the states of <see cref="ScreenMirroring"/>.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ScreenMirroringState
    {
        /// <summary>
        /// Idle.
        /// </summary>
        Idle = 1,

        /// <summary>
        /// Prepared.
        /// </summary>
        /// <seealso cref="ScreenMirroring.Prepare(Display, ScreenMirroringResolutions)"/>
        Prepared,

        /// <summary>
        /// Connected to a source.
        /// </summary>
        /// <seealso cref="ScreenMirroring.ConnectAsync(string)"/>
        Connected,

        /// <summary>
        /// Playing.
        /// </summary>
        /// <seealso cref="ScreenMirroring.StartAsync"/>
        Playing,

        /// <summary>
        /// Paused while playing media.
        /// </summary>
        /// <seealso cref="ScreenMirroring.PauseAsync"/>
        Paused,

        /// <summary>
        /// Disconnected from source.
        /// </summary>
        /// <seealso cref="ScreenMirroring.Disconnect"/>
        Disconnected
    }

    /// <summary>
    /// Specifies the errors for <see cref="ScreenMirroring"/>.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ScreenMirroringError
    {
        /// <summary>
        /// Invalid operation.
        /// </summary>
        InvalidOperation = ScreenMirroringErrorCode.InvalidOperation
    }

    /// <summary>
    /// Specifies the display mode for <see cref="ScreenMirroring"/>.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public enum ScreenMirroringDisplayMode
    {
        /// <summary>
        /// Letter box.
        /// </summary>
        LetterBox,

        /// <summary>
        /// Original size.
        /// </summary>
        OriginSize,

        /// <summary>
        /// Full screen.
        /// </summary>
        Full,

        /// <summary>
        /// Cropped full screen.
        /// </summary>
        CroppedFull,

        /// <summary>
        /// Original size or letter box.
        /// </summary>
        OriginOrLetterBox,

        /// <summary>
        /// Custom ROI.
        /// </summary>
        CustomRoi
    }

    /// <summary>
    /// Specifies the device type for <see cref="ScreenMirroring"/>.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public enum ScreenMirroringDeviceType
    {
        /// <summary>
        /// All other devices except TV and Mobile.
        /// </summary>
        Generic,

        /// <summary>
        /// TV device.
        /// </summary>
        Tv,

        /// <summary>
        /// Mobile device.
        /// </summary>
        Mobile
    }
}
