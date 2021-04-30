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
    /// It is a class for form repost policy decision maker of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebContextMenuItemList : Disposable
    {
        internal WebContextMenuItemList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebContextMenuItemList.DeleteWebContextMenuItemList(swigCPtr);
        }

        /// <summary>
        /// Gets item count
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ItemCount
        {
            get
            {
                return Interop.WebContextMenuItemList.GetItemCount(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets item at the index.
        /// <param name="index">The index of item</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebContextMenuItem GetItemAtIndex(uint index)
        {
            IntPtr result = Interop.WebContextMenuItemList.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new WebContextMenuItem(result, false);
        }
    }
}
