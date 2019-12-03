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
        public static readonly BindableProperty ListPaddingProperty = BindableProperty.Create("ListPadding", typeof(Extents), typeof(Tizen.NUI.Components.DropDown), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            if (newValue != null)
            {
                instance.privateListPadding = (Extents)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            return instance.privateListPadding;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListSizeProperty = BindableProperty.Create("ListSize", typeof(Size), typeof(Tizen.NUI.Components.DropDown), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            if (newValue != null)
            {
                instance.privateListSize = (Size)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            return instance.privateListSize;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedItemIndexProperty = BindableProperty.Create("SelectedItemIndex", typeof(int), typeof(Tizen.NUI.Components.DropDown), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            if (newValue != null)
            {
                instance.privateSelectedItemIndex = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            return instance.privateSelectedItemIndex;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusedItemIndexProperty = BindableProperty.Create("FocusedItemIndex", typeof(int), typeof(Tizen.NUI.Components.DropDown), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            if (newValue != null)
            {
                instance.privateFocusedItemIndex = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            return instance.privateFocusedItemIndex;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListMarginProperty = BindableProperty.Create("ListMargin", typeof(Extents), typeof(Tizen.NUI.Components.DropDown), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            if (newValue != null)
            {
                instance.privateListMargin = (Extents)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            return instance.privateListMargin;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListRelativeOrientationProperty = BindableProperty.Create("ListRelativeOrientation", typeof(ListOrientation), typeof(Tizen.NUI.Components.DropDown), ListOrientation.Left, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            if (newValue != null)
            {
                instance.privateListRelativeOrientation = (ListOrientation)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            return instance.privateListRelativeOrientation;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceProperty = BindableProperty.Create("Space", typeof(Extents), typeof(Tizen.NUI.Components.DropDown), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            if (newValue != null)
            {
                instance.privateSpace = (Extents)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            return instance.privateSpace;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceBetweenButtonTextAndIconProperty = BindableProperty.Create("SpaceBetweenButtonTextAndIcon", typeof(int), typeof(Tizen.NUI.Components.DropDown), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            if (newValue != null)
            {
                instance.privateSpaceBetweenButtonTextAndIcon = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.DropDown)bindable;
            return instance.privateSpaceBetweenButtonTextAndIcon;
        });


        #region DropDown
        private Button button = null;
        private TextLabel headerText = null;
        private TextLabel buttonText = null;
        private ImageView listBackgroundImage = null;
        private FlexibleView list = null;
        private DropDownListBridge adapter = new DropDownListBridge();
        private DropDownItemView touchedView = null;
        private int selectedItemIndex = -1;

        private Extents listPadding = null;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new DropDownStyle Style => ViewStyle as DropDownStyle;

        /// <summary>
        /// Creates a new instance of a DropDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDown() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a DropDown with style.
        /// </summary>
        /// <param name="style">Create DropDown by special style defined in UX.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDown(string style) : base(style)
        {
        }

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
        /// List orientation.
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
        /// Space between button text and button icon in DropDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public int SpaceBetweenButtonTextAndIcon
        {
            get
            {
                return (int)GetValue(SpaceBetweenButtonTextAndIconProperty);
            }
            set
            {
                SetValue(SpaceBetweenButtonTextAndIconProperty, value);
            }
        }
        private int privateSpaceBetweenButtonTextAndIcon
        {
            get
            {
                return (int)Style.SpaceBetweenButtonTextAndIcon;
            }
            set
            {
                Style.SpaceBetweenButtonTextAndIcon = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Left space in DropDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public Extents Space
        {
            get
            {
                return (Extents)GetValue(SpaceProperty);
            }
            set
            {
                SetValue(SpaceProperty, value);
            }
        }
        private Extents privateSpace
        {
            get
            {
                return (Extents)Style.Space;
            }
            set
            {
                Style.Space = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// List relative orientation in DropDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ListOrientation ListRelativeOrientation
        {
            get
            {
                return (ListOrientation)GetValue(ListRelativeOrientationProperty);
            }
            set
            {
                SetValue(ListRelativeOrientationProperty, value);
            }
        }
        private ListOrientation privateListRelativeOrientation
        {
            get
            {
                return (ListOrientation)Style.ListRelativeOrientation;
            }
            set
            {
                Style.ListRelativeOrientation = value;
                RelayoutRequest();
            }
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
                return (Extents)GetValue(ListMarginProperty);
            }
            set
            {
                SetValue(ListMarginProperty, value);
            }
        }
        private Extents privateListMargin
        {
            get
            {
                return Style.ListMargin;
            }
            set
            {
                Style.ListMargin = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Focused item index in list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public int FocusedItemIndex
        {
            get
            {
                return (int)GetValue(FocusedItemIndexProperty);
            }
            set
            {
                SetValue(FocusedItemIndexProperty, value);
            }
        }
        private int privateFocusedItemIndex
        {
            get
            {
                return (int)Style.FocusedItemIndex;
            }
            set
            {
                Style.FocusedItemIndex = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Selected item index in list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public int SelectedItemIndex
        {
            get
            {
                return (int)GetValue(SelectedItemIndexProperty);
            }
            set
            {
                SetValue(SelectedItemIndexProperty, value);
            }
        }
        private int privateSelectedItemIndex
        {
            get
            {
                return selectedItemIndex;
            }
            set
            {
                if (value == selectedItemIndex || adapter == null || value >= adapter.GetItemCount())
                {
                    return;
                }
                UpdateSelectedItem(value);
            }
        }

        /// <summary>
        /// List size in DropDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public Size ListSize
        {
            get
            {
                return (Size)GetValue(ListSizeProperty);
            }
            set
            {
                SetValue(ListSizeProperty, value);
            }
        }
        private Size privateListSize
        {
            get
            {
                return Style.ListSize;
            }
            set
            {
                Style.ListSize = value;
                RelayoutRequest();
            }
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
                return (Extents)GetValue(ListPaddingProperty);
            }
            set
            {
                SetValue(ListPaddingProperty, value);
            }
        }
        private Extents privateListPadding
        {
            get
            {
                return listPadding;
            }
            set
            {
                Style.ListPadding.CopyFrom(value);

                if (null == listPadding)
                {
                    listPadding = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
                        Style.ListPadding.Start = start;
                        Style.ListPadding.End = end;
                        Style.ListPadding.Top = top;
                        Style.ListPadding.Bottom = bottom;
                        RelayoutRequest();
                    }, value.Start, value.End, value.Top, value.Bottom);
                }
                else
                {
                    listPadding.CopyFrom(value);
                }

                RelayoutRequest();
            }
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
            adapter.InsertData(-1, itemData);
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
            if(index < 0 || index >= adapter.GetItemCount())
            {
                return;
            }

            if (selectedItemIndex == index)
            {
                selectedItemIndex = -1;
            }
            else if(selectedItemIndex > index)
            {
                selectedItemIndex--;
            }

            adapter.RemoveData(index);
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
            if (list == null)
            {
                return;
            }
            list.AttachScrollBar(scrollBar);
        }

        /// <summary>
        /// Detach scroll bar to list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DetachScrollBar()
        {
            if (list == null)
            {
                return;
            }
            list.DetachScrollBar();
        }

        protected override void RegisterDetectionOfSubstyleChanges()
        {
            base.RegisterDetectionOfSubstyleChanges();

            Style.PropertyChanged += DropDownAttributesPropertyChanged;
            Style.HeaderText.PropertyChanged += HeaderTextAttributesPropertyChanged;
            Style.Button.PropertyChanged += ButtonAttributesPropertyChanged;

            Style.Button.Icon.PropertyChanged += IconStylePropertyChanged;
        }

        private void IconStylePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            int iconWidth = 0;
            int buttonTextWidth = 0;
            if (e.PropertyName.Equals(ImageViewStyle.SizeProperty.PropertyName))
            {
                iconWidth = (int)Style.Button.Icon.Size.Width;
            }

            if (buttonText.NaturalSize2D != null)
            {
                buttonTextWidth = buttonText.NaturalSize2D.Width;
            }

            button.SizeWidth = iconWidth + (int)Style.SpaceBetweenButtonTextAndIcon + buttonTextWidth;
        }

        private void DropDownAttributesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Space"))
            {
                button.Position2D.X = (int)Style.Space.Start;
            }
        }

        private void ButtonAttributesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (null == button)
            {
                button = new Button()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    IconRelativeOrientation = Components.Button.IconOrientation.Right,
                };
                button.Name = "DropDownButton";
                button.ClickEvent += ButtonClickEvent;
                Add(button);

                button.ApplyStyle(Style.Button);
            }

            if (null == buttonText)
            {
                buttonText = new TextLabel()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                };
                buttonText.Name = "DropDownButtonText";
                Add(buttonText);
                buttonText.Hide();
            }
        }

        private void HeaderTextAttributesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (null == headerText)
            {
                headerText = new TextLabel();
                headerText.Name = "DropDownHeaderText";
                Add(headerText);

                headerText.ApplyStyle(Style.HeaderText);
            }
        }

        /// <summary>
        /// Update DropDown by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            if (Style.ListBackgroundImage != null)
            {
                if (listBackgroundImage == null)
                {
                    CreateListBackgroundImage();
                    CreateList();
                }

                int temp = (int)Style.FocusedItemIndex;
                list.FocusedItemIndex = temp;
                list.Size = Style.ListSize;
                list.Padding = Style.ListPadding;

                int listBackgroundImageX = 0;
                int listBackgroundImageY = 0;
                if (Style.ListRelativeOrientation == ListOrientation.Left)
                {
                    if (Style.ListMargin != null)
                    {
                        listBackgroundImageX = (int)Style.ListMargin.Start;
                        listBackgroundImageY = (int)Style.ListMargin.Top;
                    }
                }
                else if (Style.ListRelativeOrientation == ListOrientation.Right)
                {
                    if (Style.ListMargin != null)
                    {
                        int listWidth = 0;
                        if (list.Size2D != null)
                        {
                            listWidth = list.Size2D.Width;
                        }
                        listBackgroundImageX = Size2D.Width - listWidth - (int)Style.ListMargin.End;
                        listBackgroundImageY = (int)Style.ListMargin.Top;
                    }
                }
                listBackgroundImage.Position2D = new Position2D(listBackgroundImageX, listBackgroundImageY);
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
                if (headerText != null)
                {
                    Utility.Dispose(headerText);
                }

                if (buttonText != null)
                {
                    Utility.Dispose(buttonText);
                }

                if (button != null)
                {
                    Utility.Dispose(button);
                }

                if (list != null)
                {
                    if (listBackgroundImage != null)
                    {
                        Utility.Dispose(listBackgroundImage);
                    }

                    Utility.Dispose(list);
                }
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

        private void OnClickEvent(object sender, ItemClickEventArgs e)
        {
            ItemClickEvent?.Invoke(sender, e);
        }

        private void CreateList()
        {
            list = new FlexibleView();
            list.Name = "DropDownList";
            LinearLayoutManager layoutManager = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
            list.SetLayoutManager(layoutManager);
            list.SetAdapter(adapter);
            list.Focusable = true;
            list.ItemTouchEvent += ListItemTouchEvent;
            list.ItemClickEvent += ListItemClickEvent;
            listBackgroundImage.Add(list);
            listBackgroundImage.Hide();
        }

        private void ListItemClickEvent(object sender, FlexibleView.ItemClickEventArgs e)
        {
            if (e.ClickedView != null)
            {
                UpdateSelectedItem(e.ClickedView.AdapterPosition);

                ItemClickEventArgs args = new ItemClickEventArgs();
                args.Index = e.ClickedView.AdapterPosition;
                args.Text = (e.ClickedView.ItemView as DropDownItemView)?.Text;
                OnClickEvent(this, args);
            }

            listBackgroundImage.Hide();
        }

        private void ListItemTouchEvent(object sender, FlexibleView.ItemTouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            switch (state)
            {
                case PointStateType.Down:
                    if (e.TouchedView != null)
                    {
                        touchedView = e.TouchedView.ItemView as DropDownItemView;
                        if (touchedView != null && touchedView.BackgroundColorSelector != null)
                        {
                            touchedView.BackgroundColor = touchedView.BackgroundColorSelector.GetValue(ControlStates.Pressed);
                        }
                    }
                    break;
                case PointStateType.Motion:
                    if (touchedView != null && touchedView.BackgroundColorSelector != null)
                    {
                        touchedView.BackgroundColor = touchedView.BackgroundColorSelector.GetValue(ControlStates.Normal);
                    }
                    break;
                case PointStateType.Up:
                    if (touchedView != null && touchedView.BackgroundColorSelector != null)
                    {
                        touchedView.BackgroundColor = touchedView.BackgroundColorSelector.GetValue(ControlStates.Selected);
                    }
                    break;
                default:
                    break;
            }
        }      

        private void UpdateSelectedItem(int index)
        {
            if (selectedItemIndex != -1)
            {
                DropDownDataItem data = adapter.GetData(selectedItemIndex);
                if(data != null)
                {
                    data.IsSelected = false;
                }
                DropDownItemView view = list?.FindViewHolderForAdapterPosition(selectedItemIndex)?.ItemView as DropDownItemView;
                if (view != null)
                {
                    view.IsSelected = false;
                }
            }

            if (index != -1)
            {
                DropDownDataItem data = adapter.GetData(index);
                if (data != null)
                {
                    data.IsSelected = true;
                }
                DropDownItemView view = list?.FindViewHolderForAdapterPosition(index)?.ItemView as DropDownItemView;
                if (view != null)
                {
                    view.IsSelected = true;
                    button.Style.Text.Text = view.Text;
                }
            }

            selectedItemIndex = index;
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

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            listBackgroundImage.Show();
        }

        private void CreateHeaderTextAttributes()
        {
            if (Style.HeaderText == null)
            {
                Style.HeaderText = new TextLabelStyle()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
            }
        }

        private void CreateButtonAttributes()
        {
            if (Style.Button == null)
            {
                Style.Button = new ButtonStyle();
            }
        }

        private void CreateButtonTextAttributes()
        {
            CreateButtonAttributes();

            if (Style.Button.Text== null)
            {
                Style.Button.Text= new TextLabelStyle
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    Position = new Position(0, 0),
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                };
            }
        }

        private void CreateButtonIconAttributes()
        {
            CreateButtonAttributes();

            if (Style.Button.Icon== null)
            {
                Style.Button.Icon= new ImageViewStyle
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                };
            }
        }

        private void CreateListBackgroundAttributes()
        {
            if (Style.ListBackgroundImage == null)
            {
                Style.ListBackgroundImage = new ImageViewStyle
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
            }
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
                Initalize();
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
                Initalize();
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
                Initalize();
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
                    if (itemDataStyle.BackgroundColor == null)
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
                    CreateTextAttributes();
                    if (itemDataStyle.Text.Text == null)
                    {
                        itemDataStyle.Text.Text = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Text.Text.All = value;
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
                    CreateTextAttributes();
                    if (itemDataStyle.Text.PointSize == null)
                    {
                        itemDataStyle.Text.PointSize = new Selector<float?> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Text.PointSize.All = value;
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
                    return "";
                    //return itemDataAttributes.TextAttributes?.FontFamily?.GetValue(State);
                }
                set
                {
                    CreateTextAttributes();
                    itemDataStyle.Text.FontFamily = value;
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
                    CreateTextAttributes();
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
                    CreateIconAttributes();
                    if (itemDataStyle.Icon.ResourceUrl == null)
                    {
                        itemDataStyle.Icon.ResourceUrl = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Icon.ResourceUrl.All = value;
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
                    CreateIconAttributes();
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
                    CreateIconAttributes();
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
                    CreateCheckImageAttributes();
                    if (itemDataStyle.CheckImage.ResourceUrl == null)
                    {
                        itemDataStyle.CheckImage.ResourceUrl = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.CheckImage.ResourceUrl.All = value;
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
                    CreateCheckImageAttributes();
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

            private void Initalize()
            {
                if (itemDataStyle == null)
                {
                    throw new Exception("Button attribute parse error.");
                }
            }

            private void CreateTextAttributes()
            {
                if(itemDataStyle.Text== null)
                {
                    itemDataStyle.Text= new TextLabelStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Begin,
                    };
                }
            }

            private void CreateIconAttributes()
            {
                if (itemDataStyle.Icon== null)
                {
                    itemDataStyle.Icon= new ImageViewStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    };
                }
            }

            private void CreateCheckImageAttributes()
            {
                if (itemDataStyle.CheckImage== null)
                {
                    itemDataStyle.CheckImage= new ImageViewStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    };
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
            public DropDownItemView() : base()
            {
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Selector<Color> BackgroundColorSelector
            {
                get;
                set;
            }

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
                    };
                    Add(mCheck);
                }
                mCheck.Hide();
            }
        }
        #endregion

        #region DropDownListBridge

        /// <summary>
        /// DropDownListBridge is bridge to contact item data and item view.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class DropDownListBridge : FlexibleView.Adapter
        {
            private List<DropDownDataItem> mDatas = new List<DropDownDataItem>();

            /// <summary>
            /// Creates a new instance of a DropDownListBridge.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownListBridge()
            {
            }

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
                    position = mDatas.Count;
                }
                mDatas.Insert(position, data);
                NotifyItemInserted(position);
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
                mDatas.RemoveAt(position);
                NotifyItemRemoved(position);
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
                return mDatas[position];
            }

            /// <summary>
            /// Get view holder by view type.
            /// </summary>
            /// <param name="viewType">Create item view.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override FlexibleView.ViewHolder OnCreateViewHolder(int viewType)
            {
                FlexibleView.ViewHolder viewHolder = new FlexibleView.ViewHolder(new DropDownItemView());

                return viewHolder;
            }

            /// <summary>
            /// Binder view holder, it can be override.
            /// </summary>
            /// <param name="holder">View holder.</param>
            /// <param name="position">Position index where will be gotten.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override void OnBindViewHolder(FlexibleView.ViewHolder holder, int position)
            {
                DropDownDataItem listItemData = mDatas[position];
                if(listItemData == null)
                {
                    return;
                }
                DropDownItemView listItemView = holder.ItemView as DropDownItemView;
                listItemView.Name = "Item" + position;
                if (listItemData.Size != null)
                {
                    holder.ItemView.Size = listItemData.Size;
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
            public override void OnDestroyViewHolder(FlexibleView.ViewHolder holder)
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
            public override int GetItemCount()
            {
                return mDatas.Count;
            }        
        }
        #endregion
    }
}
