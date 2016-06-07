// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

using Tizen.Internals.Errors;

namespace Tizen.Applications
{
    /// <summary>
    /// The Application handles an application state change or system events and provides mechanisms that launch other applications.
    /// </summary>
    public abstract class Application : IDisposable
    {
        internal const string LogTag = "Tizen.Applications";

        private static Application s_CurrentApplication = null;

        private object _lock = new object();

        private Interop.AppCommon.AppEventCallback _lowMemoryCallback;
        private Interop.AppCommon.AppEventCallback _lowBatteryCallback;
        private Interop.AppCommon.AppEventCallback _localeChangedCallback;
        private Interop.AppCommon.AppEventCallback _regionChangedCallback;

        private IntPtr _lowMemoryEventHandle = IntPtr.Zero;
        private IntPtr _lowBatteryEventHandle = IntPtr.Zero;
        private IntPtr _localeChangedEventHandle = IntPtr.Zero;
        private IntPtr _regionChangedEventHandle = IntPtr.Zero;

        private DirectoryInfo _directoryInfo;
        private ApplicationInfo _applicationInfo;

        /// <summary>
        /// Initializes the Application class.
        /// </summary>
        public Application()
        {
            _lowMemoryCallback = new Interop.AppCommon.AppEventCallback(OnLowMemoryNative);
            _lowBatteryCallback = new Interop.AppCommon.AppEventCallback(OnLowBatteryNative);
            _localeChangedCallback = new Interop.AppCommon.AppEventCallback(OnLocaleChangedNative);
            _regionChangedCallback = new Interop.AppCommon.AppEventCallback(OnRegionChangedNative);
        }

        /// <summary>
        /// Occurs when the application is launched.
        /// </summary>
        public event EventHandler Created;

        /// <summary>
        /// Occurs when the application is about to shutdown.
        /// </summary>
        public event EventHandler Terminated;

        /// <summary>
        /// Occurs whenever the application receives the appcontrol message.
        /// </summary>
        public event EventHandler<AppControlReceivedEventArgs> AppControlReceived;

        /// <summary>
        /// Occurs when the system memory is low.
        /// </summary>
        public event EventHandler<LowMemoryEventArgs> LowMemory;

        /// <summary>
        /// Occurs when the system battery is low.
        /// </summary>
        public event EventHandler<LowBatteryEventArgs> LowBattery;

        /// <summary>
        /// Occurs when the system language is chagned.
        /// </summary>
        public event EventHandler<LocaleChangedEventArgs> LocaleChanged;

        /// <summary>
        /// Occurs when the region format is changed.
        /// </summary>
        public event EventHandler<RegionFormatChangedEventArgs> RegionFormatChanged;

        /// <summary>
        /// Gets the instance of current application.
        /// </summary>
        public static Application Current { get { return s_CurrentApplication; } }

        /// <summary>
        /// Gets the class representing directory information of current application.
        /// </summary>
        public DirectoryInfo DirectoryInfo
        {
            get
            {
                lock (_lock)
                {
                    if (_directoryInfo == null)
                    {
                        _directoryInfo = new DirectoryInfo();
                    }
                }
                return _directoryInfo;
            }
        }

        /// <summary>
        /// Gets the class representing information of current application.
        /// </summary>
        public ApplicationInfo ApplicationInfo
        {
            get
            {
                lock (_lock)
                {
                    if (_applicationInfo == null)
                    {
                        string appId = string.Empty;
                        Interop.AppCommon.AppGetId(out appId);
                        if (!string.IsNullOrEmpty(appId))
                        {
                            _applicationInfo = new ApplicationInfo(appId);
                        }
                    }
                }
                return _applicationInfo;
            }
        }

        /// <summary>
        /// Runs the application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public virtual void Run(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            TizenSynchronizationContext.Initialize();

            s_CurrentApplication = this;

            ErrorCode err = ErrorCode.None;
            err = AddEventHandler(out _lowMemoryEventHandle, Interop.AppCommon.AppEventType.LowMemory, _lowMemoryCallback);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LowMemory event. Err = " + err);
            }

            err = AddEventHandler(out _lowBatteryEventHandle, Interop.AppCommon.AppEventType.LowBattery, _lowBatteryCallback);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LowBattery event. Err = " + err);
            }

            err = AddEventHandler(out _localeChangedEventHandle, Interop.AppCommon.AppEventType.LanguageChanged, _localeChangedCallback);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LocaleChanged event. Err = " + err);
            }

            err = AddEventHandler(out _regionChangedEventHandle, Interop.AppCommon.AppEventType.RegionFormatChanged, _regionChangedCallback);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for RegionFormatChanged event. Err = " + err);
            }
        }

        /// <summary>
        /// Exits the main loop of application. 
        /// </summary>
        public abstract void Exit();

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is launched.
        /// If base.OnCreated() is not called, the event 'Created' will not be emitted.
        /// </summary>
        protected virtual void OnCreate()
        {
            Created?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is terminated.
        /// If base.OnTerminate() is not called, the event 'Terminated' will not be emitted.
        /// </summary>
        protected virtual void OnTerminate()
        {
            Terminated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application receives the appcontrol message.
        /// If base.OnAppControlReceived() is not called, the event 'AppControlReceived' will not be emitted.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            AppControlReceived?.Invoke(this, e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system memory is low.
        /// If base.OnLowMemory() is not called, the event 'LowMemory' will not be emitted.
        /// </summary>
        protected virtual void OnLowMemory(LowMemoryEventArgs e)
        {
            LowMemory?.Invoke(this, e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system battery is low.
        /// If base.OnLowBattery() is not called, the event 'LowBattery' will not be emitted.
        /// </summary>
        protected virtual void OnLowBattery(LowBatteryEventArgs e)
        {
            LowBattery?.Invoke(this, e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system language is changed.
        /// If base.OnLocaleChanged() is not called, the event 'LocaleChanged' will not be emitted.
        /// </summary>
        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            LocaleChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the region format is changed.
        /// If base.OnRegionFormatChanged() is not called, the event 'RegionFormatChanged' will not be emitted.
        /// </summary>
        protected virtual void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            RegionFormatChanged?.Invoke(this, e);
        }

        internal virtual ErrorCode AddEventHandler(out IntPtr handle, Interop.AppCommon.AppEventType type, Interop.AppCommon.AppEventCallback callback)
        {
            handle = IntPtr.Zero;
            return ErrorCode.None;
        }

        internal virtual void RemoveEventHandler(IntPtr handle)
        {
        }

        private void OnLowMemoryNative(IntPtr infoHandle, IntPtr data)
        {
            LowMemoryStatus status = LowMemoryStatus.None;
            ErrorCode err = Interop.AppCommon.AppEventGetLowMemoryStatus(infoHandle, out status);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get memory status. Err = " + err);
            }
            OnLowMemory(new LowMemoryEventArgs(status));
        }

        private void OnLowBatteryNative(IntPtr infoHandle, IntPtr data)
        {
            LowBatteryStatus status = LowBatteryStatus.None;
            ErrorCode err = Interop.AppCommon.AppEventGetLowBatteryStatus(infoHandle, out status);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get battery status. Err = " + err);
            }
            OnLowBattery(new LowBatteryEventArgs(status));
        }

        private void OnLocaleChangedNative(IntPtr infoHandle, IntPtr data)
        {
            string lang;
            ErrorCode err = Interop.AppCommon.AppEventGetLanguage(infoHandle, out lang);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get changed language. Err = " + err);
            }
            OnLocaleChanged(new LocaleChangedEventArgs(lang));
        }

        private void OnRegionChangedNative(IntPtr infoHandle, IntPtr data)
        {
            string region;
            ErrorCode err = Interop.AppCommon.AppEventGetRegionFormat(infoHandle, out region);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get changed region format. Err = " + err);
            }
            OnRegionFormatChanged(new RegionFormatChangedEventArgs(region));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_applicationInfo != null)
                    {
                        _applicationInfo.Dispose();
                    }
                }

                if (_lowMemoryEventHandle != IntPtr.Zero)
                {
                    RemoveEventHandler(_lowMemoryEventHandle);
                }
                if (_lowBatteryEventHandle != IntPtr.Zero)
                {
                    RemoveEventHandler(_lowBatteryEventHandle);
                }
                if (_localeChangedEventHandle != IntPtr.Zero)
                {
                    RemoveEventHandler(_localeChangedEventHandle);
                }
                if (_regionChangedEventHandle != IntPtr.Zero)
                {
                    RemoveEventHandler(_regionChangedEventHandle);
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer of the Application class.
        /// </summary>
        ~Application()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all resources used by the Application class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
