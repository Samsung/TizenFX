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
using System.Globalization;
using System.Threading.Tasks;
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    public class TeamCoreApplication : TeamApplication
    {
        protected TeamCoreApplication(TeamCoreBackend backend) : base(backend)
        {
            Log.Info(LogTag, "TeamCoreApplication constructor called");
        }
        public event EventHandler Created;
        public event EventHandler Terminated;
        public event EventHandler<AppControlReceivedEventArgs> AppControlReceived;
        public event EventHandler<LowMemoryEventArgs> LowMemory;
        public event EventHandler<LowBatteryEventArgs> LowBattery;
        public event EventHandler<LocaleChangedEventArgs> LocaleChanged;
        public event EventHandler<RegionFormatChangedEventArgs> RegionFormatChanged;
        public event EventHandler<DeviceOrientationEventArgs> DeviceOrientationChanged;
        public event EventHandler<TimeZoneChangedEventArgs> TimeZoneChanged;
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

        protected virtual void OnTerminate()
        {
            Log.Info(LogTag, "TeamCoreApplication.OnTerminate() called");
            Terminated?.Invoke(this, EventArgs.Empty);
        }

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

        protected virtual void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
            Log.Info(LogTag, $"TeamCoreApplication.OnDeviceOrientationChanged() called - Orientation: {e?.DeviceOrientation}");
            DeviceOrientationChanged?.Invoke(this, e);
        }

        protected virtual void OnTimeZoneChanged(TimeZoneChangedEventArgs e)
        {
            Log.Info(LogTag, $"TeamCoreApplication.OnTimeZoneChanged() called - TimeZone: {e?.TimeZone}, ID: {e?.TimeZoneId}");
            CultureInfo.CurrentCulture.ClearCachedData();
            TimeZoneChanged?.Invoke(this, e);
        }

        public static void Post(Action runner)
        {
            Log.Info(LogTag, "TeamCoreApplication.Post(Action) called");
            if (runner == null)
            {
                throw new ArgumentNullException(nameof(runner));
            }

            GSourceManager.Post(runner);
        }

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

    internal static class GlobalizationMode
    {
        private static int _invariant = -1;

        internal static bool Invariant
        {
            get
            {
                if (_invariant == -1)
                {
                    string value = Environment.GetEnvironmentVariable("DOTNET_SYSTEM_GLOBALIZATION_INVARIANT");
                    _invariant = value != null ? (value.Equals("1") ? 1 : 0) : 0;
                }

                return _invariant != 0;
            }
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
