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
    public class Tab : Control
    {
        private const int aniTime = 100; // will be defined in const file later
        private List<TabItem> itemList = new List<TabItem>();
        private int curIndex = 0;
        private View underline = null;
        private Animation underlineAni = null;
        private bool isNeedAnimation = false;
        private Extents space;
        private bool useTextNaturalSize = false;
        private int itemSpace = 0;
        private float pointSize;
        private string fontFamily;
        private Color textColor;

        static Tab() { }

        /// <summary>
        /// Creates a new instance of a Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Tab() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Tab with style.
        /// </summary>
        /// <param name="style">Create Tab by special style defined in UX.</param>
        /// <since_tizen> 8 </since_tizen>
        public Tab(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Tab with style.
        /// </summary>
        /// <param name="tabStyle">Create Tab by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public Tab(TabStyle tabStyle) : base(tabStyle)
        {
            Initialize();
        }

        /// <summary>
        /// An event for the item changed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<ItemChangedEventArgs> ItemChangedEvent;

        /// <summary>
        /// Return a copied Style instance of Tab
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the Tab.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        //public new TabStyle Style
        //{
        //    get
        //    {
        //        return new TabStyle(ViewStyle as TabStyle);
        //    } 
        //}
        public new TabStyle Style => ViewStyle as TabStyle;

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
            set
            {
                underline = value;
            }
        }

        /// <summary>
        /// Selected item's index in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        public bool UseTextNaturalSize
        {
            get
            {
                return useTextNaturalSize;
            }
            set
            {
                useTextNaturalSize = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gap between items.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int ItemSpace
        {
            get
            {
                return itemSpace;
            }
            set
            {
                itemSpace = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Space in Tab. Sequence as Left, Right, Top, Bottom
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ItemPadding
        {
            get
            {
                if (null == space)
                {
                    space = new Extents(0, 0, 0, 0);
                }
                return space;
            }
            set
            {
                if (null == space)
                {
                    space = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
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

        /// <summary>
        /// UnderLine view's size in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size UnderLineSize
        {
            get
            {
                return Underline.Size;
            }
            set
            {
                Underline.Size = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// UnderLine view's background in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color UnderLineBackgroundColor
        {
            get
            {
                return Underline.BackgroundColor;
            }
            set
            {
                Underline.BackgroundColor = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Text point size in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float PointSize
        {
            get
            {
                return pointSize;
            }
            set
            {
                pointSize = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Text font family in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string FontFamily
        {
            get
            {
                return fontFamily;
            }
            set
            {
                fontFamily = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Text color in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                RelayoutRequest();
            }
        }

        private ColorSelector textColorSelector = new ColorSelector();
        /// <summary>
        /// Text color selector in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        public void InsertItem(TabItemData itemData, int index)
        {
            AddItemByIndex(itemData, index);
        }

        /// <summary>
        /// Delete tab item by index.
        /// </summary>
        /// <param name="itemIndex">Position index where will be deleted.</param>
        /// <since_tizen> 6 </since_tizen>
        public void DeleteItem(int itemIndex)
        {
            if(itemList == null || itemIndex < 0 || itemIndex >= itemList.Count)
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
        /// <since_tizen> 8 </since_tizen>
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            TabStyle tabStyle = viewStyle as TabStyle;

            if (null != tabStyle)
            {
                Underline.ApplyStyle(Style.UnderLine);
                CreateUnderLineAnimation();
            }
        }

        /// <summary>
        /// Dispose Tab and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if(underlineAni != null)
                {
                    if(underlineAni.State == Animation.States.Playing)
                    {
                        underlineAni.Stop();
                    }
                    underlineAni.Dispose();
                    underlineAni = null;
                }
                Utility.Dispose(underline);
                if(itemList != null)
                {
                    for(int i = 0; i < itemList.Count; i++)
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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            LayoutChild();
        }

        /// <summary>
        /// Get Tab style.
        /// </summary>
        /// <returns>The default tab style.</returns>
        /// <since_tizen> 8 </since_tizen>
        protected override ViewStyle GetViewStyle()
        {
            return new TabStyle();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event data</param>
        /// <since_tizen> 8 </since_tizen>
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            TabStyle tabStyle = StyleManager.Instance.GetViewStyle(style) as TabStyle;
            if (tabStyle != null)
            {
                Style.CopyFrom(tabStyle);
            }
        }

        /// <summary>
        /// Layout child in Tab and it can be override by user.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
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

            int preX = (int)ItemPadding.Start;
            int preW = 0;

            if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                if (useTextNaturalSize == true)
                {
                    for (int i = 0; i < totalNum; i++)
                    {
                        preW = (itemList[i].TextItem.NaturalSize2D != null ? itemList[i].TextItem.NaturalSize2D.Width : 0);
                        itemList[i].Position.X = preX;
                        itemList[i].Size.Width = preW;
                        preX = (int)itemList[i].Position.X + preW + itemSpace;
                        itemList[i].Index = i;
                    }
                }
                else
                {
                    preW = ((int)Size.Width - (int)ItemPadding.Start - (int)ItemPadding.End) / totalNum;
                    for (int i = 0; i < totalNum; i++)
                    {
                        itemList[i].Position.X = preX;
                        itemList[i].Size.Width = preW;
                        preX = (int)itemList[i].Position.X + preW + itemSpace;
                        itemList[i].Index = i;
                    }
                }
            }
            else
            {
                preX = (int)ItemPadding.End;
                if (useTextNaturalSize == true)
                {
                    int w = (int)Size.Width;
                    for (int i = 0; i < totalNum; i++)
                    {
                        preW = (itemList[i].NaturalSize2D != null ? itemList[i].NaturalSize2D.Width : 0);
                        itemList[i].Position.X = w - preW - preX;
                        itemList[i].Size.Width = preW;
                        preX = w - (int)itemList[i].Position.X + itemSpace;
                        itemList[i].Index = i;
                    }
                }
                else
                {
                    preW = ((int)Size.Width - (int)ItemPadding.Start - (int)ItemPadding.End) / totalNum;
                    for (int i = totalNum - 1; i >= 0; i--)
                    {
                        itemList[i].Position.X = preX;
                        itemList[i].Size.Width = preW;
                        preX = (int)itemList[i].Position.X + preW + itemSpace;
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
            if (null == itemData) return;
            int h = (int)Underline.Size.Height;
            int topSpace = (int)ItemPadding.Top;

            Tab.TabItem item = new TabItem();
            item.TextItem.ApplyStyle(Style.Text);

            item.Text = itemData.Text;
            item.Size.Height = Size.Height - h - topSpace;
            item.Position.Y = topSpace;
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
                itemList[curIndex].ControlState = ControlStates.Selected;
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
            if (underline == null || underline.Size == null || itemList == null || itemList.Count <= 0)
            {
                return;
            }

            underline.Size = new Size(itemList[curIndex].Size.Width, (int)Style.UnderLine.Size.Height);
            underline.BackgroundColor = Style.UnderLine.BackgroundColor.All;
            if (isNeedAnimation)
            {
                CreateUnderLineAnimation();
                if (underlineAni.State == Animation.States.Playing)
                {
                    underlineAni.Stop();
                }
                underlineAni.Clear();
                underlineAni.AnimateTo(underline, "PositionX", itemList[curIndex].Position.X);
                underlineAni.Play();
            }
            else
            {
                underline.Position.X = (int)itemList[curIndex].Position.X;
                isNeedAnimation = true;
            }

            underline.Show();
        }

        private void UpdateSelectedItem(TabItem item)
        {
            if(item == null || curIndex == item.Index)
            {
                return;
            }

            ItemChangedEventArgs e = new ItemChangedEventArgs
            {
                PreviousIndex = curIndex,
                CurrentIndex = item.Index
            };
            ItemChangedEvent?.Invoke(this, e);

            itemList[curIndex].ControlState = ControlStates.Normal;
            curIndex = item.Index;
            itemList[curIndex].ControlState = ControlStates.Selected;

            UpdateUnderLinePos();
        }

        private bool ItemTouchEvent(object source, TouchEventArgs e)
        {
            TabItem item = source as TabItem;
            if(item == null)
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
        }

        /// <summary>
        /// TabItemData is a class to record all data which will be applied to Tab item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class TabItemData
        {
            /// <summary>
            /// Text string in tab item view.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
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
        public class ItemChangedEventArgs : EventArgs
        {
            /// <summary> Previous selected index of Tab </summary>
            /// <since_tizen> 6 </since_tizen>
            public int PreviousIndex;
            /// <summary> Current selected index of Tab </summary>
            /// <since_tizen> 6 </since_tizen>
            public int CurrentIndex;
        }
    }
}
