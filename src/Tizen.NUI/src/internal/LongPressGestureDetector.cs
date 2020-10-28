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

    internal class LongPressGestureDetector : GestureDetector
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal LongPressGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.LongPressGestureDetector_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LongPressGestureDetector obj)
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
                    NDalicPINVOKE.delete_LongPressGestureDetector(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        /// <since_tizen> 3 </since_tizen>
        public class DetectedEventArgs : EventArgs
        {
            private View _view;
            private LongPressGesture _longPressGesture;

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
            public LongPressGesture LongPressGesture
            {
                get
                {
                    return _longPressGesture;
                }
                set
                {
                    _longPressGesture = value;
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void DetectedCallbackDelegate(IntPtr actor, IntPtr longPressGesture);
        private DaliEventHandler<object, DetectedEventArgs> _longPressGestureEventHandler;
        private DetectedCallbackDelegate _longPressGestureCallbackDelegate;


        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_longPressGestureEventHandler == null)
                    {
                        _longPressGestureEventHandler += value;

                        _longPressGestureCallbackDelegate = new DetectedCallbackDelegate(OnLongPressGestureDetected);
                        this.DetectedSignal().Connect(_longPressGestureCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_longPressGestureEventHandler != null)
                    {
                        this.DetectedSignal().Disconnect(_longPressGestureCallbackDelegate);
                    }

                    _longPressGestureEventHandler -= value;
                }
            }
        }

        private void OnLongPressGestureDetected(IntPtr actor, IntPtr longPressGesture)
        {
            DetectedEventArgs e = new DetectedEventArgs();

            // Populate all members of "e" (LongPressGestureEventArgs) with real data
            e.View = Registry.GetManagedBaseHandleFromNativePtr(actor) as View;
            e.LongPressGesture = Tizen.NUI.LongPressGesture.GetLongPressGestureFromPtr(longPressGesture);

            if (_longPressGestureEventHandler != null)
            {
                //here we send all data to user event handlers
                _longPressGestureEventHandler(this, e);
            }

        }


        public static LongPressGestureDetector GetLongPressGestureDetectorFromPtr(global::System.IntPtr cPtr)
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        public LongPressGestureDetector() : this(NDalicPINVOKE.LongPressGestureDetector_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public LongPressGestureDetector(uint touchesRequired) : this(NDalicPINVOKE.LongPressGestureDetector_New__SWIG_1(touchesRequired), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public LongPressGestureDetector(uint minTouches, uint maxTouches) : this(NDalicPINVOKE.LongPressGestureDetector_New__SWIG_2(minTouches, maxTouches), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public new static LongPressGestureDetector DownCast(BaseHandle handle)
        {
            LongPressGestureDetector ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as LongPressGestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LongPressGestureDetector(LongPressGestureDetector handle) : this(NDalicPINVOKE.new_LongPressGestureDetector__SWIG_1(LongPressGestureDetector.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LongPressGestureDetector Assign(LongPressGestureDetector rhs)
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(NDalicPINVOKE.LongPressGestureDetector_Assign(swigCPtr, LongPressGestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetTouchesRequired(uint touches)
        {
            NDalicPINVOKE.LongPressGestureDetector_SetTouchesRequired__SWIG_0(swigCPtr, touches);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetTouchesRequired(uint minTouches, uint maxTouches)
        {
            NDalicPINVOKE.LongPressGestureDetector_SetTouchesRequired__SWIG_1(swigCPtr, minTouches, maxTouches);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetMinimumTouchesRequired()
        {
            uint ret = NDalicPINVOKE.LongPressGestureDetector_GetMinimumTouchesRequired(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetMaximumTouchesRequired()
        {
            uint ret = NDalicPINVOKE.LongPressGestureDetector_GetMaximumTouchesRequired(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LongPressGestureDetectedSignal DetectedSignal()
        {
            LongPressGestureDetectedSignal ret = new LongPressGestureDetectedSignal(NDalicPINVOKE.LongPressGestureDetector_DetectedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
