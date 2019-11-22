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
        /// The VisibilityAction class.
        /// Using this class, developers are able to assign visibility action to a specific item.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class VisibilityAction : AbstractAction
        {
            /// <summary>
            /// Initializes VisibilityAction class.
            /// </summary>
            /// <param name="extra"> An extra data of the VisibilityAction.
            /// This value is set to the VisibilityAction object's Extra attribute.
            /// </param>
            /// <since_tizen> 7 </since_tizen>
            public VisibilityAction(string extra) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ActionVisibilityCreate(out handle, extra);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal VisibilityAction(IntPtr handle) : base(handle)
            {
            }

            /// <summary>
            /// Sets the visibility state of the items when the action is triggered..
            /// </summary>
            /// <param name="id">The id of the item.</param>
            /// <param name="visible">The visibility state.</param>            
            /// <since_tizen> 6 </since_tizen>
            public void SetVisibility(string id, bool visible)
            {
                Interop.NotificationEx.ActionVisibilitySet(NativeHandle, id, visible);
            }
        }
    }
}
