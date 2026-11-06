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
    /// This class emits a signal when a tap gesture occurs that meets the requirements set by the application.<br />
    /// A TapGesture is a discrete gesture, which means it does not have any state information attached.<br />
    /// </summary>
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TapGestureDetector : GestureDetector
    {
        /// <summary>
        /// Creates an initialized TapGestureDetector.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TapGestureDetector() : this(Interop.TapGestureDetector.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an initialized TapGestureDetector with the specified parameters.
        /// </summary>
        /// <param name="tapsRequired">The minimum and maximum number of taps required</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TapGestureDetector(uint tapsRequired) : this(Interop.TapGestureDetector.New(tapsRequired), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="handle">A reference to the copied handle</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TapGestureDetector(TapGestureDetector handle) : this(Interop.TapGestureDetector.NewTapGestureDetector(TapGestureDetector.getCPtr(handle)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TapGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal TapGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        private DaliEventHandler<object, DetectedEventArgs> _detectedEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DetectedCallbackType(IntPtr actor, IntPtr TapGesture);
        private DetectedCallbackType _detectedCallback;

        /// <summary>
        /// This signal is emitted when the specified tap is detected on the attached view.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                if (_detectedEventHandler == null)
                {
                    _detectedCallback = OnTapGestureDetected;
                    using var signal = DetectedSignal();
                    signal.Connect(_detectedCallback);
                }

                _detectedEventHandler += value;
            }

            remove
            {
                _detectedEventHandler -= value;
                if (_detectedEventHandler == null && _detectedCallback != null)
                {
                    using var signal = DetectedSignal();
                    signal.Disconnect(_detectedCallback);
                    _detectedCallback = null;
                }
            }
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
            Interop.TapGestureDetector.SetMinimumTapsRequired(SwigCPtr, minimumTaps);
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
            Interop.TapGestureDetector.SetMaximumTapsRequired(SwigCPtr, maximumTaps);
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
            uint ret = Interop.TapGestureDetector.GetMinimumTapsRequired(SwigCPtr);
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
            uint ret = Interop.TapGestureDetector.GetMaximumTapsRequired(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal new static TapGestureDetector DownCast(BaseHandle handle)
        {
            TapGestureDetector ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as TapGestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static TapGestureDetector GetTapGestureDetectorFromPtr(global::System.IntPtr cPtr)
        {
            TapGestureDetector ret = new TapGestureDetector(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TapGestureDetectedSignal DetectedSignal()
        {
            TapGestureDetectedSignal ret = new TapGestureDetectedSignal(Interop.TapGestureDetector.DetectedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TapGestureDetector Assign(TapGestureDetector rhs)
        {
            TapGestureDetector ret = new TapGestureDetector(Interop.TapGestureDetector.Assign(SwigCPtr, TapGestureDetector.getCPtr(rhs)), false);
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
                if (_detectedCallback != null)
                {
                    using TapGestureDetectedSignal signal = new TapGestureDetectedSignal(Interop.TapGestureDetector.DetectedSignal(GetBaseHandleCPtrHandleRef), false);
                    signal?.Disconnect(_detectedCallback);
                    _detectedCallback = null;
                }
            }
            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TapGestureDetector.DeleteTapGestureDetector(swigCPtr);
        }

        private void OnTapGestureDetected(IntPtr actor, IntPtr tapGesture)
        {
            DetectedEventArgs e = new DetectedEventArgs();

            // Populate all members of "e" (DetectedEventArgs) with real data
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

            e.TapGesture = Tizen.NUI.TapGesture.GetTapGestureFromPtr(tapGesture);

            if (_detectedEventHandler != null)
            {
                e.Handled = true;
                //here we send all data to user event handlers
                _detectedEventHandler(this, e);
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

        /// <summary>
        /// Recognition options of a tap gesture detector that can differ per input device: the taps required and
        /// whether every tap event is delivered.<br />
        /// An Options object is a complete snapshot of the settings; the detector applies the snapshot registered for the
        /// most specific matching <see cref="GestureDeviceSelector"/> and otherwise its own settings.<br />
        /// Start from <see cref="GetDefaultOptions"/> to keep the values you do not want to change.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed class Options : Disposable
        {
            /// <summary>
            /// Creates an Options object holding the built-in default settings.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Options() : this(Interop.TapGestureDetector.NewOptions(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal Options(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn, false)
            {
            }

            /// <summary>
            /// Gets or sets the minimum number of taps required. The default is 1.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint MinimumTapsRequired
            {
                get
                {
                    uint ret = Interop.TapGestureDetector.OptionsGetMinimumTapsRequired(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
                set
                {
                    Interop.TapGestureDetector.OptionsSetMinimumTapsRequired(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }

            /// <summary>
            /// Gets or sets the maximum number of taps required. The default is 1.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint MaximumTapsRequired
            {
                get
                {
                    uint ret = Interop.TapGestureDetector.OptionsGetMaximumTapsRequired(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
                set
                {
                    Interop.TapGestureDetector.OptionsSetMaximumTapsRequired(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }

            /// <summary>
            /// Gets or sets whether every tap is delivered immediately (true) or only the final tap of a multi-tap sequence (false). The default is false.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool ReceiveAllTapEvents
            {
                get
                {
                    bool ret = Interop.TapGestureDetector.OptionsIsReceiveAllTapEventsEnabled(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
                set
                {
                    Interop.TapGestureDetector.OptionsSetReceiveAllTapEventsEnabled(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
            /// This will not be public opened.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
            {
                Interop.TapGestureDetector.DeleteOptions(swigCPtr);
            }
        }

        /// <summary>
        /// Returns a copy of the settings this detector uses when no device-specific options match.
        /// </summary>
        /// <returns>A new Options object. Dispose it when no longer needed.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Options GetDefaultOptions()
        {
            Options ret = new Options(Interop.TapGestureDetector.GetDefaultOptions(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Registers the settings to use for gestures that start on a device matching the selector.<br />
        /// Registering with an equal selector replaces the earlier settings. The detector copies the options,
        /// so later changes to <paramref name="options"/> have no effect until it is set again.
        /// </summary>
        /// <param name="selector">The devices the options apply to.</param>
        /// <param name="options">The complete settings for those devices.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDeviceOptions(GestureDeviceSelector selector, Options options)
        {
            Interop.TapGestureDetector.SetDeviceOptions(SwigCPtr, GestureDeviceSelector.getCPtr(selector), Options.getCPtr(options));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the settings registered for exactly this selector. Fallback to a less specific selector is not applied.
        /// </summary>
        /// <param name="selector">The selector the options were registered with.</param>
        /// <param name="options">The registered settings, or null when none are registered for the selector.</param>
        /// <returns>True when settings are registered for the selector.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TryGetDeviceOptions(GestureDeviceSelector selector, out Options options)
        {
            Options result = new Options();
            bool found = Interop.TapGestureDetector.GetDeviceOptions(SwigCPtr, GestureDeviceSelector.getCPtr(selector), Options.getCPtr(result));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                result.Dispose();
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            if (!found)
            {
                result.Dispose();
                options = null;
                return false;
            }

            options = result;
            return true;
        }

        /// <summary>
        /// Removes the settings registered for exactly this selector. Does nothing when none are registered.
        /// </summary>
        /// <param name="selector">The selector the options were registered with.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearDeviceOptions(GestureDeviceSelector selector)
        {
            Interop.TapGestureDetector.ClearDeviceOptions(SwigCPtr, GestureDeviceSelector.getCPtr(selector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether every tap is delivered immediately or only the final tap of a multi-tap sequence.<br />
        /// When true, each tap arrives as it happens; when false (the default), taps are held back until the multi-tap
        /// interval expires and only the final count is delivered.
        /// </summary>
        /// <param name="receive">True to receive every tap event.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ReceiveAllTapEvents(bool receive)
        {
            Interop.TapGestureDetector.ReceiveAllTapEvents(SwigCPtr, receive);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether every tap event is delivered immediately.
        /// </summary>
        /// <returns>True if every tap event is delivered.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsReceiveAllTapEventsEnabled()
        {
            bool ret = Interop.TapGestureDetector.IsReceiveAllTapEventsEnabled(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
