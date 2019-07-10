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

using static Interop;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Tizen.Multimedia
{
    public partial class Player
    {
        /// <summary>
        /// Occurs when the playback of a media is finished.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<EventArgs> PlaybackCompleted;
        private NativePlayer.PlaybackCompletedCallback _playbackCompletedCallback;

        /// <summary>
        /// Occurs when the playback of a media is interrupted.
        /// </summary>
        /// <remarks>
        /// If the reason is <see cref="PlaybackInterruptionReason.ResourceConflict"/>,
        /// the player state will be one of <see cref="PlayerState.Idle"/>, <see cref="PlayerState.Ready"/>,
        /// or <see cref="PlayerState.Paused"/>.
        /// </remarks>
        /// <seealso cref="Player.State"/>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<PlaybackInterruptedEventArgs> PlaybackInterrupted;
        private NativePlayer.PlaybackInterruptedCallback _playbackInterruptedCallback;

        /// <summary>
        /// Occurs when any error occurs.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<PlayerErrorOccurredEventArgs> ErrorOccurred;
        private NativePlayer.PlaybackErrorCallback _playbackErrorCallback;

        /// <summary>
        /// Occurs when the video stream is changed.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<VideoStreamChangedEventArgs> VideoStreamChanged;
        private NativePlayer.VideoStreamChangedCallback _videoStreamChangedCallback;

        /// <summary>
        /// Occurs when the subtitle is updated.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<SubtitleUpdatedEventArgs> SubtitleUpdated;
        private NativePlayer.SubtitleUpdatedCallback _subtitleUpdatedCallback;

        /// <summary>
        /// Occurs when there is a change in the buffering status of streaming.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<BufferingProgressChangedEventArgs> BufferingProgressChanged;
        private NativePlayer.BufferingProgressCallback _bufferingProgressCallback;

        internal event EventHandler<MediaStreamBufferStatusChangedEventArgs> MediaStreamAudioBufferStatusChanged;
        private NativePlayer.MediaStreamBufferStatusCallback _mediaStreamAudioBufferStatusChangedCallback;

        internal event EventHandler<MediaStreamBufferStatusChangedEventArgs> MediaStreamVideoBufferStatusChanged;
        private NativePlayer.MediaStreamBufferStatusCallback _mediaStreamVideoBufferStatusChangedCallback;

        internal event EventHandler<MediaStreamSeekingOccurredEventArgs> MediaStreamAudioSeekingOccurred;
        private NativePlayer.MediaStreamSeekCallback _mediaStreamAudioSeekCallback;

        internal event EventHandler<MediaStreamSeekingOccurredEventArgs> MediaStreamVideoSeekingOccurred;
        private NativePlayer.MediaStreamSeekCallback _mediaStreamVideoSeekCallback;

        private void RegisterEvents()
        {
            RegisterSubtitleUpdatedCallback();
            RegisterErrorOccurredCallback();
            RegisterPlaybackInterruptedCallback();
            RegisterVideoStreamChangedCallback();
            RegisterBufferingCallback();
            RegisterMediaStreamBufferStatusCallback();
            RegisterMediaStreamSeekCallback();
            RegisterPlaybackCompletedCallback();
        }

        private void RegisterSubtitleUpdatedCallback()
        {
            _subtitleUpdatedCallback = (duration, text, _) =>
            {
                Log.Debug(PlayerLog.Tag, $"duration : {duration}, text : {text}");
                SubtitleUpdated?.Invoke(this, new SubtitleUpdatedEventArgs(duration, text));
            };

            NativePlayer.SetSubtitleUpdatedCb(Handle, _subtitleUpdatedCallback).
                ThrowIfFailed(this, "Failed to initialize the player");
        }

        private void RegisterPlaybackCompletedCallback()
        {
            _playbackCompletedCallback = _ =>
            {
                Log.Debug(PlayerLog.Tag, "completed callback");
                PlaybackCompleted?.Invoke(this, EventArgs.Empty);
            };
            NativePlayer.SetCompletedCb(Handle, _playbackCompletedCallback).
                ThrowIfFailed(this, "Failed to set PlaybackCompleted");
        }

        private void RegisterPlaybackInterruptedCallback()
        {
            _playbackInterruptedCallback = (code, _) =>
            {
                if (!Enum.IsDefined(typeof(PlaybackInterruptionReason), code))
                {
                    return;
                }

                if (code == PlaybackInterruptionReason.ResourceConflict)
                {
                    OnUnprepared();
                }

                Log.Warn(PlayerLog.Tag, $"interrupted reason : {code}");
                PlaybackInterrupted?.Invoke(this, new PlaybackInterruptedEventArgs(code));
            };

            NativePlayer.SetInterruptedCb(Handle, _playbackInterruptedCallback).
                ThrowIfFailed(this, "Failed to set PlaybackInterrupted");
        }

        private void RegisterErrorOccurredCallback()
        {
            _playbackErrorCallback = (code, _) =>
            {
                //TODO handle service disconnected error.
                Log.Warn(PlayerLog.Tag, "error code : " + code);
                ErrorOccurred?.Invoke(this, new PlayerErrorOccurredEventArgs((PlayerError)code));
            };

            NativePlayer.SetErrorCb(Handle, _playbackErrorCallback).
                ThrowIfFailed(this, "Failed to set PlaybackError");
        }

        /// <summary>
        /// Raises the <see cref="ErrorOccurred"/> event.
        /// </summary>
        /// <param name="e">
        /// An <see cref="PlayerErrorOccurredEventArgs"/> that contains the event data.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void OnErrorOccurred(PlayerErrorOccurredEventArgs e)
        {
            ErrorOccurred?.Invoke(this, e);
        }

        #region VideoFrameDecoded event
        private EventHandler<VideoFrameDecodedEventArgs> _videoFrameDecoded;

        private NativePlayer.VideoFrameDecodedCallback _videoFrameDecodedCallback;

        /// <summary>
        /// Occurs when a video frame is decoded.
        /// </summary>
        /// <remarks>
        ///     <para>The event handler will be executed on an internal thread.</para>
        ///     <para>The <see cref="VideoFrameDecodedEventArgs.Packet"/> in event args should be disposed after use.</para>
        /// </remarks>
        /// <feature>http://tizen.org/feature/multimedia.raw_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <seealso cref="VideoFrameDecodedEventArgs.Packet"/>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<VideoFrameDecodedEventArgs> VideoFrameDecoded
        {
            add
            {
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.RawVideo);

                _videoFrameDecoded += value;
            }
            remove
            {
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.RawVideo);

                _videoFrameDecoded -= value;
            }
        }

        private void RegisterVideoFrameDecodedCallback()
        {
            _videoFrameDecodedCallback = (packetHandle, _) =>
            {
                var handler = _videoFrameDecoded;
                if (handler != null)
                {
                    Log.Debug(PlayerLog.Tag, "packet : " + packetHandle);
                    handler.Invoke(this,
                        new VideoFrameDecodedEventArgs(MediaPacket.From(packetHandle)));
                }
                else
                {
                    MediaPacket.From(packetHandle).Dispose();
                }
            };

            NativePlayer.SetVideoFrameDecodedCb(Handle, _videoFrameDecodedCallback).
                ThrowIfFailed(this, "Failed to register the VideoFrameDecoded");
        }
        #endregion

        #region AudioFrameDecoded event
        private event EventHandler<AudioFrameDecodedEventArgs> _audioFrameDecoded;

        private NativePlayer.AudioFrameDecodedCallback _audioFrameDecodedCallback;

        /// <summary>
        /// Occurs when a audio frame is decoded.
        /// </summary>
        /// <remarks>
        ///     <para>The event handler will be executed on an internal thread.</para>
        ///     <para>The <see cref="AudioFrameDecodedEventArgs.Packet"/> in event args should be disposed after use.</para>
        /// </remarks>
        /// <seealso cref="AudioFrameDecodedEventArgs.Packet"/>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<AudioFrameDecodedEventArgs> AudioFrameDecoded
        {
            add
            {
                _audioFrameDecoded += value;
            }
            remove
            {
                _audioFrameDecoded -= value;
            }
        }
        #endregion

        private void RegisterVideoStreamChangedCallback()
        {
            _videoStreamChangedCallback = (width, height, fps, bitrate, _) =>
            {
                Log.Debug(PlayerLog.Tag, $"height={height}, width={width}, fps={fps}, bitrate={bitrate}");

                VideoStreamChanged?.Invoke(this, new VideoStreamChangedEventArgs(height, width, fps, bitrate));
            };

            NativePlayer.SetVideoStreamChangedCb(Handle, _videoStreamChangedCallback).
                ThrowIfFailed(this, "Failed to set the video stream changed callback");
        }

        private void RegisterBufferingCallback()
        {
            _bufferingProgressCallback = (percent, _) =>
            {
                Log.Debug(PlayerLog.Tag, $"Buffering callback with percent { percent }");

                BufferingProgressChanged?.Invoke(this, new BufferingProgressChangedEventArgs(percent));
            };

            NativePlayer.SetBufferingCb(Handle, _bufferingProgressCallback).
                ThrowIfFailed(this, "Failed to set BufferingProgress");
        }

        private void RegisterMediaStreamBufferStatusCallback()
        {
            _mediaStreamAudioBufferStatusChangedCallback = (status, _) =>
            {
                Debug.Assert(Enum.IsDefined(typeof(MediaStreamBufferStatus), status));
                Log.Debug(PlayerLog.Tag, "audio buffer status : " + status);

                MediaStreamAudioBufferStatusChanged?.Invoke(this,
                    new MediaStreamBufferStatusChangedEventArgs(status));
            };
            _mediaStreamVideoBufferStatusChangedCallback = (status, _) =>
            {
                Debug.Assert(Enum.IsDefined(typeof(MediaStreamBufferStatus), status));
                Log.Debug(PlayerLog.Tag, "video buffer status : " + status);

                MediaStreamVideoBufferStatusChanged?.Invoke(this,
                    new MediaStreamBufferStatusChangedEventArgs(status));
            };

            RegisterMediaStreamBufferStatusCallback(StreamType.Audio, _mediaStreamAudioBufferStatusChangedCallback);
            RegisterMediaStreamBufferStatusCallback(StreamType.Video, _mediaStreamVideoBufferStatusChangedCallback);
        }

        private void RegisterMediaStreamBufferStatusCallback(StreamType streamType,
            NativePlayer.MediaStreamBufferStatusCallback cb)
        {
            NativePlayer.SetMediaStreamBufferStatusCb(Handle, streamType, cb).
                ThrowIfFailed(this, "Failed to SetMediaStreamBufferStatus");
        }

        private void RegisterMediaStreamSeekCallback()
        {
            _mediaStreamAudioSeekCallback = (offset, _) =>
            {
                Log.Debug(PlayerLog.Tag, "audio seeking offset : " + offset);
                MediaStreamAudioSeekingOccurred?.Invoke(this, new MediaStreamSeekingOccurredEventArgs(offset));
            };
            _mediaStreamVideoSeekCallback = (offset, _) =>
            {
                Log.Debug(PlayerLog.Tag, "video seeking offset : " + offset);
                MediaStreamVideoSeekingOccurred?.Invoke(this, new MediaStreamSeekingOccurredEventArgs(offset));
            };

            RegisterMediaStreamSeekCallback(StreamType.Audio, _mediaStreamAudioSeekCallback);
            RegisterMediaStreamSeekCallback(StreamType.Video, _mediaStreamVideoSeekCallback);
        }

        private void RegisterMediaStreamSeekCallback(StreamType streamType, NativePlayer.MediaStreamSeekCallback cb)
        {
            NativePlayer.SetMediaStreamSeekCb(Handle, streamType, cb).
                ThrowIfFailed(this, "Failed to SetMediaStreamSeek");
        }
    }
}
