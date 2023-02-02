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

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Enumeration for the lifecycle state of the NUIGadget.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public  enum NUIGadgetLifecycleState
    {
        /// <summary>
        /// The initialized state.
        /// This state is set when the gadget is initialized. The constructor of the NUIGadget is called.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Initialized = 0,

        /// <summary>
        /// The created state.
        /// This state is set when the gadget is created. The 'OnCreate()' method of the NUIGadget is called.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Created = 1,

        /// <summary>
        /// The resumed state.
        /// This state is set when the gadget is resumed. The 'OnResume()' method of the NUIGadget is called.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Resumed = 2,

        /// <summary>
        /// The paused state.
        /// This state is set when the gadget is paused. The 'OnPause()' method of the NUIGadget is called.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Paused = 3,

        /// <summary>
        /// The destroyed state.
        /// This state is set when the gadget is destroyed. The 'OnDestroy()' method of the NUIGadget is called.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Destroyed = 4,
    }
}
