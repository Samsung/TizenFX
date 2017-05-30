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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a packet for multimedia.
    /// </summary>
    public abstract class MediaPacket : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;

        /// <summary>
        /// Initializes a new instance of the MediaPacket class with the specified media format.
        /// </summary>
        /// <param name="format">The media format containing properties for the packet.</param>
        /// <exception cref="System.ArgumentNullException">format is null.</exception>
        /// <exception cref="System.ArgumentException">
        ///     <see cref="MediaFormatType"/> of the specified format is <see cref="MediaFormatType.Container"/>.</exception>
        /// <exception cref="System.InvalidOperationException">Operation failed.</exception>
        internal MediaPacket(MediaFormat format)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (format.Type == MediaFormatType.Container)
            {
                throw new ArgumentException("Container format can't be used to create a new packet.");
            }

            Initialize(format);
            _format = format;
        }

        /// <summary>
        /// Initializes a new instance of the MediaPacket class from a native handle.
        /// </summary>
        /// <param name="handle">The native handle to be used.</param>
        internal MediaPacket(IntPtr handle)
        {
            _handle = handle;

            IntPtr formatHandle;
            int ret = Interop.MediaPacket.GetFormat(handle, out formatHandle);

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
                Interop.MediaFormat.Unref(formatHandle);
            }
        }

        ~MediaPacket()
        {
            Dispose(false);
        }

        /// <summary>
        /// Creates and initializes a native handle for the current object.
        /// </summary>
        /// <param name="format">The format to be set to the media format.</param>
        /// <exception cref="System.InvalidOperationException">Operation failed.</exception>
        private void Initialize(MediaFormat format)
        {
            if (format.Type == MediaFormatType.Container)
            {
                throw new ArgumentException("Creating a packet for container is not supported.");
            }

            IntPtr formatHandle = IntPtr.Zero;

            try
            {
                formatHandle = format.AsNativeHandle();

                int ret = Interop.MediaPacket.Create(formatHandle, IntPtr.Zero, IntPtr.Zero, out _handle);
                MultimediaDebug.AssertNoError(ret);

                Debug.Assert(_handle != IntPtr.Zero, "Created handle must not be null");

                Alloc();
            }
            catch (Exception)
            {
                if (_handle != IntPtr.Zero)
                {
                    Interop.MediaPacket.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                throw;
            }
            finally
            {
                if (formatHandle != IntPtr.Zero)
                {
                    Interop.MediaFormat.Unref(formatHandle);
                }
            }
        }

        /// <summary>
        /// Allocates internal buffer.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Operation failed.</exception>
        private void Alloc()
        {
            ErrorCode ret = (ErrorCode)Interop.MediaPacket.Alloc(_handle);
            if (ret == ErrorCode.None)
            {
                return;
            }

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
        public MediaFormat Format
        {
            get
            {
                ValidateNotDisposed();
                return _format;
            }
        }

        /// <summary>
        /// Gets or sets the PTS(Presentation Time Stamp) value of the current packet.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket is not writable state which means it being used by another module.</exception>
        public ulong Pts
        {
            get
            {
                ValidateNotDisposed();

                ulong value = 0;
                int ret = Interop.MediaPacket.GetPts(_handle, out value);

                MultimediaDebug.AssertNoError(ret);

                return value;
            }
            set
            {
                ValidateNotDisposed();
                ValidateNotLocked();

                int ret = Interop.MediaPacket.SetPts(_handle, value);

                MultimediaDebug.AssertNoError(ret);
            }
        }

        /// <summary>
        /// Gets or sets the DTS(Decoding Time Stamp) value of the current packet.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket is not in writable state which means it being used by another module.</exception>
        public ulong Dts
        {
            get
            {
                ValidateNotDisposed();

                ulong value = 0;
                int ret = Interop.MediaPacket.GetDts(_handle, out value);

                MultimediaDebug.AssertNoError(ret);

                return value;
            }
            set
            {
                ValidateNotDisposed();
                ValidateNotLocked();

                int ret = Interop.MediaPacket.SetDts(_handle, value);

                MultimediaDebug.AssertNoError(ret);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the packet is encoded type.
        /// </summary>
        /// <value>true if the packet is encoded type; otherwise, false.</value>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed.</exception>
        public bool IsEncoded
        {
            get
            {
                ValidateNotDisposed();

                bool value = false;
                int ret = Interop.MediaPacket.IsEncoded(_handle, out value);

                MultimediaDebug.AssertNoError(ret);

                return value;
            }
        }

        private MediaPacketBuffer _buffer;

        /// <summary>
        /// Gets the buffer of the packet.
        /// </summary>
        /// <value>The <see cref="MediaPacketBuffer"/> allocated to the packet.
        ///     This property will return null if the packet is raw video format.</value>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed.</exception>
        /// <seealso cref="IsEncoded"/>
        /// <seealso cref="VideoPlanes"/>
        public MediaPacketBuffer Buffer
        {
            get
            {
                ValidateNotDisposed();

                if (IsVideoPlaneSupported)
                {
                    return null;
                }

                if (_buffer == null)
                {
                    _buffer = GetBuffer();
                }

                return _buffer;
            }
        }

        /// <summary>
        /// Gets or sets a length of data written in the <see cref="Buffer"/>.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The value specified for this property is less than zero or greater than <see cref="MediaPacketBuffer.Length"/>.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket has <see cref="VideoPlanes"/> instead of <see cref="Buffer"/>.\n
        ///     -or-\n
        ///     The MediaPacket is not in writable state which means it being used by another module.
        ///     </exception>
        public int BufferWrittenLength
        {
            get
            {
                ValidateNotDisposed();

                ulong value = 0;
                int ret = Interop.MediaPacket.GetBufferSize(_handle, out value);
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
                    throw new ArgumentOutOfRangeException("value must be less than Buffer.Size.");
                }

                int ret = Interop.MediaPacket.SetBufferSize(_handle, (ulong)value);
                MultimediaDebug.AssertNoError(ret);
            }
        }

        private MediaPacketVideoPlane[] _videoPlanes;

        /// <summary>
        /// Gets the video planes of the packet.
        /// </summary>
        /// <value>The <see cref="MediaPacketVideoPlane"/>s allocated to the packet.
        ///     This property will return null if the packet is not raw video format.</value>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed.</exception>
        /// <seealso cref="IsEncoded"/>
        /// <seealso cref="Buffer"/>
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
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket is not in writable state which means it being used by another module.
        ///     </exception>
        public MediaPacketBufferFlags BufferFlags
        {
            get
            {
                ValidateNotDisposed();

                int value = 0;

                int ret = Interop.MediaPacket.GetBufferFlags(_handle, out value);

                MultimediaDebug.AssertNoError(ret);

                return (MediaPacketBufferFlags)value;
            }

            set
            {
                ValidateNotDisposed();
                ValidateNotLocked();

                int ret = Interop.MediaPacket.ResetBufferFlags(_handle);

                MultimediaDebug.AssertNoError(ret);

                ret = Interop.MediaPacket.SetBufferFlags(_handle, (int)value);

                MultimediaDebug.AssertNoError(ret);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the packet has been disposed of.
        /// </summary>
        /// <value>true if the packet has been disposed of; otherwise, false.</value>
        public bool IsDisposed
        {
            get
            {
                return _isDisposed;
            }
        }

        private bool _isDisposed = false;

        /// <summary>
        /// Releases all resources.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     The MediaPacket can not be disposed which means it being used by another module.
        ///     </exception>
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

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (_handle != IntPtr.Zero)
            {
                Interop.MediaPacket.Destroy(_handle);
                _handle = IntPtr.Zero;
            }

            _isDisposed = true;
        }

        internal IntPtr GetHandle()
        {
            ValidateNotDisposed();

            Debug.Assert(_handle != IntPtr.Zero, "The handle is invalid!");

            return _handle;
        }

        /// <summary>
        /// Validate the current object has not been disposed of.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        private void ValidateNotDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("This packet has already been disposed of.");
            }
        }

        /// <summary>
        /// Validate the current object is not locked.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The MediaPacket is in use by another module.</exception>
        private void ValidateNotLocked()
        {
            ValidateNotDisposed();

            if (_lock.IsLocked)
            {
                throw new InvalidOperationException("Can't perform any writing operation." +
                    "The packet is in use, internally.");
            }
        }
        /// <summary>
        /// Ensures whether the packet is writable.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket already has been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The MediaPacket is being used by another module.</exception>
        internal void EnsureWritableState()
        {
            ValidateNotDisposed();
            ValidateNotLocked();
        }

        /// <summary>
        /// Ensures whether the packet is readable.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket already has been disposed of.</exception>
        internal void EnsureReadableState()
        {
            ValidateNotDisposed();
        }

        /// <summary>
        /// Gets a value indicating whether the packet is raw video format.
        /// </summary>
        /// <value>true if the packet is raw video format; otherwise, false.</value>
        private bool IsVideoPlaneSupported
        {
            get
            {
                return !IsEncoded && Format.Type == MediaFormatType.Video;
            }
        }

        /// <summary>
        /// Retrieves video planes of the current packet.
        /// </summary>
        /// <returns>The <see cref="MediaPacketVideoPlane"/>s allocated to the current MediaPacket.</returns>
        private MediaPacketVideoPlane[] GetVideoPlanes()
        {
            Debug.Assert(_handle != IntPtr.Zero, "The handle is invalid!");

            uint numberOfPlanes = 0;
            int ret = Interop.MediaPacket.GetNumberOfVideoPlanes(_handle, out numberOfPlanes);

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
        /// <returns>The <see cref="MediaPacketBuffer"/> allocated to the current MediaPacket.</returns>
        private MediaPacketBuffer GetBuffer()
        {
            Debug.Assert(_handle != IntPtr.Zero, "The handle is invalid!");

            IntPtr dataHandle;

            int ret = Interop.MediaPacket.GetBufferData(_handle, out dataHandle);
            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(dataHandle != IntPtr.Zero, "Data handle is invalid!");

            int size = 0;
            ret = Interop.MediaPacket.GetAllocatedBufferSize(_handle, out size);
            MultimediaDebug.AssertNoError(ret);

            return new MediaPacketBuffer(this, dataHandle, size);
        }

        #region Lock operations
        private readonly LockState _lock = new LockState();

        /// <summary>
        /// Provides a thread-safe lock state controller.
        /// </summary>
        private sealed class LockState
        {
            const int LOCKED = 1;
            const int UNLOCKED = 0;

            private int _locked = UNLOCKED;

            internal void SetLock()
            {
                if (Interlocked.CompareExchange(ref _locked, LOCKED, UNLOCKED) == LOCKED)
                {
                    throw new InvalidOperationException("The packet is already locked.");
                }
            }

            internal void SetUnlock()
            {
                if (Interlocked.CompareExchange(ref _locked, UNLOCKED, LOCKED) == UNLOCKED)
                {
                    Debug.Fail("The packet to unlock is not locked. " +
                        "There must be an error somewhere that a lock isn't disposed correctly.");
                }
            }

            internal bool IsLocked
            {
                get
                {
                    return Interlocked.CompareExchange(ref _locked, 0, 0) == LOCKED;
                }
            }
        }

        /// <summary>
        /// Provides a thread-safe lock controller.
        /// </summary>
        /// <example>
        /// using (var lock = BaseMeadiPacket.Lock(mediaPacket))
        /// {
        ///     ....
        /// }
        /// </example>
        internal sealed class Lock : IDisposable
        {
            private readonly MediaPacket _packet;
            private readonly GCHandle _gcHandle;
            private int _lockCount;

            internal static Lock Get(MediaPacket packet)
            {
                Debug.Assert(packet != null);

                lock (packet)
                {
                    Lock lck = FromHandle(packet._handle);

                    if (lck == null)
                    {
                        lck = new Lock(packet);
                    }

                    lck._lockCount++;

                    return lck;
                }
            }

            private Lock(MediaPacket packet)
            {
                Debug.Assert(packet != null, "The packet is null!");

                packet.ValidateNotDisposed();

                _packet = packet;

                _packet._lock.SetLock();

                _gcHandle = GCHandle.Alloc(this);

                SetExtra(GCHandle.ToIntPtr(_gcHandle));
            }

            internal static Lock FromHandle(IntPtr handle)
            {
                Debug.Assert(handle != IntPtr.Zero);

                IntPtr extra = GetExtra(handle);

                if (extra == IntPtr.Zero)
                {
                    return null;
                }

                return (Lock)GCHandle.FromIntPtr(extra).Target;
            }

            private void SetExtra(IntPtr ptr)
            {
                int ret = Interop.MediaPacket.SetExtra(_packet._handle, ptr);

                MultimediaDebug.AssertNoError(ret);
            }

            private static IntPtr GetExtra(IntPtr handle)
            {
                IntPtr value;

                int ret = Interop.MediaPacket.GetExtra(handle, out value);

                MultimediaDebug.AssertNoError(ret);

                return value;
            }

            internal IntPtr GetHandle()
            {
                return _packet.GetHandle();
            }

            internal MediaPacket MediaPacket
            {
                get
                {
                    return _packet;
                }
            }

            private bool _isDisposed = false;

            public void Dispose()
            {
                if (!_isDisposed)
                {
                    lock (_packet)
                    {
                        _lockCount--;

                        if (_lockCount == 0)
                        {
                            // TODO rollback after the corresponding native api is fixed.
                            //SetExtra(IntPtr.Zero);

                            if (_gcHandle.IsAllocated)
                            {
                                _gcHandle.Free();
                            }

                            //We can assure that at this point '_packet' is always locked by this lock.
                            _packet._lock.SetUnlock();
                        }
                    }

                    _isDisposed = true;
                }
            }
        }
        #endregion

        /// <summary>
        /// Creates an object of the MediaPacekt with the specified <see cref="MediaFormat"/>.
        /// </summary>
        /// <param name="format">The media format for the new packet.</param>
        /// <returns>A new MediaPacket object.</returns>
        public static MediaPacket Create(MediaFormat format)
        {
            return new SimpleMediaPacket(format);
        }

        internal static MediaPacket From(IntPtr handle)
        {
            return new SimpleMediaPacket(handle);
        }
    }

    internal class SimpleMediaPacket : MediaPacket
    {
        internal SimpleMediaPacket(MediaFormat format) : base(format)
        {
        }

        internal SimpleMediaPacket(IntPtr handle) : base(handle)
        {
        }
    }
}
