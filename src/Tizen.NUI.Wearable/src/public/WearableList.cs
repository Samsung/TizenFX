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
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WearableList() : base(new RecycleAdapter(), new FishEyeLayoutManager())
        {
            ScrollingDirection = ScrollableBase.Direction.Vertical;

            ScrollDragStarted += OnScrollDragStarted;
            ScrollAnimationEnded += OnAnimationEnded;

            ContentContainer.PositionUsesPivotPoint = true;
            ContentContainer.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
            ContentContainer.PivotPoint = Tizen.NUI.PivotPoint.TopCenter;
            NoticeAnimationEndBeforePosition = 50;

            ScrollAvailableArea = new Vector2(0, ContentContainer.SizeHeight);

            SetFocus(0, false);

            Scrollbar = new CircularScrollbar();
            DecelerationThreshold = 60.0f;
            DecelerationRate = 0.991f;
        }

        protected override void SetScrollbar()
        {
            if(LayoutManager != null)
            {
                Scrollbar.Initialize(ContentContainer.Size.Height, LayoutManager.StepSize, ContentContainer.CurrentPosition.Y, false);
            }
        }

        public new RecycleAdapter Adapter
        {
            get
            {
                return base.Adapter;
            }

            set
            {
                base.Adapter = value;

                foreach (View child in Children)
                {
                    child.PositionUsesPivotPoint = true;
                    child.ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter;
                }

                ScrollAvailableArea = new Vector2( 0, ContentContainer.SizeHeight );
            }
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
            if (LayoutManager == null)
            {
                return;
            }

            foreach (RecycleItem item in Children)
            {
                if (item.DataIndex == dataIndex)
                {
                    RecycleItem prevFocusedItem = FocusedItem;
                    prevFocusedItem?.OnFocusLost();
                    FocusedItem = item;
                    FocusedItem.OnFocusGained();

                    ScrollTo(item.DataIndex * LayoutManager.StepSize, animated);
                }
            }
        }

        private void OnAnimationEnded(object source, ScrollEventArgs args)
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
            if (LayoutManager == null)
            {
                return;
            }
            int targetDataIndex = (int)Math.Round(Math.Abs(targetPosition) / LayoutManager.StepSize);

            for (int i = 0; i < Children.Count; i++)
            {
                RecycleItem item = Children[i] as RecycleItem;
                if (item == null)
                {
                    continue;
                }

                if (targetDataIndex == item.DataIndex)
                {
                    FocusedItem = item;
                    item.OnFocusGained();
                    break;
                }
            }
        }

        private void OnScrollDragStarted(object source, ScrollEventArgs args)
        {
            RecycleItem prevFocusedItem = FocusedItem;
            prevFocusedItem?.OnFocusLost();
        }
    }
}
