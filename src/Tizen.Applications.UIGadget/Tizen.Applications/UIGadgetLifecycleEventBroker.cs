/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;

namespace Tizen.Applications
{
    /// <summary>
    /// Event Broker for the UIGadget lifecycle change event.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class UIGadgetLifecycleEventBroker
    {
        /// <summary>
        /// Occurs when the lifecycle of the UIGadget is changed.
        /// </summary>
        /// <remarks>
        /// This event is raised when the state of the UIGadget changes.
        /// It provides information about the current state through the UIGadgetLifecycleChangedEventArgs argument.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public static event EventHandler<UIGadgetLifecycleChangedEventArgs> LifecycleChanged;

        /// <summary>
        /// Notifies that the lifecycle of the UIGadget is changed.
        /// </summary>
        /// <param name="gadget">The UIGadget instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when the 'gadget' is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void NotifyLifecycleChanged(IUIGadget gadget)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            var args = new UIGadgetLifecycleChangedEventArgs
            {
                State = gadget.State,
                UIGadget = gadget,
            };
            CoreApplication.Post(() => LifecycleChanged?.Invoke(null, args));
        }
    }
}
