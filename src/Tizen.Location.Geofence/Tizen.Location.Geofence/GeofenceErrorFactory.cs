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
using Tizen;


namespace Tizen.Location.Geofence
{
    /// <summary>
    /// Enum to give the type of error occured, if any.
    /// </summary>
    public enum GeofenceError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = Tizen.Internals.Errors.ErrorCode.None,

        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,

        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,

        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,

        /// <summary>
        /// Not Supported.
        /// </summary>
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,

        /// <summary>
        /// Geofence Manager is not initialized.
        /// </summary>
        NotInitialized = -0x02C00000 | 0x100 | 0x01,

        /// <summary>
        /// Invalid geofence ID.
        /// </summary>
        InvalidID = -0x02C00000 | 0x100 | 0x02,

        /// <summary>
        /// Exception occurs.
        /// </summary>
        Exception = -0x02C00000 | 0x100 | 0x03,

        /// <summary>
        /// Geofencing is already started.
        /// </summary>
        AlreadyStarted = -0x02C00000 | 0x100 | 0x04,

        /// <summary>
        /// Too many geofence.
        /// </summary>
        TooManyGeofence = -0x02C00000 | 0x100 | 0x05,

        /// <summary>
        /// Error in GPS, Wi-Fi, or BT.
        /// </summary>
        IPC = -0x02C00000 | 0x100 | 0x06,

        /// <summary>
        /// DB error in the server side.
        /// </summary>
        DBFailed = -0x02C00000 | 0x100 | 0x07,

        /// <summary>
        /// Access to specified place is denied.
        /// </summary>
        PlaceAccessDenied = -0x02C00000 | 0x100 | 0x08,

        /// <summary>
        /// Access to specified geofence is denied.
        /// </summary>
        GeofenceAccessDenied = -0x02C00000 | 0x100 | 0x09
    };

    internal class GeofenceErrorFactory
    {
        internal const string LogTag = "Tizen.Location.Geofence";

        internal static Exception CreateException(GeofenceError err, string msg)
        {
            Log.Info(LogTag, "Got Error " + err + " throwing Exception with msg " + msg);
            Exception exp;
            switch (err)
            {
                case GeofenceError.InvalidParameter:
                    {
                        exp = new ArgumentException(msg + " Invalid Parameters Provided");
                        break;
                    }

                case GeofenceError.OutOfMemory:
                    {
                        exp = new OutOfMemoryException(msg + " Out Of Memory");
                        break;
                    }

                case GeofenceError.NotInitialized:
                    {
                        exp = new InvalidOperationException(msg + " Not initializded");
                        break;
                    }

                case GeofenceError.NotSupported:
                    {
                        exp = new NotSupportedException(msg + " Not supported");
                        break;
                    }

                case GeofenceError.PermissionDenied:
                // fall through
                case GeofenceError.GeofenceAccessDenied:
                //fall through
                case GeofenceError.PlaceAccessDenied:
                    {
                        exp = new UnauthorizedAccessException(msg + " Permission Denied");
                        break;
                    }

                case GeofenceError.DBFailed:
                    {
                        exp = new InvalidOperationException(msg + " DataBase Failed");
                        break;
                    }

                default:
                    {
                        exp = new InvalidOperationException(msg);
                        break;
                    }
            }

            return exp;
        }
    }
}
