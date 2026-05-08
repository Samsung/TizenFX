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
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// Defines the common contract for NUI-based applications.
    /// </summary>
    /// <remarks>
    /// This interface abstracts the shared functionality between <see cref="NUIApplication"/>
    /// and <see cref="TeamCoreUiApplication"/>, enabling polymorphic access to lifecycle events,
    /// directory/application information, idle management, and the default window.
    /// </remarks>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IUIApplication
    {
        private static IUIApplication s_current = null;

        /// <summary>
        /// Gets or sets the current application instance.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IUIApplication Current
        {
            get => s_current;
            set => s_current = value;
        }

        /// <summary>
        /// Gets the backend associated with this application.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        IUICoreBackend Backend { get; }

        /// <summary>
        /// Gets the application information.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        IApplicationInfo ApplicationInfo { get; }

        /// <summary>
        /// Gets the directory information.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        IDirectoryInfo DirectoryInfo { get; }

        /// <summary>
        /// Adds a delegate to be called when the main loop is idle.
        /// </summary>
        /// <param name="func">The delegate to call.</param>
        /// <returns><c>true</c> if the delegate was added successfully; otherwise, <c>false</c>.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AddIdle(Delegate func);

        /// <summary>
        /// Removes a previously added idle delegate.
        /// </summary>
        /// <param name="func">The delegate to remove.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void RemoveIdle(Delegate func);

        /// <summary>
        /// Gets the default window of the application.
        /// </summary>
        /// <returns>The default window.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        TWindow GetDefaultWindow<TWindow>();

        #region Events

        /// <summary>
        /// Occurs before the application is created.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler PreCreated;

        /// <summary>
        /// Occurs when the application is created.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler Created;

        /// <summary>
        /// Occurs when the application is terminated.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler Terminated;

        /// <summary>
        /// Occurs when the application is paused.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler Paused;

        /// <summary>
        /// Occurs when the application is resumed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler Resumed;

        /// <summary>
        /// Occurs when the application receives an app control request.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler<AppControlReceivedEventArgs> AppControlReceived;

        /// <summary>
        /// Occurs when a low memory condition is reported by the system.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler<LowMemoryEventArgs> LowMemory;

        /// <summary>
        /// Occurs when a low battery condition is reported by the system.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler<LowBatteryEventArgs> LowBattery;

        /// <summary>
        /// Occurs when the system language is changed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler<LocaleChangedEventArgs> LocaleChanged;

        /// <summary>
        /// Occurs when the region format of the system is changed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler<RegionFormatChangedEventArgs> RegionFormatChanged;

        /// <summary>
        /// Occurs when the device orientation is changed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler<DeviceOrientationEventArgs> DeviceOrientationChanged;

        /// <summary>
        /// Occurs when the system time zone is changed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler<TimeZoneChangedEventArgs> TimeZoneChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Invoked before the application is created.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnPreCreate();

        /// <summary>
        /// Invoked when the application is created.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnCreate();

        /// <summary>
        /// Invoked when the application is terminated.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnTerminate();

        /// <summary>
        /// Invoked when the application is paused.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnPause();

        /// <summary>
        /// Invoked when the application is resumed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnResume();

        /// <summary>
        /// Invoked when the application receives an app control request.
        /// </summary>
        /// <param name="e">The event data containing the received application control.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnAppControlReceived(AppControlReceivedEventArgs e);

        /// <summary>
        /// Invoked when a low memory event is reported by the system.
        /// </summary>
        /// <param name="e">The event data describing the low memory status.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnLowMemory(LowMemoryEventArgs e);

        /// <summary>
        /// Invoked when a low battery event is reported by the system.
        /// </summary>
        /// <param name="e">The event data describing the low battery status.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnLowBattery(LowBatteryEventArgs e);

        /// <summary>
        /// Invoked when the system language is changed.
        /// </summary>
        /// <param name="e">The event data describing the new locale.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnLocaleChanged(LocaleChangedEventArgs e);

        /// <summary>
        /// Invoked when the region format is changed.
        /// </summary>
        /// <param name="e">The event data describing the new region.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnRegionFormatChanged(RegionFormatChangedEventArgs e);

        /// <summary>
        /// Invoked when the device orientation is changed.
        /// </summary>
        /// <param name="e">The event data describing the new orientation.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnDeviceOrientationChanged(DeviceOrientationEventArgs e);

        /// <summary>
        /// Invoked when the system time zone is changed.
        /// </summary>
        /// <param name="e">The event data describing the new time zone.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnTimeZoneChanged(TimeZoneChangedEventArgs e);

        #endregion
    }
}