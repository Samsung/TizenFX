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
    public class LayoutItemWrapper : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        internal LayoutItemWrapperImpl layoutItemWrapperImpl;

        internal LayoutItemWrapper(global::System.IntPtr cPtr, bool cMemoryOwn) : base(LayoutPINVOKE.LayoutItemWrapper_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutItemWrapper obj)
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
                    LayoutPINVOKE.delete_LayoutItemWrapper(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose();
        }

        public class ChildProperty
        {
            public static readonly int WIDTH_SPECIFICATION = LayoutPINVOKE.LayoutItemWrapper_ChildProperty_WIDTH_SPECIFICATION_get();
            public static readonly int HEIGHT_SPECIFICATION = LayoutPINVOKE.LayoutItemWrapper_ChildProperty_HEIGHT_SPECIFICATION_get();

        }

        /*public LayoutItemWrapper (Handle handle) : this (LayoutPINVOKE.LayoutItemWrapper_New(Handle.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }*/

        public View GetOwner()
        {
            global::System.IntPtr cPtr = LayoutPINVOKE.LayoutItemWrapper_GetOwner(swigCPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as View;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void SetAnimateLayout(bool animateLayout)
        {
            LayoutPINVOKE.LayoutItemWrapper_SetAnimateLayout(swigCPtr, animateLayout);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private bool IsLayoutAnimated()
        {
            bool ret = LayoutPINVOKE.LayoutItemWrapper_IsLayoutAnimated(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool LayoutAnimate
        {
            get
            {
                return IsLayoutAnimated();
            }
            set
            {
                SetAnimateLayout( value );
            }
        }

        internal LayoutItemWrapper(LayoutItemWrapperImpl implementation) : this(LayoutPINVOKE.new_LayoutItemWrapper__SWIG_2(LayoutItemWrapperImpl.getCPtr(implementation)), true)
        {
            layoutItemWrapperImpl = implementation;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }


    public interface ILayoutParent
    {
        ILayoutParent GetParent();
        /*{
            global::System.IntPtr cPtr = LayoutPINVOKE.LayoutParent_GetParent(swigCPtr);
            LayoutParent ret = (cPtr == global::System.IntPtr.Zero) ? null : new LayoutParent(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }*/
    }
}