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

namespace Tizen.NUI
{

    using System;
    using System.Runtime.InteropServices;


    internal class ObjectRegistry : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal ObjectRegistry(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.ObjectRegistry_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ObjectRegistry obj)
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

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_ObjectRegistry(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        /// <since_tizen> 3 </since_tizen>
        public class ObjectCreatedEventArgs : EventArgs
        {
            private BaseHandle _baseHandle;

            /// <since_tizen> 3 </since_tizen>
            public BaseHandle BaseHandle
            {
                get
                {
                    return _baseHandle;
                }
                set
                {
                    _baseHandle = value;
                }
            }
        }

        /// <since_tizen> 3 </since_tizen>
        public class ObjectDestroyedEventArgs : EventArgs
        {
            private RefObject _refObject;

            /// <since_tizen> 3 </since_tizen>
            public RefObject RefObject
            {
                get
                {
                    return _refObject;
                }
                set
                {
                    _refObject = value;
                }
            }
        }


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ObjectCreatedEventCallbackDelegate(IntPtr baseHandle);
        private DaliEventHandler<object, ObjectCreatedEventArgs> _objectRegistryObjectCreatedEventHandler;
        private ObjectCreatedEventCallbackDelegate _objectRegistryObjectCreatedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ObjectDestroyedEventCallbackDelegate(IntPtr fefObject);
        private DaliEventHandler<object, ObjectDestroyedEventArgs> _objectRegistryObjectDestroyedEventHandler;
        private ObjectDestroyedEventCallbackDelegate _objectRegistryObjectDestroyedEventCallbackDelegate;

        public event DaliEventHandler<object, ObjectCreatedEventArgs> ObjectCreated
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_objectRegistryObjectCreatedEventHandler == null)
                    {
                        _objectRegistryObjectCreatedEventHandler += value;

                        _objectRegistryObjectCreatedEventCallbackDelegate = new ObjectCreatedEventCallbackDelegate(OnObjectCreated);
                        this.ObjectCreatedSignal().Connect(_objectRegistryObjectCreatedEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_objectRegistryObjectCreatedEventHandler != null)
                    {
                        this.ObjectCreatedSignal().Disconnect(_objectRegistryObjectCreatedEventCallbackDelegate);
                    }

                    _objectRegistryObjectCreatedEventHandler -= value;
                }
            }
        }

        // Callback for ObjectRegistry ObjectCreatedSignal
        private void OnObjectCreated(IntPtr baseHandle)
        {
            ObjectCreatedEventArgs e = new ObjectCreatedEventArgs();

            // Populate all members of "e" (ObjectCreatedEventArgs) with real data
            //e.BaseHandle = BaseHandle.GetBaseHandleFromPtr(baseHandle); //GetBaseHandleFromPtr() is not present in BaseHandle.cs. Not sure what is the reason?

            if (_objectRegistryObjectCreatedEventHandler != null)
            {
                //here we send all data to user event handlers
                _objectRegistryObjectCreatedEventHandler(this, e);
            }
        }

        public event DaliEventHandler<object, ObjectDestroyedEventArgs> ObjectDestroyed
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_objectRegistryObjectDestroyedEventHandler == null)
                    {
                        _objectRegistryObjectDestroyedEventHandler += value;

                        _objectRegistryObjectDestroyedEventCallbackDelegate = new ObjectDestroyedEventCallbackDelegate(OnObjectDestroyed);
                        this.ObjectDestroyedSignal().Connect(_objectRegistryObjectDestroyedEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_objectRegistryObjectDestroyedEventHandler != null)
                    {
                        this.ObjectDestroyedSignal().Disconnect(_objectRegistryObjectDestroyedEventCallbackDelegate);
                    }

                    _objectRegistryObjectDestroyedEventHandler -= value;
                }
            }
        }

        // Callback for ObjectRegistry ObjectDestroyedSignal
        private void OnObjectDestroyed(IntPtr refObject)
        {
            ObjectDestroyedEventArgs e = new ObjectDestroyedEventArgs();

            // Populate all members of "e" (ObjectDestroyedEventArgs) with real data
            e.RefObject = RefObject.GetRefObjectFromPtr(refObject);

            if (_objectRegistryObjectDestroyedEventHandler != null)
            {
                //here we send all data to user event handlers
                _objectRegistryObjectDestroyedEventHandler(this, e);
            }
        }


        public ObjectRegistry() : this(NDalicPINVOKE.new_ObjectRegistry__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ObjectRegistry(ObjectRegistry handle) : this(NDalicPINVOKE.new_ObjectRegistry__SWIG_1(ObjectRegistry.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ObjectRegistry Assign(ObjectRegistry rhs)
        {
            ObjectRegistry ret = new ObjectRegistry(NDalicPINVOKE.ObjectRegistry_Assign(swigCPtr, ObjectRegistry.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public ObjectCreatedSignal ObjectCreatedSignal()
        {
            ObjectCreatedSignal ret = new ObjectCreatedSignal(NDalicPINVOKE.ObjectRegistry_ObjectCreatedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public ObjectDestroyedSignal ObjectDestroyedSignal()
        {
            ObjectDestroyedSignal ret = new ObjectDestroyedSignal(NDalicPINVOKE.ObjectRegistry_ObjectDestroyedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
