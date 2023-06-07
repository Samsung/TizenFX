/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.Applications.CoreBackend;
using Tizen.Applications;

namespace Tizen.NUI
{
    class NUICoreBackend : ICoreTaskBackend
    {
        /// <summary>
        /// The Application instance to connect event.
        /// </summary>
        protected Application application;
        private string stylesheet = "";
        private NUIApplication.WindowMode windowMode = NUIApplication.WindowMode.Opaque;
        private Rectangle windowRectangle = null;
        private WindowType defaultWindowType = WindowType.Normal;
        private ICoreTask coreTask;
        private WindowData windowData = null;

        /// <summary>
        /// The Dictionary to contain each type of event callback.
        /// </summary>
        protected IDictionary<EventType, object> Handlers = new Dictionary<EventType, object>();
        protected IDictionary<EventType, object> TaskHandlers = new Dictionary<EventType, object>();

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public NUICoreBackend()
        {
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public NUICoreBackend(string stylesheet)
        {
            this.stylesheet = stylesheet;
        }

        /// <summary>
        /// The constructor with stylesheet and window mode.
        /// </summary>
        public NUICoreBackend(string stylesheet, NUIApplication.WindowMode windowMode)
        {
            this.stylesheet = stylesheet;
            this.windowMode = windowMode;
        }

        /// <summary>
        /// The constructor with stylesheet, window mode, window size and window position.
        /// </summary>
        public NUICoreBackend(string stylesheet, NUIApplication.WindowMode windowMode, Size2D windowSize, Position2D windowPosition)
        {
            this.stylesheet = stylesheet;
            this.windowMode = windowMode;
            if (windowSize != null && windowPosition != null)
            {
                this.windowRectangle = new Rectangle(windowPosition.X, windowPosition.Y, windowSize.Width, windowSize.Height);
            }
        }

        /// <summary>
        /// The constructor with stylesheet, window mode, window size, window position and default window type.
        /// This will be hidden as inhouse API. Because it is only for internal IME window.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUICoreBackend(string stylesheet, NUIApplication.WindowMode windowMode, WindowType type)
        {
            this.stylesheet = stylesheet;
            this.windowMode = windowMode;
            this.defaultWindowType = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUICoreBackend(WindowData windowData)
        {
            //NOTE: windowMode, defaultWindowType, windowRectangle are not used.
            this.windowData = windowData;
        }

        /// <summary>
        /// Adds NUIApplication event to Application.
        /// Puts each type of event callback in Dictionary.
        /// </summary>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The event callback.</param>
        public void AddEventHandler(EventType evType, Action handler)
        {
            Handlers.Add(evType, handler);
        }

        /// <summary>
        /// Adds NUIApplication event to Application.
        /// Puts each type of event callback in Dictionary.
        /// </summary>
        /// <typeparam name="TEventArgs">The argument type for the event.</typeparam>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The event callback.</param>
        public void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs
        {
            Handlers.Add(evType, handler);
        }

        /// <summary>
        /// The Dispose function.
        /// </summary>
        public void Dispose()
        {
            if (application != null)
            {
                application.Dispose();
            }
            if (windowRectangle != null)
            {
                windowRectangle.Dispose();
            }
        }

        /// <summary>
        /// The Exit application.
        /// </summary>
        public void Exit()
        {
            if (application != null)
            {
                application.Quit();
            }
        }

        /// <summary>
        /// Ensures that the function passed in is called from the main loop when it is idle.
        /// </summary>
        /// <param name="func">The function to call</param>
        /// <returns>true if added successfully, false otherwise</returns>
        public bool AddIdle(System.Delegate func)
        {
            return application.AddIdle(func);
        }

        /// <summary>
        /// The Run application.
        /// </summary>
        /// <param name="args">The arguments from commandline.</param>
        public void Run(string[] args)
        {
            Tizen.Tracer.Begin("[NUI] NUICorebackend Run()");

            Tizen.Tracer.Begin("[NUI] NUICorebackend Run(): TizenSynchronizationContext.Initialize() called");
            TizenSynchronizationContext.Initialize();
            Tizen.Tracer.End();

            Tizen.Tracer.Begin("[NUI] NUICorebackend Run(): args of main set, window type set");
            if (Tizen.Applications.Application.Current?.ApplicationInfo != null)
            {
                args[0] = Tizen.Applications.Application.Current.ApplicationInfo.ExecutablePath;
            }
            if (string.IsNullOrEmpty(args[0]))
            {
                args[0] = this.GetType().Assembly.FullName.Replace(" ", "");
            }

            if (windowData != null)
            {
                bool enableUIThread = coreTask != null;
                application = Application.NewApplication(args, stylesheet, enableUIThread, windowData);
            }
            else if (defaultWindowType != WindowType.Normal)
            {
                application = Application.NewApplication(stylesheet, windowMode, defaultWindowType);
            }
            else
            {
                if (windowRectangle != null)
                {
                    if (coreTask != null)
                    {
                        application = Application.NewApplication(args, stylesheet, windowMode, windowRectangle, true);
                    }
                    else
                    {
                        application = Application.NewApplication(args, stylesheet, windowMode, windowRectangle);
                    }
                }
                else
                {
                    if (coreTask != null)
                    {
                        // The Rectangle(0, 0, 0, 0) means that want to use the full screen size window at 0,0.
                        using (Rectangle rec = new Rectangle(0, 0, 0, 0))
                        {
                            application = Application.NewApplication(args, stylesheet, windowMode, rec, true);
                        }
                    }
                    else
                    {
                        application = Application.NewApplication(args, stylesheet, windowMode);
                    }
                }
            }
            Tizen.Tracer.End();

            Tizen.Tracer.Begin("[NUI] NUICorebackend Run(): add application related events");
            application.BatteryLow += OnBatteryLow;
            application.LanguageChanged += OnLanguageChanged;
            application.MemoryLow += OnMemoryLow;
            application.RegionChanged += OnRegionChanged;
            application.DeviceOrientationChanged += OnDeviceOrientationChanged;

            application.Initialized += OnInitialized;
            application.Resumed += OnResumed;
            application.Terminating += OnTerminated;
            application.Paused += OnPaused;
            application.AppControl += OnAppControl;
            Tizen.Tracer.End();

            Tizen.Tracer.End();

            if (coreTask != null)
            {
                application.TaskBatteryLow += OnTaskBatteryLow;
                application.TaskLanguageChanged += OnTaskLanguageChanged;
                application.TaskMemoryLow += OnTaskMemoryLow;
                application.TaskRegionChanged += OnTaskRegionChanged;
                application.TaskDeviceOrientationChanged += OnTaskDeviceOrientationChanged;

                application.TaskInitialized += OnTaskInitialized;
                application.TaskTerminating += OnTaskTerminated;
                application.TaskAppControl += OnTaskAppControl;
                // Note: UIEvent, DeviceOrientationChanged are not implemented.
            }

            application.MainLoop();
            application.Dispose();
        }

        /// <summary>
        /// Sets the core task.
        /// </summary>
        /// <param name="task">The core task interface.</param>
        /// <since_tizen> 10 </since_tizen>
        public void SetCoreTask(ICoreTask task)
        {
            coreTask = task;
        }

        /// <summary>
        /// The Region changed event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for RegionChanged.</param>
        private void OnRegionChanged(object source, NUIApplicationRegionChangedEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnRegionChanged Called");
            var handler = Handlers[EventType.RegionFormatChanged] as Action<RegionFormatChangedEventArgs>;
            handler?.Invoke(new RegionFormatChangedEventArgs((source as Application)?.GetRegion()));
        }

        /// <summary>
        /// The Memory Low event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for MemoryLow.</param>
        private void OnMemoryLow(object source, NUIApplicationMemoryLowEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnMemoryLow Called");
            var handler = Handlers[EventType.LowMemory] as Action<LowMemoryEventArgs>;

            switch (e.MemoryStatus)
            {
                case Application.MemoryStatus.Normal:
                    {
                        handler?.Invoke(new LowMemoryEventArgs(LowMemoryStatus.None));
                        break;
                    }
                case Application.MemoryStatus.Low:
                    {
                        handler?.Invoke(new LowMemoryEventArgs(LowMemoryStatus.SoftWarning));
                        break;
                    }
                case Application.MemoryStatus.CriticallyLow:
                    {
                        handler?.Invoke(new LowMemoryEventArgs(LowMemoryStatus.HardWarning));
                        break;
                    }
            }
        }

        /// <summary>
        /// The Language changed event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for LanguageChanged.</param>
        private void OnLanguageChanged(object source, NUIApplicationLanguageChangedEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnLanguageChanged Called");
            var handler = Handlers[EventType.LocaleChanged] as Action<LocaleChangedEventArgs>;
            handler?.Invoke(new LocaleChangedEventArgs((source as Application)?.GetLanguage()));
        }

        /// <summary>
        /// The Battery Low event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for BatteryLow.</param>
        private void OnBatteryLow(object source, NUIApplicationBatteryLowEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnBatteryLow Called");
            var handler = Handlers[EventType.LowBattery] as Action<LowBatteryEventArgs>;
            switch (e.BatteryStatus)
            {
                case Application.BatteryStatus.Normal:
                    {
                        handler?.Invoke(new LowBatteryEventArgs(LowBatteryStatus.None));
                        break;
                    }
                case Application.BatteryStatus.CriticallyLow:
                    {
                        handler?.Invoke(new LowBatteryEventArgs(LowBatteryStatus.CriticalLow));
                        break;
                    }
                case Application.BatteryStatus.PowerOff:
                    {
                        handler?.Invoke(new LowBatteryEventArgs(LowBatteryStatus.PowerOff));
                        break;
                    }
            }
        }

        /// <summary>
        /// The Device Orientation changed event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for DeviceOrientationChanged.</param>
        private void OnDeviceOrientationChanged(object source, NUIApplicationDeviceOrientationChangedEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnDeviceOrientationChanged Called");
            var handler = Handlers[EventType.DeviceOrientationChanged] as Action<DeviceOrientationEventArgs>;

            switch (e.DeviceOrientationStatus)
            {
                case Application.DeviceOrientationStatus.Orientation_0:
                    {
                        handler?.Invoke(new DeviceOrientationEventArgs(DeviceOrientation.Orientation_0));
                        break;
                    }
                case Application.DeviceOrientationStatus.Orientation_90:
                    {
                        handler?.Invoke(new DeviceOrientationEventArgs(DeviceOrientation.Orientation_90));
                        break;
                    }
                case Application.DeviceOrientationStatus.Orientation_180:
                    {
                        handler?.Invoke(new DeviceOrientationEventArgs(DeviceOrientation.Orientation_180));
                        break;
                    }
                case Application.DeviceOrientationStatus.Orientation_270:
                    {
                        handler?.Invoke(new DeviceOrientationEventArgs(DeviceOrientation.Orientation_270));
                        break;
                    }
            }
        }

        /// <summary>
        /// The Initialized event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Initialized.</param>
        private void OnInitialized(object source, NUIApplicationInitEventArgs e)
        {
            Tizen.Tracer.Begin("[NUI] OnInitialized()");

            Log.Info("NUI", "NUICorebackend OnPreCreated Called");

            Tizen.Tracer.Begin("[NUI] OnInitialized(): OnPreCreated event handler");
            var preCreateHandler = Handlers[EventType.PreCreated] as Action;
            preCreateHandler?.Invoke();
            Tizen.Tracer.End();

            Log.Info("NUI", "NUICorebackend OnCreate Called");

            Tizen.Tracer.Begin("[NUI] OnInitialized(): OnCreated event handler");
            var createHandler = Handlers[EventType.Created] as Action;
            createHandler?.Invoke();
            Tizen.Tracer.End();

            Tizen.Tracer.End();
        }

        /// <summary>
        /// The Terminated event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Terminated.</param>
        private void OnTerminated(object source, NUIApplicationTerminatingEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnTerminated Called");
            var handler = Handlers[EventType.Terminated] as Action;
            handler?.Invoke();
        }

        /// <summary>
        /// The Resumed event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Resumed.</param>
        private void OnResumed(object source, NUIApplicationResumedEventArgs e)
        {
            Tizen.Tracer.Begin("[NUI] OnResumed()");

            Log.Info("NUI", "NUICorebackend OnResumed Called");

            Tizen.Tracer.Begin("[NUI] OnResumed(): OnResumed event handler");
            var handler = Handlers[EventType.Resumed] as Action;
            handler?.Invoke();
            Tizen.Tracer.End();

            Tizen.Tracer.End();
        }

        /// <summary>
        /// The App control event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for AppControl.</param>
        private void OnAppControl(object source, NUIApplicationAppControlEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnAppControl Called");
            var handler = Handlers[EventType.AppControlReceived] as Action<AppControlReceivedEventArgs>;
            using SafeAppControlHandle handle = new SafeAppControlHandle(e.VoidP, false);
            handler?.Invoke(new AppControlReceivedEventArgs(new ReceivedAppControl(handle)));
        }

        /// <summary>
        /// The Paused event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Paused.</param>
        private void OnPaused(object source, NUIApplicationPausedEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnPaused Called");
            var handler = Handlers[EventType.Paused] as Action;
            handler?.Invoke();
        }

        /// <summary>
        /// The Region changed event callback function. The callback is emitted on the main thread.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for RegionChanged.</param>
        private void OnTaskRegionChanged(object source, NUIApplicationRegionChangedEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnTaskRegionChanged Called");
            coreTask.OnRegionFormatChanged(new RegionFormatChangedEventArgs((source as Application)?.GetRegion()));
        }

        /// <summary>
        /// The Memory Low event callback function. The callback is emitted on the main thread.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for MemoryLow.</param>
        private void OnTaskMemoryLow(object source, NUIApplicationMemoryLowEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnTaskMemoryLow Called");
            switch (e.MemoryStatus)
            {
                case Application.MemoryStatus.Normal:
                    {
                        coreTask.OnLowMemory(new LowMemoryEventArgs(LowMemoryStatus.None));
                        break;
                    }
                case Application.MemoryStatus.Low:
                    {
                        coreTask.OnLowMemory(new LowMemoryEventArgs(LowMemoryStatus.SoftWarning));
                        break;
                    }
                case Application.MemoryStatus.CriticallyLow:
                    {
                        coreTask.OnLowMemory(new LowMemoryEventArgs(LowMemoryStatus.HardWarning));
                        break;
                    }
            }
        }

        /// <summary>
        /// The Language changed event callback function. The callback is emitted on the main thread.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for LanguageChanged.</param>
        private void OnTaskLanguageChanged(object source, NUIApplicationLanguageChangedEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnTaskLanguageChanged Called");
            coreTask.OnLocaleChanged(new LocaleChangedEventArgs((source as Application)?.GetLanguage()));
        }

        /// <summary>
        /// The Battery Low event callback function. The callback is emitted on the main thread.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for BatteryLow.</param>
        private void OnTaskBatteryLow(object source, NUIApplicationBatteryLowEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnTaskBatteryLow Called");
            switch (e.BatteryStatus)
            {
                case Application.BatteryStatus.Normal:
                    {
                        coreTask?.OnLowBattery(new LowBatteryEventArgs(LowBatteryStatus.None));
                        break;
                    }
                case Application.BatteryStatus.CriticallyLow:
                    {
                        coreTask?.OnLowBattery(new LowBatteryEventArgs(LowBatteryStatus.CriticalLow));
                        break;
                    }
                case Application.BatteryStatus.PowerOff:
                    {
                        coreTask?.OnLowBattery(new LowBatteryEventArgs(LowBatteryStatus.PowerOff));
                        break;
                    }
            }
        }

        /// <summary>
        /// The Orientation Changed event callback function. The callback is emitted on the main thread.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for changing device orientation.</param>
        private void OnTaskDeviceOrientationChanged(object source, NUIApplicationDeviceOrientationChangedEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnTaskBatteryLow Called");
            switch (e.DeviceOrientationStatus)
            {
                case Application.DeviceOrientationStatus.Orientation_0:
                    {
                        coreTask?.OnDeviceOrientationChanged(new DeviceOrientationEventArgs(DeviceOrientation.Orientation_0));
                        break;
                    }
                case Application.DeviceOrientationStatus.Orientation_90:
                    {
                        coreTask?.OnDeviceOrientationChanged(new DeviceOrientationEventArgs(DeviceOrientation.Orientation_90));
                        break;
                    }
                case Application.DeviceOrientationStatus.Orientation_180:
                    {
                        coreTask?.OnDeviceOrientationChanged(new DeviceOrientationEventArgs(DeviceOrientation.Orientation_180));
                        break;
                    }
                case Application.DeviceOrientationStatus.Orientation_270:
                    {
                        coreTask?.OnDeviceOrientationChanged(new DeviceOrientationEventArgs(DeviceOrientation.Orientation_270));
                        break;
                    }
            }
        }

        /// <summary>
        /// The Initialized event callback function. The callback is emitted on the main thread.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Initialized.</param>
        private void OnTaskInitialized(object source, NUIApplicationInitEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnTaskInitialized Called");
            coreTask.OnCreate();
        }

        /// <summary>
        /// The Terminated event callback function. The callback is emitted on the main thread.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Terminated.</param>
        private void OnTaskTerminated(object source, NUIApplicationTerminatingEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnTaskTerminated Called");
            coreTask.OnTerminate();
        }

        /// <summary>
        /// The App control event callback function. The callback is emitted on the main thread.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for AppControl.</param>
        private void OnTaskAppControl(object source, NUIApplicationAppControlEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnTaskAppControl Called");
            using SafeAppControlHandle handle = new SafeAppControlHandle(e.VoidP, false);
            coreTask.OnAppControlReceived(new AppControlReceivedEventArgs(new ReceivedAppControl(handle)));
        }

        internal Application ApplicationHandle
        {
            get
            {
                return application;
            }
        }
    }
}
