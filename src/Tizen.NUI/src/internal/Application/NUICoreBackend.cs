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
using System.Collections.Generic;
using Tizen.Applications.CoreBackend;
using Tizen.Applications;

namespace Tizen.NUI
{
    class NUICoreBackend : ICoreBackend
    {
        /// <summary>
        /// The Application instance to connect event.
        /// </summary>
        protected Application application;
        private string stylesheet = "";
        private NUIApplication.WindowMode windowMode = NUIApplication.WindowMode.Opaque;
        private Rectangle windowRectangle = null;

        /// <summary>
        /// The Dictionary to contain each type of event callback.
        /// </summary>
        protected IDictionary<EventType, object> Handlers = new Dictionary<EventType, object>();

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
            TizenSynchronizationContext.Initialize();

            args[0] = Tizen.Applications.Application.Current.ApplicationInfo.ExecutablePath;
            if (string.IsNullOrEmpty(args[0]))
            {
                args[0] = this.GetType().Assembly.FullName.Replace(" ", "");
            }

            if (windowRectangle != null)
            {
                application = Application.NewApplication(args, stylesheet, windowMode, windowRectangle);
            }
            else
            {
                application = Application.NewApplication(args, stylesheet, windowMode);
            }

            application.BatteryLow += OnBatteryLow;
            application.LanguageChanged += OnLanguageChanged;
            application.MemoryLow += OnMemoryLow;
            application.RegionChanged += OnRegionChanged;

            application.Initialized += OnInitialized;
            application.Resumed += OnResumed;
            application.Terminating += OnTerminated;
            application.Paused += OnPaused;
            application.AppControl += OnAppControl;

            application.MainLoop();
            application.Dispose();
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
        /// The Initialized event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Initialized.</param>
        private void OnInitialized(object source, NUIApplicationInitEventArgs e)
        {
            Log.Info("NUI", "NUICorebackend OnPreCreated Called");
            var preCreateHandler = Handlers[EventType.PreCreated] as Action;
            preCreateHandler?.Invoke();

            Log.Info("NUI", "NUICorebackend OnCreate Called");
            var createHandler = Handlers[EventType.Created] as Action;
            createHandler?.Invoke();
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
            Log.Info("NUI", "NUICorebackend OnResumed Called");
            var handler = Handlers[EventType.Resumed] as Action;
            handler?.Invoke();
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
            SafeAppControlHandle handle = new SafeAppControlHandle(e.VoidP, false);
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

        internal Application ApplicationHandle
        {
            get
            {
                return application;
            }
        }
    }
}
