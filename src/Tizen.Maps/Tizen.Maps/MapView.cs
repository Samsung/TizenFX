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
    /// Map View
    /// </summary>
    public class MapView : Layout, IDisposable
    {
        internal Interop.ViewHandle handle;
        private MapService _service;

        private Dictionary<IntPtr, MapObject> _handleToObjectTable = new Dictionary<IntPtr, MapObject>();

        private Interop.ViewOnEventCallback _gestureEventCallback;
        private Interop.ViewOnEventCallback _objectEventCallback;
        private Interop.ViewOnEventCallback _viewReadyEventCallback;

        private event EventHandler<MapGestureEventArgs> _scrolledEventHandler;
        private event EventHandler<MapGestureEventArgs> _zoomedEventHandler;
        private event EventHandler<MapGestureEventArgs> _tappedEventHandler;
        private event EventHandler<MapGestureEventArgs> _doubleTappedEventHandler;
        private event EventHandler<MapGestureEventArgs> _twoFingerTappedEventHandler;
        private event EventHandler<MapGestureEventArgs> _rotatedEventHandler;
        private event EventHandler<MapGestureEventArgs> _longPressedEventHandler;
        private event EventHandler _viewReadyEventHandler;

        /// <summary>
        /// Creates the View and link it to the instance of map service
        /// </summary>
        /// <param name="parent">The evas object to be drawn</param>
        /// <param name="service">Map service</param>
        public MapView(EvasObject parent, MapService service) : base(parent)
        {
            handle = new Interop.ViewHandle(service.handle, this);
            _service = service;

            // We need to keep Gesture Tap event enabled for object event to work
            handle.SetGestureEnabled(Interop.ViewGesture.Tap, true);
            SetObjectEventCallback();
        }

        /// <summary>
        /// Scrolled gesture event
        /// </summary>
        public event EventHandler<MapGestureEventArgs> Scrolled
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.Scroll, true);
                _scrolledEventHandler += value;
            }
            remove
            {
                _scrolledEventHandler -= value;
                if (_scrolledEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.Scroll, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// ZoomChanged gesture event
        /// </summary>
        public event EventHandler<MapGestureEventArgs> ZoomChanged
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.Zoom, true);
                _zoomedEventHandler += value;
            }
            remove
            {
                _zoomedEventHandler -= value;
                if (_zoomedEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.Zoom, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// Clicked gesture event
        /// </summary>
        public event EventHandler<MapGestureEventArgs> Clicked
        {
            add
            {
                SetGestureEventCallback();
                //handle.SetGestureEnabled(Interop.ViewGesture.Tap, true);
                _tappedEventHandler += value;
            }
            remove
            {
                _tappedEventHandler -= value;
                if (_tappedEventHandler == null)
                {
                    //handle.SetGestureEnabled(Interop.ViewGesture.Tap, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// DoubleClicked gesture event
        /// </summary>
        public event EventHandler<MapGestureEventArgs> DoubleClicked
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.DoubleTap, true);
                _doubleTappedEventHandler += value;
            }
            remove
            {
                _doubleTappedEventHandler -= value;
                if (_doubleTappedEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.DoubleTap, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// TwoFingerPressed gesture event
        /// </summary>
        public event EventHandler<MapGestureEventArgs> TwoFingerPressed
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.TwoFingerTap, true);
                _twoFingerTappedEventHandler += value;
            }
            remove
            {
                _twoFingerTappedEventHandler -= value;
                if (_twoFingerTappedEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.TwoFingerTap, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// Rotated gesture event
        /// </summary>
        public event EventHandler<MapGestureEventArgs> Rotated
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.Rotate, true);
                _rotatedEventHandler += value;
            }
            remove
            {
                _rotatedEventHandler -= value;
                if (_rotatedEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.Rotate, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// LongPressed gesture event
        /// </summary>
        public event EventHandler<MapGestureEventArgs> LongPressed
        {
            add
            {
                SetGestureEventCallback();
                handle.SetGestureEnabled(Interop.ViewGesture.LongPress, true);
                _longPressedEventHandler += value;
            }
            remove
            {
                _longPressedEventHandler -= value;
                if (_longPressedEventHandler == null)
                {
                    handle.SetGestureEnabled(Interop.ViewGesture.LongPress, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        /// <summary>
        /// ViewReady gesture event
        /// </summary>
        public event EventHandler ViewReady
        {
            add
            {
                SetViewReadyEventCallback();
                _viewReadyEventHandler += value;
            }
            remove
            {
                _viewReadyEventHandler -= value;
                UnsetGestureEventCallback();
            }
        }

        /// <summary>
        /// Map View's current zoom level
        /// </summary>
        public int ZoomLevel
        {
            get
            {
                return handle.ZoomLevel;
            }
            set
            {
                handle.ZoomLevel = value;
            }
        }

        /// <summary>
        /// Minimum zoom level for map view
        /// </summary>
        public int MinimumZoomLevel
        {
            get
            {
                return handle.MinimumZoomLevel;
            }
            set
            {
                handle.MinimumZoomLevel = value;
            }
        }

        /// <summary>
        /// Maximum zoom level for map view
        /// </summary>
        public int MaximumZoomLevel
        {
            get
            {
                return handle.MaximumZoomLevel;
            }
            set
            {
                handle.MaximumZoomLevel = value;
            }
        }

        /// <summary>
        /// orientation on the View [0 ~ 360 degrees]
        /// </summary>
        public double Orientation
        {
            get
            {
                return handle.Orientation;
            }
            set
            {
                handle.Orientation = value;
            }
        }

        /// <summary>
        /// Map view type (theme)
        /// </summary>
        public MapTypes MapType
        {
            get
            {
                return (MapTypes)handle.MapType;
            }
            set
            {
                handle.MapType = (Interop.ViewType)value;
            }
        }

        /// <summary>
        /// Indicates whether the map should show the 3D buildings layer
        /// </summary>
        public bool BuildingsEnabled
        {
            get
            {
                return handle.BuildingsEnabled;
            }
            set
            {
                handle.BuildingsEnabled = value;
            }
        }

        /// <summary>
        /// Indicates whether the map should show the traffic layer
        /// </summary>
        public bool TrafficEnabled
        {
            get
            {
                return handle.TrafficEnabled;
            }
            set
            {
                handle.TrafficEnabled = value;
            }
        }

        /// <summary>
        /// Indicates whether the map should show the public transit layer
        /// </summary>
        public bool PublicTransitEnabled
        {
            get
            {
                return handle.PublicTransitEnabled;
            }
            set
            {
                handle.PublicTransitEnabled = value;
            }
        }

        /// <summary>
        /// Gets whether the scale-bar is enabled or not
        /// </summary>
        public bool ScalebarEnabled
        {
            get
            {
                return handle.ScalebarEnabled;
            }
            set
            {
                handle.ScalebarEnabled = value;
            }
        }

        /// <summary>
        /// Map view's language
        /// </summary>
        public string Language
        {
            get
            {
                return handle.Language;
            }
            set
            {
                handle.Language = value;
            }
        }

        /// <summary>
        /// Geographical coordinates for map view's center
        /// </summary>
        public Geocoordinates Center
        {
            get
            {
                return new Geocoordinates(handle.Center);
            }
            set
            {
                handle.Center = value.handle;
            }
        }

        /// <summary>
        /// List of map object added to map view
        /// </summary>
        public IEnumerable<MapObject> Children
        {
            get
            {
                return _handleToObjectTable.Values;
            }
        }

        /// <summary>
        /// Changes geographical coordinates to screen coordinates
        /// </summary>
        /// <param name="coordinates">Geographical coordinates</param>
        /// <returns></returns>
        public Point GeolocationToScreen(Geocoordinates coordinates)
        {
            return handle.GeolocationToScreen(coordinates.handle);
        }

        /// <summary>
        /// Changes screen coordinates to geographical coordinates
        /// </summary>
        /// <param name="screenCoordinates">screen coordinates</param>
        /// <returns></returns>
        public Geocoordinates ScreenToGeolocation(Point screenCoordinates)
        {
            return new Geocoordinates(handle.ScreenToGeolocation(screenCoordinates));
        }

        /// <summary>
        /// Adds map object to map view
        /// </summary>
        /// <param name="child">map object to add</param>
        public void Add(MapObject child)
        {
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
        /// Removes map object from map view
        /// </summary>
        /// <param name="child">map object to remove</param>
        /// <remarks>Once removed, child object will be become invalid</remarks>
        public void Remove(MapObject child)
        {
            var objectHandle = child.GetHandle();
            if (_handleToObjectTable.Remove(objectHandle))
            {
                handle.RemoveObject(child.GetHandle());

                // The object handle will be released automatically by the View, once RemoveObject call is successful
                child.InvalidateMapObject();
            }
        }

        /// <summary>
        /// Removes all map objects from map view
        /// </summary>
        public void RemoveAll()
        {
            foreach (var child in _handleToObjectTable.Values)
            {
                child.InvalidateMapObject();
            }
            _handleToObjectTable.Clear();
            handle.RemoveAllObjects();
        }

        /// <summary>
        /// Captures a snapshot of the Map View
        /// </summary>
        /// <param name="type">type of file format</param>
        /// <param name="quality">quality for encoding (1~100) </param>
        /// <param name="path">The file path for snapshot</param>
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
                        case GestureType.Zoom: _zoomedEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.Tap: _tappedEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.DoubleTap: _doubleTappedEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.TwoFingerTap: _twoFingerTappedEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.Rotate: _rotatedEventHandler?.Invoke(this, eventArg); break;
                        case GestureType.LongPress: _longPressedEventHandler?.Invoke(this, eventArg); break;
                    }
                };
                handle.SetEventCb(Interop.ViewEventType.Gesture, _gestureEventCallback, IntPtr.Zero);
            }
        }

        private void UnsetGestureEventCallback()
        {
            if (_scrolledEventHandler != null || _zoomedEventHandler != null
                || _tappedEventHandler != null || _doubleTappedEventHandler != null
                || _twoFingerTappedEventHandler != null || _rotatedEventHandler != null
                || _longPressedEventHandler != null)
            {
                return;
            }

            handle.UnsetEventCb(Interop.ViewEventType.Gesture);
            _gestureEventCallback = null;
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
                        case Interop.ViewGesture.Tap:
                            {
                                var mapObject = _handleToObjectTable[eventArg.ViewObject];
                                mapObject?.HandleClickedEvent();
                                break;
                            }
                    }
                };
                handle.SetEventCb(Interop.ViewEventType.Object, _objectEventCallback, IntPtr.Zero);
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
            }
        }

        private void UnsetViewReadyEventCallback()
        {
            if (_viewReadyEventHandler == null)
            {
                handle.UnsetEventCb(Interop.ViewEventType.Ready);
                _viewReadyEventCallback = null;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
