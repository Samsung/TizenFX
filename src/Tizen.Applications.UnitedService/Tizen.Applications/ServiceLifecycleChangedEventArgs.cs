﻿/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Event arguments for the service lifecycle change event.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ServiceLifecycleChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the service object that triggered the event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public Service Service { get; internal set; }

        /// <summary>
        /// Gets the current state of the service lifecycle.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public ServiceLifecycleState State { get; internal set; }
    }
}