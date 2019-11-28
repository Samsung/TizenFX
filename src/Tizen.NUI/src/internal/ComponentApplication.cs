using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    class ComponentApplication : Application
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private List<NUIFrameComponent> _frameComponentList;
        private static ComponentApplication _instance; //singleton

        internal ComponentApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            _frameComponentList = new List<NUIFrameComponent>();
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
                    Interop.ComponentApplication.delete_ComponentApplication(swigCPtr);
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

            IntPtr widgetIntPtr = Interop.ComponentApplication.ComponentApplication_New(argc, argvStr, stylesheet);

            ComponentApplication ret = new ComponentApplication(widgetIntPtr, false);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        internal ComponentApplication(ComponentApplication componentApplication) : this(Interop.ComponentApplication.new_ComponentApplication__SWIG_1(ComponentApplication.getCPtr(componentApplication)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ComponentApplication Assign(ComponentApplication componentApplication)
        {
            ComponentApplication ret = new ComponentApplication(Interop.ComponentApplication.ComponentApplication_Assign(swigCPtr, ComponentApplication.getCPtr(componentApplication)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

		
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr NUIComponentApplicationCreatenativeEventCallbackDelegate(IntPtr data);

		public delegate IntPtr CreateNativeEventHandler(IntPtr data);
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
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationCreateNativeEventHandler == null)
                    {
                        _applicationCreateNativeEventHandler += value;

                        _applicationCreateNativeEventCallbackDelegate = new NUIComponentApplicationCreatenativeEventCallbackDelegate(OnApplicationCreateNative);
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
            IntPtr ptr = IntPtr.Zero;
		
			if (_applicationCreateNativeEventHandler != null)
			{
				ptr = _applicationCreateNativeEventHandler.Invoke(data);
			}
		    return ptr;
		}

        internal void RegisterFrameComponent(NUIFrameComponent nuiFrameComponent)
        {
            _frameComponentList.Add(nuiFrameComponent);
        }

        internal int GetFrameComponentCount()
        {
            return _frameComponentList.Count;
        }


    }


}
