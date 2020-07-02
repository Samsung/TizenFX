﻿/* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// [Draft] This class provides a View that can recycle items to improve performance.
    /// </summary>
    /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RecyclerView : ScrollableBase
    {
        private RecycleAdapter adapter;
        private RecycleLayoutManager layoutManager;
        private int totalItemCount = 15;
        private List<PropertyNotification> notifications = new List<PropertyNotification>();

        public RecyclerView() : base()
        {
            Initialize(new RecycleAdapter(), new RecycleLayoutManager());
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="adapter">Recycle adapter of RecyclerView.</param>
        /// <param name="layoutManager">Recycle layoutManager of RecyclerView.</param>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecyclerView(RecycleAdapter adapter, RecycleLayoutManager layoutManager)
        {
            Initialize(adapter, layoutManager);
        }

        private void Initialize(RecycleAdapter adapter, RecycleLayoutManager layoutManager)
        {
            Scrolling += OnScrolling;

            this.adapter = adapter;
            this.adapter.OnDataChanged += OnAdapterDataChanged;

            this.layoutManager = layoutManager;
            this.layoutManager.Container = ContentContainer;
            this.layoutManager.ItemSize = this.adapter.CreateRecycleItem().Size;
            this.layoutManager.DataCount = this.adapter.Data.Count;

            InitializeItems();
        }

        private void OnItemSizeChanged(object source, PropertyNotification.NotifyEventArgs args)
        {
            layoutManager.Layout(ScrollingDirection == Direction.Horizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y);
        }
        
        public int TotalItemCount 
        {
            get
            {
                return totalItemCount;
            }
            set
            {
                totalItemCount = value;
                InitializeItems();
            }
        }

        private void InitializeItems()
        {
            for(int i = Children.Count -1 ; i > -1 ; i--)
            {
                Children[i].Unparent();
                notifications[i].Notified -= OnItemSizeChanged;
                notifications.RemoveAt(i);
            }

            for (int i = 0; i < totalItemCount; i++)
            {
                RecycleItem item = adapter.CreateRecycleItem();
                item.DataIndex = i;
                item.Name = "[" + i + "] recycle";

                if (i < adapter.Data.Count)
                {
                    adapter.BindData(item);
                }
                Add(item);

                PropertyNotification noti = item.AddPropertyNotification("size", PropertyCondition.Step(0.1f));
                noti.Notified += OnItemSizeChanged;
                notifications.Add(noti);
            }

            layoutManager.Layout(0.0f);

            if (ScrollingDirection == Direction.Horizontal)
            {
                ContentContainer.SizeWidth = layoutManager.CalculateLayoutOrientationSize();
            }
            else
            {
                ContentContainer.SizeHeight = layoutManager.CalculateLayoutOrientationSize();
            }
        }


        public new Direction ScrollingDirection
        {
            get
            {
                return base.ScrollingDirection;
            }
            set
            {
                base.ScrollingDirection = value;

                if (ScrollingDirection == Direction.Horizontal)
                {
                    ContentContainer.SizeWidth = layoutManager.CalculateLayoutOrientationSize();
                }
                else
                {
                    ContentContainer.SizeHeight = layoutManager.CalculateLayoutOrientationSize();
                }
            }
        }

        /// <summary>
        /// Recycler adpater.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecycleAdapter Adapter
        {
            get
            {
                return adapter;
            }
            set
            {
                if (adapter != null)
                {
                    adapter.OnDataChanged -= OnAdapterDataChanged;
                }

                adapter = value;
                adapter.OnDataChanged += OnAdapterDataChanged;
                layoutManager.ItemSize = adapter.CreateRecycleItem().Size;
                layoutManager.DataCount = adapter.Data.Count;
                InitializeItems();
            }
        }

        /// <summary>
        /// Recycler layoutManager.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecycleLayoutManager LayoutManager
        {
            get
            {
                return layoutManager;
            }
            set
            {
                layoutManager = value;
                layoutManager.Container = ContentContainer;
                layoutManager.ItemSize = adapter.CreateRecycleItem().Size;
                layoutManager.DataCount = adapter.Data.Count;
                InitializeItems();
            }
        }

        private void OnScrolling(object source, ScrollEventArgs args)
        {
            layoutManager.Layout(ScrollingDirection == Direction.Horizontal ? args.Position.X : args.Position.Y);
            List<RecycleItem> recycledItemList = layoutManager.Recycle(ScrollingDirection == Direction.Horizontal ? args.Position.X : args.Position.Y);
            BindData(recycledItemList);
        }

        private void OnAdapterDataChanged(object source, EventArgs args)
        {
            List<RecycleItem> changedData = new List<RecycleItem>();

            foreach (RecycleItem item in Children)
            {
                changedData.Add(item);
            }

            BindData(changedData);
        }

        private void BindData(List<RecycleItem> changedData)
        {
            foreach (RecycleItem item in changedData)
            {
                if (item.DataIndex > -1 && item.DataIndex < adapter.Data.Count)
                {
                    item.Show();
                    item.Name = "["+item.DataIndex+"]";
                    adapter.BindData(item);
                }
                else
                {
                    item.Hide();
                }
            }
        }

        /// <summary>
        /// Adjust scrolling position by own scrolling rules.
        /// Override this function when developer wants to change destination of flicking.(e.g. always snap to center of item)
        /// </summary>
        /// <param name="position">Scroll position which is calculated by ScrollableBase</param>
        /// <returns>Adjusted scroll destination</returns>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override float AdjustTargetPositionOfScrollAnimation(float position)
        {
            // Destination is depending on implementation of layout manager.
            // Get destination from layout manager.
            return layoutManager.CalculateCandidateScrollPosition(position);
        }
    }
}
