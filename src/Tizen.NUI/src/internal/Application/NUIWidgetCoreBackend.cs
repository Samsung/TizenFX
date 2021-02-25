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
    class NUIWidgetCoreBackend : ICoreBackend
    {
        /// <summary>
        /// Application instance to connect event.
        /// </summary>
        protected WidgetApplication _application;
        private string _stylesheet = "";
        Dictionary<System.Type, string> _widgetInfo;

        /// <summary>
        /// Dictionary to contain each type of event callback.
        /// </summary>
        protected IDictionary<EventType, object> Handlers = new Dictionary<EventType, object>();

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public NUIWidgetCoreBackend()
        {
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public NUIWidgetCoreBackend(string stylesheet)
        {
            _stylesheet = stylesheet;
        }

        /// <summary>
        /// Add NUIWidgetApplication event to Application.
        /// Put each type of event callback in Dictionary.
        /// </summary>
        /// <param name="evType">Type of event</param>
        /// <param name="handler">Event callback</param>
        public void AddEventHandler(EventType evType, Action handler)
        {
            Handlers.Add(evType, handler);
        }

        /// <summary>
        /// Add NUIWidgetApplication event to Application.
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
            if (_application != null)
            {
                _application.Dispose();
            }
        }

        /// <summary>
        /// Exit Application.
        /// </summary>
        public void Exit()
        {
            if (_application != null)
            {
                _application.Quit();
            }
        }

        public void RegisterWidgetInfo(Dictionary<System.Type, string> widgetInfo)
        {
            _widgetInfo = widgetInfo;
        }

        public void AddWidgetInfo(Dictionary<System.Type, string> widgetInfo)
        {
            if (_application != null)
            {
                _application.AddWidgetInfo(widgetInfo);
            }
        }

        /// <summary>
        /// Run Application.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public void Run(string[] args)
        {
            TizenSynchronizationContext.Initialize();

            args[0] = Tizen.Applications.Application.Current.ApplicationInfo.ExecutablePath;
            _application = WidgetApplication.NewWidgetApplication(args, _stylesheet);
            _application.RegisterWidgetInfo(_widgetInfo);

            _application.BatteryLow += OnBatteryLow;
            _application.LanguageChanged += OnLanguageChanged;
            _application.MemoryLow += OnMemoryLow;
            _application.RegionChanged += OnRegionChanged; ;
            _application.Initialized += OnInitialized;
            _application.Terminating += OnTerminated;

            _application.MainLoop();
        }

        /// <summary>
        /// The Initialized event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Initialized.</param>
        private void OnInitialized(object source, NUIApplicationInitEventArgs e)
        {
            var preCreateHandler = Handlers[EventType.PreCreated] as Action;
            preCreateHandler?.Invoke();

            var createHandler = Handlers[EventType.Created] as Action;
            createHandler?.Invoke();
            _application.RegisterWidgetCreatingFunction();
        }

        /// <summary>
        /// The Terminated event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Terminated.</param>
        private void OnTerminated(object source, NUIApplicationTerminatingEventArgs e)
        {
            var handler = Handlers[EventType.Terminated] as Action;
            handler?.Invoke();
        }

        /// <summary>
        /// The Region changed event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for RegionChanged.</param>
        private void OnRegionChanged(object source, NUIApplicationRegionChangedEventArgs e)
        {
            var handler = Handlers[EventType.RegionFormatChanged] as Action<RegionFormatChangedEventArgs>;
            handler?.Invoke(new RegionFormatChangedEventArgs(e.Application.GetRegion()));
        }

        /// <summary>
        /// The Language changed event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for LanguageChanged.</param>
        private void OnLanguageChanged(object source, NUIApplicationLanguageChangedEventArgs e)
        {
            var handler = Handlers[EventType.LocaleChanged] as Action<LocaleChangedEventArgs>;
            handler?.Invoke(new LocaleChangedEventArgs(e.Application.GetLanguage()));
        }

        /// <summary>
        /// The Memory Low event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for MemoryLow.</param>
        private void OnMemoryLow(object source, NUIApplicationMemoryLowEventArgs e)
        {
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
        /// The Battery Low event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for BatteryLow.</param>
        private void OnBatteryLow(object source, NUIApplicationBatteryLowEventArgs e)
        {
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

        internal WidgetApplication WidgetApplicationHandle
        {
            get
            {
                return _application;
            }
        }
    }
}
