/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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

using Tizen.NUI;
using Tizen.Applications;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class FrameProvider
        {
            internal enum ErrorCode
            {
                None = Tizen.Internals.Errors.ErrorCode.None,
                InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
                InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
                IoError = Tizen.Internals.Errors.ErrorCode.IoError,
                OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            }

            internal delegate void ShowCallback(IntPtr handle, IntPtr userData);

            internal delegate void HideCallback(IntPtr handle, IntPtr userData);

            [StructLayout(LayoutKind.Sequential)]
            internal struct FrameProviderEventCallbacks
            {
                public ShowCallback OnShow;
                public HideCallback OnHide;
            }

            [DllImport(Libraries.FrameProvider, EntryPoint = "frame_provider_create")]
            internal static extern ErrorCode Create(IntPtr wl2Win, ref FrameProviderEventCallbacks callbacks, IntPtr userData, out SafeFrameProviderHandle handle);

            [DllImport(Libraries.FrameProvider, EntryPoint = "frame_provider_destroy")]
            internal static extern ErrorCode DangerousDestroy(IntPtr handle);

            [DllImport(Libraries.FrameProvider, EntryPoint = "frame_provider_notify_show_status")]
            internal static extern ErrorCode NotifyShowStatus(SafeFrameProviderHandle handle, SafeBundleHandle safeBundleHandle);

            [DllImport(Libraries.FrameProvider, EntryPoint = "frame_provider_notify_hide_status")]
            internal static extern ErrorCode NotifyHideStatus(SafeFrameProviderHandle handle, SafeBundleHandle safeBundleHandle);
        }
    }
}
