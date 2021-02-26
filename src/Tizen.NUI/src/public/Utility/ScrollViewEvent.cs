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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// ScrollView contains views that can be scrolled manually (via touch).
    /// </summary>
    public partial class ScrollView
    {
        private DaliEventHandler<object, SnapStartedEventArgs> scrollViewSnapStartedEventHandler;
        private SnapStartedCallbackDelegate scrollViewSnapStartedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void SnapStartedCallbackDelegate(IntPtr data);

        /// <summary>
        /// SnapStarted can be used to subscribe or unsubscribe the event handler
        /// The SnapStarted signal is emitted when the ScrollView has started to snap or flick (it tells the target
        ///  position, scale, rotation for the snap or flick).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, SnapStartedEventArgs> SnapStarted
        {
            add
            {
                // Restricted to only one listener
                if (scrollViewSnapStartedEventHandler == null)
                {
                    scrollViewSnapStartedEventHandler += value;

                    scrollViewSnapStartedCallbackDelegate = new SnapStartedCallbackDelegate(OnSnapStarted);
                    ScrollViewSnapStartedSignal snapStarted = this.SnapStartedSignal();
                    snapStarted?.Connect(scrollViewSnapStartedCallbackDelegate);
                    snapStarted?.Dispose();
                }
            }

            remove
            {
                if (scrollViewSnapStartedEventHandler != null)
                {
                    ScrollViewSnapStartedSignal snapStarted = this.SnapStartedSignal();
                    snapStarted?.Disconnect(scrollViewSnapStartedCallbackDelegate);
                    snapStarted?.Dispose();
                }

                scrollViewSnapStartedEventHandler -= value;
            }
        }

        internal ScrollViewSnapStartedSignal SnapStartedSignal()
        {
            ScrollViewSnapStartedSignal ret = new ScrollViewSnapStartedSignal(Interop.ScrollView.SnapStartedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        // Callback for ScrollView SnapStarted signal
        private void OnSnapStarted(IntPtr data)
        {
            SnapStartedEventArgs e = new SnapStartedEventArgs();

            // Populate all members of "e" (SnapStartedEventArgs) with real data
            e.SnapEventInfo = SnapEvent.GetSnapEventFromPtr(data);

            if (scrollViewSnapStartedEventHandler != null)
            {
                //here we send all data to user event handlers
                scrollViewSnapStartedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Snaps signal event's data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class SnapEvent : Disposable
        {
            /// <summary>
            /// swigCMemOwn
            /// </summary>
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected bool swigCMemOwn;
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;

            /// <summary>
            /// Create an instance of SnapEvent.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public SnapEvent() : this(Interop.ScrollView.NewScrollViewSnapEvent(), true)
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
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Vector2 position
            {
                set
                {
                    Interop.ScrollView.SnapEventPositionSet(swigCPtr, Vector2.getCPtr(value));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    global::System.IntPtr cPtr = Interop.ScrollView.SnapEventPositionGet(swigCPtr);
                    Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
            }

            /// <summary>
            /// Scroll duration.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float duration
            {
                set
                {
                    Interop.ScrollView.SnapEventDurationSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.ScrollView.SnapEventDurationGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
            }

            internal SnapType type
            {
                set
                {
                    Interop.ScrollView.SnapEventTypeSet(swigCPtr, (int)value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    SnapType ret = (SnapType)Interop.ScrollView.SnapEventTypeGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// Get SnapEvent From Ptr
            /// </summary>
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
                        Interop.ScrollView.DeleteScrollViewSnapEvent(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }

                base.Dispose(type);
            }

        }

        /// <summary>
        /// Event arguments that passed via the SnapStarted signal.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class SnapStartedEventArgs : EventArgs
        {
            private Tizen.NUI.ScrollView.SnapEvent snapEvent;

            /// <summary>
            /// SnapEventInfo is the SnapEvent information like snap or flick (it tells the target position, scale, rotation for the snap or flick).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Tizen.NUI.ScrollView.SnapEvent SnapEventInfo
            {
                get
                {
                    return snapEvent;
                }
                set
                {
                    snapEvent = value;
                }
            }
        }
    }
}
