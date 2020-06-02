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
    /// [Draft] This class implements a linear box layout.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LinearListLayoutManager : LayoutManager
    {
        private float mLayoutOriginPosition = 0;

        /// <summary>
        /// This is called to find out where items are lain out according to current scroll position.
        /// </summary>
        /// <param name="scrollPosition">Scroll position which is calculated by ScrollableBase</param>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        public override void Layout(float scrollPosition)
        {
            RecycleItem previousItem = null;

            foreach(RecycleItem item in Container.Children)
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

        /// <summary>
        /// This is called to find out which items should be recycled according to current scroll position.
        /// </summary>
        /// <param name="scrollPosition">Scroll position which is calculated by ScrollableBase</param>
        /// <returns>List of RecycleItems which should be recycled.</returns>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        public override List<RecycleItem> Recycle(float scrollPosition)
        {
            List<RecycleItem> result = new List<RecycleItem>();

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
                    RecycleItem target = Container.Children[0] as RecycleItem;
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
                    RecycleItem target = Container.Children[Container.Children.Count - 1] as RecycleItem;
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

        /// <summary>
        /// Adjust scrolling position by own scrolling rules.
        /// </summary>
        /// <param name="scrollPosition">Scroll position which is calculated by ScrollableBase</param>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        public override float CalculateCandidateScrollPosition(float scrollPosition)
        {
            return scrollPosition;
        }
    }
}