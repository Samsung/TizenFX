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
    /// This class implements a grid box layout.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GridLayouter : ItemsLayouter
    {
        private CollectionView colView;
        private Size2D sizeCandidate;
        private int spanSize = 1;
        private float align = 0.5f;
        private float headerSize;
        private float footerSize;

        /// <summary>
        /// Clean up ItemsLayouter.
        /// </summary>
        /// <param name="view"> ItemsView of layouter. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Initialize(ItemsView view)
        {
            colView = view as CollectionView;
            if (colView == null)
            {
                throw new ArgumentException("GridLayouter only can be applied CollectionView.", nameof(view));
            }

            // 1. Clean Up
            foreach (ViewItem item in VisibleItems)
            {
                colView.UnrealizeItem(item, false);
            }
            VisibleItems.Clear();

            FirstVisible = 0;
            LastVisible = 0;

            bool isHorizontal = (colView.ScrollingDirection == ScrollableBase.Direction.Horizontal);

            ViewItem header = colView?.Header;
            ViewItem footer = colView?.Footer;
            float width, height;
            int count = colView.InternalItemSource.Count;
            int pureCount = count - (header ? 1 : 0) - (footer? 1 : 0);

            // 2. Get the header / footer and size deligated item and measure the size.
            if (header)
            {
                MeasureChild(colView, header);

                width = header.Layout != null ? header.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = header.Layout != null ? header.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                headerSize = isHorizontal ? width : height;
            }

            if (footer)
            {
                MeasureChild(colView, footer);

                width = footer.Layout != null ? footer.Layout.MeasuredWidth.Size.AsRoundedValue() : 0;
                height = footer.Layout != null ? footer.Layout.MeasuredHeight.Size.AsRoundedValue() : 0;

                footerSize = isHorizontal ? width : height;
                footer.Index = count - 1;
            }

            int firstIndex = header? 1 : 0;

            // Get Size Deligate. FIXME if group exist index must be changed.
            ViewItem sizeDeligate = colView.RealizeItem(firstIndex);
            if (sizeDeligate == null)
            {
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

            //Console.WriteLine("[NUI] item Size {0} :{1}", width, height);

            // pick the StepCandidate.
            StepCandidate = isHorizontal ? width : height;
            spanSize = isHorizontal ? Convert.ToInt32(Math.Truncate((double)(colView.Size.Height / height))):
                                      Convert.ToInt32(Math.Truncate((double)(colView.Size.Width / width)));
            if (StepCandidate < 1) StepCandidate = 1;
            if (spanSize < 1) spanSize = 1;

            sizeCandidate = new Size2D(Convert.ToInt32(width), Convert.ToInt32(height));

            // 3. Measure the scroller content size.
            ScrollContentSize = StepCandidate * Convert.ToInt32(Math.Ceiling((double)pureCount / (double)spanSize));
            if (header) ScrollContentSize += headerSize;
            if (footer) ScrollContentSize += footerSize;
            if (isHorizontal) colView.ContentContainer.SizeWidth = ScrollContentSize;
            else colView.ContentContainer.SizeHeight = ScrollContentSize;

            colView.UnrealizeItem(sizeDeligate);
            if (header != null) colView.UnrealizeItem(header);
            if (footer != null) colView.UnrealizeItem(footer);

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
            bool isHorizontal = (colView.ScrollingDirection == ScrollableBase.Direction.Horizontal);

            (float X, float Y) visibleArea = (PrevScrollPosition,
                PrevScrollPosition + ( isHorizontal ? colView.Size.Width : colView.Size.Height)
            );

            //Console.WriteLine("[NUI] itemsView [{0},{1}] [{2},{3}]", colView.Size.Width, colView.Size.Height, colView.ContentContainer.Size.Width, colView.ContentContainer.Size.Height);

            // 1. Set First/Last Visible Item Index. 
            (int start, int end) found = FindVisibleItems(visibleArea);
            FirstVisible = found.start;
            LastVisible = found.end;

            //Console.WriteLine("[NUI] {0} :visibleArea before [{1},{2}] after [{3},{4}]", scrollPosition, prevFirstVisible, prevLastVisible, FirstVisible, LastVisible);

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

            //Console.WriteLine("Realize Begin [{0} to {1}]", FirstVisible, LastVisible);
            // 3. Realize and placing visible items.
            for (int i = FirstVisible; i <= LastVisible; i++)
            {
                //Console.WriteLine("[NUI] Realize!");
                ViewItem item = null;
                // 4. Get item if visible or realize new.
                if (i >= prevFirstVisible && i <= prevLastVisible)
                {
                    item = GetVisibleItem(i);
                    if (item) continue;
                }
                if (item == null) item = colView.RealizeItem(i);
                VisibleItems.Add(item);

                (float X, float Y) pos = GetItemPosition(i);
                // 5. Placing item.
                item.Position = new Position(pos.X, pos.Y);
                // Console.WriteLine("[NUI] ["+item.Index+"] ["+item.Position.X+", "+item.Position.Y+" ==== \n");
            }
            //Console.WriteLine("Realize Done");
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override (float X, float Y) GetItemPosition(object item)
        {
           if (item == null) throw new ArgumentNullException(nameof(item));
           if (colView == null) return (0, 0);
          /*
           is group?
           is Header? - it cannot be a header
           is Footer? - it cannot be a footer
           */

           return GetItemPosition(colView.InternalItemSource.GetPosition(item));
        }

        /// <Inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override (float X, float Y) GetItemSize(object item)
        {
           if (item == null) throw new ArgumentNullException(nameof(item));
           if (sizeCandidate == null) return (0, 0);
           /*
           is group?
           is Header? - it cannot be a header
           is Footer? - it cannot be a footer
           */
           // gengrid item has to be all same size.

           return (sizeCandidate.Width, sizeCandidate.Height);
        }

        /// <inheritdoc/>
        public override void NotifyItemSizeChanged(ViewItem item)
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
            bool isHorizontal = colView.ScrollingDirection == ScrollableBase.Direction.Horizontal;

            switch (direction)
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
                if (candidate.Index >= 0 && candidate.Index < colView.InternalItemSource.Count)
                {
                    nextFocusedView = candidate;
                }
            }
            return nextFocusedView;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override (int start, int end) FindVisibleItems((float X, float Y)visibleArea)
        {
            bool hasHeader = (colView.Header != null);
            bool hasFooter = (colView.Footer != null);
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
                found.start = (Convert.ToInt32(Math.Abs(visibleAreaX / StepCandidate)) - 1) * spanSize;

                if (found.start < 0) found.start = 0;
                if (hasHeader) found.start += 1;
            }

            if (hasFooter && visibleArea.Y > ScrollContentSize - footerSize)
            {
                found.end = MaxIndex + 1;
            }
            else
            {
                float visibleAreaY = visibleArea.Y - (hasHeader ? headerSize : 0);
                //Need to Consider GroupHeight!!!!
                found.end = (Convert.ToInt32(Math.Abs(visibleAreaY / StepCandidate)) + 1) * spanSize;

                if (hasHeader) found.end += 1;
                if (found.end > (MaxIndex)) found.end = MaxIndex;
            }
            return found;
        }

        private (float X, float Y) GetItemPosition(int index)
        {
            if (sizeCandidate == null) return (0, 0);
            bool isHorizontal = (colView.ScrollingDirection == ScrollableBase.Direction.Horizontal);
            bool hasHeader = (colView.Header != null);
            bool hasFooter = (colView.Footer != null);
            float xPos, yPos;

            if (hasHeader && index == 0)
            {
                return (0, 0);
            }
            if (hasFooter && index == colView.InternalItemSource.Count)
            {
                xPos = isHorizontal ? ScrollContentSize - footerSize : 0;
                yPos = isHorizontal ? 0 : ScrollContentSize - footerSize;
                return (xPos, yPos);
            }

            int pureIndex = index - (colView.Header ? 1 : 0);
            // int convert must be truncate value.
            int division = pureIndex / spanSize;
            int remainder = pureIndex % spanSize;
            int emptyArea = isHorizontal ? (int)(colView.Size.Height - (sizeCandidate.Height * spanSize)) :
                                            (int)(colView.Size.Width - (sizeCandidate.Width * spanSize));
            if (division < 0) division = 0;
            if (remainder < 0) remainder = 0;

            xPos = isHorizontal ? division * sizeCandidate.Width + (hasHeader ? headerSize : 0) : emptyArea * align + remainder * sizeCandidate.Width;
            yPos = isHorizontal ? emptyArea * align + remainder * sizeCandidate.Height : division * sizeCandidate.Height + (hasHeader ? headerSize : 0);

            return (xPos, yPos);
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
