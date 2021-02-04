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

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_clone")]
        internal static extern ErrorCode DangerousClone(IntPtr handle, out SafeParcelHandle clone);
        // int parcel_clone(parcel_h parcel, parcel_h *clone);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_burst_write")]
        internal static extern ErrorCode BurstWrite(SafeParcelHandle handle, byte[] buf, UInt32 size);
        // int parcel_burst_write(parcel_h parcel, cont void *buf, uint32_t size);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_burst_read")]
        internal static extern ErrorCode BurstRead(SafeParcelHandle handle, [In, Out] byte[] buf, UInt32 size);
        // int parcel_burst_read(parcel_h parcel, void *buf, uint32_t size);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_bool")]
        internal static extern ErrorCode WriteBool(SafeParcelHandle handle, bool val);
        // int parcel_write_bool(parcel_h parcel, bool val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_byte")]
        internal static extern ErrorCode WriteByte(SafeParcelHandle handle, byte val);
        // int parcel_write_byte(parcel_h parcel, char val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_uint16")]
        internal static extern ErrorCode WriteUInt16(SafeParcelHandle handle, UInt16 val);
        // int parcel_write_uint16(parcel_h parcel, uint16_t val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_uint32")]
        internal static extern ErrorCode WriteUInt32(SafeParcelHandle handle, UInt32 val);
        // int parcel_write_uint32(parcel_h parcel, uint32_t val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_uint64")]
        internal static extern ErrorCode WriteUInt64(SafeParcelHandle handle, UInt64 val);
        // int parcel_write_uint64(parcel_h parcel, uint64_t val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_int16")]
        internal static extern ErrorCode WriteInt16(SafeParcelHandle handle, Int16 val);
        // int parcel_write_int16(parcel_h parcel, int16_t val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_int32")]
        internal static extern ErrorCode WriteInt32(SafeParcelHandle handle, Int32 val);
        // int parcel_write_int32(parcel_h parcel, int32_t val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_int64")]
        internal static extern ErrorCode WriteInt64(SafeParcelHandle handle, Int64 val);
        // int parcel_write_int64(parcel_h parcel, int64_t val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_float")]
        internal static extern ErrorCode WriteFloat(SafeParcelHandle handle, float val);
        // int parcel_write_float(parcel_h parcel, float val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_double")]
        internal static extern ErrorCode WriteDouble(SafeParcelHandle handle, double val);
        // int parcel_write_double(parcel_h parcel, double val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_string")]
        internal static extern ErrorCode WriteString(SafeParcelHandle handle, string str);
        // int parcel_write_string(parcel_h parcel, const char *str);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_write_bundle")]
        internal static extern ErrorCode WriteBundle(SafeParcelHandle handle, IntPtr b);
        // int parcel_write_bundle(parcel_h parcel, bundle *b);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_bool")]
        internal static extern ErrorCode ReadBool(SafeParcelHandle handle, out bool val);
        // int parcel_read_bool(parcel_h parcel, bool *val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_byte")]
        internal static extern ErrorCode ReadByte(SafeParcelHandle handle, out byte val);
        // int parcel_read_byte(parcel_h parcel, char *val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_uint16")]
        internal static extern ErrorCode ReadUInt16(SafeParcelHandle handle, out UInt16 val);
        // int parcel_read_uint16(parcel_h parcel, uint16_t *val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_uint32")]
        internal static extern ErrorCode ReadUInt32(SafeParcelHandle handle, out UInt32 val);
        // int parcel_read_uint32(parcel_h parcel, uint32_t *val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_uint64")]
        internal static extern ErrorCode ReadUInt64(SafeParcelHandle handle, out UInt64 val);
        // int parcel_read_uint64(parcel_h parcel, uint64_t *val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_int16")]
        internal static extern ErrorCode ReadInt16(SafeParcelHandle handle, out Int16 val);
        // int parcel_read_int16(parcel_h parcel, int16_t *val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_int32")]
        internal static extern ErrorCode ReadInt32(SafeParcelHandle handle, out Int32 val);
        // int parcel_read_int32(parcel_h parcel, int32_t *val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_int64")]
        internal static extern ErrorCode ReadInt64(SafeParcelHandle handle, out Int64 val);
        // int parcel_read_int64(parcel_h parcel, int64_t *val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_float")]
        internal static extern ErrorCode ReadFloat(SafeParcelHandle handle, out float val);
        // int parcel_read_float(parcel_h parcel, float *val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_double")]
        internal static extern ErrorCode ReadDouble(SafeParcelHandle handle, out double val);
        // int parcel_read_double(parcel_h parcel, double *val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_string")]
        internal static extern ErrorCode ReadString(SafeParcelHandle handle, out string val);
        // int parcel_read_string(parcel_h parcel, char **val);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_read_bundle")]
        internal static extern ErrorCode ReadBundle(SafeParcelHandle handle, out IntPtr b);
        // int parcel_read_bundle(parcel_h parcel, bundle **b);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_get_raw")]
        internal static extern ErrorCode GetRaw(SafeParcelHandle handle, out IntPtr raw, out UInt32 size);
        // int parcel_get_raw(parcel_h parcel, void **raw, uint32_t *size);

        [DllImport(Libraries.Parcel, EntryPoint = "parcel_reset")]
        internal static extern ErrorCode Reset(SafeParcelHandle handle, byte[] buf, UInt32 size);
        // int parcel_reset(parcel_h parcel, const void *buf, uint32_t size);
    }
}