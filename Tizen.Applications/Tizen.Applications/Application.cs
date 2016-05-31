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
        private const string LogTag = "Tizen.Applications";

        private static Application s_CurrentApplication = null;

        private Interop.AppEvent.SafeAppEventHandle _lowMemoryNativeHandle;
        private Interop.AppEvent.SafeAppEventHandle _localeChangedNativeHandle;

        private Interop.AppEvent.AppEventCallback _appEventCallback;

        private object _lock = new object();

        private DirectoryInfo _directoryInfo;
        private ApplicationInfo _applicationInfo;

        /// <summary>
        /// Initializes Application instance.
        /// </summary>
        public Application()
        {
            _appEventCallback = new Interop.AppEvent.AppEventCallback(HandleAppEvent);
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
        /// Occurs when the system language is chagned.
        /// </summary>
        public event EventHandler<LocaleChangedEventArgs> LocaleChanged;

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

            s_CurrentApplication = this;

            Interop.AppEvent.AddEventHandler(Interop.AppEvent.EventNames.LowMemory, _appEventCallback, IntPtr.Zero, out _lowMemoryNativeHandle);
            Interop.AppEvent.AddEventHandler(Interop.AppEvent.EventNames.LanguageSet, _appEventCallback, IntPtr.Zero, out _localeChangedNativeHandle);
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
        /// Overrides this method if want to handle behavior when the system language is changed.
        /// If base.OnLocaleChanged() is not called, the event 'LocaleChanged' will not be emitted.
        /// </summary>
        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            LocaleChanged?.Invoke(this, e);
        }

        private void HandleAppEvent(string eventName, IntPtr eventData, IntPtr data)
        {
            Bundle b = new Bundle(eventData);
            if (eventName == Interop.AppEvent.EventNames.LowMemory)
            {
                string value = b.GetItem<string>(Interop.AppEvent.EventKeys.LowMemory);
                LowMemoryStatus status = LowMemoryStatus.Normal;
                if (value == Interop.AppEvent.EventValues.MemorySoftWarning)
                {
                    status = LowMemoryStatus.SoftWarning;
                }
                else if (value == Interop.AppEvent.EventValues.MemoryHardWarning)
                {
                    status = LowMemoryStatus.HardWarning;
                }
                OnLowMemory(new LowMemoryEventArgs { LowMemoryStatus = status });
            }
            else if (eventName == Interop.AppEvent.EventNames.LanguageSet)
            {
                string value = b.GetItem<string>(Interop.AppEvent.EventKeys.LanguageSet);
                OnLocaleChanged(new LocaleChangedEventArgs { Locale = value });
            }
            b.Dispose();
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
                    if (_lowMemoryNativeHandle != null && !_lowMemoryNativeHandle.IsInvalid)
                    {
                        _lowMemoryNativeHandle.Dispose();
                    }
                    if (_localeChangedNativeHandle != null && !_localeChangedNativeHandle.IsInvalid)
                    {
                        _localeChangedNativeHandle.Dispose();
                    }
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
