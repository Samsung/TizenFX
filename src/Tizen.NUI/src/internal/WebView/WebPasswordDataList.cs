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
    /// It is a class for password data list of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebPasswordDataList : Disposable
    {
        internal WebPasswordDataList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebPasswordDataList.DeleteWebPasswordDataList(swigCPtr);
        }

        /// <summary>
        /// Count of password data list.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ItemCount
        {
            get
            {
                return Interop.WebPasswordDataList.GetItemCount(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets password data by index.
        /// <param name="index">index of list</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebPasswordData GetItemAtIndex(uint index)
        {
            System.IntPtr dataIntPtr = Interop.WebPasswordDataList.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) return null;
            return new WebPasswordData(dataIntPtr, false);
        }
    }
}
