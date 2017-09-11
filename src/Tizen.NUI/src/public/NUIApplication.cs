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
        /// Occurs whenever the application is resumed.
        /// </summary>
        public event EventHandler Resumed;

        /// <summary>
        /// Occurs whenever the application is paused.
        /// </summary>
        public event EventHandler Paused;

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
            Log.Debug("NUI", "OnLocaleChanged() is called!");
            base.OnLocaleChanged(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            Log.Debug("NUI", "OnLowBattery() is called!");
            base.OnLowBattery(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            Log.Debug("NUI", "OnLowMemory() is called!");
            base.OnLowMemory(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            Log.Debug("NUI", "OnRegionFormatChanged() is called!");
            base.OnRegionFormatChanged(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnTerminate()
        {
            Log.Debug("NUI", "OnTerminate() is called!");
            base.OnTerminate();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnPause()
        {
            Log.Debug("NUI", "OnPause() is called!");
            Paused?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnResume()
        {
            Log.Debug("NUI", "OnResume() is called!");
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnPreCreate()
        {
            Log.Debug("NUI", "OnPreCreate() is called!");
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
            base.OnAppControlReceived(e);
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
            base.OnCreate();
        }

        /// <summary>
        /// Run NUIApplication.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            Backend.AddEventHandler(EventType.PreCreated, OnPreCreate);
            Backend.AddEventHandler(EventType.Resumed, OnResume);
            Backend.AddEventHandler(EventType.Paused, OnPause);
            base.Run(args);
        }

        /// <summary>
        /// Exit NUIApplication.
        /// </summary>
        public override void Exit()
        {
            base.Exit();
        }

        /// <summary>
        /// Ensures that the function passed in is called from the main loop when it is idle.
        /// </summary>
        /// <param name="func">The function to call</param>
        /// <returns>true if added successfully, false otherwise</returns>
        public bool AddIdle(System.Delegate func)
        {
            return ((NUICoreBackend)this.Backend).AddIdle(func);
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

        /// <summary>
        /// Get the window instance.
        /// </summary>
        [Obsolete("Please do not use! this will be deprecated")]
        public Window Window
        {
            get
            {
                return Window.Instance;
            }
        }
    }
}
