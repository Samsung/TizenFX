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
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        /// <summary>
        /// Invalid Operation.
        /// </summary>
        InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
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
