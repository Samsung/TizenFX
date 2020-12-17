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
    /// The class for showing service module
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class ServiceComponent : BaseComponent
    {
        /// <summary>
        /// Overrides this method to handle behavior when the component is created.
        /// </summary>
        /// <returns>True if a service component is successfully created</returns>
        public abstract bool OnCreate();

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the start command message.
        /// </summary>
        /// <param name="appControl">appcontrol object</param>
        /// <param name="restarted">True if it was restarted</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnStartCommand(AppControl appControl, bool restarted)
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
