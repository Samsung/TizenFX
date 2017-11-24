/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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
using Tizen.Applications;
using Tizen.Applications.CoreBackend;
using Tizen.NUI;

namespace Tizen.NUI
{

    /// <summary>
    /// Represents an application that have UI screen. The NUIWidgetApplication class has a default stage.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Please do not use! This will be deprecated!")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NUIWidgetApplication : CoreApplication
    {

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public NUIWidgetApplication() : base(new NUIWidgetCoreBackend())
        {
            Tizen.Log.Fatal("NUI", "### NUIWidgetApplication called");
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        /// <param name="styleSheet">The styleSheet url.</param>
        /// <since_tizen> 4 </since_tizen>
        public NUIWidgetApplication(string styleSheet) : base(new NUIWidgetCoreBackend(styleSheet))
        {
            Tizen.Log.Fatal("NUI", "### NUIWidgetApplication(string) called");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            Log.Fatal("NUI", "OnLocaleChanged() is called!");
            base.OnLocaleChanged(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            Log.Fatal("NUI", "OnLowBattery() is called!");
            base.OnLowBattery(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            Log.Fatal("NUI", "OnLowMemory() is called!");
            base.OnLowMemory(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            Log.Fatal("NUI", "OnRegionFormatChanged() is called!");
            base.OnRegionFormatChanged(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnTerminate()
        {
            Log.Fatal("NUI", "OnTerminate() is called!");
            base.OnTerminate();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnPreCreate()
        {
            Log.Fatal("NUI", "OnPreCreate() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnCreate()
        {
            // This is also required to create DisposeQueue on main thread.
            DisposeQueue disposeQ = DisposeQueue.Instance;
            disposeQ.Initialize();
            Log.Fatal("NUI","OnCreate() is called!");
            base.OnCreate();
        }

        /// <summary>
        /// Run NUIWidgetApplication.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// <since_tizen> 4 </since_tizen>
        public override void Run(string[] args)
        {
            Backend.AddEventHandler(EventType.PreCreated, OnPreCreate);
            base.Run(args);
        }

        /// <summary>
        /// Exit NUIWidgetApplication.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public override void Exit()
        {
            Tizen.Log.Fatal("NUI", "### NUIWidgetApplication Exit called");
            base.Exit();
        }

        internal WidgetApplication ApplicationHandle
        {
            get
            {
                return ((NUIWidgetCoreBackend)this.Backend).WidgetApplicationHandle;
            }
        }
    }
}