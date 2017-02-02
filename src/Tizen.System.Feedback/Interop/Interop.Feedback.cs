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
    internal static partial class Feedback
    {
        internal enum FeedbackError
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            OperationFailed = Tizen.Internals.Errors.ErrorCode.NotPermitted,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NoSuchDevice,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            NotInitialized = -0x00020000 | 0x12,
        }

        // Any change here might require changes in Tizen.System.FeedbackType enum
        internal enum FeedbackType
        {
            Sound = 1,
            Vibration = 2,
        }

        [DllImport(Libraries.Feedback, EntryPoint = "feedback_initialize")]
        internal static extern int Initialize();

        [DllImport(Libraries.Feedback, EntryPoint = "feedback_deinitialize")]
        internal static extern int Deinitialize();

        [DllImport(Libraries.Feedback, EntryPoint = "feedback_play")]
        internal static extern int Play(int pattern);

        [DllImport(Libraries.Feedback, EntryPoint = "feedback_play_type")]
        internal static extern int PlayType(FeedbackType type, int pattern);

        [DllImport(Libraries.Feedback, EntryPoint = "feedback_stop")]
        internal static extern int Stop();

        [DllImport(Libraries.Feedback, EntryPoint = "feedback_is_supported_pattern")]
        internal static extern int IsSupportedPattern(FeedbackType type, int pattern, out bool supported);
    }
}
