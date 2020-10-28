/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
    using System.Runtime.InteropServices;
    using Tizen.NUI.BaseComponents;


    internal class PinchGestureDetector : GestureDetector
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal PinchGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.PinchGestureDetector_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PinchGestureDetector obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }


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


            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_PinchGestureDetector(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        /// <since_tizen> 3 </since_tizen>
        public class DetectedEventArgs : EventArgs
        {
            private View _view;
            private PinchGesture _pinchGesture;

            /// <since_tizen> 3 </since_tizen>
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

            /// <since_tizen> 3 </since_tizen>
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
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void DetectedCallbackDelegate(IntPtr actor, IntPtr pinchGesture);
        private DaliEventHandler<object, DetectedEventArgs> _pinchGestureEventHandler;
        private DetectedCallbackDelegate _pinchGestureCallbackDelegate;


        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_pinchGestureEventHandler == null)
                    {
                        _pinchGestureEventHandler += value;

                        _pinchGestureCallbackDelegate = new DetectedCallbackDelegate(OnPinchGestureDetected);
                        this.DetectedSignal().Connect(_pinchGestureCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_pinchGestureEventHandler != null)
                    {
                        this.DetectedSignal().Disconnect(_pinchGestureCallbackDelegate);
                    }

                    _pinchGestureEventHandler -= value;
                }
            }
        }

        private void OnPinchGestureDetected(IntPtr actor, IntPtr pinchGesture)
        {
            DetectedEventArgs e = new DetectedEventArgs();

            // Populate all members of "e" (DetectedEventArgs) with real data
            e.View = Registry.GetManagedBaseHandleFromNativePtr(actor) as View;
            e.PinchGesture = Tizen.NUI.PinchGesture.GetPinchGestureFromPtr(pinchGesture);

            if (_pinchGestureEventHandler != null)
            {
                //here we send all data to user event handlers
                _pinchGestureEventHandler(this, e);
            }

        }


        public static PinchGestureDetector GetPinchGestureDetectorFromPtr(global::System.IntPtr cPtr)
        {
            PinchGestureDetector ret = new PinchGestureDetector(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        public PinchGestureDetector() : this(NDalicPINVOKE.PinchGestureDetector_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public new static PinchGestureDetector DownCast(BaseHandle handle)
        {
            PinchGestureDetector ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as PinchGestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PinchGestureDetector(PinchGestureDetector handle) : this(NDalicPINVOKE.new_PinchGestureDetector__SWIG_1(PinchGestureDetector.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PinchGestureDetector Assign(PinchGestureDetector rhs)
        {
            PinchGestureDetector ret = new PinchGestureDetector(NDalicPINVOKE.PinchGestureDetector_Assign(swigCPtr, PinchGestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PinchGestureDetectedSignal DetectedSignal()
        {
            PinchGestureDetectedSignal ret = new PinchGestureDetectedSignal(NDalicPINVOKE.PinchGestureDetector_DetectedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
