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
using System;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// Widget application
    /// </summary>
    internal class WidgetApplication : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal WidgetApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicManualPINVOKE.WidgetApplication_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WidgetApplication obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// To make Window instance be disposed.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (_initCallback != null)
            {
                this.InitSignal().Disconnect(_initCallback);
            }
            if (_terminateCallback != null)
            {
                this.TerminateSignal().Disconnect(_terminateCallback);
            }
            if (_languageChangedCallback != null)
            {
                this.LanguageChangedSignal().Disconnect(_languageChangedCallback);;
            }
            if (_regionChangedCallback != null)
            {
                this.RegionChangedSignal().Disconnect(_regionChangedCallback);
            }
            if (_batteryLowCallback != null)
            {
                this.BatteryLowSignal().Disconnect(_batteryLowCallback);
            }
            if (_memoryLowCallback != null)
            {
                this.MemoryLowSignal().Disconnect(_memoryLowCallback);
            }
            
            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicManualPINVOKE.delete_WidgetApplication(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        internal static WidgetApplication GetWidgetApplicationFromPtr(global::System.IntPtr cPtr)
        {
            WidgetApplication ret = new WidgetApplication(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static WidgetApplication Instance
        {
            get
            {
                return _instance;
            }
        }

        public static WidgetApplication NewWidgetApplication(string[] args, string stylesheet)
        {
            WidgetApplication ret = New(args, stylesheet);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            _instance = ret;
            return ret;
        }

        public static WidgetApplication New(string[] args, string stylesheet)
        {
            int argc = args.Length;
            string argvStr = string.Join(" ", args);

            WidgetApplication ret = new WidgetApplication(NDalicManualPINVOKE.WidgetApplication_New(argc, argvStr, stylesheet), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
 
        internal WidgetApplication(WidgetApplication widgetApplication) : this(NDalicManualPINVOKE.new_WidgetApplication__SWIG_1(WidgetApplication.getCPtr(widgetApplication)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal WidgetApplication Assign(WidgetApplication widgetApplication)
        {
            WidgetApplication ret = new WidgetApplication(NDalicManualPINVOKE.WidgetApplication_Assign(swigCPtr, WidgetApplication.getCPtr(widgetApplication)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// This starts the application.
        /// </summary>
        public void MainLoop()
        {
            NDalicManualPINVOKE.WidgetApplication_MainLoop(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// This quits the application.
        /// Tizen applications should use Lower to improve re-start performance unless they need to Quit completely.
        /// </summary>
        public void Quit()
        {
            NDalicManualPINVOKE.WidgetApplication_Quit(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get path application resources are stored at.
        /// </summary>
        /// <returns>The full path of the resources</returns>
        public static string GetResourcePath()
        {
            string ret = NDalicManualPINVOKE.WidgetApplication_GetResourcePath();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get region information from device.
        /// </summary>
        /// <returns>Region information</returns>
        public string GetRegion()
        {
            string ret = NDalicManualPINVOKE.WidgetApplication_GetRegion(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get language from device.
        /// </summary>
        /// <returns>Language information</returns>
        public string GetLanguage()
        {
            string ret = NDalicManualPINVOKE.WidgetApplication_GetLanguage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via widget app event signal.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public class WidgetApplicationEventArgs : EventArgs
        {
            /// <summary>
            /// Widget application.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public WidgetApplication WidgetApplication
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void InitCallbackType(IntPtr widgetApplication);
        private InitCallbackType _initCallback;
        private DaliEventHandler<object,WidgetApplicationEventArgs> _initEventHandler;

        /// <summary>
        /// Init event.
        /// </summary>
        public event DaliEventHandler<object, WidgetApplicationEventArgs> Init
        {
            add
            {
                if (_initEventHandler == null)
                {
                    _initCallback = new InitCallbackType( OnInit);
                    InitSignal().Connect(_initCallback);
                }

                _initEventHandler += value;
            }

            remove
            {
                _initEventHandler -= value;

                if (_initEventHandler == null && InitSignal().Empty() == false)
                {
                   InitSignal().Disconnect(_initCallback);
                }
            }
        }

        private void OnInit(IntPtr widgetApplication)
        {
            WidgetApplicationEventArgs e = new WidgetApplicationEventArgs();
            if (widgetApplication != null)
            {
                e.WidgetApplication = WidgetApplication.GetWidgetApplicationFromPtr(widgetApplication);
            }

            if (_initEventHandler != null)
            {
                _initEventHandler(this, e);
            }
        }

        internal AppSignalType InitSignal()
        {
            AppSignalType ret = new AppSignalType(NDalicManualPINVOKE.WidgetApplication_InitSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TerminateCallbackType(IntPtr widgetApplication);
        private TerminateCallbackType _terminateCallback;
        private DaliEventHandler<object, WidgetApplicationEventArgs> _terminateEventHandler;

        /// <summary>
        /// Terminate event.
        /// </summary>
        public event DaliEventHandler<object, WidgetApplicationEventArgs> Terminate
        {
            add
            {
                if (_terminateEventHandler == null)
                {
                    _terminateCallback = new TerminateCallbackType( OnTerminate);
                    TerminateSignal().Connect(_terminateCallback);
                }

                _terminateEventHandler += value;
            }

            remove
            {
                _terminateEventHandler -= value;

                if (_terminateEventHandler == null && TerminateSignal().Empty() == false)
                {
                   TerminateSignal().Disconnect(_terminateCallback);
                }
            }
        }

        private void OnTerminate(IntPtr widgetApplication)
        {
            WidgetApplicationEventArgs e = new WidgetApplicationEventArgs();

            if (widgetApplication != null)
            {
                e.WidgetApplication = WidgetApplication.GetWidgetApplicationFromPtr(widgetApplication);
            }

            if (_terminateEventHandler != null)
            {
                _terminateEventHandler(this, e);
            }
        }

        internal AppSignalType TerminateSignal()
        {
            AppSignalType ret = new AppSignalType(NDalicManualPINVOKE.WidgetApplication_TerminateSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void LanguageChangedCallbackType(IntPtr widgetApplication);
        private LanguageChangedCallbackType _languageChangedCallback;
        private DaliEventHandler<object, WidgetApplicationEventArgs> _languageChangedEventHandler;

        /// <summary>
        /// LanguageChanged event.
        /// </summary>
        public event DaliEventHandler<object, WidgetApplicationEventArgs> LanguageChanged
        {
            add
            {
                if (_languageChangedEventHandler == null)
                {
                    _languageChangedCallback = new LanguageChangedCallbackType( OnLanguageChanged);
                    LanguageChangedSignal().Connect(_languageChangedCallback);
                }

                _languageChangedEventHandler += value;
            }

            remove
            {
                _languageChangedEventHandler -= value;

                if (_languageChangedEventHandler == null && LanguageChangedSignal().Empty() == false)
                {
                   LanguageChangedSignal().Disconnect(_languageChangedCallback);
                }
            }
        }

        private void OnLanguageChanged(IntPtr widgetApplication)
        {
            WidgetApplicationEventArgs e = new WidgetApplicationEventArgs();

            if (widgetApplication != null)
            {
                e.WidgetApplication = WidgetApplication.GetWidgetApplicationFromPtr(widgetApplication);
            }

            if (_languageChangedEventHandler != null)
            {
                _languageChangedEventHandler(this, e);
            }
        }

        internal AppSignalType LanguageChangedSignal()
        {
            AppSignalType ret = new AppSignalType(NDalicManualPINVOKE.WidgetApplication_LanguageChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void RegionChangedCallbackType(IntPtr widgetApplication);
        private RegionChangedCallbackType _regionChangedCallback;
        private DaliEventHandler<object, WidgetApplicationEventArgs> _regionChangedEventHandler;

        /// <summary>
        /// RegionChanged event.
        /// </summary>
        public event DaliEventHandler<object, WidgetApplicationEventArgs> RegionChanged
        {
            add
            {
                if (_regionChangedEventHandler == null)
                {
                    _regionChangedCallback = new RegionChangedCallbackType( OnRegionChanged );
                    RegionChangedSignal().Connect(_regionChangedCallback);
                }

                _regionChangedEventHandler += value;
            }

            remove
            {
                _regionChangedEventHandler -= value;

                if (_regionChangedEventHandler == null && RegionChangedSignal().Empty() == false)
                {
                   RegionChangedSignal().Disconnect(_regionChangedCallback);
                }
            }
        }

        private void OnRegionChanged(IntPtr widgetApplication)
        {
            WidgetApplicationEventArgs e = new WidgetApplicationEventArgs();

            if (widgetApplication != null)
            {
                e.WidgetApplication = WidgetApplication.GetWidgetApplicationFromPtr(widgetApplication);
            }

            if (_regionChangedEventHandler != null)
            {
                _regionChangedEventHandler(this, e);
            }
        }

        internal AppSignalType RegionChangedSignal()
        {
            AppSignalType ret = new AppSignalType(NDalicManualPINVOKE.WidgetApplication_RegionChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void BatteryLowCallbackType(IntPtr widgetApplication);
        private BatteryLowCallbackType _batteryLowCallback;
        private DaliEventHandler<object, WidgetApplicationEventArgs> _batteryLowEventHandler;

        /// <summary>
        /// BatteryLow event.
        /// </summary>
        public event DaliEventHandler<object, WidgetApplicationEventArgs> BatteryLow
        {
            add
            {
                if (_batteryLowEventHandler == null)
                {
                    _batteryLowCallback = new BatteryLowCallbackType( OnBatteryLow );
                    BatteryLowSignal().Connect(_batteryLowCallback);
                }

                _batteryLowEventHandler += value;
            }

            remove
            {
                _batteryLowEventHandler -= value;

                if (_batteryLowEventHandler == null && BatteryLowSignal().Empty() == false)
                {
                   BatteryLowSignal().Disconnect(_batteryLowCallback);
                }
            }
        }

        private void OnBatteryLow(IntPtr widgetApplication)
        {
            WidgetApplicationEventArgs e = new WidgetApplicationEventArgs();

            if (widgetApplication != null)
            {
                e.WidgetApplication = WidgetApplication.GetWidgetApplicationFromPtr(widgetApplication);
            }

            if (_batteryLowEventHandler != null)
            {
                _batteryLowEventHandler(this, e);
            }
        }

        internal WidgetApplicationLowBatterySignalType BatteryLowSignal()
        {
            WidgetApplicationLowBatterySignalType ret = new WidgetApplicationLowBatterySignalType(NDalicManualPINVOKE.WidgetApplication_LowBatterySignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void MemoryLowCallbackType(IntPtr widgetApplication);
        private MemoryLowCallbackType _memoryLowCallback;
        private DaliEventHandler<object, WidgetApplicationEventArgs> _memoryLowEventHandler;

        /// <summary>
        /// MemoryLow event.
        /// </summary>
        public event DaliEventHandler<object, WidgetApplicationEventArgs> MemoryLow
        {
            add
            {
                if (_memoryLowEventHandler == null)
                {
                    _memoryLowCallback = new MemoryLowCallbackType (OnMemoryLow);
                    MemoryLowSignal().Connect(_memoryLowCallback);
                }

                _memoryLowEventHandler += value;
            }

            remove
            {
                _memoryLowEventHandler -= value;

                if (_memoryLowEventHandler == null && MemoryLowSignal().Empty() == false)
                {
                   MemoryLowSignal().Disconnect(_memoryLowCallback);
                }
            }
        }

        private void OnMemoryLow(IntPtr widgetApplication)
        {
            WidgetApplicationEventArgs e = new WidgetApplicationEventArgs();

            if (widgetApplication != null)
            {
                e.WidgetApplication = WidgetApplication.GetWidgetApplicationFromPtr(widgetApplication);
            }

            if (_memoryLowEventHandler != null)
            {
                _memoryLowEventHandler(this, e);
            }
        }

        internal WidgetApplicationLowMemorySignalType MemoryLowSignal()
        {
            WidgetApplicationLowMemorySignalType ret = new WidgetApplicationLowMemorySignalType(NDalicManualPINVOKE.WidgetApplication_LowMemorySignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private static WidgetApplication _instance; //singleton

    }

}
