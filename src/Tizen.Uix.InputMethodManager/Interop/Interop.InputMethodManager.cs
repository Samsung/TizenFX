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

/// <summary>
/// Partial interop class.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// InputMethodManager interop class.
    /// </summary>
    internal static class InputMethodManager
    {
        internal static string LogTag = "Tizen.Uix.InputMethodManager";

        private const int ErrorInputMethodManager = -0x02F20000;

        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            OperationFailed = ErrorInputMethodManager | 0x0010,
        };

        [DllImport(Libraries.InputMethodManager, EntryPoint = "ime_manager_show_ime_list")]
        internal static extern ErrorCode ImeManagerShowImeList();

        [DllImport(Libraries.InputMethodManager, EntryPoint = "ime_manager_show_ime_selector")]
        internal static extern ErrorCode ImeManagerShowImeSelector();

        [DllImport(Libraries.InputMethodManager, EntryPoint = "ime_manager_is_ime_enabled")]
        internal static extern ErrorCode ImeManagerIsImeEnabled(string appId, out bool isEnabled);

        [DllImport(Libraries.InputMethodManager, EntryPoint = "ime_manager_get_active_ime")]
        internal static extern ErrorCode ImeManagerGetActiveIme(out string app_id);

        [DllImport(Libraries.InputMethodManager, EntryPoint = "ime_manager_get_enabled_ime_count")]
        internal static extern int ImeManagerGetEnabledImeCount();

        [DllImport(Libraries.InputMethodManager, EntryPoint = "ime_manager_prelaunch_ime")]
        internal static extern ErrorCode ImeManagerPrelaunchIme();
    }
}
