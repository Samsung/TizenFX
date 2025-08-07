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
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// It tries to detect when the user moves two touch points towards or away from each other.
    /// </summary>
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PinchGestureDetector : GestureDetector
    {
        /// <summary>
        /// Creates an initialized PinchGestureDetector.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PinchGestureDetector() : this(Interop.PinchGesture.PinchGestureDetectorNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="handle">A reference to the copied handle</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PinchGestureDetector(PinchGestureDetector handle) : this(Interop.PinchGesture.NewPinchGestureDetector(PinchGestureDetector.getCPtr(handle)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PinchGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal PinchGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        private DaliEventHandler<object, DetectedEventArgs> detectedEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DetectedCallbackType(IntPtr actor, IntPtr pinchGesture);
        private DetectedCallbackType detectedCallback;

        /// <summary>
        /// This signal is emitted when the specified pinch is detected on the attached view.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                if (detectedEventHandler == null)
                {
                    detectedCallback = OnPinchGestureDetected;
                    using var signal = DetectedSignal();
                    signal.Connect(detectedCallback);
                }

                detectedEventHandler += value;
            }

            remove
            {
                detectedEventHandler -= value;
                using var signal = DetectedSignal();
                if (detectedEventHandler == null && signal.Empty() == false)
                {
                    signal.Disconnect(detectedCallback);
                }
            }
        }


        internal static PinchGestureDetector GetPinchGestureDetectorFromPtr(global::System.IntPtr cPtr)
        {
            PinchGestureDetector ret = new PinchGestureDetector(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal new static PinchGestureDetector DownCast(BaseHandle handle)
        {
            PinchGestureDetector ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as PinchGestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PinchGestureDetector Assign(PinchGestureDetector rhs)
        {
            PinchGestureDetector ret = new PinchGestureDetector(Interop.PinchGesture.PinchGestureDetectorAssign(SwigCPtr, PinchGestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PinchGestureDetectedSignal DetectedSignal()
        {
            PinchGestureDetectedSignal ret = new PinchGestureDetectedSignal(Interop.PinchGesture.PinchGestureDetectorDetectedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// override it to clean-up your own resources.
        /// </summary>
        /// <param name="type"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (HasBody())
            {
                if (detectedCallback != null)
                {
                    using PinchGestureDetectedSignal signal = new PinchGestureDetectedSignal(Interop.PinchGesture.PinchGestureDetectorDetectedSignal(GetBaseHandleCPtrHandleRef), false);
                    signal?.Disconnect(detectedCallback);
                    detectedCallback = null;
                }
            }
            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PinchGesture.DeletePinchGestureDetector(swigCPtr);
        }

        private void OnPinchGestureDetected(IntPtr actor, IntPtr pinchGesture)
        {
            if (detectedEventHandler != null)
            {
                DetectedEventArgs e = new DetectedEventArgs();

                // Populate all members of "e" (DetectedEventArgs) with real data.
                e.View = Registry.GetManagedBaseHandleFromNativePtr(actor) as View;
                if (null == e.View)
                {
                    e.View = Registry.GetManagedBaseHandleFromRefObject(actor) as View;
                }

                // If DispatchGestureEvents is false, no gesture events are dispatched.
                if (e.View != null && e.View.DispatchGestureEvents == false)
                {
                    return;
                }

                e.PinchGesture = Tizen.NUI.PinchGesture.GetPinchGestureFromPtr(pinchGesture);
                //Here we send all data to user event handlers.
                detectedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event arguments that passed via the PinchGestureEvent signal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class DetectedEventArgs : EventArgs
        {
            private View view;
            private PinchGesture pinchGesture;
            private bool handled = true;

            /// <summary>
            /// The attached view.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public View View
            {
                get
                {
                    return view;
                }
                set
                {
                    view = value;
                }
            }

            /// <summary>
            /// The PinchGesture.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public PinchGesture PinchGesture
            {
                get
                {
                    return pinchGesture;
                }
                set
                {
                    pinchGesture = value;
                }
            }

            /// <summary>
            /// Gets or sets a value that indicates whether the event handler has completely handled the event or whether the system should continue its own processing.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Handled
            {
                get => handled;
                set
                {
                    handled = value;
                    Interop.Actor.SetNeedGesturePropagation(View.getCPtr(view), !value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }
    }
}
