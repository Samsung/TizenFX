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
        public RotationGestureDetector() : this(Interop.RotationGesture.RotationGestureDetector_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="handle">A reference to the copied handle</param>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RotationGestureDetector(RotationGestureDetector handle) : this(Interop.RotationGesture.new_RotationGestureDetector__SWIG_1(RotationGestureDetector.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal RotationGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.RotationGesture.RotationGestureDetector_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        private DaliEventHandler<object, DetectedEventArgs> _detectedEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void DetectedCallbackType(IntPtr actor, IntPtr rotationGesture);
        private DetectedCallbackType _detectedCallback;

        /// <summary>
        /// This signal is emitted when the specified rotation is detected on the attached view.
        /// </summary>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                if (_detectedEventHandler == null)
                {
                    _detectedCallback = OnRotationGestureDetected;
                    DetectedSignal().Connect(_detectedCallback);
                }

                _detectedEventHandler += value;
            }

            remove
            {
                _detectedEventHandler -= value;

                if (_detectedEventHandler == null && DetectedSignal().Empty() == false)
                {
                    DetectedSignal().Disconnect(_detectedCallback);
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
            RotationGestureDetector ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as RotationGestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RotationGestureDetector obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal RotationGestureDetector Assign(RotationGestureDetector rhs)
        {
            RotationGestureDetector ret = new RotationGestureDetector(Interop.RotationGesture.RotationGestureDetector_Assign(swigCPtr, RotationGestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RotationGestureDetectedSignal DetectedSignal()
        {
            RotationGestureDetectedSignal ret = new RotationGestureDetectedSignal(Interop.RotationGesture.RotationGestureDetector_DetectedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            if (_detectedCallback != null)
            {
                DetectedSignal().Disconnect(_detectedCallback);
            }

            Interop.RotationGesture.delete_RotationGestureDetector(swigCPtr);
        }

        private void OnRotationGestureDetected(IntPtr actor, IntPtr rotationGesture)
        {
            DetectedEventArgs e = new DetectedEventArgs();

            // Populate all members of "e" (DetectedEventArgs) with real data.
            e.View = Registry.GetManagedBaseHandleFromNativePtr(actor) as View;
            if (null == e.View)
            {
                e.View = Registry.GetManagedBaseHandleFromRefObject(actor) as View;
            }

            e.RotationGesture = Tizen.NUI.RotationGesture.GetRotationGestureFromPtr(rotationGesture);

            if (_detectedEventHandler != null)
            {
                //Here we send all data to user event handlers.
                _detectedEventHandler(this, e);
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
            private View _view;
            private RotationGesture _rotationGesture;
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
                    return _view;
                }
                set
                {
                    _view = value;
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
                    return _rotationGesture;
                }
                set
                {
                    _rotationGesture = value;
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
                    Interop.Actor.SetNeedGesturePropagation(View.getCPtr(_view), !value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

    }

}
