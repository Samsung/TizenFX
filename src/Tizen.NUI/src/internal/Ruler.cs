/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;

namespace Tizen.NUI
{
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Ruler : RefObject
    {

        internal Ruler(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Ruler.Ruler_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Ruler obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
           throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float Snap(float x, float bias)
        {
            float ret = Interop.Ruler.Ruler_Snap__SWIG_0(swigCPtr, x, bias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float Snap(float x)
        {
            float ret = Interop.Ruler.Ruler_Snap__SWIG_1(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float GetPositionFromPage(uint page, out uint volume, bool wrap)
        {
            float ret = Interop.Ruler.Ruler_GetPositionFromPage(swigCPtr, page, out volume, wrap);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual uint GetPageFromPosition(float position, bool wrap)
        {
            uint ret = Interop.Ruler.Ruler_GetPageFromPosition(swigCPtr, position, wrap);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual uint GetTotalPages()
        {
            uint ret = Interop.Ruler.Ruler_GetTotalPages(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Ruler.RulerType GetType()
        {
            Ruler.RulerType ret = (Ruler.RulerType)Interop.Ruler.Ruler_GetType(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEnabled()
        {
            bool ret = Interop.Ruler.Ruler_IsEnabled(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Enable()
        {
            Interop.Ruler.Ruler_Enable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Disable()
        {
            Interop.Ruler.Ruler_Disable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDomain(RulerDomain domain)
        {
            Interop.Ruler.Ruler_SetDomain(swigCPtr, RulerDomain.getCPtr(domain));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RulerDomain GetDomain()
        {
            RulerDomain ret = new RulerDomain(Interop.Ruler.Ruler_GetDomain(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DisableDomain()
        {
            Interop.Ruler.Ruler_DisableDomain(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Clamp(float x, float length, float scale)
        {
            float ret = Interop.Ruler.Ruler_Clamp__SWIG_0(swigCPtr, x, length, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Clamp(float x, float length)
        {
            float ret = Interop.Ruler.Ruler_Clamp__SWIG_1(swigCPtr, x, length);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Clamp(float x)
        {
            float ret = Interop.Ruler.Ruler_Clamp__SWIG_2(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float Clamp(float x, float length, float scale, SWIGTYPE_p_Dali__Toolkit__ClampState clamped)
        {
            float ret = Interop.Ruler.Ruler_Clamp__SWIG_3(swigCPtr, x, length, scale, SWIGTYPE_p_Dali__Toolkit__ClampState.getCPtr(clamped));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SnapAndClamp(float x, float bias, float length, float scale)
        {
            float ret = Interop.Ruler.Ruler_SnapAndClamp__SWIG_0(swigCPtr, x, bias, length, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SnapAndClamp(float x, float bias, float length)
        {
            float ret = Interop.Ruler.Ruler_SnapAndClamp__SWIG_1(swigCPtr, x, bias, length);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SnapAndClamp(float x, float bias)
        {
            float ret = Interop.Ruler.Ruler_SnapAndClamp__SWIG_2(swigCPtr, x, bias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SnapAndClamp(float x)
        {
            float ret = Interop.Ruler.Ruler_SnapAndClamp__SWIG_3(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float SnapAndClamp(float x, float bias, float length, float scale, SWIGTYPE_p_Dali__Toolkit__ClampState clamped)
        {
            float ret = Interop.Ruler.Ruler_SnapAndClamp__SWIG_4(swigCPtr, x, bias, length, scale, SWIGTYPE_p_Dali__Toolkit__ClampState.getCPtr(clamped));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum RulerType
        {
            /// <summary>A Fixed ruler.</summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.

            Fixed,

            /// <summary>A Free ruler.</summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            Free
        }
    }
}
