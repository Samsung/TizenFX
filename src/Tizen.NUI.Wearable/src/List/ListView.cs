
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// [Draft] This class provides a View that can scroll a single View with a layout. This View can be a nest of Views.
    /// </summary>
    /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ListView : RecyclerList
    {
        public ListView(ListAdapter adapter) : base(adapter, new FishEyeLayoutManager())
        {
            ScrollingDirection = ScrollableBase.Direction.Vertical;

            ScrollDragStartEvent += OnScrollDragStart;
            ScrollAnimationEndEvent += OnAnimationEnd;

            foreach(View child in mContainer.Children)
            {
                child.PositionUsesPivotPoint = true;
                child.ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter;
            }

            mContainer.PositionUsesPivotPoint = true;
            mContainer.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
            mContainer.PivotPoint = ScrollingDirection == Direction.Vertical?Tizen.NUI.PivotPoint.TopCenter:Tizen.NUI.PivotPoint.CenterLeft;
            mContainer.Size = new Size(mLayoutManager.StepSize*(mAdapter.Data.Count-1),mContainer.Size.Height);
            ScrollAvailableArea = new Vector2(0,mLayoutManager.StepSize*(mAdapter.Data.Count-1));
            noticeAnimationEndBeforePosition = 100;

            ListItem focusedItem = mContainer.Children[0] as ListItem;
            focusedItem.OnFocusGained();
        }

        private void OnAnimationEnd(object source, ScrollableBase.ScrollEventArgs args)
        {
        }

        protected override void OnPreReachedTargetPosition(float targetPosition)
        {
            FishEyeLayoutManager layoutManager = mLayoutManager as FishEyeLayoutManager;

            if(layoutManager != null)
            {
                int targetDataIndex = (int)(Math.Abs(targetPosition) / mLayoutManager.StepSize);

                for(int i = 0 ; i<mContainer.Children.Count;i++)
                {
                    ListItem item = mContainer.Children[i] as ListItem;

                    if(targetDataIndex == item.DataIndex)
                    {
                        item.OnFocusGained();
                        break;
                    }
                }
            }
        }

        private float dragStartPosition = 0.0f;

        private void OnScrollDragStart(object source, ScrollableBase.ScrollEventArgs args)
        {
            dragStartPosition = args.Position.Y;
            FishEyeLayoutManager layoutManager = mLayoutManager as FishEyeLayoutManager;

            if(layoutManager != null)
            {
                ListItem focusedItem = mContainer.Children[layoutManager.FocusedIndex] as ListItem;
                focusedItem.OnFocusLost();
            }
        }
    }
}