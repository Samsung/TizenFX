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
        /// The Text class.
        /// Using this class, developers are able to contain text information in notifications.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Text : AbstractItem
        {
            /// <summary>
            /// Initializes Text class.
            /// </summary>
            /// <param name="id"> The ID of this item. </param>
            /// <param name="contents"> The contents of text item. It cannot be null.</param>
            /// <param name="hyperlink"> The hyperlink value of text item. </param>
            /// <exception cref="ArgumentException">Thrown when the contents argument is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public Text(string id, string contents, string hyperlink) : base(((Func<IntPtr>)(delegate ()
            {
                if (contents == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);

                IntPtr handle;
                Interop.NotificationEx.TextCreate(out handle, id, contents, hyperlink);                
                return handle;
            }))())
            {
            }

            internal Text(IntPtr ptr) : base(ptr)
            {
            }

            /// <summary>
            /// The contents of text item.
            /// </summary>
            /// <exception cref="ArgumentException">Thrown when the contents value is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public string Contents
            {
                get
                {
                    string contents;
                    Interop.NotificationEx.TextGetContents(NativeHandle, out contents);                    
                    return contents;
                }
                set
                {
                    if (value == null)
                        ErrorFactory.ThrowException(ErrorCode.InvalidParameter);

                    Interop.NotificationEx.TextSetContents(NativeHandle, value);                    
                }
            }

            /// <summary>
            /// Sets multi-language item to text item.
            /// After multi-language set, Contents attribute will return multi-language contents.
            /// </summary>
            /// <param name="multi"> The multi-language item. </param>
            /// <since_tizen> 7 </since_tizen>
            public void SetMultiLanguage(MultiLanguage multi)
            {
                if (multi == null)
                    Interop.NotificationEx.TextSetMultiLanguage(NativeHandle, IntPtr.Zero);
                else
                    Interop.NotificationEx.TextSetMultiLanguage(NativeHandle, multi.NativeHandle);
            }
        }
    }
}
