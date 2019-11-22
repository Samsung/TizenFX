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
        /// The Button class.
        /// Using this class, developers are able to create button style notification items.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Button : AbstractItem
        {
            /// <summary>
            /// Initializes Button class.
            /// </summary>
            /// <param name="id"> An item ID. </param>
            /// <param name="title"> A button title. </param>
            /// <since_tizen> 7 </since_tizen>
            public Button(string id, string title) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ButtonCreate(out handle, id, title);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Button(IntPtr ptr) : base(ptr)
            {
            }

            /// <summary>
            /// A title of button.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public string Title
            {
                get
                {
                    string title;
                    Interop.NotificationEx.ButtonGetTitle(NativeHandle, out title);                    
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
                    Interop.NotificationEx.ButtonSetMultiLanguageTitle(NativeHandle, IntPtr.Zero);
                else
                    Interop.NotificationEx.ButtonSetMultiLanguageTitle(NativeHandle, title.NativeHandle);
            }
        }
    }
}
