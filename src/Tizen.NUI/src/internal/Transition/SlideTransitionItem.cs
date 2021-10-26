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

using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// SlideTransitionItem is an object to set slide transition of a View that will appear or disappear.
    /// SlideTransitionItem object is required to be added to the TransitionSet to play.
    /// </summary>
    internal class SlideTransitionItem : TransitionItemBase
    {
        /// <summary>
        /// Creates an initialized SlideTransition.<br />
        /// </summary>
        /// <remarks>Delay and duration of timePeriod must be greater than zero.</remarks>
        public SlideTransitionItem(View view, Vector2 direction, bool appearingTransition, TimePeriod timePeriod, AlphaFunction alphaFunction) : this(Interop.SlideTransitionItem.New(view.SwigCPtr, direction.SwigCPtr, timePeriod.SwigCPtr), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            AppearingTransition = appearingTransition;
            AlphaFunction = alphaFunction;
        }

        internal SlideTransitionItem(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal SlideTransitionItem(SlideTransitionItem handle) : this(Interop.SlideTransitionItem.NewSlideTransitionItem(SlideTransitionItem.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SlideTransitionItem Assign(SlideTransitionItem rhs)
        {
            SlideTransitionItem ret = new SlideTransitionItem(Interop.SlideTransitionItem.Assign(SwigCPtr, SlideTransitionItem.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make SlideTransition instance be disposed.
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
                Tizen.Log.Fatal("NUI", $"[ERROR] SlideTransitionItem ReleaseSwigCPtr()! IntPtr=0x{swigCPtr.Handle:X} HasBody={this.HasBody()}");
                return;
            }
            Interop.SlideTransitionItem.Delete(swigCPtr);
        }
    }
}
