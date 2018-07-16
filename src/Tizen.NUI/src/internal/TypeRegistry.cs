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

    internal class TypeRegistry : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal TypeRegistry(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.TypeRegistry_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TypeRegistry obj)
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
                    NDalicPINVOKE.delete_TypeRegistry(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        public static TypeRegistry Get()
        {
            TypeRegistry ret = new TypeRegistry(NDalicPINVOKE.TypeRegistry_Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public TypeRegistry() : this(NDalicPINVOKE.new_TypeRegistry__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public TypeRegistry(TypeRegistry handle) : this(NDalicPINVOKE.new_TypeRegistry__SWIG_1(TypeRegistry.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public TypeRegistry Assign(TypeRegistry rhs)
        {
            TypeRegistry ret = new TypeRegistry(NDalicPINVOKE.TypeRegistry_Assign(swigCPtr, TypeRegistry.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Tizen.NUI.TypeInfo GetTypeInfo(string uniqueTypeName)
        {
            Tizen.NUI.TypeInfo ret = new Tizen.NUI.TypeInfo(NDalicPINVOKE.TypeRegistry_GetTypeInfo__SWIG_0(swigCPtr, uniqueTypeName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Tizen.NUI.TypeInfo GetTypeInfo(SWIGTYPE_p_std__type_info registerType)
        {
            Tizen.NUI.TypeInfo ret = new Tizen.NUI.TypeInfo(NDalicPINVOKE.TypeRegistry_GetTypeInfo__SWIG_1(swigCPtr, SWIGTYPE_p_std__type_info.getCPtr(registerType)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetTypeNameCount()
        {
            uint ret = NDalicPINVOKE.TypeRegistry_GetTypeNameCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetTypeName(uint index)
        {
            string ret = NDalicPINVOKE.TypeRegistry_GetTypeName(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TypeRegistry(SWIGTYPE_p_Dali__Internal__TypeRegistry typeRegistry) : this(NDalicPINVOKE.new_TypeRegistry__SWIG_2(SWIGTYPE_p_Dali__Internal__TypeRegistry.getCPtr(typeRegistry)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

    }

}
