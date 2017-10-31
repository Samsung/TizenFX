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

namespace Tizen.NUI
{

    internal class Ruler : RefObject
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Ruler(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Ruler_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Ruler obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    throw new global::System.MethodAccessException("C++ destructor does not have public access");
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        public virtual float Snap(float x, float bias)
        {
            float ret = NDalicPINVOKE.Ruler_Snap__SWIG_0(swigCPtr, x, bias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float Snap(float x)
        {
            float ret = NDalicPINVOKE.Ruler_Snap__SWIG_1(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetPositionFromPage(uint page, out uint volume, bool wrap)
        {
            float ret = NDalicPINVOKE.Ruler_GetPositionFromPage(swigCPtr, page, out volume, wrap);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual uint GetPageFromPosition(float position, bool wrap)
        {
            uint ret = NDalicPINVOKE.Ruler_GetPageFromPosition(swigCPtr, position, wrap);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual uint GetTotalPages()
        {
            uint ret = NDalicPINVOKE.Ruler_GetTotalPages(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public new Ruler.RulerType GetType()
        {
            Ruler.RulerType ret = (Ruler.RulerType)NDalicPINVOKE.Ruler_GetType(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool IsEnabled()
        {
            bool ret = NDalicPINVOKE.Ruler_IsEnabled(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Enable()
        {
            NDalicPINVOKE.Ruler_Enable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Disable()
        {
            NDalicPINVOKE.Ruler_Disable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetDomain(RulerDomain domain)
        {
            NDalicPINVOKE.Ruler_SetDomain(swigCPtr, RulerDomain.getCPtr(domain));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public RulerDomain GetDomain()
        {
            RulerDomain ret = new RulerDomain(NDalicPINVOKE.Ruler_GetDomain(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void DisableDomain()
        {
            NDalicPINVOKE.Ruler_DisableDomain(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float Clamp(float x, float length, float scale)
        {
            float ret = NDalicPINVOKE.Ruler_Clamp__SWIG_0(swigCPtr, x, length, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float Clamp(float x, float length)
        {
            float ret = NDalicPINVOKE.Ruler_Clamp__SWIG_1(swigCPtr, x, length);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float Clamp(float x)
        {
            float ret = NDalicPINVOKE.Ruler_Clamp__SWIG_2(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float Clamp(float x, float length, float scale, SWIGTYPE_p_Dali__Toolkit__ClampState clamped)
        {
            float ret = NDalicPINVOKE.Ruler_Clamp__SWIG_3(swigCPtr, x, length, scale, SWIGTYPE_p_Dali__Toolkit__ClampState.getCPtr(clamped));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float SnapAndClamp(float x, float bias, float length, float scale)
        {
            float ret = NDalicPINVOKE.Ruler_SnapAndClamp__SWIG_0(swigCPtr, x, bias, length, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float SnapAndClamp(float x, float bias, float length)
        {
            float ret = NDalicPINVOKE.Ruler_SnapAndClamp__SWIG_1(swigCPtr, x, bias, length);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float SnapAndClamp(float x, float bias)
        {
            float ret = NDalicPINVOKE.Ruler_SnapAndClamp__SWIG_2(swigCPtr, x, bias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float SnapAndClamp(float x)
        {
            float ret = NDalicPINVOKE.Ruler_SnapAndClamp__SWIG_3(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float SnapAndClamp(float x, float bias, float length, float scale, SWIGTYPE_p_Dali__Toolkit__ClampState clamped)
        {
            float ret = NDalicPINVOKE.Ruler_SnapAndClamp__SWIG_4(swigCPtr, x, bias, length, scale, SWIGTYPE_p_Dali__Toolkit__ClampState.getCPtr(clamped));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public enum RulerType
        {
            Fixed,
            Free
        }

    }

}
