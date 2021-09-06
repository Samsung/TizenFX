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

using System.Collections.Generic;
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
    /// WebBackForwardList is a class for back-forward list of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebBackForwardList : Disposable
    {
        private WebBackForwardSubList backwardItemList = null;
        private WebBackForwardSubList forwardItemList = null;

        internal WebBackForwardList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Dispose for IDisposable pattern
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                if (backwardItemList != null)
                {
                    backwardItemList.Dispose();
                }
                if (forwardItemList != null)
                {
                    forwardItemList.Dispose();
                }
            }

            base.Dispose(type);
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
            return new WebBackForwardListItem(itemPtr, true);
        }

        /// <summary>
        /// Get previous item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardListItem GetPreviousItem()
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetPreviousItem(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new WebBackForwardListItem(itemPtr, true);
        }

        /// <summary>
        /// Get next item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardListItem GetNextItem()
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetNextItem(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new WebBackForwardListItem(itemPtr, true);
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
            return new WebBackForwardListItem(itemPtr, true);
        }

        /// <summary>
        /// Get copied backward items preceding the current item and limited by limit.
        /// Item in returned list starts with the oldest one.
        /// If limit is equal to ItemCount - 1, all the items preceding the current item are returned.
        /// </summary>
        /// <param name="limit">The number of items to retrieve.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WebBackForwardListItem> GetBackwardItems(int limit)
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetBackwardItems(SwigCPtr, limit);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (backwardItemList != null)
            {
                backwardItemList.Dispose();
            }
            backwardItemList = new WebBackForwardSubList(itemPtr, true);

            List<WebBackForwardListItem> list = new List<WebBackForwardListItem>();
            for (uint i = 0; i < backwardItemList.ItemCount; i++)
            {
                list.Add(backwardItemList.GetItemAtIndex(i));
            }
            return list;
        }

        /// <summary>
        /// Get copied forward items following the current item and limited by limit.
        /// Item in returned list starts with the oldest one.
        /// If limit is equal to ItemCount - 1, all the items preceding the current item are returned.
        /// </summary>
        /// <param name="limit">The number of items to retrieve.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WebBackForwardListItem> GetForwardItems(int limit)
        {
            System.IntPtr itemPtr = Interop.WebBackForwardList.GetBackwardItems(SwigCPtr, limit);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (forwardItemList != null)
            {
                forwardItemList.Dispose();
            }
            forwardItemList = new WebBackForwardSubList(itemPtr, true);

            List<WebBackForwardListItem> list = new List<WebBackForwardListItem>();
            for (uint i = 0; i < forwardItemList.ItemCount; i++)
            {
                list.Add(forwardItemList.GetItemAtIndex(i));
            }
            return list;
        }
    }

    /// <summary>
    /// WebBackForwardSubList is an internal class for back-forward copied list item of web view.
    /// </summary>
    internal class WebBackForwardSubList : Disposable
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
        internal uint ItemCount
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
        internal WebBackForwardListItem GetItemAtIndex(uint index)
        {
            System.IntPtr itemPtr = Interop.WebBackForwardSubList.GetItemAtIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new WebBackForwardListItem(itemPtr, false);
        }
    }
}
