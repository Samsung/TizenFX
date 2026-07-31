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
using System.Globalization;
using System.Threading.Tasks;
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the core Team application with common lifecycle and system events.
    /// </summary>
    /// <remarks>
    /// Subclasses typically add UI- or service-specific behavior on top of the events exposed here.
    /// </remarks>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TeamCoreApplication : TeamApplication
    {
        /// <summary>
        /// Initializes the <see cref="TeamCoreApplication"/> class with the given backend.
        /// </summary>
        /// <param name="backend">The backend used to drive this Team application instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="backend"/> is null.</exception>
        protected TeamCoreApplication(TeamCoreBackend backend) : base(backend)
        {
            Log.Info(LogTag, "TeamCoreApplication constructor called");
        }

        /// <summary>
        /// Occurs whenever the application is launched.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Created;

        /// <summary>
        /// Occurs whenever the application is about to shut down.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Terminated;

        /// <summary>
        /// Occurs whenever the application receives an application control request.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AppControlReceivedEventArgs> AppControlReceived;

        /// <summary>
        /// Occurs when a low memory condition is reported by the system.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<LowMemoryEventArgs> LowMemory;

        /// <summary>
        /// Occurs when a low battery condition is reported by the system.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<LowBatteryEventArgs> LowBattery;

        /// <summary>
        /// Occurs when the system language is changed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<LocaleChangedEventArgs> LocaleChanged;

        /// <summary>
        /// Occurs when the region format of the system is changed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<RegionFormatChangedEventArgs> RegionFormatChanged;

        /// <summary>
        /// Occurs when the device orientation is changed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<DeviceOrientationEventArgs> DeviceOrientationChanged;

        /// <summary>
        /// Occurs when the system time zone is changed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<TimeZoneChangedEventArgs> TimeZoneChanged;

        /// <summary>
        /// Runs the Team application's main loop and subscribes to lifecycle and system events.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="args"/> is null.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Run(string[] args)
        {
            base.Run(args);

            Backend.AddEventHandler(EventType.Created, OnCreate);
            Backend.AddEventHandler(EventType.Terminated, OnTerminate);
            Backend.AddEventHandler<AppControlReceivedEventArgs>(EventType.AppControlReceived, OnAppControlReceived);
            Backend.AddEventHandler<LowMemoryEventArgs>(EventType.LowMemory, OnLowMemory);
            Backend.AddEventHandler<LowBatteryEventArgs>(EventType.LowBattery, OnLowBattery);
            Backend.AddEventHandler<LocaleChangedEventArgs>(EventType.LocaleChanged, OnLocaleChanged);
            Backend.AddEventHandler<RegionFormatChangedEventArgs>(EventType.RegionFormatChanged, OnRegionFormatChanged);
            Backend.AddEventHandler<DeviceOrientationEventArgs>(EventType.DeviceOrientationChanged, OnDeviceOrientationChanged);
            Backend.AddEventHandler<TimeZoneChangedEventArgs>(EventType.TimeZoneChanged, OnTimeZoneChanged);

            _backend.Run(args);
        }

        /// <summary>
        /// Invoked when the application is created. Raises the <see cref="Created"/> event.
        /// </summary>
        protected virtual void OnCreate()
        {
            if (!GlobalizationMode.Invariant)
            {
                string locale = SystemLocaleConverter.ULocale.GetDefaultLocale();

                TeamLocaleManager.SetCurrentUICultureInfo(locale);
                TeamLocaleManager.SetCurrentCultureInfo(locale);
            }
            else
            {
                Log.Warn(LogTag, "Run in invariant mode");
            }

            Created?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Invoked when the application is about to terminate. Raises the <see cref="Terminated"/> event.
        /// </summary>
        protected virtual void OnTerminate()
        {
            Log.Info(LogTag, "TeamCoreApplication.OnTerminate() called");
            Terminated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Invoked when the application receives an application control request. Raises the <see cref="AppControlReceived"/> event.
        /// </summary>
        /// <param name="e">The event data containing the received application control.</param>
        protected virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            Log.Info(LogTag, "TeamCoreApplication.OnAppControlReceived() called");
            if (e == null)
            {
                Log.Error(LogTag, "e is null");
                return;
            }

            AppControlReceived?.Invoke(this, e);
        }

        /// <summary>
        /// Invoked when a low memory event is reported by the system. Raises the <see cref="LowMemory"/> event
        /// and triggers <see cref="GC.Collect()"/> on soft/hard warnings.
        /// </summary>
        /// <param name="e">The event data describing the low memory status.</param>
        protected virtual void OnLowMemory(LowMemoryEventArgs e)
        {
            Log.Info(LogTag, $"TeamCoreApplication.OnLowMemory() called - Status: {e?.LowMemoryStatus}");
            if (e == null)
            {
                Log.Error(LogTag, "e is null");
                return;
            }

            LowMemory?.Invoke(this, e);
            if (e.LowMemoryStatus == LowMemoryStatus.SoftWarning || e.LowMemoryStatus == LowMemoryStatus.HardWarning)
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Invoked when a low battery event is reported by the system. Raises the <see cref="LowBattery"/> event.
        /// </summary>
        /// <param name="e">The event data describing the low battery status.</param>
        protected virtual void OnLowBattery(LowBatteryEventArgs e)
        {
            Log.Info(LogTag, $"TeamCoreApplication.OnLowBattery() called - Status: {e?.LowBatteryStatus}");
            if (e == null)
            {
                Log.Error(LogTag, "e is null");
                return;
            }

            LowBattery?.Invoke(this, e);
        }

        /// <summary>
        /// Invoked when the system language is changed. Updates the current UI culture and raises the <see cref="LocaleChanged"/> event.
        /// </summary>
        /// <param name="e">The event data describing the new locale.</param>
        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            Log.Info(LogTag, $"TeamCoreApplication.OnLocaleChanged() called - Locale: {e?.Locale}");
            if (e == null)
            {
                Log.Error(LogTag, "e is null");
                return;
            }

            if (!GlobalizationMode.Invariant)
            {
                TeamLocaleManager.SetCurrentUICultureInfo(e.Locale);
            }

            LocaleChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Invoked when the region format is changed. Updates the current culture and raises the <see cref="RegionFormatChanged"/> event.
        /// </summary>
        /// <param name="e">The event data describing the new region.</param>
        protected virtual void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            Log.Info(LogTag, $"TeamCoreApplication.OnRegionFormatChanged() called - Region: {e?.Region}");
            if (e == null)
            {
                Log.Error(LogTag, "e is null");
                return;
            }

            if (!GlobalizationMode.Invariant)
            {
                TeamLocaleManager.SetCurrentCultureInfo(e.Region);
            }

            RegionFormatChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Invoked when the device orientation is changed. Raises the <see cref="DeviceOrientationChanged"/> event.
        /// </summary>
        /// <param name="e">The event data describing the new orientation.</param>
        protected virtual void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
            Log.Info(LogTag, $"TeamCoreApplication.OnDeviceOrientationChanged() called - Orientation: {e?.DeviceOrientation}");
            DeviceOrientationChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Invoked when the system time zone is changed. Clears cached culture data and raises the <see cref="TimeZoneChanged"/> event.
        /// </summary>
        /// <param name="e">The event data describing the new time zone.</param>
        protected virtual void OnTimeZoneChanged(TimeZoneChangedEventArgs e)
        {
            Log.Info(LogTag, $"TeamCoreApplication.OnTimeZoneChanged() called - TimeZone: {e?.TimeZone}, ID: {e?.TimeZoneId}");
            CultureInfo.CurrentCulture.ClearCachedData();
            TimeZoneChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Posts an action to be executed on the main loop of the current Team application.
        /// </summary>
        /// <param name="runner">The action to be executed on the main loop.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="runner"/> is null.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Post(Action runner)
        {
            Log.Info(LogTag, "TeamCoreApplication.Post(Action) called");
            if (runner == null)
            {
                throw new ArgumentNullException(nameof(runner));
            }

            GSourceManager.Post(runner);
        }

        /// <summary>
        /// Posts a function to be executed on the main loop of the current Team application and awaits its result.
        /// </summary>
        /// <typeparam name="T">The type of the result returned by <paramref name="runner"/>.</typeparam>
        /// <param name="runner">The function to be executed on the main loop.</param>
        /// <returns>A task that completes with the result of <paramref name="runner"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="runner"/> is null.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<T> Post<T>(Func<T> runner)
        {
            Log.Info(LogTag, $"TeamCoreApplication.Post<T>() called - Type: {typeof(T).Name}");
            if (runner == null)
            {
                throw new ArgumentNullException(nameof(runner));
            }

            var task = new TaskCompletionSource<T>();
            GSourceManager.Post(() => { task.SetResult(runner()); } );
            return await task.Task.ConfigureAwait(false);
        }
    }

    internal static class TeamLocaleManager
    {
        private static readonly string LogTag = "DN_TAM";

        internal static void SetCurrentCultureInfo(string locale)
        {
            var converter = new SystemLocaleConverter();
            CultureInfo cultureInfo = converter.Convert(locale);
            if (cultureInfo != null)
            {
                CultureInfo.CurrentCulture = cultureInfo;
            }
            else
            {
                Log.Error(LogTag, $"CultureInfo is null. locale: {locale}");
            }
        }

        internal static void SetCurrentUICultureInfo(string locale)
        {
            var converter = new SystemLocaleConverter();
            CultureInfo cultureInfo = converter.Convert(locale);
            if (cultureInfo != null)
            {
                CultureInfo.CurrentUICulture = cultureInfo;
            }
            else
            {
                Log.Error(LogTag, $"CultureInfo is null. locale: {locale}");
            }
        }
    }
}
