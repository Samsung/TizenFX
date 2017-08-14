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
using Tizen.Applications;
using Tizen.Applications.CoreBackend;
using Tizen.NUI;

namespace Tizen.NUI
{

    /// <summary>
    /// Represents an application that have UI screen. The NUIApplication class has a default stage.
    /// </summary>
    public class NUIApplication : CoreApplication
    {
        /// <summary>
        /// The instance of ResourceManager.
        /// </summary>
        private static System.Resources.ResourceManager resourceManager = null;
        /// <summary>
        /// The default constructor.
        /// </summary>
        public NUIApplication() : base(new NUICoreBackend())
        {
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public NUIApplication(string stylesheet) : base(new NUICoreBackend(stylesheet))
        {
        }

        /// <summary>
        /// The constructor with stylesheet and window mode.
        /// </summary>
        public NUIApplication(string stylesheet, WindowMode windowMode) : base(new NUICoreBackend(stylesheet,windowMode))
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            Log.Debug("NUI", "OnLowBattery() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            Log.Debug("NUI", "OnLowMemory() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            Log.Debug("NUI", "OnRegionFormatChanged() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnTerminate()
        {
            Log.Debug("NUI", "OnTerminate() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnPause()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnResume()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnPreCreate()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            Log.Debug("NUI", "OnAppControlReceived() is called!");
            if (e != null)
            {
                Log.Debug("NUI", "OnAppControlReceived() is called! ApplicationId=" + e.ReceivedAppControl.ApplicationId);
                Log.Debug("NUI", "CallerApplicationId=" + e.ReceivedAppControl.CallerApplicationId + "   IsReplyRequest=" + e.ReceivedAppControl.IsReplyRequest);
            }
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnCreate()
        {
            // This is also required to create DisposeQueue on main thread.
            DisposeQueue disposeQ = DisposeQueue.Instance;
            disposeQ.Initialize();
            Log.Debug("NUI","OnCreate() is called!");
        }

        /// <summary>
        /// Run NUIApplication.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            string[] argsClone = null;

            if (args == null)
            {
                argsClone = new string[1];
            }
            else
            {
                argsClone = new string[args.Length + 1];
                args.CopyTo(argsClone, 1);
            }
            argsClone[0] = string.Empty;

            Backend.AddEventHandler(EventType.PreCreated, OnPreCreate);
            Backend.AddEventHandler(EventType.Created, OnCreate);
            Backend.AddEventHandler<AppControlReceivedEventArgs>(EventType.AppControlReceived, OnAppControlReceived);
            Backend.AddEventHandler(EventType.Resumed, OnResume);
            Backend.AddEventHandler(EventType.Paused, OnPause);
            Backend.AddEventHandler(EventType.Terminated, OnTerminate);
            Backend.AddEventHandler<RegionFormatChangedEventArgs>(EventType.RegionFormatChanged, OnRegionFormatChanged);
            Backend.AddEventHandler<LowMemoryEventArgs>(EventType.LowMemory, OnLowMemory);
            Backend.AddEventHandler<LowBatteryEventArgs>(EventType.LowBattery, OnLowBattery);
            Backend.AddEventHandler<LocaleChangedEventArgs>(EventType.LocaleChanged, OnLocaleChanged);

            Backend.Run(argsClone);
        }

        /// <summary>
        /// Exit NUIApplication.
        /// </summary>
        public override void Exit()
        {
            Backend.Exit();
        }

        /// <summary>
        /// Enumeration for deciding whether a NUI application window is opaque or transparent.
        /// </summary>
        public enum WindowMode
        {
            Opaque = 0,
            Transparent = 1
        }


        internal Application ApplicationHandle
        {
            get
            {
                return ((NUICoreBackend)this.Backend).ApplicationHandle;
            }
        }

        /// <summary>
        /// ResourceManager to handle multilingual
        /// </summary>
        public static System.Resources.ResourceManager MultilingualResourceManager
        {
            get
            {
                return resourceManager;
            }
            set
            {
                resourceManager = value;
            }
        }
    }
}
