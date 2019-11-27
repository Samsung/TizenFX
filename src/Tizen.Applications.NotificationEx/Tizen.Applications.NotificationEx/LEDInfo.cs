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
        /// The LEDInfo class.
        /// Receives notification items related events from Reporter.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class LEDInfo
        {
            private Color _color;
            internal IntPtr NativeHandle { get; set; }

            internal LEDInfo(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            /// <summary>
            /// Initializes LEDInfo class.
            /// </summary>
            /// <param name="color"> A color of led. It can not be null. </param>     
            /// <exception cref="ArgumentException">Thrown when the color parameter is null.
            /// <since_tizen> 7 </since_tizen>
            public LEDInfo(Color color)
            {
                if (color == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);

                IntPtr handle;
                Interop.NotificationEx.LEDInfoCreate(out handle, color.NativeHandle);                
            }

            /// <summary>
            /// Destructor of the LEDInfo class.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            ~LEDInfo()
            {
                ErrorCode err = Interop.NotificationEx.LEDInfoDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy LEDInfo");
            }

            /// <summary>
            /// A turning on LED period.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public int OnPeriod
            {
                get
                {
                    int period;
                    Interop.NotificationEx.LEDInfoGetOnPeriod(NativeHandle, out period);
                    return period;
                }
                set
                {
                    Interop.NotificationEx.LEDInfoSetOnPeriod(NativeHandle, value);
                }
            }

            /// <summary>
            /// A turning off LED period.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public int OffPeriod
            {
                get
                {
                    int period;
                    Interop.NotificationEx.LEDInfoGetOffPeriod(NativeHandle, out period);
                    return period;
                }
                set
                {
                    Interop.NotificationEx.LEDInfoSetOffPeriod(NativeHandle, value);
                }
            }

            /// <summary>
            /// A LED color.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Color Color
            {
                get
                {
                    if (_color != null)
                        return _color;
                    IntPtr handle;
                    ErrorCode err = Interop.NotificationEx.LEDInfoGetColor(NativeHandle, out handle);
                    if (err != ErrorCode.None)
                        ErrorFactory.ThrowException(err);
                    _color = new Color(handle);
                    return _color;
                }
                private set
                {
                    if (value == null)
                        Interop.NotificationEx.LEDInfoSetColor(NativeHandle, IntPtr.Zero);
                    else
                        Interop.NotificationEx.LEDInfoSetColor(NativeHandle, value.NativeHandle);
                    _color = value;
                }
            }
        }
    }
}
