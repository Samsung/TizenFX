/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd. All rights reserved.
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

using Tizen.Applications.Shortcut;

internal static partial class Interop
{
    internal static partial class Shortcut
    {
        internal delegate int AddCallback(string appId, string shortcutName, int type, string contentInfo, string iconPath, int processId, double period, bool isAllowDuplicate, IntPtr data);

        internal delegate int DeleteCallback(string appId, string shortcutName, int processId, IntPtr data);

        internal delegate int ResultCallback(int ret, IntPtr data);

        internal delegate int ListCallback(string package_name, string icon, string name, string extra_key, string extra_data, IntPtr user_data);

        /// <summary>
        /// Enumeration for the values of the shortcut response types.
        /// </summary>
        internal enum ErrorCode : int
        {
            /// <summary>
            /// Successful.
            /// </summary>
            None = Tizen.Internals.Errors.ErrorCode.None,

            /// <summary>
            /// Invalid function parameter.
            /// </summary>
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,

            /// <summary>
            /// Out of memory.
            /// </summary>
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,

            /// <summary>
            /// Permission denied.
            /// </summary>
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,

            /// <summary>
            /// I/O Error.
            /// </summary>
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,

            /// <summary>
            /// Not supported.
            /// </summary>
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,

            /// <summary>
            /// Device or resource busy.
            /// </summary>
            ResourceBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,

            /// <summary>
            /// There is no space to add a new shortcut.
            /// </summary>
            NoSpace = -0x01160000 | 0x01,

            /// <summary>
            /// Shortcut is already added.
            /// </summary>
            Exist = -0x01160000 | 0x02,

            /// <summary>
            /// Unrecoverable error.
            /// </summary>
            Fault = -0x01160000 | 0x04,

            /// <summary>
            /// Shortcut does not exist.
            /// </summary>
            NotExist = -0x01160000 | 0x08,

            /// <summary>
            /// Connection not established or communication problem.
            /// </summary>
            COMM = -0x01160000 | 0x40
        }

        [DllImport(Libraries.Shortcut, EntryPoint = "shortcut_add_to_home_sync")]
        internal static extern ErrorCode AddToHome(string name, int type, string uri, string icon, int dubplicate);

        [DllImport(Libraries.Shortcut, EntryPoint = "shortcut_add_to_home_widget_sync")]
        internal static extern ErrorCode AddToWidget(string name, ShortcutWidgetSize size,  string widgetId, string icon, double period, int dubplicate);

        [DllImport(Libraries.Shortcut, EntryPoint = "shortcut_remove_from_home_sync")]
        internal static extern ErrorCode Delete(string name);

        [DllImport(Libraries.Shortcut, EntryPoint = "shortcut_get_list")]
        internal static extern ErrorCode GetList(string name, ListCallback list, IntPtr data);

        [DllImport(Libraries.Shortcut, EntryPoint = "shortcut_set_request_cb")]
        internal static extern ErrorCode SetShortcutAddCallback(AddCallback cb, IntPtr data);

        [DllImport(Libraries.Shortcut, EntryPoint = "shortcut_unset_request_cb")]
        internal static extern ErrorCode UnsetShortcutAddCallback();

        [DllImport(Libraries.Shortcut, EntryPoint = "shortcut_set_remove_cb")]
        internal static extern ErrorCode SetShortcutDeleteCallback(DeleteCallback cb, IntPtr data);

        [DllImport(Libraries.Shortcut, EntryPoint = "shortcut_unset_remove_cb")]
        internal static extern ErrorCode UnsetShortcutDeleteCallback();
    }
}
