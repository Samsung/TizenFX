// Copyright 2016 by Samsung Electronics, Inc.
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.
using System;
using System.Runtime.InteropServices;
using Tizen.Telephony;

/// <summary>
/// Partial Interop Class
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Telephony Interop Class
    /// </summary>
    internal static class Telephony
  {
    private const int TIZEN_ERROR_TELEPHONY = -0x02600000;
    internal static string LogTag = "Tizen.Telephony";
    internal enum TelephonyError
    {
      None = Tizen.Internals.Errors.ErrorCode.None,
      OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
      InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
      PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
      NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
      OperationFailed = TIZEN_ERROR_TELEPHONY | 0x0001,
      SIMNotAvailable = TIZEN_ERROR_TELEPHONY | 0x1001
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct HandleList
    {
      internal uint Count;
      internal IntPtr HandleArrayPointer;
    };

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_set_noti_cb")]
    internal static extern TelephonyError TelephonySetNotiCb(IntPtr handle, Tizen.Telephony.ChangeNotificationEventArgs.Notification notiId, NotificationCallback cb, IntPtr userData);

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_unset_noti_cb")]
    internal static extern TelephonyError TelephonyUnsetNotiCb(IntPtr handle, Tizen.Telephony.ChangeNotificationEventArgs.Notification notiId);

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_init")]
    internal static extern TelephonyError TelephonyInit(out HandleList list);

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_deinit")]
    internal static extern TelephonyError TelephonyDeinit(ref HandleList list);

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_get_state")]
    internal static extern TelephonyError TelephonyGetState(out State state);

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_set_state_changed_cb")]
    internal static extern TelephonyError TelephonySetStateChangedCb(StateChangedCallback callback, IntPtr userData);

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_unset_state_changed_cb")]
    internal static extern TelephonyError TelephonyUnsetStateChangedCb(StateChangedCallback callback);

    [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
    internal delegate void NotificationCallback(IntPtr handle, ChangeNotificationEventArgs.Notification notiId, IntPtr data, IntPtr userData);

    [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
    internal delegate void StateChangedCallback(State state, IntPtr userData);
  }
}