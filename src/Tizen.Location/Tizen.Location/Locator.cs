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
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.Internals.Errors;
using System.Runtime.InteropServices;

namespace Tizen.Location
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Location";
    }

    /// <summary>
    /// A class which contains the functionality for obtaining geographical infomation and setting boundary condition.
    /// Notifications on events like service becoming enabled or disabled, new position data being available
    /// and others can also be acquired.
    /// </summary>
    public class Locator : IDisposable
    {
        private int _interval = 1;
        private int _stayInterval = 120;
        private double _distance = 120.0;
        private bool _isEnableMock;
        private IntPtr _handle;
        private LocationType _locationType;
        private Location _location = null;
        private bool _disposed = false;
        private bool _isStarted = false;
        private static Locator s_locatorReference;
        private int _requestId = 0;
        private Dictionary<IntPtr, Interop.LocatorEvent.LocationUpdatedCallback> _callback_map = new Dictionary<IntPtr, Interop.LocatorEvent.LocationUpdatedCallback>();

        private Interop.LocatorEvent.ServiceStatechangedCallback _serviceStateChangedCallback;
        private Interop.LocatorEvent.ZonechangedCallback _zoneChangedCallback;
        private Interop.LocatorEvent.SettingchangedCallback _settingChangedCallback;
        private Interop.LocatorEvent.LocationchangedCallback _distanceBasedLocationChangedCallback;
        private Interop.LocatorEvent.LocationchangedCallback _locationChangedCallback;

        private EventHandler<ZoneChangedEventArgs> _zoneChanged;
        private EventHandler<ServiceStateChangedEventArgs> _serviceStateChanged;
        private EventHandler<SettingChangedEventArgs> _settingChanged;
        private EventHandler<LocationChangedEventArgs> _distanceBasedLocationChanged;
        private EventHandler<LocationChangedEventArgs> _locationChanged;

        /// <summary>
        /// The constructor of Locator class.
        /// </summary>
        /// <param name="locationType"> The back-end positioning method to be used for LBS.</param>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public Locator(LocationType locationType)
        {
            Log.Info(Globals.LogTag, "Locator Constructor");
            int ret = Interop.Locator.Create((int)locationType, out _handle);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error creating Location Manager," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
            _location = new Location();
            _locationType = locationType;
        }

        /// <summary>
        /// The destructor of Locator class.
        /// </summary>
        ~Locator()
        {
            Dispose(false);
        }

        /// <summary>
        /// The time interval between callback updates.
        /// Should be in the range [1~120] seconds.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public int Interval
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the Callback Interval");
                return _interval;
            }
            set
            {
                Log.Info(Globals.LogTag, "Setting the Callback Interval");
                if (value > 0 && value <= 120)
                {
                    _interval = value;
                }
                else
                {
                    Log.Error(Globals.LogTag, "Error setting Callback Interval");
                    throw LocationErrorFactory.ThrowLocationException((int)LocationError.InvalidParameter);
                }
            }
        }

        /// <summary>
        /// The time interval between Distance based location callback updates.
        /// Should be in the range [1~120] seconds.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public int StayInterval
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the StayInterval");
                return _stayInterval;
            }
            set
            {
                Log.Info(Globals.LogTag, "Setting the StayInterval");
                if (value > 0 && value <= 120)
                {
                    _stayInterval = value;
                }
                else
                {
                    Log.Error(Globals.LogTag, "Error Setting the StayInterval");
                    throw LocationErrorFactory.ThrowLocationException((int)LocationError.InvalidParameter);
                }
            }
        }

        /// <summary>
        /// The distance between callback updates.
        /// Should be in the range [1-120] meters.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public double Distance
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the Distance Interval");
                return _distance;
            }
            set
            {
                Log.Info(Globals.LogTag, "Setting the Distance Interval");
                if (value > 0 && value <= 120)
                {
                    _distance = value;
                }
                else
                {
                    Log.Error(Globals.LogTag, "Error Setting the Distance");
                    throw LocationErrorFactory.ThrowLocationException((int)LocationError.InvalidParameter);
                }
            }
        }

        /// <summary>
        /// Gets the Location object.
        /// </summary>
        public Location Location
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting location details");
                return _location;
           }
        }

        /// <summary>
        /// Gets the type used to obtain Location data.
        /// </summary>
        public LocationType LocationType
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting LocationType");
                return _locationType;
            }
        }

        /// <summary>
        /// Gets the status whether mock location is enabled or not.
        /// </summary>
        /// <exception cref="UnauthroizedAccessException">Thrown when the app has no privilege to use the location</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public bool EnableMock
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting getting Mock");
                return _isEnableMock;
            }
            set
            {
                _isEnableMock = value;
                SetEnableMock();
            }
        }

        internal IntPtr GetHandle()
        {
            return _handle;
        }

        private void SetEnableMock()
        {
            int ret = Interop.Locator.EnableMock(_isEnableMock);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error Set Enable Mock Type," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        /// <summary>
        /// Starts the Location Manager which has been created using the specified method.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="UnauthroizedAccessException">Thrown when the app has no privilege to use the location</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public void Start()
        {
            Log.Info(Globals.LogTag, "Starting Location Manager");
            if (Locator.s_locatorReference == null)
            {
                int ret = Interop.Locator.Start(_handle);
                if (((LocationError)ret != LocationError.None))
                {
                    Log.Error(Globals.LogTag, "Error Starting Location Manager," + (LocationError)ret);
                    throw LocationErrorFactory.ThrowLocationException(ret);
                }
                Locator.s_locatorReference = this;
                _isStarted = true;
                Log.Info(Globals.LogTag, "Locator reference set");
            }
            else
            {
                Log.Error(Globals.LogTag, "Error, previous instance of Locator should be stopped before starting a new one," + LocationError.NotSupported);
                throw LocationErrorFactory.ThrowLocationException((int)LocationError.NotSupported);
            }
        }

        /// <summary>
        /// Stops the Location Manager which has been activated using the specified method.
        /// Does not destroy the manager.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public void Stop()
        {
            Log.Info(Globals.LogTag, "Stopping Location Manager");
            int ret = Interop.Locator.Stop(_handle);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error stopping Location Manager," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
            Locator.s_locatorReference = null;
            _isStarted = false;
       }

        /// <summary>
        /// Sets a mock location for the given location method.
        /// </summary>
        /// <param name="location"> The location object containing the mock location details.</param>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="UnauthroizedAccessException">Thrown when the app has no privilege to use the location</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public void SetMockLocation(Location location)
        {
            Log.Info(Globals.LogTag, "Setting mock location");
            int ret = Interop.Locator.SetMockLocation(_handle, location.Latitude, location.Longitude, location.Altitude, location.Speed, location.Direction, location.HorizontalAccuracy);
            if (((LocationError)ret == LocationError.None))
            {
                _location.Latitude = location.Latitude;
                _location.Longitude = location.Longitude;
                _location.Altitude = location.Altitude;
                _location.Speed = location.Speed;
                _location.Direction = location.Direction;
                _location.HorizontalAccuracy = location.HorizontalAccuracy;
            }
            else
            {
                Log.Error(Globals.LogTag, "Error in setting up location mocking," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        /// <summary>
        /// Clears a mock location for the given location method.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="UnauthroizedAccessException">Thrown when the app has no privilege to use the location</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public void ClearMock()
        {
            Log.Info(Globals.LogTag, "Clear mock location");
            int ret = Interop.Locator.ClearMock(_handle);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in clear up location mocking," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        /// <summary>
        /// Gets the details of the location asynchronously.
        /// </summary>
        /// <param name="timeout"> Timeout to stop requesting single location after(seconds).</param>
        /// <returns> A task which contains the current location details</returns>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="UnauthroizedAccessException">Thrown when the app has no privilege to use the location</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public Task<Location> GetLocationAsync(int timeout)
        {
            var task = new TaskCompletionSource<Location>();
            IntPtr id = IntPtr.Zero;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (LocationError error, double latitude, double longitude, double altitude, int timestamp, double speed, double direction, double climb, IntPtr userData) =>
                {
                    if (error != LocationError.None)
                    {
                        Log.Error(Globals.LogTag, "Error in getting up location information," + (LocationError)error);
                    }
                    else
                    {
                        Log.Info(Globals.LogTag, "Creating a current location object");
                        _location = new Location(latitude, longitude, altitude, 0.0, direction, speed, timestamp);
                        task.SetResult(_location);
                    }
                    lock (_callback_map)
                    {
                        _callback_map.Remove(userData);
                    }
                };
            }

            int ret = Interop.LocatorEvent.GetSingleLocation(_handle, timeout, _callback_map[id], id);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in setting up location mocking," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
            return task.Task;
        }


        /// <summary>
        /// Gets the details of the location.
        /// </summary>
        /// <returns> which contains the current location details</returns>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="UnauthroizedAccessException">Thrown when the app has no privilege to use the location</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public Location GetLocation()
        {
            double altitude = 0;
            double latitude = 0;
            double longitude = 0;
            double climb = 0;
            double direction = 0;
            double speed = 0;
            LocationAccuracy level = LocationAccuracy.None;
            double horizontal = 0;
            double vertical = 0;
            int timestamp = 0;

            if (_isStarted)
            {
                Log.Info(Globals.LogTag, "Get current location information");
                int ret = Interop.Locator.GetLocation(_handle, out altitude, out latitude, out longitude, out climb, out direction, out speed, out level, out horizontal, out vertical, out timestamp);
                if (((LocationError)ret != LocationError.None))
                {
                    Log.Error(Globals.LogTag, "Error in get current location infomation," + (LocationError)ret);
                    throw LocationErrorFactory.ThrowLocationException(ret);
                }
            }
            else
            {
                Log.Info(Globals.LogTag, "Get last location information");
                int ret = Interop.Locator.GetLastLocation(_handle, out altitude, out latitude, out longitude, out climb, out direction, out speed, out level, out horizontal, out vertical, out timestamp);
                if (((LocationError)ret != LocationError.None))
                {
                    Log.Error(Globals.LogTag, "Error in get last location information," + (LocationError)ret);
                    throw LocationErrorFactory.ThrowLocationException(ret);
                }
            }

            Location location = new Location(latitude, longitude, altitude, horizontal, direction, speed, timestamp);
            _location = location;

            return location;
        }


        /// <summary>
        /// Adds a bounds for a given locator.
        /// </summary>
        /// <param name="locationBoundary"> The boundary object to be added to the locator.</param>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public void AddBoundary(LocationBoundary locationBoundary)
        {
            Log.Info(Globals.LogTag, "AddBoundary called");

            int ret = Interop.Locator.AddBoundary(_handle, locationBoundary.GetHandle());
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Adding Boundary," + (LocationBoundError)ret);
                throw LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
        }

        /// <summary>
        /// Deletes a bounds for a given locator.
        /// </summary>
        /// <param name="locationBoundary"> The boundary object to be removed from the locator.</param>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public void RemoveBoundary(LocationBoundary locationBoundary)
        {
            Log.Info(Globals.LogTag, "RemoveBoundary called");
            int ret = Interop.Locator.RemoveBoundary(_handle, locationBoundary.GetHandle());
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Removing Boundary," + (LocationBoundError)ret);
                throw LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
        }

        /// <summary>
        /// The overidden Dispose method of the IDisposable class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                DestroyHandle();

            _disposed = true;
        }

        private void DestroyHandle()
        {
            int ret = Interop.Locator.Destroy(_handle);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in Destroy handle, " + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        /// <summary>
        /// (event) ServiceStateChanged Event is invoked when the location service state is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged
        {
            add
            {
                Log.Info(Globals.LogTag, "ServiceStateChanged called");
                if (_serviceStateChanged == null)
                {
                    Log.Info(Globals.LogTag, "Calling function SetServiceStateChangedCallback");
                    SetServiceStateChangedCallback();
                }
                _serviceStateChanged += value;
            }
            remove
            {
                Log.Info(Globals.LogTag, "Callback removed");
                _serviceStateChanged -= value;

                if (_serviceStateChanged == null)
                {
                    Log.Info(Globals.LogTag, "Calling function UnSetServiceStateChangedCallback");
                    UnSetServiceStateChangedCallback();
                }
            }
        }

        private void SetServiceStateChangedCallback()
        {
            Log.Info(Globals.LogTag, "Calling Interop.LocatorEvent.SetServiceStateChangedCallback");
            if (_serviceStateChangedCallback == null)
            {
                _serviceStateChangedCallback = (state, userData) =>
                {
                    Log.Info(Globals.LogTag, "Inside ServiceStateChangedCallback");
                    _serviceStateChanged?.Invoke(this, new ServiceStateChangedEventArgs(state));
                };
            }

            int ret = Interop.LocatorEvent.SetServiceStateChangedCallback(_handle, _serviceStateChangedCallback, IntPtr.Zero);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in Setting Service State Changed Callback," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        private void UnSetServiceStateChangedCallback()
        {
            Log.Info(Globals.LogTag, "Calling Interop.LocatorEvent.UnSetServiceStateChangedCallback");
            int ret = Interop.LocatorEvent.UnSetServiceStateChangedCallback(_handle);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in UnSetting Service State Changed Callback," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        /// <summary>
        /// (event) ZoneChanged is  invoked when the previously set boundary area is entered or left.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public event EventHandler<ZoneChangedEventArgs> ZoneChanged
        {
            add
            {
                Log.Info(Globals.LogTag, "ZoneChanged called");
                if (_zoneChanged == null)
                {
                    Log.Info(Globals.LogTag, "Calling function SetZoneChangedCallback");
                    SetZoneChangedCallback();
                }
                _zoneChanged += value;
            }
            remove
            {
                Log.Info(Globals.LogTag, "Callback removed");
                _zoneChanged -= value;

                if (_zoneChanged == null)
                {
                    Log.Info(Globals.LogTag, "Calling function UnSetZoneChangedCallback");
                    UnSetZoneChangedCallback();
                }
            }
        }

        private void SetZoneChangedCallback()
        {
            Log.Info(Globals.LogTag, "Inside SetZoneChangedCallback");
            if (_zoneChangedCallback == null)
            {
                _zoneChangedCallback = (state, latitude, longitude, altitude, timestamp, userData) =>
                {
                    Log.Info(Globals.LogTag, "Inside ZoneChangedCallback");
                    DateTime timeStamp = DateTime.Now;
                    if (timestamp != 0)
                    {
                        DateTime start = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(timestamp), DateTimeKind.Utc);
                        timeStamp = start.ToLocalTime();
                    }
                    _zoneChanged?.Invoke(this, new ZoneChangedEventArgs(state, latitude, longitude, altitude, timeStamp));
                };
            }

            int ret = Interop.LocatorEvent.SetZoneChangedCallback(_handle, _zoneChangedCallback, IntPtr.Zero);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in Setting Zone Changed Callback," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        private void UnSetZoneChangedCallback()
        {
            Log.Info(Globals.LogTag, "Inside UnSetZoneChangedCallback");
            int ret = Interop.LocatorEvent.UnSetZoneChangedCallback(_handle);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in UnSetting Zone Changed Callback," + (LocationError)ret);
            }
        }

        /// <summary>
        /// (event) SetttingChanged is raised when the location setting is changed.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public event EventHandler<SettingChangedEventArgs> SettingChanged
        {
            add
            {
                Log.Info(Globals.LogTag, "Adding SettingChanged EventHandler");
                if (_settingChanged == null)
                {
                    Log.Info(Globals.LogTag, "Calling function SetSettingChangedCallback");
                    SetSettingChangedCallback();
                }
                _settingChanged += value;
            }
            remove
            {
                Log.Info(Globals.LogTag, "Removing SettingChanged EventHandler");
                _settingChanged -= value;

                if (_settingChanged == null)
                {
                    Log.Info(Globals.LogTag, "Calling function UnSetSettingChangedCallback");
                    UnSetSettingChangedCallback();
                }
            }
        }

        private void SetSettingChangedCallback()
        {
            Log.Info(Globals.LogTag, "Calling SetSettingChangedCallback");
            if (_settingChangedCallback == null)
            {
                _settingChangedCallback = (method, enable, userData) =>
                {
                    Log.Info(Globals.LogTag, "Calling SettingChangedCallback");
                    _settingChanged?.Invoke(this, new SettingChangedEventArgs(method, enable));
                };
            }

            int ret = Interop.LocatorEvent.SetSettingChangedCallback((int)_locationType, _settingChangedCallback, IntPtr.Zero);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in Setting Changed Callback," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        private void UnSetSettingChangedCallback()
        {
            Log.Info(Globals.LogTag, "Calling UnSetSettingChangedCallback");
            int ret = Interop.LocatorEvent.UnSetSettingChangedCallback((int)_locationType);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in Unsetting Setting's Callback," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        /// <summary>
        /// (event) DistanceBasedLocationChanged is raised with updated location information.
        /// The callback will be invoked at minimum interval or minimum distance with updated position information.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public event EventHandler<LocationChangedEventArgs> DistanceBasedLocationChanged
        {
            add
            {
                Log.Info(Globals.LogTag, "Adding DistanceBasedLocationChanged EventHandler");
                //if (_distanceBasedLocationChanged == null)
                {
                    Log.Info(Globals.LogTag, "Calling function SetDistanceBasedLocationChangedCallback");
                    SetDistanceBasedLocationChangedCallback();
                }
                _distanceBasedLocationChanged += value;
            }
            remove
            {
                Log.Info(Globals.LogTag, "Removing DistanceBasedLocationChanged EventHandler");
                _distanceBasedLocationChanged -= value;

                if (_distanceBasedLocationChanged == null)
                {
                    Log.Info(Globals.LogTag, "Calling function UnSetDistanceBasedLocationChangedCallback");
                    UnSetDistanceBasedLocationChangedCallback();
                }
            }
        }

        private void SetDistanceBasedLocationChangedCallback()
        {
            Log.Info(Globals.LogTag, "SetDistanceBasedLocationChangedCallback");
            if (_distanceBasedLocationChangedCallback == null) {
                _distanceBasedLocationChangedCallback = (latitude, longitude, altitude, speed, direction, horizontalAccuracy, timestamp, userData) =>
                {
                    Log.Info(Globals.LogTag, "DistanceBasedLocationChangedCallback #1");
                    Location location = new Location(latitude, longitude, altitude, horizontalAccuracy, direction, speed, timestamp);
                    Log.Info(Globals.LogTag, "DistanceBasedLocationChangedCallback #2");
                    _distanceBasedLocationChanged?.Invoke(this, new LocationChangedEventArgs(location));
                    Log.Info(Globals.LogTag, "DistanceBasedLocationChangedCallback #3");
                };
            }
            
            int ret = Interop.LocatorEvent.SetDistanceBasedLocationChangedCallback(_handle, _distanceBasedLocationChangedCallback, _stayInterval, _distance, IntPtr.Zero);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in Setting Distance based location changed Callback," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        private void UnSetDistanceBasedLocationChangedCallback()
        {
            Log.Info(Globals.LogTag, "UnSetDistanceBasedLocationChangedCallback");
            int ret = Interop.LocatorEvent.UnSetDistanceBasedLocationChangedCallback(_handle);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in UnSetting Distance based location changed Callback," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
            _distanceBasedLocationChanged = null;
        }

        /// <summary>
        /// (event)LocationUpdated is raised at defined intervals of time with updated location information.
        /// The callback will be invoked periodically.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported</exception>
        public event EventHandler<LocationChangedEventArgs> LocationChanged
        {
            add
            {
                Log.Info(Globals.LogTag, "Adding LocationChanged EventHandler");
                if (_locationChanged == null)
                {
                    Log.Info(Globals.LogTag, "Calling function SetLocationChangedCallback");
                    SetLocationChangedCallback();
                }
                _locationChanged += value;
            }
            remove
            {
                Log.Info(Globals.LogTag, "Adding LocationChanged EventHandler");
                _locationChanged -= value;

                if (_locationChanged == null)
                {
                    Log.Info(Globals.LogTag, "calling function UnSetLocationChangedCallback");
                    UnSetLocationChangedCallback();
                }
            }
        }

        private void SetLocationChangedCallback()
        {
            Log.Info(Globals.LogTag, "Calling SetLocationChangedCallback");

            if (_locationChangedCallback == null) {
                _locationChangedCallback = (latitude, longitude, altitude, speed, direction, horizontalAccuracy, timestamp, userData) =>
                {
                    Log.Info(Globals.LogTag, "LocationChangedCallback has been called");
                    Location location = new Location(latitude, longitude, altitude, horizontalAccuracy, direction, speed, timestamp);
                    _location = location;
                    _locationChanged?.Invoke(this, new LocationChangedEventArgs(location));
                };
            }

            int ret = Interop.LocatorEvent.SetLocationChangedCallback(_handle, _locationChangedCallback, _interval, IntPtr.Zero);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in Setting location changed Callback," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }

        private void UnSetLocationChangedCallback()
        {
            Log.Info(Globals.LogTag, "Calling UnSetLocationChangedCallback");
            int ret = Interop.LocatorEvent.UnSetLocationChangedCallback(_handle);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in UnSetting location changed Callback," + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }
    }
}
