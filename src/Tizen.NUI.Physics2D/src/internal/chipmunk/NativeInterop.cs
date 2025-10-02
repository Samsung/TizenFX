/*
 * Copyright (c) 2023 Codefoco (codefoco@codefoco.com)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    internal static class NativeInterop
    {
        public static IntPtr RegisterHandle(object obj)
        {
            var gcHandle = GCHandle.Alloc(obj);
            return GCHandle.ToIntPtr(gcHandle);
        }

        public static T FromIntPtr<T>(IntPtr pointer)
        {
            Debug.Assert(pointer != IntPtr.Zero, "IntPtr parameter should never be Zero");

            var handle = GCHandle.FromIntPtr(pointer);

            Debug.Assert(handle.IsAllocated, "GCHandle not allocated.");
            Debug.Assert(handle.Target is T, "Target is not of type T.");

            return (T)handle.Target;
        }

        public static void ReleaseHandle(IntPtr pointer)
        {
            Debug.Assert(pointer != IntPtr.Zero, "IntPtr parameter should never be Zero");

            var handle = GCHandle.FromIntPtr(pointer);

            Debug.Assert(handle.IsAllocated, "GCHandle not allocated.");

            handle.Free();
        }

        public static T FromIntPtrAndFree<T>(IntPtr pointer)
        {
            Debug.Assert(pointer != IntPtr.Zero, "IntPtr parameter should never be Zero");

            var handle = GCHandle.FromIntPtr(pointer);

            Debug.Assert(handle.IsAllocated, "GCHandle not allocated.");
            Debug.Assert(handle.Target is T, "Target is not of type T.");
            T obj = (T)handle.Target;

            handle.Free();

            return obj;
        }

        public static int SizeOf<T>()
        {
            return Marshal.SizeOf<T>();
        }

        public static IntPtr AllocStructure<T>()
        {
            int size = SizeOf<T>();

            Debug.Assert(size>0, "The memory size to be allocated should be greater than 0");

            return Marshal.AllocHGlobal(size);
        }

        public static void FreeStructure(IntPtr ptr)
        {
            Marshal.FreeHGlobal(ptr);
        }

        public static T PtrToStructure<T>(IntPtr intPtr)
        {
            return Marshal.PtrToStructure<T>(intPtr);
        }

        public static T[] PtrToStructureArray<T>(IntPtr intPtr, int count)
        {
            var items = new T[count];
            var size = SizeOf<T>();

            for (var i = 0; i < count; i++)
            {
                var newPtr = new IntPtr(intPtr.ToInt64() + (i * size));
                items[i] = PtrToStructure<T>(newPtr);
            }

            return items;
        }

        internal static IntPtr StructureArrayToPtr<T>(IReadOnlyList<T> items)
        {
            var size = SizeOf<T>();
            int allocBytes = checked(size * items.Count);
            Debug.Assert(allocBytes > 0, "The memory to be allocated should be greater than 0");

            var memory = Marshal.AllocHGlobal(allocBytes);

            for (var i = 0; i < items.Count; i++)
            {
                var ptr = new IntPtr(memory.ToInt64() + (i * size));
                Marshal.StructureToPtr<T>(items[i], ptr, true);
            }

            return memory;
        }
    }
}
