/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    /// An angle in degrees.<br />
    /// This reduces ambiguity when using methods which accept angles in degrees or radians.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Degree : Disposable
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Degree() : this(Interop.Degree.new_Degree__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an angle in degrees.
        /// </summary>
        /// <param name="value">The initial value in degrees.</param>
        /// <since_tizen> 3 </since_tizen>
        public Degree(float value) : this(Interop.Degree.new_Degree__SWIG_1(value), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an angle in degrees from a radian.
        /// </summary>
        /// <param name="value">The initial value in radians.</param>
        /// <since_tizen> 3 </since_tizen>
        public Degree(Radian value) : this(Interop.Degree.new_Degree__SWIG_2(Radian.getCPtr(value)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Degree(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The value of degree.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Value
        {
            set
            {
                Interop.Degree.Degree_degree_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Degree.Degree_degree_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Degree obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Degree.delete_Degree(swigCPtr);
        }
    }
}