
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// [Draft] This class provides a View that can scroll a single View with a layout. This View can be a nest of Views.
    /// </summary>
    /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RecyclerList : ScrollableBase
    {
        protected ListAdapter mAdapter;
        protected View mContainer;
        protected LayoutManager mLayoutManager;
        protected int mTotalItemCount = 15;
        private List<PropertyNotification> notifications = new List<PropertyNotification>();

        public RecyclerList(ListAdapter adapter, LayoutManager layoutManager)
        {
            Name = "[List]";
            mContainer = new View()
            {
                WidthSpecification = ScrollingDirection == Direction.Vertical? LayoutParamPolicies.MatchParent:LayoutParamPolicies.WrapContent,
                HeightSpecification = ScrollingDirection == Direction.Horizontal? LayoutParamPolicies.MatchParent:LayoutParamPolicies.WrapContent,
                Layout = new AbsoluteLayout()
                {
                    SetPositionByLayout = false,
                },
                Name="Container",
            };

            Add(mContainer);
            ScrollEvent += OnScroll;

            mAdapter = adapter;
            mAdapter.OnDataChanged += OnAdapterDataChanged;

            mLayoutManager = layoutManager;
            mLayoutManager.Container = mContainer;
            mLayoutManager.ItemSize = mAdapter.CreateListItem().Size;

            for(int i = 0; i< mTotalItemCount; i++)
            {
                ListItem item = mAdapter.CreateListItem();
                item.DataIndex = i;
                item.Name ="["+i+"] recycle";

                if(i<mAdapter.Data.Count)
                {
                    mAdapter.BindData(item);
                }
                mContainer.Add(item);

                PropertyNotification noti = item.AddPropertyNotification("size", PropertyCondition.Step(0.1f));
                noti.Notified += (object source, PropertyNotification.NotifyEventArgs args) =>
                {
                    mLayoutManager.Layout(ScrollingDirection == Direction.Horizontal?mPreviousScrollPosition.X:mPreviousScrollPosition.Y);
                };
                notifications.Add(noti);
            }
            
            mLayoutManager.Layout(0.0f);

            if(ScrollingDirection == Direction.Horizontal)
            {
                mContainer.Size = new Size(mLayoutManager.StepSize*(mAdapter.Data.Count-1),mContainer.Size.Height);
            }
            else
            {
                mContainer.Size = new Size(mContainer.Size.Width,mLayoutManager.StepSize*(mAdapter.Data.Count-1));
            }
        }

        public ListAdapter Adapter{
            get
            {
                return mAdapter;
            }
        }

        private void OnScroll(object source, ScrollableBase.ScrollEventArgs args)
        {
            mLayoutManager.Layout(ScrollingDirection == Direction.Horizontal?args.Position.X:args.Position.Y);
            List<ListItem> recycledItemList = mLayoutManager.Recycle(ScrollingDirection == Direction.Horizontal?args.Position.X:args.Position.Y);
            BindData(recycledItemList);
        }

        private void OnAdapterDataChanged(object source, EventArgs args)
        {
            List<ListItem> changedData = new List<ListItem>();

            foreach(ListItem item in mContainer.Children)
            {
                changedData.Add(item);
            }

            BindData(changedData);
        }

        private void BindData(List<ListItem> changedData)
        {
            foreach(ListItem item in changedData)
            {
                if(item.DataIndex > -1 && item.DataIndex < mAdapter.Data.Count)
                {
                    item.Show();
                    mAdapter.BindData(item);
                }
                else
                {
                    item.Hide();
                }
            }
        }

        protected override float AdjustScrollToChild(float position)
        {
            return mLayoutManager.CalculateCandidateScrollPosition(position);
        }
    }
}