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
    public class DropDown : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListPaddingProperty = BindableProperty.Create("ListPadding", typeof(Extents), typeof(DropDown), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SelectedItemIndexProperty = BindableProperty.Create("SelectedItemIndex", typeof(int), typeof(DropDown), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DropDown)bindable;
            if (newValue != null)
            {
                int selectedItemIndex = (int)newValue;
                if (selectedItemIndex == instance.selectedItemIndex || instance.adapter == null || selectedItemIndex >= instance.adapter.GetItemCount())
                {
                    return;
                }
                instance.UpdateSelectedItem(selectedItemIndex);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DropDown)bindable;
            return instance.selectedItemIndex;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListMarginProperty = BindableProperty.Create("ListMargin", typeof(Extents), typeof(DropDown), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ListRelativeOrientationProperty = BindableProperty.Create("ListRelativeOrientation", typeof(ListOrientation), typeof(DropDown), ListOrientation.Left, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SpaceBetweenButtonTextAndIconProperty = BindableProperty.Create("SpaceBetweenButtonTextAndIcon", typeof(int), typeof(DropDown), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        private Scrollable scrollable = null;

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
        /// Creates a new instance of a DropDown with attributes.
        /// </summary>
        /// <param name="attributes">Create DropDown by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDown(DropDownStyle attributes) : base(attributes)
        {
        }

        /// <summary>
        /// An event for the button clicked signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void ClickEventHandler<ClickEventArgs>(object sender, ClickEventArgs e);

        /// <summary>
        /// An event for the item clicked signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ClickEventHandler<ItemClickEventArgs> ItemClickEvent;

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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            if (scrollable == null)
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
            if (scrollable == null)
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
                CreateHeaderText();
                CreateButtonText();
                CreateButton();

                CreateListBackgroundImage();
                if (null == scrollable) // scrollable used to test of ListContainer Setup invoked already
                {
                    SetUpListContainer();
                }
                button.ApplyStyle(Style.Button);
                headerText.ApplyStyle(Style.HeaderText);
                listBackgroundImage.ApplyStyle(Style.ListBackgroundImage);
            }
        }

        /// <summary>
        /// Update DropDown by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UpdateDropDown()
        {
            if (null == scrollable || null == listBackgroundImage || null == dropDownMenuFullList) return;
            if (null == Style.ListBackgroundImage.Size) return;
            // Resize and position scrolling list within the drop down list container.  Can be used to position list in relation to the background image.
            scrollable.Size = Style.ListBackgroundImage.Size - new Size((listPadding.Start + listPadding.End), (listPadding.Top + listPadding.Bottom), 0);
            scrollable.Position2D = new Position2D(listPadding.Start, listPadding.Top);

            int listBackgroundImageX = 0;
            int listBackgroundImageY = 0;
            if (listRelativeOrientation == ListOrientation.Left)
            {
                listBackgroundImageX = (int)listMargin.Start;
                listBackgroundImageY = (int)listMargin.Top;
            }
            else if (listRelativeOrientation == ListOrientation.Right)
            {
                int listWidth = 0;
                if (dropDownMenuFullList.Size2D != null)
                {
                    listWidth = dropDownMenuFullList.Size2D.Width;
                }
                listBackgroundImageX = Size2D.Width - listWidth - (int)listMargin.End;
                listBackgroundImageY = (int)listMargin.Top;
            }
            listBackgroundImage.Position2D = new Position2D(listBackgroundImageX, listBackgroundImageY);
            dropDownMenuFullList?.Layout?.RequestLayout();
        }

        protected override void OnUpdate()
        {
            float iconWidth = 0;
            float buttonTextWidth = 0;
            if (null != buttonText)
            {
                buttonText.Text = Style.Button.Text.Text.All;
                buttonText.PointSize = Style.Button.Text.PointSize?.All ?? 20;
                buttonTextWidth = buttonText.NaturalSize.Width;
            }
            iconWidth = Style.Button.Icon.Size?.Width ?? 48;
            button.SizeWidth = iconWidth + Style.SpaceBetweenButtonTextAndIcon + buttonTextWidth;

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
            UpdateSelectedItem(selectedItemIndex);
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
                Utility.Dispose(scrollable);
                Utility.Dispose(dropDownMenuFullList);
                Utility.Dispose(listBackgroundImage);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Get DropDown attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
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
            view.TouchEvent += ListItemTouchEvent;
            dropDownMenuFullList.Add(view);
        }

        private void OnClickEvent(object sender, ItemClickEventArgs e)
        {
            ItemClickEvent?.Invoke(sender, e);
        }

        private void CreateHeaderText()
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
                };
                headerText.Name = "DropDownHeaderText";
                Add(headerText);
            }
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

        private void CreateListBackgroundImage()
        {
            if (null == listBackgroundImage)
            {
                listBackgroundImage = new ImageView
                {
                    Name = "ListBackgroundImage",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    WidthResizePolicy = ResizePolicyType.FitToChildren,
                    HeightResizePolicy = ResizePolicyType.FitToChildren,
                };
                Add(listBackgroundImage);
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

            scrollable = new Scrollable()
            {
                Name = "Scrollable",
            };
            scrollable.Add(dropDownMenuFullList);

            listBackgroundImage.Add(scrollable);
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

        private void SetListItemToSelected(DropDownItemView targetItemView)
        {
            // Set the DropDownItemView matching the targetItemView to selected.
            if (selectedItemView!=targetItemView)
            {
                if (selectedItemView!=null)
                {
                    // clear selection status of currently selected item view
                    selectedItemView.IsSelected = false;
                }
                // Set target item to selected
                targetItemView.IsSelected = true;
                selectedItemView = targetItemView;
            }
        }

        private bool ListItemTouchEvent(object sender, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            DropDownItemView touchedView = sender as DropDownItemView;;
            switch (state)
            {
                case PointStateType.Down:
                    if (touchedView != null && touchedView.BackgroundColorSelector != null)
                    {
                        touchedView.BackgroundColor = touchedView.BackgroundColorSelector.GetValue(ControlStates.Pressed);
                    }
                    itemPressed = true;  // if matched with a Up then a click event.
                    break;
                case PointStateType.Motion:
                    if (touchedView != null && touchedView.BackgroundColorSelector != null)
                    {
                        touchedView.BackgroundColor = touchedView.BackgroundColorSelector.GetValue(ControlStates.Normal);
                    }
                    itemPressed = false;
                    break;
                case PointStateType.Up:
                    if (touchedView != null && touchedView.BackgroundColorSelector != null)
                    {
                        touchedView.BackgroundColor = touchedView.BackgroundColorSelector.GetValue(ControlStates.Selected);

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

        private void UpdateSelectedItem(int index)
        {
            if (null == adapter) return;
            if (null == dropDownMenuFullList) return;
            if (selectedItemIndex != -1)
            {
                DropDownDataItem data = adapter.GetData(selectedItemIndex);
                if(null != data)
                {
                    data.IsSelected = false;
                }
                DropDownItemView listItemView = dropDownMenuFullList.GetChildAt((uint)selectedItemIndex) as DropDownItemView;
                data.IsSelected = false;
                SetListItemToSelected(listItemView);
            }

            if (index != -1)
            {
                DropDownDataItem data = adapter.GetData(index);
                if (null != data)
                {
                    data.IsSelected = true;
                    DropDownItemView listItemView = dropDownMenuFullList?.GetChildAt((uint)index) as DropDownItemView;
                    if(listItemView)
                    {
                        SetListItemToSelected(listItemView);
                    }
                }
            }

            selectedItemIndex = index;
            dropDownMenuFullList?.Layout?.RequestLayout();
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
            public int Index;
            /// <summary> Clicked item text string of DropDown's list </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Text;
        }
        #endregion

        #region DropDownDataItem
        /// <summary>
        /// DropDownDataItem is a class to record all data which will be applied to DropDown item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        //[EditorBrowsable(EditorBrowsableState.Never)]
        public class DropDownDataItem
        {
            private DropDownItemStyle itemDataStyle = new DropDownItemStyle();

            /// <summary>
            /// Creates a new instance of a DropDownItemData.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownDataItem()
            {
                Initialize();
            }

            /// <summary>
            /// Creates a new instance of a DropDownItemData with style.
            /// </summary>
            /// <param name="style">Create DropDownItemData by special style defined in UX.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownDataItem(string style)
            {
                if(style != null)
                {
                    ViewStyle attributes = StyleManager.Instance.GetAttributes(style);
                    if(attributes == null)
                    {
                        throw new InvalidOperationException($"There is no style {style}");
                    }
                    itemDataStyle = attributes as DropDownItemStyle;
                }
                Initialize();
            }

            /// <summary>
            /// Creates a new instance of a DropDownItemData with style.
            /// </summary>
            /// <param name="style">Create DropDownItemData by style customized by user.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownDataItem(DropDownItemStyle style)
            {
                itemDataStyle.CopyFrom(style);
                Initialize();
            }

            /// <summary>
            /// DropDown item size.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size Size
            {
                get
                {
                    return itemDataStyle.Size;
                }
                set
                {
                    itemDataStyle.Size = value;
                }
            }

            /// <summary>
            /// DropDown item background color selector.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Selector<Color> BackgroundColorSelector
            {
                get
                {
                    return itemDataStyle.BackgroundColor;
                }
                set
                {
                    if (null == itemDataStyle?.BackgroundColor)
                    {
                        itemDataStyle.BackgroundColor = new Selector<Color>();
                    }

                    itemDataStyle.BackgroundColor.Clone(value);
                }
            }

            /// <summary>
            /// DropDown item text string.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Text
            {
                get
                {
                    return itemDataStyle.Text?.Text?.All;
                }
                set
                {
                    if (null == itemDataStyle.Text.Text)
                    {
                        itemDataStyle.Text.Text = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Text.Text = value;
                    }
                }
            }

            /// <summary>
            /// DropDown item text's point size.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float PointSize
            {
                get
                {
                    return itemDataStyle.Text?.PointSize?.All ?? 0;
                }
                set
                {
                    if (null == itemDataStyle.Text.PointSize)
                    {
                        itemDataStyle.Text.PointSize = new Selector<float?> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Text.PointSize = value;
                    }
                }
            }

            /// <summary>
            /// DropDown item text's font family.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string FontFamily
            {
                get
                {
                    return itemDataStyle.Text.FontFamily?.All;
                }
                set
                {
                    if (null == itemDataStyle.Text.FontFamily)
                    {
                        itemDataStyle.Text.FontFamily = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Text.FontFamily = value;
                    }
                }
            }

            /// <summary>
            /// DropDown item text's position.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Position TextPosition
            {
                get
                {
                    return itemDataStyle.Text?.Position;
                }
                set
                {
                    itemDataStyle.Text.Position = value;
                }
            }

            /// <summary>
            /// DropDown item's icon's resource url.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string IconResourceUrl
            {
                get
                {
                    return itemDataStyle.Icon?.ResourceUrl?.All;
                }
                set
                {
                    if (null == itemDataStyle.Icon.ResourceUrl)
                    {
                        itemDataStyle.Icon.ResourceUrl = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Icon.ResourceUrl = value;
                    }
                }
            }

            /// <summary>
            /// DropDown item's icon's size.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size IconSize
            {
                get
                {
                    return itemDataStyle.Icon?.Size;
                }
                set
                {
                    itemDataStyle.Icon.Size = value;
                }
            }

            /// <summary>
            /// DropDown item's icon's position.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Position IconPosition
            {
                get
                {
                    return itemDataStyle.Icon.Position;
                }
                set
                {
                    itemDataStyle.Icon.Position = value;
                }
            }

            /// <summary>
            /// DropDown item's check image's resource url.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string CheckImageResourceUrl
            {
                get
                {
                    return itemDataStyle.CheckImage?.ResourceUrl?.All;
                }
                set
                {
                    if (null == itemDataStyle.CheckImage.ResourceUrl)
                    {
                        itemDataStyle.CheckImage.ResourceUrl = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.CheckImage.ResourceUrl = value;
                    }
                }
            }

            /// <summary>
            /// DropDown item's check image's size.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size CheckImageSize
            {
                get
                {
                    return itemDataStyle.CheckImage?.Size;
                }
                set
                {
                    itemDataStyle.CheckImage.Size = value;
                }
            }

            /// <summary>
            /// DropDown item's check image's right space.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int CheckImageGapToBoundary
            {
                get
                {
                    return itemDataStyle.CheckImageGapToBoundary;
                }
                set
                {
                    itemDataStyle.CheckImageGapToBoundary = value;
                }
            }

            /// <summary>
            /// Flag to decide DropDown item is selected or not.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsSelected
            {
                get
                {
                    return itemDataStyle.IsSelected;
                }
                set
                {
                    itemDataStyle.IsSelected = value;
                }
            }

            private void Initialize()
            {
                if (itemDataStyle == null)
                {
                    throw new Exception("DropDownDataItem style parse error.");
                }
            }
        }
        #endregion

        #region DropDownItemView
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal class DropDownItemView : Control
        {
            private TextLabel mText = null;
            private ImageView mIcon = null;
            private ImageView mCheck = null;

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownItemView() : base() { }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Selector<Color> BackgroundColorSelector { get; set; }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Text
            {
                get
                {
                    if(mText == null)
                    {
                        return null;
                    }
                    return mText.Text;
                }
                set
                {
                    CreateText();
                    mText.Text = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string FontFamily
            {
                get
                {
                    if (mText == null)
                    {
                        return null;
                    }
                    return mText.FontFamily;
                }
                set
                {
                    CreateText();
                    mText.FontFamily = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float? PointSize
            {
                get
                {
                    if (mText == null)
                    {
                        return 0;
                    }
                    return mText.PointSize;
                }
                set
                {
                    CreateText();
                    mText.PointSize = (float)value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color TextColor
            {
                get
                {
                    if (mText == null)
                    {
                        return null;
                    }
                    return mText.TextColor;
                }
                set
                {
                    CreateText();
                    mText.TextColor = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Position TextPosition
            {
                get
                {
                    if (mText == null)
                    {
                        return null;
                    }
                    return mText.Position;
                }
                set
                {
                    CreateText();
                    mText.Position = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string IconResourceUrl
            {
                get
                {
                    if (mIcon == null)
                    {
                        return null;
                    }
                    return mIcon.ResourceUrl;
                }
                set
                {
                    CreateIcon();
                    mIcon.ResourceUrl = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size IconSize
            {
                get
                {
                    if (mIcon == null)
                    {
                        return null;
                    }
                    return mIcon.Size;
                }
                set
                {
                    CreateIcon();
                    mIcon.Size = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Position IconPosition
            {
                get
                {
                    if (mIcon == null)
                    {
                        return null;
                    }
                    return mIcon.Position;
                }
                set
                {
                    CreateIcon();
                    mIcon.Position = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string CheckResourceUrl
            {
                get
                {
                    if (mCheck == null)
                    {
                        return null;
                    }
                    return mCheck.ResourceUrl;
                }
                set
                {
                    CreateCheckImage();
                    mCheck.ResourceUrl = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Position CheckPosition
            {
                get
                {
                    if (mCheck == null)
                    {
                        return null;
                    }
                    return mCheck.Position;
                }
                set
                {
                    CreateCheckImage();
                    mCheck.Position = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size CheckImageSize
            {
                get
                {
                    if (mCheck == null)
                    {
                        return null;
                    }
                    return mCheck.Size;
                }
                set
                {
                    CreateCheckImage();
                    mCheck.Size = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsSelected
            {
                get
                {
                    if (mCheck == null)
                    {
                        return false;
                    }
                    return mCheck.Visibility;
                }
                set
                {
                    CreateCheckImage();
                    if(value)
                    {
                        mCheck.Show();
                    }
                    else
                    {
                        mCheck.Hide();
                    }
                }
            }

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
                    if (mText != null)
                    {
                        Remove(mText);
                        mText.Dispose();
                        mText = null;
                    }

                    if (mIcon != null)
                    {
                        Remove(mIcon);
                        mIcon.Dispose();
                        mIcon = null;
                    }

                    if (mCheck != null)
                    {
                        Remove(mCheck);
                        mCheck.Dispose();
                        mCheck = null;
                    }
                }
                base.Dispose(type);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override ViewStyle GetViewStyle()
            {
                return null;
            }

            private void CreateIcon()
            {
                if(mIcon == null)
                {
                    mIcon = new ImageView()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    };
                    Add(mIcon);
                }
            }

            private void CreateText()
            {
                if (mText == null)
                {
                    mText = new TextLabel()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Begin,
                    };
                    Add(mText);
                }
            }

            private void CreateCheckImage()
            {
                if (mCheck == null)
                {
                    mCheck = new ImageView()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        Name = "checkedImage",
                    };
                    Add(mCheck);
                }
                mCheck.Hide();
            }
        }
        #endregion

        #region DropDownListBridge

        /// <summary>
        /// DropDownListBridge is bridge to connect item data and an item View.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class DropDownListBridge
        {
            private List<DropDownDataItem> itemDataList = new List<DropDownDataItem>();

            internal bool AdapterPurge {get;set;} = false;  // Set to true if adapter content changed since last iteration.

            /// <summary>
            /// Creates a new instance of a DropDownListBridge.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownListBridge() { }

            /// <summary>
            /// Insert data. The inserted data will be added to the special position by index automatically.
            /// </summary>
            /// <param name="position">Position index where will be inserted.</param>
            /// <param name="data">Item data which will apply to tab item view.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void InsertData(int position, DropDownDataItem data)
            {
                if(position == -1)
                {
                    position = itemDataList.Count;
                }
                itemDataList.Insert(position, data);
                AdapterPurge = true;
            }

            /// <summary>
            /// Remove data by position.
            /// </summary>
            /// <param name="position">Position index where will be removed.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RemoveData(int position)
            {
                itemDataList.RemoveAt(position);
                AdapterPurge = true;
            }

            /// <summary>
            /// Get data by position.
            /// </summary>
            /// <param name="position">Position index where will be gotten.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownDataItem GetData(int position)
            {
                return itemDataList[position];
            }

            /// <summary>
            /// Get view holder by view type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder OnCreateViewHolder()
            {
                ViewHolder viewHolder = new ViewHolder(new DropDownItemView());

                return viewHolder;
            }

            /// <summary>
            /// Bind ViewHolder with View.
            /// </summary>
            /// <param name="holder">View holder.</param>
            /// <param name="position">Position index of source data.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void BindViewHolder(ViewHolder holder, int position)
            {
                DropDownDataItem listItemData = itemDataList[position];
                if(listItemData == null)
                {
                    return;
                }
                DropDownItemView listItemView = holder.ItemView as DropDownItemView;
                listItemView.Name = "Item" + position;
                if (listItemData.Size != null)
                {
                    if (listItemData.Size.Width > 0)
                    {
                        holder.ItemView.WidthSpecification = (int)listItemData.Size.Width;
                    }
                    else
                    {
                        holder.ItemView.WidthSpecification = LayoutParamPolicies.MatchParent;
                    }

                    if (listItemData.Size.Height > 0)
                    {
                        holder.ItemView.HeightSpecification = (int)listItemData.Size.Height;
                    }
                    else
                    {
                        holder.ItemView.HeightSpecification = LayoutParamPolicies.MatchParent;
                    }
                }

                if (listItemView != null)
                {
                    listItemView.BackgroundColorSelector = listItemData.BackgroundColorSelector;
                    if (listItemData.Text != null)
                    {
                        listItemView.Text = listItemData.Text;
                        listItemView.PointSize = listItemData.PointSize;
                        listItemView.FontFamily = listItemData.FontFamily;
                        listItemView.TextPosition = listItemData.TextPosition;
                    }

                    if (listItemData.IconResourceUrl != null)
                    {
                        listItemView.IconResourceUrl = listItemData.IconResourceUrl;
                        listItemView.IconSize = listItemData.IconSize;
                        if (listItemView.IconSize != null)
                        {
                            listItemView.IconPosition = new Position(listItemData.IconPosition.X, (listItemView.Size2D.Height - listItemView.IconSize.Height) / 2);
                        }
                    }

                    if (listItemData.CheckImageResourceUrl != null)
                    {
                        listItemView.CheckResourceUrl = listItemData.CheckImageResourceUrl;
                        listItemView.CheckImageSize = listItemData.CheckImageSize;
                        if (listItemView.CheckImageSize != null)
                        {
                            listItemView.CheckPosition = new Position(listItemView.Size2D.Width - listItemData.CheckImageGapToBoundary - listItemView.CheckImageSize.Width, (listItemView.Size2D.Height - listItemView.CheckImageSize.Height) / 2);
                        }
                    }

                    listItemView.IsSelected = listItemData.IsSelected;
                }
            }

            /// <summary>
            /// Destroy view holder, it can be override.
            /// </summary>
            /// <param name="holder">View holder.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void OnDestroyViewHolder(ViewHolder holder)
            {
                if (holder.ItemView != null)
                {
                    holder.ItemView.Dispose();
                }
            }

            /// <summary>
            /// Get item count, it can be override.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetItemCount()
            {
                return itemDataList.Count;
            }
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
                if (itemView == null)
                {
                    throw new ArgumentNullException("itemView may not be null");
                }
                this.ItemView = itemView;
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
