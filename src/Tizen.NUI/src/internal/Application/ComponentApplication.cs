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
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    class ComponentApplication : Application
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal ComponentApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ComponentApplication obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

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
                    Interop.ComponentApplication.DeleteComponentApplication(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        public static ComponentApplication NewComponentApplication(string[] args, string stylesheet)
        {
            ComponentApplication ret = New(args, stylesheet);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            instance = ret;
            return ret;
        }

        public static ComponentApplication New(string[] args, string stylesheet)
        {
            int argc = args.Length;
            string argvStr = string.Join(" ", args);

            IntPtr widgetIntPtr = Interop.ComponentApplication.New(argc, argvStr, stylesheet);

            ComponentApplication ret = new ComponentApplication(widgetIntPtr, false);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        internal ComponentApplication(ComponentApplication componentApplication) : this(Interop.ComponentApplication.NewComponentApplication(ComponentApplication.getCPtr(componentApplication)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ComponentApplication Assign(ComponentApplication componentApplication)
        {
            ComponentApplication ret = new ComponentApplication(Interop.ComponentApplication.Assign(swigCPtr, ComponentApplication.getCPtr(componentApplication)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr NUIComponentApplicationCreatenativeEventCallbackDelegate();

        public delegate IntPtr CreateNativeEventHandler();
        private CreateNativeEventHandler applicationCreateNativeEventHandler;
        private NUIComponentApplicationCreatenativeEventCallbackDelegate applicationCreateNativeEventCallbackDelegate;

        /**
          * @brief Event for Initialized signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Initialized signal is emitted when application is initialized
          */
        public event CreateNativeEventHandler CreateNative
        {
            add
            {
                // Restricted to only one listener
                if (applicationCreateNativeEventHandler == null)
                {
                    applicationCreateNativeEventHandler += value;

                    applicationCreateNativeEventCallbackDelegate = new NUIComponentApplicationCreatenativeEventCallbackDelegate(OnApplicationCreateNative);
                    Connect(applicationCreateNativeEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationCreateNativeEventHandler != null)
                {
                    Disconnect(applicationCreateNativeEventCallbackDelegate);
                }

                applicationCreateNativeEventHandler -= value;
            }
        }


        public void Connect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(func);
            {
                Interop.ComponentApplication.CreateNativeSignalConnect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                {
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        public void Disconnect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.ComponentApplication.CreateNativeSignalDisconnect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                {
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        internal ApplicationSignal CreateNativeSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(Interop.ComponentApplication.CreateNativeSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        // Callback for Application InitSignal
        private IntPtr OnApplicationCreateNative()
        {
            return applicationCreateNativeEventHandler?.Invoke() ?? IntPtr.Zero;
        }
    }
}
