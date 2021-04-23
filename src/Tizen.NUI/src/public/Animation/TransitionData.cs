/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    /// <summary>
    /// This object translates data from a property array of maps into an array of animators.
    /// This is normally used when animating visuals.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TransitionData : BaseHandle
    {
        /// <summary>
        /// Create an instance of TransitionData.
        /// </summary>
        /// <param name="transition">The transition data to store (a single animator).</param>
        /// <since_tizen> 3 </since_tizen>
        public TransitionData(PropertyMap transition) : this(Interop.TransitionData.NewByMap(PropertyMap.getCPtr(transition)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an instance of TransitionData.
        /// </summary>
        /// <param name="transition">The transition data to store (an array of maps of animators).</param>
        /// <since_tizen> 3 </since_tizen>
        public TransitionData(PropertyArray transition) : this(Interop.TransitionData.NewByArray(PropertyArray.getCPtr(transition)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Create an instance of TransitionData by copy constructor.
        /// </summary>
        /// <param name="handle">Handle to an object.</param>
        /// <since_tizen> 3 </since_tizen>
        public TransitionData(TransitionData handle) : this(Interop.TransitionData.NewTransitionData(TransitionData.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TransitionData(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// returns the count of the individual property transitions stored within this handle.
        /// </summary>
        /// <returns>A handle to the image at the specified position.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint Count()
        {
            uint ret = Interop.TransitionData.Count(SwigCPtr);
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
            PropertyMap ret = new PropertyMap(Interop.TransitionData.GetAnimatorAt(SwigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TransitionData obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TransitionData.DeleteTransitionData(swigCPtr);
        }
    }
}
