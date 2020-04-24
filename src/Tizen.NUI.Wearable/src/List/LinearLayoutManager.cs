using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System.Collections.Generic;
using System.ComponentModel;


namespace Tizen.NUI.Wearable
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LinearLayoutManager : LayoutManager
    {

        private float mLayoutOriginPosition = 0;
        public LinearLayoutManager(Size itemSize, View container)
        {
            ItemSize = itemSize;
            Container = container;
            Layout(0.0f);
        }

        protected override void Layout(float scrollPosition)
        {
            ListItem previousItem = null;

            foreach(ListItem item in Container.Children)
            {
                item.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
                item.PositionUsesPivotPoint = false;

                float targetPosition = mLayoutOriginPosition;

                if(previousItem != null)
                {
                    targetPosition = LayoutOrientation == Orientation.Horizontal?
                    previousItem.PositionX + previousItem.SizeWidth:
                    previousItem.PositionY + previousItem.SizeHeight;
                }

                item.Position = LayoutOrientation == Orientation.Horizontal?
                new Position(targetPosition,item.PositionY):
                new Position(item.PositionX,targetPosition);

                previousItem = item;
            }
        }

        public override List<ListItem> OnScroll(float scrollPosition)
        {
            List<ListItem> result = new List<ListItem>();
            float itemSize = LayoutOrientation == Orientation.Horizontal?ItemSize.Width:ItemSize.Height;

            View firstVisibleItem = Container.Children[3];
            float firstVisibleItemPosition = LayoutOrientation == Orientation.Horizontal?firstVisibleItem.Position.X:firstVisibleItem.Position.Y;

            firstVisibleItemPosition += 180;

            bool checkFront = (mPrevScrollPosition - scrollPosition) > 0;

            if(checkFront)
            {
                Tizen.Log.Error("NUI",firstVisibleItemPosition+" vs "+Math.Abs(scrollPosition)+"\n");
                if(firstVisibleItemPosition < Math.Abs(scrollPosition))
                {
                    Tizen.Log.Error("NUI","Too MANY ITEM IN FRONT !!! ===\n");
                    // Too many item is in front!!! move first item to back!!!!
                    ListItem target = Container.Children[0] as ListItem;
                    target.DataIndex = mPrevFirstDataIndex + Container.Children.Count;

                    target.SiblingOrder = Container.Children.Count - 1;
                    mPrevFirstDataIndex += 1;

                    result.Add(target);

                    mLayoutOriginPosition += LayoutOrientation == Orientation.Horizontal?
                        ItemSize.Width:ItemSize.Height;
                }
            }
            else
            {
                Tizen.Log.Error("NUI",firstVisibleItemPosition+" vs "+(Math.Abs(scrollPosition)+itemSize)+"\n");
                if(firstVisibleItemPosition > Math.Abs(scrollPosition) + itemSize)
                {
                    Tizen.Log.Error("NUI","Too MANY ITEM IN BACK !!! ===\n");
                    ListItem target = Container.Children[Container.Children.Count - 1] as ListItem;
                    target.DataIndex = mPrevFirstDataIndex - 1;

                    target.SiblingOrder = 0;
                    mPrevFirstDataIndex -= 1;

                    result.Add(target);

                    mLayoutOriginPosition -= LayoutOrientation == Orientation.Horizontal?
                        Container.Children[0].SizeWidth:Container.Children[0].SizeHeight;
                }
            }

            mPrevScrollPosition = scrollPosition;

            Layout(scrollPosition);
            return result;
        }
    }
}