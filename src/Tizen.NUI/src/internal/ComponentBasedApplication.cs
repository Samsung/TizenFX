using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    class ComponentApplication : Application
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private static ComponentApplication _instance; //singleton

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
                    Interop.ComponentApplication.delete_ComponentBasedApplication(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        public new static ComponentApplication Instance
        {
            get
            {
                return _instance;
            }
        }

        public static ComponentApplication NewComponentBasedApplication(string[] args, string stylesheet)
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

            IntPtr widgetIntPtr = Interop.ComponentApplication.ComponentBasedApplication_New(argc, argvStr, stylesheet);

            ComponentApplication ret = new ComponentApplication(widgetIntPtr, false);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        internal ComponentApplication(ComponentApplication componentBasedApplication) : this(Interop.ComponentApplication.new_ComponentBasedApplication__SWIG_1(ComponentApplication.getCPtr(componentBasedApplication)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ComponentApplication Assign(ComponentApplication componentBasedApplication)
        {
            ComponentApplication ret = new ComponentApplication(Interop.ComponentApplication.ComponentBasedApplication_Assign(swigCPtr, ComponentApplication.getCPtr(componentBasedApplication)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

		
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr NUIComponentBasedApplicationCreatenativeEventCallbackDelegate(IntPtr data);

		public delegate IntPtr CreateNativeEventHandler(IntPtr data);
		private CreateNativeEventHandler _applicationCreateNativeEventHandler;
        private NUIComponentBasedApplicationCreatenativeEventCallbackDelegate _applicationCreateNativeEventCallbackDelegate;
		

        /**
          * @brief Event for Initialized signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Initialized signal is emitted when application is initialised
          */
        public event CreateNativeEventHandler CreateNative
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationCreateNativeEventHandler == null)
                    {
                        _applicationCreateNativeEventHandler += value;

                        _applicationCreateNativeEventCallbackDelegate = new NUIComponentBasedApplicationCreatenativeEventCallbackDelegate(OnApplicationCreateNative);
                        Connect(_applicationCreateNativeEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationCreateNativeEventHandler != null)
                    {
                        Disconnect(_applicationCreateNativeEventCallbackDelegate);
                    }

                    _applicationCreateNativeEventHandler -= value;
                }
            }
        }


        public void Connect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(func);
            {
                Interop.ComponentApplication.ComponentApplication_CreateNativeSignal_Connect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
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
                Interop.ComponentApplication.ComponentApplication_CreateNativeSignal_Disconnect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                {
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        internal ApplicationSignal CreateNativeSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(Interop.ComponentApplication.ComponentApplication_CreateNativeSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
		

		
		// Callback for Application InitSignal
		private IntPtr OnApplicationCreateNative(IntPtr data)
        {
            Tizen.Log.Error("MYLOG", "CBA.OnApplicationCreateNative");
            IntPtr ptr = IntPtr.Zero;
		
			if (_applicationCreateNativeEventHandler != null)
			{
				ptr = _applicationCreateNativeEventHandler.Invoke(data);
			}
            Tizen.Log.Error("MYLOG", "ptr: " + ptr);
		    return ptr;
		}

		
    }

	
}
