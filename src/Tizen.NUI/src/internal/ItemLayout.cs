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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{

    internal class ItemLayout : RefObject
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal ItemLayout(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ItemLayout.ItemLayout_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ItemLayout obj)
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
                    Interop.ItemLayout.delete_ItemLayout(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        public void SetLayoutProperties(PropertyMap properties)
        {
            Interop.ItemLayout.ItemLayout_SetLayoutProperties(swigCPtr, PropertyMap.getCPtr(properties));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PropertyMap GetLayoutProperties()
        {
            PropertyMap ret = new PropertyMap(Interop.ItemLayout.ItemLayout_GetLayoutProperties(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void GetItemSize(uint itemId, Vector3 layoutSize, Vector3 itemSize)
        {
            Interop.ItemLayout.ItemLayout_GetItemSize(swigCPtr, itemId, Vector3.getCPtr(layoutSize), Vector3.getCPtr(itemSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetItemSize(Vector3 itemSize)
        {
            Interop.ItemLayout.ItemLayout_SetItemSize(swigCPtr, Vector3.getCPtr(itemSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual float GetMinimumLayoutPosition(uint numberOfItems, Vector3 layoutSize)
        {
            float ret = Interop.ItemLayout.ItemLayout_GetMinimumLayoutPosition(swigCPtr, numberOfItems, Vector3.getCPtr(layoutSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetClosestAnchorPosition(float layoutPosition)
        {
            float ret = Interop.ItemLayout.ItemLayout_GetClosestAnchorPosition(swigCPtr, layoutPosition);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetItemScrollToPosition(uint itemId)
        {
            float ret = Interop.ItemLayout.ItemLayout_GetItemScrollToPosition(swigCPtr, itemId);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual ItemRange GetItemsWithinArea(float firstItemPosition, Vector3 layoutSize)
        {
            ItemRange ret = new ItemRange(Interop.ItemLayout.ItemLayout_GetItemsWithinArea(swigCPtr, firstItemPosition, Vector3.getCPtr(layoutSize)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetClosestOnScreenLayoutPosition(int itemID, float currentLayoutPosition, Vector3 layoutSize)
        {
            float ret = Interop.ItemLayout.ItemLayout_GetClosestOnScreenLayoutPosition(swigCPtr, itemID, currentLayoutPosition, Vector3.getCPtr(layoutSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual uint GetReserveItemCount(Vector3 layoutSize)
        {
            uint ret = Interop.ItemLayout.ItemLayout_GetReserveItemCount(swigCPtr, Vector3.getCPtr(layoutSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void GetDefaultItemSize(uint itemId, Vector3 layoutSize, Vector3 itemSize)
        {
            Interop.ItemLayout.ItemLayout_GetDefaultItemSize(swigCPtr, itemId, Vector3.getCPtr(layoutSize), Vector3.getCPtr(itemSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual Degree GetScrollDirection()
        {
            Degree ret = new Degree(Interop.ItemLayout.ItemLayout_GetScrollDirection(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetScrollSpeedFactor()
        {
            float ret = Interop.ItemLayout.ItemLayout_GetScrollSpeedFactor(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetMaximumSwipeSpeed()
        {
            float ret = Interop.ItemLayout.ItemLayout_GetMaximumSwipeSpeed(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetItemFlickAnimationDuration()
        {
            float ret = Interop.ItemLayout.ItemLayout_GetItemFlickAnimationDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual int GetNextFocusItemID(int itemID, int maxItems, View.FocusDirection direction, bool loopEnabled)
        {
            int ret = Interop.ItemLayout.ItemLayout_GetNextFocusItemID(swigCPtr, itemID, maxItems, (int)direction, loopEnabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetFlickSpeedFactor()
        {
            float ret = Interop.ItemLayout.ItemLayout_GetFlickSpeedFactor(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void ApplyConstraints(View view, int itemId, Vector3 layoutSize, View itemView)
        {
            Interop.ItemLayout.ItemLayout_ApplyConstraints(swigCPtr, View.getCPtr(view), itemId, Vector3.getCPtr(layoutSize), View.getCPtr(itemView));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual Vector3 GetItemPosition(int itemID, float currentLayoutPosition, Vector3 layoutSize)
        {
            Vector3 ret = new Vector3(Interop.ItemLayout.ItemLayout_GetItemPosition(swigCPtr, itemID, currentLayoutPosition, Vector3.getCPtr(layoutSize)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
