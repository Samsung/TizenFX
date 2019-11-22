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
        /// The MultiLanguage class.
        /// Using this class, developers are able to use multi-language text for notification items.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class MultiLanguage
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            internal IntPtr NativeHandle { get; set; }

            /// <summary>
            /// Initializes Multi class.
            /// </summary>
            /// <param name="msgid"> The identifier of the message to be translated. One of the identifers declared in PO files.
            /// The message of msgid and format must contain the same specifiers and in the same order.
            /// </param>
            /// <param name="format"> The string that contains the text to be written.
            /// It can optionally contain embedded format specifiers that are replaced by the values specified in subsequent additional arguments and formatted as requested.
            /// Valid specifiers are as follows. 
            /// %d : Signed decimal integer 
            /// %f : Decimal floating point 
            /// %s : String of characters</param>
            /// <param name="args"> The additional arguments. The values to be used to replace format specifiers in the format string. </param>
            /// <since_tizen> 7 </since_tizen>
            public MultiLanguage(string msgid, string format, params object[] args)
            {
                IntPtr handle;

                ErrorCode err = Interop.NotificationEx.MultiLanguageCreate(out handle, msgid, format, args);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                NativeHandle = handle;
            }

            /// <summary>
            /// Destructor of the MultiLanguage class.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            ~MultiLanguage()
            {
                ErrorCode err = Interop.NotificationEx.MultiLanguageDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy multi language");
            }
        }
    }
}
