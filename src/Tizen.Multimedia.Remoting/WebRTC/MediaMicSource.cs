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
    /// Represents a microphone source.
    /// </summary>
    /// <remarks>The recorder privilege(http://tizen.org/privilege/recorder) is required.</remarks>
    /// <seealso cref="WebRTC.AddSource"/>
    /// <seealso cref="WebRTC.AddSources"/>
    /// <since_tizen> 9 </since_tizen>
    public sealed class MediaMicSource : MediaSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaMicSource"/> class.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public MediaMicSource() : base(MediaType.Audio) {}

        internal override void OnAttached(WebRTC webRtc)
        {
            Debug.Assert(webRtc != null);
            if (WebRtc != null)
            {
                Log.Error(WebRTCLog.Tag, "The source is has already been assigned to another WebRTC.");
                throw new InvalidOperationException("The source is has already been assigned to another WebRTC.");
            }

            NativeWebRTC.AddMediaSource(webRtc.Handle, MediaSourceType.Microphone, out uint sourceId).
                ThrowIfFailed("Failed to add MediaMicSource.");

            WebRtc = webRtc;
            SourceId = sourceId;
        }

        internal override void OnDetached(WebRTC webRtc)
        {
            NativeWebRTC.RemoveMediaSource(webRtc.Handle, SourceId.Value).
                ThrowIfFailed("Failed to remove MediaMicSource.");

            WebRtc = (WebRTC)null;
        }

        /// <summary>
        /// Applies the audio stream policy to <see cref="MediaMicSource"/>.
        /// </summary>
        /// <param name="policy">The <see cref="AudioStreamPolicy"/> to apply.</param>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Idle"/> state.<br/>
        /// <br/>
        /// <see cref="WebRTC"/> does not support all <see cref="AudioStreamType"/>.<br/>
        /// Supported types are <see cref="AudioStreamType.Media"/>, <see cref="AudioStreamType.VoiceRecognition"/>,
        /// <see cref="AudioStreamType.Voip"/>, <see cref="AudioStreamType.MediaExternalOnly"/>.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">
        ///     The WebRTC has already been disposed.<br/>
        ///     -or-<br/>
        ///     <paramref name="policy"/> has already been disposed.
        /// </exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="policy"/> is null.</exception>
        /// <exception cref="NotSupportedException">
        ///     <see cref="AudioStreamType"/> of <paramref name="policy"/> is not supported on the current platform.
        /// </exception>
        /// <seealso cref="AudioStreamPolicy"/>
        /// <since_tizen> 9 </since_tizen>
        public void ApplyAudioStreamPolicy(AudioStreamPolicy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy), "policy is null");
            }

            WebRtc.ValidateWebRTCState(WebRTCState.Idle);

            var ret = NativeWebRTC.SetAudioStreamPolicyToMicSource(WebRtc.Handle, SourceId.Value, policy.Handle);

            if (ret == WebRTCErrorCode.InvalidArgument)
            {
                throw new NotSupportedException("The specified policy is not supported on the current system.");
            }

            ret.ThrowIfFailed("Failed to set the audio stream policy to the WebRTC");
        }
    }
}
