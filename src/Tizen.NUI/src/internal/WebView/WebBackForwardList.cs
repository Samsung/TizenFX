/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// WebBackForwardListItem is a class for back-forward list item of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebBackForwardListItem : Disposable
    {
        internal WebBackForwardListItem(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Get uri.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri Url
        {
            get
            {
                return new Uri(Interop.WebBackForwardListItem.GetUrl(SwigCPtr));
            }
        }

        /// <summary>
        /// Get title.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Title
        {
            get
            {
                return Interop.WebBackForwardListItem.GetTitle(SwigCPtr);
            }
        }

        /// <summary>
        /// Get original url.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri OriginalUrl
        {
            get
            {
                return new Uri(Interop.WebBackForwardListItem.GetOriginalUrl(SwigCPtr));
            }
        }
    }

    /// <summary>
    /// WebBackForwardList is a class for back-forward list of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebBackForwardList : Disposable
    {
        internal WebBackForwardList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Get item count.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ItemCount
        {
            get
            {
                return Interop.WebBackForwardList.GetItemCount(SwigCPtr);
            }
        }

        /// <summary>
        /// Get current item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardListItem GetCurrentItem()
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetCurrentItem(SwigCPtr);
            return new WebBackForwardListItem(itemPtr, false);
        }

        /// <summary>
        /// Get current item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardListItem GetItemAtIndex(int index)
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetItemAtIndex(SwigCPtr, index);
            return new WebBackForwardListItem(itemPtr, false);
        }
    }
}

