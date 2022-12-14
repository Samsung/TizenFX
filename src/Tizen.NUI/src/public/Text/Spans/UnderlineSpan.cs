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
    public class UnderlineSpan : BaseSpan
    {

        /// <summary>
        /// Create underline span.<br />
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UnderlineSpan Create()
        {
            UnderlineSpan ret = new UnderlineSpan(Interop.UnderlineSpan.New(), true);
            return ret;
        }

        /// <summary>
        /// Create underline span.<br />
        /// </summary>
        /// <param name="color">The color of line</param>
        /// <param name="height">The height of line</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UnderlineSpan CreateSolidLine(Color color, float height)
        {
            UnderlineSpan ret = new UnderlineSpan(Interop.UnderlineSpan.NewSolid(Vector4.getCPtr(color), height), true);
            return ret;
        }

        /// <summary>
        /// Create underline span.<br />
        /// </summary>
        /// <param name="color">The color of line</param>
        /// <param name="height">The height of line</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UnderlineSpan CreateDoubleLine(Color color, float height)
        {
            UnderlineSpan ret = new UnderlineSpan(Interop.UnderlineSpan.NewDouble(Vector4.getCPtr(color), height), true);
            return ret;
        }

        /// <summary>
        /// Create underline span.<br />
        /// </summary>
        /// <param name="color">The color of line</param>
        /// <param name="height">The height of line</param>
        /// <param name="dashGap">The dash-gap of line</param>
        /// <param name="dashWidth">The dash-width of line</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UnderlineSpan CreateDashedLine(Color color, float height, float dashGap, float dashWidth)
        {
            UnderlineSpan ret = new UnderlineSpan(Interop.UnderlineSpan.NewDashed(Vector4.getCPtr(color), height, dashGap, dashWidth), true);
            return ret;
        }

        internal UnderlineSpan(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The line type in underline-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnderlineType Type
        {
            get
            {
                UnderlineType ret = (UnderlineType)Interop.UnderlineSpan.GetType(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether the line type is defined in underline-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasType
        {
            get
            {
                bool ret = Interop.UnderlineSpan.IsTypeDefined(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
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
                Color ret = new Color(Interop.UnderlineSpan.GetColor(SwigCPtr), true);
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
                bool ret = Interop.UnderlineSpan.IsColorDefined(SwigCPtr);
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
                float ret = Interop.UnderlineSpan.GetHeight(SwigCPtr);
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
                bool ret = Interop.UnderlineSpan.IsHeightDefined(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The dash-gap of line in underline-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float DashGap
        {
            get
            {
                float ret = Interop.UnderlineSpan.GetDashGap(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether the dash-gap is defined in underline-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasDashGap
        {
            get
            {
                bool ret = Interop.UnderlineSpan.IsDashGapDefined(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The dash-width of line in underline-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float DashWidth
        {
            get
            {
                float ret = Interop.UnderlineSpan.GetDashWidth(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether the dash-width is defined in underline-span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasDashWidth
        {
            get
            {
                bool ret = Interop.UnderlineSpan.IsDashWidthDefined(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.UnderlineSpan.DeleteUnderlineSpan(swigCPtr);
        }
    }
}