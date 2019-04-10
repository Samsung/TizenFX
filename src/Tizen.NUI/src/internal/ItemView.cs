/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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

    using System;
    using System.Runtime.InteropServices;


    internal class ItemView : Scrollable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal ItemView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ItemView.ItemView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ItemView obj)
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
                    Interop.ItemView.delete_ItemView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        public new Tizen.NUI.PropertyArray Layout
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                GetProperty(ItemView.Property.LAYOUT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.LAYOUT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <since_tizen> 3 </since_tizen>
        public new class Property
        {
            /// <since_tizen> 3 </since_tizen>
            public static readonly int LAYOUT = Interop.ItemView.ItemView_Property_LAYOUT_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int MINIMUM_SWIPE_SPEED = Interop.ItemView.ItemView_Property_MINIMUM_SWIPE_SPEED_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int MINIMUM_SWIPE_DISTANCE = Interop.ItemView.ItemView_Property_MINIMUM_SWIPE_DISTANCE_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int WHEEL_SCROLL_DISTANCE_STEP = Interop.ItemView.ItemView_Property_WHEEL_SCROLL_DISTANCE_STEP_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SNAP_TO_ITEM_ENABLED = Interop.ItemView.ItemView_Property_SNAP_TO_ITEM_ENABLED_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int REFRESH_INTERVAL = Interop.ItemView.ItemView_Property_REFRESH_INTERVAL_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int LAYOUT_POSITION = Interop.ItemView.ItemView_Property_LAYOUT_POSITION_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_SPEED = Interop.ItemView.ItemView_Property_SCROLL_SPEED_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int OVERSHOOT = Interop.ItemView.ItemView_Property_OVERSHOOT_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_DIRECTION = Interop.ItemView.ItemView_Property_SCROLL_DIRECTION_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int LAYOUT_ORIENTATION = Interop.ItemView.ItemView_Property_LAYOUT_ORIENTATION_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_CONTENT_SIZE = Interop.ItemView.ItemView_Property_SCROLL_CONTENT_SIZE_get();
        }

        public ItemView(ItemFactory factory) : this(Interop.ItemView.ItemView_New(ItemFactory.getCPtr(factory)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();

        }

        internal static ItemView DownCast(BaseHandle handle)
        {
            ItemView ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as ItemView;
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetLayoutCount()
        {
            uint ret = Interop.ItemView.ItemView_GetLayoutCount(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void AddLayout(ItemLayout layout)
        {
            Interop.ItemView.ItemView_AddLayout(swigCPtr, ItemLayout.getCPtr(layout));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void RemoveLayout(uint layoutIndex)
        {
            Interop.ItemView.ItemView_RemoveLayout(swigCPtr, layoutIndex);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t GetLayout(uint layoutIndex)
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t(Interop.ItemView.ItemView_GetLayout(swigCPtr, layoutIndex), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t GetActiveLayout()
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t(Interop.ItemView.ItemView_GetActiveLayout(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float GetCurrentLayoutPosition(uint itemId)
        {
            float ret = Interop.ItemView.ItemView_GetCurrentLayoutPosition(swigCPtr, itemId);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void ActivateLayout(uint layoutIndex, Vector3 targetSize, float durationSeconds)
        {
            Interop.ItemView.ItemView_ActivateLayout(swigCPtr, layoutIndex, Vector3.getCPtr(targetSize), durationSeconds);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void DeactivateCurrentLayout()
        {
            Interop.ItemView.ItemView_DeactivateCurrentLayout(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void SetMinimumSwipeSpeed(float speed)
        {
            Interop.ItemView.ItemView_SetMinimumSwipeSpeed(swigCPtr, speed);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public float GetMinimumSwipeSpeed()
        {
            float ret = Interop.ItemView.ItemView_GetMinimumSwipeSpeed(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetMinimumSwipeDistance(float distance)
        {
            Interop.ItemView.ItemView_SetMinimumSwipeDistance(swigCPtr, distance);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public float GetMinimumSwipeDistance()
        {
            float ret = Interop.ItemView.ItemView_GetMinimumSwipeDistance(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetWheelScrollDistanceStep(float step)
        {
            Interop.ItemView.ItemView_SetWheelScrollDistanceStep(swigCPtr, step);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public float GetWheelScrollDistanceStep()
        {
            float ret = Interop.ItemView.ItemView_GetWheelScrollDistanceStep(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetAnchoring(bool enabled)
        {
            Interop.ItemView.ItemView_SetAnchoring(swigCPtr, enabled);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public bool GetAnchoring()
        {
            bool ret = Interop.ItemView.ItemView_GetAnchoring(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetAnchoringDuration(float durationSeconds)
        {
            Interop.ItemView.ItemView_SetAnchoringDuration(swigCPtr, durationSeconds);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public float GetAnchoringDuration()
        {
            float ret = Interop.ItemView.ItemView_GetAnchoringDuration(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void ScrollToItem(uint itemId, float durationSeconds)
        {
            Interop.ItemView.ItemView_ScrollToItem(swigCPtr, itemId, durationSeconds);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void SetRefreshInterval(float intervalLayoutPositions)
        {
            Interop.ItemView.ItemView_SetRefreshInterval(swigCPtr, intervalLayoutPositions);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public float GetRefreshInterval()
        {
            float ret = Interop.ItemView.ItemView_GetRefreshInterval(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Refresh()
        {
            Interop.ItemView.ItemView_Refresh(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public View GetItem(uint itemId)
        {
            View ret = new View(Interop.ItemView.ItemView_GetItem(swigCPtr, itemId), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetItemId(View view)
        {
            uint ret = Interop.ItemView.ItemView_GetItemId(swigCPtr, View.getCPtr(view));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void InsertItem(Item newItem, float durationSeconds)
        {
            Interop.ItemView.ItemView_InsertItem(swigCPtr, Item.getCPtr(newItem), durationSeconds);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void InsertItems(ItemContainer newItems, float durationSeconds)
        {
            Interop.ItemView.ItemView_InsertItems(swigCPtr, ItemContainer.getCPtr(newItems), durationSeconds);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void RemoveItem(uint itemId, float durationSeconds)
        {
            Interop.ItemView.ItemView_RemoveItem(swigCPtr, itemId, durationSeconds);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void RemoveItems(ItemIdContainer itemIds, float durationSeconds)
        {
            Interop.ItemView.ItemView_RemoveItems(swigCPtr, ItemIdContainer.getCPtr(itemIds), durationSeconds);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void ReplaceItem(Item replacementItem, float durationSeconds)
        {
            Interop.ItemView.ItemView_ReplaceItem(swigCPtr, Item.getCPtr(replacementItem), durationSeconds);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void ReplaceItems(ItemContainer replacementItems, float durationSeconds)
        {
            Interop.ItemView.ItemView_ReplaceItems(swigCPtr, ItemContainer.getCPtr(replacementItems), durationSeconds);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void SetItemsParentOrigin(Vector3 parentOrigin)
        {
            Interop.ItemView.ItemView_SetItemsParentOrigin(swigCPtr, Vector3.getCPtr(parentOrigin));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public Vector3 GetItemsParentOrigin()
        {
            Vector3 ret = new Vector3(Interop.ItemView.ItemView_GetItemsParentOrigin(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetItemsAnchorPoint(Vector3 anchorPoint)
        {
            Interop.ItemView.ItemView_SetItemsAnchorPoint(swigCPtr, Vector3.getCPtr(anchorPoint));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public Vector3 GetItemsAnchorPoint()
        {
            Vector3 ret = new Vector3(Interop.ItemView.ItemView_GetItemsAnchorPoint(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void GetItemsRange(ItemRange range)
        {
            Interop.ItemView.ItemView_GetItemsRange(swigCPtr, ItemRange.getCPtr(range));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public VoidSignal LayoutActivatedSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.ItemView.ItemView_LayoutActivatedSignal(swigCPtr), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public float MinimumSwipeSpeed
        {
            get
            {
                float temp = 0.0f;
                GetProperty(ItemView.Property.MINIMUM_SWIPE_SPEED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.MINIMUM_SWIPE_SPEED, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float MinimumSwipeDistance
        {
            get
            {
                float temp = 0.0f;
                GetProperty(ItemView.Property.MINIMUM_SWIPE_DISTANCE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.MINIMUM_SWIPE_DISTANCE, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float WheelScrollDistanceStep
        {
            get
            {
                float temp = 0.0f;
                GetProperty(ItemView.Property.WHEEL_SCROLL_DISTANCE_STEP).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.WHEEL_SCROLL_DISTANCE_STEP, new Tizen.NUI.PropertyValue(value));
            }
        }
        public bool SnapToItemEnabled
        {
            get
            {
                bool temp = false;
                GetProperty(ItemView.Property.SNAP_TO_ITEM_ENABLED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.SNAP_TO_ITEM_ENABLED, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float RefreshInterval
        {
            get
            {
                float temp = 0.0f;
                GetProperty(ItemView.Property.REFRESH_INTERVAL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.REFRESH_INTERVAL, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float LayoutPosition
        {
            get
            {
                float temp = 0.0f;
                GetProperty(ItemView.Property.LAYOUT_POSITION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.LAYOUT_POSITION, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float ScrollSpeed
        {
            get
            {
                float temp = 0.0f;
                GetProperty(ItemView.Property.SCROLL_SPEED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.SCROLL_SPEED, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float Overshoot
        {
            get
            {
                float temp = 0.0f;
                GetProperty(ItemView.Property.OVERSHOOT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.OVERSHOOT, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 ScrollDirection
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(ItemView.Property.SCROLL_DIRECTION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.SCROLL_DIRECTION, new Tizen.NUI.PropertyValue(value));
            }
        }
        public int LayoutOrientation
        {
            get
            {
                int temp = 0;
                GetProperty(ItemView.Property.LAYOUT_ORIENTATION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.LAYOUT_ORIENTATION, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float ScrollContentSize
        {
            get
            {
                float temp = 0.0f;
                GetProperty(ItemView.Property.SCROLL_CONTENT_SIZE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ItemView.Property.SCROLL_CONTENT_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }

    }

}
