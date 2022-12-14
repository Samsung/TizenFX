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
    public class StrikethroughSpan : BaseSpan
    {

        /// <summary>
        /// Create underline span.<br />
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StrikethroughSpan Create()
        {
            StrikethroughSpan ret = new StrikethroughSpan(Interop.StrikethroughSpan.New(), true);
            return ret;
        }

        /// <summary>
        /// Create underline span.<br />
        /// </summary>
        /// <param name="color">The color of line</param>
        /// <param name="height">The height of line</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StrikethroughSpan Create(Color color, float height)
        {
            StrikethroughSpan ret = new StrikethroughSpan(Interop.StrikethroughSpan.New(Vector4.getCPtr(color), height), true);
            return ret;
        }

        internal StrikethroughSpan(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The color of line in underline-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color
        {
            get
            {
                Color ret = new Color(Interop.StrikethroughSpan.GetColor(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether the color is defined in underline-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasColor
        {
            get
            {
                bool ret = Interop.StrikethroughSpan.IsColorDefined(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The height of line in underline-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Height
        {
            get
            {
                float ret = Interop.StrikethroughSpan.GetHeight(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether the height is defined in underline-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasHeight
        {
            get
            {
                bool ret = Interop.StrikethroughSpan.IsHeightDefined(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }


        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.StrikethroughSpan.DeleteStrikethroughSpan(swigCPtr);
        }
    }
}