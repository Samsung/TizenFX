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

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebBackForwardListItem.DeleteItem(swigCPtr);
        }

        /// <summary>
        /// Get uri.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Url
        {
            get
            {
                return Interop.WebBackForwardListItem.GetUrl(SwigCPtr);
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
        public string OriginalUrl
        {
            get
            {
                return Interop.WebBackForwardListItem.GetOriginalUrl(SwigCPtr);
            }
        }
    }

    /// <summary>
    /// WebBackForwardSubList is a class for back-forward copied list item of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebBackForwardSubList : Disposable
    {
        internal WebBackForwardSubList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebBackForwardSubList.DeleteCopiedItems(swigCPtr);
        }

        /// <summary>
        /// Get item count.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ItemCount
        {
            get
            {
                return Interop.WebBackForwardSubList.GetItemCount(SwigCPtr);
            }
        }

        /// <summary>
        /// Get item with index.
        /// </summary>
        /// <param name="index">The index of list item.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardListItem GetItemAtIndex(uint index)
        {
            System.IntPtr itemPtr = Interop.WebBackForwardSubList.GetItemAtIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            WebBackForwardListItem ret = new WebBackForwardListItem(itemPtr, false);
            return ret;
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
        public uint ItemCount
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
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            WebBackForwardListItem ret = new WebBackForwardListItem(itemPtr, true);
            return ret;
        }

        /// <summary>
        /// Get previous item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardListItem GetPreviousItem()
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetPreviousItem(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            WebBackForwardListItem ret = new WebBackForwardListItem(itemPtr, true);
            return ret;
        }

        /// <summary>
        /// Get next item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardListItem GetNextItem()
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetNextItem(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            WebBackForwardListItem ret = new WebBackForwardListItem(itemPtr, true);
            return ret;
        }

        /// <summary>
        /// Get item with index.
        /// </summary>
        /// <param name="index">The index of list item.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardListItem GetItemAtIndex(int index)
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetItemAtIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            WebBackForwardListItem ret = new WebBackForwardListItem(itemPtr, true);
            return ret;
        }

        /// <summary>
        /// Get copied backward items.
        /// </summary>
        /// <param name="index">limit The number of items to retrieve.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardSubList GetBackwardItems(int index)
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetBackwardItems(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            WebBackForwardSubList ret = new WebBackForwardSubList(itemPtr, true);
            return ret;
        }

        /// <summary>
        /// Get copied forward items.
        /// </summary>
        /// <param name="index">limit The number of items to retrieve.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardSubList GetForwardItems(int index)
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetBackwardItems(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            WebBackForwardSubList ret = new WebBackForwardSubList(itemPtr, true);
            return ret;
        }
    }
}

