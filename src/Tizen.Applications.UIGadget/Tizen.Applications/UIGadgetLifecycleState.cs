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

using System.ComponentModel;

namespace Tizen.Applications
{
    /// <summary>
    /// Enumeration for the lifecycle state of the UIGadget.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum UIGadgetLifecycleState
    {
        /// <summary>
        /// The initialized state.
        /// This state is set when the UIGadget is initialized. The constructor of the UIGadget is called.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        Initialized = 0,

        /// <summary>
        /// The created state.
        /// This state is set when the UIGadget is created. The 'OnCreate()' method of the UIGadget is called.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        Created = 1,

        /// <summary>
        /// The resumed state.
        /// This state is set when the UIGadget is resumed. The 'OnResume()' method of the UIGadget is called.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        Resumed = 2,

        /// <summary>
        /// The paused state.
        /// This state is set when the UIGadget is paused. The 'OnPause()' method of the UIGadget is called.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        Paused = 3,

        /// <summary>
        /// The destroyed state.
        /// This state is set when the UIGadget is destroyed. The 'OnDestroy()' method of the UIGadget is called.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        Destroyed = 4,

        /// <summary>
        /// The pre-created state.
        /// This state is set when the UIGadget is pre-created. The 'OnPreCreate()' method of the UIGadget is called.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PreCreated = 5,
    }
}
