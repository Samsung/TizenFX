/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.StickerData;

namespace Tizen.Uix.Sticker
{
    internal static class ExceptionFactory
    {
        internal static Exception CreateException(ErrorCode err)
        {
            Log.Error(LogTag, "Error " + err);
            switch (err)
            {
                case ErrorCode.NotSupported:
                    return new NotSupportedException("Sticker NOT supported");
                case ErrorCode.PermissionDenied:
                    return new UnauthorizedAccessException("Permission Denied");
                case ErrorCode.InvalidParameter:
                    return new ArgumentException("Invalid Parameters Provided");
                case ErrorCode.OutOfMemory:
                    return new InvalidOperationException("Out Of Memory");
                case ErrorCode.OperationFailed:
                    return new InvalidOperationException("Operation Failed");
                case ErrorCode.FileExists:
                    return new InvalidOperationException("File exists");
                case ErrorCode.NoData:
                    return new InvalidOperationException("No data available");
                case ErrorCode.NoSuchFile:
                    return new InvalidOperationException("No such file");
            }
            return new InvalidOperationException("Unknown error : {err.ToString()}");
        }
    }
}
