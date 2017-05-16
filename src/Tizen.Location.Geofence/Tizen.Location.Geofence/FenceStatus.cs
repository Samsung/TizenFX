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

namespace Tizen.Location.Geofence
{
    /// <summary>
    /// The geofence status describes the current state and duration of a geofence.
    /// <list>
    /// <item>State: State is specified by current state of fence</item>
    /// <item>Duration: Geofence is specified by duration of current state</item>
    /// </list>
    /// </summary>
    public class FenceStatus : IDisposable
    {
        private bool _disposed = false;

        internal IntPtr Handle
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new geofence status.
        /// </summary>
        /// <exception cref="ArgumentException">Incase of Invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public FenceStatus(int fenceId)
        {
            IntPtr handle;
            GeofenceError ret = (GeofenceError)Interop.GeofenceStatus.Create(fenceId, out handle);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to create Geofence Status instance");
            }

            Handle = handle;
        }

        ~FenceStatus()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the state of geofence.
        /// </summary>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public GeofenceState State
        {
            get
            {
                GeofenceState state;
                GeofenceError ret = (GeofenceError)Interop.GeofenceStatus.State(Handle, out state);
                if (ret != GeofenceError.None)
                {
                    Tizen.Log.Error(GeofenceErrorFactory.LogTag, "Failed to get FenceState");
                }

                return state;
            }
        }

        /// <summary>
        /// Gets the amount of seconds geofence is in the current state.
        /// </summary>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public int Duration
        {
            get
            {
                int result = -1;
                GeofenceError ret = (GeofenceError)Interop.GeofenceStatus.Duration(Handle, out result);
                if (ret != GeofenceError.None)
                {
                    Tizen.Log.Error(GeofenceErrorFactory.LogTag, "Failed to get FenceDuration");
                }

                return result;
            }
        }

        /// <summary>
        /// Overloaded Dispose API for destroying the fence Handle.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (Handle != IntPtr.Zero)
            {
                Interop.GeofenceStatus.Destroy(Handle);
                Handle = IntPtr.Zero;
            }

            _disposed = true;
        }
    }
}
