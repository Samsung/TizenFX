﻿/*
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

namespace Tizen.NUI
{
    /// <summary>
    /// Event arguments for the OneShotService lifecycle change event.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class OneShotServiceLifecycleChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the OneShotService object that triggered the event.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public OneShotService OneShotService { get; set; }

        /// <summary>
        /// Gets the current state of the OneShotService lifecycle.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public OneShotServiceLifecycleState State { get; internal set; }
    }
}
