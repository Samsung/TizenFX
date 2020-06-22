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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// DropDown is one kind of common component, a dropdown allows the user click dropdown button to choose one value from a list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DropDown : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListPaddingProperty = BindableProperty.Create(nameof(ListPadding), typeof(Extents), typeof(DropDown), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DropDown)bindable;
            if (newValue != null)
            {
                instance.listPadding.CopyFrom((Extents)newValue);
                instance.UpdateDropDown();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DropDown)bindable;
            return instance.listPadding;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedItemIndexProperty = BindableProperty.Create(nameof(SelectedItemIndex), typeof(int), typeof(DropDown), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DropDown)bindable;
            if (newValue != null)
            {
                int selectedItemIndex = (int)newValue;
                if (selectedItemIndex == instance.selectedItemIndex || instance.adapter == null || selectedItemIndex < 0 || selectedItemIndex >= instance.adapter.GetItemCount())
                {
                    return;
                }
                instance.SetListItemToSelected((uint)selectedItemIndex);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DropDown)bindable;
            return instance.selectedItemIndex;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListMarginProperty = BindableProperty.Create(nameof(ListMargin), typeof(Extents), typeof(DropDown), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DropDown)bindable;
            if (newValue != null)
            {
                instance.listMargin.CopyFrom((Extents)newValue);
                instance.UpdateDropDown();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DropDown)bindable;
            return instance.listMargin;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListRelativeOrientationProperty = BindableProperty.Create(nameof(ListRelativeOrientation), typeof(ListOrientation), typeof(DropDown), ListOrientation.Left, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DropDown)bindable;
            if (newValue != null)
            {
                instance.listRelativeOrientation = (ListOrientation)newValue;
                instance.UpdateDropDown();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DropDown)bindable;
            return instance.listRelativeOrientation;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceBetweenButtonTextAndIconProperty = BindableProperty.Create(nameof(SpaceBetweenButtonTextAndIcon), typeof(int), typeof(DropDown), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DropDown)bindable;
            if (newValue != null)
            {
                instance.spaceBetweenButtonTextAndIcon = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DropDown)bindable;
            return instance.spaceBetweenButtonTextAndIcon;
        });

        #region DropDown
        private Button button = null;
        private TextLabel headerText = null;
        private TextLabel buttonText = null;
        private ImageView listBackgroundImage = null;
        // Component that scrolls the child added to it.
        private ScrollableBase scrollableBase = null;

        // The LinearLayout container to house the items in the drop down list.
        private View dropDownMenuFullList = null;
        private DropDownListBridge adapter = new DropDownListBridge();
        private DropDownItemView selectedItemView = null;
        private TapGestureDetector tapGestureDetector = null;

        private Extents listMargin = new Extents(0, 0, 0, 0);
        private Extents listPadding = new Extents(0, 0, 0, 0);
        private ListOrientation listRelativeOrientation = ListOrientation.Left;
        private int selectedItemIndex = -1;
        private int spaceBetweenButtonTextAndIcon = 0;
        private bool itemPressed = false;

        static DropDown() { }

        /// <summary>
        /// Creates a new instance of a DropDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDown() : base() { }

        /// <summary>
        /// Creates a new instance of a DropDown with style.
        /// </summary>
        /// <param name="style">Create DropDown by special style defined in UX.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDown(string style) : base(style) { }

        /// <summary>
        /// Creates a new instance of a DropDown with style.
        /// </summary>
        /// <param name="dropDownStyle">Create DropDown by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDown(DropDownStyle dropDownStyle) : base(dropDownStyle)
        {
        }

        /// <summary>
        /// An event for the item clicked signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ItemClickEventArgs> ItemClickEvent;

        /// <summary>
        /// List position in relation to the main button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ListOrientation
        {
            /// <summary>
            /// Left.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Left,
            /// <summary>
            /// Right.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Right,
        }

        /// <summary>
        /// Get or set header text.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel HeaderText
        {
            get
            {
                if (null == headerText)
                {
                    headerText = new TextLabel()
                    {
                        WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                        HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        ParentOrigin = NUI.ParentOrigin.Center,
                        PivotPoint = NUI.ParentOrigin.Center,
                        PositionUsesPivotPoint = true,
                        Name = "DropDownHeaderText"
                    };
                    Add(headerText);
                }
                return headerText;
            }
            internal set
            {
                headerText = value;
            }
        }

        /// <summary>
        /// Get or set button.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button Button
        {
            get
            {
                if (null == button)
                {
                    button = new Button()
                    {
                        ParentOrigin = NUI.ParentOrigin.CenterLeft,
                        PivotPoint = NUI.PivotPoint.CenterLeft,
                        PositionUsesPivotPoint = true,
                        HeightResizePolicy = ResizePolicyType.FitToChildren,
                        IconRelativeOrientation = Button.IconOrientation.Right,
                        Name = "DropDownButton"
                    };
                    button.ClickEvent += ButtonClickEvent;
                    Add(button);

                    if (null == buttonText)
                    {
                        buttonText = new TextLabel();
                    }
                }
                return button;
            }
            internal set
            {
                button = value;
            }
        }

        /// <summary>
        /// Get or set the background image of list.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView ListBackgroundImage
        {
            get
            {
                if (null == listBackgroundImage)
                {
                    listBackgroundImage = new ImageView()
                    {
                        Name = "ListBackgroundImage",
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        WidthResizePolicy = ResizePolicyType.FitToChildren,
                        HeightResizePolicy = ResizePolicyType.FitToChildren,
                    };
                    Add(listBackgroundImage);

                    if (null == scrollableBase) // scrollableBase used to test of ListContainer Setup invoked already
                    {
                        SetUpListContainer();
                    }
                }
                return listBackgroundImage;
            }
            internal set
            {
                listBackgroundImage = value;
            }
        }

        /// <summary>
        /// Return a copied Style instance of DropDown
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the DropDown.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        //public new DropDownStyle Style
        //{
        //    get
        //    {
        //        return new DropDownStyle(ViewStyle as DropDownStyle);
        //    }
        //}
        public new DropDownStyle Style => ViewStyle as DropDownStyle;

        /// <summary>
        /// Space between button text and button icon in DropDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public int SpaceBetweenButtonTextAndIcon
        {
            get => (int)GetValue(SpaceBetweenButtonTextAndIconProperty);
            set => SetValue(SpaceBetweenButtonTextAndIconProperty, value);
        }

        /// <summary>
        /// List relative orientation in DropDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ListOrientation ListRelativeOrientation
        {
            get => (ListOrientation)GetValue(ListRelativeOrientationProperty);
            set => SetValue(ListRelativeOrientationProperty, value);
        }

        /// <summary>
        /// Space in list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public Extents ListMargin
        {
            get
            {
                Extents tmp = (Extents)GetValue(ListMarginProperty);
                return new Extents((ushort start, ushort end, ushort top, ushort bottom) => { ListMargin = new Extents(start, end, top, bottom); }, tmp.Start, tmp.End, tmp.Top, tmp.Bottom);
            }
            set => SetValue(ListMarginProperty, value);
        }

        /// <summary>
        /// Selected item index in list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public int SelectedItemIndex
        {
            get => (int)GetValue(SelectedItemIndexProperty);
            set => SetValue(SelectedItemIndexProperty, value);
        }

        /// <summary>
        /// List padding in DropDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public Extents ListPadding
        {
            get
            {
                Extents tmp = (Extents)GetValue(ListPaddingProperty);
                return new Extents((ushort start, ushort end, ushort top, ushort bottom) => { ListPadding = new Extents(start, end, top, bottom); }, tmp.Start, tmp.End, tmp.Top, tmp.Bottom);
            }
            set => SetValue(ListPaddingProperty, value);
        }

        /// <summary>
        /// Add list item by item data. The added item will be added to end of all items automatically.
        /// </summary>
        /// <param name="itemData">Item data which will apply to tab item view.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddItem(DropDownDataItem itemData)
        {
           // Add item to adaptor, will be added to list via AddItemAt during OnUpdate()
           int insertionPosition = adapter.GetItemCount();
           adapter.InsertData(insertionPosition, itemData);
        }

        /// <summary>
        /// Delete list item by index.
        /// </summary>
        /// <param name="index">Position index where will be deleted.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteItem(int index)
        {
            if (index < 0 || index >= adapter?.GetItemCount()) return;
            if (null == dropDownMenuFullList) return;

            if (selectedItemIndex == index)
            {
                selectedItemIndex = -1;
            }
            else if(selectedItemIndex > index)
            {
                selectedItemIndex--;
            }

            adapter?.RemoveData(index);

            if(index < dropDownMenuFullList.ChildCount)
            {
                View childToRemove = dropDownMenuFullList.GetChildAt((uint)index);
                if (childToRemove)
                {
                    childToRemove.TouchEvent -= ListItemTouchEvent;
                    dropDownMenuFullList.Remove(childToRemove);
                    dropDownMenuFullList?.Layout?.RequestLayout();
                }
            }
        }

        /// <summary>
        /// Insert list item by item data. The inserted item will be added to the special position by index automatically.
        /// </summary>
        /// <param name="item">Item data which will apply to tab item view.</param>
        /// <param name="index">Position index where will be inserted.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertItem(DropDownDataItem item, int index)
        {
            if (index < 0 || index >= adapter.GetItemCount())
            {
                return;
            }

            if (selectedItemIndex >= index)
            {
                selectedItemIndex++;
            }

            adapter.InsertData(index, item);
        }

        /// <summary>
        /// Add scroll bar to list.
        /// </summary>
        /// <param name="scrollBar">Scroll bar defined by user which will be added to list.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AttachScrollBar(ScrollBar scrollBar)
        {
            if (scrollableBase == null)
            {
                return;
            }
            Tizen.Log.Error("DropDown","Feature unsupported");
        }

        /// <summary>
        /// Detach scroll bar to list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DetachScrollBar()
        {
            if (scrollableBase == null)
            {
                return;
            }
            Tizen.Log.Error("DropDown","Feature unsupported");
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            DropDownStyle dropDownStyle = viewStyle as DropDownStyle;
            if (null != dropDownStyle)
            {
                if (null != dropDownStyle.Button)
                {
                    Button.ApplyStyle(dropDownStyle.Button);
                }
                if (null != dropDownStyle.HeaderText)
                {
                    HeaderText.ApplyStyle(dropDownStyle.HeaderText);
                }
                if (null != dropDownStyle.ListBackgroundImage)
                {
                    ListBackgroundImage.ApplyStyle(dropDownStyle.ListBackgroundImage);
                }
                UpdateDropDown();
            }
        }

        /// <summary>
        /// Update DropDown by style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UpdateDropDown()
        {
            if (null == scrollableBase || null == listBackgroundImage || null == dropDownMenuFullList) return;
            if (null == Style.ListBackgroundImage.Size) return;
            // Resize and position scrolling list within the drop down list container.  Can be used to position list in relation to the background image.
            scrollableBase.Size = Style.ListBackgroundImage.Size - new Size((listPadding.Start + listPadding.End), (listPadding.Top + listPadding.Bottom), 0);
            scrollableBase.Position2D = new Position2D(listPadding.Start, listPadding.Top);

            int listBackgroundImageX = 0;
            int listBackgroundImageY = 0;
            if (listRelativeOrientation == ListOrientation.Left)
            {
                listBackgroundImageX = (int)listMargin.Start;
                listBackgroundImageY = (int)listMargin.Top;
            }
            else if (listRelativeOrientation == ListOrientation.Right)
            {
                listBackgroundImageX = -(int)listMargin.End;
                listBackgroundImageY = (int)listMargin.Top;
            }
            listBackgroundImage.Position2D = new Position2D(listBackgroundImageX, listBackgroundImageY);
            dropDownMenuFullList?.Layout?.RequestLayout();
        }

        /// <summary>
        /// update.
        /// </summary>
        protected override void OnUpdate()
        {
            float buttonTextWidth = 0;
            if (null != buttonText)
            {
                buttonText.Text = Style.Button.Text.Text.All;
                buttonText.PointSize = Style.Button.Text.PointSize?.GetValue(ControlState) ?? StyleManager.PointSizeNormal;
                buttonTextWidth = buttonText.NaturalSize.Width;
            }
            float fitWidth = (Style.Button.Icon.Size?.Width ?? 48) + Style.SpaceBetweenButtonTextAndIcon + buttonTextWidth;
            fitWidth += (button.IconPadding.Start + button.IconPadding.End);
            button.Size.Width = Math.Max(button.Size.Width, fitWidth);
            RelayoutRequest();

            int numberOfItemsToAdd = adapter.GetItemCount();

            if (adapter.AdapterPurge == true)
            {
                adapter.AdapterPurge = false;
                for (int i = 0; i < numberOfItemsToAdd; i++)
                {
                    AddItemAt(adapter.GetData(i), i);
                }
            }
            // Set selection icon on View
            if (selectedItemIndex > 0)
            {
                SetListItemToSelected((uint)selectedItemIndex, selectedItemView);
            }
        }

        /// <summary>
        /// Dispose DropDown and all children on it.
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
                Utility.Dispose(headerText);
                Utility.Dispose(buttonText);
                Utility.Dispose(button);
                Utility.Dispose(scrollableBase);
                Utility.Dispose(dropDownMenuFullList);
                Utility.Dispose(listBackgroundImage);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Get DropDown style.
        /// </summary>
        /// <returns>The default dropdown style.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new DropDownStyle();
        }

        private void AddItemAt(DropDownDataItem itemData,int index)
        {
            ViewHolder viewHolder = adapter.OnCreateViewHolder();
            if (!viewHolder.IsBound)
            {
                adapter.BindViewHolder(viewHolder, index);
                viewHolder.IsBound = true;
            }

            if (tapGestureDetector == null)
            {
                tapGestureDetector = new TapGestureDetector();
            }
            View view = viewHolder.ItemView;
            view.ApplyStyle(itemData.itemDataStyle);
            view.TouchEvent += ListItemTouchEvent;
            dropDownMenuFullList.Add(view);
        }

        private void OnClickEvent(object sender, ItemClickEventArgs e)
        {
            ItemClickEvent?.Invoke(sender, e);
        }

        private void CreateButtonText()
        {
            if (null == buttonText)
            {
                buttonText = new TextLabel();
            }
        }

        private void CreateButton()
        {
            if (null == button)
            {
                button = new Button()
                {
                    ParentOrigin = NUI.ParentOrigin.CenterLeft,
                    PivotPoint = NUI.PivotPoint.CenterLeft,
                    PositionUsesPivotPoint = true,
                    HeightResizePolicy = ResizePolicyType.FitToChildren,
                    IconRelativeOrientation = Button.IconOrientation.Right,
                };
                button.Name = "DropDownButton";
                button.ClickEvent += ButtonClickEvent;
                Add(button);
            }
        }

        private void SetUpListContainer()
        {
            LinearLayout linear = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            };

            dropDownMenuFullList = new View()
            {
                Layout = linear,
                Name = "DropDownMenuList",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Focusable = true,
            };

            scrollableBase = new ScrollableBase()
            {
                Name = "Scrollable",
            };
            scrollableBase.Add(dropDownMenuFullList);

            listBackgroundImage.Add(scrollableBase);
            listBackgroundImage.Hide();
        }

        private View GetViewFromIndex(uint index)
        {
            if ((index < dropDownMenuFullList.ChildCount) && (index >=0) )
            {
                return dropDownMenuFullList.GetChildAt(index);
            }
            else
            {
                return null;
            }
        }

        private void SetListItemToSelected(DropDownItemView view)
        {
            if (dropDownMenuFullList == null || view == null || view == selectedItemView)
            {
                return;
            }

            uint newSelectedIndex = 0;
            for (; newSelectedIndex < dropDownMenuFullList.ChildCount; newSelectedIndex++)
            {
                var itemView = dropDownMenuFullList.GetChildAt(newSelectedIndex) as DropDownItemView;
                if (itemView == view)
                {
                    SetListItemToSelected(newSelectedIndex, view);
                    return;
                }
            }
        }

        private void SetListItemToSelected(uint index)
        {
            if (dropDownMenuFullList == null || index == selectedItemIndex)
            {
                return;
            }

            SetListItemToSelected(index, GetViewFromIndex(index) as DropDownItemView);
        }

        private void SetListItemToSelected(uint index, DropDownItemView view)
        {
            if (adapter == null)
            {
                return;
            }

            if (selectedItemView != null)
            {
                selectedItemView.IsSelected = false;
                selectedItemView.ControlState = ControlStates.Normal;
                adapter.GetData(selectedItemIndex).IsSelected = false;
            }

            if (view == null || index >= dropDownMenuFullList.ChildCount)
            {
                selectedItemIndex = -1;
                selectedItemView = null;
                return;
            }

            selectedItemIndex = (int)index;
            selectedItemView = view;
            selectedItemView.ControlState = ControlStates.Selected;
            selectedItemView.IsSelected = true;
            adapter.GetData(selectedItemIndex).IsSelected = true;
            dropDownMenuFullList.Layout?.RequestLayout();
        }

        private bool ListItemTouchEvent(object sender, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            DropDownItemView touchedView = sender as DropDownItemView;;
            switch (state)
            {
                case PointStateType.Down:
                    if (touchedView != null)
                    {
                        touchedView.ControlState = ControlStates.Pressed;
                    }
                    itemPressed = true;  // if matched with a Up then a click event.
                    break;
                case PointStateType.Motion:
                    if (touchedView != null)
                    {
                        touchedView.ControlState = ControlStates.Normal;
                    }
                    itemPressed = false;
                    break;
                case PointStateType.Up:
                    if (touchedView != null)
                    {
                        if (itemPressed)  // if Down was previously sent without motion (Scrolling) in-between then a clicked event occurred.
                        {
                            // List item clicked
                            Console.WriteLine("Tapped{0}", touchedView.Name);
                            SetListItemToSelected(touchedView);
                            button.Text = touchedView.Text;
                            button.Show();
                            listBackgroundImage.Hide();
                        }
                    }
                    break;
                default:
                    break;
            }
            return true;
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            button.Hide();
            listBackgroundImage.Show();
            dropDownMenuFullList?.Layout?.RequestLayout();
            listBackgroundImage.RaiseToTop();
        }

        #endregion

        #region ItemClickEventArgs
        /// <summary>
        /// ItemClickEventArgs is a class to record item click event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ItemClickEventArgs : EventArgs
        {
            /// <summary> Clicked item index of DropDown's list </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int Index { get; set; }
            /// <summary> Clicked item text string of DropDown's list </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Text { get; set; }
        }
        #endregion

        #region ViewHolder

        /// <summary>
        /// A ViewHolder is a class that holds a View created from DropDownListBridge data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ViewHolder
        {
            /// <summary>
            /// ViewHolder constructor.
            /// </summary>
            /// <param name="itemView">View</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder(View itemView)
            {
                ItemView = itemView ?? throw new ArgumentNullException(nameof(itemView), "itemView may not be null");
            }

            /// <summary>
            /// Returns the view.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public View ItemView { get; }

            internal bool IsBound { get; set; }
        }

        #endregion
    }
}
