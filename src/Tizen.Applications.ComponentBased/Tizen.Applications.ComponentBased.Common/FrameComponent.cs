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
    /// The class for showing UI module
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class FrameComponent : BaseComponent
    {
        /// <summary>
        /// Gets the display status of a component.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when component type is already added to the component.</exception>
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
        /// Overrides this method to handle behavior when the component is launched.
        /// </summary>
        /// <returns>True if a service component is successfully created</returns>
        /// <since_tizen> 6 </since_tizen>
        public abstract bool OnCreate();

        /// <summary>
        /// Overrides this method to create window. It will be called before OnCreate method.
        /// </summary>
        /// <returns>Window object to use</returns>
        /// <since_tizen> 6 </since_tizen>
        public abstract IWindowInfo CreateWindowInfo();

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the appcontrol message.
        /// </summary>
        /// <param name="appControl">appcontrol object</param>
        /// <param name="restarted">True if it was restarted</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnStart(AppControl appControl, bool restarted)
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is resumed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnResume()
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is paused.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnPause()
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is stopped.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnStop()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is destroyed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnDestroy()
        {
        }
    }
}
