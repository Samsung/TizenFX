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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Represents a media packet source.
    /// </summary>
    /// <seealso cref="WebRTC.AddSource"/>
    /// <seealso cref="WebRTC.AddSources"/>
    /// <since_tizen> 9 </since_tizen>
    public sealed class MediaPacketSource : MediaSource
    {
        private readonly MediaFormat _audioMediaFormat;
        private readonly MediaFormat _videoMediaFormat;
        private static List<MediaFormatAudioMimeType> _supportedAudioFormats;
        private static List<MediaFormatVideoMimeType> _supportedVideoFormats;

        /// <summary>
        /// Gets all supported audio types.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static IEnumerable<MediaFormatAudioMimeType> SupportedAudioTypes
        {
            get
            {
                GetSupportedTypes();
                return _supportedAudioFormats.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets all supported video types.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static IEnumerable<MediaFormatVideoMimeType> SupportedVideoTypes
        {
            get
            {
                GetSupportedTypes();
                return _supportedVideoFormats.AsReadOnly();
            }
        }

        private static void GetSupportedTypes()
        {
            if (_supportedAudioFormats != null || _supportedVideoFormats != null)
            {
                return;
            }

            NativeWebRTC.Create(out WebRTCHandle webRtcHandle).ThrowIfFailed("Failed to create WebRTC");
            IntPtr handle = webRtcHandle.DangerousGetHandle();
            Debug.Assert(handle != IntPtr.Zero);

            try
            {
                _supportedAudioFormats = new List<MediaFormatAudioMimeType>();
                _supportedVideoFormats = new List<MediaFormatVideoMimeType>();
                NativeWebRTC.SupportedMediaFormatCallback callback = (format, _) =>
                {
                    if (Enum.IsDefined(typeof(MediaFormatAudioMimeType), (object)format))
                    {
                        Log.Debug(WebRTCLog.Tag, "supported audio : " + ((MediaFormatAudioMimeType)format).ToString());
                        _supportedAudioFormats.Add((MediaFormatAudioMimeType)format);
                    }
                    else if (Enum.IsDefined(typeof(MediaFormatVideoMimeType), (object)format))
                    {
                        Log.Debug(WebRTCLog.Tag, "supported video : " + ((MediaFormatVideoMimeType)format).ToString());
                        _supportedVideoFormats.Add((MediaFormatVideoMimeType)format);
                    }
                    else
                        Log.Debug(WebRTCLog.Tag, "skipped : " + format.ToString());
                    return true;
                };

                NativeWebRTC.SupportedMediaSourceFormat(handle, callback, IntPtr.Zero).ThrowIfFailed("Failed to get the list");
            }
            finally
            {
                webRtcHandle.Dispose();
            }
        }

        private MediaPacketSourceConfiguration CreateAudioConfiguration(AudioMediaFormat format)
        {
            if (format == null)
            {
                return null;
            }

            // FIXME: Will be enabled, if native implementation supports this functionality.
            // if (!SupportedAudioTypes.Contains<MediaFormatAudioMimeType>(format.MimeType))
            // {
            //     throw new ArgumentException($"The audio format is not supported, Type : {format.MimeType}.");
            // }

            return new MediaPacketSourceConfiguration(this);
        }

        private MediaPacketSourceConfiguration CreateVideoConfiguration(VideoMediaFormat format)
        {
            if (format == null)
            {
                return null;
            }

            // FIXME: Will be enabled, if native implementation supports this functionality.
            // if (!SupportedVideoTypes.Contains(format.MimeType))
            // {
            //     throw new ArgumentException($"The video format is not supported, Type : {format.MimeType}.");
            // }
            return new MediaPacketSourceConfiguration(this);
        }

        /// <summary>
        /// Initializes a new instance of the MediaPacketSource class with the specified <see cref="AudioMediaFormat"/>.
        /// </summary>
        /// <param name="audioMediaFormat">The <see cref="AudioMediaFormat"/> for this source.</param>
        /// <exception cref="ArgumentNullException"><paramref name="audioMediaFormat"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="audioMediaFormat"/> is not supported.</exception>
        /// <seealso cref="SupportedAudioTypes"/>
        /// <since_tizen> 9 </since_tizen>
        public MediaPacketSource(AudioMediaFormat audioMediaFormat) : base(MediaType.Audio)
        {
            _audioMediaFormat = audioMediaFormat ?? throw new ArgumentNullException(nameof(audioMediaFormat));
            AudioConfiguration = CreateAudioConfiguration(audioMediaFormat);
        }

        /// <summary>
        /// Initializes a new instance of the MediaPacketSource class with the specified <see cref="VideoMediaFormat"/>.
        /// </summary>
        /// <param name="videoMediaFormat">The <see cref="VideoMediaFormat"/> for this source.</param>
        /// <exception cref="ArgumentNullException"><paramref name="videoMediaFormat"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="videoMediaFormat"/> is not supported.</exception>
        /// <seealso cref="SupportedVideoTypes"/>
        /// <since_tizen> 9 </since_tizen>
        public MediaPacketSource(VideoMediaFormat videoMediaFormat) : base(MediaType.Video)
        {
            _videoMediaFormat = videoMediaFormat ?? throw new ArgumentNullException(nameof(videoMediaFormat));
            VideoConfiguration = CreateVideoConfiguration(videoMediaFormat);
        }

        /// <summary>
        /// Gets the audio configuration, or null if no AudioMediaFormat is specified in the constructor.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public MediaPacketSourceConfiguration AudioConfiguration { get; }

        /// <summary>
        /// Gets the video configuration, or null if no VideoMediaFormat is specified in the constructor.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public MediaPacketSourceConfiguration VideoConfiguration { get; }

        /// <summary>
        /// Pushes elementary stream to decode audio or video.
        /// </summary>
        /// <remarks>
        /// This source must be set as a source to a WebRTC and the WebRTC must be in the
        /// <see cref="WebRTCState.Negotiating"/> or <see cref="WebRTCState.Playing"/> state
        /// </remarks>
        /// <param name="packet">The <see cref="MediaPacket"/> to decode.</param>
        /// <exception cref="InvalidOperationException">
        ///     This source is not set as a source to a WebRTC.<br/>
        ///     -or-<br/>
        ///     The WebRTC is not in the valid state.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="packet"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="packet"/> has been disposed.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="packet"/> is neither video nor audio type.<br/>
        ///     -or-<br/>
        ///     The format of packet is not matched with the specified format in the constructor.
        /// </exception>
        /// <seealso cref="WebRTC.AddSource"/>
        /// <seealso cref="WebRTC.AddSources"/>
        /// <seealso cref="MediaPacket"/>
        /// <since_tizen> 9 </since_tizen>
        public void Push(MediaPacket packet)
        {
            if (WebRtc == null)
            {
                Log.Error(WebRTCLog.Tag, "The source is not set as a source to a WebRTC yet.");
                throw new InvalidOperationException("The source is not set as a source to a WebRTC yet.");
            }

            if (packet == null)
            {
                Log.Error(WebRTCLog.Tag, "packet is null");
                throw new ArgumentNullException(nameof(packet));
            }

            if (packet.IsDisposed)
            {
                Log.Error(WebRTCLog.Tag, "packet is disposed");
                throw new ObjectDisposedException(nameof(packet));
            }

            if (packet.Format.Type == MediaFormatType.Text || packet.Format.Type == MediaFormatType.Container)
            {
                Log.Error(WebRTCLog.Tag, "The format of the packet is invalid : " + packet.Format.Type);
                throw new ArgumentException($"The format of the packet is invalid : {packet.Format.Type}.");
            }

            if (!packet.Format.Equals(_audioMediaFormat) && !packet.Format.Equals(_videoMediaFormat))
            {
                Log.Error(WebRTCLog.Tag, "The format of the packet is invalid : Unmatched format.");
                throw new ArgumentException("The format of the packet is invalid : Unmatched format.");
            }

            if (packet.Format.Type == MediaFormatType.Video && _videoMediaFormat == null)
            {
                Log.Error(WebRTCLog.Tag, "Video is not configured with the current source.");
                throw new ArgumentException("Video is not configured with the current source.");
            }

            if (packet.Format.Type == MediaFormatType.Audio && _audioMediaFormat == null)
            {
                Log.Error(WebRTCLog.Tag, "Audio is not configured with the current source.");
                throw new ArgumentException("Audio is not configured with the current source.");
            }

            WebRtc.ValidateWebRTCState(WebRTCState.Negotiating, WebRTCState.Playing);

            NativeWebRTC.PushMediaPacket(WebRtc.Handle, SourceId.Value, packet.GetHandle()).
                ThrowIfFailed("Failed to push the packet to the WebRTC");
        }

        private void SetMediaStreamInfo(MediaFormat mediaFormat)
        {
            if (mediaFormat == null)
            {
                Log.Warn(WebRTCLog.Tag, "invalid media format");
            }
            else
            {
                IntPtr ptr = IntPtr.Zero;

                try
                {
                    ptr = mediaFormat.AsNativeHandle();
                    NativeWebRTC.SetMediaPacketSourceInfo(WebRtc.Handle, SourceId.Value, ptr).
                        ThrowIfFailed("Failed to set the media stream info");
                }
                finally
                {
                    MediaFormat.ReleaseNativeHandle(ptr);
                }
            }
        }

        internal override void OnAttached(WebRTC webRtc)
        {
            Debug.Assert(webRtc != null);

            if (WebRtc != null)
            {
                Log.Error(WebRTCLog.Tag, "The source is has already been assigned to another WebRTC.");
                throw new InvalidOperationException("The source is has already been assigned to another WebRTC.");
            }

            NativeWebRTC.AddMediaSource(webRtc.Handle, MediaSourceType.MediaPacket, out uint sourceId).
                ThrowIfFailed("Failed to add media source for media packet.");

            WebRtc = webRtc;
            SourceId = sourceId;

            AudioConfiguration?.OnWebRTCSet();
            VideoConfiguration?.OnWebRTCSet();

            SetMediaStreamInfo(_audioMediaFormat);
            SetMediaStreamInfo(_videoMediaFormat);
        }

        internal override void OnDetached(WebRTC webRtc)
        {
            NativeWebRTC.RemoveMediaSource(webRtc.Handle, SourceId.Value).
                ThrowIfFailed("Failed to remove media source for media packet.");

            AudioConfiguration?.OnWebRTCUnset();
            VideoConfiguration?.OnWebRTCUnset();

            WebRtc = null;
        }
    }
}
