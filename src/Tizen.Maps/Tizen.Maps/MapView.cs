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
    public class MapView : Layout
    {
        internal Interop.ViewHandle handle;
        private Interop.ServiceHandle _service;

        private HashSet<MapObject> _children = new HashSet<MapObject>();

        private Interop.View.ViewOnEventCallback _gestureEventCallback;
        private Interop.View.ViewOnEventCallback _objectEventCallback;
        private Interop.View.ViewOnEventCallback _viewReadyEventCallback;

        private event EventHandler<MapGestureEventArgs> _scrolledEventHandler;
        private event EventHandler<MapGestureEventArgs> _zoomedEventHandler;
        private event EventHandler<MapGestureEventArgs> _tappedEventHandler;
        private event EventHandler<MapGestureEventArgs> _doubleTappedEventHandler;
        private event EventHandler<MapGestureEventArgs> _twoFingerTappedEventHandler;
        private event EventHandler<MapGestureEventArgs> _rotatedEventHandler;
        private event EventHandler<MapGestureEventArgs> _longPressedEventHandler;
        private event EventHandler _viewReadyEventHandler;

        public MapView(EvasObject parent, MapService service) : base(parent)
        {
            IntPtr nativeHandle;
            var err = Interop.View.Create(service.handle, this, out nativeHandle);
            err.ThrowIfFailed("Failed to create native map view handle");

            handle = new Interop.ViewHandle(nativeHandle);
            _service = service.handle;

            Console.WriteLine($"MapView Created: ServiceHandle: {(IntPtr)_service}, ViewHandle: {(IntPtr)handle}");

            // We need to keep Gesture Tap event enabled for object event to work
            Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.Tap, true);
            SetObjectEventCallback();
        }

        public event EventHandler<MapGestureEventArgs> Scrolled
        {
            add
            {
                SetGestureEventCallback();
                Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.Scroll, true);
                _scrolledEventHandler += value;
            }
            remove
            {
                _scrolledEventHandler -= value;
                if (_scrolledEventHandler == null)
                {
                    Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.Scroll, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        public event EventHandler<MapGestureEventArgs> ZoomChanged
        {
            add
            {
                SetGestureEventCallback();
                Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.Zoom, true);
                _zoomedEventHandler += value;
            }
            remove
            {
                _zoomedEventHandler -= value;
                if (_zoomedEventHandler == null)
                {
                    Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.Zoom, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        public event EventHandler<MapGestureEventArgs> Clicked
        {
            add
            {
                SetGestureEventCallback();
                //Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.Tap, true);
                _tappedEventHandler += value;
            }
            remove
            {
                _tappedEventHandler -= value;
                if (_tappedEventHandler == null)
                {
                    //Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.Tap, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        public event EventHandler<MapGestureEventArgs> DoubleClicked
        {
            add
            {
                SetGestureEventCallback();
                Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.DoubleTap, true);
                _doubleTappedEventHandler += value;
            }
            remove
            {
                _doubleTappedEventHandler -= value;
                if (_doubleTappedEventHandler == null)
                {
                    Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.DoubleTap, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        public event EventHandler<MapGestureEventArgs> TwoFingerPressed
        {
            add
            {
                SetGestureEventCallback();
                Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.TwoFingerTap, true);
                _twoFingerTappedEventHandler += value;
            }
            remove
            {
                _twoFingerTappedEventHandler -= value;
                if (_twoFingerTappedEventHandler == null)
                {
                    Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.TwoFingerTap, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        public event EventHandler<MapGestureEventArgs> Rotated
        {
            add
            {
                SetGestureEventCallback();
                Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.Rotate, true);
                _rotatedEventHandler += value;
            }
            remove
            {
                _rotatedEventHandler -= value;
                if (_rotatedEventHandler == null)
                {
                    Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.Rotate, false);
                    UnsetGestureEventCallback();
                }
            }
        }

        public event EventHandler<MapGestureEventArgs> LongPressed
        {
            add
            {
                SetGestureEventCallback();
                Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.LongPress, true);
                _longPressedEventHandler += value;
            }
            remove
            {
                _longPressedEventHandler -= value;
                if (_longPressedEventHandler == null)
                {
                    Interop.View.SetGestureEnabled(handle, Interop.ViewGesture.LongPress, false);
                    UnsetGestureEventCallback();
                }
            }
        }

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

        public int ZoomLevel
        {
            get
            {
                int value;
                Interop.View.GetZoomLevel(handle, out value);
                return value;
            }
            set
            {
                Interop.View.SetZoomLevel(handle, value);
            }
        }

        public int MinimumZoomLevel
        {
            get
            {
                int value;
                Interop.View.GetMinZoomLevel(handle, out value);
                return value;
            }
            set
            {
                Interop.View.SetMinZoomLevel(handle, value);
            }
        }

        public int MaximumZoomLevel
        {
            get
            {
                int value;
                Interop.View.GetMaxZoomLevel(handle, out value);
                return value;
            }
            set
            {
                Interop.View.SetMaxZoomLevel(handle, value);
            }
        }

        public double Orientation
        {
            get
            {
                double value;
                Interop.View.GetOrientation(handle, out value);
                return value;
            }
            set
            {
                Interop.View.SetOrientation(handle, value);
            }
        }

        public MapTypes MapType
        {
            get
            {
                Interop.ViewType value;
                Interop.View.GetType(handle, out value);
                return (MapTypes)value;
            }
            set
            {
                Interop.View.SetType(handle, (Interop.ViewType)value);
            }
        }

        public bool BuildingsEnabled
        {
            get
            {
                bool value;
                Interop.View.GetBuildingsEnabled(handle, out value);
                return value;
            }
            set
            {
                Interop.View.SetBuildingsEnabled(handle, value);
            }
        }

        public bool TrafficEnabled
        {
            get
            {
                bool value;
                Interop.View.GetTrafficEnabled(handle, out value);
                return value;
            }
            set
            {
                Interop.View.SetTrafficEnabled(handle, value);
            }
        }

        public bool PublicTransitEnabled
        {
            get
            {
                bool value;
                Interop.View.GetPublicTransitEnabled(handle, out value);
                return value;
            }
            set
            {
                Interop.View.SetPublicTransitEnabled(handle, value);
            }
        }

        public bool ScalebarEnabled
        {
            get
            {
                bool value;
                Interop.View.GetScalebarEnabled(handle, out value);
                return value;
            }
            set
            {
                Interop.View.SetScalebarEnabled(handle, value);
            }
        }

        public string Language
        {
            get
            {
                string value;
                Interop.View.GetLanguage(handle, out value);
                return value;
            }
            set
            {
                Interop.View.SetLanguage(handle, value);
            }
        }

        public Geocoordinates Center
        {
            get
            {
                IntPtr coordinateHandle;
                Interop.View.GetCenter(handle, out coordinateHandle);
                return new Geocoordinates(coordinateHandle);
            }
            set
            {
                Geocoordinates geocoordinate = value;
                Interop.View.SetCenter(handle, geocoordinate.handle);
            }
        }

        public IEnumerable<MapObject> Children
        {
            get
            {
                return _children;
            }
        }

        public Point GeolocationToScreen(Geocoordinates coordinates)
        {
            Point screenCoordinates = new Point();
            Geocoordinates geocoordinate = coordinates;
            Interop.View.GeolocationToScreen(handle, geocoordinate.handle, out screenCoordinates.X, out screenCoordinates.Y);
            return screenCoordinates;
        }

        public Geocoordinates ScreenToGeolocation(Point screenCoordinates)
        {
            IntPtr coordinateHandle;
            Interop.View.ScreenToGeolocation(handle, screenCoordinates.X, screenCoordinates.Y, out coordinateHandle);
            return new Geocoordinates(coordinateHandle);
        }

        public void Add(MapObject child)
        {
            child.handle.ReleaseOwnership();
            _children.Add(child);
            child.AddToMapObjectTable();
            Interop.View.AddObject(handle, child.handle);
        }

        public void Remove(MapObject child)
        {
            _children.Remove(child);
            child.RemoveFromMapObjectTable();
            Interop.View.RemoveObject(handle, child.handle);
        }

        public void RemoveAll()
        {
            foreach (var child in _children)
            {
                child.RemoveFromMapObjectTable();
            }
            _children.Clear();
            Interop.View.RemoveAllObjects(handle);
        }

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
                    var eventArg = MapGestureEventArgs.Create(eventData);
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
                Interop.View.SetEventCb(handle, Interop.ViewEventType.Gesture, _gestureEventCallback, IntPtr.Zero);
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

            Interop.View.UnsetEventCb(handle, Interop.ViewEventType.Gesture);
            _gestureEventCallback = null;
        }

        private void SetObjectEventCallback()
        {
            if (_objectEventCallback == null)
            {
                _objectEventCallback = (type, eventData, userData) =>
                {
                    if (type != Interop.ViewEventType.Object) return;
                    var eventArg = MapObjectEventArgs.Create(eventData);
                    switch (eventArg.GestureType)
                    {
                        case GestureType.Tap: eventArg.ViewObject.HandleClickedEvent(); break;
                    }
                };
                Interop.View.SetEventCb(handle, Interop.ViewEventType.Object, _objectEventCallback, IntPtr.Zero);
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
                Interop.View.SetEventCb(handle, Interop.ViewEventType.Ready, _viewReadyEventCallback, IntPtr.Zero);
            }
        }

        private void UnsetViewReadyEventCallback()
        {
            if (_viewReadyEventHandler == null)
            {
                Interop.View.UnsetEventCb(handle, Interop.ViewEventType.Ready);
                _viewReadyEventCallback = null;
            }
        }
    }
}