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
        /// The AppControlAction class.
        /// If you want to add application launch action, attach this action to the notification item.        
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class AppControlAction : AbstractAction
        {
            /// <summary>
            /// Initializes AppControlAction class.
            /// </summary>
            /// <param name="control"> An AppControl which contains application information to be launched by viewer. </param>
            /// <param name="extra"> An extra data. </param>
            /// <since_tizen> 7 </since_tizen>
            public AppControlAction(AppControl control, string extra) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ActionAppControlCreate(
                    out handle, control.SafeAppControlHandle.DangerousGetHandle(), extra);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal AppControlAction(IntPtr handle) : base(handle)
            {
            }
        }
    }
}
