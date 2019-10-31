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
    internal class CustomActor : Animatable
    {

        internal CustomActor(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.CustomActorImpl.CustomActor_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CustomActor obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CustomActorImpl.delete_CustomActor(swigCPtr);
        }

        public CustomActor() : this(Interop.CustomActorImpl.new_CustomActor__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static CustomActor DownCast(BaseHandle handle)
        {
            CustomActor ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as CustomActor;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public CustomActorImpl GetImplementation()
        {
            CustomActorImpl ret = new CustomActorImpl(Interop.CustomActorImpl.CustomActor_GetImplementation(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public CustomActor(CustomActorImpl implementation) : this(Interop.CustomActorImpl.new_CustomActor__SWIG_1(CustomActorImpl.getCPtr(implementation)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public CustomActor(CustomActor copy) : this(Interop.CustomActorImpl.new_CustomActor__SWIG_2(CustomActor.getCPtr(copy)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public CustomActor Assign(CustomActor rhs)
        {
            CustomActor ret = new CustomActor(Interop.CustomActorImpl.CustomActor_Assign(swigCPtr, CustomActor.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
