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
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
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
            uint ret = Interop.ItemFactory.GetNumberOfItems(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual View NewItem(uint itemId)
        {
            View ret = new View(Interop.ItemFactory.NewItem(SwigCPtr, itemId), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ItemReleased(uint itemId, View view)
        {
            if (SwigDerivedClassHasMethod("ItemReleased", swigMethodTypes2)) Interop.ItemFactory.ItemReleasedSwigExplicitItemFactory(SwigCPtr, itemId, View.getCPtr(view)); else Interop.ItemFactory.ItemReleased(SwigCPtr, itemId, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemFactory() : this(Interop.ItemFactory.NewItemFactory(), true)
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
            Interop.ItemFactory.DirectorConnect(SwigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate uint SwigDelegateItemFactory_0();

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate global::System.IntPtr SwigDelegateItemFactory_1(uint itemId);

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SwigDelegateItemFactory_2(uint itemId, global::System.IntPtr actor);

        private SwigDelegateItemFactory_0 swigDelegate0;
        private SwigDelegateItemFactory_1 swigDelegate1;
        private SwigDelegateItemFactory_2 swigDelegate2;

        private static global::System.Type[] swigMethodTypes0 = System.Array.Empty<global::System.Type>();
        private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(uint) };
        private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(uint), typeof(View) };
    }
}
