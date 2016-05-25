/// This File contains the Api's related to the class
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.Content.MediaContent
{
    internal static class Globals
    {
        internal const string LogTag = "Tizen.Content.MediaContent";
    }
    internal static class FixMe
    {
        //TODO: Fix the below constant by a suitable constant in csapi-tizen
        internal const int MediaContentErrorClass = -0x01610000;
    }
    /// <summary>
    /// Enum to give the type of error occured, if any.</summary>
    public enum MediaContentError : int
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = Tizen.Internals.Errors.ErrorCode.None,
        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InavlidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        /// <summary>
        /// Invalid Operation.
        /// </summary>
        InavlidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
        /// <summary>
        /// No space left on device.
        /// </summary>
        NoSpaceOnDevice = Tizen.Internals.Errors.ErrorCode.FileNoSpaceOnDevice,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        AlreadyInProgress = Tizen.Internals.Errors.ErrorCode.AlreadyInProgress,
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        ResourceBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,
        InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
        /// <summary>
        /// DB operation failed.
        /// </summary>
        DBFailed = FixMe.MediaContentErrorClass | 0x01,
        /// <summary>
        /// DB operation BUSY.
        /// </summary>
        DBBusy = FixMe.MediaContentErrorClass | 0x02,
        /// <summary>
        /// Network Fail.
        /// </summary>
        NetworkError = FixMe.MediaContentErrorClass | 0x03,
        /// <summary>
        /// Unsupported Content.
        /// </summary>
        UnsupportedContent = FixMe.MediaContentErrorClass | 0x04
    };
}
