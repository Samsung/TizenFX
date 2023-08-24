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
    /// Represents a screen source.
    /// </summary>
    /// <remarks>
    /// MediaScreenSource is not allowed to be used by third-party applications due to the security reasons. (Since Tizen 7.0)
    /// </remarks>
    /// <seealso cref="WebRTC.AddSource"/>
    /// <seealso cref="WebRTC.AddSources"/>
    /// <since_tizen> 9 </since_tizen>
    public sealed class MediaScreenSource : MediaSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaScreenSource"/> class.
        /// </summary>
        /// <feature>http://tizen.org/feature/display</feature>
        /// <remark>
        /// If display feature is not supported, NotSupportedException will be thrown
        /// when MediaScreenSource is added by <see cref="WebRTC.AddSource"/> or <see cref="WebRTC.AddSources"/>.
        /// </remark>
        /// <since_tizen> 9 </since_tizen>
        public MediaScreenSource() : base(MediaType.Video) {}

        internal override void OnAttached(WebRTC webRtc)
        {
            Debug.Assert(webRtc != null);

            if (WebRtc != null)
            {
                throw new InvalidOperationException("The source is has already been assigned to another WebRTC.");
            }

            NativeWebRTC.AddMediaSource(webRtc.Handle, MediaSourceType.Screen, out uint sourceId).
                ThrowIfFailed("Failed to add MediaScreenSource.");

            WebRtc = webRtc;
            SourceId = sourceId;
        }

        internal override void OnDetached(WebRTC webRtc)
        {
            NativeWebRTC.RemoveMediaSource(webRtc.Handle, SourceId.Value).
                ThrowIfFailed("Failed to remove MediaScreenSource.");

            WebRtc = null;
        }

        internal override MediaSourceType MediaSourceType => MediaSourceType.Screen;
    }
}
