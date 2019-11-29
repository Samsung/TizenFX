/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// ViewWrapper.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ViewWrapper : View
    {
        internal ViewWrapperImpl viewWrapperImpl;

        internal ViewWrapper(global::System.IntPtr cPtr, bool cMemoryOwn, ViewStyle viewStyle) : base(Interop.ViewWrapper.ViewWrapper_SWIGUpcast(cPtr), cMemoryOwn, viewStyle)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal ViewWrapper(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ViewWrapper.ViewWrapper_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal ViewWrapper(string typeName, ViewWrapperImpl implementation, ViewStyle viewStyle) : this(Interop.ViewWrapper.ViewWrapper_New(typeName, ViewWrapperImpl.getCPtr(implementation)), true, viewStyle)
        {
            viewWrapperImpl = implementation;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ViewWrapper(string typeName, ViewWrapperImpl implementation) : this(Interop.ViewWrapper.ViewWrapper_New(typeName, ViewWrapperImpl.getCPtr(implementation)), true)
        {
            viewWrapperImpl = implementation;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ViewWrapper.delete_ViewWrapper(swigCPtr);
        }
    }
}