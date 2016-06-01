// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
            if (String.IsNullOrEmpty(errorMessage))
            {
                errorMessage = err.ToString();
            }
            switch ((DownloadError)errorCode)
            {
                case DownloadError.InvalidParameter:
                case DownloadError.InvalidUrl:
                case DownloadError.InvalidDestination:
                case DownloadError.InvalidNetworkType: throw new ArgumentException(errorMessage, paramName);
                case DownloadError.OutOfMemory:
                case DownloadError.NetworkUnreachable:
                case DownloadError.ConnectionTimedOut:
                case DownloadError.NoSpace:
                case DownloadError.PermissionDenied:
                case DownloadError.NotSupported:
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
                case DownloadError.IoError: throw new InvalidOperationException(errorMessage);
            }
        }
    }
}
