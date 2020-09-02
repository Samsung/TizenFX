/*
* Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Inspections
{
    internal static class ExceptionFactory
    {
        internal static Exception CreateException(Interop.Inspections.InspectionError err)
        {
            Tizen.Log.Error(Interop.Inspections.LogTag, $"Error {err}");

            switch (err)
            {
                case Interop.Inspections.InspectionError.InvalidParameter:
                    return new ArgumentException("Invalid parameters provided");

                case Interop.Inspections.InspectionError.IoError:
                    return new InvalidOperationException("I/O Error occured");

                case Interop.Inspections.InspectionError.OutOfMemory:
                    return new InvalidOperationException("Invalid operation");

                case Interop.Inspections.InspectionError.ResourceBusy:
                    return new InvalidOperationException("Resource is busy");

                case Interop.Inspections.InspectionError.TimedOut:
                    return new InvalidOperationException("Timed out");

                case Interop.Inspections.InspectionError.NotSupported:
                    return new NotSupportedException("Not supported");

                case Interop.Inspections.InspectionError.TryAgain:
                    return new InvalidOperationException("Try again");

                case Interop.Inspections.InspectionError.PermissionDenied:
                    return new InvalidOperationException("Permission denied");

                default:
                    return new Exception("");
            }
        }
    }
}
