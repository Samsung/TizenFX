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
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// [Draft] This class implements a grid box layout.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GridRecycleLayoutManager : RecycleLayoutManager
    {
        private int rows = 1;

        /// <summary>
        /// [draft ]Get/Set the number of rows in the grid
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;

                if (Container != null)
                {
                    Layout(PrevScrollPosition);
                }
            }
        }

        private int columns = 1;


        /// <summary>
        /// [Draft] Get/Set the number of columns in the grid
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;

                if (Container != null)
                {
                    Layout(PrevScrollPosition);
                }
            }
        }

        private int firstVisibleItemIndex = -1;
        private int lastVisibleItemIndex = -1;

        private bool IsItemVisible(float scrollPosition, RecycleItem item)
        {
            bool result = false;
            View list = Container.GetParent() as View;
            if (list == null)
            {
                return result;
            }
            Vector2 visibleArea = new Vector2(Math.Abs(scrollPosition),
                Math.Abs(scrollPosition) + (LayoutOrientation == Orientation.Vertical ?
                                                list.Size.Width : list.Size.Height)
            );

            float firstCheckPoint = LayoutOrientation == Orientation.Vertical ? item.Position.X : item.Position.Y;
            float secondCheckPoint = LayoutOrientation == Orientation.Vertical ?
                                        firstCheckPoint + item.Size.Width :
                                        firstCheckPoint + item.Size.Height;

            result = (firstCheckPoint >= visibleArea.X && firstCheckPoint <= visibleArea.Y) || (secondCheckPoint >= visibleArea.X && secondCheckPoint <= visibleArea.Y);

            return result;
        }

        /// <summary>
        /// This is called to find out how much container size can be.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float CalculateLayoutOrientationSize()
        {
            float orientationFactor = LayoutOrientation == Orientation.Vertical ? Rows : Columns;
            return StepSize * (int)Math.Ceiling((double)DataCount / (double)orientationFactor);
        }


        /// <summary>
        /// This is called to find out where items are lain out according to current scroll position.
        /// </summary>
        /// <param name="scrollPosition">Scroll position which is calculated by ScrollableBase</param>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        public override void Layout(float scrollPosition)
        {
            int itemInGroup = LayoutOrientation == Orientation.Vertical ? Rows : Columns;
            firstVisibleItemIndex = -1;
            lastVisibleItemIndex = -1;

            RecycleItem previousItem = null;

            for (int i = 0; i < Container.Children.Count; i++)
            {
                RecycleItem item = Container.Children[i] as RecycleItem;

                if (previousItem != null && item != null)
                {
                    item.Position = LayoutOrientation == Orientation.Vertical ?
                        new Position(
                            (i % itemInGroup == 0 ?
                            previousItem.Position.X + (previousItem.CurrentSize.Width != 0 ?
                                                            previousItem.CurrentSize.Width :
                                                            previousItem.Size.Width) :
                            previousItem.Position.X),
                            (i % itemInGroup == 0 ?
                            0 :
                            previousItem.PositionY + (previousItem.CurrentSize.Height != 0 ?
                                                            previousItem.CurrentSize.Height :
                                                            previousItem.Size.Height))
                        ) :
                        new Position(
                            (i % itemInGroup == 0 ?
                            0 :
                            previousItem.PositionX + (previousItem.CurrentSize.Width != 0 ?
                                                            previousItem.CurrentSize.Width :
                                                            previousItem.Size.Width)),
                            (i % itemInGroup == 0 ?
                            previousItem.Position.Y + (previousItem.CurrentSize.Height != 0 ?
                                                            previousItem.CurrentSize.Height :
                                                            previousItem.Size.Height) :
                            previousItem.Position.Y)
                        );
                }

                bool isVisible = IsItemVisible(scrollPosition, item);

                if (isVisible)
                {
                    firstVisibleItemIndex = firstVisibleItemIndex == -1 ? i : firstVisibleItemIndex;
                    lastVisibleItemIndex = i;
                }

                previousItem = item;
            }

            if (StepSize == 0)
            {
                StepSize = LayoutOrientation == Orientation.Vertical ? ItemSize.Width : ItemSize.Height;
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
            bool checkFront = (PrevScrollPosition - scrollPosition) > 0;

            int itemInGroup = LayoutOrientation == Orientation.Vertical ? Rows : Columns;

            if (checkFront)
            {
                int currentGroupNum = (int)(firstVisibleItemIndex / itemInGroup) + 1;

                if (currentGroupNum > 2)
                {
                    // Too many item is in front!!! move first item to back!!!!
                    for (int i = 0; i < itemInGroup; i++)
                    {
                        RecycleItem target = Container.Children[0] as RecycleItem;
                        if (target != null)
                        {
                            target.DataIndex = target.DataIndex + Container.Children.Count;
                            target.SiblingOrder = Container.Children.Count - 1;

                            result.Add(target);
                        }
                    }
                }
            }
            else
            {
                int currentGroupNum = (int)(lastVisibleItemIndex / itemInGroup) + 1;

                if (currentGroupNum < (int)(Container.Children.Count / itemInGroup) - 3)
                {
                    for (int i = 0; i < itemInGroup; i++)
                    {
                        RecycleItem prevFirstItem = Container.Children[itemInGroup] as RecycleItem;
                        RecycleItem target = Container.Children[Container.Children.Count - 1] as RecycleItem;
                        if (prevFirstItem != null && target != null)
                        {
                            target.Position = new Position(
                                LayoutOrientation == Orientation.Vertical ? (prevFirstItem.Position.X - target.Size.Width) : prevFirstItem.Position.X,
                                LayoutOrientation == Orientation.Vertical ? prevFirstItem.Position.Y : (prevFirstItem.Position.Y - target.Size.Height)
                            );
                            target.DataIndex = target.DataIndex - Container.Children.Count;
                            target.SiblingOrder = 0;

                            result.Add(target);
                        }
                    }
                }
            }


            PrevScrollPosition = scrollPosition;

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

        public override View RequestNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            View nextFocusedView = null;
            int targetSibling = -1;
            bool isHorizontal = LayoutOrientation == Orientation.Horizontal;

            switch (direction)
            {
                case View.FocusDirection.Left:
                    {
                        targetSibling = isHorizontal ? currentFocusedView.SiblingOrder - 1 : currentFocusedView.SiblingOrder - Rows;
                        break;
                    }
                case View.FocusDirection.Right:
                    {
                        targetSibling = isHorizontal ? currentFocusedView.SiblingOrder + 1 : currentFocusedView.SiblingOrder + Rows;
                        break;
                    }
                case View.FocusDirection.Up:
                    {
                        targetSibling = isHorizontal ? currentFocusedView.SiblingOrder - Columns : currentFocusedView.SiblingOrder - 1;
                        break;
                    }
                case View.FocusDirection.Down:
                    {
                        targetSibling = isHorizontal ? currentFocusedView.SiblingOrder + Columns : currentFocusedView.SiblingOrder + 1;
                        break;
                    }
            }

            if (targetSibling > -1 && targetSibling < Container.Children.Count)
            {
                RecycleItem candidate = Container.Children[targetSibling] as RecycleItem;
                if (candidate != null && candidate.DataIndex >= 0 && candidate.DataIndex < DataCount)
                {
                    nextFocusedView = candidate;
                }
            }

            return nextFocusedView;
        }
    }
}
