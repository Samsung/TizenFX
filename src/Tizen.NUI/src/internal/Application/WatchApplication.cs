/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
            if (timeTickCallback != null)
            {
                this.TimeTickSignal().Disconnect(timeTickCallback);
            }
            if (ambientTickCallback != null)
            {
                this.AmbientTickSignal().Disconnect(ambientTickCallback);
            }
            if (ambientChangedCallback != null)
            {
                this.AmbientChangedSignal().Disconnect(ambientChangedCallback);
            }
        }

        public static WatchApplication NewWatchApplication()
        {
            WatchApplication ret = New();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            // we've got an application now connect the signals
            instance = ret;
            return ret;
        }

        public static WatchApplication NewWatchApplication(string[] args)
        {
            WatchApplication ret = New(args);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            instance = ret;
            return ret;
        }

        public static WatchApplication NewWatchApplication(string[] args, string stylesheet)
        {
            WatchApplication ret = New(args, stylesheet);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            instance = ret;
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
        private TimeTickCallbackType timeTickCallback;
        private DaliEventHandler<object, TimeTickEventArgs> timeTickEventHandler;

        /// <summary>
        /// TimeTick event.
        /// </summary>
        public event DaliEventHandler<object, TimeTickEventArgs> TimeTick
        {
            add
            {
                if (timeTickEventHandler == null)
                {
                    timeTickCallback = new TimeTickCallbackType(OnTimeTick);
                    TimeTickSignal().Connect(timeTickCallback);
                }

                timeTickEventHandler += value;
            }

            remove
            {
                timeTickEventHandler -= value;

                if (timeTickEventHandler == null && TimeTickSignal().Empty() == false)
                {
                    TimeTickSignal().Disconnect(timeTickCallback);
                }
            }
        }

        private void OnTimeTick(IntPtr application, IntPtr watchTime)
        {
            TimeTickEventArgs e = new TimeTickEventArgs();
            e.Application = this;
            e.WatchTime = WatchTime.GetWatchTimeFromPtr(watchTime);

            timeTickEventHandler?.Invoke(this, e);
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
        private AmbientTickCallbackType ambientTickCallback;
        private DaliEventHandler<object, AmbientTickEventArgs> ambientTickEventHandler;

        /// <summary>
        /// AmbientTick event.
        /// </summary>
        public event DaliEventHandler<object, AmbientTickEventArgs> AmbientTick
        {
            add
            {
                if (ambientTickEventHandler == null)
                {
                    ambientTickCallback = new AmbientTickCallbackType(OnAmbientTick);
                    AmbientTickSignal().Connect(ambientTickCallback);
                }

                ambientTickEventHandler += value;
            }

            remove
            {
                ambientTickEventHandler -= value;

                if (ambientTickEventHandler == null && AmbientTickSignal().Empty() == false)
                {
                    AmbientTickSignal().Disconnect(ambientTickCallback);
                }
            }
        }

        private void OnAmbientTick(IntPtr application, IntPtr watchTime)
        {
            AmbientTickEventArgs e = new AmbientTickEventArgs();

            e.Application = this;
            e.WatchTime = WatchTime.GetWatchTimeFromPtr(watchTime);
            ambientTickEventHandler?.Invoke(this, e);
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
        private AmbientChangedCallbackType ambientChangedCallback;
        private DaliEventHandler<object, AmbientChangedEventArgs> ambientChangedEventHandler;

        /// <summary>
        /// AmbientChanged event.
        /// </summary>
        public event DaliEventHandler<object, AmbientChangedEventArgs> AmbientChanged
        {
            add
            {
                if (ambientChangedEventHandler == null)
                {
                    ambientChangedCallback = new AmbientChangedCallbackType(OnAmbientChanged);
                    AmbientChangedSignal().Connect(ambientChangedCallback);
                }

                ambientChangedEventHandler += value;
            }

            remove
            {
                ambientChangedEventHandler -= value;

                if (ambientChangedEventHandler == null && AmbientChangedSignal().Empty() == false)
                {
                    AmbientChangedSignal().Disconnect(ambientChangedCallback);
                }
            }
        }

        private void OnAmbientChanged(IntPtr application, bool changed)
        {
            AmbientChangedEventArgs e = new AmbientChangedEventArgs();
            e.Application = this;
            e.Changed = changed;
            ambientChangedEventHandler?.Invoke(this, e);
        }

        internal WatchBoolSignal AmbientChangedSignal()
        {
            WatchBoolSignal ret = new WatchBoolSignal(Interop.Watch.WatchApplicationAmbientChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
