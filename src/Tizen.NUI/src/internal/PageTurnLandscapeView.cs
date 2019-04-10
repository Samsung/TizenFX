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

    internal class PageTurnLandscapeView : PageTurnView
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal PageTurnLandscapeView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.PageTurnLandScapeView.PageTurnLandscapeView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PageTurnLandscapeView obj)
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
                    Interop.PageTurnLandScapeView.delete_PageTurnLandscapeView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        public PageTurnLandscapeView(PageFactory pageFactory, Vector2 pageSize) : this(Interop.PageTurnLandScapeView.PageTurnLandscapeView_New(PageFactory.getCPtr(pageFactory), Vector2.getCPtr(pageSize)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();

        }
        public PageTurnLandscapeView(PageTurnLandscapeView pageTurnLandscapeView) : this(Interop.PageTurnLandScapeView.new_PageTurnLandscapeView__SWIG_1(PageTurnLandscapeView.getCPtr(pageTurnLandscapeView)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public PageTurnLandscapeView Assign(PageTurnLandscapeView pageTurnLandscapeView)
        {
            PageTurnLandscapeView ret = new PageTurnLandscapeView(Interop.PageTurnLandScapeView.PageTurnLandscapeView_Assign(swigCPtr, PageTurnLandscapeView.getCPtr(pageTurnLandscapeView)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public new static PageTurnLandscapeView DownCast(BaseHandle handle)
        {
            PageTurnLandscapeView ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as PageTurnLandscapeView;
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
