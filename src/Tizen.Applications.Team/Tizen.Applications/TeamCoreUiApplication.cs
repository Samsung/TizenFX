/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using Tizen.Applications;
using Tizen.Applications.CoreBackend;
using Tizen.NUI;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents a base class for Team UI applications that own a NUI <see cref="Window"/> and expose
    /// <see cref="Resumed"/> and <see cref="Paused"/> lifecycle events.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TeamCoreUiApplication : TeamCoreApplication, IUIApplication
    {
        /// <summary>
        /// Initializes the <see cref="TeamCoreUiApplication"/> class.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TeamCoreUiApplication(TeamCoreBackend backend) : base(backend)
        {
        }

        /// <summary>
        /// Gets the default window of this application.
        /// </summary>
        /// <returns>The default <see cref="Window"/> associated with this application.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window GetDefaultWindow()
        {
            return ((TeamUICoreBackend)Backend).GetDefaultWindow();
        }

        /// <summary>
        /// Occurs before the application is created.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler PreCreated;

        /// <summary>
        /// Occurs whenever the application is resumed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Resumed;

        /// <summary>
        /// Occurs whenever the application is paused.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Paused;

        /// <summary>
        /// Adds a delegate to be called when the main loop is idle.
        /// </summary>
        /// <param name="func">The delegate to call.</param>
        /// <returns><c>true</c> if the delegate was added successfully; otherwise, <c>false</c>.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AddIdle(Delegate func)
        {
            return false;
        }

        /// <summary>
        /// Removes a previously added idle delegate.
        /// </summary>
        /// <param name="func">The delegate to remove.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveIdle(Delegate func)
        {
        }

        /// <summary>
        /// Runs the Team UI application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Run(string[] args)
        {
            Backend.AddEventHandler(EventType.Resumed, ResumeHandler);
            Backend.AddEventHandler(EventType.Paused, PauseHandler);
            Backend.AddEventHandler(EventType.PreCreated, OnPreCreate);

            base.Run(args);
        }

        /// <summary>
        /// Invoked before the application is created. Raises the <see cref="PreCreated"/> event.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnPreCreate()
        {
            PreCreated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Invoked when the application is resumed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnResume()
        {

        }

        /// <summary>
        /// Invoked when the application is resumed. Raises the <see cref="Resumed"/> event after OnResume()
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void ResumeHandler()
        {
            OnResume();
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Invoked when the application is paused. Raises the <see cref="Paused"/> event.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnPause()
        {
        }

        /// <summary>
        /// Invoked when the application is paused. Raises the <see cref="Paused"/> event after OnPause()
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void PauseHandler()
        {
            OnPause();
            Paused?.Invoke(this, EventArgs.Empty);
        }

        #region IUIApplication Interface

        /// <summary>
        /// Gets the backend associated with this application as <see cref="IUICoreBackend"/>.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        IUICoreBackend IUIApplication.Backend => (TeamUICoreBackend)_backend;

        /// <summary>
        /// Gets the application information as <see cref="IApplicationInfo"/>.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        IApplicationInfo IUIApplication.ApplicationInfo => ApplicationInfo;

        /// <summary>
        /// Gets the directory information as <see cref="IDirectoryInfo"/>.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        IDirectoryInfo IUIApplication.DirectoryInfo => DirectoryInfo;

        /// <summary>
        /// Gets the default window as <see cref="IUIApplication"/> interface.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        TWindow IUIApplication.GetDefaultWindow<TWindow>() => (TWindow)(object)GetDefaultWindow();

        // Methods - explicit interface implementation
        /// <summary>
        /// Invoked before the application is created.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnPreCreate() => OnPreCreate();

        /// <summary>
        /// Invoked when the application is created.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnCreate() => OnCreate();

        /// <summary>
        /// Invoked when the application is terminated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnTerminate() => OnTerminate();

        /// <summary>
        /// Invoked when the application is paused.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnPause() => OnPause();

        /// <summary>
        /// Invoked when the application is resumed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnResume() => OnResume();

        /// <summary>
        /// Invoked when the application receives an app control request.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnAppControlReceived(AppControlReceivedEventArgs e) => OnAppControlReceived(e);

        /// <summary>
        /// Invoked when a low memory event is reported by the system.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnLowMemory(LowMemoryEventArgs e) => OnLowMemory(e);

        /// <summary>
        /// Invoked when a low battery event is reported by the system.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnLowBattery(LowBatteryEventArgs e) => OnLowBattery(e);

        /// <summary>
        /// Invoked when the system language is changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnLocaleChanged(LocaleChangedEventArgs e) => OnLocaleChanged(e);

        /// <summary>
        /// Invoked when the region format is changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnRegionFormatChanged(RegionFormatChangedEventArgs e) => OnRegionFormatChanged(e);

        /// <summary>
        /// Invoked when the device orientation is changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnDeviceOrientationChanged(DeviceOrientationEventArgs e) => OnDeviceOrientationChanged(e);

        /// <summary>
        /// Invoked when the system time zone is changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IUIApplication.OnTimeZoneChanged(TimeZoneChangedEventArgs e) => OnTimeZoneChanged(e);

        #endregion
    }
}
