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

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// Tab is one kind of common component, it can be used as menu label.
    /// User can handle Tab by adding/inserting/deleting TabItem.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Tab : Control
    {
        private const int aniTime = 100; // will be defined in const file later
        private List<TabItem> itemList = new List<TabItem>();
        private int curIndex = 0;
        private View underline = null;
        private TabAttributes tabAttributes = null;
        private Animation underlineAni = null;
        private bool isNeedAnimation = false;

        /// <summary>
        /// Creates a new instance of a Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tab() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Tab with style.
        /// </summary>
        /// <param name="style">Create Tab by special style defined in UX.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tab(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Tab with attributes.
        /// </summary>
        /// <param name="attributes">Create Tab by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tab(TabAttributes attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// An event for the item changed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ItemChangeEventArgs> ItemChangedEvent;

        /// <summary>
        /// Selected item's index in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsNatureTextWidth
        {
            get
            {
                return tabAttributes.IsNatureTextWidth;
            }
            set
            {
                tabAttributes.IsNatureTextWidth = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gap between items.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ItemGap
        {
            get
            {
                return tabAttributes.ItemGap;
            }
            set
            {
                tabAttributes.ItemGap = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Left space in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftSpace
        {
            get
            {
                return (int)tabAttributes.Space.X;
            }
            set
            {
                tabAttributes.Space.X = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Bottom space in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BottomSpace
        {
            get
            {
                return (int)tabAttributes.Space.W;
            }
            set
            {
                tabAttributes.Space.W = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Right space in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightSpace
        {
            get
            {
                return (int)tabAttributes.Space.Y;
            }
            set
            {
                tabAttributes.Space.Y = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Top space in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TopSpace
        {
            get
            {
                return (int)tabAttributes.Space.Z;
            }
            set
            {
                tabAttributes.Space.Z = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// UnderLine view's size in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D UnderLineSize2D
        {
            get
            {
                return tabAttributes.UnderLineAttributes?.Size2D;
            }
            set
            {
                if (value != null)
                {
                    CreateUnderLineAttributes();
                    tabAttributes.UnderLineAttributes.Size2D = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// UnderLine view's background in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color UnderLineBackgroundColor
        {
            get
            {
                return tabAttributes.UnderLineAttributes?.BackgroundColor?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateUnderLineAttributes();
                    if (tabAttributes.UnderLineAttributes.BackgroundColor == null)
                    {
                        tabAttributes.UnderLineAttributes.BackgroundColor = new ColorSelector();
                    }
                    tabAttributes.UnderLineAttributes.BackgroundColor.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Text point size in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float PointSize
        {
            get
            {
                return tabAttributes.TextAttributes?.PointSize?.All ?? 0;
            }
            set
            {
                CreateTextAttributes();
                if (tabAttributes.TextAttributes.PointSize == null)
                {
                    tabAttributes.TextAttributes.PointSize = new FloatSelector();
                }
                tabAttributes.TextAttributes.PointSize.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Text font family in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get
            {
                return tabAttributes.TextAttributes?.FontFamily;
            }
            set
            {
                CreateTextAttributes();
                tabAttributes.TextAttributes.FontFamily = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Text color in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TextColor
        {
            get
            {
                return tabAttributes.TextAttributes?.TextColor?.All;
            }
            set
            {
                CreateTextAttributes();
                if (tabAttributes.TextAttributes.TextColor == null)
                {
                    tabAttributes.TextAttributes.TextColor = new ColorSelector();
                }
                tabAttributes.TextAttributes.TextColor.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Text color selector in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector TextColorSelector
        {
            get
            {
                return tabAttributes.TextAttributes.TextColor;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    tabAttributes.TextAttributes.TextColor = value.Clone() as ColorSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Add tab item by item data. The added item will be added to end of all items automatically.
        /// </summary>
        /// <param name="itemData">Item data which will apply to tab item view.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertItem(TabItemData itemData, int index)
        {
            AddItemByIndex(itemData, index);
        }

        /// <summary>
        /// Delete tab item by index.
        /// </summary>
        /// <param name="itemIndex">Position index where will be deleted.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Dispose Tab and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Update Tab by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            if (tabAttributes.UnderLineAttributes != null)
            {
                if (underline == null)
                {
                    underline = new View()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    };
                    Add(underline);
                    CreateUnderLineAnimation();
                }
                ApplyAttributes(underline, tabAttributes.UnderLineAttributes);
            }

            if (tabAttributes.TextAttributes != null)
            {
                if (curIndex >= 0 && curIndex < itemList.Count)
                {
                    itemList[curIndex].UpdateItemText(tabAttributes.TextAttributes);
                }
            }

            LayoutChild();
        }

        /// <summary>
        /// Get Tab attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new TabAttributes();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            TabAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as TabAttributes;
            if (tempAttributes != null)
            {
                tempAttributes.IsNatureTextWidth = tabAttributes.IsNatureTextWidth; // keep IsNatureTextWidth as original
                attributes = tabAttributes = tempAttributes;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Layout child in Tab and it can be override by user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void LayoutChild()
        {
            if (tabAttributes == null || itemList == null)
            {
                return;
            }
            int totalNum = itemList.Count;
            if (totalNum == 0)
            {
                return;
            }

            int preX = (int)tabAttributes.Space.X;
            int preW = 0;
            int itemGap = tabAttributes.ItemGap;

            if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                if (tabAttributes.IsNatureTextWidth == true)
                {
                    for (int i = 0; i < totalNum; i++)
                    {
                        preW = itemList[i].TextItem.NaturalSize2D.Width;
                        itemList[i].Position2D.X = preX;
                        itemList[i].Size2D.Width = preW;
                        preX = itemList[i].Position2D.X + preW + itemGap;
                        itemList[i].Index = i;
                    }
                }
                else
                {
                    preW = (Size2D.Width - (int)tabAttributes.Space.X - (int)tabAttributes.Space.Y) / totalNum;
                    for (int i = 0; i < totalNum; i++)
                    {
                        itemList[i].Position2D.X = preX;
                        itemList[i].Size2D.Width = preW;
                        preX = itemList[i].Position2D.X + preW + itemGap;
                        itemList[i].Index = i;
                    }
                }
            }
            else
            {
                preX = (int)tabAttributes.Space.Y;
                if (tabAttributes.IsNatureTextWidth == true)
                {
                    int w = Size2D.Width;
                    for (int i = 0; i < totalNum; i++)
                    {
                        preW = (itemList[i].TextItem.NaturalSize2D != null ? itemList[i].TextItem.NaturalSize2D.Width : 0);
                        itemList[i].Position2D.X = w - preW - preX;
                        itemList[i].Size2D.Width = preW;
                        preX = w - itemList[i].Position2D.X + itemGap;
                        itemList[i].Index = i;
                    }
                }
                else
                {
                    preW = (Size2D.Width - (int)tabAttributes.Space.X - (int)tabAttributes.Space.Y) / totalNum;
                    for (int i = totalNum - 1; i >= 0; i--)
                    {
                        itemList[i].Position2D.X = preX;
                        itemList[i].Size2D.Width = preW;
                        preX = itemList[i].Position2D.X + preW + itemGap;
                        itemList[i].Index = i;
                    }
                }
            }
            UpdateUnderLinePos();
        }

        private void Initialize()
        {
            tabAttributes = attributes as TabAttributes;
            if (tabAttributes == null)
            {
                throw new Exception("Tab attribute parse error.");
            }

            ApplyAttributes(this, tabAttributes);
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            LayoutChild();
        }

        private void AddItemByIndex(TabItemData itemData, int index)
        {
            int h = 0;
            int topSpace = (int)tabAttributes.Space.Z;
            if (tabAttributes.UnderLineAttributes != null && tabAttributes.UnderLineAttributes.Size2D != null)
            {
                h = tabAttributes.UnderLineAttributes.Size2D.Height;
            }
            Tab.TabItem item = new TabItem();
            ApplyAttributes(item.TextItem, tabAttributes.TextAttributes);
            item.TextItem.Text = itemData.Text;
            item.Size2D.Height = Size2D.Height - h - topSpace;
            item.Position2D.Y = topSpace;
            item.TouchEvent += ItemTouchEvent;
            Add(item);

            if(index >= itemList.Count)
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
                itemList[curIndex].State = ControlStates.Selected;
                itemList[curIndex].UpdateItemText(tabAttributes.TextAttributes);
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

        private void CreateUnderLineAttributes()
        {
            if (tabAttributes.UnderLineAttributes == null)
            {
                tabAttributes.UnderLineAttributes = new ViewAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                };
            }
        }

        private void CreateTextAttributes()
        {
            if (tabAttributes.TextAttributes == null)
            {
                tabAttributes.TextAttributes = new TextAttributes()
                {
                    PositionUsesPivotPoint =  true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WidthResizePolicy =  ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
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
            if (underline == null || tabAttributes.UnderLineAttributes == null || tabAttributes.UnderLineAttributes.Size2D == null
                || itemList == null || itemList.Count <= 0)
            {
                return;
            }

            tabAttributes.UnderLineAttributes.Size2D.Width = itemList[curIndex].Size2D.Width;

            underline.Size2D = new Size2D(itemList[curIndex].Size2D.Width, tabAttributes.UnderLineAttributes.Size2D.Height);
            underline.BackgroundColor = tabAttributes.UnderLineAttributes.BackgroundColor.All;
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
                underline.Position2D.X = itemList[curIndex].Position2D.X;
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

            ItemChangeEventArgs e = new ItemChangeEventArgs
            {
                PreviousIndex = curIndex,
                CurrentIndex = item.Index
            };
            ItemChangedEvent?.Invoke(this, e);

            itemList[curIndex].State = ControlStates.Normal;
            itemList[curIndex].UpdateItemText(tabAttributes.TextAttributes);
            curIndex = item.Index;
            itemList[curIndex].State = ControlStates.Selected;
            itemList[curIndex].UpdateItemText(tabAttributes.TextAttributes);

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

        internal class TabItem : Control
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

            internal int Index
            {
                get;
                set;
            }

            internal TextLabel TextItem
            {
                get;
                set;
            }

            protected override void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                if (type == DisposeTypes.Explicit)
                {
                    if (TextItem != null)
                    {
                        Remove(TextItem);
                        TextItem.Dispose();
                        TextItem = null;
                    }
                }

                base.Dispose(type);
            }

            protected override Attributes GetAttributes()
            {
                return null;
            }

            internal void UpdateItemText(TextAttributes attrs)
            {
                ApplyAttributes(TextItem, attrs);
            }
        }

        /// <summary>
        /// TabItemData is a class to record all data which will be applied to Tab item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class TabItemData
        {
            /// <summary>
            /// Text string in tab item view.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Text
            {
                get;
                set;
            }
        }

        /// <summary>
        /// ItemChangeEventArgs is a class to record item change event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ItemChangeEventArgs : EventArgs
        {
            /// <summary> Previous selected index of Tab </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int PreviousIndex;
            /// <summary> Current selected index of Tab </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int CurrentIndex;
        }
    }
}
