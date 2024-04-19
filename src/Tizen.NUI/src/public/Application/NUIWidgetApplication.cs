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
using Tizen.Applications;
using Tizen.Applications.CoreBackend;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System;

namespace Tizen.NUI
{
    /// <summary>
    /// Represents an application that have UI screen. The NUIWidgetApplication class has a default stage.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class NUIWidgetApplication : CoreApplication
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <remarks>Widget ID will be replaced as the application ID.</remarks>
        /// <param name="widgetType">Derived widget class type.</param>
        public NUIWidgetApplication(System.Type widgetType) : base(new NUIWidgetCoreBackend())
        {
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
            NUIWidgetCoreBackend core = Backend as NUIWidgetCoreBackend;
            core?.RegisterWidgetInfo(new Dictionary<System.Type, string> { { widgetType, ApplicationInfo.ApplicationId } });
        }

        /// <summary>
        /// The constructor for multi widget class and instance.
        /// </summary>
        /// <param name="widgetTypes">List of derived widget class type.</param>
        public NUIWidgetApplication(Dictionary<System.Type, string> widgetTypes) : base(new NUIWidgetCoreBackend())
        {
            if (widgetTypes == null)
            {
                throw new InvalidOperationException("Dictionary is null");
            }
            else
            {
                Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
                NUIWidgetCoreBackend core = Backend as NUIWidgetCoreBackend;
                core?.RegisterWidgetInfo(widgetTypes);
            }
        }

        /// <summary>
        /// The default constructor with stylesheet.
        /// </summary>
        /// <remarks>Widget ID will be replaced as the application ID.</remarks>
        /// <param name="widgetType">Derived widget class type.</param>
        /// <param name="styleSheet">The styleSheet url.</param>
        /// <since_tizen> 4 </since_tizen>
        public NUIWidgetApplication(System.Type widgetType, string styleSheet) : base(new NUIWidgetCoreBackend(styleSheet))
        {
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
            NUIWidgetCoreBackend core = Backend as NUIWidgetCoreBackend;
            core?.RegisterWidgetInfo(new Dictionary<System.Type, string> { { widgetType, ApplicationInfo.ApplicationId } });
        }

        /// <summary>
        /// Add WidgetInfo in runtime
        /// </summary>
        /// <param name="widgetType">Derived widget class type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddWidgetType(System.Type widgetType)
        {
            NUIWidgetCoreBackend core = Backend as NUIWidgetCoreBackend;
            core?.AddWidgetInfo(new Dictionary<System.Type, string> { { widgetType, ApplicationInfo.ApplicationId } });
        }

        /// <summary>
        /// Add WidgetInfo in runtime
        /// </summary>
        /// <param name="widgetTypes">Derived widget class type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddWidgetType(Dictionary<System.Type, string> widgetTypes)
        {
            NUIWidgetCoreBackend core = Backend as NUIWidgetCoreBackend;
            core?.AddWidgetInfo(widgetTypes);
        }

        /// <summary>
        /// Set to true if XAML is used. 
        /// This must be called before or immediately after the NUIWidgetApplication constructor is called.
        /// The default value is true.
        /// </summary>
        /// <remarks>
        /// This must be called before or immediately after the NUIWidgetApplication constructor is called.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public bool IsUsingXaml { get; set; } = true;

        internal WidgetApplication ApplicationHandle
        {
            get
            {
                return ((NUIWidgetCoreBackend)this.Backend).WidgetApplicationHandle;
            }
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

        /// <summary>
        /// Flush render/update thread messages synchronously.
        /// </summary>
        /// <remarks>
        /// This function will relayout forcibily.
        /// This function is used for advanced developer. It will make main-thread overhead if you call this function frequencely.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void FlushUpdateMessages()
        {
            ApplicationHandle.FlushUpdateMessages();
        }

        /// <summary>
        /// Overrides this method if want to handle OnLocaleChanged behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            Log.Fatal("NUI", "OnLocaleChanged() is called!");
            base.OnLocaleChanged(e);
        }

        /// <summary>
        /// Overrides this method if want to handle OnLowBattery behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            Log.Fatal("NUI", "OnLowBattery() is called!");
            base.OnLowBattery(e);
        }

        /// <summary>
        /// Overrides this method if want to handle OnLowMemory behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            Log.Fatal("NUI", "OnLowMemory() is called!");
            base.OnLowMemory(e);
        }

        /// <summary>
        /// Overrides this method if want to handle OnRegionFormatChanged behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            Log.Fatal("NUI", "OnRegionFormatChanged() is called!");
            base.OnRegionFormatChanged(e);
        }

        /// <summary>
        /// This method is to handle behavior when the device orientation is changed.
        ///
        /// When device is rotated to ccw or cw, this event occurs.
        /// In addition, this event is different to window orientation changed event.
        /// The window orientation event is for per a window and occurs when some flags should be set before.
        /// </summary>
        /// <param name="e">The device orientation changed event argument</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
            Log.Fatal("NUI", "OnDeviceOrientationChanged() is called!");
            base.OnDeviceOrientationChanged(e);
        }

        /// <summary>
        /// Overrides this method if want to handle OnTerminate behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnTerminate()
        {
            Log.Fatal("NUI", "OnTerminate() is called!");
            base.OnTerminate();
        }

        /// <summary>
        /// Overrides this method if want to handle OnPreCreate behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnPreCreate()
        {
            Log.Fatal("NUI", "OnPreCreate() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle OnCreate behavior.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnCreate()
        {
            // This is also required to create DisposeQueue on main thread.
            DisposeQueue disposeQ = DisposeQueue.Instance;
            disposeQ.Initialize();
            Log.Fatal("NUI", "OnCreate() is called!");
            base.OnCreate();
        }
    }
}
