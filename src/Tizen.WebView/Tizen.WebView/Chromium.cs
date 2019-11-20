/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.WebView
{
    /// <summary>
    /// This class provides the methods to initialize and shutdown the Chromium-efl.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class Chromium
    {
        /// <summary>
        /// Initializes the Chromium's instance.
        /// </summary>
        /// <returns>A reference count of the Chromium's instance.</returns>
        /// <since_tizen> 4 </since_tizen>
        public static int Initialize()
        {
            return Interop.ChromiumEwk.ewk_init();
        }

        /// <summary>
        /// Decreases a reference count of the WebKit's instance, possibly destroying it.
        /// </summary>
        /// <returns>A reference count of the Chromium's instance.</returns>
        /// <since_tizen> 4 </since_tizen>
        public static int Shutdown()
        {
            return Interop.ChromiumEwk.ewk_shutdown();
        }

        /// <summary>
        /// Sets argument count and argument array for Chromium.
        /// </summary>
        /// <param name="args">Argument array. The first value of array must be program's name.</param>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetArguments(string[] args)
        {
            Interop.ChromiumEwk.ewk_set_arguments(args.Length, args);
        }
    }
}
