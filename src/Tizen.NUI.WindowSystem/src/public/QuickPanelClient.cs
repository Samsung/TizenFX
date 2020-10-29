/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Collections.Generic;
using System.Text;
using Tizen.Applications.Exceptions;
using Tizen.System;

namespace Tizen.NUI.WindowSystem.Shell
{
    /// <summary>
    /// Class for the Tizen quickpanel client.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class QuickPanelClient : IDisposable
    {
        private TizenShell _tzsh;
        private IntPtr _tzshQpClient;
        private int _tzshWin;
        private bool disposed = false;
        private bool isDisposeQueued = false;
        private Window.WindowOrientation _screenOrientation = Window.WindowOrientation.Portrait;

        private int _visibleEventType;
        private IntPtr _visibleEventHandler;
        private Interop.QuickPanelClient.QuickPanelEventCallback _onVisibleChanged;
        private event EventHandler<VisibleState> _visibleChanged;
        /// <summary>
        /// Emits the event when the visible state of the quickpanel service window is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<VisibleState> VisibleChanged
        {
            add
            {
                if (_visibleChanged == null)
                {
                    if (_visibleEventType == 0)
                    {
                        _visibleEventType = Interop.TizenShell.NewEventType(_tzsh.GetNativeHandle(), Interop.QuickPanelClient.EventStringVisible);
                    }
                    _onVisibleChanged = OnVisibleChanged;
                    _visibleEventHandler = Interop.QuickPanelClient.AddEventHandler(_tzshQpClient, _visibleEventType, _onVisibleChanged, IntPtr.Zero);
                    if (_visibleEventHandler == IntPtr.Zero)
                    {
                        int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                        _tzsh.ErrorCodeThrow(err);
                    }
                }
                _visibleChanged += value;
            }
            remove
            {
                int _res;
                _visibleChanged -= value;
                if (_visibleChanged == null)
                {
                    _res = Interop.QuickPanelClient.DelEventHandler(_tzshQpClient, _visibleEventHandler);
                    _tzsh.ErrorCodeThrow(_res);
                }
            }
        }

        private int _orientationEventType;
        private IntPtr _orientationEventHandler;
        private Interop.QuickPanelClient.QuickPanelEventCallback _onOrientationChanged;
        private event EventHandler<Window.WindowOrientation> _orientationChanged;
        /// <summary>
        /// Emits the event when the orientation of the quickpanel service window is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<Window.WindowOrientation> OrientationChanged
        {
            add
            {
                if (_orientationChanged == null)
                {
                    if (_orientationEventType == 0)
                    {
                        _orientationEventType = Interop.TizenShell.NewEventType(_tzsh.GetNativeHandle(), Interop.QuickPanelClient.EventStringOrientation);
                    }
                    _onOrientationChanged = OnOrientationChanged;
                    _orientationEventHandler = Interop.QuickPanelClient.AddEventHandler(_tzshQpClient, _orientationEventType, _onOrientationChanged, IntPtr.Zero);
                    if (_orientationEventHandler == IntPtr.Zero)
                    {
                        int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                        _tzsh.ErrorCodeThrow(err);
                    }
                }
                _orientationChanged += value;
            }
            remove
            {
                int _res;
                _orientationChanged -= value;
                if (_orientationChanged == null)
                {
                    _res = Interop.QuickPanelClient.DelEventHandler(_tzshQpClient, _orientationEventHandler);
                    _tzsh.ErrorCodeThrow(_res);
                }
            }
        }

        /// <summary>
        /// Enumeration for type of quickpanel service window.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public enum Types
        {
            /// <summary>
            /// Unknown type. There is no quickpanel service.
            /// </summary>
            Unknown = 0x0,
            /// <summary>
            /// System default type.
            /// </summary>
            SystemDefault = 0x1,
            /// <summary>
            /// Context menu type.
            /// </summary>
            ContextMenu = 0x2,
            /// <summary>
            /// Apps menu type.
            /// </summary>
            AppsMenu = 0x3,
        }

        /// <summary>
        /// Enumeration for visible state of quickpanel service window.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public enum VisibleState
        {
            /// <summary>
            /// Unknown state. There is no quickpanel service.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Unknown = 0x0,
            /// <summary>
            /// Shown state.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Shown = 0x1,
            /// <summary>
            /// Hidden state.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Hidden = 0x2,
        }

        /// <summary>
        /// Enumeration for scrollable state of quickpanel service window.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public enum ScrollableState
        {
            /// <summary>
            /// Unknown state. There is no quickpanel service.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Unknown = 0x0,
            /// <summary>
            /// Scrollable state.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Set = 0x1,
            /// <summary>
            /// Not scrollable state.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Unset = 0x2,
            /// <summary>
            /// Retain scrollable state.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Retain = 0x3,
        }

        /// <summary>
        /// Enumeration for orientation state of quickpanel service window.
        /// </summary>
        private enum OrientationState
        {
            /// <summary>
            /// Unknown state. There is no quickpanel service.
            /// </summary>
            Unknown = 0x0,
            /// <summary>
            /// Radius 0
            /// </summary>
            Angle_0 = 0x1,
            /// <summary>
            /// 90
            /// </summary>
            Angle_90 = 0x2,
            /// <summary>
            /// 180
            /// </summary>
            Angle_180 = 0x3,
            /// <summary>
            /// 270
            /// </summary>
            Angle_270 = 0x4,
        }

        /// <summary>
        /// Creates a new Quickpanel Client handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window to provide service of the quickpanel.</param>
        /// <param name="type">The type of quickpanel service.</param>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public QuickPanelClient(TizenShell tzShell, Window win, Types type)
        {
            int width = 0, height = 0;
            if (tzShell == null)
            {
                throw new ArgumentNullException((string)"tzShell");
            }
            if (tzShell.GetNativeHandle() == IntPtr.Zero)
            {
                throw new ArgumentException("tzShell is not initialized.");
            }
            if (win == null)
            {
                throw new ArgumentNullException((string)"win");
            }

            _tzsh = tzShell;
            _tzshWin = win.GetNativeId();
            _tzshQpClient = Interop.QuickPanelClient.CreateWithType(_tzsh.GetNativeHandle(), (IntPtr)_tzshWin, (int)type);
            if (_tzshQpClient == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ErrorCodeThrow(err);
            }

            Information.TryGetValue("http://tizen.org/feature/screen.width", out width);
            Information.TryGetValue("http://tizen.org/feature/screen.height", out height);
            if (width > height) _screenOrientation = Window.WindowOrientation.Landscape;
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        ~QuickPanelClient()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <exception cref="MemberAccessException">Thrown when private memeber is a corrupted.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void Dispose()
        {
            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                GC.SuppressFinalize(this);
            }
        }

        /// <inheritdoc/>
        protected virtual void Dispose(DisposeTypes type)
        {
            int res;
            if (!disposed)
            {
                if (_tzshQpClient != IntPtr.Zero)
                {
                    res = Interop.QuickPanelClient.Destroy(_tzshQpClient);
                    try
                    {
                        _tzsh.ErrorCodeThrow(res);
                    }
                    catch (ArgumentException)
                    {
                        throw new MemberAccessException("QuickPanelClient is a corrupted");
                    }
                    _tzshQpClient = IntPtr.Zero;
                }
                disposed = true;
            }
        }

        private Window.WindowOrientation ConvertOrientation(OrientationState state)
        {
            if (_screenOrientation == Window.WindowOrientation.Portrait)
            {
                if (state == OrientationState.Angle_90)
                {
                    return Window.WindowOrientation.Landscape;
                }
                else if (state == OrientationState.Angle_180)
                {
                    return Window.WindowOrientation.PortraitInverse;
                }
                else if (state == OrientationState.Angle_270)
                {
                    return Window.WindowOrientation.LandscapeInverse;
                }
                else
                {
                    return Window.WindowOrientation.Portrait;
                }
            }
            else
            {
                if (state == OrientationState.Angle_90)
                {
                    return Window.WindowOrientation.Portrait;
                }
                else if (state == OrientationState.Angle_180)
                {
                    return Window.WindowOrientation.LandscapeInverse;
                }
                else if (state == OrientationState.Angle_270)
                {
                    return Window.WindowOrientation.PortraitInverse;
                }
                else
                {
                    return Window.WindowOrientation.Landscape;
                }
            }
        }

        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        private void OnVisibleChanged(int type, IntPtr ev_info, IntPtr data)
        {
            int res;
            int state;

            res = Interop.QuickPanelClient.GetEventVisible(ev_info, out state);
            _tzsh.ErrorCodeThrow(res);

            _visibleChanged?.Invoke(this, (VisibleState)state);
        }

        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        private void OnOrientationChanged(int type, IntPtr ev_info, IntPtr data)
        {
            int res;
            int state;
            Window.WindowOrientation orientation;

            res = Interop.QuickPanelClient.GetEventOrientation(ev_info, out state);
            _tzsh.ErrorCodeThrow(res);

            orientation = ConvertOrientation((OrientationState)state);

            _orientationChanged?.Invoke(this, orientation);
        }

        /// <summary>
        /// Gets the visible state of the quickpanel.
        /// </summary>
        /// <returns>The visible state of the quickpanel service window.</returns>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <since_tizen> 8 </since_tizen>
        public VisibleState Visible
        {
            get
            {
                return GetVisible();
            }
        }

        private VisibleState GetVisible()
        {
            int res;
            int vis;

            res = Interop.QuickPanelClient.GetVisible(_tzshQpClient, out vis);

            _tzsh.ErrorCodeThrow(res);

            return (VisibleState)vis;
        }

        /// <summary>
        /// Gets or sets the window's scrollable state of the quickpanel service window.
        /// </summary>
        /// <returns>The scrollable state of the quickpanel service window.</returns>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <since_tizen> 8 </since_tizen>
        public ScrollableState Scrollable
        {
            get
            {
                return GetScrollable();
            }
            set
            {
                SetScrollable(value);
            }
        }

        private ScrollableState GetScrollable()
        {
            int res;
            int scroll;

            res = Interop.QuickPanelClient.GetScrollableState(_tzshQpClient, out scroll);

            _tzsh.ErrorCodeThrow(res);

            return (ScrollableState)scroll;
        }

        private void SetScrollable(ScrollableState scroll)
        {
            int res;

            res = Interop.QuickPanelClient.SetScrollableState(_tzshQpClient, (int)scroll);

            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Gets the current orientation of the quickpanel service window.
        /// </summary>
        /// <returns>The orientation of the quickpanel service window.</returns>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <since_tizen> 8 </since_tizen>
        public Window.WindowOrientation Orientation
        {
            get
            {
                return GetOrientation();
            }
        }

        private Window.WindowOrientation GetOrientation()
        {
            int res;
            int state;
            Window.WindowOrientation orientation;

            res = Interop.QuickPanelClient.GetOrientation(_tzshQpClient, out state);

            _tzsh.ErrorCodeThrow(res);
            orientation = ConvertOrientation((OrientationState)state);

            return orientation;
        }

        /// <summary>
        /// Shows the quickpanel service window if it is currently scrollable.
        /// </summary>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void Show()
        {
            int res;

            res = Interop.QuickPanelClient.Show(_tzshQpClient);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Hides the quickpanel service window.
        /// </summary>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void Hide()
        {
            int res;

            res = Interop.QuickPanelClient.Hide(_tzshQpClient);
            _tzsh.ErrorCodeThrow(res);
        }
    }
}
