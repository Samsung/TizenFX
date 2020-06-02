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
        private int firstVisibleItemIndex = -1;
        private int lastVisibleItemIndex = -1;

        private bool IsItemVisible(float scrollPosition, RecycleItem item)
        {
            bool result = false;
            View list = Container.GetParent() as View;

            Vector2 visibleArea = new Vector2( Math.Abs(scrollPosition), 
                Math.Abs(scrollPosition) + (LayoutOrientation == Orientation.Horizontal?
                                                list.Size.Width:list.Size.Height)
            );

            float firstCheckPoint = LayoutOrientation == Orientation.Horizontal? item.Position.X:item.Position.Y;
            float secondCheckPoint = LayoutOrientation == Orientation.Horizontal? 
                                        firstCheckPoint + item.Size.Width:
                                        firstCheckPoint + item.Size.Height;

            // Tizen.Log.Error("NUI", "[1p] "+visibleArea.X+ " =< "+firstCheckPoint+" =< "+visibleArea.Y+" ==== \n");
            // Tizen.Log.Error("NUI", "[2p] "+visibleArea.X+ " =< "+secondCheckPoint+" =< "+visibleArea.Y+" ==== \n");

            result = (firstCheckPoint >= visibleArea.X && firstCheckPoint <= visibleArea.Y) || (secondCheckPoint >= visibleArea.X && secondCheckPoint <= visibleArea.Y);

            return result;
        }

        /// <summary>
        /// This is called to find out where items are lain out according to current scroll position.
        /// </summary>
        /// <param name="scrollPosition">Scroll position which is calculated by ScrollableBase</param>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        public override void Layout(float scrollPosition)
        {
            firstVisibleItemIndex = -1;
            lastVisibleItemIndex = -1;

            RecycleItem previousItem = null;

            for(int i = 0 ; i < Container.Children.Count ; i++)
            {
                RecycleItem item = Container.Children[i] as RecycleItem;

                if(previousItem != null)
                {
                    item.Position = LayoutOrientation == Orientation.Horizontal?
                        new Position(
                            previousItem.Position.X + (previousItem.CurrentSize.Width != 0 ?
                                                            previousItem.CurrentSize.Width:
                                                            previousItem.Size.Width),
                            item.PositionY
                        ):
                        new Position(
                            item.PositionX,
                            previousItem.Position.Y + (previousItem.CurrentSize.Height != 0 ? 
                                                            previousItem.CurrentSize.Height:
                                                            previousItem.Size.Height)
                        );
                }

                bool isVisible = IsItemVisible(scrollPosition, item);

                if(isVisible)
                {
                    firstVisibleItemIndex = firstVisibleItemIndex == -1? i : firstVisibleItemIndex;
                    lastVisibleItemIndex = i;
                }

                previousItem = item;

                // Tizen.Log.Error("NUI","["+item.DataIndex+"] "+item.Position.Y+" ==== \n");
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
          
            bool checkFront = (mPrevScrollPosition - scrollPosition) > 0;

            if(checkFront)
            {
                if(firstVisibleItemIndex > 3)
                {
                    // Too many item is in front!!! move first item to back!!!!
                    RecycleItem target = Container.Children[0] as RecycleItem;
                    target.DataIndex = target.DataIndex + Container.Children.Count;
                    target.SiblingOrder = Container.Children.Count - 1;

                    result.Add(target);
                }
            }
            else
            {
                if(lastVisibleItemIndex < Container.Children.Count - 3)
                {
                    RecycleItem prevFirstItem = Container.Children[0] as RecycleItem;

                    RecycleItem target = Container.Children[Container.Children.Count - 1] as RecycleItem;
                    target.Position = new Position(
                        LayoutOrientation == Orientation.Horizontal ? (prevFirstItem.Position.X - target.Size.Width) : prevFirstItem.Position.X,
                        LayoutOrientation == Orientation.Horizontal ? prevFirstItem.Position.Y : (prevFirstItem.Position.Y - target.Size.Height)
                    );
                    target.DataIndex = target.DataIndex - Container.Children.Count;
                    target.SiblingOrder = 0;

                    result.Add(target);
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