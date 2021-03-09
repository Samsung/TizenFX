﻿/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// This class provides a View that can layouting items in list and grid with high performance.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CollectionView : RecyclerView
    {
        /// <summary>
        /// Binding Property of selected item in single selection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(CollectionView), null,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var colView = (CollectionView)bindable;
                    oldValue = colView.selectedItem;
                    colView.selectedItem = newValue;
                    var args = new SelectionChangedEventArgs(oldValue, newValue);

                    foreach (RecyclerViewItem item in colView.ContentContainer.Children.Where((item) => item is RecyclerViewItem))
                    {
                        if (item.BindingContext == null) continue;
                        if (item.BindingContext == oldValue) item.IsSelected = false;
                        else if (item.BindingContext == newValue) item.IsSelected = true;
                    }

                    SelectionPropertyChanged(colView, args);
                },
                defaultValueCreator: (bindable) =>
                {
                    var colView = (CollectionView)bindable;
                    return colView.selectedItem;
                });

        /// <summary>
        /// Binding Property of selected items list in multiple selection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedItemsProperty =
            BindableProperty.Create(nameof(SelectedItems), typeof(IList<object>), typeof(CollectionView), null,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var colView = (CollectionView)bindable;
                    var oldSelection = colView.selectedItems ?? selectEmpty;
                    //FIXME : CoerceSelectedItems calls only isCreatedByXaml
                    var newSelection = (SelectionList)CoerceSelectedItems(colView, newValue);
                    colView.selectedItems = newSelection;
                    colView.SelectedItemsPropertyChanged(oldSelection, newSelection);
                },
                defaultValueCreator: (bindable) =>
                {
                    var colView = (CollectionView)bindable;
                    colView.selectedItems = colView.selectedItems ?? new SelectionList(colView);
                    return colView.selectedItems;
                });

        /// <summary>
        /// Binding Property of selected items list in multiple selection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionModeProperty =
            BindableProperty.Create(nameof(SelectionMode), typeof(ItemSelectionMode), typeof(CollectionView), ItemSelectionMode.None,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var colView = (CollectionView)bindable;
                    oldValue = colView.selectionMode;
                    colView.selectionMode = (ItemSelectionMode)newValue;
                    SelectionModePropertyChanged(colView, oldValue, newValue);
                },
                defaultValueCreator: (bindable) =>
                {
                    var colView = (CollectionView)bindable;
                    return colView.selectionMode;
                });


        private static readonly IList<object> selectEmpty = new List<object>(0);
        private DataTemplate itemTemplate = null;
        private IEnumerable itemsSource = null;
        private ItemsLayouter itemsLayouter = null;
        private DataTemplate groupHeaderTemplate;
        private DataTemplate groupFooterTemplate;
        private bool isGrouped;
        private bool wasRelayouted = false;
        private bool needInitalizeLayouter = false;
        private object selectedItem;
        private SelectionList selectedItems;
        private bool suppressSelectionChangeNotification;
        private ItemSelectionMode selectionMode = ItemSelectionMode.None;
        private RecyclerViewItem header;
        private RecyclerViewItem footer;
        private View focusedView;
        private int prevFocusedDataIndex = 0;
        private List<RecyclerViewItem> recycleGroupHeaderCache { get; } = new List<RecyclerViewItem>();
        private List<RecyclerViewItem> recycleGroupFooterCache { get; } = new List<RecyclerViewItem>();

        /// <summary>
        /// Base constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CollectionView() : base()
        {
            FocusGroup = true;
            SetKeyboardNavigationSupport(true);
        }

        /// <summary>
        /// Base constructor with ItemsSource
        /// </summary>
        /// <param name="itemsSource">item's data source</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CollectionView(IEnumerable itemsSource) : this()
        {
            ItemsSource = itemsSource;
        }

        /// <summary>
        /// Base constructor with ItemsSource, ItemsLayouter and ItemTemplate
        /// </summary>
        /// <param name="itemsSource">item's data source</param>
        /// <param name="layouter">item's layout manager</param>
        /// <param name="template">item's view template with data bindings</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CollectionView(IEnumerable itemsSource, ItemsLayouter layouter, DataTemplate template) : this()
        {
            ItemsSource = itemsSource;
            ItemTemplate = template;
            ItemsLayouter = layouter;
        }

        /// <summary>
        /// Event of Selection changed.
        /// old selection list and new selection will be provided.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

        /// <summary>
        /// Align item in the viewport when ScrollTo() calls.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ItemScrollTo
        {
            /// <summary>
            /// Scroll to show item in nearest viewport on scroll direction.
            /// item is above the scroll viewport, item will be came into front,
            /// item is under the scroll viewport, item will be came into end,
            /// item is in the scroll viewport, no scroll.
            /// </summary>
            Nearest,
            /// <summary>
            /// Scroll to show item in start of the viewport.
            /// </summary>
            Start,
            /// <summary>
            /// Scroll to show item in center of the viewport.
            /// </summary>
            Center,
            /// <summary>
            /// Scroll to show item in end of the viewport.
            /// </summary>
            End,
        }

        /// <summary>
        /// Item's source data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override IEnumerable ItemsSource
        {
            get
            {
                return itemsSource;
            }
            set
            {

                itemsSource = value;
                if (value == null)
                {
                    if (InternalItemSource != null) InternalItemSource.Dispose();
                    //layouter.Clear()
                    return;
                }
                if (InternalItemSource != null) InternalItemSource.Dispose();
                InternalItemSource = ItemsSourceFactory.Create(this);

                if (itemsLayouter == null) return;

                needInitalizeLayouter = true;
                Init();
            }
        }

        /// <summary>
        /// DataTemplate for items.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override DataTemplate ItemTemplate
        {
            get
            {
                return itemTemplate;
            }
            set
            {
                itemTemplate = value;
                if (value == null)
                {
                    //layouter.clear()
                    return;
                }

                needInitalizeLayouter = true;
                Init();
            }
        }

        /// <summary>
        /// Items Layouter.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ItemsLayouter ItemsLayouter
        {
            get
            {
                return itemsLayouter;
            }
            set
            {
                itemsLayouter = value;
                base.InternalItemsLayouter = ItemsLayouter;
                if (value == null)
                {
                    needInitalizeLayouter = false;
                    return;
                }

                needInitalizeLayouter = true;
                Init();
            }
        }

        /// <summary>
        /// Scrolling direction to display items layout.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Direction ScrollingDirection
        {
            get
            {
                return base.ScrollingDirection;
            }
            set
            {
                base.ScrollingDirection = value;

                if (ScrollingDirection == Direction.Horizontal)
                {
                    ContentContainer.SizeWidth = ItemsLayouter.CalculateLayoutOrientationSize();
                }
                else
                {
                    ContentContainer.SizeHeight = ItemsLayouter.CalculateLayoutOrientationSize();
                }
            }
        }

        /// <summary>
        /// Selected item in single selection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Selected items list in multiple selection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<object> SelectedItems
        {
            get => (IList<object>)GetValue(SelectedItemsProperty);
            // set => SetValue(SelectedItemsProperty, new SelectionList(this, value));
        }

        /// <summary>
        /// Selection mode to handle items selection. See ItemSelectionMode for details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemSelectionMode SelectionMode
        {
            get => (ItemSelectionMode)GetValue(SelectionModeProperty);
            set => SetValue(SelectionModeProperty, value);
        }

        /// <summary>
        /// Command of selection changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ICommand SelectionChangedCommand { set; get; }

        /// <summary>
        /// Command parameter of selection changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object SelectionChangedCommandParameter { set; get; }

        /// <summary>
        /// Size strategy of measuring scroll content. see details in ItemSizingStrategy.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemSizingStrategy SizingStrategy { get; set; }

        /// <summary>
        /// Header item which placed in top-most position.
        /// note : internal index and count will be increased.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecyclerViewItem Header
        {
            get => header;
            set
            {
                if (header != null)
                {
                    //ContentContainer.Remove(header);
                    Utility.Dispose(header);
                }
                if (value != null)
                {
                    value.Index = 0;
                    value.ParentItemsView = this;
                    value.IsHeader = true;
                    ContentContainer.Add(value);
                }
                header = value;
                needInitalizeLayouter = true;
                Init();
            }
        }

        /// <summary>
        /// Footer item which placed in bottom-most position.
        /// note : internal count will be increased.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecyclerViewItem Footer
        {
            get => footer;
            set
            {
                if (footer != null)
                {
                    //ContentContainer.Remove(footer);
                    Utility.Dispose(footer);
                }
                if (value != null)
                {
                    value.Index = InternalItemSource?.Count ?? 0;
                    value.ParentItemsView = this;
                    value.IsFooter = true;
                    ContentContainer.Add(value);
                }
                footer = value;
                needInitalizeLayouter = true;
                Init();
            }
        }

        /// <summary>
        /// Boolean flag of group feature existence.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsGrouped
        {
            get => isGrouped;
            set
            {
                isGrouped = value;
                needInitalizeLayouter = true;
                //Need to re-intialize Internal Item Source.
                if (InternalItemSource != null)
                {
                    InternalItemSource.Dispose();
                    InternalItemSource = null;
                }
                if (ItemsSource != null)
                    InternalItemSource = ItemsSourceFactory.Create(this);
                Init();
            }
        }

        /// <summary>
        ///  DataTemplate of group header. Group feature is not supported yet.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataTemplate GroupHeaderTemplate
        {
            get
            {
                return groupHeaderTemplate;
            }
            set
            {
                groupHeaderTemplate = value;
                needInitalizeLayouter = true;
                Init();
            }
        }

        /// <summary>
        /// DataTemplate of group footer. Group feature is not supported yet.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataTemplate GroupFooterTemplate
        {
            get
            {
                return groupFooterTemplate;
            }
            set
            {
                groupFooterTemplate = value;
                needInitalizeLayouter = true;
                Init();
            }
        }


        /// <summary>
        /// Internal encapsulated items data source.
        /// </summary>
        internal new IGroupableItemSource InternalItemSource
        {
            get
            {
                return (base.InternalItemSource as IGroupableItemSource);
            }
            set
            {
                base.InternalItemSource = value;
            }
        }
        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            base.OnRelayout(size, container);

            wasRelayouted = true;
            if (needInitalizeLayouter) Init();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override View GetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            View nextFocusedView = null;

            if (focusedView == null)
            {
                // If focusedView is null, find child which has previous data index
                if (ContentContainer.Children.Count > 0 && InternalItemSource.Count > 0)
                {
                    for (int i = 0; i < ContentContainer.Children.Count; i++)
                    {
                        RecyclerViewItem item = Children[i] as RecyclerViewItem;
                        if (item?.Index == prevFocusedDataIndex)
                        {
                            nextFocusedView = item;
                            break;
                        }
                    }
                }
            }
            else
            {
                // If this is not first focus, request next focus to Layouter
                nextFocusedView = ItemsLayouter.RequestNextFocusableView(currentFocusedView, direction, loopEnabled);
            }

            if (nextFocusedView != null)
            {
                // Check next focused view is inside of visible area.
                // If it is not, move scroll position to make it visible.
                Position scrollPosition = ContentContainer.CurrentPosition;
                float targetPosition = -(ScrollingDirection == Direction.Horizontal ? scrollPosition.X : scrollPosition.Y);

                float left = nextFocusedView.Position.X;
                float right = nextFocusedView.Position.X + nextFocusedView.Size.Width;
                float top = nextFocusedView.Position.Y;
                float bottom = nextFocusedView.Position.Y + nextFocusedView.Size.Height;

                float visibleRectangleLeft = -scrollPosition.X;
                float visibleRectangleRight = -scrollPosition.X + Size.Width;
                float visibleRectangleTop = -scrollPosition.Y;
                float visibleRectangleBottom = -scrollPosition.Y + Size.Height;

                if (ScrollingDirection == Direction.Horizontal)
                {
                    if ((direction == View.FocusDirection.Left || direction == View.FocusDirection.Up) && left < visibleRectangleLeft)
                    {
                        targetPosition = left;
                    }
                    else if ((direction == View.FocusDirection.Right || direction == View.FocusDirection.Down) && right > visibleRectangleRight)
                    {
                        targetPosition = right - Size.Width;
                    }
                }
                else
                {
                    if ((direction == View.FocusDirection.Up || direction == View.FocusDirection.Left) && top < visibleRectangleTop)
                    {
                        targetPosition = top;
                    }
                    else if ((direction == View.FocusDirection.Down || direction == View.FocusDirection.Right) && bottom > visibleRectangleBottom)
                    {
                        targetPosition = bottom - Size.Height;
                    }
                }

                focusedView = nextFocusedView;
                prevFocusedDataIndex = (nextFocusedView as RecyclerViewItem)?.Index ?? -1;

                ScrollTo(targetPosition, true);
            }
            else
            {
                // If nextView is null, it means that we should move focus to outside of Control.
                // Return FocusableView depending on direction.
                switch (direction)
                {
                    case View.FocusDirection.Left:
                        {
                            nextFocusedView = LeftFocusableView;
                            break;
                        }
                    case View.FocusDirection.Right:
                        {
                            nextFocusedView = RightFocusableView;
                            break;
                        }
                    case View.FocusDirection.Up:
                        {
                            nextFocusedView = UpFocusableView;
                            break;
                        }
                    case View.FocusDirection.Down:
                        {
                            nextFocusedView = DownFocusableView;
                            break;
                        }
                }

                if (nextFocusedView != null)
                {
                    focusedView = null;
                }
                else
                {
                    //If FocusableView doesn't exist, not move focus.
                    nextFocusedView = focusedView;
                }
            }

            return nextFocusedView;
        }

        /// <summary>
        /// Update selected items list in multiple selection.
        /// </summary>
        /// <param name="newSelection">updated selection list by user</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateSelectedItems(IList<object> newSelection)
        {
            var oldSelection = new List<object>(SelectedItems);

            suppressSelectionChangeNotification = true;

            SelectedItems.Clear();

            if (newSelection?.Count > 0)
            {
                for (int n = 0; n < newSelection.Count; n++)
                {
                    SelectedItems.Add(newSelection[n]);
                }
            }

            suppressSelectionChangeNotification = false;

            SelectedItemsPropertyChanged(oldSelection, newSelection);
        }

        /// <summary>
        /// Scroll to specific position with or without animation.
        /// </summary>
        /// <param name="position">Destination.</param>
        /// <param name="animate">Scroll with or without animation</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void ScrollTo(float position, bool animate) => base.ScrollTo(position, animate);

        /// <summary>
        /// Scroll to specific item's aligned position with or without animation.
        /// </summary>
        /// <param name="item">Target item of dataset.</param>
        /// <param name="animate">Boolean flag of animation.</param>
        /// <param name="align">Align state of item. see details in ItemScrollTo.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ScrollTo(object item, bool animate = false, ItemScrollTo align = ItemScrollTo.Nearest)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (ItemsLayouter == null) throw new Exception("Item Layouter must exist.");

            if (InternalItemSource.GetPosition(item) == -1)
            {
                throw new Exception("ScrollTo parameter item is not a member of ItemsSource");
            }

            float scrollPos, curPos, curSize, curItemSize;
            (float x, float y) = ItemsLayouter.GetItemPosition(item);
            (float width, float height) = ItemsLayouter.GetItemSize(item);
            if (ScrollingDirection == Direction.Horizontal)
            {
                scrollPos = x;
                curPos = ScrollPosition.X;
                curSize = Size.Width;
                curItemSize = width;
            }
            else
            {
                scrollPos = y;
                curPos = ScrollPosition.Y;
                curSize = Size.Height;
                curItemSize = height;
            }

            //Console.WriteLine("[NUI] ScrollTo [{0}:{1}], curPos{2}, itemPos{3}, curSize{4}, itemSize{5}", InternalItemSource.GetPosition(item), align, curPos, scrollPos, curSize, curItemSize);
            switch (align)
            {
                case ItemScrollTo.Start:
                    //nothing necessary.
                    break;
                case ItemScrollTo.Center:
                    scrollPos = scrollPos - (curSize / 2) + (curItemSize / 2);
                    break;
                case ItemScrollTo.End:
                    scrollPos = scrollPos - curSize + curItemSize;
                    break;
                case ItemScrollTo.Nearest:
                    if (scrollPos < curPos - curItemSize)
                    {
                        // item is placed before the current screen. scrollTo.Top
                    }
                    else if (scrollPos >= curPos + curSize + curItemSize)
                    {
                        // item is placed after the current screen. scrollTo.End
                        scrollPos = scrollPos - curSize + curItemSize;
                    }
                    else
                    {
                        // item is in the scroller. ScrollTo() is ignored.
                        return;
                    }
                    break;
            }

            //Console.WriteLine("[NUI] ScrollTo [{0}]-------------------", scrollPos);
            base.ScrollTo(scrollPos, animate);
        }

        // Realize and Decorate the item.
        internal override RecyclerViewItem RealizeItem(int index)
        {
            if (index == 0 && Header != null)
            {
                Header.Show();
                return Header;
            }

            if (index == InternalItemSource.Count - 1 && Footer != null)
            {
                Footer.Show();
                return Footer;
            }

            if (isGrouped)
            {
                var context = InternalItemSource.GetItem(index);
                if (InternalItemSource.IsGroupHeader(index))
                {
                    DataTemplate templ = (groupHeaderTemplate as DataTemplateSelector)?.SelectDataTemplate(context, this) ?? groupHeaderTemplate;

                    RecyclerViewItem groupHeader = PopRecycleGroupCache(templ, true);
                    if (groupHeader == null)
                    {
                        groupHeader = (RecyclerViewItem)DataTemplateExtensions.CreateContent(groupHeaderTemplate, context, this);

                        groupHeader.ParentItemsView = this;
                        groupHeader.Template = templ;
                        groupHeader.isGroupHeader = true;
                        groupHeader.isGroupFooter = false;
                        ContentContainer.Add(groupHeader);
                    }
                    groupHeader.Index = index;
                    groupHeader.ParentGroup = context;
                    groupHeader.BindingContext = context;
                    //group selection?
                    return groupHeader;
                }
                else if (InternalItemSource.IsGroupFooter(index))
                {
                    DataTemplate templ = (groupFooterTemplate as DataTemplateSelector)?.SelectDataTemplate(context, this) ?? groupFooterTemplate;

                    RecyclerViewItem groupFooter = PopRecycleGroupCache(templ, false);
                    if (groupFooter == null)
                    {
                        groupFooter = (RecyclerViewItem)DataTemplateExtensions.CreateContent(groupFooterTemplate, context, this);

                        groupFooter.ParentItemsView = this;
                        groupFooter.Template = templ;
                        groupFooter.isGroupHeader = false;
                        groupFooter.isGroupFooter = true;
                        ContentContainer.Add(groupFooter);
                    }
                    groupFooter.Index = index;
                    groupFooter.ParentGroup = context;
                    groupFooter.BindingContext = context;

                    //group selection?
                    return groupFooter;
                }
            }

            RecyclerViewItem item = base.RealizeItem(index);
            if (isGrouped) item.ParentGroup = InternalItemSource.GetGroupParent(index);

            switch (SelectionMode)
            {
                case ItemSelectionMode.SingleSelection:
                    if (item.BindingContext == SelectedItem) item.IsSelected = true;
                    break;

                case ItemSelectionMode.MultipleSelections:
                    if (SelectedItems?.Contains(item.BindingContext) ?? false) item.IsSelected = true;
                    break;
                case ItemSelectionMode.None:
                    item.IsSelectable = false;
                    break;
            }

            return item;
        }

        // Unrealize and caching the item.
        internal override void UnrealizeItem(RecyclerViewItem item, bool recycle = true)
        {
            if (item == Header)
            {
                item.Hide();
                return;
            }
            if (item == Footer)
            {
                item.Hide();
                return;
            }
            if (item.isGroupHeader || item.isGroupFooter)
            {
                if (!recycle || !PushRecycleGroupCache(item))
                    Utility.Dispose(item);
                return;
            }

            item.IsSelected = false;
            base.UnrealizeItem(item, recycle);
        }

        internal void SelectedItemsPropertyChanged(IList<object> oldSelection, IList<object> newSelection)
        {
            if (suppressSelectionChangeNotification)
            {
                return;
            }

            foreach (RecyclerViewItem item in ContentContainer.Children.Where((item) => item is RecyclerViewItem))
            {
                if (item.BindingContext == null) continue;
                if (newSelection.Contains(item.BindingContext))
                {
                    if (!item.IsSelected) item.IsSelected = true;
                }
                else
                {
                    if (item.IsSelected) item.IsSelected = false;
                }
            }
            SelectionPropertyChanged(this, new SelectionChangedEventArgs(oldSelection, newSelection));

            OnPropertyChanged(SelectedItemsProperty.PropertyName);
        }

        /// <summary>
        /// Internal selection callback.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnSelectionChanged(SelectionChangedEventArgs args)
        {
            //Selection Callback
        }

        /// <summary>
        /// Adjust scrolling position by own scrolling rules.
        /// Override this function when developer wants to change destination of flicking.(e.g. always snap to center of item)
        /// </summary>
        /// <param name="position">Scroll position which is calculated by ScrollableBase</param>
        /// <returns>Adjusted scroll destination</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override float AdjustTargetPositionOfScrollAnimation(float position)
        {
            // Destination is depending on implementation of layout manager.
            // Get destination from layout manager.
            return ItemsLayouter.CalculateCandidateScrollPosition(position);
        }

        /// <summary>
        /// OnScroll event callback.
        /// </summary>
        /// <param name="source">Scroll source object</param>
        /// <param name="args">Scroll event argument</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnScrolling(object source, ScrollEventArgs args)
        {
            if (disposed) return;

            if (needInitalizeLayouter)
            {
                ItemsLayouter.Initialize(this);
                needInitalizeLayouter = false;
            }
            base.OnScrolling(source, args);
        }

        /// <summary>
        /// Dispose ItemsView and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                disposed = true;
                if (InternalItemSource != null)
                {
                    InternalItemSource.Dispose();
                    InternalItemSource = null;
                }
                if (Header != null)
                {
                    Utility.Dispose(Header);
                    Header = null;
                }
                if (Footer != null)
                {
                    Utility.Dispose(Footer);
                    Footer = null;
                }
                groupHeaderTemplate = null;
                groupFooterTemplate = null;
                //
            }

            base.Dispose(type);
        }

        private static void SelectionPropertyChanged(CollectionView colView, SelectionChangedEventArgs args)
        {
            var command = colView.SelectionChangedCommand;

            if (command != null)
            {
                var commandParameter = colView.SelectionChangedCommandParameter;

                if (command.CanExecute(commandParameter))
                {
                    command.Execute(commandParameter);
                }
            }
            colView.SelectionChanged?.Invoke(colView, args);
            colView.OnSelectionChanged(args);
        }

        private static object CoerceSelectedItems(BindableObject bindable, object value)
        {
            if (value == null)
            {
                return new SelectionList((CollectionView)bindable);
            }

            if (value is SelectionList)
            {
                return value;
            }

            return new SelectionList((CollectionView)bindable, value as IList<object>);
        }

        private static void SelectionModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var colView = (CollectionView)bindable;

            var oldMode = (ItemSelectionMode)oldValue;
            var newMode = (ItemSelectionMode)newValue;

            IList<object> previousSelection = new List<object>();
            IList<object> newSelection = new List<object>();

            switch (oldMode)
            {
                case ItemSelectionMode.None:
                    break;
                case ItemSelectionMode.SingleSelection:
                    if (colView.SelectedItem != null)
                    {
                        previousSelection.Add(colView.SelectedItem);
                    }
                    break;
                case ItemSelectionMode.MultipleSelections:
                    previousSelection = colView.SelectedItems;
                    break;
            }

            switch (newMode)
            {
                case ItemSelectionMode.None:
                    break;
                case ItemSelectionMode.SingleSelection:
                    if (colView.SelectedItem != null)
                    {
                        newSelection.Add(colView.SelectedItem);
                    }
                    break;
                case ItemSelectionMode.MultipleSelections:
                    newSelection = colView.SelectedItems;
                    break;
            }

            if (previousSelection.Count == newSelection.Count)
            {
                if (previousSelection.Count == 0 || (previousSelection[0] == newSelection[0]))
                {
                    // Both selections are empty or have the same single item; no reason to signal a change
                    return;
                }
            }

            var args = new SelectionChangedEventArgs(previousSelection, newSelection);
            SelectionPropertyChanged(colView, args);
        }

        private void Init()
        {
            if (ItemsSource == null) return;
            if (ItemsLayouter == null) return;
            if (ItemTemplate == null) return;

            if (disposed) return;
            if (needInitalizeLayouter)
            {
                if (InternalItemSource == null) return;

                InternalItemSource.HasHeader = (header != null);
                InternalItemSource.HasFooter = (footer != null);
            }

            if (!wasRelayouted) return;

            if (needInitalizeLayouter)
            {
                ItemsLayouter.Initialize(this);
                needInitalizeLayouter = false;
            }
            ItemsLayouter.RequestLayout(0.0f, true);

            if (ScrollingDirection == Direction.Horizontal)
            {
                ContentContainer.SizeWidth = ItemsLayouter.CalculateLayoutOrientationSize();
            }
            else
            {
                ContentContainer.SizeHeight = ItemsLayouter.CalculateLayoutOrientationSize();
            }
        }

        private bool PushRecycleGroupCache(RecyclerViewItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (RecycleCache.Count >= 20) return false;
            if (item.Template == null) return false;
            if (item.isGroupHeader)
            {
                recycleGroupHeaderCache.Add(item);
            }
            else if (item.isGroupFooter)
            {
                recycleGroupFooterCache.Add(item);
            }
            else return false;
            item.Hide();
            item.Index = -1;
            return true;
        }

        private RecyclerViewItem PopRecycleGroupCache(DataTemplate Template, bool isHeader)
        {
            RecyclerViewItem viewItem = null;

            var Cache = (isHeader ? recycleGroupHeaderCache : recycleGroupFooterCache);
            for (int i = 0; i < Cache.Count; i++)
            {
                viewItem = Cache[i];
                if (Template == viewItem.Template) break;
            }

            if (viewItem != null)
            {
                Cache.Remove(viewItem);
                viewItem.Show();
            }
            return viewItem;
        }

    }
}
