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
    /// Enumeration for audio codec.
    /// </summary>
    public enum AudioCodec
    {
        /// <summary>
        /// Screen mirroring is not negotiated yet
        /// </summary>
        None,
        /// <summary>
        /// AAC codec for audio
        /// </summary>
        Aac,
        /// <summary>
        /// AC3 codec for audio
        /// </summary>
        Ac3,
        /// <summary>
        /// LPCM codec for audio
        /// </summary>
        Lpcm
    }
    /// <summary>
    /// Enumeration for video codec.
    /// </summary>
    public enum VideoCodec
    {
        /// <summary>
        /// Screen mirroring is not negotiated yet
        /// </summary>
        None,
        /// <summary>
        /// H.264 codec for video
        /// </summary>
        H264
    }
    /// <summary>
    /// Enumeration for display surface type.
    /// </summary>
    public enum SurfaceType
    {
        /// <summary>
        /// Use overlay surface to display streaming multimedia data
        /// </summary>
        Overlay,
        /// <summary>
        /// Use Evas pixmap surface to display streaming multimedia data
        /// </summary>
        Evas
    }

    /// <summary>
    /// Enumeration for screen mirroring resolution.
    /// </summary>
    public enum ResolutionType
    {
        /// <summary>
        /// W-1920, H-1080, 30 fps
        /// </summary>
        R1920x1080P30 = (1 << 0),
        /// <summary>
        /// W-1280, H-720, 30 fps
        /// </summary>
        R1280x720P30 = (1 << 1),
        /// <summary>
        /// W-960, H-540, 30 fps
        /// </summary>
        R960x540P30 = (1 << 2),
        /// <summary>
        /// W-864, H-480, 30 fps
        /// </summary>
        R864x480P30 = (1 << 3),
        /// <summary>
        /// W-720, H-480, 60 fps
        /// </summary>
        R720x480P60 = (1 << 4),
        /// <summary>
        /// W-640, H-480, 60 fps
        /// </summary>
        R640x480P60 = (1 << 5),
        /// <summary>
        /// W-640, H-360, 30 fps
        /// </summary>
        R640x360P30 = (1 << 6)
    }

    /// <summary>
    /// Enumeration for screen mirroring sink state
    /// </summary>
    public enum SCMirroringSinkState
    {
        /// <summary>
        /// Screen mirroring is not created yet
        /// </summary>
        None,
        /// <summary>
        /// Screen mirroring is created, but not prepared yet
        /// </summary>
        Null,
        /// <summary>
        /// Screen mirroring is prepared to play media
        /// </summary>
        Prepared,
        /// <summary>
        /// Screen mirroring is connected
        /// </summary>
        Connected,
        /// <summary>
        /// Screen mirroring is now playing media
        /// </summary>
        Playing,
        /// <summary>
        /// Screen mirroring is paused while playing media
        /// </summary>
        Paused,
        /// <summary>
        /// Screen mirroring is disconnected
        /// </summary>
        Disconnected
    }

    /// <summary>
    /// Enumeration for screen mirroring error.
    /// </summary>
    public enum SCMirroringError
    {
        /// <summary>
        /// Successful
        /// </summary>
        None = SCMirroringErrorCode.None,
        /// <summary>
        /// Invalid parameter
        /// </summary>
        InvalidParameter = SCMirroringErrorCode.InvalidParameter,
        /// <summary>
        /// Invalid operation
        /// </summary>
        InvalidOperation = SCMirroringErrorCode.InvalidOperation
    }
}
