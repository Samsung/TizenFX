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
    internal class ObjectRegistry : BaseHandle
    {
        internal ObjectRegistry(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ObjectRegistry obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ObjectRegistry.DeleteObjectRegistry(swigCPtr);
        }

        public class ObjectCreatedEventArgs : EventArgs
        {
            private BaseHandle baseHandle;

            public BaseHandle BaseHandle
            {
                get
                {
                    return baseHandle;
                }
                set
                {
                    baseHandle = value;
                }
            }
        }

        public class ObjectDestroyedEventArgs : EventArgs
        {
            private RefObject refObject;

            public RefObject RefObject
            {
                get
                {
                    return refObject;
                }
                set
                {
                    refObject = value;
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ObjectCreatedEventCallbackDelegate(IntPtr baseHandle);
        private DaliEventHandler<object, ObjectCreatedEventArgs> objectRegistryObjectCreatedEventHandler;
        private ObjectCreatedEventCallbackDelegate objectRegistryObjectCreatedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ObjectDestroyedEventCallbackDelegate(IntPtr fefObject);
        private DaliEventHandler<object, ObjectDestroyedEventArgs> objectRegistryObjectDestroyedEventHandler;
        private ObjectDestroyedEventCallbackDelegate objectRegistryObjectDestroyedEventCallbackDelegate;

        public event DaliEventHandler<object, ObjectCreatedEventArgs> ObjectCreated
        {
            add
            {
                // Restricted to only one listener
                if (objectRegistryObjectCreatedEventHandler == null)
                {
                    objectRegistryObjectCreatedEventHandler += value;

                    objectRegistryObjectCreatedEventCallbackDelegate = new ObjectCreatedEventCallbackDelegate(OnObjectCreated);
                    this.ObjectCreatedSignal().Connect(objectRegistryObjectCreatedEventCallbackDelegate);
                }
            }

            remove
            {
                if (objectRegistryObjectCreatedEventHandler != null)
                {
                    this.ObjectCreatedSignal().Disconnect(objectRegistryObjectCreatedEventCallbackDelegate);
                }

                objectRegistryObjectCreatedEventHandler -= value;
            }
        }

        // Callback for ObjectRegistry ObjectCreatedSignal
        private void OnObjectCreated(IntPtr baseHandle)
        {
            ObjectCreatedEventArgs e = new ObjectCreatedEventArgs();

            // Populate all members of "e" (ObjectCreatedEventArgs) with real data
            //e.BaseHandle = BaseHandle.GetBaseHandleFromPtr(baseHandle); //GetBaseHandleFromPtr() is not present in BaseHandle.cs. Not sure what is the reason?

            if (objectRegistryObjectCreatedEventHandler != null)
            {
                //here we send all data to user event handlers
                objectRegistryObjectCreatedEventHandler(this, e);
            }
        }

        public event DaliEventHandler<object, ObjectDestroyedEventArgs> ObjectDestroyed
        {
            add
            {
                // Restricted to only one listener
                if (objectRegistryObjectDestroyedEventHandler == null)
                {
                    objectRegistryObjectDestroyedEventHandler += value;

                    objectRegistryObjectDestroyedEventCallbackDelegate = new ObjectDestroyedEventCallbackDelegate(OnObjectDestroyed);
                    this.ObjectDestroyedSignal().Connect(objectRegistryObjectDestroyedEventCallbackDelegate);
                }
            }

            remove
            {
                if (objectRegistryObjectDestroyedEventHandler != null)
                {
                    this.ObjectDestroyedSignal().Disconnect(objectRegistryObjectDestroyedEventCallbackDelegate);
                }

                objectRegistryObjectDestroyedEventHandler -= value;
            }
        }

        // Callback for ObjectRegistry ObjectDestroyedSignal
        private void OnObjectDestroyed(IntPtr refObject)
        {
            ObjectDestroyedEventArgs e = new ObjectDestroyedEventArgs();

            // Populate all members of "e" (ObjectDestroyedEventArgs) with real data
            e.RefObject = RefObject.GetRefObjectFromPtr(refObject);

            if (objectRegistryObjectDestroyedEventHandler != null)
            {
                //here we send all data to user event handlers
                objectRegistryObjectDestroyedEventHandler(this, e);
            }
        }


        public ObjectRegistry() : this(Interop.ObjectRegistry.NewObjectRegistry(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ObjectRegistry(ObjectRegistry handle) : this(Interop.ObjectRegistry.NewObjectRegistry(ObjectRegistry.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ObjectRegistry Assign(ObjectRegistry rhs)
        {
            ObjectRegistry ret = new ObjectRegistry(Interop.ObjectRegistry.Assign(SwigCPtr, ObjectRegistry.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public ObjectCreatedSignal ObjectCreatedSignal()
        {
            ObjectCreatedSignal ret = new ObjectCreatedSignal(Interop.ObjectRegistry.ObjectCreatedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public ObjectDestroyedSignal ObjectDestroyedSignal()
        {
            ObjectDestroyedSignal ret = new ObjectDestroyedSignal(Interop.ObjectRegistry.ObjectDestroyedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
