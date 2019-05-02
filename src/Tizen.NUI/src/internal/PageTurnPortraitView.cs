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

    internal class PageTurnPortraitView : PageTurnView
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal PageTurnPortraitView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.PageTurnPortraitView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PageTurnPortraitView obj)
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
                    NDalicPINVOKE.delete_PageTurnPortraitView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        public PageTurnPortraitView(PageFactory pageFactory, Vector2 pageSize) : this(NDalicPINVOKE.PageTurnPortraitView_New(PageFactory.getCPtr(pageFactory), Vector2.getCPtr(pageSize)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public PageTurnPortraitView(PageTurnPortraitView pageTurnPortraitView) : this(NDalicPINVOKE.new_PageTurnPortraitView__SWIG_1(PageTurnPortraitView.getCPtr(pageTurnPortraitView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PageTurnPortraitView Assign(PageTurnPortraitView pageTurnPortraitView)
        {
            PageTurnPortraitView ret = new PageTurnPortraitView(NDalicPINVOKE.PageTurnPortraitView_Assign(swigCPtr, PageTurnPortraitView.getCPtr(pageTurnPortraitView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public new static PageTurnPortraitView DownCast(BaseHandle handle)
        {
            PageTurnPortraitView ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as PageTurnPortraitView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
