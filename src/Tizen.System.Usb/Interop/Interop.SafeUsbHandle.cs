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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

internal static partial class Interop
{
    public delegate ErrorCode GetterMethod<T>(out T value);
    public delegate ErrorCode GetterPtrMethod(out IntPtr value);
    public delegate ErrorCode GetDescriptorString(ref int length, byte[] data);
    public delegate ErrorCode SetterMethod<T>(T value);

    internal static T NativeGet<T>(GetterMethod<T> getter, [CallerMemberName] string propertyName = "")
    {
        T value;
        var err = getter(out value);
        if (err.IsSuccess())
        {
            return value;
        }

        err.ThrowIfFailed($"Native getter for {propertyName} failed");
        return default(T);
    }

    internal static string DescriptorString(GetDescriptorString getter, string language = "us-ascii", [CallerMemberName] string propertyName = "")
    {
        int len = MaxStringDescriptorSize;
        byte[] data = new byte[len];
        getter(ref len, data).ThrowIfFailed($"Native setter for {propertyName} failed");
        return Encoding.GetEncoding(language).GetString(data, 0, len);
    }

    internal static void NativeSet<T>(SetterMethod<T> setter, T value, [CallerMemberName] string propertyName = "")
    {
        setter(value).ThrowIfFailed($"Native setter for {propertyName} failed");
    }

    internal abstract class SafeUsbHandle : SafeHandle
    {
        public abstract void Destroy();
        public SafeUsbHandle() : base(IntPtr.Zero, true) { }
        public SafeUsbHandle(IntPtr handle) : base(handle, true) { }
        public override bool IsInvalid { get { return handle == IntPtr.Zero; } }
        protected override bool ReleaseHandle()
        {
            Destroy();
            SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
