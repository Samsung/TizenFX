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
    public abstract class Spanned : CharacterSequence
    {

        internal Spanned(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Retrieve all spans<br />
        /// </summary>
        /// <returns>list of spans</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<BaseSpan> GetAllSpans( )
        {
            StdVectorBaseSpan ret = new StdVectorBaseSpan(Interop.Spanned.GetAllSpans(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            List<BaseSpan> list = ret.CreateListFromNativeVector();

            return list;
        }

        /// <summary>
        /// Retrieve all spans and ranges. Two lists are mapped by index.<br />
        /// </summary>
        /// <param name="spans">The container to clone spans.</param>
        /// <param name="ranges">The container to clone ranges.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RetrieveAllSpansAndRanges( List<BaseSpan> spans, List<Range> ranges)
        {
            //Create native container for spans
            StdVectorBaseSpan nativeVectorSpans = new StdVectorBaseSpan(Interop.StdVectorBaseSpan.CreateVector(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            //Create native container for ranges
            StdVectorRange nativeVectorRanges = new StdVectorRange(Interop.StdVectorRange.CreateVector(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            Interop.Spanned.RetrieveAllSpansAndRanges(SwigCPtr, nativeVectorSpans.SwigCPtr, nativeVectorRanges.SwigCPtr);

            // Copy from native containers
            nativeVectorSpans.FillListFromNativeVector(spans);
            nativeVectorRanges.FillListFromNativeVector(ranges);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Spanned.DeleteSpanned(swigCPtr);
        }

    }
}