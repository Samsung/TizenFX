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
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal WatchApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WatchApplication obj)
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
            DisConnectFromSignals();

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicManualPINVOKE.delete_WatchApplication(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
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

        public new static WatchApplication Instance
        {
            get
            {
                return _instance;
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
            WatchApplication ret = new WatchApplication(NDalicManualPINVOKE.WatchApplication_New__SWIG_0(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static WatchApplication New(string[] args)
        {
            int argc = args.Length;
            string argvStr = string.Join(" ", args);

            WatchApplication ret = new WatchApplication(NDalicManualPINVOKE.WatchApplication_New__SWIG_1(argc, argvStr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static WatchApplication New(string[] args, string stylesheet)
        {
            int argc = args.Length;
            string argvStr = string.Join(" ", args);

            WatchApplication ret = new WatchApplication(NDalicManualPINVOKE.WatchApplication_New__SWIG_2(argc, argvStr, stylesheet), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WatchApplication(WatchApplication implementation) : this(NDalicManualPINVOKE.new_WatchApplication__SWIG_1(WatchApplication.getCPtr(implementation)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Event arguments that passed via time tick event signal.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public class TimeTickEventArgs : EventArgs
        {
            /// <summary>
            /// Application.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public Application Application
            {
                get;
                set;
            }

            /// <summary>
            /// WatchTime.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public WatchTime WatchTime
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TimeTickCallbackType(IntPtr application, IntPtr watchTime);
        private TimeTickCallbackType _timeTickCallback;
        private DaliEventHandler<object,TimeTickEventArgs> _timeTickEventHandler;

        /// <summary>
        /// TimeTick event.
        /// </summary>
        public event DaliEventHandler<object, TimeTickEventArgs> TimeTick
        {
            add
            {
                if (_timeTickEventHandler == null)
                {
                    _timeTickCallback = new TimeTickCallbackType( OnTimeTick);
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
            using (e.Application = Application.GetApplicationFromPtr(application))
            {
            using (e.WatchTime = WatchTime.GetWatchTimeFromPtr(watchTime))
            {
                _timeTickEventHandler?.Invoke(this, e);
            }
            }

        }

        internal WatchTimeSignal TimeTickSignal()
        {
            WatchTimeSignal ret = new WatchTimeSignal(NDalicManualPINVOKE.WatchApplication_TimeTickSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via ambient tick event signal.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public class AmbientTickEventArgs : EventArgs
        {
            /// <summary>
            /// Application.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public Application Application
            {
                get;
                set;
            }

            /// <summary>
            /// WatchTime.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public WatchTime WatchTime
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AmbientTickCallbackType(IntPtr application, IntPtr watchTime);
        private AmbientTickCallbackType _ambientTickCallback;
        private DaliEventHandler<object,AmbientTickEventArgs> _ambientTickEventHandler;

        /// <summary>
        /// AmbientTick event.
        /// </summary>
        public event DaliEventHandler<object, AmbientTickEventArgs> AmbientTick
        {
            add
            {
                if (_ambientTickEventHandler == null)
                {
                    _ambientTickCallback = new AmbientTickCallbackType( OnAmbientTick);
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

            using (e.Application = Application.GetApplicationFromPtr(application))
            {
            using (e.WatchTime = WatchTime.GetWatchTimeFromPtr(watchTime))
            {
                _ambientTickEventHandler?.Invoke(this, e);
            }
            }
        }

        internal WatchTimeSignal AmbientTickSignal()
        {
            WatchTimeSignal ret = new WatchTimeSignal(NDalicManualPINVOKE.WatchApplication_AmbientTickSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via ambient tick event signal.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public class AmbientChangedEventArgs : EventArgs
        {
            /// <summary>
            /// Application.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public Application Application
            {
                get;
                set;
            }

            /// <summary>
            /// Changed.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public bool Changed
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AmbientChangedCallbackType(IntPtr application, bool changed);
        private AmbientChangedCallbackType _ambientChangedCallback;
        private DaliEventHandler<object,AmbientChangedEventArgs> _ambientChangedEventHandler;

        /// <summary>
        /// AmbientChanged event.
        /// </summary>
        public event DaliEventHandler<object, AmbientChangedEventArgs> AmbientChanged
        {
            add
            {
                if (_ambientChangedEventHandler == null)
                {
                    _ambientChangedCallback = new AmbientChangedCallbackType( OnAmbientChanged);
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
            using (e.Application = Application.GetApplicationFromPtr(application))
            {
                e.Changed = changed;
                _ambientChangedEventHandler?.Invoke(this, e);
            }
        }

        internal WatchBoolSignal AmbientChangedSignal()
        {
            WatchBoolSignal ret = new WatchBoolSignal(NDalicManualPINVOKE.WatchApplication_AmbientChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private static WatchApplication _instance; //singleton

    }

}
