/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Reflection;
using Tizen.Applications;
using Tizen.Applications.CoreBackend;
using Tizen.NUI.Xaml;

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
        private static string currentLoadedXaml = null;

        /// <summary>
        /// Xaml loaded delegate.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void XamlLoadedHandler(string xamlName);

        static NUIApplication()
        {
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
        }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "NUICoreBackend is disposed in the base class when the application is terminated")]
        public NUIApplication() : base(new NUICoreBackend())
        {
        }

        /// <summary>
        /// The constructor with window size and position.
        /// </summary>
        /// <param name="windowSize">The window size.</param>
        /// <param name="windowPosition">The window position.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "NUICoreBackend is disposed in the base class when the application is terminated")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIApplication(Size2D windowSize, Position2D windowPosition) : base(new NUICoreBackend("", NUIApplication.WindowMode.Opaque, windowSize, windowPosition))
        {
        }

        /// <summary>
        /// The constructor with a stylesheet.
        /// </summary>
        /// <param name="styleSheet">The styleSheet url.</param>
        /// <since_tizen> 3 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "NUICoreBackend is disposed in the base class when the application is terminated")]
        public NUIApplication(string styleSheet) : base(new NUICoreBackend(styleSheet))
        {
        }

        /// <summary>
        /// The constructor with a stylesheet, window size, and position.
        /// </summary>
        /// <param name="styleSheet">The styleSheet URL.</param>
        /// <param name="windowSize">The window size.</param>
        /// <param name="windowPosition">The window position.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "NUICoreBackend is disposed in the base class when the application is terminated")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIApplication(string styleSheet, Size2D windowSize, Position2D windowPosition) : base(new NUICoreBackend(styleSheet, WindowMode.Opaque, windowSize, windowPosition))
        {
        }

        /// <summary>
        /// The constructor with a stylesheet and window mode.
        /// </summary>
        /// <param name="styleSheet">The styleSheet url.</param>
        /// <param name="windowMode">The windowMode.</param>
        /// <since_tizen> 3 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "NUICoreBackend is disposed in the base class when the application is terminated")]
        public NUIApplication(string styleSheet, WindowMode windowMode) : base(new NUICoreBackend(styleSheet, windowMode))
        {
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
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "NUICoreBackend is disposed in the base class when the application is terminated")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIApplication(string styleSheet, WindowMode windowMode, Size2D windowSize, Position2D windowPosition) : base(new NUICoreBackend(styleSheet, windowMode, windowSize, windowPosition))
        {
        }

        /// <summary>
        /// Internal inhouse constructor with Graphics Backend Type
        /// </summary>
        /// <param name="backend"></param>
        /// <param name="windowMode"></param>
        /// <param name="windowSize"></param>
        /// <param name="windowPosition"></param>
        /// <param name="styleSheet"></param>
        /// InhouseAPI, this could be opened in NextTizen
        [Obsolete("Please do not use! This will be deprecated!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIApplication(Graphics.BackendType backend, WindowMode windowMode = WindowMode.Opaque, Size2D windowSize = null, Position2D windowPosition = null, string styleSheet = "") : base(new NUICoreBackend(styleSheet, windowMode, windowSize, windowPosition))
        {
            //windowMode and styleSheet will be added later. currently it's not working as expected.
            Graphics.Backend = backend;
            Tizen.Log.Error("NUI", "Plaese DO NOT set graphical backend type with this constructor! This will give no effect!");
        }

        /// <summary>
        /// The constructor with theme option.
        /// </summary>
        /// <param name="option">The theme option.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "NUICoreBackend is disposed in the base class when the application is terminated")]
        public NUIApplication(ThemeOptions option) : base(new NUICoreBackend())
        {
            ApplyThemeOption(option);
        }

        /// <summary>
        /// The constructor with window size and position and theme option.
        /// </summary>
        /// <param name="windowSize">The window size.</param>
        /// <param name="windowPosition">The window position.</param>
        /// <param name="option">The theme option.</param>
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "NUICoreBackend is disposed in the base class when the application is terminated")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIApplication(Size2D windowSize, Position2D windowPosition, ThemeOptions option) : base(new NUICoreBackend("", NUIApplication.WindowMode.Opaque, windowSize, windowPosition))
        {
            ApplyThemeOption(option);
        }

        /// <summary>
        /// The constructor with a stylesheet, window mode and default window type.
        /// It is the only way to create an IME window.
        /// </summary>
        /// <param name="styleSheet">The styleSheet URL.</param>
        /// <param name="windowMode">The windowMode.</param>
        /// <param name="type">The default window type.</param>
        /// <since_tizen> 9 </since_tizen>
        public NUIApplication(string styleSheet, WindowMode windowMode, WindowType type) : base(new NUICoreBackend(styleSheet, windowMode, type))
        {
            ExternalThemeManager.Initialize();
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
        /// Xaml loaded event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event XamlLoadedHandler XamlLoaded;

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
        /// Enumeration for theme options of the NUIApplication.
        /// </summary>
        [Flags]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ThemeOptions : int
        {
            /// <summary>
            /// No option specified.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            None = 0,

            /// <summary>
            /// Enable platform theme.
            /// When this option is on, all views in the NUIApplication is affected by platform theme (e.g. light/dark).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            PlatformThemeEnabled = 1 << 0,

            /// <summary>
            /// Sets the default value of View.ThemeChangeSensitive.
            /// when this option is on, all views are made sensitive on theme changing by default.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ThemeChangeSensitive = 1 << 1,
        };

        /// <summary>
        /// Current loaded xaml's full name.
        /// </summary>
        public static string CurrentLoadedXaml
        {
            get
            {
                return currentLoadedXaml;
            }
            set
            {
                if (currentLoadedXaml != value)
                {
                    currentLoadedXaml = value;
                    XamlLoaded?.Invoke(value);
                }
            }
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
                return GetDefaultWindow();
            }
        }

        /// <summary>
        /// Gets the Application Id.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AppId
        {
            get
            {
                return Tizen.Applications.Application.Current.ApplicationInfo.ApplicationId;
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
            XamlParser.s_assemblies.Add(assembly);
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
        /// Sets the number of frames per render.
        /// </summary>
        /// <param name="numberOfVSyncsPerRender">The number of vsyncs between successive renders.</param>
        /// <remarks>
        /// Suggest this is a power of two:
        /// 1 - render each vsync frame.
        /// 2 - render every other vsync frame.
        /// 4 - render every fourth vsync frame.
        /// 8 - render every eighth vsync frame. <br />
        /// For example, if an application runs on 60 FPS and SetRenderRefreshRate(2) is called, the frames per second will be changed to 30.
        ///</remarks>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetRenderRefreshRate(uint numberOfVSyncsPerRender)
        {
            Adaptor.Instance.SetRenderRefreshRate(numberOfVSyncsPerRender);
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
            base.OnCreate();
        }

        /// <summary>
        /// This is used to improve application launch performance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void Preload()
        {
            Interop.Application.PreInitialize();
            ThemeManager.Preload();
            IsPreload = true;
        }

        /// <summary>
        /// This is used to improve application launch performance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendLaunchRequest(AppControl appControl)
        {
            TransitionOptions?.SendLaunchRequest(appControl);
        }

        /// <summary>
        /// This is used to improve application launch performance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionOptions TransitionOptions { get; set; }

        /// <summary>
        /// Check if it is loaded as dotnet-loader-nui.
        /// </summary>
        static internal bool IsPreload { get; set; }

        private void ApplyThemeOption(ThemeOptions option)
        {
            if ((option & ThemeOptions.PlatformThemeEnabled) != 0)
            {
                ThemeManager.PlatformThemeEnabled = true;
            }

            if ((option & ThemeOptions.ThemeChangeSensitive) != 0)
            {
                ThemeManager.ApplicationThemeChangeSensitive = true;
            }
        }
    }

    /// <summary>
    /// Graphics Backend Type.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1052:StaticHolderTypesShouldBeStaticOrNotInheritable")]
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
        internal static BackendType Backend = BackendType.Gles;

        internal const string GlesCSharpBinder = NDalicPINVOKE.Lib;
        internal const string VulkanCSharpBinder = "libdali-csharp-binder-vk.so";
    }
}
