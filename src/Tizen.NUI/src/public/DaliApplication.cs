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
using NUI;

//------------------------------------------------------------------------------
// This file can only run on Tizen target. You should compile it with hello-test.cs, and
// add tizen c# application related library as reference.
//------------------------------------------------------------------------------
namespace Tizen.Applications
{
    /// <summary>
    /// Represents an application that have UI screen. The DaliApplication class has a default stage.
    /// </summary>
    public class DaliApplication : CoreUIApplication
    {
        /// <summary>
        /// The instance of the Dali Application.
        /// </summary>
        /// <remarks>
        /// This application is created before OnCreate() or created event. And the DaliApplication will be terminated when this application is closed.
        /// </remarks>
        protected NUI.Application application;

        /// <summary>
        /// The instance of the Dali Application extension.
        /// </summary>
        protected NUI.ApplicationExtensions applicationExt;

        /// <summary>
        /// Store the stylesheet value.
        /// </summary>
        protected string m_stylesheet;

        /// <summary>
        /// Store the window mode value.
        /// </summary>
        protected NUI.Application.WINDOW_MODE m_windowMode;

        /// <summary>
        /// Store the app mode value.
        /// </summary>
        protected APP_MODE appMode;

        /// <summary>
        /// The instance of the Dali Stage.
        /// </summary>
        public Stage stage { get; private set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public DaliApplication():base()
        {
            appMode = APP_MODE.DEFAULT;
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public DaliApplication(string stylesheet):base()
        {
            //handle the stylesheet
            appMode = APP_MODE.STYLESHEETONLY;
            m_stylesheet = stylesheet;
        }

        /// <summary>
        /// The constructor with stylesheet and window mode.
        /// </summary>
        public DaliApplication(string stylesheet, NUI.Application.WINDOW_MODE windowMode)
            : base()
        {
            //handle the stylesheet and windowMode
            appMode = APP_MODE.STYLESHEETWITHWINDOWMODE;
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
                case APP_MODE.DEFAULT:
                    application = NUI.Application.NewApplication();
                    break;
                case APP_MODE.STYLESHEETONLY:
                    application = NUI.Application.NewApplication(m_stylesheet);
                    break;
                case APP_MODE.STYLESHEETWITHWINDOWMODE:
                    application = NUI.Application.NewApplication(m_stylesheet, m_windowMode);
                    break;
                default:
                    break;
            }

            applicationExt = new NUI.ApplicationExtensions(application);
            applicationExt.Init();

            stage = Stage.GetCurrent();
            stage.SetBackgroundColor( NDalic.WHITE );
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
        protected enum APP_MODE
        {
            DEFAULT = 0,
            STYLESHEETONLY = 1,
            STYLESHEETWITHWINDOWMODE = 2
        }
    }
}
