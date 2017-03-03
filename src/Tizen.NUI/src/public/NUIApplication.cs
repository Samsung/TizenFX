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

//------------------------------------------------------------------------------
// This file can only run on Tizen target. You should compile it with hello-test.cs, and
// add tizen c# application related library as reference.
//------------------------------------------------------------------------------
namespace Tizen.Applications
{
    /// <summary>
    /// Represents an application that have UI screen. The NUIApplication class has a default stage.
    /// </summary>
    public class NUIApplication : CoreUIApplication
    {
        /// <summary>
        /// The instance of the Dali Application.
        /// </summary>
        /// <remarks>
        /// This application is created before OnCreate() or created event. And the NUIApplication will be terminated when this application is closed.
        /// </remarks>
        protected Tizen.NUI.Application application;

        /// <summary>
        /// The instance of the Dali Application extension.
        /// </summary>
        internal Tizen.NUI.ApplicationExtensions applicationExt;

        /// <summary>
        /// Store the stylesheet value.
        /// </summary>
        protected string m_stylesheet;

        /// <summary>
        /// Store the window mode value.
        /// </summary>
        protected Tizen.NUI.Application.WINDOW_MODE m_windowMode;

        /// <summary>
        /// Store the app mode value.
        /// </summary>
        protected AppMode appMode;

        /// <summary>
        /// The instance of the Dali Stage.
        /// </summary>
        public Stage stage { get; private set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public NUIApplication():base()
        {
            appMode = AppMode.Default;
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public NUIApplication(string stylesheet):base()
        {
            //handle the stylesheet
            appMode = AppMode.StyleSheetOnly;
            m_stylesheet = stylesheet;
        }

        /// <summary>
        /// The constructor with stylesheet and window mode.
        /// </summary>
        public NUIApplication(string stylesheet, Tizen.NUI.Application.WINDOW_MODE windowMode)
            : base()
        {
            //handle the stylesheet and windowMode
            appMode = AppMode.StyleSheetWithWindowMode;
            m_stylesheet = stylesheet;
            m_windowMode = windowMode;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior before calling OnCreate().
        /// stage property is initialized in this overrided method.
        /// </summary>
        protected override void OnPreCreate()
        {
            switch(appMode)
            {
                case AppMode.Default:
                    application = Tizen.NUI.Application.NewApplication();
                    break;
                case AppMode.StyleSheetOnly:
                    application = Tizen.NUI.Application.NewApplication(m_stylesheet);
                    break;
                case AppMode.StyleSheetWithWindowMode:
                    application = Tizen.NUI.Application.NewApplication(m_stylesheet, m_windowMode);
                    break;
                default:
                    break;
            }

            applicationExt = new Tizen.NUI.ApplicationExtensions(application);
            applicationExt.Init();

            stage = Stage.GetCurrent();
            stage.SetBackgroundColor( Color.White );
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnTerminate()
        {
            base.OnTerminate();
            applicationExt.Terminate();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            applicationExt.Pause();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            applicationExt.Resume();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            base.OnLocaleChanged(e);
            applicationExt.LanguageChange();
        }

        /// <summary>
        /// The mode of creating Dali application.
        /// </summary>
        protected enum AppMode
        {
            Default = 0,
            StyleSheetOnly = 1,
            StyleSheetWithWindowMode = 2
        }
    }
}
