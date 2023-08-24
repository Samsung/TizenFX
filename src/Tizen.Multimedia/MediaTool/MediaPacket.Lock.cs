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
using Native = Tizen.Multimedia.Interop.MediaPacket;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a packet for multimedia.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract partial class MediaPacket : IDisposable
    {
        private readonly LockState _lock = new LockState();

        /// <summary>
        /// Validates the current object is not locked.
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

            internal bool IsLocked => Interlocked.CompareExchange(ref _locked, 0, 0) == LOCKED;
        }

        /// <summary>
        /// Provides a thread-safe lock controller.
        /// </summary>
        /// <example>
        /// using (var lock = BaseMediaPacket.Lock(mediaPacket))
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

                lock (packet._lock)
                {
                    Lock lck = FromHandle(packet._handle) ?? new Lock(packet);

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
                int ret = Native.SetExtra(_packet._handle, ptr);

                MultimediaDebug.AssertNoError(ret);
            }

            private static IntPtr GetExtra(IntPtr handle)
            {
                int ret = Native.GetExtra(handle, out var value);

                MultimediaDebug.AssertNoError(ret);

                return value;
            }

            internal IntPtr GetHandle() => _packet.GetHandle();

            internal MediaPacket MediaPacket => _packet;

            private bool _isDisposed = false;

            public void Dispose()
            {
                if (!_isDisposed)
                {
                    lock (_packet._lock)
                    {
                        _lockCount--;

                        if (_lockCount == 0)
                        {
                            SetExtra(IntPtr.Zero);

                            if (_gcHandle.IsAllocated)
                            {
                                _gcHandle.Free();
                            }

                            // We can assure that at this point '_packet' is always locked by this lock.
                            _packet._lock.SetUnlock();
                        }
                    }

                    _isDisposed = true;
                }
            }
        }
    }
}
