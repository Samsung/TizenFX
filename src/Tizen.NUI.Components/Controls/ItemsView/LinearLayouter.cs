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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// [Draft] This class implements a linear box layout.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LinearLayouter : ItemsLayouter
    {
        private List<float> ItemPosition = new List<float>();
        private List<float> ItemSize = new List<float>();
        private int ItemSizeChanged = -1;
        private CollectionView colView;
        private bool hasHeader;
        private float headerSize;
        private bool hasFooter;
        private float footerSize;

        /// <summary>
        /// Clean up ItemsLayouter.
        /// </summary>
        /// <param name="view"> ItemsView of layouter.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Initialize(ItemsView view)
        {
            colView = view as CollectionView;
            if (colView == null)
            {
                throw new ArgumentException("LinearLayouter only can be applied CollectionView.", nameof(view));
            }
            // 1. Clean Up
            foreach (ViewItem item in VisibleItems)
            {
                colView.UnrealizeItem(item, false);
            }
            VisibleItems.Clear();

            FirstVisible = 0;
            LastVisible = 0;
            ItemPosition.Clear();
            ItemSize.Clear();

            isHorizontal = (colView.ScrollingDirection == ScrollableBase.Direction.Horizontal);

            ViewItem header = colView?.Header;
            ViewItem footer = colView?.Footer;
            float width, height;
            int count = colView.InternalItemSource.Count;

            if (header)
            {
                MeasureChild(colView, header);

                width = header.Layout != null ? header.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = header.Layout != null ? header.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                headerSize = isHorizontal ? width : height;
                hasHeader = true;
            }
            else hasHeader = false;

            if (footer)
            {
                MeasureChild(colView, footer);

                width = footer.Layout != null ? footer.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = footer.Layout != null ? footer.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                footerSize = isHorizontal ? width : height;
                footer.Index = count - 1;
                hasFooter = true;
            }
            else hasFooter = false;

            int FirstIndex = hasHeader ? 1 : 0;
            // Get Size Deligate. FIXME if group exist index must be changed.
            ViewItem sizeDeligate = colView.RealizeItem(FirstIndex);
            if (sizeDeligate == null)
            {
                // error !
                throw new Exception("Cannot create content from DatTemplate.");
            }

            sizeDeligate.BindingContext = colView.InternalItemSource.GetItem(FirstIndex);

            // Need to Set proper hieght or width on scroll direciton.

            if (sizeDeligate.Layout == null)
            {
                width =  sizeDeligate.WidthSpecification;
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
            StepCandidate = isHorizontal ? width : height;
            if (StepCandidate == 0) StepCandidate = 1;

            float Current = 0.0F;
            for (int i = 0; i < count; i++)
            {
                if (colView.SizingStrategy == ItemSizingStrategy.MeasureAll)
                {
                    if (i == 0 && hasHeader)
                        ItemSize.Add(headerSize);
                    else if (i == count -1 && hasFooter)
                        ItemSize.Add(footerSize);
                    else ItemSize.Add(StepCandidate);
                }
                ItemPosition.Add(Current);
                if (i == 0 && hasHeader)
                {
                    Current += headerSize;
                }
                else if (i == count -1 && hasFooter)
                    Current += footerSize;
                else Current += StepCandidate;
            }

            ScrollContentSize = Current;
            if (isHorizontal) colView.ContentContainer.SizeWidth = ScrollContentSize;
            else colView.ContentContainer.SizeHeight = ScrollContentSize;

            colView.UnrealizeItem(sizeDeligate);
            if (hasHeader) colView.UnrealizeItem(header);
            if (hasFooter) colView.UnrealizeItem(footer);

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
            int LastIndex = colView.InternalItemSource.Count -1;

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
                PrevScrollPosition + ( isHorizontal ? colView.Size.Width : colView.Size.Height)
            );

            // 1. Set First/Last Visible Item Index. 
            (int start, int end) found = FindVisibleItems(visibleArea);
            FirstVisible = found.start;
            LastVisible = found.end;
            //Console.WriteLine("[NUI] visibleArea before [{0},{1}] after [{2},{3}]", prevFirstVisible, prevLastVisible, FirstVisible, LastVisible);

            // 2. Unrealize invisible items.
            List<ViewItem> unrealizedItems = new List<ViewItem>();
            foreach (ViewItem item in VisibleItems)
            {
                if (item.Index < FirstVisible || item.Index > LastVisible)
                {
                   //Console.WriteLine("[NUI] Unrealize{0}!", item.Index);

                   unrealizedItems.Add(item);
                   colView.UnrealizeItem(item);
                }
            }
            VisibleItems.RemoveAll(unrealizedItems.Contains);

            //Console.WriteLine("[NUI] Realize Begin [{0} to {1}]", FirstVisible, LastVisible);
            // 3. Realize and placing visible items.
            for (int i = FirstVisible; i <= LastVisible; i++)
            {
                ViewItem item = null;
                // 4. Get item if visible or realize new.
                if (i >= prevFirstVisible && i <= prevLastVisible)
                {
                    item = GetVisibleItem(i);
                    if (item) continue;
                }
                if (item == null) item = colView.RealizeItem(i);

                VisibleItems.Add(item);

                // 5. Placing item.
                item.Position = ( isHorizontal ?
                        new Position(
                            ItemPosition[i],
                            item.PositionY
                        ):
                        new Position(
                            item.PositionX,
                            ItemPosition[i]
                        ));
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

           return (isHorizontal ? (pos, 0.0F) : (0.0F, pos));
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override (float X, float Y) GetItemSize(object item)
        {
           if (item == null) throw new ArgumentNullException(nameof(item));
           // Layouting Items in scrollPosition.
           float size = GetItemSize(colView.InternalItemSource.GetPosition(item));
           float view = (isHorizontal ? colView.Size.Height : colView.Size.Width);

           return (isHorizontal ? (size, view) : (view, size));
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void NotifyItemSizeChanged(ViewItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!IsInitialized ||
                (colView.SizingStrategy == ItemSizingStrategy.MeasureFirst &&
                item.Index != 0) ||
                (item.Index < 0))
                return;

            float PrevSize, CurrentSize;
            if (item.Index == (colView.InternalItemSource.Count-1))
            {
                PrevSize = ScrollContentSize - ItemPosition[item.Index];
            }
            else
            {
                PrevSize = ItemPosition[item.Index + 1] - ItemPosition[item.Index];
            }

            CurrentSize = (isHorizontal ? item.Size.Width : item.Size.Height);

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

            switch(direction)
            {
                case View.FocusDirection.Left :
                {
                    targetSibling = isHorizontal ? currentFocusedView.SiblingOrder - 1 : targetSibling;
                    break;
                }
                case View.FocusDirection.Right :
                {
                    targetSibling = isHorizontal ? currentFocusedView.SiblingOrder + 1 : targetSibling;
                    break;
                }
                case View.FocusDirection.Up :
                {
                    targetSibling = isHorizontal ? targetSibling : currentFocusedView.SiblingOrder - 1;
                    break;
                }
                case View.FocusDirection.Down :
                {
                    targetSibling = isHorizontal ? targetSibling : currentFocusedView.SiblingOrder + 1;
                    break;
                }
            }

            if(targetSibling > -1 && targetSibling < Container.Children.Count)
            {
                ViewItem candidate = Container.Children[targetSibling] as ViewItem;
                if(candidate.Index >= 0 && candidate.Index < colView.InternalItemSource.Count)
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
            (int start, int end) found;

            // Header is Showing
            if (hasHeader && visibleArea.X < headerSize)
            {
                found.start = 0;

            }
            else
            {
                float visibleAreaX = visibleArea.X - (hasHeader ? headerSize : 0);
                found.start = (Convert.ToInt32(Math.Abs(visibleAreaX / StepCandidate)) - 5);

                if (found.start < 0) found.start = 0;
            }

            if (hasFooter && visibleArea.Y > ScrollContentSize - footerSize)
            {
                found.end = MaxIndex + 1;
            }
            else
            {
                float visibleAreaY = visibleArea.Y - (hasHeader ? headerSize : 0);
                //Need to Consider GroupHeight!!!!
                found.end = (Convert.ToInt32(Math.Abs(visibleAreaY / StepCandidate)) + 5);

                if (hasHeader) found.end += 1;
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
            bool IsGroupHeader = false;
            bool IsGroupFooter = false;

            if (index <= 0) return;
            if (index >= colView.InternalItemSource.Count)

            if (IsGroup)
            {
                IsGroupHeader = (colView.InternalItemSource as IGroupableItemSource).IsGroupHeader(index);
                IsGroupFooter = (colView.InternalItemSource as IGroupableItemSource).IsGroupFooter(index);
                //Do Something
            }

            ItemPosition[index] = ItemPosition[index-1] + GetItemSize(index-1);
        }

        private ViewItem GetVisibleItem(int index)
        {
            foreach (ViewItem item in VisibleItems)
            {
                if (item.Index == index) return item;
            }
            return null;
        }
    }
}
