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
    internal class TypeRegistration : Disposable
    {
        internal TypeRegistration(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TypeRegistration obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TypeRegistration.DeleteTypeRegistration(swigCPtr);
        }

        static private global::System.IntPtr SwigConstructTypeRegistration(SWIGTYPE_p_std__type_info registerType, SWIGTYPE_p_std__type_info baseType, System.Delegate f)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(f);
            return Interop.TypeRegistration.NewTypeRegistration(SWIGTYPE_p_std__type_info.getCPtr(registerType), SWIGTYPE_p_std__type_info.getCPtr(baseType), new System.Runtime.InteropServices.HandleRef(null, ip));
        }

        internal TypeRegistration(SWIGTYPE_p_std__type_info registerType, SWIGTYPE_p_std__type_info baseType, System.Delegate f) : this(TypeRegistration.SwigConstructTypeRegistration(registerType, baseType, f), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        static private global::System.IntPtr SwigConstructTypeRegistration(SWIGTYPE_p_std__type_info registerType, SWIGTYPE_p_std__type_info baseType, System.Delegate f, bool callCreateOnInit)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(f);
            return Interop.TypeRegistration.NewTypeRegistration(SWIGTYPE_p_std__type_info.getCPtr(registerType), SWIGTYPE_p_std__type_info.getCPtr(baseType), new System.Runtime.InteropServices.HandleRef(null, ip), callCreateOnInit);
        }

        internal TypeRegistration(SWIGTYPE_p_std__type_info registerType, SWIGTYPE_p_std__type_info baseType, System.Delegate f, bool callCreateOnInit) : this(TypeRegistration.SwigConstructTypeRegistration(registerType, baseType, f, callCreateOnInit), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        static private global::System.IntPtr SwigConstructTypeRegistration(string name, SWIGTYPE_p_std__type_info baseType, System.Delegate f)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(f);
            return Interop.TypeRegistration.NewTypeRegistration(name, SWIGTYPE_p_std__type_info.getCPtr(baseType), new System.Runtime.InteropServices.HandleRef(null, ip));
        }

        internal TypeRegistration(string name, SWIGTYPE_p_std__type_info baseType, System.Delegate f) : this(TypeRegistration.SwigConstructTypeRegistration(name, baseType, f), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public string RegisteredName()
        {
            string ret = Interop.TypeRegistration.RegisteredName(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static void RegisterControl(string controlName, System.Delegate createFunc)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(createFunc);
            {
                Interop.TypeRegistration.RegisterControl(controlName, new System.Runtime.InteropServices.HandleRef(null, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static void RegisterProperty(string controlName, string propertyName, int index, PropertyType type, System.Delegate setFunc, System.Delegate getFunc)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(setFunc);
            System.IntPtr ip2 = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(getFunc);
            {
                Interop.TypeRegistration.RegisterProperty(controlName, propertyName, index, (int)type, new System.Runtime.InteropServices.HandleRef(null, ip), new System.Runtime.InteropServices.HandleRef(null, ip2));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
    }
}
