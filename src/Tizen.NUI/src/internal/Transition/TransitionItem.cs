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
    /// TransitionItem is an object to set Transition of View pair those have same TransitionTag.
    /// TransitionItem object is required for each View pair and this is added to the TransitionSet to play.
    /// </summary>
    internal class TransitionItem : TransitionItemBase
    {
        /// <summary>
        /// Creates an initialized transition.<br />
        /// </summary>
        /// <remarks>DurationmSeconds must be greater than zero.</remarks>
        public TransitionItem(View source, View destination, TimePeriod timePeriod, AlphaFunction alphaFunction) : this(Interop.TransitionItem.New(source.SwigCPtr, destination.SwigCPtr, timePeriod.SwigCPtr), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            AlphaFunction = alphaFunction;
        }

        internal TransitionItem(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Sets the source View will be shown after transition finished.
        /// </summary>
        public bool ShowSourceAfterFinished
        {
            set
            {
                Interop.TransitionItem.ShowSourceAfterFinished(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TransitionItem obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal TransitionItem(TransitionItem handle) : this(Interop.TransitionItem.NewTransitionItem(TransitionItem.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TransitionItem Assign(TransitionItem rhs)
        {
            TransitionItem ret = new TransitionItem(Interop.TransitionItem.Assign(SwigCPtr, TransitionItem.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make transition instance be disposed.
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
                Tizen.Log.Fatal("NUI", $"[ERROR] TransitionItem ReleaseSwigCPtr()! IntPtr=0x{swigCPtr.Handle:X} HasBody={this.HasBody()}");
                return;
            }
            Interop.TransitionItem.Delete(swigCPtr);
        }
    }
}
