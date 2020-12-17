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
using System.Runtime.InteropServices;
using System.Text;

namespace Tizen.WebView
{
    /// <summary>
    /// The callback function that is invoked when the message is received from the script.
    /// </summary>
    /// <param name="message">The JavaScriptMessage returned by the script.</param>
    /// <since_tizen> 4 </since_tizen>
    public delegate void JavaScriptMessageHandler(JavaScriptMessage message);

    /// <summary>
    /// A script message contains information that is sent from the JavaScript runtime.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class JavaScriptMessage
    {
        private string _name;
        private IntPtr _body;

        internal JavaScriptMessage(Interop.ChromiumEwk.ScriptMessage message)
        {
            _name = Marshal.PtrToStringAnsi(message.name);
            _body = message.body;
        }

        /// <summary>
        /// The object name in JavaScript.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Gets the value of the body as an integer type.
        /// </summary>
        /// <returns>The value of the body as an integer type.</returns>
        /// <since_tizen> 4 </since_tizen>
        public int GetBodyAsInteger()
        {
            if (_body == IntPtr.Zero)
            {
                return 0;
            }
            return Marshal.ReadInt32(_body, 0);
        }

        /// <summary>
        /// Gets the value of the body as a double type.
        /// </summary>
        /// <returns>The value of the body as a double type.</returns>
        /// <since_tizen> 4 </since_tizen>
        public double GetBodyAsDouble()
        {
            if (_body == IntPtr.Zero)
            {
                return 0d;
            }
            double[] ret = new double[1] ;
            Marshal.Copy(_body, ret, 0, 1);
            return ret[0];
        }

        /// <summary>
        /// Gets the value of the body as a boolean type.
        /// </summary>
        /// <returns>The value of the body as boolean type.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool GetBodyAsBoolean()
        {
            if (_body == IntPtr.Zero)
            {
                return false;
            }
            return Marshal.ReadByte(_body) != (byte)0;
        }

        /// <summary>
        /// Gets the value of the body as a string type.
        /// </summary>
        /// <returns>The value of the body as a string type.</returns>
        /// <since_tizen> 4 </since_tizen>
        public string GetBodyAsString()
        {
            if (_body == IntPtr.Zero)
            {
                return string.Empty;
            }
            return Marshal.PtrToStringAnsi(_body);
        }
    }
}
