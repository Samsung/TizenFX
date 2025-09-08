/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Represents a base class for UI components in the component-based application model.
    /// This class provides methods for handling the lifecycle and state of UI components.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class FrameComponent : BaseComponent
    {
        /// <summary>
        /// Gets the current display status of the component.
        /// </summary>
        /// <value>
        /// The current <see cref="DisplayStatus"/> of the component.
        /// </value>
        /// <exception cref="InvalidOperationException">Thrown when the display status cannot be retrieved.</exception>
        /// <since_tizen> 6 </since_tizen>
        public DisplayStatus DisplayStatus
        {
            get
            {
                Interop.CBApplication.NativeDisplayStatus status;
                Interop.CBApplication.ErrorCode err = Interop.CBApplication.BaseFrameGetDisplayStatus(Handle, out status);
                if (err != Interop.CBApplication.ErrorCode.None)
                    throw new InvalidOperationException("Fail to get display status : err(" + err + ")");

                return (DisplayStatus)status;
            }
        }

        /// <summary>
        /// Called when the component is launched. Override this method to implement custom launch behavior.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the service component is successfully created; otherwise, <c>false</c>.
        /// </returns>
        /// <since_tizen> 6 </since_tizen>
        public abstract bool OnCreate();

        /// <summary>
        /// Called to create the window for the component. Override this method to provide a custom window.
        /// This method will be called before <see cref="OnCreate"/> method.
        /// </summary>
        /// <returns>
        /// An <see cref="IWindowInfo"/> object that represents the created window.
        /// </returns>
        /// <since_tizen> 6 </since_tizen>
        public abstract IWindowInfo CreateWindowInfo();

        /// <summary>
        /// Called when the component receives an app control message. Override this method to handle app control messages.
        /// </summary>
        /// <param name="appControl">The <see cref="AppControl"/> object containing the app control data.</param>
        /// <param name="restarted"><c>true</c> if the component was restarted; otherwise, <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnStart(AppControl appControl, bool restarted)
        {
        }

        /// <summary>
        /// Called when the component is resumed. Override this method to handle resume behavior.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnResume()
        {
        }

        /// <summary>
        /// Called when the component is paused. Override this method to handle pause behavior.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnPause()
        {
        }

        /// <summary>
        /// Called when the component is stopped. Override this method to handle stop behavior.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnStop()
        {
        }

        /// <summary>
        /// Called when the component is destroyed. Override this method to handle destruction behavior.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnDestroy()
        {
        }
    }
}
