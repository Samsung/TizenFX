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
    /// Represents a base class for widget components in the component-based application model.
    /// This class provides methods for handling the lifecycle and state of widget components.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class WidgetComponent : BaseComponent
    {
        /// <summary>
        /// Called when the widget component is created. Override this method to implement custom creation behavior.
        /// </summary>
        /// <param name="width">The width of the widget component instance.</param>
        /// <param name="height">The height of the widget component instance.</param>
        /// <returns>
        /// <c>true</c> if the widget component is successfully created; otherwise, <c>false</c>.
        /// </returns>
        /// <since_tizen> 9 </since_tizen>
        public abstract bool OnCreate(int width, int height);

        /// <summary>
        /// Called to create the window for the widget. This method will be called before the <see cref="OnCreate"/> method.
        /// </summary>
        /// <param name="width">The width of the widget window.</param>
        /// <param name="height">The height of the widget window.</param>
        /// <returns>
        /// An <see cref="IWindowProxy"/> object representing the window to use.
        /// </returns>
        /// <since_tizen> 9 </since_tizen>
        public abstract IWindowProxy CreateWindowInfo(int width, int height);

        /// <summary>
        /// Called when the widget component is started. Override this method to handle start behavior.
        /// </summary>
        /// <param name="restarted">
        /// <c>true</c> if the component was restarted; otherwise, <c>false</c>.
        /// </param>
        /// <since_tizen> 9 </since_tizen>
        public virtual void OnStart(bool restarted)
        {
        }

        /// <summary>
        /// Called when the widget component is resumed. Override this method to handle resume behavior.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public virtual void OnResume()
        {
        }

        /// <summary>
        /// Called when the widget component is paused. Override this method to handle pause behavior.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public virtual void OnPause()
        {
        }

        /// <summary>
        /// Called when the widget component is stopped. Override this method to handle stop behavior.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public virtual void OnStop()
        {
        }

        /// <summary>
        /// Called when the widget component is destroyed. Override this method to handle destruction behavior.
        /// </summary>
        /// <param name="permanent">
        /// <c>true</c> if the instance is permanent; otherwise, <c>false</c>.
        /// </param>
        /// <since_tizen> 9 </since_tizen>
        public virtual void OnDestroy(bool permanent)
        {
        }
    }
}
