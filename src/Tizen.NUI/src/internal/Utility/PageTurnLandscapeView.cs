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

        internal PageTurnLandscapeView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.PageTurnLandScapeView.PageTurnLandscapeViewUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PageTurnLandscapeView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PageTurnLandScapeView.DeletePageTurnLandscapeView(swigCPtr);
        }

        public PageTurnLandscapeView(PageFactory pageFactory, Vector2 pageSize) : this(Interop.PageTurnLandScapeView.PageTurnLandscapeViewNew(PageFactory.getCPtr(pageFactory), Vector2.getCPtr(pageSize)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public PageTurnLandscapeView(PageTurnLandscapeView pageTurnLandscapeView) : this(Interop.PageTurnLandScapeView.NewPageTurnLandscapeView(PageTurnLandscapeView.getCPtr(pageTurnLandscapeView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PageTurnLandscapeView Assign(PageTurnLandscapeView pageTurnLandscapeView)
        {
            PageTurnLandscapeView ret = new PageTurnLandscapeView(Interop.PageTurnLandScapeView.PageTurnLandscapeViewAssign(SwigCPtr, PageTurnLandscapeView.getCPtr(pageTurnLandscapeView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public new static PageTurnLandscapeView DownCast(BaseHandle handle)
        {
            PageTurnLandscapeView ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as PageTurnLandscapeView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
