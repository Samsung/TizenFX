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
using System.Linq;
using Tizen.NUI.BaseComponents;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{


    /// <summary>
    /// [Draft] This class implements a linear box layout.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LinearLayouter : ItemsLayouter
    {
        private readonly List<float> ItemPosition = new List<float>();
        private readonly List<float> ItemSize = new List<float>();
        private int ItemSizeChanged = -1;
        private CollectionView colView;
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
        /// <param name="view"> ItemsView of layouter.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Initialize(RecyclerView view)
        {
            colView = view as CollectionView;
            if (colView == null)
            {
                throw new ArgumentException("LinearLayouter only can be applied CollectionView.", nameof(view));
            }
            // 1. Clean Up
            foreach (RecyclerViewItem item in VisibleItems)
            {
                colView.UnrealizeItem(item, false);
            }
            VisibleItems.Clear();
            ItemPosition.Clear();
            ItemSize.Clear();
            groups.Clear();

            FirstVisible = 0;
            LastVisible = 0;

            IsHorizontal = (colView.ScrollingDirection == ScrollableBase.Direction.Horizontal);

            RecyclerViewItem header = colView?.Header;
            RecyclerViewItem footer = colView?.Footer;
            float width, height;
            int count = colView.InternalItemSource.Count;

            if (header != null)
            {
                MeasureChild(colView, header);

                width = header.Layout != null ? header.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = header.Layout != null ? header.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                headerSize = IsHorizontal ? width : height;
                hasHeader = true;

                colView.UnrealizeItem(header);
            }
            else hasHeader = false;

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
            else hasFooter = false;

            //No Internal Source exist.
            if (count == (hasHeader ? (hasFooter ? 2 : 1) : 0)) return;

            int firstIndex = hasHeader ? 1 : 0;

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

                        // Need to Set proper hieght or width on scroll direciton.
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
                        // Need to Set proper hieght or width on scroll direciton.
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

            if (!failed)
            {
                RecyclerViewItem sizeDeligate = colView.RealizeItem(firstIndex);
                if (sizeDeligate == null)
                {
                    // error !
                    throw new Exception("Cannot create content from DatTemplate.");
                }

                sizeDeligate.BindingContext = colView.InternalItemSource.GetItem(firstIndex);

                // Need to Set proper hieght or width on scroll direciton.
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
                //Console.WriteLine("[NUI] Layout Size {0} :{0}", width, height);
                // pick the StepCandidate.
                StepCandidate = IsHorizontal ? width : height;
                if (StepCandidate == 0) StepCandidate = 1; //????

                colView.UnrealizeItem(sizeDeligate);
            }

            float Current = 0.0F;
            IGroupableItemSource source = colView.InternalItemSource;
            GroupInfo currentGroup = null;
            for (int i = 0; i < count; i++)
            {
                if (colView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                {
                    if (i == 0 && hasHeader)
                        ItemSize.Add(headerSize);
                    else if (i == count - 1 && hasFooter)
                        ItemSize.Add(footerSize);
                    else if (source.IsGroupHeader(i))
                        ItemSize.Add(groupHeaderSize);
                    else if (source.IsGroupFooter(i))
                        ItemSize.Add(groupFooterSize);
                    else ItemSize.Add(StepCandidate);
                }
                if (isGrouped)
                {
                    if (i == 0 && hasHeader)
                    {
                        //ItemPosition.Add(Current);
                        Current += headerSize;
                    }
                    else if (i == count - 1 && hasFooter)
                    {
                        //ItemPosition.Add(Current);
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
                                //hasHeader = true,
                                //hasFooter = false,
                                StartIndex = i,
                                Count = 1,
                                GroupSize = groupHeaderSize,
                                GroupPosition = Current
                            };
                            currentGroup.ItemPosition.Add(0);
                            groups.Add(currentGroup);
                            Current += groupHeaderSize;
                        }
                        //optional
                        else if (source.IsGroupFooter(i))
                        {
                            //currentGroup.hasFooter = true;
                            currentGroup.Count++;
                            currentGroup.GroupSize += groupFooterSize;
                            currentGroup.ItemPosition.Add(Current - currentGroup.GroupPosition);
                            Current += groupFooterSize;
                        }
                        else
                        {
                            currentGroup.Count++;
                            currentGroup.GroupSize += StepCandidate;
                            currentGroup.ItemPosition.Add(Current - currentGroup.GroupPosition);
                            Current += StepCandidate;
                        }
                    }
                }
                else
                {
                    ItemPosition.Add(Current);

                    if (i == 0 && hasHeader) Current += headerSize;
                    else if (i == count - 1 && hasFooter) Current += footerSize;
                    else Current += StepCandidate;
                }
            }

            ScrollContentSize = Current;
            if (IsHorizontal) colView.ContentContainer.SizeWidth = ScrollContentSize;
            else colView.ContentContainer.SizeHeight = ScrollContentSize;


            base.Initialize(view);
            //Console.WriteLine("[NUI] Init Done, StepCnadidate{0}, Scroll{1}", StepCandidate, ScrollContentSize);
        }

        /// <summary>
        /// This is called to find out where items are lain out according to current scroll position.
        /// </summary>
        /// <param name="scrollPosition">Scroll position which is calculated by ScrollableBase</param>
        /// <param name="force">boolean force flag to layouting forcely.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void RequestLayout(float scrollPosition, bool force = false)
        {
            // Layouting is only possible after once it intialized.
            if (!IsInitialized) return;
            int LastIndex = colView.InternalItemSource.Count - 1;

            if (!force && PrevScrollPosition == Math.Abs(scrollPosition)) return;
            PrevScrollPosition = Math.Abs(scrollPosition);

            if (ItemSizeChanged >= 0)
            {
                for (int i = ItemSizeChanged; i <= LastIndex; i++)
                    UpdatePosition(i);
                ScrollContentSize = ItemPosition[LastIndex - 1] + GetItemSize(LastIndex);
            }

            int prevFirstVisible = FirstVisible;
            int prevLastVisible = LastVisible;

            (float X, float Y) visibleArea = (PrevScrollPosition,
                PrevScrollPosition + (IsHorizontal ? colView.Size.Width : colView.Size.Height)
            );

            // 1. Set First/Last Visible Item Index. 
            (int start, int end) = FindVisibleItems(visibleArea);
            FirstVisible = start;
            LastVisible = end;

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

            // 3. Realize and placing visible items.
            for (int i = FirstVisible; i <= LastVisible; i++)
            {
                RecyclerViewItem item = null;
                // 4. Get item if visible or realize new.
                if (i >= prevFirstVisible && i <= prevLastVisible)
                {
                    item = GetVisibleItem(i);
                    if (item) continue;
                }
                if (item == null) item = colView.RealizeItem(i);

                VisibleItems.Add(item);

                // 5. Placing item.
                float posX = 0F, posY = 0F;
                if (isGrouped)
                {
                    //isHeader?
                    if (colView.Header == item)
                    {
                        posX = 0F;
                        posY = 0F;
                    }
                    else if (colView.Footer == item)
                    {
                        posX = (IsHorizontal ? ScrollContentSize - item.SizeWidth : 0F);
                        posY = (IsHorizontal ? 0F : ScrollContentSize - item.SizeHeight);
                    }
                    else
                    {
                        GroupInfo gInfo = GetGroupInfo(i);
                        posX = (IsHorizontal ? gInfo.GroupPosition + gInfo.ItemPosition[i - gInfo.StartIndex] : 0F);
                        posY = (IsHorizontal ? 0F : gInfo.GroupPosition + gInfo.ItemPosition[i - gInfo.StartIndex]);
                    }
                }
                else
                {
                    posX = (IsHorizontal ? ItemPosition[i] : 0F);
                    posY = (IsHorizontal ? 0F : ItemPosition[i]);
                }

                item.Position = new Position(posX, posY);
                //Console.WriteLine("[NUI] ["+item+"]["+item.Index+"] :: ["+item.Position.X+", "+item.Position.Y+"] ==== \n");
            }
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override (float X, float Y) GetItemPosition(object item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            // Layouting Items in scrollPosition.
            float pos = ItemPosition[colView.InternalItemSource.GetPosition(item)];

            return (IsHorizontal ? (pos, 0.0F) : (0.0F, pos));
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override (float X, float Y) GetItemSize(object item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            // Layouting Items in scrollPosition.
            float size = GetItemSize(colView.InternalItemSource.GetPosition(item));
            float view = (IsHorizontal ? colView.Size.Height : colView.Size.Width);

            return (IsHorizontal ? (size, view) : (view, size));
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void NotifyItemSizeChanged(RecyclerViewItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!IsInitialized ||
                (colView.SizingStrategy == ItemSizingStrategy.MeasureFirst &&
                item.Index != 0) ||
                (item.Index < 0))
                return;

            float PrevSize, CurrentSize;
            if (item.Index == (colView.InternalItemSource.Count - 1))
            {
                PrevSize = ScrollContentSize - ItemPosition[item.Index];
            }
            else
            {
                PrevSize = ItemPosition[item.Index + 1] - ItemPosition[item.Index];
            }

            CurrentSize = (IsHorizontal ? item.Size.Width : item.Size.Height);

            if (CurrentSize != PrevSize)
            {
                if (colView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                    ItemSize[item.Index] = CurrentSize;
                else
                    StepCandidate = CurrentSize;
            }
            if (ItemSizeChanged == -1) ItemSizeChanged = item.Index;
            else ItemSizeChanged = Math.Min(ItemSizeChanged, item.Index);

            //ScrollContentSize += Diff; UpdateOnce?
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
            int adds = 5;
            int skipGroup = -2;
            (int start, int end) found = (0, 0);

            // 1. Find the start index.
            // Header is Showing
            if (hasHeader && visibleArea.X <= headerSize)
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
                            for (int i = 0; i < gInfo.Count; i++)
                            {
                                // Reach last index of group.
                                if (i == (gInfo.Count - 1))
                                {
                                    found.start = gInfo.StartIndex + i - adds;
                                    failed = false;
                                    break;

                                }
                                else if (gInfo.ItemPosition[i] <= visibleArea.X - gInfo.GroupPosition &&
                                        gInfo.ItemPosition[i + 1] >= visibleArea.X - gInfo.GroupPosition)
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
                    found.start = (Convert.ToInt32(Math.Abs(visibleAreaX / StepCandidate)) - adds);
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
                            for (int i = 0; i < gInfo.Count; i++)
                            {
                                if (i == (gInfo.Count - 1))
                                {
                                    //Sould be groupFooter!
                                    found.end = gInfo.StartIndex + i + adds;
                                    failed = false;
                                    break;

                                }
                                else if (gInfo.ItemPosition[i] <= visibleArea.Y - gInfo.GroupPosition &&
                                        gInfo.ItemPosition[i + 1] >= visibleArea.Y - gInfo.GroupPosition)
                                {
                                    found.end = gInfo.StartIndex + i + adds;
                                    failed = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (failed) found.end = MaxIndex;
                }
                else
                {
                    float visibleAreaY = visibleArea.Y - (hasHeader ? headerSize : 0);
                    found.end = (Convert.ToInt32(Math.Abs(visibleAreaY / StepCandidate)) + adds);
                    if (hasHeader) found.end += 1;
                }
                if (found.end > (MaxIndex)) found.end = MaxIndex;
            }
            return found;
        }

        private float GetItemSize(int index)
        {
            if (colView.SizingStrategy == ItemSizingStrategy.MeasureAll)
            {
                return ItemSize[index];
            }
            else
            {
                if (index == 0 && hasHeader)
                    return headerSize;
                if (index == colView.InternalItemSource.Count - 1 && hasFooter)
                    return footerSize;
                return StepCandidate;
            }
        }

        private void UpdatePosition(int index)
        {
            bool IsGroup = (colView.InternalItemSource is IGroupableItemSource);

            if (index <= 0) return;
            if (index >= colView.InternalItemSource.Count)

                if (IsGroup)
                {
                    //IsGroupHeader = (colView.InternalItemSource as IGroupableItemSource).IsGroupHeader(index);
                    //IsGroupFooter = (colView.InternalItemSource as IGroupableItemSource).IsGroupFooter(index);
                    //Do Something
                }

            ItemPosition[index] = ItemPosition[index - 1] + GetItemSize(index - 1);
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
            public List<float> ItemPosition = new List<float>();
        }
    }
}
