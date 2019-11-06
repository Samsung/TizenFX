﻿/*
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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// ScrollView contains views that can be scrolled manually (via touch).
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class ScrollView
    {
        private DaliEventHandler<object, SnapStartedEventArgs> _scrollViewSnapStartedEventHandler;
        private SnapStartedCallbackDelegate _scrollViewSnapStartedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void SnapStartedCallbackDelegate(IntPtr data);

        /// <summary>
        /// SnapStarted can be used to subscribe or unsubscribe the event handler
        /// The SnapStarted signal is emitted when the ScrollView has started to snap or flick (it tells the target
        ///  position, scale, rotation for the snap or flick).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, SnapStartedEventArgs> SnapStarted
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_scrollViewSnapStartedEventHandler == null)
                    {
                        _scrollViewSnapStartedEventHandler += value;

                        _scrollViewSnapStartedCallbackDelegate = new SnapStartedCallbackDelegate(OnSnapStarted);
                        this.SnapStartedSignal().Connect(_scrollViewSnapStartedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_scrollViewSnapStartedEventHandler != null)
                    {
                        this.SnapStartedSignal().Disconnect(_scrollViewSnapStartedCallbackDelegate);
                    }

                    _scrollViewSnapStartedEventHandler -= value;
                }
            }
        }

        internal ScrollViewSnapStartedSignal SnapStartedSignal()
        {
            ScrollViewSnapStartedSignal ret = new ScrollViewSnapStartedSignal(Interop.ScrollView.ScrollView_SnapStartedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        // Callback for ScrollView SnapStarted signal
        private void OnSnapStarted(IntPtr data)
        {
            SnapStartedEventArgs e = new SnapStartedEventArgs();

            // Populate all members of "e" (SnapStartedEventArgs) with real data
            e.SnapEventInfo = SnapEvent.GetSnapEventFromPtr(data);

            if (_scrollViewSnapStartedEventHandler != null)
            {
                //here we send all data to user event handlers
                _scrollViewSnapStartedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Snaps signal event's data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class SnapEvent : Disposable
        {
            /// <summary>
            /// swigCMemOwn
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected bool swigCMemOwn;
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;

            /// <summary>
            /// Create an instance of SnapEvent.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public SnapEvent() : this(Interop.ScrollView.new_ScrollView_SnapEvent(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal SnapEvent(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            /// <summary>
            /// Scroll position.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Vector2 position
            {
                set
                {
                    Interop.ScrollView.ScrollView_SnapEvent_position_set(swigCPtr, Vector2.getCPtr(value));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    global::System.IntPtr cPtr = Interop.ScrollView.ScrollView_SnapEvent_position_get(swigCPtr);
                    Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// Scroll duration.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float duration
            {
                set
                {
                    Interop.ScrollView.ScrollView_SnapEvent_duration_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.ScrollView.ScrollView_SnapEvent_duration_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            internal SnapType type
            {
                set
                {
                    Interop.ScrollView.ScrollView_SnapEvent_type_set(swigCPtr, (int)value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    SnapType ret = (SnapType)Interop.ScrollView.ScrollView_SnapEvent_type_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// Get SnapEvent From Ptr
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6, Will be removed in API9, " + 
                "Please use SnapStarted event instead!" +
                "IntPtr(native integer pointer) is supposed to be not used in Application!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static SnapEvent GetSnapEventFromPtr(global::System.IntPtr cPtr)
            {
                SnapEvent ret = new SnapEvent(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SnapEvent obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            /// <summary>
            /// Dispose
            /// </summary>
            /// <param name="type">the dispose type</param>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                //Release your own unmanaged resources here.
                //You should not access any managed member here except static instance.
                //because the execution order of Finalizes is non-deterministic.

                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        Interop.ScrollView.delete_ScrollView_SnapEvent(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }

                base.Dispose(type);
            }

        }

        /// <summary>
        /// Event arguments that passed via the SnapStarted signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class SnapStartedEventArgs : EventArgs
        {
            private Tizen.NUI.ScrollView.SnapEvent _snapEvent;

            /// <summary>
            /// SnapEventInfo is the SnapEvent information like snap or flick (it tells the target position, scale, rotation for the snap or flick).
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Tizen.NUI.ScrollView.SnapEvent SnapEventInfo
            {
                get
                {
                    return _snapEvent;
                }
                set
                {
                    _snapEvent = value;
                }
            }
        }
    }
}
