// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
