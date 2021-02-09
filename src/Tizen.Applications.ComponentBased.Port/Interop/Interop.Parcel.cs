/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;
using Tizen.Internals;
using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class Parcel
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            IllegalByteSeq = Tizen.Internals.Errors.ErrorCode.IllegalByteSeq,
            NoData = Tizen.Internals.Errors.ErrorCode.NoData,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        }

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_create")]
        internal static extern ErrorCode Create(out SafeParcelHandle handle);
        // int parcel_create(parcel_h *parcel);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_destroy")]
        internal static extern ErrorCode DangerousDestroy(IntPtr handle);
        // int parcel_destroy(parcel_h parcel);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_get_raw")]
        internal static extern ErrorCode GetRaw(SafeParcelHandle handle, out IntPtr raw, out UInt32 size);
        // int parcel_get_raw(parcel_h parcel, void **raw, uint32_t *size);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_reset")]
        internal static extern ErrorCode Reset(SafeParcelHandle handle, byte[] buf, UInt32 size);
        // int parcel_reset(parcel_h parcel, const void *buf, uint32_t size);
    }
}