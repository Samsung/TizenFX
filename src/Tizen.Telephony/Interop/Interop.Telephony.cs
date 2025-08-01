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
using Tizen.Internals;
using Tizen.Telephony;

/// <summary>
/// The Partial Interop class.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// The Telephony Interop class.
    /// Deprecated since API13.
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

#if !PROFILE_TV
    [NativeStruct("telephony_handle_list_s", Include="telephony_common.h", PkgConfig="capi-telephony")]
#endif
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