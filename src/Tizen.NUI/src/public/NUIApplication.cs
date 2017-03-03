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
using Tizen.NUI;

namespace Tizen.NUI
{

    public class NUIApplication : CoreUIApplication
    {
        private void LOG(string _str)
        {
            Tizen.Log.Debug("NUI", _str);
            //Console.WriteLine("[NUI]" + _str);
        }

        private Application _application;
        private ApplicationExtensions _applicationExt;
        private string _stylesheet;
        private Application.WindowMode _windowMode;
        private AppMode _appMode;
        private Stage _stage;

        public NUIApplication() : base()
        {
            _appMode = AppMode.Default;
        }

        public NUIApplication(string stylesheet) : base()
        {
            //handle the stylesheet
            _appMode = AppMode.StyleSheetOnly;
            _stylesheet = stylesheet;
        }

        public NUIApplication(string stylesheet, Application.WindowMode windowMode) : base()
        {
            //handle the stylesheet and windowMode
            _appMode = AppMode.StyleSheetWithWindowMode;
            _stylesheet = stylesheet;
            _windowMode = windowMode;
        }


        protected override void OnPause()
        {
            base.OnPause();
            _applicationExt.Pause();
            LOG("OnPause() is called!");
        }

        protected override void OnPreCreate()
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
            _applicationExt = new ApplicationExtensions(_application);
            _applicationExt.Init();

            _stage = Stage.Instance;
            _stage.SetBackgroundColor(Color.White);
            LOG("OnPreCreate() is called!");
        }

        protected override void OnResume()
        {
            base.OnResume();
            _applicationExt.Resume();
            LOG("OnResume() is called!");
        }

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

        protected override void OnCreate()
        {
            base.OnCreate();
            LOG("OnCreate() is called!");
        }

        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            base.OnLocaleChanged(e);
            _applicationExt.LanguageChange();
            LOG("OnLocaleChanged() is called!");
        }

        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            base.OnLowBattery(e);
            LOG("OnLowBattery() is called!");
        }

        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            base.OnLowMemory(e);
            LOG("OnLowMemory() is called!");
        }

        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            base.OnRegionFormatChanged(e);
            LOG("OnRegionFormatChanged() is called!");
        }

        protected override void OnTerminate()
        {
            base.OnTerminate();
            _applicationExt.Terminate();
            LOG("OnTerminate() is called!");
        }

        private enum AppMode
        {
            Default = 0,
            StyleSheetOnly = 1,
            StyleSheetWithWindowMode = 2
        }
    }
}
