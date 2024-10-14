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
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// The CoreApplication class provides functionality to manage application lifecycle events that are controlled by the backend system.
    /// </summary>
    /// <remarks>
    /// By inheriting from the Application class, CoreApplication enables developers to handle various application states such as creating and terminating. It also allows them to define their own event handlers for these states.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    public class CoreApplication : Application
    {
        private readonly ICoreBackend _backend;
        private readonly ICoreTask _task;
        private bool _disposedValue = false;

        /// <summary>
        /// Initializes the CoreApplication class by providing a specific implementation of the ICoreBackend interface.
        /// </summary>
        /// <param name="backend">An instance of the desired implementation of the ICoreBackend interface.</param>
        /// <remarks>
        /// The CoreApplication class provides access to various features and functionalities related to application management.
        /// By initializing the CoreApplication class with a specific implementation of the ICoreBackend interface, developers can customize the behavior and functionality of their applications based on their requirements.
        /// It enables them to extend the capabilities of the default CoreApplication class and tailor it according to their needs.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public CoreApplication(ICoreBackend backend)
        {
            _backend = backend;
            _task = null;
        }

        /// <summary>
        /// Initializes the CoreApplication class.
        /// </summary>
        /// <param name="backend">The backend instance implementing ICoreBackend interface.</param>
        /// <param name="task">The backend instance implmenting ICoreTask interface.</param>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoreApplication(ICoreBackend backend, ICoreTask task)
        {
            _backend = backend;
            _task = task;
        }

        /// <summary>
        /// Occurs when the application is launched.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler Created;

        /// <summary>
        /// Occurs when the application is about to shutdown.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler Terminated;

        /// <summary>
        /// Occurs whenever the application receives the appcontrol message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<AppControlReceivedEventArgs> AppControlReceived;

        /// <summary>
        /// Occurs when the system memory is low.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<LowMemoryEventArgs> LowMemory;

        /// <summary>
        /// Occurs when the system battery is low.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<LowBatteryEventArgs> LowBattery;

        /// <summary>
        /// Occurs when the system language is chagned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<LocaleChangedEventArgs> LocaleChanged;

        /// <summary>
        /// Occurs when the region format is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<RegionFormatChangedEventArgs> RegionFormatChanged;

        /// <summary>
        /// Occurs when the device orientation is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<DeviceOrientationEventArgs> DeviceOrientationChanged;

        /// <summary>
        /// Occurs when the time zone is changed.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public event EventHandler<TimeZoneChangedEventArgs> TimeZoneChanged;

        /// <summary>
        /// The backend instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected ICoreBackend Backend { get { return _backend; } }

        /// <summary>
        /// Runs the application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// <since_tizen> 3 </since_tizen>
        public override void Run(string[] args)
        {
            base.Run(args);

            _backend.AddEventHandler(EventType.Created, OnCreate);
            _backend.AddEventHandler(EventType.Terminated, OnTerminate);
            _backend.AddEventHandler<AppControlReceivedEventArgs>(EventType.AppControlReceived, OnAppControlReceived);
            _backend.AddEventHandler<LowMemoryEventArgs>(EventType.LowMemory, OnLowMemory);
            _backend.AddEventHandler<LowBatteryEventArgs>(EventType.LowBattery, OnLowBattery);
            _backend.AddEventHandler<LocaleChangedEventArgs>(EventType.LocaleChanged, OnLocaleChanged);
            _backend.AddEventHandler<RegionFormatChangedEventArgs>(EventType.RegionFormatChanged, OnRegionFormatChanged);
            _backend.AddEventHandler<DeviceOrientationEventArgs>(EventType.DeviceOrientationChanged, OnDeviceOrientationChanged);
            _backend.AddEventHandler<TimeZoneChangedEventArgs>(EventType.TimeZoneChanged, OnTimeZoneChanged);

            string[] argsClone = new string[args == null ? 1 : args.Length + 1];
            if (args != null && args.Length > 1)
            {
                args.CopyTo(argsClone, 1);
            }
            argsClone[0] = string.Empty;

            if (_task != null)
            {
                ICoreTaskBackend backend = (ICoreTaskBackend)_backend;
                backend.SetCoreTask(_task);
                backend.Run(argsClone);
            }
            else
            {
                _backend.Run(argsClone);
            }
        }

        /// <summary>
        /// Exits the main loop of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public override void Exit()
        {
            _backend.Exit();
        }

        /// <summary>
        /// Overrides this method if you want to handle specific behavior when the application is created.
        /// Calling base.OnCreate() ensures that the default implementation is executed before any custom code in this method.
        /// If base.OnCreate() is not called, the event 'Created' will not be emitted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnCreate()
        {
            if (_task != null)
            {
                TizenUISynchronizationContext.Initialize();
            }

            if (!GlobalizationMode.Invariant)
            {
                string locale = ULocale.GetDefaultLocale();
                ChangeCurrentUICultureInfo(locale);
                ChangeCurrentCultureInfo(locale);
            }
            else
            {
                Log.Warn(LogTag, "Run in invariant mode");
            }

            Created?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Override this method to define specific actions that occur when the application terminates.
        /// Calling base.OnTerminate() ensures that the default termination process takes place and the 'Terminated' event is emitted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnTerminate()
        {
            Terminated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Override this method to customize the behavior when the application receives the appcontrol message.
        /// If base.OnAppControlReceived() is not called, the event 'AppControlReceived' will not be triggered.
        /// </summary>
        /// <param name="e">The arguments passed in the appcontrol message</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            if (e == null)
            {
                Log.Error(LogTag, "e is null");
                return;
            }

            AppControlReceived?.Invoke(this, e);
        }

        /// <summary>
        /// Override this method to handle behavior when the system memory is low.
        /// Calling base.OnLowMemory() ensures that the 'LowMemory' event is emitted.
        /// </summary>
        /// <param name="e">The low memory event argument</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnLowMemory(LowMemoryEventArgs e)
        {
            if (e == null)
            {
                Log.Error(LogTag, "e is null");
                return;
            }

            LowMemory?.Invoke(this, e);
            if (e.LowMemoryStatus == LowMemoryStatus.SoftWarning || e.LowMemoryStatus == LowMemoryStatus.HardWarning)
            {
                System.GC.Collect();
            }
        }

        /// <summary>
        /// Override this method to handle the behavior when the system battery level drops.
        /// If base.OnLowBattery() is not called, the LowBattery event will not be raised.
        /// </summary>
        /// <param name="e">The arguments for the low battery event</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnLowBattery(LowBatteryEventArgs e)
        {
            if (e == null)
            {
                Log.Error(LogTag, "e is null");
                return;
            }

            LowBattery?.Invoke(this, e);
        }

        /// <summary>
        /// Override this method to handle changes in the system language.
        /// If base.OnLocaleChanged() is not called, the LocaleChanged event will not be triggered.
        /// </summary>
        /// <param name="e">The arguments passed with the LocaleChanged event</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            if (e == null)
            {
                Log.Error(LogTag, "e is null");
                return;
            }

            if (!GlobalizationMode.Invariant)
            {
                ChangeCurrentUICultureInfo(e.Locale);
            }

            LocaleChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Override this method to handle changes in the region format.
        /// Make sure to call base.OnRegionFormatChanged() to ensure that the RegionFormatChanged event is raised.
        /// </summary>
        /// <param name="e">The region format changed event arguments</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            if (e == null)
            {
                Log.Error(LogTag, "e is null");
                return;
            }

            if (!GlobalizationMode.Invariant)
            {
                ChangeCurrentCultureInfo(e.Region);
            }

            RegionFormatChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Override this method to define specific behavior when the device orientation changes.
        /// If base.OnDeviceOrientationChanged() is not called, the 'DeviceOrientationChanged' event will not be raised.
        /// </summary>
        /// <param name="e">The arguments for the device orientation change event</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
            DeviceOrientationChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Override this method to handle changes in the current time zone.
        /// Calling base.OnTimeZoneChanged() ensures that the TimeZoneChanged event is triggered.
        /// </summary>
        /// <param name="e">The arguments containing details about the time zone change</param>
        /// <since_tizen> 11 </since_tizen>
        protected virtual void OnTimeZoneChanged(TimeZoneChangedEventArgs e)
        {
            TimeZoneChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Dispatches an asynchronous message to a main loop of the CoreApplication.
        /// </summary>
        /// <remarks>
        /// If an application uses UI thread App Model, the asynchronous message will be delivered to the UI thread.
        /// If not, the asynchronous message will be delivered to the main thread.
        /// </remarks>
        /// <param name="runner">The runner callaback.</param>
        /// <exception cref="ArgumentNullException">Thrown when the runner is null.</exception>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Post(Action runner)
        {
            if (runner == null)
            {
                throw new ArgumentNullException(nameof(runner));
            }

            GSourceManager.Post(runner, true);
        }

        /// <summary>
        /// Dispatches an asynchronous message to a main loop of the CoreApplication.
        /// </summary>
        /// <remarks>
        /// If an application uses UI thread App Model, the asynchronous message will be delivered to the UI thread.
        /// If not, the asynchronous message will be delivered to the main thread.
        /// </remarks>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="runner">The runner callback.</param>
        /// <exception cref="ArgumentNullException">Thrown when the runner is null.</exception>
        /// <returns>A task with the result.</returns>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<T> Post<T>(Func<T> runner)
        {
            if (runner == null)
            {
                throw new ArgumentNullException(nameof(runner));
            }

            var task = new TaskCompletionSource<T>();
            GSourceManager.Post(() => { task.SetResult(runner()); }, true);
            return await task.Task.ConfigureAwait(false);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _backend.Dispose();
                }

                _disposedValue = true;
            }
            base.Dispose(disposing);
        }

        private CultureInfo ConvertCultureInfo(string locale)
        {
            ULocale pLocale = new ULocale(locale);
            string cultureName = CultureInfoHelper.GetCultureName(pLocale.Locale.Replace("_", "-"));

            if (!string.IsNullOrEmpty(cultureName))
            {
                try
                {
                    return new CultureInfo(cultureName);
                }
                catch (CultureNotFoundException)
                {
                    Log.Error(LogTag, "CultureNotFoundException occurs. CultureName: " + cultureName);
                }
            }

            try
            {
                return new CultureInfo(pLocale.LCID);
            }
            catch (ArgumentOutOfRangeException)
            {
                return GetFallbackCultureInfo(pLocale);
            }
            catch (CultureNotFoundException)
            {
                return GetFallbackCultureInfo(pLocale);
            }
        }

        private void ChangeCurrentCultureInfo(string locale)
        {
            CultureInfo cultureInfo = ConvertCultureInfo(locale);
            if (cultureInfo != null)
            {
                CultureInfo.CurrentCulture = cultureInfo;
            }
            else
            {
                Log.Error(LogTag, "CultureInfo is null. locale: " + locale);
            }
        }

        private void ChangeCurrentUICultureInfo(string locale)
        {
            CultureInfo cultureInfo = ConvertCultureInfo(locale);
            if (cultureInfo != null)
            {
                CultureInfo.CurrentUICulture = cultureInfo;
            }
            else
            {
                Log.Error(LogTag, "CultureInfo is null. locale: " + locale);
            }
        }

        private bool ExistCultureInfo(string locale)
        {
            foreach (var cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                if (cultureInfo.Name == locale)
                {
                    return true;
                }
            }

            return false;
        }

        private CultureInfo GetCultureInfo(string locale)
        {
            if (!ExistCultureInfo(locale))
            {
                return null;
            }

            try
            {
                return new CultureInfo(locale);
            }
            catch (CultureNotFoundException)
            {
                return null;
            }
        }

        private CultureInfo GetFallbackCultureInfo(ULocale uLocale)
        {
            CultureInfo fallbackCultureInfo = null;
            string locale = string.Empty;

            if (uLocale.Locale != null)
            {
                locale = uLocale.Locale.Replace("_", "-");
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null && uLocale.Language != null && uLocale.Script != null && uLocale.Country != null)
            {
                locale = uLocale.Language + "-" + uLocale.Script + "-" + uLocale.Country;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null && uLocale.Language != null && uLocale.Script != null)
            {
                locale = uLocale.Language + "-" + uLocale.Script;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null && uLocale.Language != null && uLocale.Country != null)
            {
                locale = uLocale.Language + "-" + uLocale.Country;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null && uLocale.Language != null)
            {
                locale = uLocale.Language;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null)
            {
                try
                {
                    fallbackCultureInfo = new CultureInfo("en");
                }
                catch (CultureNotFoundException e)
                {
                    Log.Error(LogTag, "Failed to create CultureInfo. err = " + e.Message);
                }
            }

            return fallbackCultureInfo;
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

    internal class ULocale
    {
        private const int ULOC_FULLNAME_CAPACITY = 157;
        private const int ULOC_LANG_CAPACITY = 12;
        private const int ULOC_SCRIPT_CAPACITY = 6;
        private const int ULOC_COUNTRY_CAPACITY = 4;
        private const int ULOC_VARIANT_CAPACITY = ULOC_FULLNAME_CAPACITY;

        internal ULocale(string locale)
        {
            Locale = Canonicalize(locale);
            Language = GetLanguage(Locale);
            Script = GetScript(Locale);
            Country = GetCountry(Locale);
            Variant = GetVariant(Locale);
            LCID = GetLCID(Locale);
        }

        internal string Locale { get; private set; }
        internal string Language { get; private set; }
        internal string Script { get; private set; }
        internal string Country { get; private set; }
        internal string Variant { get; private set; }
        internal int LCID { get; private set; }

        private string Canonicalize(string localeName)
        {
            // Get the locale name from ICU
            StringBuilder sb = new StringBuilder(ULOC_FULLNAME_CAPACITY);
            if (Interop.BaseUtilsi18n.Canonicalize(localeName, sb, sb.Capacity) <= 0)
            {
                return null;
            }

            return sb.ToString();
        }

        private string GetLanguage(string locale)
        {
            // Get the language name from ICU
            StringBuilder sb = new StringBuilder(ULOC_LANG_CAPACITY);
            if (Interop.BaseUtilsi18n.GetLanguage(locale, sb, sb.Capacity, out int bufSizeLanguage) != 0)
            {
                return null;
            }

            return sb.ToString();
        }

        private string GetScript(string locale)
        {
            // Get the script name from ICU
            StringBuilder sb = new StringBuilder(ULOC_SCRIPT_CAPACITY);
            if (Interop.BaseUtilsi18n.GetScript(locale, sb, sb.Capacity) <= 0)
            {
                return null;
            }

            return sb.ToString();
        }

        private string GetCountry(string locale)
        {
            int err = 0;

            // Get the country name from ICU
            StringBuilder sb = new StringBuilder(ULOC_COUNTRY_CAPACITY);
            if (Interop.BaseUtilsi18n.GetCountry(locale, sb, sb.Capacity, out err) <= 0)
            {
                return null;
            }

            return sb.ToString();
        }

        private string GetVariant(string locale)
        {
            // Get the variant name from ICU
            StringBuilder sb = new StringBuilder(ULOC_VARIANT_CAPACITY);
            if (Interop.BaseUtilsi18n.GetVariant(locale, sb, sb.Capacity) <= 0)
            {
                return null;
            }

            return sb.ToString();
        }

        private int GetLCID(string locale)
        {
            // Get the LCID from ICU
            uint lcid = Interop.BaseUtilsi18n.GetLCID(locale);
            return (int)lcid;
        }

        internal static string GetDefaultLocale()
        {
            IntPtr stringPtr = Interop.Libc.GetEnvironmentVariable("LANG");
            if (stringPtr == IntPtr.Zero)
            {
                return string.Empty;
            }

            return Marshal.PtrToStringAnsi(stringPtr);
        }
    }
}
