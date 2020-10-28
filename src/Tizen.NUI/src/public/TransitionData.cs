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
    /// This object translates data from a property array of maps into an array of animators.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TransitionData : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal TransitionData(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.TransitionData_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TransitionData obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">The dispose type</param>
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
                    NDalicPINVOKE.delete_TransitionData(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Create an instance of TransitionData.
        /// </summary>
        /// <param name="transition">The transition data to store (a single animator).</param>
        /// <since_tizen> 3 </since_tizen>
        public TransitionData(PropertyMap transition) : this(NDalicPINVOKE.TransitionData_New__SWIG_0(PropertyMap.getCPtr(transition)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Create an instance of TransitionData.
        /// </summary>
        /// <param name="transition">The transition data to store (an array of maps of animators).</param>
        /// <since_tizen> 3 </since_tizen>
        public TransitionData(PropertyArray transition) : this(NDalicPINVOKE.TransitionData_New__SWIG_1(PropertyArray.getCPtr(transition)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Create an instance of TransitionData by copy constructor.
        /// </summary>
        /// <param name="handle">Handle to an object.</param>
        /// <since_tizen> 3 </since_tizen>
        public TransitionData(TransitionData handle) : this(NDalicPINVOKE.new_TransitionData__SWIG_1(TransitionData.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// returns the count of the individual property transitions stored within this handle.
        /// </summary>
        /// <returns>A handle to the image at the the specified position.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint Count()
        {
            uint ret = NDalicPINVOKE.TransitionData_Count(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// returns the count of the individual property transitions stored within this handle.
        /// </summary>
        /// <param name="index">The index of the animator.</param>
        /// <returns>A property map representing the animator.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap GetAnimatorAt(uint index)
        {
            PropertyMap ret = new PropertyMap(NDalicPINVOKE.TransitionData_GetAnimatorAt(swigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TransitionData(SWIGTYPE_p_Dali__Toolkit__Internal__TransitionData impl) : this(NDalicPINVOKE.new_TransitionData__SWIG_2(SWIGTYPE_p_Dali__Toolkit__Internal__TransitionData.getCPtr(impl)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

    }

}