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

        internal ItemView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ItemView.Upcast(cPtr), cMemoryOwn)
        {
        }


        /// This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ItemView.DeleteItemView(swigCPtr);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Tizen.NUI.PropertyArray Layout
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                PropertyValue layout = GetProperty(ItemView.Property.LAYOUT);
                layout?.Get(temp);
                layout?.Dispose();
                return temp;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.LAYOUT, setValue);
                setValue.Dispose();
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
            public static readonly int LAYOUT = Interop.ItemView.LayoutGet();

            /// <summary>
            /// MINIMUM_SWIPE_SPEED. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int MinimumSwipeSpeed = Interop.ItemView.MinimumSwipeSpeedGet();

            /// <summary>
            /// MINIMUM_SWIPE_DISTANCE. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int MinimumSwipeDistance = Interop.ItemView.MinimumSwipeDistanceGet();

            /// <summary>
            /// WHEEL_SCROLL_DISTANCE_STEP. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int WheelScrollDistanceStep = Interop.ItemView.WheelScrollDistanceStepGet();

            /// <summary>
            /// SNAP_TO_ITEM_ENABLED. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int SnapToItemEnabled = Interop.ItemView.SnapToItemEnabledGet();

            /// <summary>
            /// REFRESH_INTERVAL. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int RefreshInterval = Interop.ItemView.RefreshIntervalGet();

            /// <summary>
            /// LAYOUT_POSITION. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int LayoutPosition = Interop.ItemView.LayoutPositionGet();

            /// <summary>
            /// SCROLL_SPEED. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollSpeed = Interop.ItemView.ScrollSpeedGet();

            /// <summary>
            /// OVERSHOOT. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int OVERSHOOT = Interop.ItemView.OvershootGet();

            /// <summary>
            /// SCROLL_DIRECTION. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollDirection = Interop.ItemView.ScrollDirectionGet();

            /// <summary>
            /// LAYOUT_ORIENTATION. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int LayoutOrientation = Interop.ItemView.LayoutOrientationGet();

            /// <summary>
            /// SCROLL_CONTENT_SIZE. This is internal use only, so not recommended to use. Need to use ItemView's properties.
            /// </summary>
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollContentSize = Interop.ItemView.ScrollContentSizeGet();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemView(ItemFactory factory) : this(Interop.ItemView.New(ItemFactory.getCPtr(factory)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static ItemView DownCast(BaseHandle handle)
        {
            ItemView ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as ItemView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetLayoutCount()
        {
            uint ret = Interop.ItemView.GetLayoutCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddLayout(ItemLayout layout)
        {
            Interop.ItemView.AddLayout(swigCPtr, ItemLayout.getCPtr(layout));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveLayout(uint layoutIndex)
        {
            Interop.ItemView.RemoveLayout(swigCPtr, layoutIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new uint GetChildCount()
        {
            uint ret = Interop.ActorInternal.GetChildCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new View GetChildAt(uint index)
        {
            View ret = new View(Interop.ActorInternal.GetChildAt(swigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t GetLayout(uint layoutIndex)
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t(Interop.ItemView.GetLayout(swigCPtr, layoutIndex));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t GetActiveLayout()
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t(Interop.ItemView.GetActiveLayout(swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetCurrentLayoutPosition(uint itemId)
        {
            float ret = Interop.ItemView.GetCurrentLayoutPosition(swigCPtr, itemId);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ActivateLayout(uint layoutIndex, Vector3 targetSize, float durationSeconds)
        {
            Interop.ItemView.ActivateLayout(swigCPtr, layoutIndex, Vector3.getCPtr(targetSize), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeactivateCurrentLayout()
        {
            Interop.ItemView.DeactivateCurrentLayout(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumSwipeSpeed(float speed)
        {
            Interop.ItemView.SetMinimumSwipeSpeed(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetMinimumSwipeSpeed()
        {
            float ret = Interop.ItemView.GetMinimumSwipeSpeed(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumSwipeDistance(float distance)
        {
            Interop.ItemView.SetMinimumSwipeDistance(swigCPtr, distance);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetMinimumSwipeDistance()
        {
            float ret = Interop.ItemView.GetMinimumSwipeDistance(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetWheelScrollDistanceStep(float step)
        {
            Interop.ItemView.SetWheelScrollDistanceStep(swigCPtr, step);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetWheelScrollDistanceStep()
        {
            float ret = Interop.ItemView.GetWheelScrollDistanceStep(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAnchoring(bool enabled)
        {
            Interop.ItemView.SetAnchoring(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetAnchoring()
        {
            bool ret = Interop.ItemView.GetAnchoring(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAnchoringDuration(float durationSeconds)
        {
            Interop.ItemView.SetAnchoringDuration(swigCPtr, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetAnchoringDuration()
        {
            float ret = Interop.ItemView.GetAnchoringDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollToItem(uint itemId, float durationSeconds)
        {
            Interop.ItemView.ScrollToItem(swigCPtr, itemId, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRefreshInterval(float intervalLayoutPositions)
        {
            Interop.ItemView.SetRefreshInterval(swigCPtr, intervalLayoutPositions);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetRefreshInterval()
        {
            float ret = Interop.ItemView.GetRefreshInterval(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Refresh()
        {
            Interop.ItemView.Refresh(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetItem(uint itemId)
        {
            View ret = new View(Interop.ItemView.GetItem(swigCPtr, itemId), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetItemId(View view)
        {
            uint ret = Interop.ItemView.GetItemId(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertItem(Item newItem, float durationSeconds)
        {
            Interop.ItemView.InsertItem(swigCPtr, Item.getCPtr(newItem), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertItems(ItemContainer newItems, float durationSeconds)
        {
            Interop.ItemView.InsertItems(swigCPtr, ItemContainer.getCPtr(newItems), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveItem(uint itemId, float durationSeconds)
        {
            Interop.ItemView.RemoveItem(swigCPtr, itemId, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveItems(ItemIdContainer itemIds, float durationSeconds)
        {
            Interop.ItemView.RemoveItems(swigCPtr, ItemIdContainer.getCPtr(itemIds), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ReplaceItem(Item replacementItem, float durationSeconds)
        {
            Interop.ItemView.ReplaceItem(swigCPtr, Item.getCPtr(replacementItem), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ReplaceItems(ItemContainer replacementItems, float durationSeconds)
        {
            Interop.ItemView.ReplaceItems(swigCPtr, ItemContainer.getCPtr(replacementItems), durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetItemsParentOrigin(Vector3 parentOrigin)
        {
            Interop.ItemView.SetItemsParentOrigin(swigCPtr, Vector3.getCPtr(parentOrigin));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetItemsParentOrigin()
        {
            Vector3 ret = new Vector3(Interop.ItemView.GetItemsParentOrigin(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetItemsAnchorPoint(Vector3 anchorPoint)
        {
            Interop.ItemView.SetItemsAnchorPoint(swigCPtr, Vector3.getCPtr(anchorPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetItemsAnchorPoint()
        {
            Vector3 ret = new Vector3(Interop.ItemView.GetItemsAnchorPoint(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetItemsRange(ItemRange range)
        {
            Interop.ItemView.GetItemsRange(swigCPtr, ItemRange.getCPtr(range));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VoidSignal LayoutActivatedSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.ItemView.LayoutActivatedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MinimumSwipeSpeed
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue minimumSwipeSpeed = GetProperty(ItemView.Property.MinimumSwipeSpeed);
                minimumSwipeSpeed?.Get(out returnValue);
                minimumSwipeSpeed?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.MinimumSwipeSpeed, setValue);
                setValue.Dispose();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MinimumSwipeDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue minimumSwipDistance = GetProperty(ItemView.Property.MinimumSwipeDistance);
                minimumSwipDistance?.Get(out returnValue);
                minimumSwipDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.MinimumSwipeDistance, setValue);
                setValue.Dispose();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float WheelScrollDistanceStep
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue wheelScrollDistanceStep = GetProperty(ItemView.Property.WheelScrollDistanceStep);
                wheelScrollDistanceStep?.Get(out returnValue);
                wheelScrollDistanceStep?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.WheelScrollDistanceStep, setValue);
                setValue.Dispose();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SnapToItemEnabled
        {
            get
            {
                bool returnValue = false;
                PropertyValue snapToItemEnabled = GetProperty(ItemView.Property.SnapToItemEnabled);
                snapToItemEnabled?.Get(out returnValue);
                snapToItemEnabled?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.SnapToItemEnabled, setValue);
                setValue.Dispose();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float RefreshInterval
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue refreshIntervalu = GetProperty(ItemView.Property.RefreshInterval);
                refreshIntervalu?.Get(out returnValue);
                refreshIntervalu?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.RefreshInterval, setValue);
                setValue.Dispose();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float LayoutPosition
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue layoutPosition = GetProperty(ItemView.Property.LayoutPosition);
                layoutPosition?.Get(out returnValue);
                layoutPosition?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.LayoutPosition, setValue);
                setValue.Dispose();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ScrollSpeed
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue scrollSpeed = GetProperty(ItemView.Property.ScrollSpeed);
                scrollSpeed?.Get(out returnValue);
                scrollSpeed?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.ScrollSpeed, setValue);
                setValue.Dispose();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Overshoot
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue overShoot = GetProperty(ItemView.Property.OVERSHOOT);
                overShoot?.Get(out returnValue);
                overShoot?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.OVERSHOOT, setValue);
                setValue.Dispose();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollDirection
        {
            get
            {
                Vector2 returnValue = new Vector2(0.0f, 0.0f);
                PropertyValue scrollDirection = GetProperty(ItemView.Property.ScrollDirection);
                scrollDirection?.Get(returnValue);
                scrollDirection?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.ScrollDirection, setValue);
                setValue.Dispose();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LayoutOrientation
        {
            get
            {
                int returnValue = 0;
                PropertyValue layoutOrientation = GetProperty(ItemView.Property.LayoutOrientation);
                layoutOrientation?.Get(out returnValue);
                layoutOrientation?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.LayoutOrientation, setValue);
                setValue.Dispose();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ScrollContentSize
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue scrollContentSize = GetProperty(ItemView.Property.ScrollContentSize);
                scrollContentSize?.Get(out returnValue);
                scrollContentSize?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(ItemView.Property.ScrollContentSize, setValue);
                setValue.Dispose();
            }
        }
    }
}
