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

namespace Tizen.Location
{
    internal static class LocationManagerError
    {
        public const int Base = -0x02C00000;
        public const int BoundsBase = -0x02C00000 | 0x20;
    }

    /// <summary>
    /// Location Manager error codes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum LocationError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = ErrorCode.None,

        /// <summary>
        /// Out of memory error.
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,

        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,

        /// <summary>
        /// Permission denied.
        /// </summary>
        AcessibilityNotallowed = ErrorCode.PermissionDenied,

        /// <summary>
        /// Address family not supported.
        /// </summary>
        NotSupported = ErrorCode.NotSupported,

        /// <summary>
        /// Location manager contains incorrect method for a given call.
        /// </summary>
        IncorrectMethod = LocationManagerError.Base | 0x01,

        /// <summary>
        /// Network unavailable.
        /// </summary>
        NetworkFailed = LocationManagerError.Base | 0x02,

        /// <summary>
        /// Location service is not available.
        /// </summary>
        ServiceNotAvailable = LocationManagerError.Base | 0x03,

        /// <summary>
        /// GPS/WPS, or MOCK setting is not enabled.
        /// </summary>
        SettingOff = LocationManagerError.Base | 0x04,

        /// <summary>
        /// Restricted by security system policy.
        /// </summary>
        SecuirtyRestricted = LocationManagerError.Base | 0x05,
    }

    /// <summary>
    /// Location Boundary error codes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum LocationBoundError
    {

        /// <summary>
        /// Successful.
        /// </summary>
        None = ErrorCode.None,

        /// <summary>
        /// Out of memory error.
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,

        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,

        /// <summary>
        /// Not supported.
        /// </summary>
        NotSupported = ErrorCode.NotSupported,

        /// <summary>
        /// Incorrect bounds type for a given call.
        /// </summary>
        IncorrectType = LocationManagerError.BoundsBase | 0x01,

        /// <summary>
        /// Cannot remove bounds handle from location manager.
        /// </summary>
        IsAdded = LocationManagerError.BoundsBase | 0x02
    }

    internal static class LocationErrorFactory
    {
        internal static Exception ThrowLocationException(int errCode)
        {
            Log.Error(Globals.LogTag, "Throw Location Exception : " + errCode);
            LocationError error = (LocationError)errCode;
            switch (error)
            {
                case LocationError.OutOfMemory:
                    return new InvalidOperationException("Out of memory");
                case LocationError.InvalidParameter:
                    return new ArgumentException("Invalid Parameter passed");
                case LocationError.AcessibilityNotallowed:
                    return new UnauthorizedAccessException("Accesibility not allowed");
                case LocationError.NotSupported:
                    return new NotSupportedException("Not supported");
                case LocationError.IncorrectMethod:
                    return new InvalidOperationException("Incorrect method used");
                case LocationError.NetworkFailed:
                    return new InvalidOperationException("Network failed");
                case LocationError.ServiceNotAvailable:
                    return new InvalidOperationException("Service not available");
                case LocationError.SettingOff:
                    return new InvalidOperationException("Current locationtype setting is off");
                case LocationError.SecuirtyRestricted:
                    return new InvalidOperationException("Security Restricted");
                default:
                    return new InvalidOperationException("Unknown Error");
            }
        }

        internal static Exception ThrowLocationBoundaryException(int errCode)
        {
            LocationBoundError error = (LocationBoundError)errCode;
            switch (error)
            {
                case LocationBoundError.OutOfMemory:
                    return new InvalidOperationException("Out of memory exception");
                case LocationBoundError.InvalidParameter:
                    return new ArgumentException("Invalid parameter passed");
                case LocationBoundError.NotSupported:
                    return new NotSupportedException("Not supported");
                case LocationBoundError.IncorrectType:
                    return new InvalidOperationException("Incorrect type passed");
                case LocationBoundError.IsAdded:
                    return new InvalidOperationException("Boundary is not addded");
                default:
                    return new InvalidOperationException("Unknown Error");
            }
        }
    }
}
