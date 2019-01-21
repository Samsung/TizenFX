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

using Tizen;
using System;
using ElmSharp;
using static Interop.InputMethod;

namespace Tizen.Uix.InputMethod
{
    /// <summary>
    /// The editor window class.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class EditorWindow : Window
    {
        internal static IntPtr _handle = IntPtr.Zero;
        private IntPtr _realHandle = IntPtr.Zero;

        internal EditorWindow():base("Edit")
        {
            _realHandle = _handle;
        }

        /// <summary>
        /// This API creates a handle for the editor window.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> 4 </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return _handle;
        }

        /// <summary>
        /// This API gets a handle for the editor window.
        /// </summary>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> 4 </since_tizen>
        public IntPtr GetHandle()
        {
            return _handle;
        }

        /// <summary>
        /// This API updates the input panel window's size information.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="portraitWidth">The width in the portrait mode.</param>
        /// <param name="portraitHeight">The height in the portrait mode.</param>
        /// <param name="landscapeWidth">The width in the landscape mode.</param>
        /// <param name="landscapeHeight">The height in the landscape mode.</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public static void SetSize(int portraitWidth, int portraitHeight, int landscapeWidth, int landscapeHeight)
        {
            ErrorCode error = ImeSetSize(portraitWidth, portraitHeight, landscapeWidth, landscapeHeight);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetSize Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }
    }
}
