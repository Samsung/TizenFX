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
    /// This class emits a signals when a long press gesture occurs that meets the requirements set by the application.<br />
    /// For any valid long press, two signals will be emitted:<br />
    /// - First identifying the beginning (state = Started) i.e. when fingers held down for the required time.<br />
    /// - Second identifying the ending (state = Finished) i.e. when fingers are released.<br />
    /// </summary>
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LongPressGestureDetector : GestureDetector
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        private DaliEventHandler<object, DetectedEventArgs> _longPressGestureEventHandler;
        private DetectedCallbackDelegate _longPressGestureCallbackDelegate;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LongPressGestureDetector() : this(Interop.LongPressGestureDetector.LongPressGestureDetector_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an initialized LongPressGestureDetector with the number of touches required.<br />
        /// A long press gesture will be emitted from this detector if the number of fingers touching the screen is equal to the touches required.<br />
        /// </summary>
        /// <param name="touchesRequired">The number of touches required.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LongPressGestureDetector(uint touchesRequired) : this(Interop.LongPressGestureDetector.LongPressGestureDetector_New__SWIG_1(touchesRequired), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an initialized LongPressGestureDetector with the minimum and maximum number of touches required.<br />
        /// A long press gesture will be emitted from this detector if the number of fingers touching the screen falls between the minimum and maximum touches set.<br />
        /// </summary>
        /// <param name="minTouches">The minimum number of touches required.</param>
        /// <param name="maxTouches">The maximum number of touches required.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LongPressGestureDetector(uint minTouches, uint maxTouches) : this(Interop.LongPressGestureDetector.LongPressGestureDetector_New__SWIG_2(minTouches, maxTouches), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="handle">A reference to the copied handle</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LongPressGestureDetector(LongPressGestureDetector handle) : this(Interop.LongPressGestureDetector.new_LongPressGestureDetector__SWIG_1(LongPressGestureDetector.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal LongPressGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.LongPressGestureDetector.LongPressGestureDetector_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void DetectedCallbackDelegate(IntPtr actor, IntPtr longPressGesture);

        /// <summary>
        /// This signal is emitted when the specified long press is detected on the attached view.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener.
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

        /// <summary>
        /// Sets the number of touches required.<br />
        /// The number of touches corresponds to the number of fingers a user has on the screen. The default is 1.<br />
        /// </summary>
        /// <param name="touches">Touches required</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTouchesRequired(uint touches)
        {
            Interop.LongPressGestureDetector.LongPressGestureDetector_SetTouchesRequired__SWIG_0(swigCPtr, touches);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum and maximum touches required.
        /// </summary>
        /// <param name="minTouches">Minimum touches required.</param>
        /// <param name="maxTouches">Maximum touches required.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTouchesRequired(uint minTouches, uint maxTouches)
        {
            Interop.LongPressGestureDetector.LongPressGestureDetector_SetTouchesRequired__SWIG_1(swigCPtr, minTouches, maxTouches);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the minimum number of touches required.
        /// </summary>
        /// <returns>The minimum number of touches required.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetMinimumTouchesRequired()
        {
            uint ret = Interop.LongPressGestureDetector.LongPressGestureDetector_GetMinimumTouchesRequired(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the maximum number of touches required.
        /// </summary>
        /// <returns>The maximum number of touches required.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetMaximumTouchesRequired()
        {
            uint ret = Interop.LongPressGestureDetector.LongPressGestureDetector_GetMaximumTouchesRequired(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static LongPressGestureDetector GetLongPressGestureDetectorFromPtr(global::System.IntPtr cPtr)
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal new static LongPressGestureDetector DownCast(BaseHandle handle)
        {
            LongPressGestureDetector ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as LongPressGestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LongPressGestureDetector Assign(LongPressGestureDetector rhs)
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(Interop.LongPressGestureDetector.LongPressGestureDetector_Assign(swigCPtr, LongPressGestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LongPressGestureDetectedSignal DetectedSignal()
        {
            LongPressGestureDetectedSignal ret = new LongPressGestureDetectedSignal(Interop.LongPressGestureDetector.LongPressGestureDetector_DetectedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LongPressGestureDetector obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">The dispose type</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.LongPressGestureDetector.delete_LongPressGestureDetector(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private void OnLongPressGestureDetected(IntPtr actor, IntPtr longPressGesture)
        {
            DetectedEventArgs e = new DetectedEventArgs();

            // Populate all members of "e" (LongPressGestureEventArgs) with real data.
            e.View = Registry.GetManagedBaseHandleFromNativePtr(actor) as View;
            if (null == e.View)
            {
                e.View = Registry.GetManagedBaseHandleFromRefObject(actor) as View;
            }

            e.LongPressGesture = Tizen.NUI.LongPressGesture.GetLongPressGestureFromPtr(longPressGesture);

            if (_longPressGestureEventHandler != null)
            {
                //Here we send all data to user event handlers.
                _longPressGestureEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event arguments that passed via the LongPressGestureEvent signal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class DetectedEventArgs : EventArgs
        {
            private View _view;
            private LongPressGesture _longPressGesture;

            /// <summary>
            /// View the attached view.
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
            /// The LongPressGesture.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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
    }
}
