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
using ElmSharp;
using Layout = ElmSharp.Layout;
using EvasObject = ElmSharp.EvasObject;
using System.Collections.Generic;

namespace Tizen.Maps
{
    /// <summary>
    /// Map View class to show a map on the screen.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MapView : Layout, IDisposable
    {
        internal Interop.ViewHandle handle;
        private MapService _service;

        private Dictionary<IntPtr, MapObject> _handleToObjectTable = new Dictionary<IntPtr, MapObject>();

        private Interop.ViewOnEventCallback _gestureEventCallback;
        private Interop.ViewOnEventCallback _objectEventCallback;
        private Interop.ViewOnEventCallback _viewReadyEventCallback;

        private event EventHandler<MapGestureEventArgs> _scrolledEventHandler;
        private event EventHandler<MapGestureEventArgs> _twoFingerZoomedEventHandler;
        private event EventHandler<MapGestureEventArgs> _clickedEventHandler;
        private event EventHandler<MapGestureEventArgs> _doubleClickedEventHandler;
        private event EventHandler<MapGestureEventArgs> _twoFingerClickedEventHandler;
        private event EventHandler<MapGestureEventArgs> _twoFingerRotatedEventHandler;
        private event EventHandler<MapGestureEventArgs> _longPressedEventHandler;
        private event EventHandler _viewReadyEventHandler;

        /// <summary>
        /// Creates a view and links it to the instance of a map service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="parent">An instance of <see cref="EvasObject"/> object for which a map view will be drawn.</param>
        /// <param name="service">An instance of <see cref="MapService"/> object.</param>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        /// <exception cref="System.ArgumentException">Thrown when parameters are invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a native operation failed to allocate memory, and connect to the service.</exception>
        public MapView(EvasObject parent, MapService service) : base(parent)
        {
            handle = new Interop.ViewHandle(service.handle, this);
            Log.Info(string.Format("MapView is created"));

            _service = service;
            this.Resize(1, 1);

            // We need to keep Gesture Tap event enabled for object event to work
            handle.SetGestureEnabled(Interop.ViewGesture.Click, true);
            SetObjectEventCallback();
        }

        /// <summary>
        /// Adds or removes event handlers to deliver a scrolled gesture event.
        /// </summary>
        /// <value>Event handlers to get a scrolled gesture event.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        public event EventHandler<MapGestureEventArgs> Scrolled
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.Scroll, true);
                _scrolledEventHandler += value;
                Log.Info(string.Format("Scrolled event handler is added"));
            }
            remove
            {
                _scrolledEventHandler -= value;
                Log.Info(string.Format("Scrolled event handler is removed"));
                if (_scrolledEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.Scroll, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// Adds or removes event handlers to deliver a zoomed gesture event.
        /// </summary>
        /// <value>Event handlers to get a zoomed gesture event.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        public event EventHandler<MapGestureEventArgs> TwoFingerZoomed
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.Zoom, true);
                _twoFingerZoomedEventHandler += value;
                Log.Info(string.Format("TwoFingerZoomed event handler is added"));
            }
            remove
            {
                _twoFingerZoomedEventHandler -= value;
                Log.Info(string.Format("TwoFingerZoomed event handler is removed"));
                if (_twoFingerZoomedEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.Zoom, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// Adds or removes event handlers to deliver a clicked gesture event.
        /// </summary>
        /// <value>Event handlers to get a clicked gesture event.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        public event EventHandler<MapGestureEventArgs> Clicked
        {
            add
            {
                SetGestureEventCallback();
                //handle.SetGestureEnabled(Interop.ViewGesture.Click, true);
                _clickedEventHandler += value;
                Log.Info(string.Format("Clicked event handler is added"));
            }
            remove
            {
                _clickedEventHandler -= value;
                Log.Info(string.Format("Clicked event handler is removed"));
                if (_clickedEventHandler == null)
                {
                    //handle.SetGestureEnabled(Interop.ViewGesture.Click, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// Adds or removes event handlers to deliver a double-clicked gesture event.
        /// </summary>
        /// <value>Event handlers to get a double-clicked gesture event.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        public event EventHandler<MapGestureEventArgs> DoubleClicked
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.DoubleClick, true);
                _doubleClickedEventHandler += value;
                Log.Info(string.Format("DoubleClicked event handler is removed"));
            }
            remove
            {
                _doubleClickedEventHandler -= value;
                Log.Info(string.Format("DoubleClicked event handler is removed"));
                if (_doubleClickedEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.DoubleClick, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// Adds or removes event handlers to deliver a clicked gesture event with two-fingers.
        /// </summary>
        /// <value>Event handlers to get a clicked gesture event.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        public event EventHandler<MapGestureEventArgs> TwoFingerClicked
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.TwoFingerClick, true);
                _twoFingerClickedEventHandler += value;
                Log.Info(string.Format("TwoFingerClicked event handler is added"));
            }
            remove
            {
                _twoFingerClickedEventHandler -= value;
                Log.Info(string.Format("TwoFingerClicked event handler is removed"));
                if (_twoFingerClickedEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.TwoFingerClick, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// Adds or removes event handlers to deliver a rotated gesture event.
        /// </summary>
        /// <value>Event handlers to get a rotated gesture event.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        public event EventHandler<MapGestureEventArgs> TwoFingerRotated
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.Rotation, true);
                _twoFingerRotatedEventHandler += value;
                Log.Info(string.Format("Rotated event handler is added"));
            }
            remove
            {
                _twoFingerRotatedEventHandler -= value;
                Log.Info(string.Format("Rotated event handler is removed"));
                if (_twoFingerRotatedEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.Rotation, false);
                    UnsetGestureEventCallback();
                }
            }
        }


        /// <summary>
        /// Adds or removes event handlers to deliver a long-pressed gesture event.
        /// </summary>
        /// <value>Event handlers to get a long-pressed gesture event.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        public event EventHandler<MapGestureEventArgs> LongPressed
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.LongPress, true);
                _longPressedEventHandler += value;
                Log.Info(string.Format("LongPressed event handler is added"));
            }
            remove
            {
                _longPressedEventHandler -= value;
                Log.Info(string.Format("LongPressed event handler is removed"));
                if (_longPressedEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.LongPress, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// Adds or removes event handlers to deliver an event representing a view ready to be used.
        /// </summary>
        /// <value>Event handlers to get a view ready event.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        public event EventHandler ViewReady
        {
            add
            {
                SetViewReadyEventCallback();
                _viewReadyEventHandler += value;
                Log.Info(string.Format("ViewReady event handler is added"));
            }
            remove
            {
                _viewReadyEventHandler -= value;
                Log.Info(string.Format("ViewReady event handler is removed"));
                UnsetGestureEventCallback();
            }
        }

        /// <summary>
        /// Gets or sets the current zoom level.
        /// </summary>
        /// <value>It is an integer value representing the current zoom level.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public int ZoomLevel
        {
            get
            {
                return handle.ZoomLevel;
            }
            set
            {
                Log.Info(string.Format("ZoomLevel is changed from {0} to {1}", handle.ZoomLevel, value));
                handle.ZoomLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum zoom level.
        /// </summary>
        /// <value>It is an integer value that limits minimal zoom level within a range of the current map plug-in support.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public int MinimumZoomLevel
        {
            get
            {
                return handle.MinimumZoomLevel;
            }
            set
            {
                Log.Info(string.Format("MinimumZoomLevel is changed from {0} to {1}", handle.MinimumZoomLevel, value));
                handle.MinimumZoomLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum zoom level.
        /// </summary>
        /// <value>It is an integer value that limits maximum zoom level within a range of the current map plug-in support.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public int MaximumZoomLevel
        {
            get
            {
                return handle.MaximumZoomLevel;
            }
            set
            {
                Log.Info(string.Format("MaximumZoomLevel is changed from {0} to {1}", handle.MaximumZoomLevel, value));
                handle.MaximumZoomLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets the orientation on the map view.
        /// </summary>
        /// <value>It is an integer value from 0 to 360 that indicates the orientation of the map view.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public double Orientation
        {
            get
            {
                return handle.Orientation;
            }
            set
            {
                Log.Info(string.Format("Orientation is changed from {0} to {1}", handle.Orientation, value));
                handle.Orientation = value;
            }
        }

        /// <summary>
        /// Gets or sets theme type of the map view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public MapTypes MapType
        {
            get
            {
                return (MapTypes)handle.MapType;
            }
            set
            {
                Log.Info(string.Format("MapType is changed from {0} to {1}", handle.MapType, value));
                handle.MapType = (Interop.ViewType)value;
            }
        }

        /// <summary>
        /// Indicates whether the map should show the 3D buildings layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public bool BuildingsEnabled
        {
            get
            {
                return handle.BuildingsEnabled;
            }
            set
            {
                Log.Info(string.Format("Showing the 3D buildings is {0}", (value ? "enabled" : "disabled")));
                handle.BuildingsEnabled = value;
            }
        }

        /// <summary>
        /// Indicates whether the map should show the traffic layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public bool TrafficEnabled
        {
            get
            {
                return handle.TrafficEnabled;
            }
            set
            {
                Log.Info(string.Format("Showing the traffic is {0}", (value ? "enabled" : "disabled")));
                handle.TrafficEnabled = value;
            }
        }

        /// <summary>
        /// Indicates whether the map should show the public transit layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public bool PublicTransitEnabled
        {
            get
            {
                return handle.PublicTransitEnabled;
            }
            set
            {
                Log.Info(string.Format("Showing the public transit is {0}", (value ? "enabled" : "disabled")));
                handle.PublicTransitEnabled = value;
            }
        }

        /// <summary>
        /// Indicates whether the scale-bar is enabled or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public bool ScaleBarEnabled
        {
            get
            {
                return handle.ScaleBarEnabled;
            }
            set
            {
                Log.Info(string.Format("Showing the scale-bar is {0}", (value ? "enabled" : "disabled")));
                handle.ScaleBarEnabled = value;
            }
        }

        /// <summary>
        /// Sets language of map view.
        /// </summary>
        /// <value>The display language in the map.
        /// A language is specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code.
        /// Each language tag is composed of one or more "subtags" separated by hyphens (-).
        /// Each subtag is composed of basic Latin letters or digits only.
        /// For example, "ko-KR" for Korean, "en-US" for American English.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the value is invalid.</exception>
        public string Language
        {
            get
            {
                return handle.Language;
            }
            set
            {
                Log.Info(string.Format("Language is changed from {0} to {1}", handle.Language, value));
                handle.Language = value;
            }
        }

        /// <summary>
        /// Gets or sets geographical coordinates for map view's center.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the value is invalid.</exception>
        public Geocoordinates Center
        {
            get
            {
                return new Geocoordinates(handle.Center);
            }
            set
            {
                Log.Info(string.Format("Center is changed from {0} to {1}", handle.Center.ToString(), value.ToString()));
                handle.Center = value.handle;
            }
        }

        /// <summary>
        /// Gets a list of the map object added to map view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new IEnumerable<MapObject> Children
        {
            get
            {
                return _handleToObjectTable.Values;
            }
        }

        /// <summary>
        /// Changes the geographical coordinates to screen coordinates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="coordinates">Geographical coordinates.</param>
        /// <returns>Returns an instance of the screen coordinates on the current screen.</returns>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the value is invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a native operation failed to allocate memory and connect to the service.</exception>
        public Point GeolocationToScreen(Geocoordinates coordinates)
        {
            return handle.GeolocationToScreen(coordinates.handle);
        }

        /// <summary>
        /// Changes the screen coordinates to geographical coordinates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="screenCoordinates">Screen coordinates.</param>
        /// <returns>Returns an instance of the geographical coordinates object.</returns>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the value is invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a native operation failed to allocate memory and connect to the service.</exception>
        public Geocoordinates ScreenToGeolocation(Point screenCoordinates)
        {
            return new Geocoordinates(handle.ScreenToGeolocation(screenCoordinates));
        }

        /// <summary>
        /// Adds a map object to map view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="child">An instance of the map object to be added.</param>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the value is invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a native operation failed to allocate memory and connect to the service.</exception>
        public void Add(MapObject child)
        {
            Log.Info(string.Format("Add a object"));
            var objectHandle = child.GetHandle();
            if (!_handleToObjectTable.ContainsKey(objectHandle))
            {
                _handleToObjectTable[objectHandle] = child;
                handle.AddObject(objectHandle);

                // MapView take ownership of added map objects
                objectHandle.HasOwnership = false;
            }
        }

        /// <summary>
        /// Removes a map object from the map view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="child">An instance of the map object to be removed.</param>
        /// <remarks>Once removed, the child object will be become invalid.</remarks>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the value is invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when native operation failed to allocate memory and connect to the service.</exception>
        public void Remove(MapObject child)
        {
            Log.Info(string.Format("Remove a object"));
            var objectHandle = child.GetHandle();
            if (_handleToObjectTable.Remove(objectHandle))
            {
                handle.RemoveObject(child.GetHandle());

                // The object handle will be released automatically by the View, once RemoveObject call is successful
                child.InvalidateMapObject();
            }
        }

        /// <summary>
        /// Removes all map objects from the map view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a native operation failed to allocate memory and connect to the service.</exception>
        public void RemoveAll()
        {
            Log.Info(string.Format("Remove all of objects"));
            foreach (var child in _handleToObjectTable.Values)
            {
                child.InvalidateMapObject();
            }
            _handleToObjectTable.Clear();
            handle.RemoveAllObjects();
        }

        /// <summary>
        /// Captures a snapshot of the map view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="type">Type of file format.</param>
        /// <param name="quality">An integer value representing the quality for encoding from 1 to 100.</param>
        /// <param name="path">A string representing the file path for a snapshot.</param>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the value is invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a native operation failed to allocate memory and connect to the service.</exception>
        public void CaptureSnapshot(SnapshotType type, int quality, string path)
        {
            var err = Interop.ViewSnapshot.ViewCaptureSnapshot(handle, (Interop.ViewSnapshotFormatType)type, quality, path);
            err.ThrowIfFailed("Failed to create snapshot for the view");
        }

        private void SetGestureEventCallback()
        {
            if (_gestureEventCallback == null)
            {
                _gestureEventCallback = (type, eventData, userData) =>
                {
                    if (type != Interop.ViewEventType.Gesture) return;
                    var eventArg = new MapGestureEventArgs(eventData);
                    switch (eventArg.GestureType)
                    {
                        case GestureType.Scroll: _scrolledEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.Zoom: _twoFingerZoomedEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.Click: _clickedEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.DoubleClick: _doubleClickedEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.TwoFingerClick: _twoFingerClickedEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.Rotation: _twoFingerRotatedEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.LongPress: _longPressedEventHandler?.Invoke(this, eventArg); break;
                    }
                };
                handle.SetEventCb(Interop.ViewEventType.Gesture, _gestureEventCallback, IntPtr.Zero);
                Log.Info(string.Format("Gesture event callback is set"));
            }
        }

        private void UnsetGestureEventCallback()
        {
            if (_scrolledEventHandler != null || _twoFingerZoomedEventHandler != null
                || _clickedEventHandler != null || _doubleClickedEventHandler != null
                || _twoFingerClickedEventHandler != null || _twoFingerRotatedEventHandler != null
                || _longPressedEventHandler != null)
            {
                return;
            }

            handle.UnsetEventCb(Interop.ViewEventType.Gesture);
            _gestureEventCallback = null;
            Log.Info(string.Format("Gesture event callback is unset"));
        }

        private void SetObjectEventCallback()
        {
            if (_objectEventCallback == null)
            {
                _objectEventCallback = (type, eventData, userData) =>
                {
                    if (type != Interop.ViewEventType.Object) return;
                    var eventArg = new Interop.ObjectEventDataHandle(eventData);
                    switch (eventArg.GestureType)
                    {
                        case Interop.ViewGesture.Click:
                        {
                            var mapObject = _handleToObjectTable[eventArg.ViewObject];
                            mapObject?.HandleClickedEvent();
                            break;
                        }
                    }
                };
                handle.SetEventCb(Interop.ViewEventType.Object, _objectEventCallback, IntPtr.Zero);
                Log.Info(string.Format("Object event callback is set"));
            }
        }

        private void SetViewReadyEventCallback()
        {
            if (_viewReadyEventCallback == null)
            {
                _viewReadyEventCallback = (type, eventData, userData) =>
                {
                    _viewReadyEventHandler?.Invoke(this, EventArgs.Empty);
                };
                handle.SetEventCb(Interop.ViewEventType.Ready, _viewReadyEventCallback, IntPtr.Zero);
                Log.Info(string.Format("ViewReady event callback is set"));
            }
        }

        private void UnsetViewReadyEventCallback()
        {
            if (_viewReadyEventHandler == null)
            {
                handle.UnsetEventCb(Interop.ViewEventType.Ready);
                _viewReadyEventCallback = null;
                Log.Info(string.Format("ViewReady event callback is unset"));
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _service.Dispose();
                }
                handle.Dispose();
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all the resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
