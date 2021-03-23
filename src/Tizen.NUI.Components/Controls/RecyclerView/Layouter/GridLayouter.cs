/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// This class implements a grid box layout.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GridLayouter : ItemsLayouter
    {
        private CollectionView colView;
        private Size2D sizeCandidate;
        private int spanSize = 1;
        private float align = 0.5f;
        private bool hasHeader;
        private float headerSize;
        private bool hasFooter;
        private float footerSize;
        private bool isGrouped;
        private readonly List<GroupInfo> groups = new List<GroupInfo>();
        private float groupHeaderSize;
        private float groupFooterSize;
        private GroupInfo Visited;

        /// <summary>
        /// Clean up ItemsLayouter.
        /// </summary>
        /// <param name="view"> ItemsView of layouter. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Initialize(RecyclerView view)
        {
            colView = view as CollectionView;
            if (colView == null)
            {
                throw new ArgumentException("GridLayouter only can be applied CollectionView.", nameof(view));
            }

            // 1. Clean Up
            foreach (RecyclerViewItem item in VisibleItems)
            {
                colView.UnrealizeItem(item, false);
            }
            VisibleItems.Clear();
            groups.Clear();

            FirstVisible = 0;
            LastVisible = 0;

            IsHorizontal = (colView.ScrollingDirection == ScrollableBase.Direction.Horizontal);

            RecyclerViewItem header = colView?.Header;
            RecyclerViewItem footer = colView?.Footer;
            float width, height;
            int count = colView.InternalItemSource.Count;
            int pureCount = count - (header ? 1 : 0) - (footer ? 1 : 0);

            // 2. Get the header / footer and size deligated item and measure the size.
            if (header != null)
            {
                MeasureChild(colView, header);

                width = header.Layout != null ? header.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = header.Layout != null ? header.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                headerSize = IsHorizontal ? width : height;
                hasHeader = true;

                colView.UnrealizeItem(header);
            }

            if (footer != null)
            {
                MeasureChild(colView, footer);

                width = footer.Layout != null ? footer.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = footer.Layout != null ? footer.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                footerSize = IsHorizontal ? width : height;
                footer.Index = count - 1;
                hasFooter = true;

                colView.UnrealizeItem(footer);
            }

            int firstIndex = header ? 1 : 0;

            if (colView.IsGrouped)
            {
                isGrouped = true;

                if (colView.GroupHeaderTemplate != null)
                {
                    while (!colView.InternalItemSource.IsGroupHeader(firstIndex)) firstIndex++;
                    //must be always true
                    if (colView.InternalItemSource.IsGroupHeader(firstIndex))
                    {
                        RecyclerViewItem groupHeader = colView.RealizeItem(firstIndex);
                        firstIndex++;

                        if (groupHeader == null) throw new Exception("[" + firstIndex + "] Group Header failed to realize!");

                        // Need to Set proper height or width on scroll direction.
                        if (groupHeader.Layout == null)
                        {
                            width = groupHeader.WidthSpecification;
                            height = groupHeader.HeightSpecification;
                        }
                        else
                        {
                            MeasureChild(colView, groupHeader);

                            width = groupHeader.Layout.MeasuredWidth.Size.AsRoundedValue();
                            height = groupHeader.Layout.MeasuredHeight.Size.AsRoundedValue();
                        }
                        //Console.WriteLine("[NUI] GroupHeader Size {0} :{0}", width, height);
                        // pick the StepCandidate.
                        groupHeaderSize = IsHorizontal ? width : height;
                        colView.UnrealizeItem(groupHeader);
                    }
                }
                else
                {
                    groupHeaderSize = 0F;
                }

                if (colView.GroupFooterTemplate != null)
                {
                    int firstFooter = firstIndex;
                    while (!colView.InternalItemSource.IsGroupFooter(firstFooter)) firstFooter++;
                    //must be always true
                    if (colView.InternalItemSource.IsGroupFooter(firstFooter))
                    {
                        RecyclerViewItem groupFooter = colView.RealizeItem(firstFooter);

                        if (groupFooter == null) throw new Exception("[" + firstFooter + "] Group Footer failed to realize!");
                        // Need to Set proper height or width on scroll direction.
                        if (groupFooter.Layout == null)
                        {
                            width = groupFooter.WidthSpecification;
                            height = groupFooter.HeightSpecification;
                        }
                        else
                        {
                            MeasureChild(colView, groupFooter);

                            width = groupFooter.Layout.MeasuredWidth.Size.AsRoundedValue();
                            height = groupFooter.Layout.MeasuredHeight.Size.AsRoundedValue();
                        }
                        // pick the StepCandidate.
                        groupFooterSize = IsHorizontal ? width : height;

                        colView.UnrealizeItem(groupFooter);
                    }
                }
                else
                {
                    groupFooterSize = 0F;
                }
            }
            else isGrouped = false;

            bool failed = false;
            //Final Check of FirstIndex
            while (colView.InternalItemSource.IsHeader(firstIndex) ||
                    colView.InternalItemSource.IsGroupHeader(firstIndex) ||
                    colView.InternalItemSource.IsGroupFooter(firstIndex))
            {
                if (colView.InternalItemSource.IsFooter(firstIndex))
                {
                    StepCandidate = 0F;
                    failed = true;
                    break;
                }
                firstIndex++;
            }

            sizeCandidate = new Size2D(0, 0);
            if (!failed)
            {
                // Get Size Deligate. FIXME if group exist index must be changed.
                RecyclerViewItem sizeDeligate = colView.RealizeItem(firstIndex);
                if (sizeDeligate == null)
                {
                    throw new Exception("Cannot create content from DatTemplate.");
                }
                sizeDeligate.BindingContext = colView.InternalItemSource.GetItem(firstIndex);

                // Need to Set proper height or width on scroll direction.
                if (sizeDeligate.Layout == null)
                {
                    width = sizeDeligate.WidthSpecification;
                    height = sizeDeligate.HeightSpecification;
                }
                else
                {
                    MeasureChild(colView, sizeDeligate);

                    width = sizeDeligate.Layout.MeasuredWidth.Size.AsRoundedValue();
                    height = sizeDeligate.Layout.MeasuredHeight.Size.AsRoundedValue();
                }
                //Console.WriteLine("[NUI] item Size {0} :{1}", width, height);

                // pick the StepCandidate.
                StepCandidate = IsHorizontal ? width : height;
                spanSize = IsHorizontal ? Convert.ToInt32(Math.Truncate((double)(colView.Size.Height / height))) :
                                        Convert.ToInt32(Math.Truncate((double)(colView.Size.Width / width)));

                sizeCandidate = new Size2D(Convert.ToInt32(width), Convert.ToInt32(height));

                colView.UnrealizeItem(sizeDeligate);
            }

            if (StepCandidate < 1) StepCandidate = 1;
            if (spanSize < 1) spanSize = 1;

            if (isGrouped)
            {
                float Current = 0.0F;
                IGroupableItemSource source = colView.InternalItemSource;
                GroupInfo currentGroup = null;

                for (int i = 0; i < count; i++)
                {
                    if (i == 0 && hasHeader)
                    {
                        Current += headerSize;
                    }
                    else if (i == count - 1 && hasFooter)
                    {
                        Current += footerSize;
                    }
                    else
                    {
                        //GroupHeader must always exist in group usage.
                        if (source.IsGroupHeader(i))
                        {
                            currentGroup = new GroupInfo()
                            {
                                GroupParent = source.GetGroupParent(i),
                                StartIndex = i,
                                Count = 1,
                                GroupSize = groupHeaderSize,
                                GroupPosition = Current
                            };
                            groups.Add(currentGroup);
                            Current += groupHeaderSize;
                        }
                        //optional
                        else if (source.IsGroupFooter(i))
                        {
                            //currentGroup.hasFooter = true;
                            currentGroup.Count++;
                            currentGroup.GroupSize += groupFooterSize;
                            Current += groupFooterSize;
                        }
                        else
                        {
                            currentGroup.Count++;
                            int index = i - currentGroup.StartIndex - 1; // groupHeader must always exist.
                            if ((index % spanSize) == 0)
                            {
                                currentGroup.GroupSize += StepCandidate;
                                Current += StepCandidate;
                            }
                        }
                    }
                }
                ScrollContentSize = Current;
            }
            else
            {
                // 3. Measure the scroller content size.
                ScrollContentSize = StepCandidate * Convert.ToInt32(Math.Ceiling((double)pureCount / (double)spanSize));
                if (hasHeader) ScrollContentSize += headerSize;
                if (hasFooter) ScrollContentSize += footerSize;
            }

            if (IsHorizontal) colView.ContentContainer.SizeWidth = ScrollContentSize;
            else colView.ContentContainer.SizeHeight = ScrollContentSize;

            base.Initialize(colView);
            //Console.WriteLine("Init Done, StepCnadidate{0}, spanSize{1}, Scroll{2}", StepCandidate, spanSize, ScrollContentSize);
        }

        /// <summary>
        /// This is called to find out where items are lain out according to current scroll position.
        /// </summary>
        /// <param name="scrollPosition">Scroll position which is calculated by ScrollableBase</param>
        /// <param name="force">boolean force flag to layouting forcely.</param>
        public override void RequestLayout(float scrollPosition, bool force = false)
        {
            // Layouting is only possible after once it intialized.
            if (!IsInitialized) return;
            int LastIndex = colView.InternalItemSource.Count;

            if (!force && PrevScrollPosition == Math.Abs(scrollPosition)) return;
            PrevScrollPosition = Math.Abs(scrollPosition);

            int prevFirstVisible = FirstVisible;
            int prevLastVisible = LastVisible;
            bool IsHorizontal = (colView.ScrollingDirection == ScrollableBase.Direction.Horizontal);

            (float X, float Y) visibleArea = (PrevScrollPosition,
                PrevScrollPosition + (IsHorizontal ? colView.Size.Width : colView.Size.Height)
            );

            //Console.WriteLine("[NUI] itemsView [{0},{1}] [{2},{3}]", colView.Size.Width, colView.Size.Height, colView.ContentContainer.Size.Width, colView.ContentContainer.Size.Height);

            // 1. Set First/Last Visible Item Index. 
            (int start, int end) = FindVisibleItems(visibleArea);
            FirstVisible = start;
            LastVisible = end;

            //Console.WriteLine("[NUI] {0} :visibleArea before [{1},{2}] after [{3},{4}]", scrollPosition, prevFirstVisible, prevLastVisible, FirstVisible, LastVisible);

            // 2. Unrealize invisible items.
            List<RecyclerViewItem> unrealizedItems = new List<RecyclerViewItem>();
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if (item.Index < FirstVisible || item.Index > LastVisible)
                {
                    //Console.WriteLine("[NUI] Unrealize{0}!", item.Index);
                    unrealizedItems.Add(item);
                    colView.UnrealizeItem(item);
                }
            }
            VisibleItems.RemoveAll(unrealizedItems.Contains);

            //Console.WriteLine("Realize Begin [{0} to {1}]", FirstVisible, LastVisible);
            // 3. Realize and placing visible items.
            for (int i = FirstVisible; i <= LastVisible; i++)
            {
                //Console.WriteLine("[NUI] Realize!");
                RecyclerViewItem item = null;
                // 4. Get item if visible or realize new.
                if (i >= prevFirstVisible && i <= prevLastVisible)
                {
                    item = GetVisibleItem(i);
                    if (item) continue;
                }
                if (item == null) item = colView.RealizeItem(i);
                VisibleItems.Add(item);

                (float x, float y) = GetItemPosition(i);
                // 5. Placing item.
                item.Position = new Position(x, y);
                //Console.WriteLine("[NUI] ["+item.Index+"] ["+item.Position.X+", "+item.Position.Y+" ==== \n");
            }
            //Console.WriteLine("Realize Done");
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override (float X, float Y) GetItemPosition(object item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (colView == null) return (0, 0);

            return GetItemPosition(colView.InternalItemSource.GetPosition(item));
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override (float X, float Y) GetItemSize(object item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (sizeCandidate == null) return (0, 0);

            if (isGrouped)
            {
                int index = colView.InternalItemSource.GetPosition(item);
                float view = (IsHorizontal ? colView.Size.Height : colView.Size.Width);

                if (colView.InternalItemSource.IsGroupHeader(index))
                {
                    return (IsHorizontal ? (groupHeaderSize, view) : (view, groupHeaderSize));
                }
                else if (colView.InternalItemSource.IsGroupFooter(index))
                {
                    return (IsHorizontal ? (groupFooterSize, view) : (view, groupFooterSize));
                }
            }

            return (sizeCandidate.Width, sizeCandidate.Height);
        }

        /// <inheritdoc/>
        public override void NotifyItemSizeChanged(RecyclerViewItem item)
        {
            // All Item size need to be same in grid!
            // if you want to change item size, change dataTemplate to re-initing.
            return;
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float CalculateLayoutOrientationSize()
        {
            //Console.WriteLine("[NUI] Calculate Layout ScrollContentSize {0}", ScrollContentSize);
            return ScrollContentSize;
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float CalculateCandidateScrollPosition(float scrollPosition)
        {
            //Console.WriteLine("[NUI] Calculate Candidate ScrollContentSize {0}", ScrollContentSize);
            return scrollPosition;
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override View RequestNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            if (currentFocusedView == null)
                throw new ArgumentNullException(nameof(currentFocusedView));

            View nextFocusedView = null;
            int targetSibling = -1;
            bool IsHorizontal = colView.ScrollingDirection == ScrollableBase.Direction.Horizontal;

            switch (direction)
            {
                case View.FocusDirection.Left:
                    {
                        targetSibling = IsHorizontal ? currentFocusedView.SiblingOrder - 1 : targetSibling;
                        break;
                    }
                case View.FocusDirection.Right:
                    {
                        targetSibling = IsHorizontal ? currentFocusedView.SiblingOrder + 1 : targetSibling;
                        break;
                    }
                case View.FocusDirection.Up:
                    {
                        targetSibling = IsHorizontal ? targetSibling : currentFocusedView.SiblingOrder - 1;
                        break;
                    }
                case View.FocusDirection.Down:
                    {
                        targetSibling = IsHorizontal ? targetSibling : currentFocusedView.SiblingOrder + 1;
                        break;
                    }
            }

            if (targetSibling > -1 && targetSibling < Container.Children.Count)
            {
                RecyclerViewItem candidate = Container.Children[targetSibling] as RecyclerViewItem;
                if (candidate.Index >= 0 && candidate.Index < colView.InternalItemSource.Count)
                {
                    nextFocusedView = candidate;
                }
            }
            return nextFocusedView;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override (int start, int end) FindVisibleItems((float X, float Y) visibleArea)
        {
            int MaxIndex = colView.InternalItemSource.Count - 1 - (hasFooter ? 1 : 0);
            int adds = spanSize * 2;
            int skipGroup = -1;
            (int start, int end) found = (0, 0);

            // Header is Showing
            if (hasHeader && visibleArea.X < headerSize)
            {
                found.start = 0;
            }
            else
            {
                if (isGrouped)
                {
                    bool failed = true;
                    foreach (GroupInfo gInfo in groups)
                    {
                        skipGroup++;
                        // in the Group
                        if (gInfo.GroupPosition <= visibleArea.X &&
                            gInfo.GroupPosition + gInfo.GroupSize >= visibleArea.X)
                        {
                            if (gInfo.GroupPosition + groupHeaderSize >= visibleArea.X)
                            {
                                found.start = gInfo.StartIndex - adds;
                                failed = false;
                            }
                            //can be step in spanSize...
                            for (int i = 1; i < gInfo.Count; i++)
                            {
                                if (!failed) break;
                                // Reach last index of group.
                                if (i == (gInfo.Count - 1))
                                {
                                    found.start = gInfo.StartIndex + i - adds;
                                    failed = false;
                                    break;

                                }
                                else if ((((i - 1) / spanSize) * StepCandidate) + StepCandidate >= visibleArea.X - gInfo.GroupPosition - groupHeaderSize)
                                {
                                    found.start = gInfo.StartIndex + i - adds;
                                    failed = false;
                                    break;
                                }
                            }
                        }
                    }
                    //footer only shows?
                    if (failed)
                    {
                        found.start = MaxIndex;
                    }
                }
                else
                {
                    float visibleAreaX = visibleArea.X - (hasHeader ? headerSize : 0);
                    found.start = (Convert.ToInt32(Math.Abs(visibleAreaX / StepCandidate)) - 1) * spanSize;
                    if (hasHeader) found.start += 1;
                }
                if (found.start < 0) found.start = 0;
            }

            if (hasFooter && visibleArea.Y > ScrollContentSize - footerSize)
            {
                found.end = MaxIndex + 1;
            }
            else
            {
                if (isGrouped)
                {
                    bool failed = true;
                    // can it be start from founded group...?
                    //foreach(GroupInfo gInfo in groups.Skip(skipGroup))
                    foreach (GroupInfo gInfo in groups)
                    {
                        // in the Group
                        if (gInfo.GroupPosition <= visibleArea.Y &&
                            gInfo.GroupPosition + gInfo.GroupSize >= visibleArea.Y)
                        {
                            if (gInfo.GroupPosition + groupHeaderSize >= visibleArea.Y)
                            {
                                found.end = gInfo.StartIndex + adds;
                                failed = false;
                            }
                            //can be step in spanSize...
                            for (int i = 1; i < gInfo.Count; i++)
                            {
                                if (!failed) break;
                                // Reach last index of group.
                                if (i == (gInfo.Count - 1))
                                {
                                    found.end = gInfo.StartIndex + i + adds;
                                    failed = false;
                                    break;
                                }
                                else if ((((i - 1) / spanSize) * StepCandidate) + StepCandidate >= visibleArea.Y - gInfo.GroupPosition - groupHeaderSize)
                                {
                                    found.end = gInfo.StartIndex + i + adds;
                                    failed = false;
                                    break;
                                }
                            }
                        }
                    }
                    //footer only shows?
                    if (failed)
                    {
                        found.start = MaxIndex;
                    }
                }
                else
                {
                    float visibleAreaY = visibleArea.Y - (hasHeader ? headerSize : 0);
                    //Need to Consider GroupHeight!!!!
                    found.end = (Convert.ToInt32(Math.Abs(visibleAreaY / StepCandidate)) + 1) * spanSize + adds;
                    if (hasHeader) found.end += 1;
                }
                if (found.end > (MaxIndex)) found.end = MaxIndex;
            }
            return found;
        }

        private (float X, float Y) GetItemPosition(int index)
        {
            float xPos, yPos;
            if (sizeCandidate == null) return (0, 0);

            if (hasHeader && index == 0)
            {
                return (0, 0);
            }
            if (hasFooter && index == colView.InternalItemSource.Count - 1)
            {
                xPos = IsHorizontal ? ScrollContentSize - footerSize : 0;
                yPos = IsHorizontal ? 0 : ScrollContentSize - footerSize;
                return (xPos, yPos);
            }
            if (isGrouped)
            {
                GroupInfo myGroup = GetGroupInfo(index);
                if (colView.InternalItemSource.IsGroupHeader(index))
                {
                    xPos = IsHorizontal ? myGroup.GroupPosition : 0;
                    yPos = IsHorizontal ? 0 : myGroup.GroupPosition;
                }
                else if (colView.InternalItemSource.IsGroupFooter(index))
                {
                    xPos = IsHorizontal ? myGroup.GroupPosition + myGroup.GroupSize - groupFooterSize : 0;
                    yPos = IsHorizontal ? 0 : myGroup.GroupPosition + myGroup.GroupSize - groupFooterSize;
                }
                else
                {
                    int pureIndex = index - myGroup.StartIndex - 1;
                    int division = pureIndex / spanSize;
                    int remainder = pureIndex % spanSize;
                    int emptyArea = IsHorizontal ? (int)(colView.Size.Height - (sizeCandidate.Height * spanSize)) :
                                                    (int)(colView.Size.Width - (sizeCandidate.Width * spanSize));
                    if (division < 0) division = 0;
                    if (remainder < 0) remainder = 0;

                    xPos = IsHorizontal ? division * sizeCandidate.Width + myGroup.GroupPosition + groupHeaderSize : emptyArea * align + remainder * sizeCandidate.Width;
                    yPos = IsHorizontal ? emptyArea * align + remainder * sizeCandidate.Height : division * sizeCandidate.Height + myGroup.GroupPosition + groupHeaderSize;
                }
            }
            else
            {
                int pureIndex = index - (colView.Header ? 1 : 0);
                // int convert must be truncate value.
                int division = pureIndex / spanSize;
                int remainder = pureIndex % spanSize;
                int emptyArea = IsHorizontal ? (int)(colView.Size.Height - (sizeCandidate.Height * spanSize)) :
                                                (int)(colView.Size.Width - (sizeCandidate.Width * spanSize));
                if (division < 0) division = 0;
                if (remainder < 0) remainder = 0;

                xPos = IsHorizontal ? division * sizeCandidate.Width + (hasHeader ? headerSize : 0) : emptyArea * align + remainder * sizeCandidate.Width;
                yPos = IsHorizontal ? emptyArea * align + remainder * sizeCandidate.Height : division * sizeCandidate.Height + (hasHeader ? headerSize : 0);
            }

            return (xPos, yPos);
        }

        private RecyclerViewItem GetVisibleItem(int index)
        {
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if (item.Index == index) return item;
            }

            return null;
        }

        private GroupInfo GetGroupInfo(int index)
        {
            if (Visited != null)
            {
                if (Visited.StartIndex <= index && Visited.StartIndex + Visited.Count > index)
                    return Visited;
            }
            if (hasHeader && index == 0) return null;
            foreach (GroupInfo group in groups)
            {
                if (group.StartIndex <= index && group.StartIndex + group.Count > index)
                {
                    Visited = group;
                    return group;
                }
            }
            Visited = null;
            return null;
        }

        /*
        private object GetGroupParent(int index)
        {
            if (Visited != null)
            {
                if (Visited.StartIndex <= index && Visited.StartIndex + Visited.Count > index)
                return Visited.GroupParent;
            }
            if (hasHeader && index == 0) return null;
            foreach (GroupInfo group in groups)
            {
                if (group.StartIndex <= index && group.StartIndex + group.Count > index)
                {
                    Visited = group;
                    return group.GroupParent;
                }
            }
            Visited = null;
            return null;
        }
        */

        class GroupInfo
        {
            public object GroupParent;
            public int StartIndex;
            public int Count;
            public float GroupSize;
            public float GroupPosition;
            //Items relative position from the GroupPosition
        }
    }
}
