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
using Tizen.System;
using Tizen.Common;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Class for the Tizen quickpanel client.
    /// </summary>
    /// <remarks>
    /// TizenShell.QuickPanelClient is a specialized class designed for handling interactions with the Quickpanel service that Tizen system GUI Application.
    /// Through this class, we can conveniently retrieve various states of the Quickpanel service and make changes to specific states when necessary.
    /// </remarks>
    /// <since_tizen> 8 </since_tizen>
    public class QuickPanelClient : IDisposable
    {
        TizenShell _tzsh;
        SafeHandles.QuickPanelClientHandle _tzshQpClient;
        int _tzshWin;
        bool disposed = false;
        WindowOrientation _screenOrientation = WindowOrientation.Portrait;

        int _visibleEventType;
        IntPtr _visibleEventHandler;
        Interop.QuickPanelClient.QuickPanelEventCallback _onVisibleChanged;
        event EventHandler<QuickPanelVisibility> _visibleChanged;

        /// <summary>
        /// The constructor of QuickPanelClass class.
        /// </summary>
        /// <remarks>
        /// This constructor creates a new Quickpanel Client handle. with this handle, we can interact with the quickpanel service.
        /// This handle needs the TizenShell handle first.
        /// </remarks>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window provider for the quickpanel service.</param>
        /// <param name="type">The type of quickpanel service.</param>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when there is not enough memory (to allocate).</exception>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when an argument is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public QuickPanelClient(TizenShell tzShell, IWindowProvider win, QuickPanelCategory type)
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
            _tzshWin = WindowSystem.Interop.EcoreWl2.GetWindowId(win.WindowHandle);
            _tzshQpClient = Interop.QuickPanelClient.CreateWithType(_tzsh.SafeHandle, (uint)_tzshWin, type);
            if (_tzshQpClient.IsInvalid)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ThrowIfError(err);
            }

            Information.TryGetValue("http://tizen.org/feature/screen.width", out width);
            Information.TryGetValue("http://tizen.org/feature/screen.height", out height);
            if (width > height) _screenOrientation = (WindowOrientation)(90);
        }

        /// <summary>
        /// Disposes the resources of the QuickPanelClient class.
        /// </summary>
        /// <exception cref="MemberAccessException">Thrown when private memeber is a corrupted.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _tzshQpClient?.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Emits the event when the visible state of the quickpanel service window is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<QuickPanelVisibility> VisibleChanged
        {
            add
            {
                if (_visibleChanged == null)
                {
                    if (_visibleEventType == 0)
                    {
                        _visibleEventType = Interop.TizenShell.NewEventType(_tzsh.SafeHandle, Interop.QuickPanelClient.EventStringVisible);
                    }
                    _onVisibleChanged = OnVisibleChanged;
                    _visibleEventHandler = Interop.QuickPanelClient.AddEventHandler(_tzshQpClient, _visibleEventType, _onVisibleChanged, IntPtr.Zero);
                    if (_visibleEventHandler == IntPtr.Zero)
                    {
                        int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                        _tzsh.ThrowIfError(err);
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
                    _tzsh.ThrowIfError(_res);
                }
            }
        }

        int _orientationEventType;
        IntPtr _orientationEventHandler;
        Interop.QuickPanelClient.QuickPanelEventCallback _onOrientationChanged;
        event EventHandler<WindowOrientation> _orientationChanged;

        /// <summary>
        /// Emits the event when the orientation of the quickpanel service window is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<WindowOrientation> OrientationChanged
        {
            add
            {
                if (_orientationChanged == null)
                {
                    if (_orientationEventType == 0)
                    {
                        _orientationEventType = Interop.TizenShell.NewEventType(_tzsh.SafeHandle, Interop.QuickPanelClient.EventStringOrientation);
                    }
                    _onOrientationChanged = OnOrientationChanged;
                    _orientationEventHandler = Interop.QuickPanelClient.AddEventHandler(_tzshQpClient, _orientationEventType, _onOrientationChanged, IntPtr.Zero);
                    if (_orientationEventHandler == IntPtr.Zero)
                    {
                        int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                        _tzsh.ThrowIfError(err);
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
                    _tzsh.ThrowIfError(_res);
                }
            }
        }

        event EventHandler<int> _rotationChanged;

        /// <summary>
        /// Emits the event when the rotation(orientation) of the quickpanel service window is changed.
        /// </summary>
        /// <remarks>
        /// The value of the event argument represents the rotation angle in degrees.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <since_tizen> 12 </since_tizen>
        public event EventHandler<int> RotationChanged
        {
            add
            {
                if(_rotationChanged == null)
                {
                    OrientationChanged += OnRotationChanged;
                }
                _rotationChanged += value;
            }
            remove
            {
                _rotationChanged -= value;
                if(_rotationChanged == null)
                {
                    OrientationChanged -= OnRotationChanged;
                }
            }
        }

        void OnRotationChanged(object sender, WindowOrientation e)
        {
            _rotationChanged?.Invoke(sender, (int)e);
        }

        /// <summary>
        /// Enumeration for orientation state of quickpanel service window.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        enum OrientationState
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

        WindowOrientation ConvertOrientation(OrientationState state)
        {
            if (_screenOrientation == WindowOrientation.Portrait)
            {
                if (state == OrientationState.Angle_90)
                {
                    return WindowOrientation.Landscape;
                }
                else if (state == OrientationState.Angle_180)
                {
                    return WindowOrientation.PortraitInverse;
                }
                else if (state == OrientationState.Angle_270)
                {
                    return WindowOrientation.LandscapeInverse;
                }
                else
                {
                    return WindowOrientation.Portrait;
                }
            }
            else
            {
                if (state == OrientationState.Angle_90)
                {
                    return WindowOrientation.Portrait;
                }
                else if (state == OrientationState.Angle_180)
                {
                    return WindowOrientation.LandscapeInverse;
                }
                else if (state == OrientationState.Angle_270)
                {
                    return WindowOrientation.PortraitInverse;
                }
                else
                {
                    return WindowOrientation.Landscape;
                }
            }
        }

        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        void OnVisibleChanged(int type, IntPtr ev_info, IntPtr data)
        {
            int res;
            int state;

            res = Interop.QuickPanelClient.GetEventVisible(ev_info, out state);
            _tzsh.ThrowIfError(res);

            _visibleChanged?.Invoke(this, (QuickPanelVisibility)state);
        }

        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        void OnOrientationChanged(int type, IntPtr ev_info, IntPtr data)
        {
            int res;
            int state;
            WindowOrientation orientation;

            res = Interop.QuickPanelClient.GetEventOrientation(ev_info, out state);
            _tzsh.ThrowIfError(res);

            orientation = ConvertOrientation((OrientationState)state);

            _orientationChanged?.Invoke(this, orientation);
        }

        /// <summary>
        /// Gets the visible state of the quickpanel.
        /// </summary>
        /// <remarks>
        /// Retrieves the visible state of the Quickpanel Service.
        /// This visible state indicates whether or not the Quickpanel Service window is displayed at the time of invocation.
        /// </remarks>
        /// <returns>The visible state of the quickpanel service window.</returns>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <since_tizen> 8 </since_tizen>
        public QuickPanelVisibility Visibility
        {
            get
            {
                return GetVisibility();
            }
        }

        QuickPanelVisibility GetVisibility()
        {
            int res;
            int vis;

            res = Interop.QuickPanelClient.GetVisible(_tzshQpClient, out vis);

            _tzsh.ThrowIfError(res);

            return (QuickPanelVisibility)vis;
        }

        /// <summary>
        /// Gets or sets the window's scrollable state of the quickpanel service window.
        /// </summary>
        /// <remarks>
        /// Retrieves or Changes the scrollable state of the Quickpanel Service window.
        /// The scrollableState determines whether the Quickpanel Service window is scrollable or not.
        /// And the scrollableState can be affect the visibility of the Quickpanel Service window.
        /// </remarks>
        /// <returns>The scrollable state of the quickpanel service window.</returns>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <since_tizen> 8 </since_tizen>
        public QuickPanelScrollMode ScrollMode
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

        QuickPanelScrollMode GetScrollable()
        {
            int res;
            int scroll;

            res = Interop.QuickPanelClient.GetScrollableState(_tzshQpClient, out scroll);

            _tzsh.ThrowIfError(res);

            return (QuickPanelScrollMode)scroll;
        }

        void SetScrollable(QuickPanelScrollMode scroll)
        {
            int res;

            res = Interop.QuickPanelClient.SetScrollableState(_tzshQpClient, scroll);

            _tzsh.ThrowIfError(res);
        }

        /// <summary>
        /// Gets the current orientation of the quickpanel service window.
        /// </summary>
        /// <remarks>
        /// Retrieves the orientation of the Quickpanel Service.
        /// This orientation value indicates the current angle of the Quickpanel Service window.
        /// </remarks>
        /// <returns>The orientation of the quickpanel service window.</returns>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <since_tizen> 8 </since_tizen>
        public WindowOrientation Orientation
        {
            get
            {
                return GetOrientation();
            }
        }

        WindowOrientation GetOrientation()
        {
            int res;
            int state;
            WindowOrientation orientation;

            res = Interop.QuickPanelClient.GetOrientation(_tzshQpClient, out state);

            _tzsh.ThrowIfError(res);
            orientation = ConvertOrientation((OrientationState)state);

            return orientation;
        }

        /// <summary>
        /// Shows the quickpanel service window if it is currently scrollable.
        /// </summary>
        /// <remarks>
        /// Change the visible state of the quickpanel service window to shown if it is currently scrollable.
        /// If the quickpanel is not scrollable, nothing will happen.
        /// </remarks>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void Show()
        {
            int res;

            res = Interop.QuickPanelClient.Show(_tzshQpClient);
            _tzsh.ThrowIfError(res);
        }

        /// <summary>
        /// Hides the quickpanel service window.
        /// </summary>
        /// <remarks>
        /// Change the visible state of the quickpanel service window to hidden.
        /// </remarks>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void Hide()
        {
            int res;

            res = Interop.QuickPanelClient.Hide(_tzshQpClient);
            _tzsh.ThrowIfError(res);
        }
    }
}
