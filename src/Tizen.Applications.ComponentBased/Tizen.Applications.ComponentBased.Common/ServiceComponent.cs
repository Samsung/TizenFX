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
    /// Represents a base class for service components in the component-based application model.
    /// This class provides methods for handling the lifecycle and state of service components.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class ServiceComponent : BaseComponent
    {
        /// <summary>
        /// Called when the service component is created. Override this method to implement custom creation behavior.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the service component is successfully created; otherwise, <c>false</c>.
        /// </returns>
        /// <since_tizen> 6 </since_tizen>
        public abstract bool OnCreate();

        /// <summary>
        /// Called when the service component receives a start command message. Override this method to handle start command behavior.
        /// </summary>
        /// <param name="appControl">The <see cref="AppControl"/> object containing the app control data.</param>
        /// <param name="restarted"><c>true</c> if the component was restarted; otherwise, <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnStartCommand(AppControl appControl, bool restarted)
        {
        }

        /// <summary>
        /// Called when the service component is destroyed. Override this method to handle destruction behavior.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnDestroy()
        {
        }
    }
}

