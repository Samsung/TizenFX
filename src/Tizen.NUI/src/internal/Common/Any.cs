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
    internal class Any : Disposable
    {
        internal Any(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Any obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Any.DeleteAny(swigCPtr);
        }

        public Any() : this(Interop.Any.NewAny(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static void AssertAlways(string assertMessage)
        {
            Interop.Any.AssertAlways(assertMessage);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Any(Any any) : this(Interop.Any.NewAny(Any.getCPtr(any)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Any Assign(Any any)
        {
            Any ret = new Any(Interop.Any.Assign(SwigCPtr, Any.getCPtr(any)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public new SWIGTYPE_p_std__type_info GetType()
        {
            SWIGTYPE_p_std__type_info ret = new SWIGTYPE_p_std__type_info(Interop.Any.GetType(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool Empty()
        {
            bool ret = Interop.Any.Empty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public class AnyContainerBase : Disposable
        {

            internal AnyContainerBase(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            {
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AnyContainerBase obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
            }

            protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                Interop.Any.DeleteAnyAnyContainerBase(swigCPtr);
            }

            public AnyContainerBase(SWIGTYPE_p_std__type_info type, SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase cloneFunc, SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void deleteFunc) : this(Interop.Any.NewAnyAnyContainerBase(SWIGTYPE_p_std__type_info.getCPtr(type), SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase.getCPtr(cloneFunc), SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void.getCPtr(deleteFunc)), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            public new SWIGTYPE_p_std__type_info GetType()
            {
                SWIGTYPE_p_std__type_info ret = new SWIGTYPE_p_std__type_info(Interop.Any.AnyContainerBaseGetType(SwigCPtr));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            public SWIGTYPE_p_std__type_info mType
            {
                get
                {
                    SWIGTYPE_p_std__type_info ret = new SWIGTYPE_p_std__type_info(Interop.Any.AnyContainerBaseMTypeGet(SwigCPtr));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            public SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase mCloneFunc
            {
                set
                {
                    Interop.Any.AnyContainerBaseMCloneFuncSet(SwigCPtr, SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase.getCPtr(value));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    global::System.IntPtr cPtr = Interop.Any.AnyContainerBaseMCloneFuncGet(SwigCPtr);
                    SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase(cPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            public SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void mDeleteFunc
            {
                set
                {
                    Interop.Any.AnyContainerBaseMDeleteFuncSet(SwigCPtr, SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void.getCPtr(value));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    global::System.IntPtr cPtr = Interop.Any.AnyContainerBaseMDeleteFuncGet(SwigCPtr);
                    SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void(cPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }
        }

        public Any.AnyContainerBase mContainer
        {
            set
            {
                Interop.Any.MContainerSet(SwigCPtr, Any.AnyContainerBase.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.Any.MContainerGet(SwigCPtr);
                Any.AnyContainerBase ret = (cPtr == global::System.IntPtr.Zero) ? null : new Any.AnyContainerBase(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }
}
