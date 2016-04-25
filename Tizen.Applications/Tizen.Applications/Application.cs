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
    public abstract class Application
    {
        private const string LogTag = "Tizen.Applications";

        private static Application s_CurrentApplication = null;

        private Interop.AppEvent.SafeAppEventHandle _lowMemoryNativeHandle;
        private Interop.AppEvent.SafeAppEventHandle _localeChangedNativeHandle;

        private object _lock = new object();

        private DirectoryInfo _directoryInfo;
        private ApplicationInfo _applicationInfo;

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
                        string appId;
                        ErrorCode err = Interop.AppCommon.AppGetId(out appId);
                        if (err == ErrorCode.None)
                        {
                            try
                            {
                                // TODO: Use lazy enabled AppInfo class without throwing exceptions.
                                _applicationInfo = ApplicationManager.GetInstalledApplication(appId);
                            }
                            catch (Exception e)
                            {
                                Log.Warn(LogTag, "Failed to get application info. " + e.Message);
                            }
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

            Interop.AppEvent.AddEventHandler(Interop.AppEvent.EventNames.LowMemory, HandleAppEvent, IntPtr.Zero, out _lowMemoryNativeHandle);
            Interop.AppEvent.AddEventHandler(Interop.AppEvent.EventNames.LanguageSet, HandleAppEvent, IntPtr.Zero, out _localeChangedNativeHandle);
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
            EventHandler eh = Created;
            if (eh != null)
            {
                eh(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is terminated.
        /// If base.OnTerminate() is not called, the event 'Terminated' will not be emitted.
        /// </summary>
        protected virtual void OnTerminate()
        {
            EventHandler eh = Terminated;
            if (eh != null)
            {
                eh(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application receives the appcontrol message.
        /// If base.OnAppControlReceived() is not called, the event 'AppControlReceived' will not be emitted.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            EventHandler<AppControlReceivedEventArgs> eh = AppControlReceived;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system memory is low.
        /// If base.OnLowMemory() is not called, the event 'LowMemory' will not be emitted.
        /// </summary>
        protected virtual void OnLowMemory(LowMemoryEventArgs e)
        {
            EventHandler<LowMemoryEventArgs> eh = LowMemory;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system language is changed.
        /// If base.OnLocaleChanged() is not called, the event 'LocaleChanged' will not be emitted.
        /// </summary>
        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            EventHandler<LocaleChangedEventArgs> eh = LocaleChanged;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        internal void SendCreate()
        {
            OnCreate();
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
    }
}
