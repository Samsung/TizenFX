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

namespace Tizen.Multimedia.MediaCodec
{
    /// <summary>
    /// Provides the means to encode and decode the video and the audio data.
    /// </summary>
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
        public MediaCodec()
        {
            int ret = Interop.MediaCodec.Create(out _handle);

            if (ret == (int)MediaCodecErrorCode.InvalidOperation)
            {
                throw new InvalidOperationException("Not able to initialize a new media codec.");
            }

            MultimediaDebug.AssertNoError(ret);

            RegisterInputProcessed();
            RegisterErrorOccurred();
        }

        #region IDisposable-support
        private bool _isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    Interop.MediaCodec.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _isDisposed = true;
            }
        }

        ~MediaCodec()
        {
            Dispose(false);
        }

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

            Interop.MediaCodec.SupportedCodecCallback cb = (codecType, _) =>
            {
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

            int ret = Interop.MediaCodec.ForeachSupportedCodec(cb, IntPtr.Zero);

            MultimediaDebug.AssertNoError(ret);

            _supportedVideoCodecs = videoCodecList.AsReadOnly();
            _supportedAudioCodecs = audioCodecList.AsReadOnly();
        }

        /// <summary>
        /// Prepares the MediaCodec for encoding or decoding.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     The codec is not configured yet.\n
        ///     -or-\n
        ///     Internal error.
        /// </exception>
        public void Prepare()
        {
            ValidateNotDisposed();

            int ret = Interop.MediaCodec.Prepare(_handle);

            if (ret == (int)MediaCodecErrorCode.NotInitialized)
            {
                throw new InvalidOperationException("The codec is not configured.");
            }
            if (ret != (int)MediaCodecErrorCode.None)
            {
                throw new InvalidOperationException("Operation failed.");
            }

            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Unprepares the MediaCodec.
        /// </summary>
        public void Unprepare()
        {
            ValidateNotDisposed();

            int ret = Interop.MediaCodec.Unprepare(_handle);

            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Configures the MediaCodec.
        /// </summary>
        /// <param name="format">The <see cref="MediaFormat"/> for properties of media data to decode or encode.</param>
        /// <param name="encoder">The value indicating whether the codec works as an encoder or a decoder.</param>
        /// <param name="codecType">The value indicating whether the codec uses hardware acceleration.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="codecType"/> is invalid.\n
        ///     -or-\n
        ///     <paramref name="format"/> is neither audio type nor video type.
        ///     </exception>
        /// <exception cref="NotSupportedException">The mime type of the format is not supported.</exception>
        /// <see cref="SupportedAudioCodecs"/>
        /// <see cref="SupportedVideoCodecs"/>
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
            int codecType = (int)format.MimeType & CodecTypeMask;

            if (!Enum.IsDefined(typeof(SupportedCodecType), codecType))
            {
                throw new NotSupportedException("The format is not supported " +
                    $"mime type : { Enum.GetName(typeof(MediaFormatAudioMimeType), format.MimeType) }");
            }

            DoConfigure(codecType, encoder, supportType);

            if (encoder)
            {
                int ret = Interop.MediaCodec.SetAudioEncoderInfo(_handle, format.SampleRate,
                    format.Channel, format.Bit, format.BitRate);

                MultimediaDebug.AssertNoError(ret);
            }
            else
            {
                int ret = Interop.MediaCodec.SetAudioDecoderInfo(_handle, format.SampleRate,
                    format.Channel, format.Bit);

                MultimediaDebug.AssertNoError(ret);
            }
        }

        private void ConfigureVideo(VideoMediaFormat format, bool encoder,
            MediaCodecTypes supportType)
        {
            int codecType = (int)format.MimeType & CodecTypeMask;

            if (!Enum.IsDefined(typeof(SupportedCodecType), codecType))
            {
                throw new NotSupportedException("The format is not supported." +
                    $"mime type : { Enum.GetName(typeof(MediaFormatVideoMimeType), format.MimeType) }");
            }

            DoConfigure(codecType, encoder, supportType);

            if (encoder)
            {
                int ret = Interop.MediaCodec.SetVideoEncoderInfo(_handle, format.Size.Width,
                    format.Size.Height, format.FrameRate, format.BitRate / 1000);

                MultimediaDebug.AssertNoError(ret);
            }
            else
            {
                int ret = Interop.MediaCodec.SetVideoDecoderInfo(_handle, format.Size.Width, format.Size.Height);

                MultimediaDebug.AssertNoError(ret);
            }
        }

        private void DoConfigure(int codecType, bool encoder, MediaCodecTypes supportType)
        {
            Debug.Assert(Enum.IsDefined(typeof(SupportedCodecType), codecType));

            int flags = (int)(encoder ? MediaCodecCodingType.Encoder : MediaCodecCodingType.Decoder);

            flags |= (int)supportType;

            int ret = Interop.MediaCodec.Configure(_handle, codecType, flags);

            if (ret == (int)MediaCodecErrorCode.NotSupportedOnDevice)
            {
                throw new NotSupportedException("The format is not supported.");
            }
            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Adds the packet to the internal queue of the codec.
        /// </summary>
        /// <param name="packet">The packet to be encoded or decoded.</param>
        /// <exception cref="ArgumentNullException"><paramref="packet"/> is null.</exception>
        /// <exception cref="InvalidOperationException">The current codec is not prepared yet.</exception>
        /// <remarks>Any attempts to modify the packet will fail until the <see cref="InputProcessed"/> event for the packet is invoked.</remarks>
        public void ProcessInput(MediaPacket packet)
        {
            ValidateNotDisposed();

            if (packet == null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            MediaPacket.Lock packetLock = MediaPacket.Lock.Get(packet);

            int ret = Interop.MediaCodec.Process(_handle, packetLock.GetHandle(), 0);

            if (ret == (int)MediaCodecErrorCode.InvalidState)
            {
                throw new InvalidOperationException("The codec is in invalid state.");
            }

            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Flushes both input and output buffers.
        /// </summary>
        public void FlushBuffers()
        {
            ValidateNotDisposed();

            int ret = Interop.MediaCodec.FlushBuffers(_handle);

            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Retrieves supported codec types for the specified params.
        /// </summary>
        /// <param name="encoder">The value indicating encoder or decoder.</param>
        /// <param name="type">The mime type to query.</param>
        /// <returns>The values indicating which codec types are supported on the current device.</returns>
        /// <exception cref="ArgumentException"><paramref="type"/> is invalid.</exception>
        public MediaCodecTypes GetCodecType(bool encoder, MediaFormatVideoMimeType type)
        {
            ValidateNotDisposed();

            if (CheckMimeType(typeof(MediaFormatVideoMimeType), (int)type) == false)
            {
                return 0;
            }

            return GetCodecType((int)type, encoder);
        }

        /// <summary>
        /// Retrieves supported codec types for the specified params.
        /// </summary>
        /// <param name="encoder">The value indicating encoder or decoder.</param>
        /// <param name="type">The mime type to query.</param>
        /// <returns>The values indicating which codec types are supported on the current device.</returns>
        /// <exception cref="ArgumentException"><paramref="type"/> is invalid.</exception>
        public MediaCodecTypes GetCodecType(bool encoder, MediaFormatAudioMimeType type)
        {
            ValidateNotDisposed();

            if (CheckMimeType(typeof(MediaFormatAudioMimeType), (int)type) == false)
            {
                return 0;
            }

            return GetCodecType((int)type, encoder);
        }

        private MediaCodecTypes GetCodecType(int mimeType, bool isEncoder)
        {
            int codecType = mimeType & CodecTypeMask;
            int value = 0;

            int ret = Interop.MediaCodec.GetSupportedType(_handle, codecType, isEncoder, out value);

            MultimediaDebug.AssertNoError(ret);

            return (MediaCodecTypes)value;
        }

        private bool CheckMimeType(Type type, int value)
        {
            int codecType = value & CodecTypeMask;

            if (!Enum.IsDefined(type, value))
            {
                throw new ArgumentException($"The mime type value is invalid : { value }.");
            }

            return Enum.IsDefined(typeof(SupportedCodecType), codecType);
        }

        #region OutputAvailable event
        private EventHandler<OutputAvailableEventArgs> _outputAvailable;
        private Interop.MediaCodec.OutputBufferAvailableCallback _outputBufferAvailableCb;
        private object _outputAvailableLock = new object();

        /// <summary>
        /// Occurs when an output buffer is available.
        /// </summary>
        /// <remarks>The output packet needs to be disposed after it is used to clean up unmanaged resources.</remarks>
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
                    Interop.MediaPacket.Destroy(packetHandle);
                    return;
                }

                OutputAvailableEventArgs args = null;
                try
                {
                    args = new OutputAvailableEventArgs(packetHandle);
                }
                catch (Exception e)
                {
                    Interop.MediaPacket.Destroy(packetHandle);

                    MultimediaLog.Error(typeof(MediaCodec).FullName, "Failed to raise OutputAvailable event", e);
                }

                if (args != null)
                {
                    _outputAvailable?.Invoke(this, args);
                }
            };

            int ret = Interop.MediaCodec.SetOutputBufferAvailableCb(_handle, _outputBufferAvailableCb);

            MultimediaDebug.AssertNoError(ret);
        }

        private void UnregisterOutputAvailableCallback()
        {
            int ret = Interop.MediaCodec.UnsetOutputBufferAvailableCb(_handle);

            MultimediaDebug.AssertNoError(ret);
        }
        #endregion

        #region InputProcessed event
        private Interop.MediaCodec.InputBufferUsedCallback _inputBufferUsedCb;

        /// <summary>
        /// Occurs when an input packet is processed.
        /// </summary>
        /// <see cref="ProcessInput(MediaPacket)"/>
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

            int ret = Interop.MediaCodec.SetInputBufferUsedCb(_handle, _inputBufferUsedCb);

            MultimediaDebug.AssertNoError(ret);
        }
        #endregion

        #region ErrorOccurred event
        private Interop.MediaCodec.ErrorCallback _errorCb;

        /// <summary>
        /// Occurs whenever an error is produced in the codec.
        /// </summary>
        public event EventHandler<MediaCodecErrorOccurredEventArgs> ErrorOccurred;

        private void RegisterErrorOccurred()
        {
            _errorCb = (errorCode, _) =>
            {
                MediaCodecError error = (Enum.IsDefined(typeof(MediaCodecError), errorCode)) ?
                    (MediaCodecError)errorCode : MediaCodecError.InternalError;

                ErrorOccurred?.Invoke(this, new MediaCodecErrorOccurredEventArgs(error));
            };
            int ret = Interop.MediaCodec.SetErrorCb(_handle, _errorCb);

            MultimediaDebug.AssertNoError(ret);
        }
        #endregion

        #region EosReached event
        private Interop.MediaCodec.EosCallback _eosCb;

        /// <summary>
        /// Occurs when the codec processes all input data.
        /// </summary>
        public event EventHandler<EventArgs> EosReached;

        private void RegisterEosReached()
        {
            _eosCb = _ => EosReached?.Invoke(this, EventArgs.Empty);

            int ret = Interop.MediaCodec.SetEosCb(_handle, _eosCb);

            MultimediaDebug.AssertNoError(ret);
        }

        #endregion

        #region BufferStatusChanged event
        private Interop.MediaCodec.BufferStatusCallback _bufferStatusCb;

        /// <summary>
        /// Occurs when the codec needs more data or has enough data.
        /// </summary>
        public event EventHandler<BufferStatusChangedEventArgs> BufferStatusChanged;

        private void RegisterBufferStatusChanged()
        {
            _bufferStatusCb = (statusCode, _) =>
            {
                Debug.Assert(Enum.IsDefined(typeof(MediaCodecStatus), statusCode),
                    $"{ statusCode } is not defined in MediaCodecStatus!");

                BufferStatusChanged?.Invoke(this,
                    new BufferStatusChangedEventArgs((MediaCodecStatus)statusCode));
            };

            int ret = Interop.MediaCodec.SetBufferStatusCb(_handle, _bufferStatusCb);

            MultimediaDebug.AssertNoError(ret);
        }
        #endregion
    }
}
