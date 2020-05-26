/* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.ComponentModel;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// [Draft] This class provides a list view styled by wearable ux.
    /// List will lay out all items with Fish-Eye layout manager.
    /// </summary>
    /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WearableList : RecyclerView
    {
        private RecycleItem FocusedItem = null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="adapter">Recycle adapter of List.</param>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WearableList(RecycleAdapter adapter) : base(adapter, new FishEyeLayoutManager())
        {
            ScrollingDirection = ScrollableBase.Direction.Vertical;

            ScrollDragStartEvent += OnScrollDragStart;
            ScrollAnimationEndEvent += OnAnimationEnd;

            foreach (View child in mContainer.Children)
            {
                child.PositionUsesPivotPoint = true;
                child.ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter;
            }

            mContainer.PositionUsesPivotPoint = true;
            mContainer.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
            mContainer.PivotPoint = ScrollingDirection == Direction.Vertical ? Tizen.NUI.PivotPoint.TopCenter : Tizen.NUI.PivotPoint.CenterLeft;
            ScrollAvailableArea = new Vector2( 0,ListLayoutManager.StepSize * (mAdapter.Data.Count - 1) );

            noticeAnimationEndBeforePosition = 50;

            SetFocus(0, false);
        }

        /// <summary>
        /// Set focus to item which has specific data index.
        /// </summary>
        /// <param name="dataIndex">Data index of item.</param>
        /// <param name="animated">If set true, scroll to item using animation.</param>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        public void SetFocus(int dataIndex, bool animated)
        {
            foreach (RecycleItem item in mContainer.Children)
            {
                if (item.DataIndex == dataIndex)
                {
                    RecycleItem prevFocusedItem = FocusedItem;
                    prevFocusedItem?.OnFocusLost();
                    FocusedItem = item;
                    FocusedItem.OnFocusGained();

                    ScrollTo(item.DataIndex * mLayoutManager.StepSize, animated);
                }
            }
        }

        private void OnAnimationEnd(object source, ScrollableBase.ScrollEventArgs args)
        {
        }

        /// <summary>
        /// This helps developer who wants to know before scroll is reaching target position.
        /// </summary>
        /// <param name="targetPosition">Index of item.</param>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        protected override void OnPreReachedTargetPosition(float targetPosition)
        {
            int targetDataIndex = (int)Math.Round(Math.Abs(targetPosition) / mLayoutManager.StepSize);

            for (int i = 0; i < mContainer.Children.Count; i++)
            {
                RecycleItem item = mContainer.Children[i] as RecycleItem;

                if (targetDataIndex == item.DataIndex)
                {
                    FocusedItem = item;
                    item.OnFocusGained();
                    break;
                }
            }
        }

        private float dragStartPosition = 0.0f;

        private void OnScrollDragStart(object source, ScrollableBase.ScrollEventArgs args)
        {
            RecycleItem prevFocusedItem = FocusedItem;
            prevFocusedItem?.OnFocusLost();
        }
    }
}