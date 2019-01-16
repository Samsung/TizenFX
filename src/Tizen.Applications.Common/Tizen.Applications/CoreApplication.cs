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
using System.Globalization;
using System.Text;
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// This class represents an application controlled lifecycles by the backend system.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CoreApplication : Application
    {
        private readonly ICoreBackend _backend;
        private bool _disposedValue = false;

        /// <summary>
        /// Initializes the CoreApplication class.
        /// </summary>
        /// <param name="backend">The backend instance implementing ICoreBacked interface.</param>
        /// <since_tizen> 3 </since_tizen>
        public CoreApplication(ICoreBackend backend)
        {
            _backend = backend;
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
            string[] argsClone = null;

            if (args == null)
            {
                argsClone = new string[1];
            }
            else
            {
                argsClone = new string[args.Length + 1];
                args.CopyTo(argsClone, 1);
            }
            argsClone[0] = string.Empty;

            base.Run(argsClone);

            _backend.AddEventHandler(EventType.Created, OnCreate);
            _backend.AddEventHandler(EventType.Terminated, OnTerminate);
            _backend.AddEventHandler<AppControlReceivedEventArgs>(EventType.AppControlReceived, OnAppControlReceived);
            _backend.AddEventHandler<LowMemoryEventArgs>(EventType.LowMemory, OnLowMemory);
            _backend.AddEventHandler<LowBatteryEventArgs>(EventType.LowBattery, OnLowBattery);
            _backend.AddEventHandler<LocaleChangedEventArgs>(EventType.LocaleChanged, OnLocaleChanged);
            _backend.AddEventHandler<RegionFormatChangedEventArgs>(EventType.RegionFormatChanged, OnRegionFormatChanged);
            _backend.AddEventHandler<DeviceOrientationEventArgs>(EventType.DeviceOrientationChanged, OnDeviceOrientationChanged);

            _backend.Run(argsClone);
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
        /// Overrides this method if want to handle behavior when the application is launched.
        /// If base.OnCreated() is not called, the event 'Created' will not be emitted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnCreate()
        {
            Created?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is terminated.
        /// If base.OnTerminate() is not called, the event 'Terminated' will not be emitted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnTerminate()
        {
            Terminated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application receives the appcontrol message.
        /// If base.OnAppControlReceived() is not called, the event 'AppControlReceived' will not be emitted.
        /// </summary>
        /// <param name="e"></param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            AppControlReceived?.Invoke(this, e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system memory is low.
        /// If base.OnLowMemory() is not called, the event 'LowMemory' will not be emitted.
        /// </summary>
        /// <param name="e">The low memory event argument</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnLowMemory(LowMemoryEventArgs e)
        {
            LowMemory?.Invoke(this, e);
            System.GC.Collect();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system battery is low.
        /// If base.OnLowBattery() is not called, the event 'LowBattery' will not be emitted.
        /// </summary>
        /// <param name="e">The low battery event argument</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnLowBattery(LowBatteryEventArgs e)
        {
            LowBattery?.Invoke(this, e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system language is changed.
        /// If base.OnLocaleChanged() is not called, the event 'LocaleChanged' will not be emitted.
        /// </summary>
        /// <param name="e">The locale changed event argument</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            ChangeCurrentCultureInfo(e.Locale);
            LocaleChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the region format is changed.
        /// If base.OnRegionFormatChanged() is not called, the event 'RegionFormatChanged' will not be emitted.
        /// </summary>
        /// <param name="e">The region format changed event argument</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            RegionFormatChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the device orientation is changed.
        /// If base.OnRegionFormatChanged() is not called, the event 'RegionFormatChanged' will not be emitted.
        /// </summary>
        /// <param name="e">The device orientation changed event argument</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
            DeviceOrientationChanged?.Invoke(this, e);
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

        private void ChangeCurrentCultureInfo(string locale)
        {
            ULocale pLocale = new ULocale(locale);
            CultureInfo currentCultureInfo = null;

            try
            {
                currentCultureInfo = new CultureInfo(pLocale.Locale.Replace("_", "-"));
            }
            catch (CultureNotFoundException)
            {
                currentCultureInfo = GetFallbackCultureInfo(pLocale);
            }

            CultureInfo.CurrentCulture = currentCultureInfo;
        }

        private CultureInfo GetCultureInfo(string locale)
        {
            CultureInfo cultureInfo = null;

            try
            {
                cultureInfo = new CultureInfo(locale);
            }
            catch (CultureNotFoundException)
            {
                return null;
            }

            return cultureInfo;
        }

        private CultureInfo GetFallbackCultureInfo(ULocale uLocale)
        {
            string locale = string.Empty;
            CultureInfo fallbackCultureInfo = null;

            if (uLocale.Script != null && uLocale.Country != null)
            {
                locale = uLocale.Language + "-" + uLocale.Script + "-" + uLocale.Country;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null && uLocale.Script != null)
            {
                locale = uLocale.Language + "-" + uLocale.Script;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null && uLocale.Country != null)
            {
                locale = uLocale.Language + "-" + uLocale.Country;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null)
            {
                try
                {
                    fallbackCultureInfo = new CultureInfo(uLocale.Language);
                }
                catch (CultureNotFoundException)
                {
                    fallbackCultureInfo = new CultureInfo("en");
                }
            }

            return fallbackCultureInfo;
        }
    }

    internal class ULocale
    {
        private const int ICU_ULOC_FULLNAME_CAPACITY = 157;
        private const int ICU_ULOC_LANG_CAPACITY = 12;
        private const int ICU_ULOC_SCRIPT_CAPACITY = 6;
        private const int ICU_ULOC_COUNTRY_CAPACITY = 4;
        private const int ICU_ULOC_VARIANT_CAPACITY = ICU_ULOC_FULLNAME_CAPACITY;
        private const int ICU_U_ZERO_ERROR = 0;

        internal ULocale(string locale)
        {
            Locale = Canonicalize(locale);
            Language = GetLanguage(Locale);
            Script = GetScript(Locale);
            Country = GetCountry(Locale);
            Variant = GetVariant(Locale);
        }

        internal string Locale { get; private set; }
        internal string Language { get; private set; }
        internal string Script { get; private set; }
        internal string Country { get; private set; }
        internal string Variant { get; private set; }

        private string Canonicalize(string localeName)
        {
            int err = ICU_U_ZERO_ERROR;

            // Get the locale name from ICU
            StringBuilder sb = new StringBuilder(ICU_ULOC_FULLNAME_CAPACITY);
            if (Interop.Icu.Canonicalize(localeName, sb, sb.Capacity, out err) <= 0)
            {
                return null;
            }

            return sb.ToString();
        }

        private string GetLanguage(string locale)
        {
            int err = ICU_U_ZERO_ERROR;

            // Get the language name from ICU
            StringBuilder sb = new StringBuilder(ICU_ULOC_LANG_CAPACITY);
            if (Interop.Icu.GetLanguage(locale, sb, sb.Capacity, out err) <= 0)
            {
                return null;
            }

            return sb.ToString();
        }

        private string GetScript(string locale)
        {
            int err = ICU_U_ZERO_ERROR;

            // Get the script name from ICU
            StringBuilder sb = new StringBuilder(ICU_ULOC_SCRIPT_CAPACITY);
            if (Interop.Icu.GetScript(locale, sb, sb.Capacity, out err) <= 0)
            {
                return null;
            }

            return sb.ToString();
        }

        private string GetCountry(string locale)
        {
            int err = ICU_U_ZERO_ERROR;

            // Get the country name from ICU
            StringBuilder sb = new StringBuilder(ICU_ULOC_SCRIPT_CAPACITY);
            if (Interop.Icu.GetCountry(locale, sb, sb.Capacity, out err) <= 0)
            {
                return null;
            }

            return sb.ToString();
        }

        private string GetVariant(string locale)
        {
            int err = ICU_U_ZERO_ERROR;

            // Get the variant name from ICU
            StringBuilder sb = new StringBuilder(ICU_ULOC_VARIANT_CAPACITY);
            if (Interop.Icu.GetVariant(locale, sb, sb.Capacity, out err) <= 0)
            {
                return null;
            }

            return sb.ToString();
        }
    }
}
