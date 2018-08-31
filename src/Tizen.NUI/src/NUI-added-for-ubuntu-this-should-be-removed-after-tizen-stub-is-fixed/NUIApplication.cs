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
using Tizen.NUI;

namespace Tizen.NUI
{

    /// <summary>
    /// Represents an application that have UI screen. The NUIApplication class has a default stage.
    /// </summary>
    public class NUIApplication : CoreUIApplication
    {
        private void LOG(string _str)
        {
            //Tizen.Log.Debug("NUI", _str);
            //Console.WriteLine("[NUI]" + _str);
        }

        /// <summary>
        /// The instance of the Application.
        /// </summary>
        /// <remarks>
        /// This application is created before OnCreate() or created event. And the NUIApplication will be terminated when this application is closed.
        /// </remarks>
        private Application _application;

        /// <summary>
        /// The instance of the Dali Application extension.
        /// </summary>
        private ApplicationExtensions _applicationExt;

        /// <summary>
        /// Store the stylesheet value.
        /// </summary>
        private string _stylesheet;

        /// <summary>
        /// Store the window mode value.
        /// </summary>
        private Application.WindowMode _windowMode;

        /// <summary>
        /// Store the app mode value.
        /// </summary>
        private AppMode _appMode;

        private Window _stage;

        /// <summary>
        /// The default constructor.
        /// </summary>
        public NUIApplication() : base()
        {
            _appMode = AppMode.Default;
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public NUIApplication(string stylesheet) : base()
        {
            //handle the stylesheet
            _appMode = AppMode.StyleSheetOnly;
            _stylesheet = stylesheet;
        }

        /// <summary>
        /// The constructor with stylesheet and window mode.
        /// </summary>
        public NUIApplication(string stylesheet, WindowMode windowMode) : base()
        {
            //handle the stylesheet and windowMode
            _appMode = AppMode.StyleSheetWithWindowMode;
            _stylesheet = stylesheet;
            _windowMode = (Application.WindowMode)windowMode;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            _applicationExt.Pause();
            LOG("OnPause() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior before calling OnCreate().
        /// stage property is initialized in this overrided method.
        /// </summary>
        protected override void OnPreCreate()
        {
            _applicationExt = new ApplicationExtensions(_application);
 //           _applicationExt.Init();

            _stage = Window.Instance;
            _stage.SetBackgroundColor(Color.White);
            LOG("OnPreCreate() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            _applicationExt.Resume();
            LOG("OnResume() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            base.OnAppControlReceived(e);
            LOG("OnAppControlReceived() is called!");
            if (e != null)
            {
                LOG("OnAppControlReceived() is called! ApplicationId=" + e.ReceivedAppControl.ApplicationId);
                LOG("CallerApplicationId=" + e.ReceivedAppControl.CallerApplicationId + "   IsReplyRequest=" + e.ReceivedAppControl.IsReplyRequest);
            }
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnCreate()
        {
            base.OnCreate();
            LOG("OnCreate() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            base.OnLocaleChanged(e);
            _applicationExt.LanguageChange();
            LOG("OnLocaleChanged() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            base.OnLowBattery(e);
            LOG("OnLowBattery() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            base.OnLowMemory(e);
            LOG("OnLowMemory() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            base.OnRegionFormatChanged(e);
            LOG("OnRegionFormatChanged() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnTerminate()
        {
            base.OnTerminate();
            _applicationExt.Terminate();
            LOG("OnTerminate() is called!");
        }

        /// <summary>
        /// The mode of creating NUI application.
        /// </summary>
        private enum AppMode
        {
            Default = 0,
            StyleSheetOnly = 1,
            StyleSheetWithWindowMode = 2
        }

        /// <summary>
        /// Enumeration for deciding whether a NUI application window is opaque or transparent.
        /// </summary>
        public enum WindowMode
        {
            Opaque = 0,
            Transparent = 1
        }

        internal void CreateApp()
        {
            switch (_appMode)
            {
                case AppMode.Default:
                    _application = Tizen.NUI.Application.NewApplication();
                    break;
                case AppMode.StyleSheetOnly:
                    _application = Tizen.NUI.Application.NewApplication(_stylesheet);
                    break;
                case AppMode.StyleSheetWithWindowMode:
                    _application = Tizen.NUI.Application.NewApplication(_stylesheet, _windowMode);
                    break;
                default:
                    break;
            }

        }

        public void Run(string[] args)
        {
            CreateApp();
            _application.Initialized += Initialize;
            _application.MainLoop();
        }


        internal void Initialize(object source, NUIApplicationInitEventArgs e)
        {          
            OnPreCreate();
            OnCreate();
        }

        public void Exit()
        {
            //dummy
        }

        private static System.Resources.ResourceManager resourceManager = null;

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

    /// <summary>
    /// Graphics BackendType
    /// </summary>
    /// InhouseAPI, this could be opend in NextTizen
    public class Graphics
    {
        public enum BackendType
        {
            Gles,
            Vulkan
        }
        public static BackendType Backend = BackendType.Gles;
        internal const string GlesCSharpBinder = "libdali-csharp-binder.so";
        internal const string VulkanCSharpBinder = "libdali-csharp-binder-vk.so";
    }
}
