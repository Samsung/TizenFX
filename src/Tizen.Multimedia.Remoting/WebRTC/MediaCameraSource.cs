/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Diagnostics;
using NativeWebRTC = Interop.NativeWebRTC;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Represents a camera source.
    /// </summary>
    /// <remarks>The camera privilege(http://tizen.org/privilege/camera) is required.</remarks>
    /// <seealso cref="WebRTC.SetSource(MediaSource)"/>
    /// <since_tizen> 9 </since_tizen>
    public sealed class MediaCameraSource : MediaSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaCameraSource"/> class.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public MediaCameraSource() : base(MediaType.Video) {}

        internal override void OnAttached(WebRTC webRtc)
        {
            Debug.Assert(webRtc != null);

            if (WebRtc != null)
            {
                throw new InvalidOperationException("The source is has already been assigned to another WebRTC.");
            }

            NativeWebRTC.AddMediaSource(webRtc.Handle, MediaSourceType.Camera, out uint sourceId).
                ThrowIfFailed("Failed to add media source for camera.");

            WebRtc = webRtc;
            SourceId = sourceId;
        }

        internal override void OnDetached(WebRTC webRtc)
        {
            NativeWebRTC.RemoveMediaSource(webRtc.Handle, SourceId.Value).
                ThrowIfFailed("Failed to add media source for camera.");

            WebRtc = null;
        }
    }
}
