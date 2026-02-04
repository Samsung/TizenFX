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
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// MediaSource is a base class for <see cref="WebRTC"/> sources.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class MediaSource : IDisplayable<uint>
    {
        internal WebRTC WebRtc { get; set; }
        internal uint? SourceId { get; set; }
        private Display _display;

        /// <summary>
        /// Gets the type of MediaSource.
        /// </summary>
        /// <value><see cref="MediaType"/></value>
        /// <since_tizen> 9 </since_tizen>
        protected MediaType MediaType { get; }

        private bool IsDetached {get; set;} = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaSource"/> class.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        protected MediaSource(MediaType mediaType)
        {
            MediaType = mediaType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaSource"/> class.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        protected MediaSource() { }

        internal void AttachTo(WebRTC webRtc)
        {
            if (IsDetached)
            {
                throw new InvalidOperationException("MediaSource was already detached.");
            }

            OnAttached(webRtc);
        }

        internal void DetachFrom(WebRTC webRtc)
        {
            OnDetached(webRtc);
            IsDetached = true;
        }

        internal abstract void OnAttached(WebRTC webRtc);

        internal abstract void OnDetached(WebRTC webRtc);

        internal virtual MediaSourceType MediaSourceType => MediaSourceType.Null;

        /// <summary>
        /// Gets or sets the transceiver direction of current media source.
        /// </summary>
        /// <remarks>
        /// The default value is <see cref="TransceiverDirection.SendRecv"/> except <see cref="MediaNullSource"/>.<br/>
        /// If user want to set each audio, video direction in <see cref="MediaFileSource"/>,
        /// please use <see cref="MediaFileSource.SetTransceiverDirection"/>. (Since API level 10)<br/>
        /// In <see cref="MediaNullSource"/>, only <see cref="TransceiverDirection.RecvOnly"/> can be set.(Since API level 10)
        /// </remarks>
        /// <value>A <see cref="TransceiverDirection"/> that specifies the transceiver direction.</value>
        /// <exception cref="InvalidOperationException">
        ///     MediaSource is not attached yet.<br/>
        /// -or-<br/>
        ///     <see cref="TransceiverDirection.SendOnly"/> or <see cref="TransceiverDirection.SendRecv"/> is set for MediaNullSource. (Since API level 10)
        /// </exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="MediaFileSource.GetTransceiverDirection"/>
        /// <seealso cref="MediaFileSource.SetTransceiverDirection"/>
        /// <since_tizen> 9 </since_tizen>
        public TransceiverDirection TransceiverDirection
        {
            get
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (this is MediaNullSource)
                {
                    return TransceiverDirection.RecvOnly;
                }

                NativeWebRTC.GetTransceiverDirection(WebRtc.Handle, SourceId.Value, MediaType, out TransceiverDirection mode).
                    ThrowIfFailed("Failed to get transceiver direction.");

                return mode;
            }
            set
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (this is MediaNullSource)
                {
                    if (value != TransceiverDirection.RecvOnly)
                    {
                        throw new InvalidOperationException("Only RecvOnly is allowed for MediaNullSource.");
                    }

                    return;
                }

                if (this is MediaNullSource || this is MediaFileSource)
                {
                    NativeWebRTC.SetTransceiverDirection(WebRtc.Handle, SourceId.Value, MediaType.Audio, value).
                        ThrowIfFailed("Failed to set audio transceiver direction.");
                    NativeWebRTC.SetTransceiverDirection(WebRtc.Handle, SourceId.Value, MediaType.Video, value).
                        ThrowIfFailed("Failed to set video transceiver direction.");
                }
                else
                {
                    NativeWebRTC.SetTransceiverDirection(WebRtc.Handle, SourceId.Value, MediaType, value).
                        ThrowIfFailed("Failed to set transceiver direction.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the transceiver codec of current media source.
        /// </summary>
        /// <remarks>
        /// This API is not supported in <see cref="MediaFileSource"/>, <see cref="MediaPacketSource"/>.<br/>
        /// If <see cref="MediaNullSource"/>, please use <see cref="MediaNullSource.GetTransceiverCodec"/>
        /// or <see cref="MediaNullSource.SetTransceiverCodec"/> instead.<br/>
        /// The WebRTC must be in the <see cref="WebRTCState.Idle"/> state when transceiver codec is set.
        /// </remarks>
        /// <value>The transceiver codec.</value>
        /// <exception cref="InvalidOperationException">
        ///     MediaSource is not attached yet.<br/>
        /// -or-<br/>
        ///     This MediaSource is not supported type of MediaSource.<br/>
        /// -or-<br/>
        /// The WebRTC is not in the valid state.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="MediaNullSource.GetTransceiverCodec"/>
        /// <seealso cref="MediaNullSource.SetTransceiverCodec"/>
        /// <since_tizen> 10 </since_tizen>
        public TransceiverCodec TransceiverCodec
        {
            get
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (this is MediaFileSource || this is MediaPacketSource || this is MediaNullSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.GetTransceiverCodec(WebRtc.Handle, SourceId.Value, MediaType, out TransceiverCodec codec).
                    ThrowIfFailed("Failed to get transceiver codec");

                return codec;
            }
            set
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (this is MediaFileSource || this is MediaPacketSource || this is MediaNullSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                WebRtc.ValidateWebRTCState(WebRTCState.Idle);

                NativeWebRTC.SetTransceiverCodec(WebRtc.Handle, SourceId.Value, MediaType, value).
                    ThrowIfFailed("Failed to set transceiver codec");
            }
        }

        /// <summary>
        /// Retrieves the supported transceiver codecs.
        /// </summary>
        /// <remarks>
        /// This API is not supported in <see cref="MediaFileSource"/>, <see cref="MediaPacketSource"/>.<br/>
        /// If user want to get supported codecs for each audio or video in <see cref="MediaNullSource"/>,
        /// please use <see cref="MediaNullSource.GetSupportedTransceiverCodecs"/> instead.
        /// </remarks>
        /// <returns>The transceiver codecs.</returns>
        /// <exception cref="InvalidOperationException">This MediaSource is not supported type of MediaSource.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="MediaNullSource.GetSupportedTransceiverCodecs"/>
        /// <since_tizen> 10 </since_tizen>
        public ReadOnlyCollection<TransceiverCodec> SupportedTransceiverCodecs
        {
            get
            {
                if (this is MediaFileSource || this is MediaPacketSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }
                if (this is MediaNullSource)
                {
                    var codecs = ForeachSupportedTransceiverCodecs(MediaType.Audio);
                    codecs.AddRange(ForeachSupportedTransceiverCodecs(MediaType.Video));

                    return new ReadOnlyCollection<TransceiverCodec>(codecs);
                }

                return new ReadOnlyCollection<TransceiverCodec>(ForeachSupportedTransceiverCodecs(MediaType));
            }
        }

        internal List<TransceiverCodec> ForeachSupportedTransceiverCodecs(MediaType type)
        {
            var codecs = new List<TransceiverCodec>();
            Exception caught = null;

            NativeWebRTC.RetrieveTransceiverCodecCallback cb = (codec, _) =>
            {
                try
                {
                    codecs.Add(codec);
                }
                catch (Exception e)
                {
                    caught = e;
                    return false;
                }

                return true;
            };

            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                try
                {
                    NativeWebRTC.ForeachSupportedTransceiverCodec(WebRtc.Handle, MediaSourceType, type, cb).
                        ThrowIfFailed("failed to retrieve stats");
                }
                catch (ObjectDisposedException)
                {
                    throw;
                }
                catch
                {
                    Log.Info(WebRTCLog.Tag, "This is not error in csharp.");
                }

                if (caught != null)
                {
                    throw caught;
                }
            }

            return codecs;
        }

        /// <summary>
        /// Gets or sets the pause status of current media source.
        /// </summary>
        /// If <see cref="MediaFileSource"/>, please use <see cref="MediaFileSource.GetPause"/>
        /// or <see cref="MediaFileSource.SetPause"/> instead.<br/> (Since API level 10)
        /// <value>A value that specifies the pause status.</value>
        /// <exception cref="InvalidOperationException">
        ///     MediaSource is not attached yet.<br/>
        /// -or-<br/>
        ///     This MediaSource is not supported type of MediaSource. (Since API level 10)
        /// </exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="MediaFileSource.GetPause"/>
        /// <seealso cref="MediaFileSource.SetPause"/>
        /// <since_tizen> 9 </since_tizen>
        public bool Pause
        {
            get
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (this is MediaFileSource || this is MediaNullSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.GetPause(WebRtc.Handle, SourceId.Value, MediaType, out bool isPaused).
                    ThrowIfFailed("Failed to get pause");

                return isPaused;
            }
            set
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (this is MediaFileSource || this is MediaNullSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.SetPause(WebRtc.Handle, SourceId.Value, MediaType, value).
                    ThrowIfFailed("Failed to set pause");
            }
        }

        /// <summary>
        /// Gets or sets the mute status of the current media source.
        /// </summary>
        /// <remarks>
        /// This API is not supported in <see cref="MediaFileSource"/>, <see cref="MediaPacketSource"/>, <see cref="MediaNullSource"/>. (Since API level 10)
        /// </remarks>
        /// <value>A value that specifies the mute status.</value>
        /// <exception cref="InvalidOperationException">
        ///     MediaSource is not attached yet.<br/>
        /// -or-<br/>
        ///     This MediaSource is not supported type of MediaSource. (Since API level 10)
        /// </exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public bool Mute
        {
            get
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (this is MediaFileSource || this is MediaPacketSource || this is MediaNullSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.GetMute(WebRtc.Handle, SourceId.Value, MediaType, out bool isMuted).
                    ThrowIfFailed("Failed to get mute");

                return isMuted;
            }
            set
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (this is MediaFileSource || this is MediaPacketSource || this is MediaNullSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.SetMute(WebRtc.Handle, SourceId.Value, MediaType, value).
                    ThrowIfFailed("Failed to set mute");
            }
        }

        /// <summary>
        /// Gets or sets the video resolution of the current media source.
        /// </summary>
        /// <value>A value that specifies the video resolution.</value>
        /// <exception cref="InvalidOperationException">
        ///     MediaSource is not attached yet.<br/>
        /// -or-<br/>
        ///     This MediaSource is not Video.
        /// -or-<br/>
        ///     This MediaSource is not supported type of MediaSource.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Size VideoResolution
        {
            get
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (MediaType != MediaType.Video)
                {
                    throw new InvalidOperationException("This property is only for video.");
                }
                if (this is MediaFileSource || this is MediaPacketSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.GetVideoResolution(WebRtc.Handle, SourceId.Value, out int width, out int height).
                    ThrowIfFailed("Failed to get video resolution");

                return new Size(width, height);
            }
            set
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (MediaType != MediaType.Video)
                {
                    throw new InvalidOperationException("This property is only for video.");
                }
                if (this is MediaFileSource || this is MediaPacketSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.SetVideoResolution(WebRtc.Handle, SourceId.Value, value.Width, value.Height).
                    ThrowIfFailed("Failed to set video resolution");
            }
        }

        /// <summary>
        /// Gets or sets the video frame rate of the current media source.
        /// </summary>
        /// <remarks>
        /// This API is only supported in video media source, especially <see cref="MediaCameraSource"/>,
        /// <see cref="MediaScreenSource"/>, <see cref="MediaTestSource"/>.<br/>
        /// </remarks>
        /// <value>A value that specifies the video frame rate.</value>
        /// <exception cref="ArgumentException">VideoFrameRate is less than or equal to zero.</exception>
        /// <exception cref="InvalidOperationException">
        ///     MediaSource is not attached yet.<br/>
        /// -or-<br/>
        ///     This MediaSource is not Video.
        /// -or-<br/>
        ///     This MediaSource is not supported type of MediaSource.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
        public int VideoFrameRate
        {
            get
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (MediaType != MediaType.Video)
                {
                    throw new InvalidOperationException("This property is only for video.");
                }
                if (this is MediaFileSource || this is MediaPacketSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.GetVideoFrameRate(WebRtc.Handle, SourceId.Value, out int frameRate).
                    ThrowIfFailed("Failed to get video frame rate");

                return frameRate;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"VideoFrameRate should be greater than zero.");
                }
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (MediaType != MediaType.Video)
                {
                    throw new InvalidOperationException("This property is only for video.");
                }
                if (this is MediaFileSource || this is MediaPacketSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.SetVideoFrameRate(WebRtc.Handle, SourceId.Value, value).
                    ThrowIfFailed("Failed to set video frame rate");
            }
        }

        /// <summary>
        /// Gets or sets the encoder bitrate of the current media source.
        /// </summary>
        /// <remarks>
        /// This API is not supported in <see cref="MediaFileSource"/>, <see cref="MediaPacketSource"/>.
        /// </remarks>
        /// <value>A value that specifies the encoder bitrate.</value>
        /// <exception cref="ArgumentException">EncoderBitrate is less than or equal to zero.</exception>
        /// <exception cref="InvalidOperationException">
        ///     MediaSource is not attached yet.<br/>
        /// -or-<br/>
        ///     This MediaSource is not Video.
        /// -or-<br/>
        ///     This MediaSource is not supported type of MediaSource.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
        public int EncoderBitrate
        {
            get
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (this is MediaFileSource || this is MediaPacketSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.GetEncoderBitrate(WebRtc.Handle, SourceId.Value, MediaType, out int bitrate).
                    ThrowIfFailed("Failed to get encoder bitrate");

                return bitrate;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"EncoderBitrate should be greater than zero.");
                }
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }
                if (this is MediaFileSource || this is MediaPacketSource)
                {
                    throw new InvalidOperationException($"This property is not supported in {this.GetType()}.");
                }

                NativeWebRTC.SetEncoderBitrate(WebRtc.Handle, SourceId.Value, MediaType, value).
                    ThrowIfFailed("Failed to set encoder bitrate");
            }
        }

        /// <summary>
        /// Sets the RTP payload type of given <paramref name="codec"/>.
        /// </summary>
        /// <remarks>
        /// <paramref name="payloadType"/> should be greater than or equal to 96 and less than or equal to 127.
        /// </remarks>
        /// <param name="codec">The transceiver codec.</param>
        /// <param name="payloadType">The RTP payload type.</param>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="payloadType"/> is less than 96 or greater than 127.
        /// </exception>
        /// <seealso cref="SupportedTransceiverCodecs"/>
        /// <since_tizen> 12 </since_tizen>
        public void SetPayloadType(TransceiverCodec codec, uint payloadType)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
            }
            if (payloadType < 96 || payloadType > 127)
            {
                throw new ArgumentOutOfRangeException(nameof(payloadType), payloadType, "Valid range : 96 <= payloadType <= 127");
            }

            NativeWebRTC.SetPaylodType(WebRtc.Handle, SourceId.Value, codec, payloadType).
                ThrowIfFailed("Failed to set payload type");
        }

        /// <summary>
        /// Gets the RTP payload type of given <paramref name="codec"/>.
        /// </summary>
        /// <param name="codec">The transceiver codec.</param>
        /// <returns>The RTP payload type.</returns>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="SupportedTransceiverCodecs"/>
        /// <since_tizen> 12 </since_tizen>
        public uint GetPayloadType(TransceiverCodec codec)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
            }

            NativeWebRTC.GetPaylodType(WebRtc.Handle, SourceId.Value, codec, out uint payloadType).
                ThrowIfFailed("Failed to get payload type");

            return payloadType;
        }

        /// <summary>
        /// Enables the audio loopback. The local audio will be played with <paramref name="policy"/>.
        /// </summary>
        /// <param name="policy">The <see cref="AudioStreamPolicy"/> to apply.</param>
        /// <remarks>
        /// <see cref="MediaSource"/> does not support all <see cref="AudioStreamType"/>.<br/>
        /// Supported types are <see cref="AudioStreamType.Media"/>, <see cref="AudioStreamType.Voip"/>,
        /// <see cref="AudioStreamType.MediaExternalOnly"/>.<br/>
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="policy"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     MediaSource is not attached yet.<br/>
        /// -or-<br/>
        ///     This MediaSource is not Audio
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     <see cref="AudioStreamType"/> of <paramref name="policy"/> is not supported on the current platform.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="policy"/> or WebRTC has already been disposed.
        /// </exception>
        /// <returns><see cref="MediaStreamTrack"/></returns>
        public MediaStreamTrack EnableAudioLoopback(AudioStreamPolicy policy)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
            }
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }
            if (MediaType != MediaType.Audio)
            {
                throw new InvalidOperationException("AudioLoopback is only for Audio MediaSource");
            }

            var ret = NativeWebRTC.SetAudioLoopback(WebRtc.Handle, SourceId.Value, policy.Handle, out uint trackId);

            if (ret == WebRTCErrorCode.InvalidArgument)
            {
                throw new NotSupportedException("The specified policy is not supported on the current system.");
            }

            ret.ThrowIfFailed("Failed to set the audio stream policy to the WebRTC");

            return new MediaStreamTrack(WebRtc, MediaType, trackId);
        }

        private uint SetDisplay(Display display)
            => display.ApplyTo(this);

        internal void ReplaceDisplay(Display newDisplay)
        {
            _display?.SetOwner(null);
            _display = newDisplay;
            _display?.SetOwner(this);
        }

        /// <summary>
        /// Enables the video loopback. The local video will be diaplayed in <paramref name="display"/>.
        /// </summary>
        /// <param name="display">The <see cref="Display"/> to apply.</param>
        /// <feature>http://tizen.org/feature/display</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">The display has already been assigned to another.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="display"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     MediaSource is not attached yet.<br/>
        /// -or-<br/>
        ///     This MediaSource is not Video
        /// </exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <returns><see cref="MediaStreamTrack"/></returns>
        public MediaStreamTrack EnableVideoLoopback(Display display)
        {
            uint trackId = 0;

            if (!Features.IsSupported(WebRTCFeatures.Display))
            {
                throw new NotSupportedException("Display feature is not supported.");
            }
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
            }
            if (display == null)
            {
                throw new ArgumentNullException(nameof(display), "Display cannot be null.");
            }
            if (MediaType != MediaType.Video)
            {
                throw new InvalidOperationException("VideoLoopback is only for Video MediaSource");
            }

            if (display?.Owner != null)
            {
                if (ReferenceEquals(this, display.Owner))
                {
                    throw new ArgumentException("The display has already been assigned to another.");
                }
            }
            else
            {
                trackId = SetDisplay(display);
                ReplaceDisplay(display);
            }

            return new MediaStreamTrack(WebRtc, MediaType, trackId);
        }

        uint IDisplayable<uint>.ApplyEcoreWindow(IntPtr windowHandle, Rectangle rect, Rotation rotation)
        {
            NativeWebRTC.SetEcoreVideoLoopback(WebRtc.Handle, SourceId.Value, windowHandle, out uint trackId).
                ThrowIfFailed("Failed to set ecore video loopback");

            return trackId;
        }
    }
}
