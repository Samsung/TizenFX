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

using System.Reflection;

namespace Tizen.NUI
{
    using Tizen.NUI.BaseComponents;
    internal class ItemFactory : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal ItemFactory(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ItemFactory obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;


        ~ItemFactory()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
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
                    NDalicPINVOKE.delete_ItemFactory(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }

        public virtual uint GetNumberOfItems()
        {
            uint ret = NDalicPINVOKE.ItemFactory_GetNumberOfItems(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual View NewItem(uint itemId)
        {
            View ret = new View(NDalicPINVOKE.ItemFactory_NewItem(swigCPtr, itemId), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void ItemReleased(uint itemId, View view)
        {
            if (SwigDerivedClassHasMethod("ItemReleased", swigMethodTypes2)) NDalicPINVOKE.ItemFactory_ItemReleasedSwigExplicitItemFactory(swigCPtr, itemId, View.getCPtr(view)); else NDalicPINVOKE.ItemFactory_ItemReleased(swigCPtr, itemId, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ItemFactory() : this(NDalicPINVOKE.new_ItemFactory(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SwigDirectorConnect();
        }

        private void SwigDirectorConnect()
        {
            if (SwigDerivedClassHasMethod("GetNumberOfItems", swigMethodTypes0))
                swigDelegate0 = new SwigDelegateItemFactory_0(SwigDirectorGetNumberOfItems);
            if (SwigDerivedClassHasMethod("NewItem", swigMethodTypes1))
                swigDelegate1 = new SwigDelegateItemFactory_1(SwigDirectorNewItem);
            if (SwigDerivedClassHasMethod("ItemReleased", swigMethodTypes2))
                swigDelegate2 = new SwigDelegateItemFactory_2(SwigDirectorItemReleased);
            NDalicPINVOKE.ItemFactory_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
        }

        private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, methodTypes);
            bool hasDerivedMethod = this.GetType().GetTypeInfo().IsSubclassOf(typeof(ItemFactory));
            NUILog.Debug("hasDerivedMethod=" + hasDerivedMethod);
            return hasDerivedMethod && (methodInfo != null);
        }

        private uint SwigDirectorGetNumberOfItems()
        {
            return GetNumberOfItems();
        }

        private global::System.IntPtr SwigDirectorNewItem(uint itemId)
        {
            return View.getCPtr(NewItem(itemId)).Handle;
        }

        private void SwigDirectorItemReleased(uint itemId, global::System.IntPtr actor)
        {
            ItemReleased(itemId, new View(actor, true));
        }

        /// <since_tizen> 3 </since_tizen>
        public delegate uint SwigDelegateItemFactory_0();
        /// <since_tizen> 3 </since_tizen>
        public delegate global::System.IntPtr SwigDelegateItemFactory_1(uint itemId);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateItemFactory_2(uint itemId, global::System.IntPtr actor);

        private SwigDelegateItemFactory_0 swigDelegate0;
        private SwigDelegateItemFactory_1 swigDelegate1;
        private SwigDelegateItemFactory_2 swigDelegate2;

        private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(uint) };
        private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(uint), typeof(View) };
    }

}
