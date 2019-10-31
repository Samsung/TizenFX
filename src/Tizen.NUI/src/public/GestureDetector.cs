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
    /// GestureDetectors analyse a stream of touch events and attempt to determine the intention of the user.<br />
    /// An view is attached to a gesture detector and if the detector recognises a pattern in its analysis, it will
    /// trigger a detected event to the application.<br />
    /// This is the base class for different gesture detectors available and provides functionality that is common to all the gesture detectors.<br />
    /// </summary>
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GestureDetector : BaseHandle
    {

        /// <summary>
        /// Constructor. Creates an uninitialized GestureDetector.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GestureDetector() : this(Interop.GestureDetector.new_GestureDetector__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="handle">A reference to the copied handle</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GestureDetector(GestureDetector handle) : this(Interop.GestureDetector.new_GestureDetector__SWIG_1(GestureDetector.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal GestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.GestureDetector.GestureDetector_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        /// <summary>
        /// Attaches an view to the gesture. The detected event will be triggered when the gesture occurs on the attached view.
        /// </summary>
        /// <param name="view">The view to attach to the gesture detector</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Attach(View view)
        {
            Interop.GestureDetector.GestureDetector_Attach(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Detaches the attached view from the gesture detector.
        /// </summary>
        /// <param name="view">The view to detach from the gesture detector</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Detach(View view)
        {
            Interop.GestureDetector.GestureDetector_Detach(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Detaches all the views that have been attached to the gesture detector.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DetachAll()
        {
            Interop.GestureDetector.GestureDetector_DetachAll(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the number of views attached to the gesture detector.
        /// </summary>
        /// <returns>The count</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetAttachedViewCount()
        {
            uint ret = Interop.GestureDetector.GestureDetector_GetAttachedActorCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns an view by index. An empty handle if the index is not valid.
        /// </summary>
        /// <param name="index">The attached view's index</param>
        /// <returns>The attached view or an empty handle</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetAttachedView(uint index)
        {
            View ret = new View(Interop.GestureDetector.GestureDetector_GetAttachedActor(swigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal GestureDetector Assign(GestureDetector rhs)
        {
            GestureDetector ret = new GestureDetector(Interop.GestureDetector.GestureDetector_Assign(swigCPtr, GestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static GestureDetector DownCast(BaseHandle handle)
        {
            GestureDetector ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as GestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(GestureDetector obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <param name="swigCPtr">The handle save native pointer.</param>
       /// <since_tizen> 6 </since_tizen>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.GestureDetector.delete_GestureDetector(swigCPtr);
        }
    }
}
