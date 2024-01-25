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

namespace Tizen.NUI
{
    internal class TypeAction : Disposable
    {
        internal TypeAction(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.NDalic.DeleteTypeAction(swigCPtr);
        }

        internal TypeAction(TypeRegistration registered, string name, SWIGTYPE_p_f_p_Dali__BaseObject_r_q_const__std__string_r_q_const__Dali__Property__Map__bool f) : this(Interop.NDalic.NewTypeAction(TypeRegistration.getCPtr(registered), name, SWIGTYPE_p_f_p_Dali__BaseObject_r_q_const__std__string_r_q_const__Dali__Property__Map__bool.getCPtr(f)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
