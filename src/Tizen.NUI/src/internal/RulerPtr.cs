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

    internal class RulerPtr : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal RulerPtr(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RulerPtr obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;


        ~RulerPtr()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
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
                    Interop.Ruler.delete_RulerPtr(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }


        public RulerPtr() : this(Interop.Ruler.new_RulerPtr__SWIG_0(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public RulerPtr(Ruler p) : this(Interop.Ruler.new_RulerPtr__SWIG_1(Ruler.getCPtr(p)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public RulerPtr(RulerPtr rhs) : this(Interop.Ruler.new_RulerPtr__SWIG_2(RulerPtr.getCPtr(rhs)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public Ruler Get()
        {
            global::System.IntPtr cPtr = Interop.Ruler.RulerPtr_Get(swigCPtr);
            Ruler ret = (cPtr == global::System.IntPtr.Zero) ? null : new Ruler(cPtr, false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public Ruler __deref__()
        {
            global::System.IntPtr cPtr = Interop.Ruler.RulerPtr___deref__(swigCPtr);
            Ruler ret = (cPtr == global::System.IntPtr.Zero) ? null : new Ruler(cPtr, false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public Ruler __ref__()
        {
            Ruler ret = new Ruler(Interop.Ruler.RulerPtr___ref__(swigCPtr), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public RulerPtr Assign(RulerPtr rhs)
        {
            RulerPtr ret = new RulerPtr(Interop.Ruler.RulerPtr_Assign__SWIG_0(swigCPtr, RulerPtr.getCPtr(rhs)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public RulerPtr Assign(Ruler rhs)
        {
            RulerPtr ret = new RulerPtr(Interop.Ruler.RulerPtr_Assign__SWIG_1(swigCPtr, Ruler.getCPtr(rhs)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Reset()
        {
            Interop.Ruler.RulerPtr_Reset__SWIG_0(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void Reset(Ruler rhs)
        {
            Interop.Ruler.RulerPtr_Reset__SWIG_1(swigCPtr, Ruler.getCPtr(rhs));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public Ruler Detach()
        {
            global::System.IntPtr cPtr = Interop.Ruler.RulerPtr_Detach(swigCPtr);
            Ruler ret = (cPtr == global::System.IntPtr.Zero) ? null : new Ruler(cPtr, false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float Snap(float x, float bias)
        {
            float ret = Interop.Ruler.RulerPtr_Snap__SWIG_0(swigCPtr, x, bias);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float Snap(float x)
        {
            float ret = Interop.Ruler.RulerPtr_Snap__SWIG_1(swigCPtr, x);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float GetPositionFromPage(uint page, out uint volume, bool wrap)
        {
            float ret = Interop.Ruler.RulerPtr_GetPositionFromPage(swigCPtr, page, out volume, wrap);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetPageFromPosition(float position, bool wrap)
        {
            uint ret = Interop.Ruler.RulerPtr_GetPageFromPosition(swigCPtr, position, wrap);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetTotalPages()
        {
            uint ret = Interop.Ruler.RulerPtr_GetTotalPages(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public new Ruler.RulerType GetType()
        {
            Ruler.RulerType ret = (Ruler.RulerType)Interop.Ruler.RulerPtr_GetType(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool IsEnabled()
        {
            bool ret = Interop.Ruler.RulerPtr_IsEnabled(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Enable()
        {
            Interop.Ruler.RulerPtr_Enable(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void Disable()
        {
            Interop.Ruler.RulerPtr_Disable(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void SetDomain(RulerDomain domain)
        {
            Interop.Ruler.RulerPtr_SetDomain(swigCPtr, RulerDomain.getCPtr(domain));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public RulerDomain GetDomain()
        {
            RulerDomain ret = new RulerDomain(Interop.Ruler.RulerPtr_GetDomain(swigCPtr), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void DisableDomain()
        {
            Interop.Ruler.RulerPtr_DisableDomain(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public float Clamp(float x, float length, float scale)
        {
            float ret = Interop.Ruler.RulerPtr_Clamp__SWIG_0(swigCPtr, x, length, scale);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float Clamp(float x, float length)
        {
            float ret = Interop.Ruler.RulerPtr_Clamp__SWIG_1(swigCPtr, x, length);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float Clamp(float x)
        {
            float ret = Interop.Ruler.RulerPtr_Clamp__SWIG_2(swigCPtr, x);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float Clamp(float x, float length, float scale, SWIGTYPE_p_Dali__Toolkit__ClampState clamped)
        {
            float ret = Interop.Ruler.RulerPtr_Clamp__SWIG_3(swigCPtr, x, length, scale, SWIGTYPE_p_Dali__Toolkit__ClampState.getCPtr(clamped));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float SnapAndClamp(float x, float bias, float length, float scale)
        {
            float ret = Interop.Ruler.RulerPtr_SnapAndClamp__SWIG_0(swigCPtr, x, bias, length, scale);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float SnapAndClamp(float x, float bias, float length)
        {
            float ret = Interop.Ruler.RulerPtr_SnapAndClamp__SWIG_1(swigCPtr, x, bias, length);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float SnapAndClamp(float x, float bias)
        {
            float ret = Interop.Ruler.RulerPtr_SnapAndClamp__SWIG_2(swigCPtr, x, bias);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float SnapAndClamp(float x)
        {
            float ret = Interop.Ruler.RulerPtr_SnapAndClamp__SWIG_3(swigCPtr, x);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float SnapAndClamp(float x, float bias, float length, float scale, SWIGTYPE_p_Dali__Toolkit__ClampState clamped)
        {
            float ret = Interop.Ruler.RulerPtr_SnapAndClamp__SWIG_4(swigCPtr, x, bias, length, scale, SWIGTYPE_p_Dali__Toolkit__ClampState.getCPtr(clamped));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Reference()
        {
            Interop.Ruler.RulerPtr_Reference(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void Unreference()
        {
            Interop.Ruler.RulerPtr_Unreference(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public int ReferenceCount()
        {
            int ret = Interop.Ruler.RulerPtr_ReferenceCount(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
