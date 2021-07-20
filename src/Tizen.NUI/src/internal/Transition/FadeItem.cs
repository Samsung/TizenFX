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
    using System;
    using System.ComponentModel;

    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// FadeItem is an object to set Fade transition of a View that will appear or disappear.
    /// FadeItem object is required to be added to the TransitionSet to play.
    /// </summary>
    internal class FadeItem : TransitionItemBase
    {
        /// <summary>
        /// Creates an initialized fade.<br />
        /// </summary>
        /// <remarks>DurationmSeconds must be greater than zero.</remarks>
        public FadeItem(View view, float opacity, bool isAppearing, TimePeriod timePeriod, AlphaFunction alphaFunction) : this(Interop.FadeItem.New(view.SwigCPtr, opacity, timePeriod.SwigCPtr), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            AppearingTransition = isAppearing;
            AlphaFunction = alphaFunction;
        }

        internal FadeItem(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FadeItem obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal FadeItem(FadeItem handle) : this(Interop.FadeItem.NewFadeItem(FadeItem.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FadeItem Assign(FadeItem rhs)
        {
            FadeItem ret = new FadeItem(Interop.FadeItem.Assign(SwigCPtr, FadeItem.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make fade instance be disposed.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }
            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            if (swigCPtr.Handle == IntPtr.Zero || this.HasBody() == false)
            {
                Tizen.Log.Fatal("NUI", $"[ERROR] FadeItem ReleaseSwigCPtr()! IntPtr=0x{swigCPtr.Handle:X} HasBody={this.HasBody()}");
                return;
            }
            Interop.FadeItem.Delete(swigCPtr);
        }
    }
}
