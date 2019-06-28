/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using System.Threading;
using System.Reflection;
using Tizen.Applications;
using Tizen.Applications.CoreBackend;

namespace Tizen.NUI
{

    /// <summary>
    /// Represents an application that have a UI screen. The NUIApplication class has a default stage.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NUIApplication : CoreApplication
    {
        /// <summary>
        /// The instance of ResourceManager.
        /// </summary>
        private static System.Resources.ResourceManager resourceManager = null;
        private Size2D _windowSize2D = null;
        private Position2D _windowPosition2D = null;

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public NUIApplication() : base(new NUICoreBackend())
        {
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
        }

        /// <summary>
        /// The constructor with window size and position.
        /// </summary>
        /// <param name="windowSize">The window size.</param>
        /// <param name="windowPosition">The window position.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIApplication(Size2D windowSize, Position2D windowPosition) : base(new NUICoreBackend())
        {
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
            _windowSize2D = windowSize;
            _windowPosition2D = windowPosition;
        }

        /// <summary>
        /// The constructor with a stylesheet.
        /// </summary>
        /// <param name="styleSheet">The styleSheet url.</param>
        /// <since_tizen> 3 </since_tizen>
        public NUIApplication(string styleSheet) : base(new NUICoreBackend(styleSheet))
        {
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
        }

        /// <summary>
        /// The constructor with a stylesheet, window size, and position.
        /// </summary>
        /// <param name="styleSheet">The styleSheet URL.</param>
        /// <param name="windowSize">The window size.</param>
        /// <param name="windowPosition">The window position.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIApplication(string styleSheet, Size2D windowSize, Position2D windowPosition) : base(new NUICoreBackend(styleSheet))
        {
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
            _windowSize2D = windowSize;
            _windowPosition2D = windowPosition;
        }

        /// <summary>
        /// The constructor with a stylesheet and window mode.
        /// </summary>
        /// <param name="styleSheet">The styleSheet url.</param>
        /// <param name="windowMode">The windowMode.</param>
        /// <since_tizen> 3 </since_tizen>
        public NUIApplication(string styleSheet, WindowMode windowMode) : base(new NUICoreBackend(styleSheet, windowMode))
        {
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
        }

        /// <summary>
        /// The constructor with a stylesheet, window mode, window size, and position.
        /// </summary>
        /// <param name="styleSheet">The styleSheet URL.</param>
        /// <param name="windowMode">The windowMode.</param>
        /// <param name="windowSize">The window size.</param>
        /// <param name="windowPosition">The window position.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIApplication(string styleSheet, WindowMode windowMode, Size2D windowSize, Position2D windowPosition) : base(new NUICoreBackend(styleSheet, windowMode))
        {
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
            _windowSize2D = windowSize;
            _windowPosition2D = windowPosition;
        }

        /// <summary>
        /// Internal inhouse constructor with Graphics Backend Type
        /// </summary>
        /// <param name="backend"></param>
        /// <param name="windowMode"></param>
        /// <param name="windowSize"></param>
        /// <param name="windowPosition"></param>
        /// <param name="styleSheet"></param>
        /// InhouseAPI, this could be opend in NextTizen
        [Obsolete("Please do not use! This will be deprecated!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIApplication(Graphics.BackendType backend, WindowMode windowMode = WindowMode.Opaque, Size2D windowSize = null, Position2D windowPosition = null, string styleSheet = "") : base(new NUICoreBackend(styleSheet, windowMode))
        {
            //windowMode and styleSheet will be added later. currenlty it's not working as expected.
            Graphics.Backend = backend;
            Tizen.Log.Error("NUI", "Plaese DO NOT set graphical backend type with this constructor! This will give no effect!");

            if (windowSize != null) { _windowSize2D = windowSize; }
            if (windowPosition != null) { _windowPosition2D = windowPosition; }
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
        }

        /// <summary>
        /// Occurs whenever the application is resumed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler Resumed;

        /// <summary>
        /// Occurs whenever the application is paused.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler Paused;

        /// <summary>
        /// Enumeration for deciding whether a NUI application window is opaque or transparent.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum WindowMode
        {
            /// <summary>
            /// Opaque
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Opaque = 0,
            /// <summary>
            /// Transparent
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Transparent = 1
        }

        /// <summary>
        /// ResourceManager to handle multilingual.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the window instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window Window
        {
            get
            {
                return Window.Instance;
            }
        }

        /// <summary>
        /// Gets the default window.
        /// </summary>
        /// <returns>The default Window.</returns>
        /// <since_tizen> 6 </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Window GetDefaultWindow()
        {
            return Window.Instance;
        }

        internal Application ApplicationHandle
        {
            get
            {
                return ((NUICoreBackend)this.Backend).ApplicationHandle;
            }
        }

        /// <summary>
        /// Register the assembly to XAML.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static void RegisterAssembly(Assembly assembly)
        {
        }

        /// <summary>
        /// Runs the NUIApplication.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// <since_tizen> 4 </since_tizen>
        public override void Run(string[] args)
        {
            Backend.AddEventHandler(EventType.PreCreated, OnPreCreate);
            Backend.AddEventHandler(EventType.Resumed, OnResume);
            Backend.AddEventHandler(EventType.Paused, OnPause);
            base.Run(args);
        }

        /// <summary>
        /// Exits the NUIApplication.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public override void Exit()
        {
            base.Exit();
        }

        /// <summary>
        /// Ensures that the function passed in is called from the main loop when it is idle.
        /// </summary>
        /// <param name="func">The function to call</param>
        /// <returns>true if added successfully, false otherwise</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool AddIdle(System.Delegate func)
        {
            return ((NUICoreBackend)this.Backend).AddIdle(func);
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            base.OnLocaleChanged(e);
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            base.OnLowBattery(e);
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            base.OnLowMemory(e);
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            base.OnRegionFormatChanged(e);
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void OnTerminate()
        {
            base.OnTerminate();
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnPause()
        {
            Paused?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnResume()
        {
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnPreCreate()
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            if (e != null)
            {
                Log.Info("NUI", "OnAppControlReceived() is called! ApplicationId=" + e.ReceivedAppControl.ApplicationId);
                Log.Info("NUI", "CallerApplicationId=" + e.ReceivedAppControl.CallerApplicationId + "   IsReplyRequest=" + e.ReceivedAppControl.IsReplyRequest);
            }
            base.OnAppControlReceived(e);
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void OnCreate()
        {
            Application.Instance.AddWindowList(Window.Instance);
            base.OnCreate();
        }
    }

    /// <summary>
    /// Graphics Backend Type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Please do not use! This will be deprecated!")]
    public class Graphics
    {
        /// <summary>
        /// Graphics Backend Type.
        /// </summary>
        public enum BackendType
        {
            /// <summary>
            /// The GLES backend.
            /// </summary>
            Gles,
            /// <summary>
            /// The Vulkan backend.
            /// </summary>
            Vulkan
        }

        /// <summary>
        /// The backend used by the NUIApplication.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackendType Backend = BackendType.Gles;

        internal const string GlesCSharpBinder = NDalicPINVOKE.Lib;
        internal const string VulkanCSharpBinder = "libdali-csharp-binder-vk.so";
    }

}
