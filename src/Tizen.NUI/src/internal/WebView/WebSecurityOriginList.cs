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
    /// It is a class for security origin of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebSecurityOrigin : Disposable
    {
        internal WebSecurityOrigin(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Host of security origin.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Host
        {
            get
            {
                string result = Interop.WebSecurityOrigin.GetHost(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) return null;
                return result;
            }
        }

        /// <summary>
        /// Protocol of security origin.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Protocol
        {
            get
            {
                string result = Interop.WebSecurityOrigin.GetProtocol(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) return null;
                return result;
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WebSecurityOrigin obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }
    }

    /// <summary>
    /// It is a class for security origin list of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebSecurityOriginList : Disposable
    {
        internal WebSecurityOriginList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebSecurityOriginList.DeleteWebSecurityOriginList(swigCPtr);
        }

        /// <summary>
        /// Count of security origin list.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ItemCount
        {
            get
            {
                uint result = Interop.WebSecurityOriginList.GetItemCount(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) return 0;
                return result;
            }
        }

        /// <summary>
        /// Gets security origin by index.
        /// <param name="index">index of list</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebSecurityOrigin GetItemAtIndex(uint index)
        {
            System.IntPtr dataIntPtr = Interop.WebSecurityOriginList.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) return null;
            return new WebSecurityOrigin(dataIntPtr, false);
        }
    }
}
