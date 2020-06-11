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
        private RecycleAdapter mAdapter;
        private View mContainer;
        private LayoutManager mLayoutManager;
        private int mTotalItemCount = 15;
        private List<PropertyNotification> notifications = new List<PropertyNotification>();

        protected RecycleAdapter MAdapter { get => mAdapter; set => mAdapter = value; }
        protected View MContainer { get => mContainer; set => mContainer = value; }
        protected LayoutManager MLayoutManager { get => mLayoutManager; set => mLayoutManager = value; }
        protected int MTotalItemCount { get => mTotalItemCount; set => mTotalItemCount = value; }
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="adapter">Recycle adapter of RecyclerView.</param>
        /// <param name="layoutManager">Recycle layoutManager of RecyclerView.</param>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecyclerView(RecycleAdapter adapter, LayoutManager layoutManager)
        {
            Name = "[List]";
            MContainer = new View()
            {
                WidthSpecification = ScrollingDirection == Direction.Vertical ? LayoutParamPolicies.MatchParent : LayoutParamPolicies.WrapContent,
                HeightSpecification = ScrollingDirection == Direction.Horizontal ? LayoutParamPolicies.MatchParent : LayoutParamPolicies.WrapContent,
                Layout = new AbsoluteLayout()
                {
                    SetPositionByLayout = false,
                },
                Name = "Container",
            };

            Add(MContainer);
            ScrollEvent += OnScroll;

            MAdapter = adapter;
            MAdapter.OnDataChanged += OnAdapterDataChanged;

            MLayoutManager = layoutManager;
            MLayoutManager.Container = MContainer;
            MLayoutManager.ItemSize = MAdapter.CreateRecycleItem().Size;

            for (int i = 0; i < MTotalItemCount; i++)
            {
                RecycleItem item = MAdapter.CreateRecycleItem();
                item.DataIndex = i;
                item.Name = "[" + i + "] recycle";

                if (i < MAdapter.Data.Count)
                {
                    MAdapter.BindData(item);
                }
                MContainer.Add(item);

                PropertyNotification noti = item.AddPropertyNotification("size", PropertyCondition.Step(0.1f));
                noti.Notified += (object source, PropertyNotification.NotifyEventArgs args) =>
                {
                    MLayoutManager.Layout(ScrollingDirection == Direction.Horizontal ? MContainer.CurrentPosition.X : MContainer.CurrentPosition.Y);
                };
                notifications.Add(noti);
            }

            MLayoutManager.Layout(0.0f);

            if (ScrollingDirection == Direction.Horizontal)
            {
                MContainer.SizeWidth = MLayoutManager.StepSize * MAdapter.Data.Count;
            }
            else
            {
                MContainer.SizeHeight = MLayoutManager.StepSize * MAdapter.Data.Count;
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
                return MAdapter;
            }
        }

        /// <summary>
        /// Recycler layoutManager.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LayoutManager ListLayoutManager
        {
            get
            {
                return MLayoutManager;
            }
        }

        private void OnScroll(object source, ScrollableBase.ScrollEventArgs args)
        {
            MLayoutManager.Layout(ScrollingDirection == Direction.Horizontal ? args.Position.X : args.Position.Y);
            List<RecycleItem> recycledItemList = MLayoutManager.Recycle(ScrollingDirection == Direction.Horizontal ? args.Position.X : args.Position.Y);
            BindData(recycledItemList);
        }

        private void OnAdapterDataChanged(object source, EventArgs args)
        {
            List<RecycleItem> changedData = new List<RecycleItem>();

            foreach (RecycleItem item in MContainer.Children)
            {
                changedData.Add(item);
            }

            BindData(changedData);
        }

        private void BindData(List<RecycleItem> changedData)
        {
            foreach (RecycleItem item in changedData)
            {
                if (item.DataIndex > -1 && item.DataIndex < MAdapter.Data.Count)
                {
                    item.Show();
                    MAdapter.BindData(item);
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
            return MLayoutManager.CalculateCandidateScrollPosition(position);
        }
    }
}