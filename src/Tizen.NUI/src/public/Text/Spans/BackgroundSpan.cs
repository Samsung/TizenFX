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

namespace Tizen.NUI.Text.Spans
{
    /// <summary>
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BackgroundSpan : BaseSpan
    {

        /// <summary>
        /// Create background color span Set and set color for it.<br />
        /// </summary>
        /// <param name="color">The background color</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackgroundSpan CreateWithBackgroundColor(Color color)
        {
            return BackgroundSpanBuilder.Initialize().WithBackgroundColor(color).Build();
        }

        internal BackgroundSpan(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The background-color in color-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color BackgroundColor
        {
            get
            {
                Color ret = new Color(Interop.BackgroundSpan.BackgroundColorGet(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether the background color is defined in color-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BackgroundColorDefined
        {
            get
            {
                bool ret = Interop.BackgroundSpan.BackgroundColorDefinedGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }


        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.BackgroundSpan.DeleteBackgroundSpan(swigCPtr);
        }
    }
}
