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
    /// An angle in radians.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Radian : Disposable
    {

        /// <summary>
        /// The default constructor, initializes to 0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Radian() : this(Interop.Radian.new_Radian__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an angle in radians.
        /// </summary>
        /// <param name="value">The initial value in radians.</param>
        /// <since_tizen> 3 </since_tizen>
        public Radian(float value) : this(Interop.Radian.new_Radian__SWIG_1(value), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an angle in radians from an angle in degrees.
        /// </summary>
        /// <param name="degree">The initial value in degrees.</param>
        /// <since_tizen> 3 </since_tizen>
        public Radian(Degree degree) : this(Interop.Radian.new_Radian__SWIG_2(Degree.getCPtr(degree)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Radian(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The value in radians.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Value
        {
            set
            {
                Interop.Radian.Radian_radian_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Radian.Radian_radian_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Conversion to float.
        /// </summary>
        /// <returns>The float value of this radian.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float ConvertToFloat()
        {
            float ret = Interop.Radian.Radian_ConvertToFloat(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Radian obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Radian.delete_Radian(swigCPtr);
        }
    }
}