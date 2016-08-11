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
