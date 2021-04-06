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
    /// It is a class for form repost decision of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebFormRepostPolicyDecision : Disposable
    {
        internal WebFormRepostPolicyDecision(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Reply whether form repost decision is allowed or not.
        /// <param name="allowed">allowed or not</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reply(bool allowed)
        {
            Interop.WebFormRepostDecision.Reply(SwigCPtr, allowed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WebContext obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }
    }
}
