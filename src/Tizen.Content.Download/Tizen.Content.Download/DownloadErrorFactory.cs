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
using Tizen.Internals.Errors;

namespace Tizen.Content.Download
{
    internal enum DownloadError
    {
        DownloadErrorCommonCode = -0x02A00000,
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        NetworkUnreachable = ErrorCode.NetworkUnreachable,
        ConnectionTimedOut = ErrorCode.ConnectionTimeout,
        NoSpace = ErrorCode.FileNoSpaceOnDevice,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        InvalidState = DownloadErrorCommonCode | 0x21,
        ConnectionFailed = DownloadErrorCommonCode | 0x22,
        InvalidUrl = DownloadErrorCommonCode | 0x24,
        InvalidDestination = DownloadErrorCommonCode | 0x25,
        TooManyDownloads = DownloadErrorCommonCode | 0x26,
        QueueFull = DownloadErrorCommonCode | 0x27,
        AlreadyCompleted = DownloadErrorCommonCode | 0x28,
        FileAlreadyExists = DownloadErrorCommonCode | 0x29,
        CannotResume = DownloadErrorCommonCode | 0x2a,
        FieldNotFound = DownloadErrorCommonCode | 0x2b,
        TooManyRedirects = DownloadErrorCommonCode | 0x30,
        UnhandledHttpCode = DownloadErrorCommonCode | 0x31,
        RequestTimeout = DownloadErrorCommonCode | 0x32,
        ResponseTimeout = DownloadErrorCommonCode | 0x33,
        SystemDown = DownloadErrorCommonCode | 0x34,
        IdNotFound = DownloadErrorCommonCode | 0x35,
        InvalidNetworkType = DownloadErrorCommonCode | 0x36,
        NoData = ErrorCode.NoData,
        IoError = ErrorCode.IoError
    }

    internal static class DownloadErrorFactory
    {
        internal static void ThrowException(int errorCode, string errorMessage = null, string paramName = null)
        {
            DownloadError err = (DownloadError)errorCode;
            string message;

            if (String.IsNullOrEmpty(errorMessage))
            {
                message = err.ToString();
            }
            else
            {
                message = errorMessage;
            }
            switch ((DownloadError)errorCode)
            {
                case DownloadError.InvalidParameter:
                case DownloadError.InvalidUrl:
                case DownloadError.InvalidDestination:
                case DownloadError.InvalidNetworkType: throw new ArgumentException(message, paramName);
                case DownloadError.OutOfMemory:
                case DownloadError.NetworkUnreachable:
                case DownloadError.ConnectionTimedOut:
                case DownloadError.NoSpace:
                case DownloadError.InvalidState:
                case DownloadError.ConnectionFailed:
                case DownloadError.TooManyDownloads:
                case DownloadError.QueueFull:
                case DownloadError.AlreadyCompleted:
                case DownloadError.FileAlreadyExists:
                case DownloadError.CannotResume:
                case DownloadError.FieldNotFound:
                case DownloadError.TooManyRedirects:
                case DownloadError.UnhandledHttpCode:
                case DownloadError.RequestTimeout:
                case DownloadError.ResponseTimeout:
                case DownloadError.SystemDown:
                case DownloadError.IdNotFound:
                case DownloadError.NoData:
                case DownloadError.IoError: throw new InvalidOperationException(message);
                case DownloadError.NotSupported: throw new NotSupportedException(message);
                case DownloadError.PermissionDenied: throw new UnauthorizedAccessException(message);
            }
        }
    }
}
