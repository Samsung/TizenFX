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
using System;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// This class emits a signal when a tap gesture occurs that meets the requirements set by the application.<br />
    /// A TapGesture is a discrete gesture, which means it does not have any state information attached.<br />
    /// </summary>
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TapGestureDetector : GestureDetector
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private DaliEventHandler<object, DetectedEventArgs> _tapGestureEventHandler;
        private DetectedCallbackDelegate _tapGestureCallbackDelegate;

        /// <summary>
        /// Creates an initialized TapGestureDetector.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TapGestureDetector() : this(NDalicPINVOKE.TapGestureDetector_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Creates an initialized TapGestureDetector with the specified parameters.
        /// </summary>
        /// <param name="tapsRequired">The minimum and maximum number of taps required</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TapGestureDetector(uint tapsRequired) : this(NDalicPINVOKE.TapGestureDetector_New__SWIG_1(tapsRequired), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal TapGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.TapGestureDetector_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void DetectedCallbackDelegate(IntPtr actor, IntPtr TapGesture);

        /// <summary>
        /// This signal is emitted when the specified tap is detected on the attached view.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_tapGestureEventHandler == null)
                    {
                        _tapGestureEventHandler += value;

                        _tapGestureCallbackDelegate = new DetectedCallbackDelegate(OnTapGestureDetected);
                        this.DetectedSignal().Connect(_tapGestureCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_tapGestureEventHandler != null)
                    {
                        this.DetectedSignal().Disconnect(_tapGestureCallbackDelegate);
                    }

                    _tapGestureEventHandler -= value;
                }
            }
        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="handle">A reference to the copied handle</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TapGestureDetector(TapGestureDetector handle) : this(NDalicPINVOKE.new_TapGestureDetector__SWIG_1(TapGestureDetector.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum number of taps required. The tap count is the number of times a user should "tap" the screen.<br />
        /// The default is 1.<br />
        /// </summary>
        /// <param name="minimumTaps">The minimum taps required</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumTapsRequired(uint minimumTaps)
        {
            NDalicPINVOKE.TapGestureDetector_SetMinimumTapsRequired(swigCPtr, minimumTaps);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the maximum number of taps required. The tap count is the number of times a user should "tap" the screen.<br />
        /// The default is 1.<br />
        /// </summary>
        /// <param name="maximumTaps">The maximum taps required</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMaximumTapsRequired(uint maximumTaps)
        {
            NDalicPINVOKE.TapGestureDetector_SetMaximumTapsRequired(swigCPtr, maximumTaps);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the minimum number of taps required.
        /// </summary>
        /// <returns>The minimum taps required</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetMinimumTapsRequired()
        {
            uint ret = NDalicPINVOKE.TapGestureDetector_GetMinimumTapsRequired(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the maximum number of taps required.
        /// </summary>
        /// <returns>The maximum taps required</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetMaximumTapsRequired()
        {
            uint ret = NDalicPINVOKE.TapGestureDetector_GetMaximumTapsRequired(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal new static TapGestureDetector DownCast(BaseHandle handle)
        {
            TapGestureDetector ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as TapGestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TapGestureDetector obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static TapGestureDetector GetTapGestureDetectorFromPtr(global::System.IntPtr cPtr)
        {
            TapGestureDetector ret = new TapGestureDetector(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TapGestureDetectedSignal DetectedSignal()
        {
            TapGestureDetectedSignal ret = new TapGestureDetectedSignal(NDalicPINVOKE.TapGestureDetector_DetectedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TapGestureDetector Assign(TapGestureDetector rhs)
        {
            TapGestureDetector ret = new TapGestureDetector(NDalicPINVOKE.TapGestureDetector_Assign(swigCPtr, TapGestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
                    NDalicPINVOKE.delete_TapGestureDetector(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private void OnTapGestureDetected(IntPtr actor, IntPtr tapGesture)
        {
            DetectedEventArgs e = new DetectedEventArgs();

            // Populate all members of "e" (DetectedEventArgs) with real data
            e.View = Registry.GetManagedBaseHandleFromNativePtr(actor) as View;
            e.TapGesture = Tizen.NUI.TapGesture.GetTapGestureFromPtr(tapGesture);

            if (_tapGestureEventHandler != null)
            {
                //here we send all data to user event handlers
                _tapGestureEventHandler(this, e);
            }

        }

        /// <summary>
        /// Event arguments that are passed via the TapGestureEvent signal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class DetectedEventArgs : EventArgs
        {
            private View _view;
            private TapGesture _tapGesture;

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
            /// The TapGesture.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public TapGesture TapGesture
            {
                get
                {
                    return _tapGesture;
                }
                set
                {
                    _tapGesture = value;
                }
            }
        }
    }

}
