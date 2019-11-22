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
        /// The CheckBox class.
        /// Using this class, developers are able to check-box notification items.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class CheckBox : AbstractItem
        {
            /// <summary>
            /// Initializes CheckBox class.
            /// </summary>
            /// <param name="id"> An item ID. </param>
            /// <param name="title"> A title of this item. </param>
            /// <param name="isChecked"> A flag that represents whether this item is checked or not. </param>
            /// <since_tizen> 7 </since_tizen>
            public CheckBox(string id, string title, bool isChecked) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.CheckboxCreate(out handle, id, title, isChecked);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal CheckBox(IntPtr ptr) : base(ptr)
            {
            }

            /// <summary>
            /// A title of check-box.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public string Title
            {
                get
                {
                    string title;
                    Interop.NotificationEx.CheckboxGetTitle(NativeHandle, out title);
                    return title;
                }
            }

            /// <summary>
            /// Sets multi-language title.
            /// </summary>
            /// <remarks>
            /// After successfully set multi-language title using this method, Title property will return multi-language title.
            /// </remarks>
            /// <param name="title">A multi-language title.</param>
            /// <since_tizen> 7 </since_tizen>
            public void SetMultiLanguageTitle(MultiLanguage title)
            {
                if (title == null)
                    Interop.NotificationEx.CheckboxSetMultiLanguage(NativeHandle, IntPtr.Zero);
                else
                    Interop.NotificationEx.CheckboxSetMultiLanguage(NativeHandle, title.NativeHandle);
            }

            /// <summary>
            /// A value that represents whether this item is checked or not.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public bool IsChecked
            {
                get
                {
                    bool isChecked;
                    Interop.NotificationEx.CheckboxGetCheckedState(NativeHandle, out isChecked);
                    return isChecked;
                }
                set
                {
                    Interop.NotificationEx.CheckboxSetCheckedState(NativeHandle, value);
                }
            }
        }
    }
}
