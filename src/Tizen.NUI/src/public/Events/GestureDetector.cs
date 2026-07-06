/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// GestureDetectors analyses a stream of touch events and attempt to determine the intention of the user.<br />
    /// An view is attached to a gesture detector and if the detector recognises a pattern in its analysis, it will
    /// trigger a detected event to the application.<br />
    /// This is the base class for different gesture detectors available and provides functionality that is common to all the gesture detectors.<br />
    /// </summary>
    /// <since_tizen> 10.1 </since_tizen>
    public class GestureDetector : BaseHandle
    {

        /// <summary>
        /// Constructor. Creates an uninitialized GestureDetector.
        /// </summary>
        /// <since_tizen> 10.1 </since_tizen>
        public GestureDetector() : this(Interop.GestureDetector.NewGestureDetector(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The copy Constructor.
        /// </summary>
        /// <param name="handle">A reference to the copied handle</param>
        /// <since_tizen> 10.1 </since_tizen>
        public GestureDetector(GestureDetector handle) : this(Interop.GestureDetector.NewGestureDetector(GestureDetector.getCPtr(handle)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal GestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal GestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        /// <summary>
        /// Attaches the GestureDetector to the view. The detected event will be triggered when the gesture occurs on the attached view.
        /// </summary>
        /// <param name="view">The view the gesture detector will be attached to.</param>
        /// <since_tizen> 10.1 </since_tizen>
        public void Attach(View view)
        {
            Interop.GestureDetector.Attach(SwigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Detaches the GestureDetector from the view.
        /// </summary>
        /// <param name="view">The view to detach the gesture detector from.</param>
        /// <since_tizen> 10.1 </since_tizen>
        public void Detach(View view)
        {
            Interop.GestureDetector.Detach(SwigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Detaches the gesture detector from all the views that have been attached to.
        /// </summary>
        /// <since_tizen> 10.1 </since_tizen>
        public void DetachAll()
        {
            Interop.GestureDetector.DetachAll(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the number of views attached to the gesture detector.
        /// </summary>
        /// <returns>The count</returns>
        /// <since_tizen> 10.1 </since_tizen>
        public uint GetAttachedViewCount()
        {
            uint ret = Interop.GestureDetector.GetAttachedActorCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns an view by index. An empty handle if the index is not valid.
        /// </summary>
        /// <param name="index">The attached view's index</param>
        /// <returns>The attached view or an empty handle</returns>
        /// <since_tizen> 10.1 </since_tizen>
        public View GetAttachedView(uint index)
        {
            View ret = new View(Interop.GestureDetector.GetAttachedActor(SwigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Handles the event for a given view and touch input.
        /// This method should only be called when SetGeometryHittestEnabled is set to true.
        /// It processes the touch input and attempts to recognize gestures based on the provided view and touch data.
        /// </summary>
        /// <param name="view">The view associated with the gesture detector.</param>
        /// <param name="touch">The touch input data to analyze for gestures.</param>
        /// <returns>True if the event was handled successfully, otherwise false.</returns>
        /// <since_tizen> 10.1 </since_tizen>
        public bool HandleEvent(View view, Touch touch)
        {
            bool ret = Interop.GestureDetector.HandleEvent(SwigCPtr, View.getCPtr(view), Touch.getCPtr(touch));
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        /// <summary>
        /// Cancels all other gesture detectors that are currently recognizing gestures by HandleEvent(View view, Touch touch) api
        /// </summary>
        /// <since_tizen> 10.1 </since_tizen>
        public void CancelAllOtherGestureDetectors()
        {
            Interop.GestureDetector.CancelAllOtherGestureDetectors(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal GestureDetector Assign(GestureDetector rhs)
        {
            GestureDetector ret = new GestureDetector(Interop.GestureDetector.Assign(SwigCPtr, GestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static GestureDetector DownCast(BaseHandle handle)
        {
            GestureDetector ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as GestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.GestureDetector.DeleteGestureDetector(swigCPtr);
        }
    }
}
