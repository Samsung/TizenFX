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
        /// The Time class.
        /// Using this class, developers are able to contain time information in notifications.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Time : AbstractItem
        {
            private DateTime _time;

            /// <summary>
            /// Initializes Time class.
            /// </summary>
            /// <param name="id"> An ID of this item. </param>
            /// <param name="dateTime"> A time value of Time item. </param>
            /// <exception cref="ArgumentException">Thrown when the dateTime parameter is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public Time(string id, DateTime dateTime) : base(((Func<IntPtr>)(delegate ()
            {
                if (dateTime == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                IntPtr handle;
                Int32 nativeTime = Convert.ToInt32((dateTime - new DateTime(1970, 1, 1)).TotalSeconds);
                ErrorCode err = Interop.NotificationEx.TimeCreate(out handle, id, nativeTime);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Time(IntPtr ptr) : base(ptr)
            {
            }

            internal override void Serialize()
            {
                base.Serialize();
                if (_time != null)
                    DateTime = _time;
            }

            /// <summary>
            /// A time value.
            /// </summary>
            /// <exception cref="ArgumentException">Thrown when the dateTime value is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public DateTime DateTime
            {
                get
                {
                    if (_time != null)
                        return _time;
                    Int32 time;
                    Interop.NotificationEx.TimeGetTime(NativeHandle, out time);
                    _time = new DateTime(1970, 1, 1).AddSeconds(time);
                    return _time;
                }
                private set
                {
                    if (value == null)
                        ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                    Interop.NotificationEx.TimeSetTime(NativeHandle, (int)(value - new DateTime(1970, 1, 1)).TotalSeconds);
                    _time = value;
                }
            }
        }
    }
}
