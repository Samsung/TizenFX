﻿/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.RPCPort
{
    /// <summary>
    /// The class that proxy and stub can use to communicate with each other.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class Port
    {
        /// <summary>
        /// Enumeration for RPC port types.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Main channel to communicate.
            /// </summary>
            Main,

            /// <summary>
            /// Sub channel for callbacks.
            /// </summary>
            Callback
        }

        internal IntPtr Handle { get; set; }
        internal Port() { }
    }
}
