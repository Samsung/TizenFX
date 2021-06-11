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
using System.ComponentModel;
using System.Diagnostics;
using Tizen.Internals.Errors;
using Native = Tizen.Multimedia.Interop.MediaPacket;
using NativeFormat = Tizen.Multimedia.Interop.MediaFormat;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a packet for multimedia.
    /// </summary>
    public abstract partial class MediaPacket : IBufferOwner, IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;

        /// <summary>
        /// Initializes a new instance of the MediaPacket class with the specified media format.
        /// </summary>
        /// <param name="format">The media format containing properties for the packet.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     The <see cref="MediaFormatType"/> of the specified format is <see cref="MediaFormatType.Container"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">Operation failed.</exception>
        internal MediaPacket(MediaFormat format)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            Initialize(format);

            _format = format;
            _buffer = new Lazy<IMediaBuffer>(GetBuffer);
        }

        /// <summary>
        /// Initializes a new instance of the MediaPacket class with the specified media format and tbm surface.
        /// </summary>
        /// <param name="format">The media format containing properties for the packet.</param>
        /// <param name="handle">The native tbm handle to be used.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="handle"/>is null.</exception>
        /// <exception cref="ArgumentException">
        ///     The <see cref="MediaFormatType"/> of the specified format is <see cref="MediaFormatType.Container"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">Operation failed.</exception>
        internal MediaPacket(MediaFormat format, IntPtr handle)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            if (handle == IntPtr.Zero)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            Initialize(format, handle);

            _format = format;
            _buffer = new Lazy<IMediaBuffer>(GetBuffer);
        }

        /// <summary>
        /// Initializes a new instance of the MediaPacket class from a native handle.
        /// </summary>
        /// <param name="handle">The native handle to be used.</param>
        internal MediaPacket(IntPtr handle)
        {
            _handle = handle;

            int ret = Native.GetFormat(handle, out IntPtr formatHandle);

            MultimediaDebug.AssertNoError(ret);

            try
            {
                if (formatHandle != IntPtr.Zero)
                {
                    _format = MediaFormat.FromHandle(formatHandle);
                }
            }
            finally
            {
                NativeFormat.Unref(formatHandle);
            }
        }

        /// <summary>
        /// Finalizes an instance of the MediaPacket class.
        /// </summary>
        ~MediaPacket()
        {
            Dispose(false);
        }

        private void Initialize(MediaFormat format)
        {
            Initialize(format, IntPtr.Zero);
        }

        /// <summary>
        /// Creates and initializes a native handle for the current object.
        /// </summary>
        /// <param name="format">The format to be set to the media format.</param>
        /// <param name="handle">The native tbm handle to be used.</param>
        /// <exception cref="InvalidOperationException">Operation failed.</exception>
        private void Initialize(MediaFormat format, IntPtr handle)
        {
            if (format.Type == MediaFormatType.Container)
            {
                throw new ArgumentException("Container format can't be used to create a new packet.",
                    nameof(format));
            }

            IntPtr formatHandle = IntPtr.Zero;

            try
            {
                formatHandle = format.AsNativeHandle();

                int ret = 0;
                if (handle == IntPtr.Zero)
                {
                    ret = Native.Create(formatHandle, IntPtr.Zero, IntPtr.Zero, out _handle);
                }
                else
                {
                    ret = Native.CreateFromTbmSurface(formatHandle, handle, IntPtr.Zero, IntPtr.Zero, out _handle);
                }

                MultimediaDebug.AssertNoError(ret);

                Debug.Assert(_handle != IntPtr.Zero, "Created handle must not be null");

                Alloc();
            }
            catch (Exception)
            {
                if (_handle != IntPtr.Zero)
                {
                    Native.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                throw;
            }
            finally
            {
                if (formatHandle != IntPtr.Zero)
                {
                    NativeFormat.Unref(formatHandle);
                }
            }
        }

        /// <summary>
        /// Allocates internal buffer.
        /// </summary>
        /// <exception cref="InvalidOperationException">Operation failed.</exception>
        private void Alloc()
        {
            ErrorCode ret = (ErrorCode)Native.Alloc(_handle);
            if (ret == ErrorCode.None)
            {
                return;
            }

            _handle = IntPtr.Zero;

            switch (ret)
            {
                case ErrorCode.OutOfMemory:
                    throw new OutOfMemoryException("Failed to allocate buffer for the packet.");

                default:
                    throw new InvalidOperationException("Failed to create a packet.");
            }

        }

        private readonly MediaFormat _format;

        /// <summary>
        /// Gets the media format of the current packet.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaFormat Format
        {
            get
            {
                ValidateNotDisposed();
                return _format;
            }
        }

        /// <summary>
        /// Gets or sets the PTS(Presentation Time Stamp) value of the current packet in nanoseconds.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket is not in the writable state, which means it is being used by another module.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public ulong Pts
        {
            get
            {
                ValidateNotDisposed();

                int ret = Native.GetPts(_handle, out var value);

                MultimediaDebug.AssertNoError(ret);

                return value;
            }
            set
            {
                ValidateNotDisposed();
                ValidateNotLocked();

                int ret = Native.SetPts(_handle, value);

                MultimediaDebug.AssertNoError(ret);
            }
        }

        /// <summary>
        /// Gets or sets the DTS(Decoding Time Stamp) value of the current packet in nanoseconds.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket is not in the writable state, which means it is being used by another module.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public ulong Dts
        {
            get
            {
                ValidateNotDisposed();

                int ret = Native.GetDts(_handle, out var value);
                MultimediaDebug.AssertNoError(ret);

                return value;
            }
            set
            {
                ValidateNotDisposed();
                ValidateNotLocked();

                int ret = Native.SetDts(_handle, value);
                MultimediaDebug.AssertNoError(ret);
            }
        }

        /// <summary>
        /// Gets or sets the duration value of the current packet in nanoseconds.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket is not in the writable state, which means it is being used by another module.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public ulong Duration
        {
            get
            {
                ValidateNotDisposed();

                int ret = Native.GetDuration(_handle, out var value);
                MultimediaDebug.AssertNoError(ret);

                return value;
            }
            set
            {
                ValidateNotDisposed();
                ValidateNotLocked();

                int ret = Native.SetDuration(_handle, value);
                MultimediaDebug.AssertNoError(ret);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the packet is the encoded type.
        /// </summary>
        /// <value>true if the packet is the encoded type; otherwise, false.</value>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public bool IsEncoded
        {
            get
            {
                ValidateNotDisposed();

                int ret = Native.IsEncoded(_handle, out var value);
                MultimediaDebug.AssertNoError(ret);

                return value;
            }
        }

        /// <summary>
        /// Gets or sets the rotation value of the current packet.
        /// </summary>
        /// <exception cref="ArgumentException">The specified value to set is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket is not in the writable state, which means it is being used by another module.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public Rotation Rotation
        {
            get
            {
                ValidateNotDisposed();

                int ret = Native.GetRotation(_handle, out var value);
                MultimediaDebug.AssertNoError(ret);

                var rotation = value < RotationFlip.HorizontalFlip ? (Rotation)value : Rotation.Rotate0;

                return rotation;
            }
            set
            {
                ValidateNotDisposed();
                ValidateNotLocked();
                ValidationUtil.ValidateEnum(typeof(Rotation), value, nameof(value));

                int ret = Native.SetRotation(_handle, (RotationFlip)value);
                MultimediaDebug.AssertNoError(ret);
            }
        }

        /// <summary>
        /// Gets or sets the flip value of the current packet.
        /// </summary>
        /// <remarks>
        /// <see cref="Flips.None"/> will be ignored in set case. It's not supported in Native FW.
        /// </remarks>
        /// <exception cref="ArgumentException">The specified value to set is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket is not in the writable state, which means it is being used by another module.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public Flips Flip
        {
            get
            {
                ValidateNotDisposed();

                int ret = Native.GetRotation(_handle, out var value);
                MultimediaDebug.AssertNoError(ret);

                var flip = (value < RotationFlip.HorizontalFlip) ? Flips.None :
                    (value == RotationFlip.HorizontalFlip ? Flips.Horizontal : Flips.Vertical);

                return flip;
            }
            set
            {
                ValidateNotDisposed();
                ValidateNotLocked();
                ValidationUtil.ValidateEnum(typeof(Flips), value, nameof(value));

                if (value == Flips.None)
                {
                    return;
                }

                var flip = value == Flips.Horizontal ? RotationFlip.HorizontalFlip : RotationFlip.VerticalFlip;

                int ret = Native.SetRotation(_handle, flip);
                MultimediaDebug.AssertNoError(ret);
            }
        }

        private Lazy<IMediaBuffer> _buffer;

        /// <summary>
        /// Gets the buffer of the packet.
        /// </summary>
        /// <value>
        /// The <see cref="IMediaBuffer"/> allocated to the packet.
        /// This property will return null if the packet is in the raw video format.
        /// </value>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <seealso cref="IsEncoded"/>
        /// <seealso cref="VideoPlanes"/>
        /// <since_tizen> 3 </since_tizen>
        public IMediaBuffer Buffer
        {
            get
            {
                ValidateNotDisposed();

                if (IsVideoPlaneSupported)
                {
                    return null;
                }

                return _buffer.Value;
            }
        }

        /// <summary>
        /// Gets or sets a length of data written in the <see cref="Buffer"/>.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The value specified for this property is less than zero or greater than the length of the <see cref="Buffer"/>.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket has <see cref="VideoPlanes"/> instead of <see cref="Buffer"/>.<br/>
        ///     -or-<br/>
        ///     The MediaPacket is not in the writable state, which means it is being used by another module.
        ///     </exception>
        /// <since_tizen> 3 </since_tizen>
        public int BufferWrittenLength
        {
            get
            {
                ValidateNotDisposed();

                int ret = Native.GetBufferSize(_handle, out var value);
                MultimediaDebug.AssertNoError(ret);

                Debug.Assert(value < int.MaxValue);

                return (int)value;
            }
            set
            {
                ValidateNotDisposed();
                ValidateNotLocked();

                if (IsVideoPlaneSupported)
                {
                    throw new InvalidOperationException(
                        "This packet uses VideoPlanes instead of Buffer.");
                }

                Debug.Assert(Buffer != null);

                if (value < 0 || value >= Buffer.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "value must be less than Buffer.Size.");
                }

                int ret = Native.SetBufferSize(_handle, (ulong)value);
                MultimediaDebug.AssertNoError(ret);
            }
        }

        private MediaPacketVideoPlane[] _videoPlanes;

        /// <summary>
        /// Gets the video planes of the packet.
        /// </summary>
        /// <value>The <see cref="MediaPacketVideoPlane"/>s allocated to the packet.
        ///     This property will return null if the packet is not in the raw video format.</value>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <seealso cref="IsEncoded"/>
        /// <seealso cref="Buffer"/>
        /// <since_tizen> 3 </since_tizen>
        public MediaPacketVideoPlane[] VideoPlanes
        {
            get
            {
                ValidateNotDisposed();

                if (!IsVideoPlaneSupported)
                {
                    return null;
                }

                if (_videoPlanes == null)
                {
                    _videoPlanes = GetVideoPlanes();
                }

                return _videoPlanes;
            }
        }

        /// <summary>
        /// Gets or sets the buffer flags of the packet.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket is not in the writable state, which means it is being used by another module.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public MediaPacketBufferFlags BufferFlags
        {
            get
            {
                ValidateNotDisposed();

                int ret = Native.GetBufferFlags(_handle, out var value);

                MultimediaDebug.AssertNoError(ret);

                return value;
            }

            set
            {
                ValidateNotDisposed();
                ValidateNotLocked();

                int ret = Native.ResetBufferFlags(_handle);

                MultimediaDebug.AssertNoError(ret);

                ret = Native.SetBufferFlags(_handle, (int)value);

                MultimediaDebug.AssertNoError(ret);
            }
        }

        #region Dispose support
        /// <summary>
        /// Gets a value indicating whether the packet has been disposed of.
        /// </summary>
        /// <value>true if the packet has been disposed of; otherwise, false.</value>
        /// <since_tizen> 3 </since_tizen>
        public bool IsDisposed => _isDisposed;

        private bool _isDisposed = false;

        /// <summary>
        /// Releases all resources used by the <see cref="MediaPacket"/> object.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket can not be disposed, which means it is being used by another module.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            ValidateNotLocked();

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="MediaPacket"/> object.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (_handle != IntPtr.Zero)
            {
                Native.Destroy(_handle);
                _handle = IntPtr.Zero;
            }

            _isDisposed = true;
        }

        /// <summary>
        /// Validates the current object has not been disposed of.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        private void ValidateNotDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("This packet has already been disposed of.");
            }
        }
        #endregion

        internal IntPtr GetHandle()
        {
            ValidateNotDisposed();

            Debug.Assert(_handle != IntPtr.Zero, "The handle is invalid!");

            return _handle;
        }

        /// <summary>
        /// Ensures whether the packet is writable.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The MediaPacket is being used by another module.</exception>
        internal void EnsureWritableState()
        {
            ValidateNotDisposed();
            ValidateNotLocked();
        }

        /// <summary>
        /// Ensures whether the packet is readable.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        internal void EnsureReadableState()
        {
            ValidateNotDisposed();
        }

        /// <summary>
        /// Gets a value indicating whether the packet is in the raw video format.
        /// </summary>
        /// <value>true if the packet is in the raw video format; otherwise, false.</value>
        private bool IsVideoPlaneSupported => !IsEncoded && Format.Type == MediaFormatType.Video;

        /// <summary>
        /// Retrieves video planes of the current packet.
        /// </summary>
        /// <returns>The <see cref="MediaPacketVideoPlane"/>s allocated to the current MediaPacket.</returns>
        private MediaPacketVideoPlane[] GetVideoPlanes()
        {
            Debug.Assert(_handle != IntPtr.Zero, "The handle is invalid!");

            int ret = Native.GetNumberOfVideoPlanes(_handle, out var numberOfPlanes);

            MultimediaDebug.AssertNoError(ret);

            MediaPacketVideoPlane[] planes = new MediaPacketVideoPlane[numberOfPlanes];

            for (int i = 0; i < numberOfPlanes; ++i)
            {
                planes[i] = new MediaPacketVideoPlane(this, i);
            }

            return planes;
        }

        /// <summary>
        /// Retrieves the buffer of the current packet.
        /// </summary>
        /// <returns>The <see cref="IMediaBuffer"/> allocated to the current MediaPacket.</returns>
        private IMediaBuffer GetBuffer()
        {
            Debug.Assert(!IsDisposed, "Packet is already disposed!");

            Debug.Assert(_handle != IntPtr.Zero, "The handle is invalid!");

            int ret = Native.GetBufferData(_handle, out var dataHandle);
            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(dataHandle != IntPtr.Zero, "Data handle is invalid!");

            ret = Native.GetAllocatedBufferSize(_handle, out var size);
            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(size >= 0, "size must not be negative!");

            return new DependentMediaBuffer(this, dataHandle, size);
        }

        /// <summary>
        /// Creates an object of the MediaPacket with the specified <see cref="MediaFormat"/>.
        /// </summary>
        /// <param name="format">The media format for the new packet.</param>
        /// <returns>A new MediaPacket object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static MediaPacket Create(MediaFormat format)
        {
            return new SimpleMediaPacket(format);
        }

        /// <summary>
        /// Creates an object of the MediaPacket with the specified <see cref="MediaFormat"/>.
        /// </summary>
        /// <param name="format">The media format for the new packet.</param>
        /// <param name="handle">The native tbm handle to be used.</param>
        /// <returns>A new MediaPacket object.</returns>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaPacket Create(MediaFormat format, IntPtr handle)
        {
            return new SimpleMediaPacket(format, handle);
        }

        internal static MediaPacket From(IntPtr handle)
        {
            return new SimpleMediaPacket(handle);
        }

        bool IBufferOwner.IsDisposed => IsDisposed;

        bool IBufferOwner.IsBufferAccessible(object buffer, MediaBufferAccessMode accessMode) => true;
    }

    internal class SimpleMediaPacket : MediaPacket
    {
        internal SimpleMediaPacket(MediaFormat format) : base(format)
        {
        }

        internal SimpleMediaPacket(MediaFormat format, IntPtr handle) : base(format, handle)
        {
        }

        internal SimpleMediaPacket(IntPtr handle) : base(handle)
        {
        }
    }
}
