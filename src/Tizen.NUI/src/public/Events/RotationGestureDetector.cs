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
    /// It tries to detect when the user moves two touch points in a circular motion.
    /// </summary>
    /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RotationGestureDetector : GestureDetector
    {
        /// <summary>
        /// Creates an initialized RotationGestureDetector.
        /// </summary>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RotationGestureDetector() : this(Interop.RotationGesture.RotationGestureDetectorNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="handle">A reference to the copied handle</param>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RotationGestureDetector(RotationGestureDetector handle) : this(Interop.RotationGesture.NewRotationGestureDetector(RotationGestureDetector.getCPtr(handle)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal RotationGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal RotationGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        private DaliEventHandler<object, DetectedEventArgs> detectedEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DetectedCallbackType(IntPtr actor, IntPtr rotationGesture);
        private DetectedCallbackType detectedCallback;

        /// <summary>
        /// This signal is emitted when the specified rotation is detected on the attached view.
        /// </summary>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                if (detectedEventHandler == null)
                {
                    detectedCallback = OnRotationGestureDetected;
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


        internal static RotationGestureDetector GetRotationGestureDetectorFromPtr(global::System.IntPtr cPtr)
        {
            RotationGestureDetector ret = new RotationGestureDetector(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal new static RotationGestureDetector DownCast(BaseHandle handle)
        {
            RotationGestureDetector ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as RotationGestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RotationGestureDetector Assign(RotationGestureDetector rhs)
        {
            RotationGestureDetector ret = new RotationGestureDetector(Interop.RotationGesture.RotationGestureDetectorAssign(SwigCPtr, RotationGestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RotationGestureDetectedSignal DetectedSignal()
        {
            RotationGestureDetectedSignal ret = new RotationGestureDetectedSignal(Interop.RotationGesture.RotationGestureDetectorDetectedSignal(SwigCPtr), false);
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
                    using RotationGestureDetectedSignal signal = new RotationGestureDetectedSignal(Interop.RotationGesture.RotationGestureDetectorDetectedSignal(GetBaseHandleCPtrHandleRef), false);
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
            Interop.RotationGesture.DeleteRotationGestureDetector(swigCPtr);
        }

        private void OnRotationGestureDetected(IntPtr actor, IntPtr rotationGesture)
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

                e.RotationGesture = Tizen.NUI.RotationGesture.GetRotationGestureFromPtr(rotationGesture);
                //Here we send all data to user event handlers.
                detectedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event arguments that passed via the RotationGestureEvent signal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class DetectedEventArgs : EventArgs
        {
            private View view;
            private RotationGesture rotationGesture;
            private bool handled = true;

            /// <summary>
            /// The attached view.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
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
            /// The RotationGesture.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public RotationGesture RotationGesture
            {
                get
                {
                    return rotationGesture;
                }
                set
                {
                    rotationGesture = value;
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
