/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd.
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
    /// WebUserMediaPermissionRequest.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebUserMediaPermissionRequest : Disposable
    {
        internal WebUserMediaPermissionRequest(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebUserMediaPermissionRequest.Delete(swigCPtr);
        }

        /// <summary>
        /// Set allowed.
        /// </summary>
        /// <param name="allowed">Allowed or not</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Set(bool allowed)
        {
            Interop.WebUserMediaPermissionRequest.Set(SwigCPtr, allowed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Suspend.
        /// </summary>
        /// <returns>true for done, otherwise, false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Suspend()
        {
            bool ret = Interop.WebUserMediaPermissionRequest.Suspend(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
