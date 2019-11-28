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
using System.Collections.Generic;
using System.Linq;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        /// <summary>
        /// The InputSelector class.
        /// Using this class, developers are able to create notification items which can have predefined contents list.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class InputSelector : AbstractItem
        {
            IList<string> _contents;
            private const string LogTag = "Tizen.Applications.NotificationEx";

            /// <summary>
            /// Initializes InputSelector class.
            /// </summary>
            /// <param name="id"> An ID of the InputSelector item. </param>
            /// <since_tizen> 7 </since_tizen>
            public InputSelector(string id) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                Interop.NotificationEx.InputSelectorCreate(out handle, id);               
                return handle;
            }))())
            {
            }

            internal InputSelector(IntPtr ptr) : base(ptr)
            {
                _contents = new List<string>();

                IntPtr contents;
                int count;
                Interop.NotificationEx.InputSelectorGetContents(NativeHandle, out contents, out count);
                if (count == 0)
                    return;

                string[] arr = Util.IntPtrToStringArray(contents, count);
                Interop.NotificationEx.ItemFreeStringList(contents, count);
                _contents = arr.ToList();
            }

            internal override void Serialize()
            {
                base.Serialize();
                if (_contents != null)
                    Contents = _contents;
            }

            /// <summary>
            /// A contents list.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public IList<string> Contents
            {
                get
                {
                    if (_contents != null)
                        return _contents;

                    _contents = new List<string>();

                    IntPtr contents;
                    int count;
                    Interop.NotificationEx.InputSelectorGetContents(NativeHandle, out contents, out count);
                    if (count == 0)
                        return _contents;
                   
                    string[] arr = Util.IntPtrToStringArray(contents, count);
                    Interop.NotificationEx.ItemFreeStringList(contents, count);
                    Log.Info(LogTag, "Get Contents #" + count);
                    _contents = arr.ToList();
                    return _contents;
                }
                set
                {
                    if (value == null)
                        ErrorFactory.ThrowException(ErrorCode.InvalidParameter);

                    Interop.NotificationEx.InputSelectorSetContents(NativeHandle, value.ToArray(), value.Count);
                    Log.Info(LogTag, "Set Contents");
                    _contents = value;
                }
            }

            /// <summary>
            /// Sets multi-language contents
            /// </summary>
            /// <remarks>
            /// After successfully set multi-language contents using this method, Contents property will return multi-language contents.
            /// </remarks>
            /// <param name="contents">A multi-language contens list.</param>
            /// <since_tizen> 7 </since_tizen>
            public void SetMultiLanguageContents(IList<MultiLanguage> contents)
            {
                if (contents == null)
                    Interop.NotificationEx.InputSelectorSetMultiLanguageContents(NativeHandle, IntPtr.Zero, 0);
                else
                    Interop.NotificationEx.InputSelectorSetMultiLanguageContents(NativeHandle, Util.ListToIntPtr(contents), contents.Count);
            }
        }
    }
}
