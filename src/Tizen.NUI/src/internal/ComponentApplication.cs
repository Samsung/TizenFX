using System;
using System.Collections.Generic;
using System.Text;
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
            _instance = ret;
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
        private CreateNativeEventHandler _applicationCreateNativeEventHandler;
        private NUIComponentApplicationCreatenativeEventCallbackDelegate _applicationCreateNativeEventCallbackDelegate;


        /**
          * @brief Event for Initialized signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Initialized signal is emitted when application is initialised
          */
        public event CreateNativeEventHandler CreateNative
        {
            add
            {
                // Restricted to only one listener
                if (_applicationCreateNativeEventHandler == null)
                {
                    _applicationCreateNativeEventHandler += value;

                    _applicationCreateNativeEventCallbackDelegate = new NUIComponentApplicationCreatenativeEventCallbackDelegate(OnApplicationCreateNative);
                    Connect(_applicationCreateNativeEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationCreateNativeEventHandler != null)
                {
                    Disconnect(_applicationCreateNativeEventCallbackDelegate);
                }

                _applicationCreateNativeEventHandler -= value;
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
            IntPtr handle = IntPtr.Zero;

            if (_applicationCreateNativeEventHandler != null)
            {
                handle = _applicationCreateNativeEventHandler.Invoke();
            }

            return handle;
        }

    }


}
