/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.Applications;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// The class for supporting QuickPanel application model.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NUIQuickPanelApplication : CoreApplication
    {
        /// <summary>
        /// Initializes the QuickPanelApplication class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIQuickPanelApplication(string styleSheet = "", NUIApplication.WindowMode windowMode = NUIApplication.WindowMode.Opaque, ServiceType serviceType = ServiceType.SYSTEM_DEFAULT, bool scrolling = false, Size2D windowSize = null, Position2D windowPosition = null)
        : base(new NUIQuickPanelCoreBackend(styleSheet, windowMode, serviceType, scrolling, windowSize, windowPosition))
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollable(bool scrolling)
        {
            (Backend as NUIQuickPanelCoreBackend)?.SetScrollable(scrolling);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ServiceType GetServiceType()
        {
            return (Backend as NUIQuickPanelCoreBackend).GetServiceType();
        }

        /// <summary>
        /// Runs the application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Run(string[] args)
        {
            //Register Callback.
            base.Run(args);
        }

        /// <summary>
        /// Exits the main loop of the application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Exit()
        {
            base.Exit();
        }

        /// <summary>
        /// This method will be called before running main-loop
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnCreate()
        {
            base.OnCreate();
        }

        /// <summary>
        /// This method will be called after exiting main-loop
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnTerminate()
        {
            base.OnTerminate();
        }

        /// <summary>
        /// Overrides this method if want to handle OnLocaleChanged behavior.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            base.OnLocaleChanged(e);
        }

        /// <summary>
        /// Overrides this method if want to handle OnLowBattery behavior.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            base.OnLowBattery(e);
        }

        /// <summary>
        /// Overrides this method if want to handle OnLowMemory behavior.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            base.OnLowMemory(e);
        }

        /// <summary>
        /// Overrides this method if want to handle OnRegionFormatChanged behavior.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            base.OnRegionFormatChanged(e);
        }

        /// <summary>
     	/// Enumeration for type of quickpanel type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ServiceType
        {
            SYSTEM_DEFAULT = 1,
            CONTEXT_MENU = 2,
        };
    }
}

