/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    using Tizen.NUI.BaseComponents;
    /// <summary>
    /// An interface to encapsulate the information required for relayout.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class RelayoutContainer : Disposable
    {

        /// <summary>
        /// Adds relayout information to the container if it doesn't already exist.
        /// </summary>
        /// <param name="view">The view to relayout.</param>
        /// <param name="size">The size to relayout.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void Add(View view, Size2D size)
        {
            Interop.NDalic.RelayoutContainerAdd(SwigCPtr, View.getCPtr(view), Size2D.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RelayoutContainer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal RelayoutContainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.NDalic.DeleteRelayoutContainer(swigCPtr);
        }
    }
}
