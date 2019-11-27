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
        /// The Entry class.
        /// Using this class, developers are able to create entry notification items.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Entry : AbstractItem
        {
            /// <summary>
            /// Initializes Entry class.
            /// </summary>
            /// <param name="id"> An ID of the Image item. </param>
            /// <since_tizen> 7 </since_tizen>
            public Entry(string id) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                Interop.NotificationEx.EntryCreate(out handle, id);                
                return handle;
            }))())
            {
            }

            internal Entry(IntPtr ptr) : base(ptr)
            {
            }

            /// <summary>
            /// The entry text.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public string Text
            {
                get
                {
                    string text;
                    Interop.NotificationEx.EntryGetText(NativeHandle, out text);
                    return text;
                }
                set
                {
                    Interop.NotificationEx.EntrySetText(NativeHandle, value);
                }
            }

            /// <summary>
            /// Sets multi-language text.
            /// </summary>
            /// <remarks>
            /// After successfully set multi-language text using this method, Text property will return multi-language text.
            /// </remarks>
            /// <param name="multi">A multi-language text.</param>
            /// <since_tizen> 7 </since_tizen>
            public void SetMultiLanguage(MultiLanguage multi)
            {
                if (multi == null)
                    Interop.NotificationEx.EntrySetMultiLanguage(NativeHandle, IntPtr.Zero);
                else
                    Interop.NotificationEx.EntrySetMultiLanguage(NativeHandle, multi.NativeHandle);
            }
        }
    }
}
