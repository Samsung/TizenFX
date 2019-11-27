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
        /// The Geometry class.
        /// Using this class, developers are able to create a notification item's geometry data.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Geometry
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            internal IntPtr NativeHandle { get; set; }

            internal Geometry(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            /// <summary>
            /// Initializes Geometry class.
            /// </summary>
            /// <param name="x"> A X position of the notification item. </param>
            /// <param name="y"> A X position of the notification item. </param>
            /// <param name="width"> A width of the notification item. </param>
            /// <param name="height"> A height of the notification item. </param>
            /// <since_tizen> 7 </since_tizen>
            public Geometry(int x, int y, int width, int height)
            {
                IntPtr handle;
                Interop.NotificationEx.GeometryCreate(out handle, x, y, width, height);                
                NativeHandle = handle;
            }

            /// <summary>
            /// Destructor of the Geometry class.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            ~Geometry()
            {
                ErrorCode err = Interop.NotificationEx.GeometryDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy geometry : " + err);
            }

            /// <summary>
            /// A x position of the notification item.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public int X
            {
                get
                {
                    int x;
                    Interop.NotificationEx.GeometryGetX(NativeHandle, out x);
                    return x;
                }
            }

            /// <summary>
            /// A y position of the notification item.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public int Y
            {
                get
                {
                    int y;
                    Interop.NotificationEx.GeometryGetY(NativeHandle, out y);
                    return y;
                }
            }

            /// <summary>
            /// A width of the notification item.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public int Width
            {
                get
                {
                    int width;
                    Interop.NotificationEx.GeometryGetWidth(NativeHandle, out width);
                    return width;
                }
            }

            /// <summary>
            /// A height of the notification item.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public int Height
            {
                get
                {
                    int height;
                    Interop.NotificationEx.GeometryGetX(NativeHandle, out height);
                    return height;
                }
            }
        }
    }
}
