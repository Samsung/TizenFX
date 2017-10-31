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

namespace Tizen.WebView
{
    /// <summary>
    /// Argument from the SmartCallback.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class SmartCallbackArgs : EventArgs
    {
        private IntPtr _arg;

        internal SmartCallbackArgs(IntPtr arg)
        {
            _arg = arg;
        }

        /// <summary>
        /// Gets argument as integer type.
        /// </summary>
        /// <returns>Argument as integer type</returns>
        /// <since_tizen> 4 </since_tizen>
        public int GetAsInteger()
        {
            if (_arg == IntPtr.Zero)
            {
                return 0;
            }
            return Marshal.ReadInt32(_arg, 0);
        }

        /// <summary>
        /// Gets argument as double type.
        /// </summary>
        /// <returns>Argument as double type</returns>
        /// <since_tizen> 4 </since_tizen>
        public double GetAsDouble()
        {
            if (_arg == IntPtr.Zero)
            {
                return 0d;
            }
            double[] ret = new double[1];
            Marshal.Copy(_arg, ret, 0, 1);
            return ret[0];
        }

        /// <summary>
        /// Gets argument as boolean type.
        /// </summary>
        /// <returns>Argument as boolean type</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool GetAsBoolean()
        {
            if (_arg == IntPtr.Zero)
            {
                return false;
            }
            return Marshal.ReadByte(_arg) != (byte)0;
        }

        /// <summary>
        /// Gets argument as string type.
        /// </summary>
        /// <returns>Argument as string type</returns>
        /// <since_tizen> 4 </since_tizen>
        public string GetAsString()
        {
            if (_arg == IntPtr.Zero)
            {
                return string.Empty;
            }
            return Marshal.PtrToStringAnsi(_arg);
        }

        internal static SmartCallbackArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            return new SmartCallbackArgs(info);
        }
    }
}
