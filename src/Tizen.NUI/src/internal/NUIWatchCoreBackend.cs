/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
    class NUIWatchCoreBackend : ICoreBackend
    {
        /// <summary>
        /// Application instance to connect event.
        /// </summary>
        protected WatchApplication _application;
        private string _stylesheet = "";

        /// <summary>
        /// Dictionary to contain each type of event callback.
        /// </summary>
        protected IDictionary<EventType, object> Handlers = new Dictionary<EventType, object>();

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public NUIWatchCoreBackend()
        {
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public NUIWatchCoreBackend(string stylesheet)
        {
            _stylesheet = stylesheet;
        }

        /// <summary>
        /// Add NUIApplication event to Application.
        /// Put each type of event callback in Dictionary.
        /// </summary>
        /// <param name="evType">Type of event</param>
        /// <param name="handler">Event callback</param>
        public void AddEventHandler(EventType evType, Action handler)
        {
            Handlers.Add(evType, handler);
        }

        /// <summary>
        /// Add NUIApplication event to Application.
        /// Put each type of event callback in Dictionary.
        /// </summary>
        /// <typeparam name="TEventArgs">Argument type for the event</typeparam>
        /// <param name="evType">Type of event</param>
        /// <param name="handler">Event callback</param>
        public void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs
        {
            Handlers.Add(evType, handler);
        }


        /// <summary>
        /// Dispose function.
        /// </summary>
        public void Dispose()
        {
            _application.Dispose();
        }

        /// <summary>
        /// Exit Application.
        /// </summary>
        public void Exit()
        {
            _application.Quit();
        }

        /// <summary>
        /// Run Application.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public void Run(string[] args)
        {
            args[0] = Tizen.Applications.Application.Current.ApplicationInfo.ExecutablePath;
            if (args.Length == 1)
            {
                _application = WatchApplication.NewWatchApplication();
            }
            else if (args.Length > 1)
            {
                _application = WatchApplication.NewWatchApplication(args, _stylesheet);
            }

            _application.BatteryLow += OnBatteryLow;
            _application.LanguageChanged += OnLanguageChanged;
            _application.MemoryLow += OnMemoryLow;
            _application.RegionChanged += OnRegionChanged;

            _application.Initialized += OnInitialized;
            _application.Resumed += OnResumed;
            _application.Terminating += OnTerminated;
            _application.Paused += OnPaused;
            _application.AppControl += OnAppControl;

            _application.AmbientChanged += OnAmbientChanged;
            _application.AmbientTick += OnAmbientTick;
            _application.TimeTick += OnTimeTick;

            _application.MainLoop();
        }

        private void OnTimeTick(object source, WatchApplication.TimeTickEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnTimeTick Called");
            var handler = Handlers[NUIEventType.TimeTick] as Action<NUIWatchApplication.TimeTickEventArgs>;
            handler?.Invoke(new NUIWatchApplication.TimeTickEventArgs(e.WatchTime));
        }

        private void OnAmbientTick(object source, WatchApplication.AmbientTickEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnAmbientTick Called");
            var handler = Handlers[NUIEventType.AmbientTick] as Action<NUIWatchApplication.AmbientTickEventArgs>;
            handler?.Invoke(new NUIWatchApplication.AmbientTickEventArgs(e.WatchTime));
        }

        private void OnAmbientChanged(object source, WatchApplication.AmbientChangedEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnAmbientChanged Called");
            var handler = Handlers[NUIEventType.AmbientChanged] as Action<NUIWatchApplication.AmbientChangedEventArgs>;
            handler?.Invoke(new NUIWatchApplication.AmbientChangedEventArgs(e.Changed));
        }

        /// <summary>
        /// Region changed event callback function.
        /// </summary>
        /// <param name="source">Application instance</param>
        /// <param name="e">Event argument for RegionChanged</param>
        private void OnRegionChanged(object source, NUIApplicationRegionChangedEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnRegionChanged Called");
            var handler = Handlers[EventType.RegionFormatChanged] as Action<RegionFormatChangedEventArgs>;
            // Need to make new signal return in native to return right value.
            handler?.Invoke( new RegionFormatChangedEventArgs(""));
        }

        /// <summary>
        /// Memory Low event callback function.
        /// </summary>
        /// <param name="source">Application instance</param>
        /// <param name="e">Event argument for MemoryLow</param>
        private void OnMemoryLow(object source, NUIApplicationMemoryLowEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnMemoryLow Called");
            var handler = Handlers[EventType.LowMemory] as Action<LowMemoryEventArgs>;
            // Need to make new signal return in native to return right value.
            handler?.Invoke( new LowMemoryEventArgs(LowMemoryStatus.None));
        }

        /// <summary>
        /// Language changed event callback function.
        /// </summary>
        /// <param name="source">Application instance</param>
        /// <param name="e">Event argument for LanguageChanged</param>
        private void OnLanguageChanged(object source, NUIApplicationLanguageChangedEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnLanguageChanged Called");
            var handler = Handlers[EventType.LocaleChanged] as Action<LocaleChangedEventArgs>;
            // Need to make new signal return in native to return right value.
            handler?.Invoke( new LocaleChangedEventArgs(""));
        }

        /// <summary>
        /// Battery low event callback function.
        /// </summary>
        /// <param name="source">Application instance</param>
        /// <param name="e">Event argument for BatteryLow</param>
        private void OnBatteryLow(object source, NUIApplicationBatteryLowEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnBatteryLow Called");
            var handler = Handlers[EventType.LowBattery] as Action<LowBatteryEventArgs>;
            // Need to make new signal return in native to return right value.
            handler?.Invoke(new LowBatteryEventArgs(LowBatteryStatus.None));
        }

        /// <summary>
        /// Initialized event callback function.
        /// </summary>
        /// <param name="source">Application instance</param>
        /// <param name="e">Event argument for Initialized</param>
        private void OnInitialized(object source, NUIApplicationInitEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnInitialized Called");
            var handler = Handlers[EventType.Created] as Action;
            handler?.Invoke();
        }

        /// <summary>
        /// Terminated event callback function.
        /// </summary>
        /// <param name="source">Application instance</param>
        /// <param name="e">Event argument for Terminated</param>
        private void OnTerminated(object source, NUIApplicationTerminatingEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnTerminated Called");
            var handler = Handlers[EventType.Terminated] as Action;
            handler?.Invoke();
        }

        /// <summary>
        /// Resumed event callback function.
        /// </summary>
        /// <param name="source">Application instance</param>
        /// <param name="e">Event argument for Resumed</param>
        private void OnResumed(object source, NUIApplicationResumedEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnResumed Called");
            var handler = Handlers[EventType.Resumed] as Action;
            handler?.Invoke();
        }

        /// <summary>
        /// App control event callback function.
        /// </summary>
        /// <param name="source">Application instance</param>
        /// <param name="e">Event argument for AppControl</param>
        private void OnAppControl(object source, NUIApplicationAppControlEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnAppControl Called");
            var handler = Handlers[EventType.AppControlReceived] as Action<AppControlReceivedEventArgs>;
            SafeAppControlHandle handle = new SafeAppControlHandle(e.VoidP, false);
            handler?.Invoke(new AppControlReceivedEventArgs(new ReceivedAppControl(handle)));
        }

        /// <summary>
        /// Paused event callback function.
        /// </summary>
        /// <param name="source">Application instance</param>
        /// <param name="e">Event argument for Paused</param>
        private void OnPaused(object source, NUIApplicationPausedEventArgs e)
        {
            Log.Debug("NUI", "NUIWatchCorebackend OnPaused Called");
            var handler = Handlers[EventType.Paused] as Action;
            handler?.Invoke();
        }

        internal WatchApplication WatchApplicationHandle
        {
            get
            {
                return _application;
            }
        }

    }
}
