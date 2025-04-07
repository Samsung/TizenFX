/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.ComponentModel;
using Tizen.Applications;
using Tizen.Applications.ComponentBased.Common;

namespace Tizen.NUI
{
    /// <summary>
    /// The class for showing UI module
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NUIWidgetComponent : WidgetComponent
    {
        private bool defaultWindowSet;
        internal NUIWindowProxy NUIWindowProxy
        {
            get;
            set;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window Window
        {
            get;
            set;
        }

        /// <summary>
        /// Overrides this method to create window. It will be called before OnCreate method.
        /// </summary>
        /// <returns>Window object to use</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override IWindowProxy CreateWindowInfo(int width, int height)
        {
            ComponentApplication instance = ComponentApplication.Instance as ComponentApplication;
            if (instance != null)
            {
                if (!defaultWindowSet)
                {
                    instance.GetWindow().WindowPositionSize = new Rectangle(0, 0, 1, 1);
                    instance.GetWindow().BackgroundColor = new Color(0, 0, 0, 0);
                    instance.GetWindow().Hide();
                    defaultWindowSet = true;
                }
                using var rect = new Rectangle(0, 0, width, height);
                Window = new Window(rect, false);
                Window.Show();
            }
            NUIWindowProxy = new NUIWindowProxy(Window);
            return NUIWindowProxy;
        }

        /// <summary>
        /// Overrides this method to handle behavior when the component is launched.
        /// </summary>
        /// <returns>True if a service component is successfully created</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnCreate(int width, int height)
        {
            return true;
        }

        /// <summary>
        /// Overrides this method if you want to handle behavior when the component receives the appcontrol message.
        /// </summary>
        /// <param name="restarted">True if it was restarted</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnStart(bool restarted)
        {
            base.OnStart(restarted);
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is resumed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnResume()
        {
            base.OnResume();
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is paused.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnPause()
        {
            base.OnPause();
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is stopped.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnStop()
        {
            base.OnStop();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is destroyed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnDestroy(bool permanent)
        {
            base.OnDestroy(permanent);
        }
    }
}

