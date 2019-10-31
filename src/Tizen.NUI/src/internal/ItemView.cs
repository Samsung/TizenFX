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

using System;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ItemView : Scrollable
    {

        internal ItemView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ItemView.ItemView_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ItemView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ItemView.delete_ItemView(swigCPtr);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Property for ItemView. This is internal use only, so not recommended to use. Need to use ItemView's properties.
        /// </summary>
        [Obsolete("Deprecated in API6; Will be removed in API9.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new class Property
        {
            /// <summary>
            /// LAYOUT. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int LAYOUT = Interop.ItemView.ItemView_Property_LAYOUT_get();

            /// <summary>
            /// MINIMUM_SWIPE_SPEED. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int MINIMUM_SWIPE_SPEED = Interop.ItemView.ItemView_Property_MINIMUM_SWIPE_SPEED_get();

            /// <summary>
            /// MINIMUM_SWIPE_DISTANCE. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int MINIMUM_SWIPE_DISTANCE = Interop.ItemView.ItemView_Property_MINIMUM_SWIPE_DISTANCE_get();

            /// <summary>
            /// WHEEL_SCROLL_DISTANCE_STEP. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int WHEEL_SCROLL_DISTANCE_STEP = Interop.ItemView.ItemView_Property_WHEEL_SCROLL_DISTANCE_STEP_get();

            /// <summary>
            /// SNAP_TO_ITEM_ENABLED. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int SNAP_TO_ITEM_ENABLED = Interop.ItemView.ItemView_Property_SNAP_TO_ITEM_ENABLED_get();

            /// <summary>
            /// REFRESH_INTERVAL. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int REFRESH_INTERVAL = Interop.ItemView.ItemView_Property_REFRESH_INTERVAL_get();

            /// <summary>
            /// LAYOUT_POSITION. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int LAYOUT_POSITION = Interop.ItemView.ItemView_Property_LAYOUT_POSITION_get();

            /// <summary>
            /// SCROLL_SPEED. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int SCROLL_SPEED = Interop.ItemView.ItemView_Property_SCROLL_SPEED_get();

            /// <summary>
            /// OVERSHOOT. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int OVERSHOOT = Interop.ItemView.ItemView_Property_OVERSHOOT_get();

            /// <summary>
            /// SCROLL_DIRECTION. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int SCROLL_DIRECTION = Interop.ItemView.ItemView_Property_SCROLL_DIRECTION_get();

            /// <summary>
            /// LAYOUT_ORIENTATION. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int LAYOUT_ORIENTATION = Interop.ItemView.ItemView_Property_LAYOUT_ORIENTATION_get();

            /// <summary>
            /// SCROLL_CONTENT_SIZE. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int SCROLL_CONTENT_SIZE = Interop.ItemView.ItemView_Property_SCROLL_CONTENT_SIZE_get();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemView(ItemFactory factory) : this(Interop.ItemView.ItemView_New(ItemFactory.getCPtr(factory)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static ItemView DownCast(BaseHandle handle)
        {
            ItemView ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as ItemView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetLayoutCount()
        {
            uint ret = Interop.ItemView.ItemView_GetLayoutCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddLayout(ItemLayout layout)
        {
            Interop.ItemView.ItemView_AddLayout(swigCPtr, ItemLayout.getCPtr(layout));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveLayout(uint layoutIndex)
        {
            Interop.ItemView.ItemView_RemoveLayout(swigCPtr, layoutIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new uint GetChildCount()
        {
            uint ret = Interop.ActorInternal.Actor_GetChildCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new View GetChildAt(uint index)
        {
            View ret = new View(Interop.ActorInternal.Actor_GetChildAt(swigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t GetLayout(uint layoutIndex)
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t(Interop.ItemView.ItemView_GetLayout(swigCPtr, layoutIndex), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t GetActiveLayout()
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t(Interop.ItemView.ItemView_GetActiveLayout(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetCurrentLayoutPosition(uint itemId)
        {
            float ret = Interop.ItemView.ItemView_GetCurrentLayoutPosition(swigCPtr, itemId);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ActivateLayout(uint layoutIndex, Vector3 targetSize, float durationSeconds)
        {
            Interop.ItemView.ItemView_ActivateLayout(swigCPtr, layoutIndex, Vector3.getCPtr(targetSize), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeactivateCurrentLayout()
        {
            Interop.ItemView.ItemView_DeactivateCurrentLayout(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumSwipeSpeed(float speed)
        {
            Interop.ItemView.ItemView_SetMinimumSwipeSpeed(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetMinimumSwipeSpeed()
        {
            float ret = Interop.ItemView.ItemView_GetMinimumSwipeSpeed(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumSwipeDistance(float distance)
        {
            Interop.ItemView.ItemView_SetMinimumSwipeDistance(swigCPtr, distance);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetMinimumSwipeDistance()
        {
            float ret = Interop.ItemView.ItemView_GetMinimumSwipeDistance(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetWheelScrollDistanceStep(float step)
        {
            Interop.ItemView.ItemView_SetWheelScrollDistanceStep(swigCPtr, step);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetWheelScrollDistanceStep()
        {
            float ret = Interop.ItemView.ItemView_GetWheelScrollDistanceStep(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAnchoring(bool enabled)
        {
            Interop.ItemView.ItemView_SetAnchoring(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetAnchoring()
        {
            bool ret = Interop.ItemView.ItemView_GetAnchoring(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAnchoringDuration(float durationSeconds)
        {
            Interop.ItemView.ItemView_SetAnchoringDuration(swigCPtr, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetAnchoringDuration()
        {
            float ret = Interop.ItemView.ItemView_GetAnchoringDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollToItem(uint itemId, float durationSeconds)
        {
            Interop.ItemView.ItemView_ScrollToItem(swigCPtr, itemId, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRefreshInterval(float intervalLayoutPositions)
        {
            Interop.ItemView.ItemView_SetRefreshInterval(swigCPtr, intervalLayoutPositions);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetRefreshInterval()
        {
            float ret = Interop.ItemView.ItemView_GetRefreshInterval(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Refresh()
        {
            Interop.ItemView.ItemView_Refresh(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetItem(uint itemId)
        {
            View ret = new View(Interop.ItemView.ItemView_GetItem(swigCPtr, itemId), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetItemId(View view)
        {
            uint ret = Interop.ItemView.ItemView_GetItemId(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertItem(Item newItem, float durationSeconds)
        {
            Interop.ItemView.ItemView_InsertItem(swigCPtr, Item.getCPtr(newItem), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertItems(ItemContainer newItems, float durationSeconds)
        {
            Interop.ItemView.ItemView_InsertItems(swigCPtr, ItemContainer.getCPtr(newItems), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveItem(uint itemId, float durationSeconds)
        {
            Interop.ItemView.ItemView_RemoveItem(swigCPtr, itemId, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveItems(ItemIdContainer itemIds, float durationSeconds)
        {
            Interop.ItemView.ItemView_RemoveItems(swigCPtr, ItemIdContainer.getCPtr(itemIds), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ReplaceItem(Item replacementItem, float durationSeconds)
        {
            Interop.ItemView.ItemView_ReplaceItem(swigCPtr, Item.getCPtr(replacementItem), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ReplaceItems(ItemContainer replacementItems, float durationSeconds)
        {
            Interop.ItemView.ItemView_ReplaceItems(swigCPtr, ItemContainer.getCPtr(replacementItems), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetItemsParentOrigin(Vector3 parentOrigin)
        {
            Interop.ItemView.ItemView_SetItemsParentOrigin(swigCPtr, Vector3.getCPtr(parentOrigin));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetItemsParentOrigin()
        {
            Vector3 ret = new Vector3(Interop.ItemView.ItemView_GetItemsParentOrigin(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetItemsAnchorPoint(Vector3 anchorPoint)
        {
            Interop.ItemView.ItemView_SetItemsAnchorPoint(swigCPtr, Vector3.getCPtr(anchorPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetItemsAnchorPoint()
        {
            Vector3 ret = new Vector3(Interop.ItemView.ItemView_GetItemsAnchorPoint(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetItemsRange(ItemRange range)
        {
            Interop.ItemView.ItemView_GetItemsRange(swigCPtr, ItemRange.getCPtr(range));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VoidSignal LayoutActivatedSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.ItemView.ItemView_LayoutActivatedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
