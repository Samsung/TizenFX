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


internal static partial class Interop
{
    private const string LogTag = "Tizen.Maps";

    public delegate ErrorCode GetterMethod<T>(out T value);
    public delegate ErrorCode GetterPtrMethod(out IntPtr value);
    public delegate ErrorCode SetterMethod<T>(T value);

    internal static T NativeGet<T>(GetterMethod<T> getter, [CallerMemberName] string propertyName = "")
    {
        T value;
        var err = getter(out value);
        if (err.IsSuccess())
        {
            return value;
        }

        //err.WarnIfFailed($"Native getter for {propertyName} failed");
        return default(T);
    }

    internal static T NativeGet<T>(GetterMethod<IntPtr> getter, Func<IntPtr, T> ctor, [CallerMemberName] string propertyName = "") where T : SafeMapsHandle
    {
        return ctor(NativeGet(getter, propertyName));
    }

    internal static T NativeGet<T>(GetterMethod<IntPtr> getter, Func<IntPtr, bool, T> ctor, bool hasOwnership, [CallerMemberName] string propertyName = "") where T : SafeMapsHandle
    {
        return ctor(NativeGet(getter, propertyName), hasOwnership);
    }

    internal static string NativeGet(GetterMethod<string> getter, [CallerMemberName] string propertyName = "")
    {
        string value;
        var err = getter(out value);
        if (err.IsSuccess())
        {
            return value;
        }

        //err.WarnIfFailed($"Native getter for {propertyName} failed");
        return string.Empty;
    }

    internal static void NativeSet<T>(SetterMethod<T> setter, T value, [CallerMemberName] string propertyName = "")
    {
        setter(value).WarnIfFailed($"Native setter for {propertyName} failed");
    }

    internal abstract class SafeMapsHandle : SafeHandle
    {
        protected delegate ErrorCode DestroyNativeHandleMethod(IntPtr handle);
        protected DestroyNativeHandleMethod DestroyHandle;

        protected SafeMapsHandle(IntPtr handle, bool needToRelease, DestroyNativeHandleMethod destroy) : base(handle, true)
        {
            HasOwnership = needToRelease;
            DestroyHandle = destroy;
        }

        internal bool HasOwnership { get; set; }

        public override bool IsInvalid { get { return handle == IntPtr.Zero; } }

        protected override bool ReleaseHandle()
        {
            if (HasOwnership)
            {
                var err = DestroyHandle(handle);
                err.WarnIfFailed($"Failed to delete native {GetType()} handle");
            }

            SetHandle(IntPtr.Zero);
            return true;
        }

        public static implicit operator IntPtr(SafeMapsHandle otherHandle)
        {
            return otherHandle.handle;
        }
    }
}
