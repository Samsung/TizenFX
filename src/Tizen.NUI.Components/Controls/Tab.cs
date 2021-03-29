/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Tab is one kind of common component, it can be used as menu label.
    /// User can handle Tab by adding/inserting/deleting TabItem.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [Obsolete("Deprecated in API8; Will be removed in API10")]
    public class Tab : Control
    {
        private const int aniTime = 100; // will be defined in const file later
        private List<TabItem> itemList = new List<TabItem>();
        private int curIndex = 0;
        private View underline = null;
        private Animation underlineAni = null;
        private bool isNeedAnimation = false;
        private Extents space;
        private TabStyle tabStyle => ViewStyle as TabStyle;

        static Tab() { }

        /// <summary>
        /// Creates a new instance of a Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Tab() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Tab with style.
        /// </summary>
        /// <param name="style">Create Tab by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tab(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Tab with style.
        /// </summary>
        /// <param name="tabStyle">Create Tab by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tab(TabStyle tabStyle) : base(tabStyle)
        {
            Initialize();
        }

        /// <summary>
        /// An event for the item changed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public event EventHandler<ItemChangedEventArgs> ItemChangedEvent;

        /// <summary>
        /// Return currently applied style.
        /// </summary>
        /// <remarks>
        /// Modifying contents in style may cause unexpected behaviour.
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public TabStyle Style => (TabStyle)(ViewStyle as TabStyle)?.Clone();

        /// <summary>
        /// Get underline of Tab.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Underline
        {
            get
            {
                if (null == underline)
                {
                    underline = new View()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    };
                    Add(underline);
                }
                return underline;
            }
            internal set
            {
                underline = value;
            }
        }

        /// <summary>
        /// Selected item's index in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public int SelectedItemIndex
        {
            get
            {
                return curIndex;
            }
            set
            {
                if (value < itemList.Count)
                {
                    UpdateSelectedItem(itemList[value]);
                }
            }
        }

        /// <summary>
        /// Flag to decide if TabItem is adjusted by text's natural width.
        /// If true, TabItem's width will be equal as text's natural width, if false, it will be decided by Tab's width and tab item count.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public bool UseTextNaturalSize
        {
            get
            {
                return tabStyle?.UseTextNaturalSize ?? false;
            }
            set
            {
                if (null != tabStyle)
                {
                    tabStyle.UseTextNaturalSize = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Gap between items.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public int ItemSpace
        {
            get
            {
                return tabStyle?.ItemSpace ?? 0;
            }
            set
            {
                if (null != tabStyle)
                {
                    tabStyle.ItemSpace = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Space in Tab. Sequence as Left, Right, Top, Bottom
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Extents Space
        {
            get
            {
                return ItemPadding;
            }
            set
            {
                ItemPadding = value;
            }
        }

        /// <summary>
        /// Item paddings in Tab. Sequence as Left, Right, Top, Bottom
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ItemPadding
        {
            get
            {
                return space;
            }
            set
            {
                if (null != value && null != tabStyle?.ItemPadding)
                {
                    tabStyle.ItemPadding.CopyFrom(value);

                    if (null == space)
                    {
                        space = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                        {
                            tabStyle.ItemPadding.Start = start;
                            tabStyle.ItemPadding.End = end;
                            tabStyle.ItemPadding.Top = top;
                            tabStyle.ItemPadding.Bottom = bottom;
                            RelayoutRequest();
                        }, value.Start, value.End, value.Top, value.Bottom);
                    }
                    else
                    {
                        space.CopyFrom(value);
                    }

                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// UnderLine view's size in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Size UnderLineSize
        {
            get
            {
                return Underline.Size;
            }
            set
            {
                if (null != tabStyle?.UnderLine)
                {
                    tabStyle.UnderLine.Size = value;
                }
                Underline.Size = value;
            }
        }

        /// <summary>
        /// UnderLine view's background in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Color UnderLineBackgroundColor
        {
            get
            {
                return Underline.BackgroundColor;
            }
            set
            {
                if (null != tabStyle?.BackgroundColor)
                {
                    tabStyle.UnderLine.BackgroundColor = value;
                }
                Underline.BackgroundColor = value;
            }
        }

        /// <summary>
        /// Text point size in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public float PointSize
        {
            get
            {
                return tabStyle?.Text?.PointSize?.All ?? 0;
            }
            set
            {
                if (null != tabStyle?.Text)
                {
                    tabStyle.Text.PointSize = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Text font family in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public string FontFamily
        {
            get
            {
                return tabStyle?.Text?.FontFamily?.All;
            }
            set
            {
                if (null != tabStyle?.Text)
                {
                    tabStyle.Text.FontFamily = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Text color in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Color TextColor
        {
            get
            {
                return tabStyle?.Text?.TextColor?.All;
            }
            set
            {
                if (null != tabStyle?.Text)
                {
                    tabStyle.Text.TextColor = value;
                    RelayoutRequest();
                }
            }
        }

        private ColorSelector textColorSelector = new ColorSelector();
        /// <summary>
        /// Text color selector in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public ColorSelector TextColorSelector
        {
            get
            {
                return textColorSelector;
            }
            set
            {
                if (value == null || textColorSelector == null)
                {
                    Tizen.Log.Fatal("NUI", "[Exception] Tab.TextColorSelector is null");
                    throw new NullReferenceException("Tab.TextColorSelector is null");
                }
                else
                {
                    textColorSelector.Clone(value);
                }
            }
        }

        /// <summary>
        /// Add tab item by item data. The added item will be added to end of all items automatically.
        /// </summary>
        /// <param name="itemData">Item data which will apply to tab item view.</param>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public void AddItem(TabItemData itemData)
        {
            AddItemByIndex(itemData, itemList.Count);
        }

        /// <summary>
        /// Insert tab item by item data. The inserted item will be added to the special position by index automatically.
        /// </summary>
        /// <param name="itemData">Item data which will apply to tab item view.</param>
        /// <param name="index">Position index where will be inserted.</param>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public void InsertItem(TabItemData itemData, int index)
        {
            AddItemByIndex(itemData, index);
        }

        /// <summary>
        /// Delete tab item by index.
        /// </summary>
        /// <param name="itemIndex">Position index where will be deleted.</param>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public void DeleteItem(int itemIndex)
        {
            if (itemList == null || itemIndex < 0 || itemIndex >= itemList.Count)
            {
                return;
            }

            if (curIndex > itemIndex || (curIndex == itemIndex && itemIndex == itemList.Count - 1))
            {
                curIndex--;
            }

            Remove(itemList[itemIndex]);
            itemList[itemIndex].Dispose();
            itemList.RemoveAt(itemIndex);

            UpdateItems();
        }

        /// <summary>
        /// Apply style to tab.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            TabStyle tabStyle = viewStyle as TabStyle;

            if (null != tabStyle)
            {
                Underline.ApplyStyle(tabStyle.UnderLine);
                CreateUnderLineAnimation();
            }
        }

        /// <summary>
        /// Dispose Tab and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
        protected override void Dispose(DisposeTypes type)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (underlineAni != null)
                {
                    if (underlineAni.State == Animation.States.Playing)
                    {
                        underlineAni.Stop();
                    }
                    underlineAni.Dispose();
                    underlineAni = null;
                }
                Utility.Dispose(underline);
                if (itemList != null)
                {
                    for (int i = 0; i < itemList.Count; i++)
                    {
                        Remove(itemList[i]);
                        itemList[i].Dispose();
                        itemList[i] = null;
                    }
                    itemList.Clear();
                    itemList = null;
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Update Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            LayoutChild();
        }

        /// <summary>
        /// Get Tab style.
        /// </summary>
        /// <returns>The default tab style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new TabStyle();
        }

        /// <summary>
        /// Layout child in Tab and it can be override by user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void LayoutChild()
        {
            if (itemList == null)
            {
                return;
            }

            int totalNum = itemList.Count;
            if (totalNum == 0)
            {
                return;
            }

            int preX = (int)tabStyle?.ItemPadding.Start;
            int preW = 0;
            int itemSpace = (null != tabStyle) ? tabStyle.ItemSpace : 0;

            if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                if (tabStyle?.UseTextNaturalSize == true)
                {
                    for (int i = 0; i < totalNum; i++)
                    {
                        preW = (itemList[i].TextItem.NaturalSize2D != null ? itemList[i].TextItem.NaturalSize2D.Width : 0);
                        itemList[i].PositionX = preX;
                        itemList[i].SizeWidth = preW;
                        preX = itemList[i].Position2D.X + preW + itemSpace;
                        itemList[i].Index = i;
                    }
                }
                else
                {
                    preW = (Size2D.Width - (int)tabStyle?.ItemPadding.Start - (int)tabStyle?.ItemPadding.End) / totalNum;
                    for (int i = 0; i < totalNum; i++)
                    {
                        itemList[i].PositionX = preX;
                        itemList[i].SizeWidth = preW;
                        preX = itemList[i].Position2D.X + preW + itemSpace;
                        itemList[i].Index = i;
                    }
                }
            }
            else
            {
                preX = (int)tabStyle?.ItemPadding.End;
                if (tabStyle?.UseTextNaturalSize == true)
                {
                    int w = Size2D.Width;
                    for (int i = 0; i < totalNum; i++)
                    {
                        preW = (itemList[i].NaturalSize2D != null ? itemList[i].NaturalSize2D.Width : 0);
                        itemList[i].PositionX = w - preW - preX;
                        itemList[i].SizeWidth = preW;
                        preX = w - itemList[i].Position2D.X + itemSpace;
                        itemList[i].Index = i;
                    }
                }
                else
                {
                    preW = (Size2D.Width - (int)tabStyle?.ItemPadding.Start - (int)tabStyle?.ItemPadding.End) / totalNum;
                    for (int i = totalNum - 1; i >= 0; i--)
                    {
                        itemList[i].PositionX = preX;
                        itemList[i].SizeWidth = preW;
                        preX = itemList[i].Position2D.X + preW + itemSpace;
                        itemList[i].Index = i;
                    }
                }
            }
            UpdateUnderLinePos();
        }

        private void Initialize()
        {
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            LayoutChild();
        }

        private void AddItemByIndex(TabItemData itemData, int index)
        {
            if (null == itemData || null == tabStyle) return;
            int h = 0;
            int topSpace = (int)tabStyle.ItemPadding.Top;
            if (Underline.Size != null)
            {
                h = (int)Underline.Size.Height;
            }

            Tab.TabItem item = new TabItem();
            item.TextItem.ApplyStyle(tabStyle.Text);

            item.Text = itemData.Text;
            item.SizeHeight = SizeHeight - h - topSpace;
            item.PositionY = topSpace;
            item.TouchEvent += ItemTouchEvent;
            Add(item);

            if (index >= itemList.Count)
            {
                itemList.Add(item);
            }
            else
            {
                itemList.Insert(index, item);
            }

            UpdateItems();
        }

        private void UpdateItems()
        {
            LayoutChild();
            if (itemList != null && curIndex >= 0 && curIndex < itemList.Count)
            {
                itemList[curIndex].IsSelected = true;
                UpdateUnderLinePos();
            }
            else
            {
                if (underline != null)
                {
                    underline.Hide();
                }
            }
        }

        private void CreateUnderLineAnimation()
        {
            if (underlineAni == null)
            {
                underlineAni = new Animation(aniTime);
            }
        }

        private void UpdateUnderLinePos()
        {
            if (underline == null || Underline.Size == null || itemList == null || itemList.Count <= 0)
            {
                return;
            }

            Underline.SizeWidth = itemList[curIndex].Size2D.Width;

            underline.Size2D = new Size2D(itemList[curIndex].Size2D.Width, (int)Underline.Size.Height);
            underline.BackgroundColor = tabStyle.UnderLine.BackgroundColor.All;
            if (isNeedAnimation)
            {
                CreateUnderLineAnimation();
                if (underlineAni.State == Animation.States.Playing)
                {
                    underlineAni.Stop();
                }
                underlineAni.Clear();
                underlineAni.AnimateTo(underline, "PositionX", itemList[curIndex].Position2D.X);
                underlineAni.Play();
            }
            else
            {
                underline.PositionX = itemList[curIndex].PositionX;
                isNeedAnimation = true;
            }

            underline.Show();
        }

        private void UpdateSelectedItem(TabItem item)
        {
            if (item == null || curIndex == item.Index)
            {
                return;
            }

            ItemChangedEventArgs e = new ItemChangedEventArgs
            {
                PreviousIndex = curIndex,
                CurrentIndex = item.Index
            };
            ItemChangedEvent?.Invoke(this, e);

            itemList[curIndex].IsSelected = false;
            curIndex = item.Index;
            itemList[curIndex].IsSelected = true;

            UpdateUnderLinePos();
        }

        private bool ItemTouchEvent(object source, TouchEventArgs e)
        {
            TabItem item = source as TabItem;
            if (item == null)
            {
                return false;
            }
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Up)
            {
                UpdateSelectedItem(item);
            }

            return true;
        }

        internal class TabItem : View
        {
            private bool isSelected = false;

            public TabItem() : base()
            {
                TextItem = new TextLabel()
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Add(TextItem);

                EnableControlStatePropagation = true;
            }

            internal int Index
            {
                get;
                set;
            }

            public string Text
            {
                get
                {
                    return TextItem.Text;
                }
                set
                {
                    TextItem.Text = value;
                }
            }

            internal TextLabel TextItem
            {
                get;
                set;
            }

            internal bool IsSelected
            {
                get
                {
                    return isSelected;
                }
                set
                {
                    ControlState = value ? ControlState.Selected : ControlState.Normal;
                    isSelected = value;
                }
            }
        }

        /// <summary>
        /// TabItemData is a class to record all data which will be applied to Tab item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class TabItemData
        {
            /// <summary>
            /// Text string in tab item view.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            public string Text
            {
                get;
                set;
            }
        }

        /// <summary>
        /// ItemChangedEventArgs is a class to record item change event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class ItemChangedEventArgs : EventArgs
        {
            /// <summary> Previous selected index of Tab </summary>
            /// <since_tizen> 6 </since_tizen>
            /// It will be removed in API10
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            public int PreviousIndex;
            /// <summary> Current selected index of Tab </summary>
            /// <since_tizen> 6 </since_tizen>
            /// It will be removed in API10
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            public int CurrentIndex;
        }
    }
}
