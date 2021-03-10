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

        internal PageTurnPortraitView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PageTurnPortraitView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PageTurnPortraitView.DeletePageTurnPortraitView(swigCPtr);
        }

        public PageTurnPortraitView(PageFactory pageFactory, Vector2 pageSize) : this(Interop.PageTurnPortraitView.New(PageFactory.getCPtr(pageFactory), Vector2.getCPtr(pageSize)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PageTurnPortraitView(PageTurnPortraitView pageTurnPortraitView) : this(Interop.PageTurnPortraitView.NewPageTurnPortraitView(PageTurnPortraitView.getCPtr(pageTurnPortraitView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PageTurnPortraitView Assign(PageTurnPortraitView pageTurnPortraitView)
        {
            PageTurnPortraitView ret = new PageTurnPortraitView(Interop.PageTurnPortraitView.Assign(SwigCPtr, PageTurnPortraitView.getCPtr(pageTurnPortraitView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public new static PageTurnPortraitView DownCast(BaseHandle handle)
        {
            PageTurnPortraitView ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as PageTurnPortraitView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
