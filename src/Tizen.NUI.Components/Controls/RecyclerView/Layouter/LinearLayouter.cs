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
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// layouter for CollectionView to display items in linear layout.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class LinearLayouter : ItemsLayouter
    {
        private readonly List<float> ItemPosition = new List<float>();
        private readonly List<float> ItemSize = new List<float>();
        private int ItemSizeChanged = -1;
        private CollectionView collectionView;
        private bool hasHeader;
        private float headerSize;
        private Extents headerMargin;
        private bool hasFooter;
        private float footerSize;
        private Extents footerMargin;
        private bool isGrouped;
        private readonly List<GroupInfo> groups = new List<GroupInfo>();
        private float groupHeaderSize;
        private Extents groupHeaderMargin;
        private float groupFooterSize;
        private Extents groupFooterMargin;
        private GroupInfo Visited;
        private Timer requestLayoutTimer = null;
        private bool isSourceEmpty;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected new IGroupableItemSource Source => collectionView?.InternalSource;

        /// <summary>
        /// Visible ViewItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override List<GroupInfo> GroupItems => groups;

        /// <summary>
        /// Clean up ItemsLayouter.
        /// </summary>
        /// <param name="view"> CollectionView of layouter.</param>
        /// <remarks>please note that, view must be type of CollectionView</remarks>
        /// <since_tizen> 9 </since_tizen>
        public override void Initialize(RecyclerView view)
        {
            collectionView = view as CollectionView;
            if (collectionView == null)
            {
                throw new ArgumentException("LinearLayouter only can be applied CollectionView.", nameof(view));
            }

            // 1. Clean Up
            foreach (RecyclerViewItem item in VisibleItems)
            {
                collectionView.UnrealizeItem(item, false);
            }
            VisibleItems.Clear();
            groups.Clear();
            FirstVisible = 0;
            LastVisible = 0;

            IsHorizontal = (collectionView.ScrollingDirection == ScrollableBase.Direction.Horizontal);

            RecyclerViewItem header = collectionView?.Header;
            RecyclerViewItem footer = collectionView?.Footer;
            float width, height;
            int count = Source.Count;

            if (header != null)
            {
                MeasureChild(collectionView, header);

                width = header.Layout != null? header.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = header.Layout != null? header.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                Extents itemMargin = header.Margin;
                headerSize = IsHorizontal?
                                width + itemMargin.Start + itemMargin.End:
                                height + itemMargin.Top + itemMargin.Bottom;
                headerMargin = new Extents(itemMargin);
                hasHeader = true;

                collectionView.UnrealizeItem(header);
            }
            else hasHeader = false;

            if (footer != null)
            {
                MeasureChild(collectionView, footer);

                width = footer.Layout != null? footer.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = footer.Layout != null? footer.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                Extents itemMargin = footer.Margin;
                footerSize = IsHorizontal?
                                width + itemMargin.Start + itemMargin.End:
                                height + itemMargin.Top + itemMargin.Bottom;
                footerMargin = new Extents(itemMargin);
                footer.Index = count - 1;
                hasFooter = true;

                collectionView.UnrealizeItem(footer);
            }
            else hasFooter = false;

            //No Internal Source exist.
            if (count == (hasHeader? (hasFooter? 2 : 1) : 0))
            {
                isSourceEmpty = true;
                base.Initialize(view);
                return;
            }
            isSourceEmpty = false;

            int firstIndex = hasHeader? 1 : 0;

            if (collectionView.IsGrouped)
            {
                isGrouped = true;

                if (collectionView.GroupHeaderTemplate != null)
                {
                    while (!Source.IsGroupHeader(firstIndex)) firstIndex++;
                    //must be always true
                    if (Source.IsGroupHeader(firstIndex))
                    {
                        RecyclerViewItem groupHeader = collectionView.RealizeItem(firstIndex);
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
                            MeasureChild(collectionView, groupHeader);

                            width = groupHeader.Layout.MeasuredWidth.Size.AsRoundedValue();
                            height = groupHeader.Layout.MeasuredHeight.Size.AsRoundedValue();
                        }
                        // pick the StepCandidate.
                        Extents itemMargin = groupHeader.Margin;
                        groupHeaderSize = IsHorizontal?
                                            width + itemMargin.Start + itemMargin.End:
                                            height + itemMargin.Top + itemMargin.Bottom;
                        groupHeaderMargin = new Extents(itemMargin);
                        collectionView.UnrealizeItem(groupHeader);
                    }
                }
                else
                {
                    groupHeaderSize = 0F;
                }

                if (collectionView.GroupFooterTemplate != null)
                {
                    int firstFooter = firstIndex;
                    while (!Source.IsGroupFooter(firstFooter)) firstFooter++;
                    //must be always true
                    if (Source.IsGroupFooter(firstFooter))
                    {
                        RecyclerViewItem groupFooter = collectionView.RealizeItem(firstFooter);

                        if (groupFooter == null) throw new Exception("[" + firstFooter + "] Group Footer failed to realize!");
                        // Need to Set proper height or width on scroll direction.
                        if (groupFooter.Layout == null)
                        {
                            width = groupFooter.WidthSpecification;
                            height = groupFooter.HeightSpecification;
                        }
                        else
                        {
                            MeasureChild(collectionView, groupFooter);

                            width = groupFooter.Layout.MeasuredWidth.Size.AsRoundedValue();
                            height = groupFooter.Layout.MeasuredHeight.Size.AsRoundedValue();
                        }
                        // pick the StepCandidate.
                        Extents itemMargin = groupFooter.Margin;
                        groupFooterSize = IsHorizontal?
                                            width + itemMargin.Start + itemMargin.End:
                                            height + itemMargin.Top + itemMargin.Bottom;
                        groupFooterMargin = new Extents(itemMargin);
                        collectionView.UnrealizeItem(groupFooter);
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
            if ((Source.Count - 1 < firstIndex) ||
                (Source.IsFooter(firstIndex) && (Source.Count - 1) == firstIndex))
            {
                StepCandidate = 0F;
                failed = true;
            }

            while (!failed &&
                   (Source.IsHeader(firstIndex) ||
                    Source.IsGroupHeader(firstIndex) ||
                    Source.IsGroupFooter(firstIndex)))
            {
                if (Source.IsFooter(firstIndex)
                    || ((Source.Count - 1) <= firstIndex))
                {
                    StepCandidate = 0F;
                    failed = true;
                    break;
                }
                firstIndex++;
            }

            if (!failed)
            {
                RecyclerViewItem sizeDeligate = collectionView.RealizeItem(firstIndex);
                if (sizeDeligate == null)
                {
                    // error !
                    throw new Exception("Cannot create content from DatTemplate.");
                }

                sizeDeligate.BindingContext = Source.GetItem(firstIndex);

                // Need to Set proper height or width on scroll direction.
                if (sizeDeligate.Layout == null)
                {
                    width = sizeDeligate.WidthSpecification;
                    height = sizeDeligate.HeightSpecification;
                }
                else
                {
                    MeasureChild(collectionView, sizeDeligate);

                    width = sizeDeligate.Layout.MeasuredWidth.Size.AsRoundedValue();
                    height = sizeDeligate.Layout.MeasuredHeight.Size.AsRoundedValue();
                }
                // pick the StepCandidate.
                Extents itemMargin = sizeDeligate.Margin;
                StepCandidate = IsHorizontal?
                                width + itemMargin.Start + itemMargin.End:
                                height + itemMargin.Top + itemMargin.Bottom;
                CandidateMargin = new Extents(itemMargin);
                if (StepCandidate == 0) StepCandidate = 1; //????

                collectionView.UnrealizeItem(sizeDeligate, false);
            }

            float Current = IsHorizontal? Padding.Start : Padding.Top;
            IGroupableItemSource source = Source;
            GroupInfo currentGroup = null;
            object currentParent = null;
            for (int i = 0; i < count; i++)
            {
                if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
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
                    if (source.IsHeader(i))
                    {
                        //ItemPosition.Add(Current);
                        Current += headerSize;
                    }
                    else if (source.IsFooter(i))
                    {
                        //ItemPosition.Add(Current);
                        Current += footerSize;
                    }
                    else
                    {
                        //GroupHeader must always exist in group usage.
                        //if (source.IsGroupHeader(i))
                        if (source.GetGroupParent(i) != currentParent)
                        {
                            currentParent = source.GetGroupParent(i);
                            float currentSize = (source.IsGroupHeader(i)? groupHeaderSize :
                                                    (source.IsGroupFooter(i)? groupFooterSize: StepCandidate));
                            currentGroup = new GroupInfo()
                            {
                                GroupParent = currentParent,
                                //hasHeader = true,
                                //hasFooter = false,
                                StartIndex = i,
                                Count = 1,
                                GroupSize = currentSize,
                                GroupPosition = Current
                            };
                            if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                                currentGroup.ItemPosition.Add(0);
                            groups.Add(currentGroup);
                            if (source.IsGroupHeader(i)) Current += currentSize;
                        }
                        //optional
                        else if (source.IsGroupFooter(i))
                        {
                            //currentGroup.hasFooter = true;
                            if (currentGroup != null)
                            {
                                currentGroup.Count++;
                                currentGroup.GroupSize += groupFooterSize;
                                if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                                    currentGroup.ItemPosition.Add(Current - currentGroup.GroupPosition);
                                Current += groupFooterSize;
                            }
                        }
                        else
                        {
                            if (currentGroup != null)
                            {
                                currentGroup.Count++;
                                currentGroup.GroupSize += StepCandidate;
                                if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                                    currentGroup.ItemPosition.Add(Current - currentGroup.GroupPosition);
                                Current += StepCandidate;
                            }
                        }
                    }
                }
                else
                {
                    if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                        ItemPosition.Add(Current);

                    if (i == 0 && hasHeader) Current += headerSize;
                    else if (i == count - 1 && hasFooter) Current += footerSize;
                    else Current += StepCandidate;
                }
            }

            ScrollContentSize = Current + (IsHorizontal? Padding.End : Padding.Bottom);
            if (IsHorizontal) collectionView.ContentContainer.SizeWidth = ScrollContentSize;
            else collectionView.ContentContainer.SizeHeight = ScrollContentSize;

            base.Initialize(view);
            //Console.WriteLine("[NUI] Init Done, StepCnadidate{0}, Scroll{1}", StepCandidate, ScrollContentSize);
        }

        /// <summary>
        /// This is called to find out where items are lain out according to current scroll position.
        /// </summary>
        /// <param name="scrollPosition">Scroll position which is calculated by ScrollableBase</param>
        /// <param name="force">boolean force flag to layouting forcely.</param>
        /// <since_tizen> 9 </since_tizen>
        public override void RequestLayout(float scrollPosition, bool force = false)
        {
            // Layouting is only possible after once it initialized.
            if (!IsInitialized) return;

            if (requestLayoutTimer != null)
            {
                requestLayoutTimer.Dispose();
                requestLayoutTimer = null;
                force = true;
            }

            int LastIndex = Source.Count - 1;

            if (!force && PrevScrollPosition == Math.Abs(scrollPosition)) return;
            PrevScrollPosition = Math.Abs(scrollPosition);

            if (ItemSizeChanged >= 0)
            {
                for (int i = ItemSizeChanged; i <= LastIndex; i++)
                    UpdatePosition(i);
                (float updateX, float updateY) = GetItemPosition(LastIndex);
                ScrollContentSize = GetItemStepSize(LastIndex) + (IsHorizontal? updateX + Padding.End : updateY + Padding.Bottom);
            }

            int prevFirstVisible = FirstVisible;
            int prevLastVisible = LastVisible;

            (float X, float Y) visibleArea = (PrevScrollPosition,
                PrevScrollPosition + (IsHorizontal? collectionView.Size.Width : collectionView.Size.Height)
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
                    unrealizedItems.Add(item);
                    collectionView.UnrealizeItem(item);
                }
            }
            VisibleItems.RemoveAll(unrealizedItems.Contains);
            unrealizedItems.Clear();

            // 3. Realize and placing visible items.
            for (int i = FirstVisible; i <= LastVisible; i++)
            {
                RecyclerViewItem item = null;
                // 4. Get item if visible or realize new.
                if (i >= prevFirstVisible && i <= prevLastVisible)
                {
                    item = GetVisibleItem(i);
                    if (item != null && !force) continue;
                }

                if (item == null)
                {
                    item = collectionView.RealizeItem(i);
                    if (item != null) VisibleItems.Add(item);
                    else throw new Exception("Failed to create RecycerViewItem index of ["+ i + "]");
                }
                // 5. Placing item.
                (float posX, float posY) = GetItemPosition(i);
                item.Position = new Position(posX, posY);

                var size = (IsHorizontal? item.SizeWidth: item.SizeHeight);

                if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureFirst)
                {
                    if (item.IsHeader || item.IsFooter || item.IsGroupHeader || item.IsGroupFooter)
                    {
                        if (item.IsHeader) size = headerSize;
                        else if (item.IsFooter) size = footerSize;
                        else if (item.IsGroupHeader) size = groupHeaderSize;
                        else if (item.IsGroupFooter) size = groupFooterSize;
                    }
                    else size = StepCandidate;
                }
                if (IsHorizontal && item.HeightSpecification == LayoutParamPolicies.MatchParent)
                {
                    item.Size = new Size(size, Container.Size.Height - Padding.Top - Padding.Bottom - item.Margin.Top - item.Margin.Bottom);
                }
                else if (!IsHorizontal && item.WidthSpecification == LayoutParamPolicies.MatchParent)
                {
                    item.Size = new Size(Container.Size.Width - Padding.Start - Padding.End - item.Margin.Start - item.Margin.End, size);
                }
            }
            return;
        }

        /// <summary>
        /// Clear the current screen and all properties.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Clear()
        {
            // Clean Up
            if (requestLayoutTimer != null)
            {
                requestLayoutTimer.Dispose();
            }
            if (groups != null)
            {
                 /*
                foreach (GroupInfo group in groups)
                {
                    //group.ItemPosition?.Clear();
                    // if Disposable?
                    //group.Dispose();
                }
                */
                groups.Clear();
            }
            if (ItemPosition != null)
            {
                ItemPosition.Clear();
            }
            if (ItemSize != null)
            {
                ItemSize.Clear();
            }
            if (headerMargin != null)
            {
                headerMargin.Dispose();
                headerMargin = null;
            }
            if (footerMargin != null)
            {
                footerMargin.Dispose();
                footerMargin = null;
            }
            if (groupHeaderMargin != null)
            {
                groupHeaderMargin.Dispose();
                groupHeaderMargin = null;
            }
            if (groupFooterMargin != null)
            {
                groupFooterMargin.Dispose();
                groupFooterMargin = null;
            }

            base.Clear();
        }


        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void NotifyItemSizeChanged(RecyclerViewItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (collectionView == null) return;

            if (!IsInitialized ||
                (collectionView.SizingStrategy == ItemSizingStrategy.MeasureFirst &&
                item.Index != 0) ||
                (item.Index < 0))
                return;

            float PrevSize, CurrentSize;
            if (item.Index == (Source.Count - 1))
            {
                PrevSize = ScrollContentSize - ItemPosition[item.Index];
            }
            else
            {
                PrevSize = ItemPosition[item.Index + 1] - ItemPosition[item.Index];
            }

            CurrentSize = (IsHorizontal? item.Size.Width : item.Size.Height);

            if (CurrentSize != PrevSize)
            {
                if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
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
        public override void NotifyItemInserted(IItemSource source, int startIndex)
        {
            // Insert Single item.
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionView == null) return;

            if (isSourceEmpty || StepCandidate == 0)
            {
                Initialize(collectionView);
            }

            // Will be null if not a group.
            float currentSize = StepCandidate;
            IGroupableItemSource gSource = source as IGroupableItemSource;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
            */

            // 1. Handle MeasureAll
            /*
            if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
            {
                //Need To Implement
            }
            */

            //2. Handle Group Case.
            if (isGrouped && gSource != null)
            {
                GroupInfo groupInfo = null;
                object groupParent = gSource.GetGroupParent(startIndex);
                int parentIndex = gSource.GetPosition(groupParent);
                if (gSource.HasHeader) parentIndex--;

                // Check item is group parent or not
                // if group parent, add new gorupinfo
                if (gSource.IsHeader(startIndex))
                {
                    // This is childless group.
                    // create new groupInfo!
                    groupInfo = new GroupInfo()
                    {
                        GroupParent = groupParent,
                        StartIndex = startIndex,
                        Count = 1,
                        GroupSize = groupHeaderSize,
                    };

                    if (parentIndex >= groups.Count)
                    {
                        groupInfo.GroupPosition = ScrollContentSize;
                        groups.Add(groupInfo);
                    }
                    else
                    {
                        groupInfo.GroupPosition = groups[parentIndex].GroupPosition;
                        groups.Insert(parentIndex, groupInfo);
                    }

                    currentSize = groupHeaderSize;
                }
                else
                {
                    // If not group parent, add item into the groupinfo.
                    if (parentIndex >= groups.Count) throw new Exception("group parent is bigger than group counts.");
                    groupInfo = groups[parentIndex];//GetGroupInfo(groupParent);
                    if (groupInfo == null) throw new Exception("Cannot find group information!");
                    groupInfo.Count++;

                    if (gSource.IsGroupFooter(startIndex))
                    {
                        // It doesn't make sence to adding footer by notify...
                        // if GroupFooterTemplate is added,
                        // need to implement on here.
                    }
                    else
                    {
                        if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                        {
                            float curPos = groupInfo.ItemPosition[startIndex - groupInfo.StartIndex];
                            groupInfo.ItemPosition.Insert(startIndex - groupInfo.StartIndex, curPos);
                            for (int i = startIndex - groupInfo.StartIndex; i < groupInfo.Count; i++)
                            {
                                groupInfo.ItemPosition[i] = curPos;
                                curPos += GetItemStepSize(parentIndex + i);
                            }
                            groupInfo.GroupSize = curPos;
                        }
                        else
                        {
                            groupInfo.GroupSize += currentSize;
                        }
                    }
                }

                if (parentIndex + 1 < groups.Count)
                {
                    for(int i = parentIndex + 1; i < groups.Count; i++)
                    {
                        groups[i].GroupPosition += currentSize;
                        groups[i].StartIndex++;
                    }
                }
            }
            else
            {
                if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                {
                    // Need to Implements
                }

            }

            // 3. Update Scroll Content Size
            ScrollContentSize += currentSize;

            if (IsHorizontal) collectionView.ContentContainer.SizeWidth = ScrollContentSize;
            else collectionView.ContentContainer.SizeHeight = ScrollContentSize;

            // 4. Update Visible Items.
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if (item.Index >= startIndex)
                {
                    item.Index++;
                }
            }

            if (startIndex <= FirstVisible)
            {
                FirstVisible++;
                LastVisible++;
            }
            else if (startIndex > FirstVisible && startIndex <= LastVisible)
            {
                LastVisible++;
            }

            if (FirstVisible > Source.Count - 1) FirstVisible = Source.Count -1;
            if (LastVisible > Source.Count - 1) LastVisible = Source.Count -1;

            float scrollPosition = PrevScrollPosition;

            /*
            // Position Adjust
            // Insertion above Top Visible!
            if (startIndex <= topInScreenIndex)
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                collectionView.ScrollTo(scrollPosition);
            }
            */

            // Update Viewport in delay.
            // FIMXE: original we only need to process RequestLayout once before layout calculation in main loop.
            // but currently we do not have any accessor to pre-calculation so instead of this,
            // using Timer temporarily.
            DelayedRequestLayout(scrollPosition);
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void NotifyItemRangeInserted(IItemSource source, int startIndex, int count)
        {
             // Insert Group
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionView == null) return;

            if (isSourceEmpty || StepCandidate == 0)
            {
                Initialize(collectionView);
            }

            float currentSize = StepCandidate;
            // Will be null if not a group.
            IGroupableItemSource gSource = source as IGroupableItemSource;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
            */

            // 1. Handle MeasureAll
            /*
            if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
            {
                //Need To Implement
            }
            */

            // 2. Handle Group Case
            // Adding ranged items should all same new groups.
            if (isGrouped && gSource != null)
            {
                GroupInfo groupInfo = null;
                object groupParent = gSource.GetGroupParent(startIndex);
                int parentIndex = gSource.GetPosition(groupParent);
                if (gSource.HasHeader) parentIndex--;

                // We guess here that range inserted from GroupStartIndex.
                int groupStartIndex = startIndex;

                for (int current = startIndex; current - startIndex < count; current++)
                {
                    // Check item is group parent or not
                    // if group parent, add new gorupinfo
                    if (groupStartIndex == current)
                    {
                        currentSize = (gSource.IsGroupHeader(current)? groupHeaderSize :
                                            (gSource.IsGroupFooter(current)? groupFooterSize: currentSize));
                        //create new groupInfo!
                        groupInfo = new GroupInfo()
                        {
                            GroupParent = groupParent,
                            StartIndex = current,
                            Count = 1,
                            GroupSize = currentSize,
                        };

                    }
                    else
                    {
                        //if not group parent, add item into the groupinfo.
                        //groupInfo = GetGroupInfo(groupStartIndex);
                        if (groupInfo == null) throw new Exception("Cannot find group information!");
                        groupInfo.Count++;

                        if (gSource.IsGroupFooter(current))
                        {
                                groupInfo.GroupSize += groupFooterSize;
                        }
                        else
                        {
                            if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                            {
                               //Need To Implement
                               /*
                                float curPos = groupInfo.ItemPosition[current - groupStartIndex];
                                groupInfo.ItemPosition.Insert(current - groupStartIndex, curPos);
                                for (int i = current - groupStartIndex; i < groupInfo.Count; i++)
                                {
                                    groupInfo.ItemPosition[i] = curPos;
                                    curPos += GetItemSize(parentIndex + i);
                                }
                                groupInfo.GroupSize = curPos;
                                */
                            }
                            else
                            {
                                groupInfo.GroupSize += StepCandidate;
                            }
                        }
                    }
                }

                if (groupInfo != null)
                {
                    if (parentIndex >= groups.Count)
                    {
                        groupInfo.GroupPosition = ScrollContentSize;
                        groups.Add(groupInfo);
                    }
                    else
                    {
                        groupInfo.GroupPosition = groups[parentIndex].GroupPosition;
                        groups.Insert(parentIndex, groupInfo);
                    }

                    // Update other below group's position
                    if (parentIndex + 1 < groups.Count)
                    {
                        for(int i = parentIndex + 1; i < groups.Count; i++)
                        {
                            groups[i].GroupPosition += groupInfo.GroupSize;
                            groups[i].StartIndex += count;
                        }
                    }

                    ScrollContentSize += groupInfo.GroupSize;
                }
                else
                {
                    Tizen.Log.Error("NUI", "groupInfo is null! Check count = 0");
                }
            }
            else
            {
                Tizen.Log.Error("NUI", "Not support insert ungrouped range items currently!");
            }

            // 3. Update Scroll Content Size
            if (IsHorizontal) collectionView.ContentContainer.SizeWidth = ScrollContentSize;
            else collectionView.ContentContainer.SizeHeight = ScrollContentSize;

            // 4. Update Visible Items.
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if (item.Index >= startIndex)
                {
                    item.Index += count;
                }
            }

            if (startIndex <= FirstVisible)
            {
                FirstVisible = FirstVisible + count;
                LastVisible = LastVisible + count;
            }
            else if (startIndex > FirstVisible && startIndex <= LastVisible)
            {
                LastVisible = LastVisible + count;
            }

            if (FirstVisible > Source.Count - 1) FirstVisible = Source.Count -1;
            if (LastVisible > Source.Count - 1) LastVisible = Source.Count -1;

            // Position Adjust
            float scrollPosition = PrevScrollPosition;
            /*
            // Insertion above Top Visible!
            if (startIndex + count <= topInScreenIndex)
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                collectionView.ScrollTo(scrollPosition);
            }
            */

            // Update Viewport in delay.
            // FIMXE: original we only need to process RequestLayout once before layout calculation in main loop.
            // but currently we do not have any accessor to pre-calculation so instead of this,
            // using Timer temporarily.
            DelayedRequestLayout(scrollPosition);
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void NotifyItemRemoved(IItemSource source, int startIndex)
        {
            // Remove Single
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionView == null) return;

            // Will be null if not a group.
            float currentSize = StepCandidate;
            IGroupableItemSource gSource = source as IGroupableItemSource;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
            */

            // 1. Handle MeasureAll
            /*
            if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
            {
                //Need To Implement
            }
            */

            // 2. Handle Group Case
            if (isGrouped && gSource != null)
            {
                int parentIndex = 0;
                GroupInfo groupInfo = null;
                foreach(GroupInfo cur in groups)
                {
                    if ((cur.StartIndex <= startIndex) && (cur.StartIndex + cur.Count - 1 >= startIndex))
                    {
                        groupInfo = cur;
                        break;
                    }
                    parentIndex++;
                }
                if (groupInfo == null) throw new Exception("Cannot find group information!");
                // Check item is group parent or not
                // if group parent, add new gorupinfo
                if (groupInfo.StartIndex == startIndex)
                {
                    // This is empty group!
                    // check group is empty.
                    if (groupInfo.Count != 1)
                    {
                        throw new Exception("Cannot remove group parent");
                    }
                    currentSize = groupInfo.GroupSize;

                    // Remove Group
                    // groupInfo.Dispose();
                    groups.Remove(groupInfo);
                    parentIndex--;
                }
                else
                {
                    groupInfo.Count--;

                    if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                    {
                        //Need to Implement this.
                    }
                    else
                    {
                        groupInfo.GroupSize -= currentSize;
                    }
                }

                for (int i = parentIndex + 1; i < groups.Count; i++)
                {
                    groups[i].GroupPosition -= currentSize;
                    groups[i].StartIndex--;
                }
            }
            else
            {
                if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                {
                    // Need to Implements
                }
                // else Nothing to Do
            }

            ScrollContentSize -= currentSize;

            // 3. Update Scroll Content Size
            if (IsHorizontal) collectionView.ContentContainer.SizeWidth = ScrollContentSize;
            else collectionView.ContentContainer.SizeHeight = ScrollContentSize;

            // 4. Update Visible Items.
            RecyclerViewItem targetItem = null;
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if (item.Index == startIndex)
                {
                    targetItem = item;
                    collectionView.UnrealizeItem(item);
                }
                else if (item.Index > startIndex)
                {
                    item.Index--;
                }
            }
            VisibleItems.Remove(targetItem);


            if (startIndex <= FirstVisible)
            {
                FirstVisible--;
                LastVisible--;
            }
            else if (startIndex > FirstVisible && startIndex <= LastVisible)
            {
                LastVisible--;
            }

            if (FirstVisible < 0) FirstVisible = 0;
            if (LastVisible < 0) LastVisible = 0;

            // Position Adjust
            float scrollPosition = PrevScrollPosition;
            /*
            // Insertion above Top Visible!
            if (startIndex <= topInScreenIndex)
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                collectionView.ScrollTo(scrollPosition);
            }
            */

            // Update Viewport in delay.
            // FIMXE: original we only need to process RequestLayout once before layout calculation in main loop.
            // but currently we do not have any accessor to pre-calculation so instead of this,
            // using Timer temporarily.
            DelayedRequestLayout(scrollPosition);
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void NotifyItemRangeRemoved(IItemSource source, int startIndex, int count)
        {
            // Remove Group
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionView == null) return;

            // Will be null if not a group.
            float currentSize = StepCandidate;
            IGroupableItemSource gSource = source as IGroupableItemSource;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
            */

            // 1. Handle MeasureAll
            /*
            if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
            {
                //Need To Implement
            }
            */

            // 2. Handle Group Case
            if (isGrouped && gSource != null)
            {
                int parentIndex = 0;
                GroupInfo groupInfo = null;
                foreach(GroupInfo cur in groups)
                {
                    if ((cur.StartIndex == startIndex) && (cur.Count == count))
                    {
                        groupInfo = cur;
                        break;
                    }
                    parentIndex++;
                }
                if (groupInfo == null) throw new Exception("Cannot find group information!");
                // Check item is group parent or not
                // if group parent, add new gorupinfo
                currentSize = groupInfo.GroupSize;
                if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                {
                    // Update ItemSize and ItemPosition
                }
                // Remove Group
                // groupInfo.Dispose();
                groups.Remove(groupInfo);

                for (int i = parentIndex; i < groups.Count; i++)
                {
                    groups[i].GroupPosition -= currentSize;
                    groups[i].StartIndex -= count;
                }
            }
            else
            {
                //It must group case! throw exception!
                Tizen.Log.Error("NUI", "Not support remove ungrouped range items currently!");
            }

            ScrollContentSize -= currentSize;

            // 3. Update Scroll Content Size
            if (IsHorizontal) collectionView.ContentContainer.SizeWidth = ScrollContentSize;
            else collectionView.ContentContainer.SizeHeight = ScrollContentSize;

            // 4. Update Visible Items.
            List<RecyclerViewItem> unrealizedItems = new List<RecyclerViewItem>();
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if ((item.Index >= startIndex)
                    && (item.Index < startIndex + count))
                {
                    unrealizedItems.Add(item);
                    collectionView.UnrealizeItem(item);
                }
                else if (item.Index >= startIndex + count)
                {
                    item.Index -= count;
                }
            }
            VisibleItems.RemoveAll(unrealizedItems.Contains);
            unrealizedItems.Clear();

            if (startIndex <= FirstVisible)
            {
                FirstVisible = FirstVisible - count;
                LastVisible = LastVisible - count;
            }
            else if (startIndex > FirstVisible && startIndex <= LastVisible)
            {
                LastVisible = LastVisible - count;
            }

            if (FirstVisible < 0) FirstVisible = 0;
            if (LastVisible < 0) LastVisible = 0;

            // Position Adjust
            float scrollPosition = PrevScrollPosition;
            /*
            // Insertion above Top Visible!
            if (startIndex <= topInScreenIndex)
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                collectionView.ScrollTo(scrollPosition);
            }
            */

            // Update Viewport in delay.
            // FIMXE: original we only need to process RequestLayout once before layout calculation in main loop.
            // but currently we do not have any accessor to pre-calculation so instead of this,
            // using Timer temporarily.
            DelayedRequestLayout(scrollPosition);
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void NotifyItemMoved(IItemSource source, int fromPosition, int toPosition)
        {
            // Reorder Single
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionView == null) return;

            float currentSize = StepCandidate;
            int diff = toPosition - fromPosition;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
            */

            // 1. Handle MeasureAll
            /*
            if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
            {
                //Need To Implement
            }
            */

            // Move can only happen in it's own groups.
            // so there will be no changes in position, startIndex in ohter groups.
            // check visible item and update indexs.
            int startIndex = ( diff > 0 ? fromPosition: toPosition);
            int endIndex = (diff > 0 ? toPosition: fromPosition);

            // all items are within the visual area
            if ((endIndex >= FirstVisible) && (startIndex <= LastVisible))
            {
                foreach (RecyclerViewItem item in VisibleItems)
                {
                    if ((item.Index >= startIndex)
                        && (item.Index <= endIndex))
                    {
                        if (item.Index == fromPosition) item.Index = toPosition;
                        else
                        {
                            if (diff > 0) item.Index--;
                            else item.Index++;
                        }
                    }
                }
            }

            if (fromPosition < FirstVisible)
            {
                if (toPosition > LastVisible)
                {
                    FirstVisible--;
                    LastVisible--;
                }
                else if (toPosition > FirstVisible && toPosition <= LastVisible)
                {
                    FirstVisible--;
                }
            }
            else if (fromPosition >= FirstVisible && fromPosition <= LastVisible)
            {
                if (toPosition < FirstVisible)
                {
                    FirstVisible++;
                }
                else if (toPosition > LastVisible)
                {
                    LastVisible--;
                }
            }
            else if (fromPosition > LastVisible)
            {
                if (toPosition <= FirstVisible)
                {
                    FirstVisible++;
                    LastVisible++;
                }
                else if (toPosition > FirstVisible && toPosition <= LastVisible)
                {
                    LastVisible++;
                }
            }

            if (FirstVisible < 0) FirstVisible = 0;
            if (LastVisible < 0) LastVisible = 0;
            if (FirstVisible > Source.Count - 1) FirstVisible = Source.Count -1;
            if (LastVisible > Source.Count - 1) LastVisible = Source.Count -1;


            if (IsHorizontal) collectionView.ContentContainer.SizeWidth = ScrollContentSize;
            else collectionView.ContentContainer.SizeHeight = ScrollContentSize;

            // Position Adjust
            float scrollPosition = PrevScrollPosition;
            /*
            // Insertion above Top Visible!
            if (((fromPosition > topInScreenIndex) && (toPosition < topInScreenIndex) ||
                ((fromPosition < topInScreenIndex) && (toPosition > topInScreenIndex)))
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                collectionView.ScrollTo(scrollPosition);
            }
            */

            // Update Viewport in delay.
            // FIMXE: original we only need to process RequestLayout once before layout calculation in main loop.
            // but currently we do not have any accessor to pre-calculation so instead of this,
            // using Timer temporarily.
            DelayedRequestLayout(scrollPosition);
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void NotifyItemRangeMoved(IItemSource source, int fromPosition, int toPosition, int count)
        {
            // Reorder Groups
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionView == null) return;

            // Will be null if not a group.
            float currentSize = StepCandidate;
            int diff = toPosition - fromPosition;

            int startIndex = ( diff > 0 ? fromPosition: toPosition);
            int endIndex = (diff > 0 ? toPosition + count - 1: fromPosition + count - 1);

            // 2. Handle Group Case
            if (isGrouped)
            {
                int fromParentIndex = 0;
                int toParentIndex = 0;
                bool findFrom = false;
                bool findTo = false;
                GroupInfo fromGroup = null;
                GroupInfo toGroup = null;

                foreach(GroupInfo cur in groups)
                {
                    if ((cur.StartIndex == fromPosition) && (cur.Count == count))
                    {
                        fromGroup = cur;
                        findFrom = true;
                        if (findFrom && findTo) break;
                    }
                    else if (cur.StartIndex == toPosition)
                    {
                        toGroup = cur;
                        findTo = true;
                        if (findFrom && findTo) break;
                    }
                    if (!findFrom) fromParentIndex++;
                    if (!findTo) toParentIndex++;
                }
                if (toGroup == null || fromGroup == null) throw new Exception("Cannot find group information!");

                fromGroup.StartIndex = toGroup.StartIndex;
                fromGroup.GroupPosition = toGroup.GroupPosition;

                endIndex = (diff > 0 ? toPosition + toGroup.Count - 1: fromPosition + count - 1);

                groups.Remove(fromGroup);
                groups.Insert(toParentIndex, fromGroup);

                int startGroup = (diff > 0? fromParentIndex: toParentIndex);
                int endGroup =  (diff > 0? toParentIndex: fromParentIndex);

                for (int i = startGroup; i <= endGroup; i++)
                {
                    if (i == toParentIndex) continue;
                    float prevPos = groups[i].GroupPosition;
                    int prevIdx = groups[i].StartIndex;
                    groups[i].GroupPosition = groups[i].GroupPosition + (diff > 0? -1 : 1) * fromGroup.GroupSize;
                    groups[i].StartIndex = groups[i].StartIndex + (diff > 0? -1 : 1) * fromGroup.Count;
                }
            }
            else
            {
                //It must group case! throw exception!
                Tizen.Log.Error("NUI", "Not support move ungrouped range items currently!");
            }

            // Move can only happen in it's own groups.
            // so there will be no changes in position, startIndex in ohter groups.
            // check visible item and update indexs.
            if ((endIndex >= FirstVisible) && (startIndex <= LastVisible))
            {
                foreach (RecyclerViewItem item in VisibleItems)
                {
                    if ((item.Index >= startIndex)
                        && (item.Index <= endIndex))
                    {
                        if ((item.Index >= fromPosition) && (item.Index < fromPosition + count))
                        {
                            item.Index = fromPosition - item.Index + toPosition;
                        }
                        else
                        {
                            if (diff > 0) item.Index -= count;
                            else item.Index += count;
                        }
                    }
                }
            }
            // FIXME!! Unraelize All and reset First/Last Visible
            foreach (RecyclerViewItem item in VisibleItems)
            {
                collectionView.UnrealizeItem(item);
            }
            VisibleItems.Clear();
            FirstVisible = 0;
            LastVisible = 0;

            // Position Adjust
            float scrollPosition = PrevScrollPosition;
            /*
            // Insertion above Top Visible!
            if (((fromPosition > topInScreenIndex) && (toPosition < topInScreenIndex) ||
                ((fromPosition < topInScreenIndex) && (toPosition > topInScreenIndex)))
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                collectionView.ScrollTo(scrollPosition);
            }
            */

            // Update Viewport in delay.
            // FIMXE: original we only need to process RequestLayout once before layout calculation in main loop.
            // but currently we do not have any accessor to pre-calculation so instead of this,
            // using Timer temporarily.
            DelayedRequestLayout(scrollPosition);
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void NotifyItemRangeChanged(IItemSource source, int startRange, int endRange)
        {
            // Reorder Group
            if (source == null) throw new ArgumentNullException(nameof(source));
            IGroupableItemSource gSource = source as IGroupableItemSource;
            if (gSource == null)throw new Exception("Source is not group!");
            if (collectionView == null) return;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
            */


            // Unrealize, initialized all items in the Range
            // and receate all.

            // Update Viewport in delay.
            // FIMXE: original we only need to process RequestLayout once before layout calculation in main loop.
            // but currently we do not have any accessor to pre-calculation so instead of this,
            // using Timer temporarily.
            DelayedRequestLayout(PrevScrollPosition);
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
                        targetSibling = IsHorizontal? currentFocusedView.SiblingOrder - 1 : targetSibling;
                        break;
                    }
                case View.FocusDirection.Right:
                    {
                        targetSibling = IsHorizontal? currentFocusedView.SiblingOrder + 1 : targetSibling;
                        break;
                    }
                case View.FocusDirection.Up:
                    {
                        targetSibling = IsHorizontal? targetSibling : currentFocusedView.SiblingOrder - 1;
                        break;
                    }
                case View.FocusDirection.Down:
                    {
                        targetSibling = IsHorizontal? targetSibling : currentFocusedView.SiblingOrder + 1;
                        break;
                    }
                default:
                    break;
            }

            if (targetSibling > -1 && targetSibling < Container.Children.Count)
            {
                RecyclerViewItem candidate = Container.Children[targetSibling] as RecyclerViewItem;
                if (candidate != null && candidate.Index >= 0 && candidate.Index < Source.Count)
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
            int MaxIndex = Source.Count - 1 - (hasFooter? 1 : 0);
            int adds = 5;
            int skipGroup = -2;
            (int start, int end) found = (0, 0);

            // 1. Find the start index.
            // Header is Showing
            if (hasHeader && visibleArea.X <= headerSize + (IsHorizontal? Padding.Start: Padding.Top))
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
                                else if (GetGroupPosition(gInfo, gInfo.StartIndex + i) <= visibleArea.X &&
                                        GetGroupPosition(gInfo, gInfo.StartIndex + i + 1) >= visibleArea.X)
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
                    float visibleAreaX = visibleArea.X - (hasHeader? headerSize : 0);
                    // Prevent zero division.
                    var itemSize = (StepCandidate != 0)? StepCandidate : 1f;
                    found.start = (Convert.ToInt32(Math.Abs(visibleAreaX / itemSize)) - adds);
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
                                    //Should be groupFooter!
                                    found.end = gInfo.StartIndex + i + adds;
                                    failed = false;
                                    break;

                                }
                                else if (GetGroupPosition(gInfo, gInfo.StartIndex + i) <= visibleArea.Y &&
                                        GetGroupPosition(gInfo, gInfo.StartIndex + i + 1) >= visibleArea.Y)
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
                    float visibleAreaY = visibleArea.Y - (hasHeader? headerSize : 0);
                    // Prevent zero division.
                    var itemSize = (StepCandidate != 0)? StepCandidate : 1f;
                    found.end = (Convert.ToInt32(Math.Abs(visibleAreaY / itemSize)) + adds);
                    if (hasHeader) found.end += 1;
                }
                if (found.end > (MaxIndex)) found.end = MaxIndex;
            }
            return found;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal override (float X, float Y) GetItemPosition(int index)
        {
            int spaceStartX = Padding.Start;
            int spaceStartY = Padding.Top;
            if (Source.IsHeader(index))
            {
                return (spaceStartX + headerMargin.Start, spaceStartY + headerMargin.Top);
            }
            else if (Source.IsFooter(index))
            {
                return ((IsHorizontal? ScrollContentSize - footerSize - Padding.End + footerMargin.Start : spaceStartX + footerMargin.Start),
                        (IsHorizontal? spaceStartY + footerMargin.Top : ScrollContentSize - footerSize - Padding.Bottom + footerMargin.Top));
            }
            else if (isGrouped)
            {
                GroupInfo gInfo = GetGroupInfo(index);
                if (gInfo == null)
                {
                    Tizen.Log.Error("NUI", "GroupInfo failed to get in GetItemPosition()!");
                    return (0, 0);
                }
                float current = GetGroupPosition(gInfo, index);
                Extents itemMargin = CandidateMargin;

                if (Source.IsGroupHeader(index))
                {
                    itemMargin = groupHeaderMargin;
                }
                else if (Source.IsGroupFooter(index))
                {
                    itemMargin = groupFooterMargin;
                }
                return ((IsHorizontal?
                        itemMargin.Start + GetGroupPosition(gInfo, index):
                        spaceStartX + itemMargin.Start),
                        (IsHorizontal?
                        spaceStartY + itemMargin.Top:
                        itemMargin.Top + GetGroupPosition(gInfo, index)));
            }
            else if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
            {
                //FIXME : CandidateMargin need to be actual itemMargin
                return ((IsHorizontal? ItemPosition[index] + CandidateMargin.Start : spaceStartX + CandidateMargin.Start),
                        (IsHorizontal? spaceStartY + CandidateMargin.Top : ItemPosition[index] + CandidateMargin.Top));
            }
            else
            {
                int adjustIndex = index - (hasHeader ? 1 : 0);
                float current = (IsHorizontal ? spaceStartX : spaceStartY) + (hasHeader? headerSize : 0) + adjustIndex * StepCandidate;
                //FIXME : CandidateMargin need to be actual itemMargin
                return ((IsHorizontal? current + CandidateMargin.Start : spaceStartX + CandidateMargin.Start),
                        (IsHorizontal? spaceStartY + CandidateMargin.Top : current + CandidateMargin.Top));
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal override (float Width, float Height) GetItemSize(int index)
        {
            if (Source.IsHeader(index))
            {
                return ((IsHorizontal? (int)headerSize : (int)(collectionView.Size.Width) - Padding.Start - Padding.End)
                        - headerMargin.Start - headerMargin.End,
                        (IsHorizontal? (int)collectionView.Size.Height - Padding.Top - Padding.Bottom: (int)headerSize)
                        - headerMargin.Top - headerMargin.Bottom);
            }
            else if (Source.IsFooter(index))
            {
                return ((IsHorizontal? (int)footerSize : (int)(collectionView.Size.Width) - Padding.Start - Padding.End)
                        - footerMargin.Start - footerMargin.End,
                        (IsHorizontal? (int)collectionView.Size.Height - Padding.Top - Padding.Bottom: (int)footerSize)
                        - footerMargin.Top - footerMargin.Bottom);
            }
            else if (Source.IsGroupHeader(index))
            {
                return ((IsHorizontal? (int)groupHeaderSize : (int)(collectionView.Size.Width) - Padding.Start - Padding.End)
                        - groupHeaderMargin.Start - groupHeaderMargin.End,
                        (IsHorizontal? (int)collectionView.Size.Height - Padding.Top - Padding.Bottom: (int)groupHeaderSize)
                        - groupHeaderMargin.Top - groupHeaderMargin.Bottom);
            }
            else if (Source.IsGroupFooter(index))
            {
                return ((IsHorizontal? (int)groupFooterSize : (int)(collectionView.Size.Width) - Padding.Start - Padding.End)
                        - groupFooterMargin.Start - groupFooterMargin.End,
                        (IsHorizontal? (int)collectionView.Size.Height - Padding.Top - Padding.Bottom: (int)groupFooterSize)
                        - groupFooterMargin.Top - groupFooterMargin.Bottom);
            }
            else
            {
                return ((IsHorizontal? (int)StepCandidate : (int)(collectionView.Size.Width) - Padding.Start - Padding.End)
                        - CandidateMargin.Start - CandidateMargin.End,
                        (IsHorizontal? (int)collectionView.Size.Height - Padding.Top - Padding.Bottom: (int)StepCandidate)
                        - CandidateMargin.Top - CandidateMargin.Bottom);
            }
        }

        private void DelayedRequestLayout(float scrollPosition , bool force = true)
        {
            if (requestLayoutTimer != null)
            {
                requestLayoutTimer.Dispose();
            }

            requestLayoutTimer = new Timer(1);
            requestLayoutTimer.Interval = 1;
            requestLayoutTimer.Tick += ((object target, Timer.TickEventArgs args) =>
            {
                RequestLayout(scrollPosition, force);
                return false;
            });
            requestLayoutTimer.Start();
        }

        /*
        private (int, float) FindTopItemInScreen()
        {
            int index = -1;
            float offset = 0.0F, Pos, Size;

            foreach(RecyclerViewItem item in VisibleItems)
            {
                Pos = IsHorizontal ? item.PositionX : item.PositionY;
                Size = IsHorizontal ? item.SizeWidth : item.SizeHeight;
                if (PrevScrollPosition >= Pos && PrevScrollPosition < Pos + Size)
                {
                    index = item.Index;
                    offset = Pos - PrevScrollPosition;
                    break;
                }
            }

            return (index, offset);
        }
        */

        private float GetItemStepSize(int index)
        {
            if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
            {
                return ItemSize[index];
            }
            else
            {
                if (Source.IsHeader(index))
                    return headerSize;
                else if (Source.IsFooter(index))
                    return footerSize;
                else if (Source.IsGroupHeader(index))
                    return groupHeaderSize;
                else if (Source.IsGroupFooter(index))
                    return groupFooterSize;
                else
                    return StepCandidate;
            }
        }

        private void UpdatePosition(int index)
        {
            bool IsGroup = (Source is IGroupableItemSource);

            if (index <= 0) return;
            if (index >= Source.Count)

                if (IsGroup)
                {
                    //IsGroupHeader = (Source as IGroupableItemSource).IsGroupHeader(index);
                    //IsGroupFooter = (Source as IGroupableItemSource).IsGroupFooter(index);
                    //Do Something
                }
            if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                ItemPosition[index] = ItemPosition[index - 1] + GetItemStepSize(index - 1);
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

        private float GetGroupPosition(GroupInfo groupInfo, int index)
        {
            if (collectionView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                return groupInfo.GroupPosition + groupInfo.ItemPosition[index - groupInfo.StartIndex];
            else
            {
                float pos = groupInfo.GroupPosition;
                if (groupInfo.StartIndex == index) return pos;

                pos = pos + groupHeaderSize + StepCandidate * (index - groupInfo.StartIndex - 1);

                return pos;
            }
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
    }
}
