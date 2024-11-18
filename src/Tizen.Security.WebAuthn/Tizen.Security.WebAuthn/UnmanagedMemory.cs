/*
 *  Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Runtime.InteropServices;

namespace Tizen.Security.WebAuthn
{
    internal class UnmanagedMemory : IDisposable
    {
        private bool _disposed = false;
        IntPtr _memory = IntPtr.Zero;

        public UnmanagedMemory()
        {}

        public UnmanagedMemory(object obj)
        {
            _memory = Marshal.AllocHGlobal(Marshal.SizeOf(obj));
            Marshal.StructureToPtr(obj, _memory, false);
        }


        public UnmanagedMemory(string obj)
        {
            _memory = Marshal.StringToHGlobalAnsi(obj);
        }

        unsafe private UnmanagedMemory(IntPtr pinned, int size)
        {
            _memory = Marshal.AllocHGlobal(size);
            Buffer.MemoryCopy((void*)pinned, (void*)_memory, size, size);
        }

        ~UnmanagedMemory()
        {
            Dispose(false);
        }

        public static UnmanagedMemory PinArray<T>(T[] array) where T : struct
        {
            if (array is null)
                return new UnmanagedMemory();

            GCHandle pinnedArray = GCHandle.Alloc(array, GCHandleType.Pinned);
            var ret = new UnmanagedMemory(pinnedArray.AddrOfPinnedObject(), Marshal.SizeOf(array[0]) * array.Length);
            pinnedArray.Free();
            return ret;
        }

        public static implicit operator IntPtr(UnmanagedMemory pinned)
        {
            return pinned._memory;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (_memory != IntPtr.Zero)
                Marshal.FreeHGlobal(_memory);

            _memory = IntPtr.Zero;
            _disposed = true;
        }
    }
}
