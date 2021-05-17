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
    /// Layouter for CollectionView to display items in grid layout.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class GridLayouter : ItemsLayouter
    {
        private CollectionView colView;
        private (float Width, float Height) sizeCandidate;
        private int spanSize = 1;
        private float align = 0.5f;
        private bool hasHeader;
        private Extents headerMargin;
        private float headerSize;
        private Extents footerMargin;
        private bool hasFooter;
        private float footerSize;
        private bool isGrouped;
        private readonly List<GroupInfo> groups = new List<GroupInfo>();
        private float groupHeaderSize;
        private Extents groupHeaderMargin;
        private float groupFooterSize;
        private Extents groupFooterMargin;
        private GroupInfo Visited;
        private Timer requestLayoutTimer = null;

        /// <summary>
        /// Clean up ItemsLayouter.
        /// </summary>
        /// <param name="view"> CollectionView of layouter. </param>
        /// <remarks>please note that, view must be type of CollectionView</remarks>
        /// <since_tizen> 9 </since_tizen>
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
            int pureCount = count - (header? 1 : 0) - (footer? 1 : 0);

            // 2. Get the header / footer and size deligated item and measure the size.
            if (header != null)
            {
                MeasureChild(colView, header);

                width = header.Layout != null? header.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = header.Layout != null? header.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                Extents itemMargin = header.Margin;
                headerSize = IsHorizontal?
                                width + itemMargin.Start + itemMargin.End:
                                height + itemMargin.Top + itemMargin.Bottom;
                headerMargin = new Extents(itemMargin);
                hasHeader = true;

                colView.UnrealizeItem(header);
            }

            if (footer != null)
            {
                MeasureChild(colView, footer);

                width = footer.Layout != null? footer.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = footer.Layout != null? footer.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                Extents itemMargin = footer.Margin;
                footerSize = IsHorizontal?
                                width + itemMargin.Start + itemMargin.End:
                                height + itemMargin.Top + itemMargin.Bottom;
                footerMargin = new Extents(itemMargin);
                footer.Index = count - 1;
                hasFooter = true;

                colView.UnrealizeItem(footer);
            }

            int firstIndex = header? 1 : 0;

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
                        Extents itemMargin = groupHeader.Margin;
                        groupHeaderSize = IsHorizontal?
                                            width + itemMargin.Start + itemMargin.End:
                                            height + itemMargin.Top + itemMargin.Bottom;
                        groupHeaderMargin = new Extents(itemMargin);
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
                        Extents itemMargin = groupFooter.Margin;
                        groupFooterSize = IsHorizontal?
                                            width + itemMargin.Start + itemMargin.End:
                                            height + itemMargin.Top + itemMargin.Bottom;
                        groupFooterMargin = new Extents(itemMargin);
                    
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

            sizeCandidate = (0, 0);
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
                Extents itemMargin = sizeDeligate.Margin;
                width = width + itemMargin.Start + itemMargin.End;
                height = height + itemMargin.Top + itemMargin.Bottom;
                StepCandidate = IsHorizontal? width : height;
                CandidateMargin = new Extents(itemMargin);
                spanSize = IsHorizontal?
                            Convert.ToInt32(Math.Truncate((double)((colView.Size.Height - Padding.Top - Padding.Bottom) / height))) :
                            Convert.ToInt32(Math.Truncate((double)((colView.Size.Width - Padding.Start - Padding.End) / width)));

                sizeCandidate = (width, height);

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

            ScrollContentSize = IsHorizontal?
                                ScrollContentSize + Padding.Start + Padding.End:
                                ScrollContentSize + Padding.Top + Padding.Bottom;

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
        /// <since_tizen> 9 </since_tizen>
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
                PrevScrollPosition + (IsHorizontal? colView.Size.Width : colView.Size.Height)
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
                    if (item != null && !force) continue;
                }
                if (item == null)
                {
                    item = colView.RealizeItem(i);
                    if (item != null) VisibleItems.Add(item);
                    else throw new Exception("Failed to create RecycerViewItem index of ["+ i + "]");
                }

                //item Position without Padding and Margin.
                (float x, float y) = GetItemPosition(i);
                // 5. Placing item with Padding and Margin.
                item.Position = new Position(x, y);
                
                //Linear Item need to be resized!
                if (item.IsHeader || item.IsFooter || item.isGroupHeader || item.isGroupFooter)
                {
                    if (IsHorizontal && item.HeightSpecification == LayoutParamPolicies.MatchParent)
                    {
                        item.Size = new Size(item.Size.Width, Container.Size.Height - Padding.Top - Padding.Bottom - item.Margin.Top - item.Margin.Bottom);
                    }
                    else if (!IsHorizontal && item.WidthSpecification == LayoutParamPolicies.MatchParent)
                    {
                        item.Size = new Size(Container.Size.Width - Padding.Start - Padding.End - item.Margin.Start - item.Margin.End, item.Size.Height);
                    }
                }
                //Console.WriteLine("[NUI] ["+item.Index+"] ["+item.Position.X+", "+item.Position.Y+" ==== \n");
            }
            //Console.WriteLine("Realize Done");
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
        public override void NotifyItemSizeChanged(RecyclerViewItem item)
        {
            // All Item size need to be same in grid!
            // if you want to change item size, change dataTemplate to re-initing.
            return;
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void NotifyItemInserted(IItemSource source, int startIndex)
        {
            // Insert Single item.
            if (source == null) throw new ArgumentNullException(nameof(source));

            // Will be null if not a group.
            float currentSize = 0;
            IGroupableItemSource gSource = source as IGroupableItemSource;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
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

                    if (gSource.IsGroupFooter(startIndex))
                    {
                        // It doesn't make sence to adding footer by notify...
                        // if GroupFooterTemplate is added,
                        // need to implement on here.
                    }
                    else
                    {
                        if (colView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                        {
                            // Wrong! Grid Layouter do not support MeasureAll!
                        }
                        else
                        {
                            int pureCount = groupInfo.Count - 1 - (colView.GroupFooterTemplate == null? 0: 1);
                            if (pureCount % spanSize == 0)
                            {
                                currentSize = StepCandidate;
                                groupInfo.GroupSize += currentSize;
                            }

                        }
                    }
                    groupInfo.Count++;

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
                if (colView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                {
                    // Wrong! Grid Layouter do not support MeasureAll!
                }
                int pureCount = colView.InternalItemSource.Count - (hasHeader? 1: 0) - (hasFooter? 1: 0);

                // Count comes after updated in ungrouped case!
                if (pureCount % spanSize == 1)
                {
                    currentSize = StepCandidate;
                }
            }

            // 3. Update Scroll Content Size
            ScrollContentSize += currentSize;

            if (IsHorizontal) colView.ContentContainer.SizeWidth = ScrollContentSize;
            else colView.ContentContainer.SizeHeight = ScrollContentSize;

            // 4. Update Visible Items.
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if (item.Index >= startIndex)
                {
                    item.Index++;
                }
            }

            float scrollPosition = PrevScrollPosition;

            /*
            // Position Adjust
            // Insertion above Top Visible!
            if (startIndex <= topInScreenIndex)
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                colView.ScrollTo(scrollPosition);
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

            float currentSize = 0;
            // Will be null if not a group.
            IGroupableItemSource gSource = source as IGroupableItemSource;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
            */

            // 2. Handle Group Case
            // Adding ranged items should all same new groups.
            if (isGrouped && gSource != null)
            {
                GroupInfo groupInfo = null;
                object groupParent = gSource.GetGroupParent(startIndex);
                int parentIndex = gSource.GetPosition(groupParent);
                if (gSource.HasHeader) parentIndex--;
                int groupStartIndex = 0;
                if (gSource.IsGroupHeader(startIndex))
                {
                    groupStartIndex = startIndex;
                }
                else
                {
                    //exception case!
                    throw new Exception("Inserted wrong groups!");
                }

                for (int current = startIndex; current - startIndex < count; current++)
                {
                    // Check item is group parent or not
                    // if group parent, add new gorupinfo
                    if (groupStartIndex == current)
                    {
                        //create new groupInfo!
                        groupInfo = new GroupInfo()
                        {
                            GroupParent = groupParent,
                            StartIndex = current,
                            Count = 1,
                            GroupSize = groupHeaderSize,
                        };
                        currentSize += groupHeaderSize;

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
                                currentSize += groupFooterSize;
                        }
                        else
                        {
                            if (colView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                            {
                                // Wrong! Grid Layouter do not support MeasureAll!
                            }
                            else
                            {
                                int index = current - groupInfo.StartIndex - 1; // groupHeader must always exist.
                                if ((index % spanSize) == 0)
                                {
                                    groupInfo.GroupSize += StepCandidate;
                                    currentSize += StepCandidate;
                                }
                            }
                        }
                    }
                }

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
                        groups[i].GroupPosition += currentSize;
                        groups[i].StartIndex += count;
                    }
                }

                ScrollContentSize += currentSize;
            }
            else
            {
                throw new Exception("Cannot insert ungrouped range items!");
            }

            // 3. Update Scroll Content Size
            if (IsHorizontal) colView.ContentContainer.SizeWidth = ScrollContentSize;
            else colView.ContentContainer.SizeHeight = ScrollContentSize;

            // 4. Update Visible Items.
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if (item.Index >= startIndex)
                {
                    item.Index += count;
                }
            }

            // Position Adjust
            float scrollPosition = PrevScrollPosition;
            /*
            // Insertion above Top Visible!
            if (startIndex + count <= topInScreenIndex)
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                colView.ScrollTo(scrollPosition);
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

            // Will be null if not a group.
            float currentSize = 0;
            IGroupableItemSource gSource = source as IGroupableItemSource;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
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
                }
                else
                {
                    groupInfo.Count--;

                    // Skip footer case as footer cannot exist alone without header.
                    if (colView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                    {
                        // Wrong! Grid Layouter do not support MeasureAll!
                    }
                    else
                    {
                        int pureCount = groupInfo.Count - 1 - (colView.GroupFooterTemplate == null? 0: 1);
                        if (pureCount % spanSize == 0)
                        {
                                currentSize = StepCandidate;
                                groupInfo.GroupSize -= currentSize;
                        }
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
                if (colView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                {
                    // Wrong! Grid Layouter do not support MeasureAll!
                }
                int pureCount = colView.InternalItemSource.Count - (hasHeader? 1: 0) - (hasFooter? 1: 0);

                // Count comes after updated in ungrouped case!
                if (pureCount % spanSize == 0)
                {
                    currentSize = StepCandidate;
                }
                
            }

            ScrollContentSize -= currentSize;

            // 3. Update Scroll Content Size
            if (IsHorizontal) colView.ContentContainer.SizeWidth = ScrollContentSize;
            else colView.ContentContainer.SizeHeight = ScrollContentSize;

            // 4. Update Visible Items.
            RecyclerViewItem targetItem = null;
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if (item.Index == startIndex)
                {
                    targetItem = item;
                    colView.UnrealizeItem(item);
                }
                else if (item.Index > startIndex)
                {
                    item.Index--;
                }
            }
            VisibleItems.Remove(targetItem);

            // Position Adjust
            float scrollPosition = PrevScrollPosition;
            /*
            // Insertion above Top Visible!
            if (startIndex <= topInScreenIndex)
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                colView.ScrollTo(scrollPosition);
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

            // Will be null if not a group.
            float currentSize = StepCandidate;
            IGroupableItemSource gSource = source as IGroupableItemSource;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
            */

            // 1. Handle Group Case
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
                if (colView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                {
                    // Wrong! Grid Layouter do not support MeasureAll!
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
                // It must group case! throw exception!
                throw new Exception("Range remove must group remove!");
            }

            ScrollContentSize -= currentSize;

            // 2. Update Scroll Content Size
            if (IsHorizontal) colView.ContentContainer.SizeWidth = ScrollContentSize;
            else colView.ContentContainer.SizeHeight = ScrollContentSize;

            // 3. Update Visible Items.
            List<RecyclerViewItem> unrealizedItems = new List<RecyclerViewItem>();
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if ((item.Index >= startIndex)
                    && (item.Index < startIndex + count))
                {
                    unrealizedItems.Add(item);
                    colView.UnrealizeItem(item);
                }
                else if (item.Index >= startIndex + count)
                {
                    item.Index -= count;
                }
            }
            VisibleItems.RemoveAll(unrealizedItems.Contains);
            unrealizedItems.Clear();

            // Position Adjust
            float scrollPosition = PrevScrollPosition;
            /*
            // Insertion above Top Visible!
            if (startIndex <= topInScreenIndex)
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                colView.ScrollTo(scrollPosition);
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

            // Will be null if not a group.
            float currentSize = StepCandidate;
            int diff = toPosition - fromPosition;

            // Get the first Visible Position to adjust.
            /*
            int topInScreenIndex = 0;
            float offset = 0F;
            (topInScreenIndex, offset) = FindTopItemInScreen();
            */
            
            // Move can only happen in it's own groups.
            // so there will be no changes in position, startIndex in ohter groups.
            // check visible item and update indexs.
            int startIndex = ( diff > 0 ? fromPosition: toPosition);
            int endIndex = (diff > 0 ? toPosition: fromPosition);

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

            if (IsHorizontal) colView.ContentContainer.SizeWidth = ScrollContentSize;
            else colView.ContentContainer.SizeHeight = ScrollContentSize;

            // Position Adjust
            float scrollPosition = PrevScrollPosition;
            /*
            // Insertion above Top Visible!
            if (((fromPosition > topInScreenIndex) && (toPosition < topInScreenIndex) ||
                ((fromPosition < topInScreenIndex) && (toPosition > topInScreenIndex)))
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                colView.ScrollTo(scrollPosition);
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
                throw new Exception("Range remove must group remove!");
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

            // Position Adjust
            float scrollPosition = PrevScrollPosition;
            /*
            // Insertion above Top Visible!
            if (((fromPosition > topInScreenIndex) && (toPosition < topInScreenIndex) ||
                ((fromPosition < topInScreenIndex) && (toPosition > topInScreenIndex)))
            {
                scrollPosition = GetItemPosition(topInScreenIndex);
                scrollPosition -= offset;

                colView.ScrollTo(scrollPosition);
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
            if (hasHeader && visibleArea.X < headerSize + (IsHorizontal? Padding.Start : Padding.Top))
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

            if (hasFooter && visibleArea.Y > ScrollContentSize - footerSize - (IsHorizontal? Padding.End : Padding.Bottom))
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

        internal override (float X, float Y) GetItemPosition(int index)
        {
            float xPos, yPos;
            int spaceStartX = Padding.Start;
            int spaceStartY = Padding.Top;
            int emptyArea = IsHorizontal?
                            (int)(colView.Size.Height - Padding.Top - Padding.Bottom - (sizeCandidate.Height * spanSize)) :
                            (int)(colView.Size.Width - Padding.Start - Padding.End - (sizeCandidate.Width * spanSize));

            if (hasHeader && index == 0)
            {
                return (spaceStartX + headerMargin.Start, spaceStartY + headerMargin.Top);
            }
            if (hasFooter && index == colView.InternalItemSource.Count - 1)
            {
                xPos = IsHorizontal?
                        ScrollContentSize - Padding.End - footerSize + footerMargin.Start:
                        spaceStartX;
                yPos = IsHorizontal?
                        spaceStartY:
                        ScrollContentSize - Padding.Bottom - footerSize + footerMargin.Top;
                return (xPos, yPos);
            }
            if (isGrouped)
            {
                GroupInfo myGroup = GetGroupInfo(index);
                if (colView.InternalItemSource.IsGroupHeader(index))
                {
                    spaceStartX+= groupHeaderMargin.Start;
                    spaceStartY+= groupHeaderMargin.Top;
                    xPos = IsHorizontal?
                            myGroup.GroupPosition + groupHeaderMargin.Start:
                            spaceStartX;
                    yPos = IsHorizontal?
                            spaceStartY:
                            myGroup.GroupPosition + groupHeaderMargin.Top;
                }
                else if (colView.InternalItemSource.IsGroupFooter(index))
                {
                    spaceStartX+= groupFooterMargin.Start;
                    spaceStartY+= groupFooterMargin.Top;
                    xPos = IsHorizontal?
                            myGroup.GroupPosition + myGroup.GroupSize - groupFooterSize + groupFooterMargin.Start:
                            spaceStartX;
                    yPos = IsHorizontal?
                            spaceStartY:
                            myGroup.GroupPosition + myGroup.GroupSize - groupFooterSize + groupFooterMargin.Top;
                }
                else
                {
                    int pureIndex = index - myGroup.StartIndex - 1;
                    int division = pureIndex / spanSize;
                    int remainder = pureIndex % spanSize;
                    if (division < 0) division = 0;
                    if (remainder < 0) remainder = 0;
                    spaceStartX+= CandidateMargin.Start;
                    spaceStartY+= CandidateMargin.Top;

                    xPos = IsHorizontal?
                            (division * sizeCandidate.Width) + myGroup.GroupPosition + groupHeaderSize + CandidateMargin.Start:
                            (emptyArea * align) + (remainder * sizeCandidate.Width) + spaceStartX;
                    yPos = IsHorizontal?
                            (emptyArea * align) + (remainder * sizeCandidate.Height) + spaceStartY:
                            (division * sizeCandidate.Height) + myGroup.GroupPosition + groupHeaderSize + CandidateMargin.Top;
                }
            }
            else
            {
                int pureIndex = index - (colView.Header ? 1 : 0);
                // int convert must be truncate value.
                int division = pureIndex / spanSize;
                int remainder = pureIndex % spanSize;
                if (division < 0) division = 0;
                if (remainder < 0) remainder = 0;
                spaceStartX+= CandidateMargin.Start;
                spaceStartY+= CandidateMargin.Top;

                xPos = IsHorizontal?
                        (division * sizeCandidate.Width) + (hasHeader? headerSize : 0) + spaceStartX:
                        (emptyArea * align) + (remainder * sizeCandidate.Width) + spaceStartX;
                yPos = IsHorizontal?
                        (emptyArea * align) + (remainder * sizeCandidate.Height) + spaceStartY:
                        (division * sizeCandidate.Height) + (hasHeader? headerSize : 0) + spaceStartY;
            }

            return (xPos, yPos);
        }

        internal override (float Width, float Height) GetItemSize(int index)
        {            
            return (sizeCandidate.Width - CandidateMargin.Start - CandidateMargin.End,
                    sizeCandidate.Height - CandidateMargin.Top - CandidateMargin.Bottom);
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
