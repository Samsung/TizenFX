
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

            mContainer.PositionUsesPivotPoint = true;
            mContainer.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
            mContainer.PivotPoint = ScrollingDirection == Direction.Vertical?Tizen.NUI.PivotPoint.TopCenter:Tizen.NUI.PivotPoint.CenterLeft;

            ScrollDragStartEvent += OnScrollDragStart;
            ScrollAnimationEndEvent += OnAnimationEnd;

            foreach(View child in mContainer.Children)
            {
                child.PositionUsesPivotPoint = true;
                child.ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter;
            }

            ListItem focusedItem = mContainer.Children[0] as ListItem;
            focusedItem.OnFocusGained();
        }

        private void OnAnimationEnd(object source, ScrollableBase.ScrollEventArgs args)
        {
            FishEyeLayoutManager layoutManager = mLayoutManager as FishEyeLayoutManager;

            if(layoutManager != null)
            {
                ListItem focusedItem = mContainer.Children[layoutManager.FocusedIndex] as ListItem;
                focusedItem.OnFocusGained();
            }
        }

        private void OnScrollDragStart(object source, ScrollableBase.ScrollEventArgs args)
        {
            FishEyeLayoutManager layoutManager = mLayoutManager as FishEyeLayoutManager;

            if(layoutManager != null)
            {
                ListItem focusedItem = mContainer.Children[layoutManager.FocusedIndex] as ListItem;
                focusedItem.OnFocusLost();
            }
        }
    }
}