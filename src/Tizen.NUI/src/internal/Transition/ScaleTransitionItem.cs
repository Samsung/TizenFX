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
    /// ScaleTransitionItem is an object to set scale transition of a View that will appear or disappear.
    /// ScaleTransitionItem object is required to be added to the TransitionSet to play.
    /// </summary>
    internal class ScaleTransitionItem : TransitionItemBase
    {
        /// <summary>
        /// Creates an initialized ScaleTransition.<br />
        /// </summary>
        /// <remarks>Delay and duration of timePeriod must be greater than zero.</remarks>
        public ScaleTransitionItem(View view, float scale, bool appearingTransition, TimePeriod timePeriod, AlphaFunction alphaFunction) : this(Interop.ScaleTransitionItem.New(view.SwigCPtr, scale, timePeriod.SwigCPtr), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            AppearingTransition = appearingTransition;
            AlphaFunction = alphaFunction;
        }

        /// <summary>
        /// Creates an initialized ScaleTransition.<br />
        /// </summary>
        /// <remarks>Delay and duration of timePeriod must be greater than zero.</remarks>
        public ScaleTransitionItem(View view, Vector2 scale, bool appearingTransition, TimePeriod timePeriod, AlphaFunction alphaFunction) : this(Interop.ScaleTransitionItem.New(view.SwigCPtr, scale.SwigCPtr, timePeriod.SwigCPtr), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            AppearingTransition = appearingTransition;
            AlphaFunction = alphaFunction;
        }

        internal ScaleTransitionItem(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal ScaleTransitionItem(ScaleTransitionItem handle) : this(Interop.ScaleTransitionItem.NewScaleTransitionItem(ScaleTransitionItem.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScaleTransitionItem Assign(ScaleTransitionItem rhs)
        {
            ScaleTransitionItem ret = new ScaleTransitionItem(Interop.ScaleTransitionItem.Assign(SwigCPtr, ScaleTransitionItem.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make ScaleTransition instance be disposed.
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
                Tizen.Log.Fatal("NUI", $"[ERROR] ScaleTransitionItem ReleaseSwigCPtr()! IntPtr=0x{swigCPtr.Handle:X} HasBody={this.HasBody()}");
                return;
            }
            Interop.ScaleTransitionItem.Delete(swigCPtr);
        }
    }
}
