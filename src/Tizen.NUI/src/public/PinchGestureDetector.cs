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
        public PinchGestureDetector() : this(Interop.PinchGesture.PinchGestureDetector_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="handle">A reference to the copied handle</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PinchGestureDetector(PinchGestureDetector handle) : this(Interop.PinchGesture.new_PinchGestureDetector__SWIG_1(PinchGestureDetector.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PinchGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.PinchGesture.PinchGestureDetector_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        private DaliEventHandler<object, DetectedEventArgs> _detectedEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void DetectedCallbackType(IntPtr actor, IntPtr pinchGesture);
        private DetectedCallbackType _detectedCallback;

        /// <summary>
        /// This signal is emitted when the specified pinch is detected on the attached view.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                if (_detectedEventHandler == null)
                {
                    _detectedCallback = OnPinchGestureDetected;
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


        internal static PinchGestureDetector GetPinchGestureDetectorFromPtr(global::System.IntPtr cPtr)
        {
            PinchGestureDetector ret = new PinchGestureDetector(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal new static PinchGestureDetector DownCast(BaseHandle handle)
        {
            PinchGestureDetector ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as PinchGestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PinchGestureDetector obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal PinchGestureDetector Assign(PinchGestureDetector rhs)
        {
            PinchGestureDetector ret = new PinchGestureDetector(Interop.PinchGesture.PinchGestureDetector_Assign(swigCPtr, PinchGestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PinchGestureDetectedSignal DetectedSignal()
        {
            PinchGestureDetectedSignal ret = new PinchGestureDetectedSignal(Interop.PinchGesture.PinchGestureDetector_DetectedSignal(swigCPtr), false);
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

            Interop.PinchGesture.delete_PinchGestureDetector(swigCPtr);
        }

        private void OnPinchGestureDetected(IntPtr actor, IntPtr pinchGesture)
        {
            DetectedEventArgs e = new DetectedEventArgs();

            // Populate all members of "e" (DetectedEventArgs) with real data.
            e.View = Registry.GetManagedBaseHandleFromNativePtr(actor) as View;
            if (null == e.View)
            {
                e.View = Registry.GetManagedBaseHandleFromRefObject(actor) as View;
            }

            e.PinchGesture = Tizen.NUI.PinchGesture.GetPinchGestureFromPtr(pinchGesture);

            if (_detectedEventHandler != null)
            {
                //Here we send all data to user event handlers.
                _detectedEventHandler(this, e);
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
            private View _view;
            private PinchGesture _pinchGesture;
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
                    return _view;
                }
                set
                {
                    _view = value;
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
                    return _pinchGesture;
                }
                set
                {
                    _pinchGesture = value;
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
