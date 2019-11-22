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
        /// The Padding class.
        /// Using this class, developers are able to adjust padding to items.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Padding
        {
            internal IntPtr NativeHandle { get; set; }
            
            internal Padding(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            /// <summary>
            /// Initializes Padding class.
            /// </summary>
            /// <param name="left"> A left padding. </param>
            /// <param name="top"> A top padding. </param>
            /// <param name="right"> A right padding. </param>
            /// <param name="bottom"> A bottom padding. </param>
            /// <since_tizen> 7 </since_tizen>
            public Padding(int left, int top, int right, int bottom)
            {
                IntPtr ptr;
                ErrorCode err = Interop.NotificationEx.PaddingCreate(out ptr, left, top, right, bottom);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                NativeHandle = ptr;
            }

            /// <summary>
            /// A left padding.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public int Left
            {
                get
                {
                    int left;
                    Interop.NotificationEx.PaddingGetLeft(NativeHandle, out left);
                    return left;
                }
            }

            /// <summary>
            /// A top padding.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public int Top
            {
                get
                {
                    int top;
                    Interop.NotificationEx.PaddingGetTop(NativeHandle, out top);
                    return top;
                }
            }

            /// <summary>
            /// A right padding.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public int Right
            {
                get
                {
                    int right;
                    Interop.NotificationEx.PaddingGetRight(NativeHandle, out right);
                    return right;
                }
            }

            /// <summary>
            /// A bottom padding.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public int Bottom
            {
                get
                {
                    int bottom;
                    Interop.NotificationEx.PaddingGetBottom(NativeHandle, out bottom);
                    return bottom;
                }
            }
        }
    }
}
