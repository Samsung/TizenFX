/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public class LayoutGroupWrapper : LayoutItem//LayoutItemWrapper
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        internal LayoutGroupWrapperImpl layoutGroupWrapperImpl;

        internal LayoutGroupWrapper(global::System.IntPtr cPtr, bool cMemoryOwn) : base(LayoutPINVOKE.LayoutGroupWrapper_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutGroupWrapper obj)
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
                    LayoutPINVOKE.delete_LayoutGroupWrapper(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose();
        }

        public class ChildProperty
        {
            public static readonly int MARGIN_SPECIFICATION = LayoutPINVOKE.LayoutGroupWrapper_ChildProperty_MARGIN_SPECIFICATION_get();
        }

        public LayoutGroupWrapper() : this(LayoutPINVOKE.new_LayoutGroupWrapper__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutGroupWrapper(LayoutGroupWrapper copy) : this(LayoutPINVOKE.new_LayoutGroupWrapper__SWIG_1(LayoutGroupWrapper.getCPtr(copy)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint Add(LayoutItemWrapper childLayout)
        {
            uint ret = LayoutPINVOKE.LayoutGroupWrapper_Add(swigCPtr, LayoutItemWrapper.getCPtr(childLayout));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Remove(uint childId)
        {
            LayoutPINVOKE.LayoutGroupWrapper_Remove__SWIG_0(swigCPtr, childId);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Remove(LayoutItemWrapper childLayout)
        {
            LayoutPINVOKE.LayoutGroupWrapper_Remove__SWIG_1(swigCPtr, LayoutItemWrapper.getCPtr(childLayout));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutItem GetChildAt(uint index)
        {
            global::System.IntPtr cPtr = LayoutPINVOKE.LayoutGroupWrapper_GetChildAt(swigCPtr, index);


            global::System.Runtime.InteropServices.HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            BaseHandle basehandle = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle);
            NDalicPINVOKE.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return basehandle as LayoutItem;
        }

        private uint GetChildCount()
        {
            uint ret = LayoutPINVOKE.LayoutGroupWrapper_GetChildCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint ChildCount
        {
            get
            {
                return GetChildCount();
            }
        }

        public LayoutItemWrapper GetChild(uint childId)
        {
            LayoutItemWrapper ret = new LayoutItemWrapper(LayoutPINVOKE.LayoutGroupWrapper_GetChild(swigCPtr, childId), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LayoutGroupWrapper(LayoutGroupWrapperImpl implementation) : this(LayoutPINVOKE.new_LayoutGroupWrapper__SWIG_2(LayoutGroupWrapperImpl.getCPtr(implementation)), true)
        {
            layoutGroupWrapperImpl = implementation;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static readonly uint UNKNOWN_ID = LayoutPINVOKE.LayoutGroupWrapper_UNKNOWN_ID_get();
    }
}