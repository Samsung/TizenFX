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
using Tizen.Applications;
using Tizen.NUI;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class FrameBroker
        {
            internal enum ErrorCode
            {
                None = Tizen.Internals.Errors.ErrorCode.None,
                InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
                OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
                AppNotFound = AppControlResult.AppNotFound,
                LaunchRejected = AppControlResult.LaunchRejected,
                IoError = Tizen.Internals.Errors.ErrorCode.IoError,
                PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            }

            internal enum FrameContextErrorCode
            {
                None = 0,
                Disqualified = 1,
                WrongRequest = 2,
            }

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void AppControlResultCallback(IntPtr request, int result, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void AppControlReplyCallback(IntPtr request, IntPtr reply, int result, IntPtr userData);

            internal delegate void FrameContextCreateCallback(IntPtr context, IntPtr userData);

            internal delegate void FrameContextResumeCallback(IntPtr context, IntPtr frame, IntPtr userData);

            internal delegate void FrameContextPauseCallback(IntPtr context, IntPtr userData);

            internal delegate void FrameContextDestroyCallback(IntPtr context, IntPtr userData);

            internal delegate void FrameContextErrorCallback(IntPtr context, int error, IntPtr userData);

            internal delegate void FrameContextUpdateCallback(IntPtr context, IntPtr frame, IntPtr userData);

            [StructLayout(LayoutKind.Sequential)]
            internal struct FrameContextLifecycleCallbacks
            {
                public FrameContextCreateCallback OnCreate;
                public FrameContextResumeCallback OnResume;
                public FrameContextPauseCallback OnPause;
                public FrameContextDestroyCallback OnDestroy;
                public FrameContextUpdateCallback OnUpdate;
                public FrameContextErrorCallback OnError;
            }

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_context_start_animation")]
            internal static extern ErrorCode StartAnimation(IntPtr handle);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_context_finish_animation")]
            internal static extern ErrorCode FinishAnimation(IntPtr handle);


            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_broker_create")]
            internal static extern ErrorCode Create(IntPtr wl2Win, ref FrameContextLifecycleCallbacks callbacks, IntPtr userData, out SafeFrameBrokerHandle handle);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_broker_destroy")]
            internal static extern ErrorCode DangerousDestroy(IntPtr handle);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_broker_send_launch_request")]
            internal static extern ErrorCode SendLaunchRequest(SafeFrameBrokerHandle handle, SafeAppControlHandle safeAppControlHandle, AppControlResultCallback resultCallback, AppControlReplyCallback replyCallback, IntPtr userData);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_broker_send_launch_request_to_provider")]
            internal static extern ErrorCode SendLaunchRequestToProvider(SafeFrameBrokerHandle handle, SafeAppControlHandle safeAppControlHandle, AppControlResultCallback resultCallback, AppControlReplyCallback replyCallback, IntPtr userData);


            internal enum FrameType
            {
                RemoteSurfaceTbmSurface = 0,
                RemoteSurfaceImageFile = 1,
                SplashScreenImage = 2,
                SplashScreenEdje = 3,
            }

            internal enum FrameDirection
            {
                Forward = 0,
                Backward = 1,
            }

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_get_tbm_surface")]
            internal static extern ErrorCode GetTbmSurface(IntPtr handle, out IntPtr tbmSurface);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_get_image_file")]
            internal static extern ErrorCode GetImageFile(IntPtr handle, out Int32 fd, out UInt32 size);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_get_file_path")]
            internal static extern ErrorCode GetFilePath(IntPtr handle, out string filePath);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_get_file_group")]
            internal static extern ErrorCode GetFileGroup(IntPtr handle, out string fileGroup);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_get_type")]
            internal static extern ErrorCode GetType(IntPtr handle, out FrameType type);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_get_direction")]
            internal static extern ErrorCode GetDirection(IntPtr handle, out FrameDirection direction);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_get_position_x")]
            internal static extern ErrorCode GetPositionX(IntPtr handle, out Int32 x);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_get_position_y")]
            internal static extern ErrorCode GetPositionY(IntPtr handle, out Int32 y);

            [DllImport(Libraries.FrameBroker, EntryPoint = "frame_get_extra_data")]
            internal static extern ErrorCode GetExtraData(IntPtr handle, out SafeBundleHandle safeBundleHandle);
        }
    }
}
