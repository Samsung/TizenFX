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
        /// The Progress class.
        /// The progress item is proper to display data that has to be updated continuously. eg. Download percentage.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Progress : AbstractItem
        {
            /// <summary>
            /// Initializes Progress class.
            /// </summary>
            /// <param name="id"> An ID of the progress item. </param>
            /// <param name="min"> A minimum value of the progress item. </param>
            /// <param name="current"> A current value of the progress item. </param>
            /// <param name="max"> A maximum value of the progress item. </param>
            /// <since_tizen> 7 </since_tizen>
            public Progress(string id, float min, float current, float max) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ProgressCreate(out handle, id, min, current, max);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Progress(IntPtr ptr) : base(ptr)
            {
            }

            /// <summary>
            /// A current value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public float Current
            {
                get
                {
                    float cur;
                    Interop.NotificationEx.ProgressGetCurrent(NativeHandle, out cur);
                    return cur;
                }
                set
                {
                    Interop.NotificationEx.ProgressSetCurrent(NativeHandle, value);
                }
            }

            /// <summary>
            /// A minimum value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public float Min
            {
                get
                {
                    float min;
                    Interop.NotificationEx.ProgressGetMin(NativeHandle, out min);
                    return min;
                }
            }

            /// <summary>
            /// A maximum value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public float Max
            {
                get
                {
                    float max;
                    Interop.NotificationEx.ProgressGetMax(NativeHandle, out max);
                    return max;
                }
            }

            /// <summary>
            /// A type of progress item.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public ProgressType Type
            {
                get
                {
                    int nativeType;
                    Interop.NotificationEx.ProgressGetType(NativeHandle, out nativeType);
                    return (ProgressType)nativeType;
                }
                set
                {
                    Interop.NotificationEx.ProgressSetType(NativeHandle, (int)value);
                }
            }
        }
    }
}
