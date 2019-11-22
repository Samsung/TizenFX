/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        /// <summary>
        /// The Color class.
        /// Using this class, developers are able to adjust color to notification items.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Color
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            internal IntPtr NativeHandle { get; set; }

            internal Color(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            /// <summary>
            /// Initializes Color class.
            /// </summary>
            /// <param name="alpha"> An alpha value. </param>
            /// <param name="red"> A red value. </param>
            /// <param name="green"> An green value. </param>
            /// <param name="blue"> An blue value. </param>
            /// <since_tizen> 7 </since_tizen>
            public Color(byte alpha, byte red, byte green, byte blue)
            {
                IntPtr ptr;
                ErrorCode err = Interop.NotificationEx.ColorCreate(out ptr, alpha, red, green, blue);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                NativeHandle = ptr;
            }

            /// <summary>
            /// Destructor of the Color class.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            ~Color()
            {
                ErrorCode err = Interop.NotificationEx.ColorDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy Color : " + err);
            }

            /// <summary>
            /// A red value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public byte Red
            {
                get
                {
                    byte val;
                    Interop.NotificationEx.ColorGetRed(NativeHandle, out val);
                    return val;
                }
            }

            /// <summary>
            /// A green value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public byte Green
            {
                get
                {
                    byte val;
                    Interop.NotificationEx.ColorGetGreen(NativeHandle, out val);
                    return val;
                }
            }

            /// <summary>
            /// A blue value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public byte Blue
            {
                get
                {
                    byte val;
                    Interop.NotificationEx.ColorGetBlue(NativeHandle, out val);
                    return val;
                }
            }

            /// <summary>
            /// An alpha value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public byte Alpha
            {
                get
                {
                    byte val;
                    Interop.NotificationEx.ColorGetAlpha(NativeHandle, out val);
                    return val;
                }
            }
        }
    }
}
