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
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        private DaliEventHandler<object, DetectedEventArgs> _rotationGestureEventHandler;
        private DetectedCallbackDelegate _rotationGestureCallbackDelegate;


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
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void DetectedCallbackDelegate(IntPtr actor, IntPtr rotationGesture);

        /// <summary>
        /// This signal is emitted when the specified rotation is detected on the attached view.
        /// </summary>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_rotationGestureEventHandler == null)
                    {
                        _rotationGestureEventHandler += value;

                        _rotationGestureCallbackDelegate = new DetectedCallbackDelegate(OnRotationGestureDetected);
                        this.DetectedSignal().Connect(_rotationGestureCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_rotationGestureEventHandler != null)
                    {
                        this.DetectedSignal().Disconnect(_rotationGestureCallbackDelegate);
                    }

                    _rotationGestureEventHandler -= value;
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

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">The dispose type</param>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
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
            //Because the execution order of Finalizes is non-deterministic.


            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.RotationGesture.delete_RotationGestureDetector(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
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

            if (_rotationGestureEventHandler != null)
            {
                //Here we send all data to user event handlers.
                _rotationGestureEventHandler(this, e);
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
        }

    }

}
