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
using System.Collections.Generic;
using System.Diagnostics;
using Native = Interop.MediaCodec;

namespace Tizen.Multimedia.MediaCodec
{
    /// <summary>
    /// Provides a means to encode and decode the video and the audio data.
    /// </summary>
    /// <feature>http://tizen.org/feature/multimedia.media_codec</feature>
    /// <since_tizen> 3 </since_tizen>
    public class MediaCodec : IDisposable
    {
        private const int CodecTypeMask = 0xFFFF;
        private const int CodecKindMask = 0x3000;
        // private const int CodecKindAudio = 0x1000; // Not used
        private const int CodecKindVideo = 0x2000;

        private IntPtr _handle;

        /// <summary>
        /// Initializes a new instance of the MediaCodec class.
        /// </summary>
        /// <feature>http://tizen.org/feature/multimedia.media_codec</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public MediaCodec()
        {
            Native.Create(out _handle).ThrowIfFailed("Failed to create media codec.");

            RegisterInputProcessed();
            RegisterErrorOccurred();
            RegisterBufferStatusChanged();
            RegisterEosReached();
        }

        #region IDisposable-support
        private bool _isDisposed = false;

        /// <summary>
        /// Releases the resources used by the <see cref="MediaCodec"/> object.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    Native.Destroy(_handle).ThrowIfFailed("Failed to destry media codec.");
                    _handle = IntPtr.Zero;
                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the MediaCodec class.
        /// </summary>
        ~MediaCodec()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all resources used by the <see cref="MediaCodec"/> object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// Validates if the object has already been disposed of.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The current object has been disposed of.</exception>
        private void ValidateNotDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(MediaCodec));
            }
        }

        private static IEnumerable<MediaFormatVideoMimeType> _supportedVideoCodecs;

        /// <summary>
        /// Gets the audio codec list that the current device supports.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static IEnumerable<MediaFormatVideoMimeType> SupportedVideoCodecs
        {
            get
            {
                if (_supportedVideoCodecs == null)
                {
                    LoadSupportedCodec();
                }

                return _supportedVideoCodecs;
            }
        }

        private static IEnumerable<MediaFormatAudioMimeType> _supportedAudioCodecs;

        /// <summary>
        /// Gets the audio codec list that the current device supports.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static IEnumerable<MediaFormatAudioMimeType> SupportedAudioCodecs
        {
            get
            {
                if (_supportedAudioCodecs == null)
                {
                    LoadSupportedCodec();
                }

                return _supportedAudioCodecs;
            }
        }

        private static bool TryGetMimeTypeFromCodecType<T>(int codecType, ref T result)
        {
            if (codecType == -1)
            {
                return false;
            }

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                if ((Convert.ToInt32(value) & CodecTypeMask) == codecType)
                {
                    result = value;
                    return true;
                }
            }

            Debug.Fail($"Unknown codec : { codecType }.");
            return false;
        }

        private static void LoadSupportedCodec()
        {
            var videoCodecList = new List<MediaFormatVideoMimeType>();
            var audioCodecList = new List<MediaFormatAudioMimeType>();

            Native.SupportedCodecCallback cb = (codecType, _) =>
            {
                codecType = TypeConverter.ToPublic((SupportedCodecType)codecType);
                if ((codecType & CodecKindMask) == CodecKindVideo)
                {
                    MediaFormatVideoMimeType mimeType = 0;
                    if (TryGetMimeTypeFromCodecType(codecType, ref mimeType))
                    {
                        videoCodecList.Add(mimeType);
                    }
                }
                else
                {
                    MediaFormatAudioMimeType mimeType = 0;
                    if (TryGetMimeTypeFromCodecType(codecType, ref mimeType))
                    {
                        audioCodecList.Add(mimeType);
                    }
                }

                return true;
            };

            Native.ForeachSupportedCodec(cb, IntPtr.Zero).ThrowIfFailed("Failed to get supported codec.");

            _supportedVideoCodecs = videoCodecList.AsReadOnly();
            _supportedAudioCodecs = audioCodecList.AsReadOnly();
        }

        /// <summary>
        /// Prepares the MediaCodec for encoding or decoding.
        /// </summary>
        /// <feature>http://tizen.org/feature/multimedia.media_codec</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The codec is not configured yet.<br/>
        ///     -or-<br/>
        ///     Internal error.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public void Prepare()
        {
            ValidateNotDisposed();

            Native.Prepare(_handle).ThrowIfFailed("Failed to prepare media codec.");
        }

        /// <summary>
        /// Unprepares the MediaCodec.
        /// </summary>
        /// <feature>http://tizen.org/feature/multimedia.media_codec</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Unprepare()
        {
            ValidateNotDisposed();

            Native.Unprepare(_handle).ThrowIfFailed("Failed to unprepare media codec.");
        }

        /// <summary>
        /// Configures the MediaCodec.
        /// </summary>
        /// <param name="format">The <see cref="MediaFormat"/> for properties of media data to decode or encode.</param>
        /// <param name="encoder">The value indicating whether the codec works as an encoder or a decoder.</param>
        /// <param name="codecType">The value indicating whether the codec uses hardware acceleration.</param>
        /// <feature>http://tizen.org/feature/multimedia.media_codec</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="codecType"/> is invalid.<br/>
        ///     -or-<br/>
        ///     <paramref name="format"/> is neither audio type nor video type.
        ///     </exception>
        /// <exception cref="NotSupportedException">The mime type of the format is not supported.</exception>
        /// <see cref="SupportedAudioCodecs"/>
        /// <see cref="SupportedVideoCodecs"/>
        /// <since_tizen> 3 </since_tizen>
        public void Configure(MediaFormat format, bool encoder, MediaCodecTypes codecType)
        {
            ValidateNotDisposed();

            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (codecType != MediaCodecTypes.Hardware && codecType != MediaCodecTypes.Software)
            {
                throw new ArgumentException("codecType is invalid.");
            }

            if (format.Type == MediaFormatType.Audio)
            {
                ConfigureAudio((AudioMediaFormat)format, encoder, codecType);
            }
            else if (format.Type == MediaFormatType.Video)
            {
                ConfigureVideo((VideoMediaFormat)format, encoder, codecType);
            }
            else
            {
                throw new ArgumentException("Only video and audio formats are allowed.");
            }
        }

        private void ConfigureAudio(AudioMediaFormat format, bool encoder,
            MediaCodecTypes supportType)
        {
            int codecType = TypeConverter.ToNative(format.MimeType);

            if (!Enum.IsDefined(typeof(SupportedCodecType), codecType))
            {
                throw new NotSupportedException("The format is not supported " +
                    $"mime type : { Enum.GetName(typeof(MediaFormatAudioMimeType), format.MimeType) }");
            }

            DoConfigure(codecType, encoder, supportType);

            if (encoder)
            {
                Native.SetAudioEncoderInfo(_handle, format.SampleRate, format.Channel, format.Bit, format.BitRate).
                    ThrowIfFailed("Failed to set audio encoder information.");
            }
            else
            {
                Native.SetAudioDecoderInfo(_handle, format.SampleRate, format.Channel, format.Bit).
                    ThrowIfFailed("Failed to set audio decoder information.");
            }
        }

        private void ConfigureVideo(VideoMediaFormat format, bool encoder,
            MediaCodecTypes supportType)
        {
            int codecType = TypeConverter.ToNative(format.MimeType);

            if (!Enum.IsDefined(typeof(SupportedCodecType), codecType))
            {
                throw new NotSupportedException("The format is not supported." +
                    $"mime type : { Enum.GetName(typeof(MediaFormatVideoMimeType), format.MimeType) }");
            }

            DoConfigure(codecType, encoder, supportType);

            if (encoder)
            {
                Native.SetVideoEncoderInfo(_handle, format.Size.Width, format.Size.Height, format.FrameRate, format.BitRate / 1000).
                    ThrowIfFailed("Failed to set video encoder information.");
            }
            else
            {
                Native.SetVideoDecoderInfo(_handle, format.Size.Width, format.Size.Height).
                    ThrowIfFailed("Failed to set video decoder information.");
            }
        }

        private void DoConfigure(int codecType, bool encoder, MediaCodecTypes supportType)
        {
            Debug.Assert(Enum.IsDefined(typeof(SupportedCodecType), codecType));

            int flags = (int)(encoder ? MediaCodecCodingType.Encoder : MediaCodecCodingType.Decoder);

            flags |= (int)supportType;

            Native.Configure(_handle, codecType, flags).ThrowIfFailed("Failed to configure media codec.");
        }

        /// <summary>
        /// Adds the packet to the internal queue of the codec.
        /// </summary>
        /// <param name="packet">The packet to be encoded or decoded.</param>
        /// <feature>http://tizen.org/feature/multimedia.media_codec</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="packet"/> is null.</exception>
        /// <exception cref="InvalidOperationException">The current codec is not prepared yet.</exception>
        /// <remarks>Any attempts to modify the packet will fail until the <see cref="InputProcessed"/> event for the packet is invoked.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public void ProcessInput(MediaPacket packet)
        {
            ValidateNotDisposed();

            if (packet == null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            MediaPacket.Lock packetLock = MediaPacket.Lock.Get(packet);

            Native.Process(_handle, packetLock.GetHandle(), 0).ThrowIfFailed("Failed to process input."); ;
        }

        /// <summary>
        /// Flushes both input and output buffers.
        /// </summary>
        /// <feature>http://tizen.org/feature/multimedia.media_codec</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void FlushBuffers()
        {
            ValidateNotDisposed();

            Native.FlushBuffers(_handle).ThrowIfFailed("Failed to flush buffers.");
        }

        /// <summary>
        /// Retrieves supported codec types for the specified params.
        /// </summary>
        /// <param name="encoder">The value indicating encoder or decoder.</param>
        /// <param name="type">The mime type to query.</param>
        /// <returns>The values indicating which codec types are supported on the current device.</returns>
        /// <feature>http://tizen.org/feature/multimedia.media_codec</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="type"/> is invalid.</exception>
        /// <since_tizen> 3 </since_tizen>
        public MediaCodecTypes GetCodecType(bool encoder, MediaFormatVideoMimeType type)
        {
            ValidateNotDisposed();

            if (CheckMimeType(typeof(MediaFormatVideoMimeType), type) == false)
            {
                return 0;
            }

            return GetCodecType(type, typeof(MediaFormatVideoMimeType), encoder);
        }

        /// <summary>
        /// Retrieves supported codec types for the specified params.
        /// </summary>
        /// <param name="encoder">The value indicating encoder or decoder.</param>
        /// <param name="type">The mime type to query.</param>
        /// <returns>The values indicating which codec types are supported on the current device.</returns>
        /// <feature>http://tizen.org/feature/multimedia.media_codec</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="type"/> is invalid.</exception>
        /// <since_tizen> 3 </since_tizen>
        public MediaCodecTypes GetCodecType(bool encoder, MediaFormatAudioMimeType type)
        {
            ValidateNotDisposed();

            if (CheckMimeType(typeof(MediaFormatAudioMimeType), type) == false)
            {
                return 0;
            }

            return GetCodecType(type, typeof(MediaFormatAudioMimeType), encoder);
        }

        private MediaCodecTypes GetCodecType<T>(T mimeType, Type type, bool isEncoder)
        {
            dynamic changedType = Convert.ChangeType(mimeType, type);
            int codecType = TypeConverter.ToNative(changedType);

            Native.GetSupportedType(_handle, codecType, isEncoder, out int value).
                ThrowIfFailed("Failed to get supported media codec type.");

            return (MediaCodecTypes)value;
        }

        private bool CheckMimeType<T>(Type mimeType, T value)
        {
            if (!Enum.IsDefined(mimeType, value))
            {
                throw new ArgumentException($"The mime type value is invalid : { value }.");
            }

            dynamic changedType = Convert.ChangeType(value, mimeType);
            var codecType = TypeConverter.ToNative(changedType);

            return Enum.IsDefined(typeof(SupportedCodecType), codecType);
        }

        #region OutputAvailable event
        private EventHandler<OutputAvailableEventArgs> _outputAvailable;
        private Native.OutputBufferAvailableCallback _outputBufferAvailableCb;
        private object _outputAvailableLock = new object();

        /// <summary>
        /// Occurs when an output buffer is available.
        /// </summary>
        /// <remarks>The output packet needs to be disposed after it is used to clean up unmanaged resources.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<OutputAvailableEventArgs> OutputAvailable
        {
            add
            {
                ValidateNotDisposed();

                lock (_outputAvailableLock)
                {
                    if (_outputAvailable == null)
                    {
                        RegisterOutputAvailableCallback();
                    }
                    _outputAvailable += value;
                }
            }
            remove
            {
                ValidateNotDisposed();

                lock (_outputAvailableLock)
                {
                    _outputAvailable -= value;
                    if (_outputAvailable == null)
                    {
                        // We can remove handler first, because we know the method that unregisters callback does not throw.
                        UnregisterOutputAvailableCallback();
                    }
                }
            }
        }

        private void RegisterOutputAvailableCallback()
        {
            _outputBufferAvailableCb = (packetHandle, _) =>
            {
                if (_outputAvailable == null)
                {
                    try
                    {
                        Native.Destroy(packetHandle).ThrowIfFailed("Failed to destroy packet.");
                    }
                    catch (Exception)
                    {
                        // Do not throw exception in pinvoke callback.
                    }

                    return;
                }

                OutputAvailableEventArgs args = null;
                try
                {
                    args = new OutputAvailableEventArgs(packetHandle);
                }
                catch (Exception e)
                {
                    try
                    {
                        Native.Destroy(packetHandle).ThrowIfFailed("Failed to destroy packet.");
                    }
                    catch
                    {
                        // Do not throw exception in pinvoke callback.
                    }

                    MultimediaLog.Error(typeof(MediaCodec).FullName, "Failed to raise OutputAvailable event", e);
                }

                if (args != null)
                {
                    _outputAvailable?.Invoke(this, args);
                }
            };

            Native.SetOutputBufferAvailableCb(_handle, _outputBufferAvailableCb).
                ThrowIfFailed("Failed to set output buffer available callback.");
        }

        private void UnregisterOutputAvailableCallback()
        {
            Native.UnsetOutputBufferAvailableCb(_handle).ThrowIfFailed("Failed to unregister output available callback.");
        }
        #endregion

        #region InputProcessed event
        private Native.InputBufferUsedCallback _inputBufferUsedCb;

        /// <summary>
        /// Occurs when an input packet is processed.
        /// </summary>
        /// <see cref="ProcessInput(MediaPacket)"/>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<InputProcessedEventArgs> InputProcessed;

        private void RegisterInputProcessed()
        {
            _inputBufferUsedCb = (lockedPacketHandle, _) =>
            {
                MediaPacket packet = null;

                // Lock must be disposed here, note that the packet won't be disposed.
                using (MediaPacket.Lock packetLock =
                    MediaPacket.Lock.FromHandle(lockedPacketHandle))
                {
                    Debug.Assert(packetLock != null);

                    packet = packetLock.MediaPacket;
                }
                Debug.Assert(packet != null);

                InputProcessed?.Invoke(this, new InputProcessedEventArgs(packet));
            };

            Native.SetInputBufferUsedCb(_handle, _inputBufferUsedCb).
                ThrowIfFailed("Failed to set input buffer used callback.");
        }
        #endregion

        #region ErrorOccurred event
        private Native.ErrorCallback _errorCb;

        /// <summary>
        /// Occurs whenever an error is produced in the codec.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<MediaCodecErrorOccurredEventArgs> ErrorOccurred;

        private void RegisterErrorOccurred()
        {
            _errorCb = (errorCode, _) =>
            {
                MediaCodecError error = (Enum.IsDefined(typeof(MediaCodecError), errorCode)) ?
                    (MediaCodecError)errorCode : MediaCodecError.InternalError;

                ErrorOccurred?.Invoke(this, new MediaCodecErrorOccurredEventArgs(error));
            };
            Native.SetErrorCb(_handle, _errorCb).ThrowIfFailed("Failed to set error callback.");
        }
        #endregion

        #region EosReached event
        private Native.EosCallback _eosCb;

        /// <summary>
        /// Occurs when the codec processes all input data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<EventArgs> EosReached;

        private void RegisterEosReached()
        {
            _eosCb = _ => EosReached?.Invoke(this, EventArgs.Empty);

            Native.SetEosCb(_handle, _eosCb).ThrowIfFailed("Failed to set eos callback.");
        }
        #endregion

        #region BufferStatusChanged event
        private Native.BufferStatusCallback _bufferStatusCb;

        /// <summary>
        /// Occurs when the codec needs more data or has enough data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<BufferStatusChangedEventArgs> BufferStatusChanged;

        private void RegisterBufferStatusChanged()
        {
            _bufferStatusCb = (statusCode, _) =>
            {
                Debug.Assert(Enum.IsDefined(typeof(MediaCodecStatus), statusCode),
                    $"{ statusCode } is not defined in MediaCodecStatus!");

                BufferStatusChanged?.Invoke(this, new BufferStatusChangedEventArgs(statusCode));
            };

            Native.SetBufferStatusCb(_handle, _bufferStatusCb).
                ThrowIfFailed("Failed to set buffer status callback.");
        }
        #endregion
    }
}
