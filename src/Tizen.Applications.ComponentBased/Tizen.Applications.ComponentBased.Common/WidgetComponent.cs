/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

using System;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The class for showing UI module
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class WidgetComponent : BaseComponent
    {

        /// <summary>
        /// Override this method to handle behavior when the component is launched.
        /// </summary>
        /// <param name="width">The width of the widget component instance</param>
        /// <param name="height">The height of the widget component instance</param>
        /// <returns>True if a service component is successfully created</returns>
        /// <since_tizen> 9 </since_tizen>
        public abstract bool OnCreate(int width, int height);

        /// <summary>
        /// Override this method to create window. It will be called before OnCreate method.
        /// </summary>
        /// <param name="width">The width of the widget window</param>
        /// <param name="height">The height of the widget window</param>
        /// <returns>Window object to use</returns>
        /// <since_tizen> 9 </since_tizen>
        public abstract IWindowProxy CreateWindowInfo(int width, int height);

        /// <summary>
        /// Overrid this method if want to handle behavior when the component is started.
        /// </summary>
        /// <param name="restarted">True if it was restarted</param>
        /// <since_tizen> 9 </since_tizen>
        public virtual void OnStart(bool restarted)
        {
        }

        /// <summary>
        /// Override this method if you want to handle the behavior when the component is resumed.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public virtual void OnResume()
        {
        }

        /// <summary>
        /// Override this method if you want to handle the behavior when the component is paused.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public virtual void OnPause()
        {
        }

        /// <summary>
        /// Override this method if you want to handle the behavior when the component is stopped.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public virtual void OnStop()
        {
        }

        /// <summary>
        /// Override this method if want to handle behavior when the component is destroyed.
        /// </summary>
        /// <param name="permanent">True if the instance is permanent</param>
        /// <since_tizen> 9 </since_tizen>
        public virtual void OnDestroy(bool permanent)
        {
        }
    }
}
