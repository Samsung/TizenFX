/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;
using System.Reflection;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ItemFactory : Disposable
    {

        internal ItemFactory(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ItemFactory obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ItemFactory.DeleteItemFactory(swigCPtr);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual uint GetNumberOfItems()
        {
            uint ret = Interop.ItemFactory.ItemFactoryGetNumberOfItems(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual View NewItem(uint itemId)
        {
            View ret = new View(Interop.ItemFactory.ItemFactoryNewItem(swigCPtr, itemId), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ItemReleased(uint itemId, View view)
        {
            if (DerivedClassHasMethod("ItemReleased", methodTypes2)) Interop.ItemFactory.ItemFactoryItemReleasedSwigExplicitItemFactory(swigCPtr, itemId, View.getCPtr(view)); else Interop.ItemFactory.ItemFactoryItemReleased(swigCPtr, itemId, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemFactory() : this(Interop.ItemFactory.NewItemFactory(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            DirectorConnect();
        }

        private void DirectorConnect()
        {
            if (DerivedClassHasMethod("GetNumberOfItems", methodTypes0))
                swigDelegate0 = new DelegateItemFactory0(DirectorGetNumberOfItems);
            if (DerivedClassHasMethod("NewItem", methodTypes1))
                swigDelegate1 = new DelegateItemFactory1(DirectorNewItem);
            if (DerivedClassHasMethod("ItemReleased", methodTypes2))
                swigDelegate2 = new DelegateItemFactory2(DirectorItemReleased);
            Interop.ItemFactory.ItemFactoryDirectorConnect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
        }

        private bool DerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, methodTypes);
            bool hasDerivedMethod = this.GetType().GetTypeInfo().IsSubclassOf(typeof(ItemFactory));
            NUILog.Debug("hasDerivedMethod=" + hasDerivedMethod);
            return hasDerivedMethod && (methodInfo != null);
        }

        private uint DirectorGetNumberOfItems()
        {
            return GetNumberOfItems();
        }

        private global::System.IntPtr DirectorNewItem(uint itemId)
        {
            return View.getCPtr(NewItem(itemId)).Handle;
        }

        private void DirectorItemReleased(uint itemId, global::System.IntPtr actor)
        {
            ItemReleased(itemId, new View(actor, true));
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate uint DelegateItemFactory0();

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate global::System.IntPtr DelegateItemFactory1(uint itemId);

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void DelegateItemFactory2(uint itemId, global::System.IntPtr actor);

        private DelegateItemFactory0 swigDelegate0;
        private DelegateItemFactory1 swigDelegate1;
        private DelegateItemFactory2 swigDelegate2;

        private static global::System.Type[] methodTypes0 = new global::System.Type[] { };
        private static global::System.Type[] methodTypes1 = new global::System.Type[] { typeof(uint) };
        private static global::System.Type[] methodTypes2 = new global::System.Type[] { typeof(uint), typeof(View) };
    }
}
