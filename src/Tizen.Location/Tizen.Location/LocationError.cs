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
    /// Location Manager error codes
    /// </summary>
    public enum LocationError
    {
        None = ErrorCode.None,/**< Successful */
        OutOfMemoryError = ErrorCode.OutOfMemory,/**< Out of memory error */
        InvalidParameter = ErrorCode.InvalidParameter,/**< Invalid parameter */
        AcessibilityNotallowed = ErrorCode.PermissionDenied,/**< Permission denied */
        NotSupported = ErrorCode.NotSupported,/**< Address family not supported */
        IncorrectMethod = LocationManagerError.Base | 0x01,/**< Location manager contains incorrect method for a given call */
        NetworkFailed = LocationManagerError.Base | 0x02,/**< Network unavailable */
        ServiceNotAvailable = LocationManagerError.Base | 0x03,/**< Location service is not available */
        GPSSettingOff = LocationManagerError.Base | 0x04,/**< GPS/WPS, or MOCK setting is not enabled */
        SecuirtyRestricted = LocationManagerError.Base | 0x05,/**< Restricted by security system policy */
        SettingOff = GPSSettingOff/**< GPS/WPS, or MOCK setting is not enabled */
    }

    /// <summary>
    /// Location Boundary error codes
    /// </summary>
    public enum LocationBoundError
    {
        None = ErrorCode.None,/**< Successful */
        OutOfMemoryError = ErrorCode.OutOfMemory,/**< Out of memory error */
        InvalidParameter = ErrorCode.InvalidParameter,/**< Invalid parameter */
        NotSupported = ErrorCode.NotSupported,/**< Not supported */
        IncorrectType = LocationManagerError.BoundsBase | 0x01,/**< Incorrect bounds type for a given call */
        IsAdded = LocationManagerError.BoundsBase | 0x02/**< Cannot remove bounds handle from location manager   */
    }

    internal static class LocationErrorFactory
    {
        internal static Exception ThrowLocationException(int errCode)
        {
            LocationError error = (LocationError)errCode;
            switch (error)
            {
                case LocationError.AcessibilityNotallowed:
                    return new InvalidOperationException("Accesibility not allowed");
                case LocationError.SettingOff:
                    return new InvalidOperationException("Current locationtype setting is off");
                case LocationError.IncorrectMethod:
                    return new InvalidOperationException("Incorrect method used");
                case LocationError.InvalidParameter:
                    return new ArgumentException("Invalid Parameter passed");
                case LocationError.NetworkFailed:
                    return new InvalidOperationException("Network failed");
                case LocationError.NotSupported:
                    return new InvalidOperationException("Operation not supported");
                case LocationError.OutOfMemoryError:
                    return new InvalidOperationException("Out of memory error");
                case LocationError.SecuirtyRestricted:
                    return new InvalidOperationException("Security Restricted");
                case LocationError.ServiceNotAvailable:
                    return new InvalidOperationException("Service not available");
                default:
                    return new InvalidOperationException("Unknown Error");
            }
        }

        internal static Exception ThrowLocationBoundaryException(int errCode)
        {
            LocationBoundError error = (LocationBoundError)errCode;
            switch (error)
            {
                case LocationBoundError.IncorrectType:
                    return new InvalidOperationException("Incorrect type passed");
                case LocationBoundError.InvalidParameter:
                    return new ArgumentException("Invalid parameter passed");
                case LocationBoundError.IsAdded:
                    return new InvalidOperationException("Boundary is not addded");
                case LocationBoundError.NotSupported:
                    return new InvalidOperationException("Operation Not supported");
                case LocationBoundError.OutOfMemoryError:
                    return new InvalidOperationException("Out of memory exception");
                default:
                    return new InvalidOperationException("Unknown Error");
            }
        }
    }
}
