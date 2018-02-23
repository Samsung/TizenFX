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

/*
namespace Tizen
{
    public class Log
    {
        public static void Error(params object[] s) {}
        public static void Debug(params object[] s) {}
        public static void Fatal(params object[] s) {}
    }
}
*/

namespace Tizen.NUI
{

    public class ReceivedAppControlArgs
    {
        public int ApplicationId;
        public int CallerApplicationId;
        public int IsReplyRequest;
    }

    public class AppControlReceivedEventArgs
    {
        public ReceivedAppControlArgs ReceivedAppControl;
    }

    public class LocaleChangedEventArgs
    { }

    public class LowMemoryEventArgs
    { }

    public class LowBatteryEventArgs
    { }

    public class RegionFormatChangedEventArgs
    { }


    /// <summary>
    /// Represents an application that have UI screen. The NUIApplication class has a default stage.
    /// </summary>
    public class CoreUIApplication
    {
         /// <summary>
        /// The default constructor.
        /// </summary>
        public CoreUIApplication()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnPause()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior before calling OnCreate().
        /// stage property is initialized in this overrided method.
        /// </summary>
        protected virtual void OnPreCreate()
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
        protected virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnCreate()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnLowBattery(LowBatteryEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnLowMemory(LowMemoryEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnTerminate()
        {
        }
    }
}