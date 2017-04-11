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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Badge
    {
        internal enum ErrorCode : int
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            FromDb = -0x01120000 | 0x01,
            AlreadyExist = -0x01120000 | 0x02,
            FromDbus = -0x01120000 | 0x03,
            NotExist = -0x01120000 | 0x04,
            ServiceNotReady = -0x01120000 | 0x05,
            InvalidPackage = -0x01120000 | 0x06
        }

        internal enum Action : uint
        {
            Create = 0,
            Remove,
            Update,
            ChangedDisplay,
            ServiceReady
        }

        internal delegate void ForeachCallback(string appId, uint count, IntPtr userData);

        internal delegate void ChangedCallback(Action action, string appId, uint count, IntPtr userData);

        [DllImport(Libraries.Badge, EntryPoint = "badge_add")]
        internal static extern ErrorCode Add(string appId);

        [DllImport(Libraries.Badge, EntryPoint = "badge_remove")]
        internal static extern ErrorCode Remove(string appId);

        [DllImport(Libraries.Badge, EntryPoint = "badge_set_count")]
        internal static extern ErrorCode SetCount(string appId, uint count);

        [DllImport(Libraries.Badge, EntryPoint = "badge_get_count")]
        internal static extern ErrorCode GetCount(string appId, out uint count);

        [DllImport(Libraries.Badge, EntryPoint = "badge_set_display")]
        internal static extern ErrorCode SetDisplay(string appId, uint isDisplay);

        [DllImport(Libraries.Badge, EntryPoint = "badge_get_display")]
        internal static extern ErrorCode GetDisplay(string appId, out uint isDisplay);

        [DllImport(Libraries.Badge, EntryPoint = "badge_foreach")]
        internal static extern ErrorCode Foreach(ForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.Badge, EntryPoint = "badge_register_changed_cb")]
        internal static extern ErrorCode SetChangedCallback(ChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Badge, EntryPoint = "badge_unregister_changed_cb")]
        internal static extern ErrorCode UnsetChangedCallback(ChangedCallback callback);
    }
}
