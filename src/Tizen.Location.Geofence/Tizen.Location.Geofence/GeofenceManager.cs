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
    /// The Geofence Manager API provides service related to geofence (geo-fence).
    /// Geofence is a virtual perimeter for a real-world geographic area.
    /// This API provides functions to set geofence with a geopoint, MAC address of Wi-Fi, and Bluetooth address.
    /// Also, notifications on events like changing in service status are provided.
    /// There are two kinds of places and fences:
    /// <list>
    /// <item>Public places and fences are created by the MyPlace application that can be used by all applications.</item>
    /// <item>Private places and fences are created by the specified application that can be used by the same application.</item>
    /// </list>
    /// Notifications can be received about the following events:
    /// <list>
    /// <item>Zone in when a device enters a specific area.</item>
    /// <item>Zone out when a device exits a specific area.</item>
    /// <item>Results and errors for each event requested to the geofence module.</item>
    /// </list>
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class GeofenceManager : IDisposable
    {
        private bool _disposed = false;

        internal IntPtr Handle
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new Geofence manager.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="OutOfMemoryException">In case of out of memory condition.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case the geofence is not supported.</exception>
        public GeofenceManager()
        {
            IntPtr handle;
            GeofenceError ret = (GeofenceError) Interop.GeofenceManager.Create(out handle);
            if(ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to create Geofence Manager instance");
            }

            Handle = handle;
        }

        ~GeofenceManager()
        {
            Dispose(false);
        }

        /// <summary>
        /// Checks whether the Geofence manager is available or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool IsSupported
        {
            get
            {
                bool ret = false;
                GeofenceError res= (GeofenceError)Interop.GeofenceManager.IsSupported(out ret);
                if(res != GeofenceError.None)
                {
                    Tizen.Log.Error(GeofenceErrorFactory.LogTag, "Failed to get IsSupported feature for Geofence manager");
                }

                return ret;
            }
        }

        /// <summary>
        /// Starts the geofencing service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="geofenceId">The specified geofence ID.</param>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <remarks>
        /// When the location service is enabled, the StateChanged event is invoked and the service starts.
        /// </remarks>
        /// <exception cref="ArgumentException">In case of an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="UnauthorizedAccessException">In case privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">In case the geofence is not supported.</exception>
        public void Start(int geofenceId)
        {
            GeofenceError ret = (GeofenceError)Interop.GeofenceManager.Start(Handle, geofenceId);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to start service for "  + geofenceId);
            }
        }

        /// <summary>
        /// Stops the geofenceing service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="geofenceId">The specified geofence ID.</param>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <remarks>
        /// This function initiates the process of stopping the service.
        /// You can stop and start the Geofence manager as needed.
        /// </remarks>
        /// <exception cref="ArgumentException">In case of an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="UnauthorizedAccessException">In case privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">In case the geofence is not supported.</exception>
        public void Stop(int geofenceId)
        {
            GeofenceError ret = (GeofenceError)Interop.GeofenceManager.Stop(Handle, geofenceId);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to stop service for " + geofenceId);
            }
        }

        private static readonly Interop.GeofenceManager.StateChangedCallback s_stateChangedCallback = (int fenceId, GeofenceState state, IntPtr data) =>
         {
             GeofenceStateEventArgs evenArgs = new GeofenceStateEventArgs(fenceId, state);
             s_stateChanged?.Invoke(null, evenArgs);
             return true;
         };

        private static event EventHandler<GeofenceStateEventArgs> s_stateChanged = null;

        /// <summary>
        /// Invokes when a device enters or exits the given geofence if this event is registered.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Call to Start() will invoke this event.
        /// </remarks>
        /// <exception cref="NotSupportedException">In case the feature is not supported.</exception>
        public event EventHandler<GeofenceStateEventArgs> StateChanged
        {
            add
            {
                if(s_stateChanged == null)
                {
                    GeofenceError ret = (GeofenceError)Interop.GeofenceManager.SetStateChangedCB(Handle, s_stateChangedCallback, IntPtr.Zero);
                    if (ret != GeofenceError.None)
                    {
                        throw GeofenceErrorFactory.CreateException(ret, "Failed to register state change callback");
                    }
                }
                s_stateChanged += value;
            }
            remove
            {
                s_stateChanged -= value;
                if (s_stateChanged == null)
                {
                    GeofenceError ret = (GeofenceError)Interop.GeofenceManager.UnsetStateChangedCB(Handle);
                    if (ret != GeofenceError.None)
                    {
                        throw GeofenceErrorFactory.CreateException(ret, "Failed to unregister state change callback");
                    }
                }
            }
        }

        private static readonly Interop.GeofenceManager.ProximityStateChangedCallback s_proximityChangedCallback = (int fenceId, ProximityState state, ProximityProvider provider, IntPtr data) =>
        {
            ProximityStateEventArgs evenArgs = new ProximityStateEventArgs(fenceId, state, provider);
            s_proximityChanged?.Invoke(null, evenArgs);
            return true;
        };

        private static event EventHandler<ProximityStateEventArgs> s_proximityChanged;

        /// <summary>
        /// Called when the proximity state of a device is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Call to Start() will invoke this event.
        /// </remarks>
        /// <exception cref="NotSupportedException">In case the feature is not supported.</exception>
        public event EventHandler<ProximityStateEventArgs> ProximityChanged
        {
            add
            {
                if (s_proximityChanged == null)
                {
                    GeofenceError ret = (GeofenceError)Interop.GeofenceManager.SetProximityStateCB(Handle, s_proximityChangedCallback, IntPtr.Zero);
                    if (ret != GeofenceError.None)
                    {
                        throw GeofenceErrorFactory.CreateException(ret, "Failed to register proximity change callback");
                    }
                    s_proximityChanged += value;
                }
            }
            remove
            {
                s_proximityChanged -= value;
                if (s_proximityChanged == null)
                {
                    GeofenceError ret = (GeofenceError)Interop.GeofenceManager.UnsetProximityStateCB(Handle);
                    if (ret != GeofenceError.None)
                    {
                        throw GeofenceErrorFactory.CreateException(ret, "Failed to un register proximity change callback");
                    }
                }
            }
        }

        private static readonly Interop.GeofenceManager.GeofenceEventCallback s_geofenceEventCallback = (int placeId, int fenceId, GeofenceError error, GeofenceEventType eventType, IntPtr data) =>
        {
            GeofenceResponseEventArgs evenArgs = new GeofenceResponseEventArgs(placeId, fenceId, error, eventType);
            s_geofenceEventChanged?.Invoke(null, evenArgs);
            return true;
        };

        private static event EventHandler<GeofenceResponseEventArgs> s_geofenceEventChanged;

        /// <summary>
        /// Called when some event occurs in the geofence and the place, such as add, update, etc..
        /// The events of public geofence is also received if there are public geofences.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Call to Start() will invoke this event.
        /// The value of place_id or geofence_id is -1 when the place ID or geofence ID is not assigned.
        /// </remarks>
        /// <exception cref="NotSupportedException">In case the feature is not supported.</exception>
        public event EventHandler<GeofenceResponseEventArgs> GeofenceEventChanged
        {
            add
            {
                if (s_geofenceEventChanged == null)
                {
                    GeofenceError ret = (GeofenceError)Interop.GeofenceManager.SetGeofenceEventCB(Handle, s_geofenceEventCallback, IntPtr.Zero);
                    if (ret != GeofenceError.None)
                    {
                        throw GeofenceErrorFactory.CreateException(ret, "Failed to register geofence event change callback");
                    }
                    s_geofenceEventChanged += value;
                }
            }
            remove
            {
                s_geofenceEventChanged -= value;
                if (s_geofenceEventChanged == null)
                {
                    GeofenceError ret = (GeofenceError)Interop.GeofenceManager.UnsetGeofenceEventCB(Handle);
                    if (ret != GeofenceError.None)
                    {
                        throw GeofenceErrorFactory.CreateException(ret, "Failed to unregister geofence event change callback");
                    }
                }
            }
        }

        /// <summary>
        /// The overloaded Dispose API for destroying the GeofenceManager handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                Interop.GeofenceManager.Destroy(Handle);
                Handle = IntPtr.Zero;
            }

            _disposed = true;
        }
    }
}
