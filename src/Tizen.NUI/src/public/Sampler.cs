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
    /// <summary>
    /// Sampler is a handle to an object that can be used to provide the sampling parameters to sample textures.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Sampler : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// Create an instance of Sampler.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Sampler() : this(Interop.Sampler.Sampler_New(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Sets the filter modes for this sampler.
        /// </summary>
        /// <param name="minFilter">The minification filter that will be used.</param>
        /// <param name="magFilter">The magnification filter that will be used.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFilterMode(FilterModeType minFilter, FilterModeType magFilter)
        {
            Interop.Sampler.Sampler_SetFilterMode(swigCPtr, (int)minFilter, (int)magFilter);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the wrap modes for this sampler.
        /// </summary>
        /// <param name="uWrap">Wrap mode for u coordinates.</param>
        /// <param name="vWrap">Wrap mode for v coordinates.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetWrapMode(WrapModeType uWrap, WrapModeType vWrap)
        {
            Interop.Sampler.Sampler_SetWrapMode__SWIG_0(swigCPtr, (int)uWrap, (int)vWrap);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the wrap modes for this sampler.
        /// </summary>
        /// <param name="rWrap">Wrap mode for the x direction.</param>
        /// <param name="sWrap">Wrap mode for the y direction.</param>
        /// <param name="tWrap">Wrap mode for the z direction.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetWrapMode(WrapModeType rWrap, WrapModeType sWrap, WrapModeType tWrap)
        {
            Interop.Sampler.Sampler_SetWrapMode__SWIG_1(swigCPtr, (int)rWrap, (int)sWrap, (int)tWrap);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Sampler obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal Sampler(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Sampler.Sampler_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                    Interop.Sampler.delete_Sampler(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }
    }
}