/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;

using Tizen.NUI.Text.Spans;

namespace Tizen.NUI.Text
{
    /// <summary>
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Spannable : Spanned
    {

        internal Spannable(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Add the given style span on the given range of text.
        /// </summary>
        /// <param name="styleSpan">The span of style to apply it on range</param>
        /// <param name="range">The range</param>
        /// <returns>true if the range is valid on text. Otherwise false</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AttachSpan(BaseSpan styleSpan, Range range)
        {
            bool ret = Interop.Spannable.AttachSpan((SwigCPtr),BaseSpan.getCPtr(styleSpan),Range.getCPtr(range));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Remove the given style span on all ranges of text.
        /// checks if styleSpan exists, and if it does, it's to be removed.
        /// </summary>
        /// <param name="styleSpan">The span of style to apply it on range</param>
        /// <returns>true if the styleSpan was exist and removed. Otherwise false</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DetachSpan(BaseSpan styleSpan)
        {
            bool ret = Interop.Spannable.DetachSpan((SwigCPtr),BaseSpan.getCPtr(styleSpan));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Spannable.DeleteSpannable(swigCPtr);
        }





    }
}