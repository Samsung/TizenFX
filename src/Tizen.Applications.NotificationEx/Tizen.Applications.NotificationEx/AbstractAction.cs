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
        /// The AbstractAction class.
        /// Using this class, developers are able to make an action that can be added to the item.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public abstract class AbstractAction
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            internal AbstractAction(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            /// <summary>
            /// Destructor of the AbstractAction class.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            ~AbstractAction()
            {
                ErrorCode err = Interop.NotificationEx.ActionDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy action : " + err);
            }

            internal IntPtr NativeHandle { get; set; }

            /// <summary>
            /// Whether the action is for local or not.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public bool IsLocal { 
                get
                {
                    bool isLocal;
                    Interop.NotificationEx.ActionIsLocal(NativeHandle, out isLocal);
                    return isLocal;
                }
            }

            /// <summary>
            /// The action type.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public ActionType Type
            {
                get
                {
                    int type;
                    Interop.NotificationEx.ActionGetType(NativeHandle, out type);
                    return (ActionType)type;
                }
            }

            /// <summary>
            /// The extra data of action.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public string Extra
            {
                get
                {
                    string extra;
                    Interop.NotificationEx.ActionGetExtra(NativeHandle, out extra);
                    return extra;
                }
            }

            /// <summary>
            /// Executes action.
            /// </summary>
            /// <param name="item"> An item which action will be executed. </param>
            /// <exception cref="ArgumentException">Thrown when the item prameter is not valid.</exception>
            /// <since_tizen> 7 </since_tizen>
            public virtual void Execute(AbstractItem item)
            {
                if (item == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);

                Interop.NotificationEx.ActionExecute(NativeHandle, item.NativeHandle);
            }
        }
    }
}
