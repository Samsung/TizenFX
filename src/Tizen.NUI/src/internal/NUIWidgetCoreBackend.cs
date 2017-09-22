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

        /// <summary>
        /// Dictionary to contain each type of event callback.
        /// </summary>
        protected IDictionary<EventType, object> Handlers = new Dictionary<EventType, object>();

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public NUIWidgetCoreBackend()
        {
            //Tizen.Log.Fatal("NUI", "### NUIWidgetCoreBackend called");
            //_application = WidgetApplication.NewWidgetApplication();
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public NUIWidgetCoreBackend(string stylesheet)
        {
            _stylesheet = stylesheet;
            //_application = WidgetApplication.NewWidgetApplication(stylesheet);
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
            Tizen.Log.Fatal("NUI", "### NUIWidgetCoreBackend Dispose called");
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
            Tizen.Log.Fatal("NUI", "### NUIWidgetCoreBackend Exit called");
            if (_application != null)
            {
                _application.Quit();
            }
        }

        /// <summary>
        /// Run Application.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public void Run(string[] args)
        {
            args[0] = Tizen.Applications.Application.Current.ApplicationInfo.ExecutablePath;
            _application = WidgetApplication.NewWidgetApplication(args, _stylesheet);

            TizenSynchronizationContext.Initialize();
            _application.BatteryLow += OnBatteryLow;
            _application.LanguageChanged += OnLanguageChanged;
            _application.MemoryLow += OnMemoryLow;
            _application.RegionChanged += OnRegionChanged; ;

            _application.Init += OnInit;
            _application.Terminate += OnTerminate;

            _application.MainLoop();
        }

        private void OnInit(object sender, WidgetApplication.WidgetApplicationEventArgs e)
        {
            Log.Fatal("NUI", "NUIWidgetApplication OnPreCreated Called");
            var preCreateHandler = Handlers[EventType.PreCreated] as Action;
            preCreateHandler?.Invoke();

            Log.Fatal("NUI", "NUIWidgetApplication OnCreate Called");
            var createHandler = Handlers[EventType.Created] as Action;
            createHandler?.Invoke();

        }

        private void OnTerminate(object sender, WidgetApplication.WidgetApplicationEventArgs e)
        {
            Log.Fatal("NUI", "NUIWidgetApplication OnTerminated Called");
            var handler = Handlers[EventType.Terminated] as Action;
            handler?.Invoke();
        }

        /// <summary>
        /// Region changed event callback function.
        /// </summary>
        /// <param name="sender">Application instance</param>
        /// <param name="e">Event argument for RegionChanged</param>
        private void OnRegionChanged(object sender, WidgetApplication.WidgetApplicationEventArgs e)
        {
            Log.Fatal("NUI", "NUIWidgetApplication OnRegionChanged Called");
            var handler = Handlers[EventType.RegionFormatChanged] as Action<RegionFormatChangedEventArgs>;
            // Need to make new signal return in native to return right value.
            handler?.Invoke(new RegionFormatChangedEventArgs(""));
        }

        /// <summary>
        /// Memory Low event callback function.
        /// </summary>
        /// <param name="sender">Application instance</param>
        /// <param name="e">Event argument for MemoryLow</param>
        private void OnMemoryLow(object sender, WidgetApplication.WidgetApplicationEventArgs e)
        {
            Log.Fatal("NUI", "NUIWidgetApplication OnMemoryLow Called");
            var handler = Handlers[EventType.LowMemory] as Action<LowMemoryEventArgs>;
            // Need to make new signal return in native to return right value.
            handler?.Invoke(new LowMemoryEventArgs(LowMemoryStatus.None));
        }

        /// <summary>
        /// Language changed event callback function.
        /// </summary>
        /// <param name="sender">Application instance</param>
        /// <param name="e">Event argument for LanguageChanged</param>
        private void OnLanguageChanged(object sender, WidgetApplication.WidgetApplicationEventArgs e)
        {

            Log.Fatal("NUI", "NUIWidgetApplication OnLanguageChanged Called");
            var handler = Handlers[EventType.LocaleChanged] as Action<LocaleChangedEventArgs>;
            // Need to make new signal return in native to return right value.
            handler?.Invoke(new LocaleChangedEventArgs(""));

        }

        /// <summary>
        /// Battery low event callback function.
        /// </summary>
        /// <param name="sender">Application instance</param>
        /// <param name="e">Event argument for BatteryLow</param>
        private void OnBatteryLow(object sender, WidgetApplication.WidgetApplicationEventArgs e)
        {
            Log.Fatal("NUI", "NUIWidgetApplication OnBatteryLow Called");
            var handler = Handlers[EventType.LowBattery] as Action<LowBatteryEventArgs>;
            // Need to make new signal return in native to return right value.
            handler?.Invoke(new LowBatteryEventArgs(LowBatteryStatus.None));

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
