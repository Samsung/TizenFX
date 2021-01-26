/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    internal class WatchApplication : Application
    {

        internal WatchApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WatchApplication obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Watch.DeleteWatchApplication(swigCPtr);
        }

        private void DisConnectFromSignals()
        {
            if (_timeTickCallback != null)
            {
                this.TimeTickSignal().Disconnect(_timeTickCallback);
            }
            if (_ambientTickCallback != null)
            {
                this.AmbientTickSignal().Disconnect(_ambientTickCallback);
            }
            if (_ambientChangedCallback != null)
            {
                this.AmbientChangedSignal().Disconnect(_ambientChangedCallback);
            }
        }

        public static WatchApplication NewWatchApplication()
        {
            WatchApplication ret = New();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            // we've got an application now connect the signals
            _instance = ret;
            return ret;
        }

        public static WatchApplication NewWatchApplication(string[] args)
        {
            WatchApplication ret = New(args);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            _instance = ret;
            return ret;
        }

        public static WatchApplication NewWatchApplication(string[] args, string stylesheet)
        {
            WatchApplication ret = New(args, stylesheet);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            _instance = ret;
            return ret;
        }

        public new static WatchApplication New()
        {
            WatchApplication ret = new WatchApplication(Interop.Watch.WatchApplicationNew(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static WatchApplication New(string[] args)
        {
            int argc = args.Length;
            string argvStr = string.Join(" ", args);

            WatchApplication ret = new WatchApplication(Interop.Watch.WatchApplicationNew(argc, argvStr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static WatchApplication New(string[] args, string stylesheet)
        {
            int argc = args.Length;
            string argvStr = string.Join(" ", args);

            WatchApplication ret = new WatchApplication(Interop.Watch.WatchApplicationNew(argc, argvStr, stylesheet), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WatchApplication(WatchApplication implementation) : this(Interop.Watch.NewWatchApplication(WatchApplication.getCPtr(implementation)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Event arguments that passed via time tick event signal.
        /// </summary>
        public class TimeTickEventArgs : EventArgs
        {
            /// <summary>
            /// Application.
            /// </summary>
            public Application Application
            {
                get;
                set;
            }

            /// <summary>
            /// WatchTime.
            /// </summary>
            public WatchTime WatchTime
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TimeTickCallbackType(IntPtr application, IntPtr watchTime);
        private TimeTickCallbackType _timeTickCallback;
        private DaliEventHandler<object, TimeTickEventArgs> _timeTickEventHandler;

        /// <summary>
        /// TimeTick event.
        /// </summary>
        public event DaliEventHandler<object, TimeTickEventArgs> TimeTick
        {
            add
            {
                if (_timeTickEventHandler == null)
                {
                    _timeTickCallback = new TimeTickCallbackType(OnTimeTick);
                    TimeTickSignal().Connect(_timeTickCallback);
                }

                _timeTickEventHandler += value;
            }

            remove
            {
                _timeTickEventHandler -= value;

                if (_timeTickEventHandler == null && TimeTickSignal().Empty() == false)
                {
                    TimeTickSignal().Disconnect(_timeTickCallback);
                }
            }
        }

        private void OnTimeTick(IntPtr application, IntPtr watchTime)
        {
            TimeTickEventArgs e = new TimeTickEventArgs();
            e.Application = this;
            e.WatchTime = WatchTime.GetWatchTimeFromPtr(watchTime);

            _timeTickEventHandler?.Invoke(this, e);

        }

        internal WatchTimeSignal TimeTickSignal()
        {
            WatchTimeSignal ret = new WatchTimeSignal(Interop.Watch.WatchApplicationTimeTickSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via ambient tick event signal.
        /// </summary>
        public class AmbientTickEventArgs : EventArgs
        {
            /// <summary>
            /// Application.
            /// </summary>
            public Application Application
            {
                get;
                set;
            }

            /// <summary>
            /// WatchTime.
            /// </summary>
            public WatchTime WatchTime
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AmbientTickCallbackType(IntPtr application, IntPtr watchTime);
        private AmbientTickCallbackType _ambientTickCallback;
        private DaliEventHandler<object, AmbientTickEventArgs> _ambientTickEventHandler;

        /// <summary>
        /// AmbientTick event.
        /// </summary>
        public event DaliEventHandler<object, AmbientTickEventArgs> AmbientTick
        {
            add
            {
                if (_ambientTickEventHandler == null)
                {
                    _ambientTickCallback = new AmbientTickCallbackType(OnAmbientTick);
                    AmbientTickSignal().Connect(_ambientTickCallback);
                }

                _ambientTickEventHandler += value;
            }

            remove
            {
                _ambientTickEventHandler -= value;

                if (_ambientTickEventHandler == null && AmbientTickSignal().Empty() == false)
                {
                    AmbientTickSignal().Disconnect(_ambientTickCallback);
                }
            }
        }

        private void OnAmbientTick(IntPtr application, IntPtr watchTime)
        {
            AmbientTickEventArgs e = new AmbientTickEventArgs();

            e.Application = this;
            e.WatchTime = WatchTime.GetWatchTimeFromPtr(watchTime);
            _ambientTickEventHandler?.Invoke(this, e);
        }

        internal WatchTimeSignal AmbientTickSignal()
        {
            WatchTimeSignal ret = new WatchTimeSignal(Interop.Watch.WatchApplicationAmbientTickSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via ambient tick event signal.
        /// </summary>
        public class AmbientChangedEventArgs : EventArgs
        {
            /// <summary>
            /// Application.
            /// </summary>
            public Application Application
            {
                get;
                set;
            }

            /// <summary>
            /// Changed.
            /// </summary>
            public bool Changed
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AmbientChangedCallbackType(IntPtr application, bool changed);
        private AmbientChangedCallbackType _ambientChangedCallback;
        private DaliEventHandler<object, AmbientChangedEventArgs> _ambientChangedEventHandler;

        /// <summary>
        /// AmbientChanged event.
        /// </summary>
        public event DaliEventHandler<object, AmbientChangedEventArgs> AmbientChanged
        {
            add
            {
                if (_ambientChangedEventHandler == null)
                {
                    _ambientChangedCallback = new AmbientChangedCallbackType(OnAmbientChanged);
                    AmbientChangedSignal().Connect(_ambientChangedCallback);
                }

                _ambientChangedEventHandler += value;
            }

            remove
            {
                _ambientChangedEventHandler -= value;

                if (_ambientChangedEventHandler == null && AmbientChangedSignal().Empty() == false)
                {
                    AmbientChangedSignal().Disconnect(_ambientChangedCallback);
                }
            }
        }

        private void OnAmbientChanged(IntPtr application, bool changed)
        {
            AmbientChangedEventArgs e = new AmbientChangedEventArgs();
            e.Application = this;
            e.Changed = changed;
            _ambientChangedEventHandler?.Invoke(this, e);
        }

        internal WatchBoolSignal AmbientChangedSignal()
        {
            WatchBoolSignal ret = new WatchBoolSignal(Interop.Watch.WatchApplicationAmbientChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
