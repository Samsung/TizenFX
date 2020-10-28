/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    /// <summary>
    /// Arguments for the event that raised when the application receives the AppControl.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AppControlReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes the AppControlReceivedEventArgs class.
        /// </summary>
        /// <param name="appControl"></param>
        /// <since_tizen> 3 </since_tizen>
        public AppControlReceivedEventArgs(ReceivedAppControl appControl)
        {
            ReceivedAppControl = appControl;
        }

        /// <summary>
        /// The received AppControl.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ReceivedAppControl ReceivedAppControl { get; private set; }
    }
}
