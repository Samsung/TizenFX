using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System.Collections.Generic;
using System.ComponentModel;


namespace Tizen.NUI.Components
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LinearListLayoutManager : LayoutManager
    {

        private float mLayoutOriginPosition = 0;
        public LinearListLayoutManager()
        {
        }

        public override void Layout(float scrollPosition)
        {
            ListItem previousItem = null;

            foreach(ListItem item in Container.Children)
            {
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

            if(mStepSize == 0)
            {
                mStepSize = LayoutOrientation == Orientation.Horizontal?ItemSize.Width:ItemSize.Height;
            }
        }

        public override List<ListItem> Recycle(float scrollPosition)
        {
            List<ListItem> result = new List<ListItem>();

            float itemSize = LayoutOrientation == Orientation.Horizontal?ItemSize.Width:ItemSize.Height;

            View firstVisibleItem = Container.Children[3];
            float firstVisibleItemPosition = LayoutOrientation == Orientation.Horizontal?firstVisibleItem.Position.X:firstVisibleItem.Position.Y;

            firstVisibleItemPosition += 180;

            bool checkFront = (mPrevScrollPosition - scrollPosition) > 0;

            if(checkFront)
            {
                if(firstVisibleItemPosition < Math.Abs(scrollPosition))
                {
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
                if(firstVisibleItemPosition > Math.Abs(scrollPosition) + itemSize)
                {
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

            return result;
        }

        public override float CalculateCandidateScrollPosition(float position)
        {
            return position;
        }
    }
}