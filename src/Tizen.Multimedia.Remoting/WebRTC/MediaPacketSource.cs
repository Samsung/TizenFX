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
    public sealed class MediaPacketSource : MediaSource
    {
        private readonly MediaFormat _audioMediaFormat;
        private readonly MediaFormat _videoMediaFormat;
        private static List<MediaFormatAudioMimeType> _supportedAudioFormats;
        private static List<MediaFormatVideoMimeType> _supportedVideoFormats;

        public static IEnumerable<MediaFormatAudioMimeType> SupportedAudioTypes
        {
            get
            {
                GetSupportedTypes();
                return _supportedAudioFormats.AsReadOnly();
            }
        }

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

            if (!SupportedAudioTypes.Contains<MediaFormatAudioMimeType>(format.MimeType))
            {
                throw new ArgumentException($"The audio format is not supported, Type : {format.MimeType}.");
            }

            return new MediaPacketSourceConfiguration(this);
        }

        private MediaPacketSourceConfiguration CreateVideoConfiguration(VideoMediaFormat format)
        {
            if (format == null)
            {
                return null;
            }

            if (!SupportedVideoTypes.Contains(format.MimeType))
            {
                throw new ArgumentException($"The video format is not supported, Type : {format.MimeType}.");
            }
            return new MediaPacketSourceConfiguration(this);
        }

        public MediaPacketSource(AudioMediaFormat audioMediaFormat)
        {
            _audioMediaFormat = audioMediaFormat ?? throw new ArgumentNullException(nameof(audioMediaFormat));
            AudioConfiguration = CreateAudioConfiguration(audioMediaFormat);
        }

        public MediaPacketSource(VideoMediaFormat videoMediaFormat)
        {
            _videoMediaFormat = videoMediaFormat ?? throw new ArgumentNullException(nameof(videoMediaFormat));
            VideoConfiguration = CreateVideoConfiguration(videoMediaFormat);
        }

        public MediaPacketSourceConfiguration AudioConfiguration { get; }

        public MediaPacketSourceConfiguration VideoConfiguration { get; }

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

            NativeWebRTC.PushMediaPacket(WebRtc.Handle, packet.GetHandle()).
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
                ThrowIfFailed("Failed to add media source for media packet.");

            AudioConfiguration?.OnWebRTCUnset();
            VideoConfiguration?.OnWebRTCUnset();

            WebRtc = null;
        }
    }
}
