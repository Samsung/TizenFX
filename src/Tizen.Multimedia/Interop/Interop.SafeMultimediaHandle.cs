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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

internal static partial class Interop
{
    internal static Task<T> PinnedTask<T>(TaskCompletionSource<T> tcs)
    {
        var gch = GCHandle.Alloc(tcs);
        return tcs.Task.ContinueWith(
            t => { gch.Free(); return t; },
            TaskContinuationOptions.ExecuteSynchronously).Unwrap();
    }

    internal abstract class SafeMultimediaHandle : SafeHandle
    {
        internal delegate ErrorCode GetterMethod<TProp>(out TProp value);
        internal delegate ErrorCode SetterMethod<TProp>(TProp value);

        protected SafeMultimediaHandle(IntPtr handle, bool needToRelease) : base(handle, true)
        {
            Debug.Assert(handle != IntPtr.Zero);
            HasOwnership = needToRelease;
        }

        internal bool HasOwnership { get; set; }
        public override bool IsInvalid { get { return handle == IntPtr.Zero; } }

        internal abstract ErrorCode DisposeNativeHandle();

        internal TProp NativeGet<TProp>(GetterMethod<TProp> getter, [CallerMemberName] string propertyName = "")
        {
            TProp value; getter(out value).ThrowIfFailed($"Failed to get {propertyName}");
            return value;
        }

        internal string NativeGet(GetterMethod<string> getter, [CallerMemberName] string propertyName = "")
        {
            string value; getter(out value).ThrowIfFailed($"Failed to get {propertyName}");
            return value;
        }

        internal void NativeSet<TProp>(SetterMethod<TProp> setter, TProp value, [CallerMemberName] string propertyName = "")
        {
            setter(value).ThrowIfFailed($"Failed to set {propertyName}");
        }

        protected override bool ReleaseHandle()
        {
            var err = ErrorCode.None;
            if (HasOwnership)
            {
                err = DisposeNativeHandle();
                err.WarnIfFailed($"Failed to delete native {GetType()} handle");
            }

            SetHandle(IntPtr.Zero);
            return err.IsSuccess();
        }
    }
}
