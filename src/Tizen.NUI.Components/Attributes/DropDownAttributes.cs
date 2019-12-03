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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using static Tizen.NUI.Components.DropDown;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// DropDownStyle is a class which saves DropDown's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DropDownStyle : ControlStyle
    {
        private int spaceBetweenButtonTextAndIcon = 0;

        private Extents _space;
        private Extents space
        {
            get
            {
                if (null == _space)
                {
                    _space = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
                        Extents extents = new Extents(start, end, top, bottom);
                        _space.CopyFrom(extents);
                    }, 0, 0, 0, 0);
                }

                return _space;
            }
        }

        private ListOrientation? listRelativeOrientation = ListOrientation.Left;

        private bool isListMarginSetted = false;
        private Extents _listMargin;
        private Extents listMargin
        {
            get
            {
                if (null == _listMargin)
                {
                    _listMargin = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
                        Extents extents = new Extents(start, end, top, bottom);
                        _listMargin.CopyFrom(extents);
                    }, 0, 0, 0, 0);
                }

                return _listMargin;
            }
        }

        private int focusedItemIndex = 0;
        private int selectedItemIndex = 0;
        private Size listSize;

        private Extents _listPadding;
        private Extents listPadding
        {
            get
            {
                if (null == _listPadding)
                {
                    _listPadding = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
                        Extents extents = new Extents(start, end, top, bottom);
                        _listPadding.CopyFrom(extents);
                    }, 0, 0, 0, 0);
                }

                return _listPadding;
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceBetweenButtonTextAndIconProperty = BindableProperty.Create("SpaceBetweenButtonTextAndIcon", typeof(int), typeof(DropDownStyle), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            dropDownStyle.spaceBetweenButtonTextAndIcon = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            return dropDownStyle.spaceBetweenButtonTextAndIcon;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceProperty = BindableProperty.Create("Space", typeof(Extents), typeof(DropDownStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            dropDownStyle.space.CopyFrom((Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            return dropDownStyle.space;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListRelativeOrientationProperty = BindableProperty.Create("ListRelativeOrientation", typeof(ListOrientation?), typeof(DropDownStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            dropDownStyle.listRelativeOrientation = (ListOrientation?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            return dropDownStyle.listRelativeOrientation;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListMarginProperty = BindableProperty.Create("ListMargin", typeof(Extents), typeof(DropDownStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            dropDownStyle.listMargin.CopyFrom((Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            return dropDownStyle.listMargin;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusedItemIndexProperty = BindableProperty.Create("FocusedItemIndex", typeof(int), typeof(DropDownStyle), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            dropDownStyle.focusedItemIndex = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            return dropDownStyle.focusedItemIndex;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedItemIndexProperty = BindableProperty.Create("SelectedItemIndex", typeof(int), typeof(DropDownStyle), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            dropDownStyle.selectedItemIndex = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            return dropDownStyle.selectedItemIndex;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListSizeProperty = BindableProperty.Create("ListSize", typeof(Size), typeof(DropDownStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            dropDownStyle.listSize = (Size)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            return dropDownStyle.listSize;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ListPaddingProperty = BindableProperty.Create("ListPadding", typeof(Extents), typeof(DropDownStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            dropDownStyle.listPadding.CopyFrom((Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            return dropDownStyle.listPadding;
        });

        /// <summary>
        /// Creates a new instance of a DropDownStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownStyle() : base()
        {
            Button = new ButtonStyle();
            HeaderText = new TextLabelStyle();
            ListBackgroundImage = new ImageViewStyle();
        }
        /// <summary>
        /// Creates a new instance of a DropDownStyle with style.
        /// </summary>
        /// <param name="style">Create DropDownStyle by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownStyle(DropDownStyle style) : base(style)
        {
            if(style == null)
            {
                return;
            }

            Button = new ButtonStyle();
            HeaderText = new TextLabelStyle();
            ListBackgroundImage = new ImageViewStyle();

            CopyFrom(style);
        }

        /// <summary>
        /// DropDown button's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ButtonStyle Button
        {
            get;
            set;
        }

        /// <summary>
        /// Header text's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle HeaderText
        {
            get;
            set;
        }

        /// <summary>
        /// List background image's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle ListBackgroundImage
        {
            get;
            set;
        }

        /// <summary>
        /// Space between button text and button icon.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SpaceBetweenButtonTextAndIcon
        {
            get
            {
                int temp = (int)GetValue(SpaceBetweenButtonTextAndIconProperty);
                return temp;
            }
            set
            {
                SetValue(SpaceBetweenButtonTextAndIconProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents Space
        {
            get
            {
                Extents temp = (Extents)GetValue(SpaceProperty);
                return temp;
            }
            set
            {
                SetValue(SpaceProperty, value);
            }
        }

        /// <summary>
        /// List relative orientation.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListOrientation? ListRelativeOrientation
        {
            get
            {
                ListOrientation? temp = (ListOrientation?)GetValue(ListRelativeOrientationProperty);
                return temp;
            }
            set
            {
                SetValue(ListRelativeOrientationProperty, value);
            }
        }

        /// <summary>
        /// List margin.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ListMargin
        {
            get
            {
                Extents temp = (Extents)GetValue(ListMarginProperty);
                return temp;
            }
            set
            {
                SetValue(ListMarginProperty, value);
            }
        }

        /// <summary>
        /// Focused item index.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FocusedItemIndex
        {
            get
            {
                int temp = (int)GetValue(FocusedItemIndexProperty);
                return temp;
            }
            set
            {
                SetValue(FocusedItemIndexProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectedItemIndex
        {
            get
            {
                int temp = (int)GetValue(SelectedItemIndexProperty);
                return temp;
            }
            set
            {
                SetValue(SelectedItemIndexProperty, value);
            }
        }

        /// <summary>
        /// List size.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ListSize
        {
            get
            {
                Size temp = (Size)GetValue(ListSizeProperty);
                return temp;
            }
            set
            {
                SetValue(ListSizeProperty, value);
            }
        }

        /// <summary>
        /// List padding.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ListPadding
        {
            get
            {
                Extents temp = (Extents)GetValue(ListPaddingProperty);
                return temp;
            }
            set
            {
                SetValue(ListPaddingProperty, value);
            }
        }

        /// <summary>
        /// Icon's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Icon
        {
            get;
            set;
        }

        /// <summary>
        /// Check image's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle CheckImage
        {
            get;
            set;
        }

        /// <summary>
        /// Gap of Check image to boundary.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CheckImageGapToBoundary
        {
            get;
            set;
        }

        /// <summary>
        /// Flag to decide item is selected or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSelected
        {
            get;
            set;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            DropDownStyle dropDownStyle = bindableObject as DropDownStyle;

            if (null != dropDownStyle)
            {
                Button.CopyFrom(dropDownStyle.Button);
                HeaderText.CopyFrom(dropDownStyle.HeaderText);
                ListBackgroundImage.CopyFrom(dropDownStyle.ListBackgroundImage);
            }
        }
    }

    /// <summary>
    /// DropDownItemStyle is a class which saves DropDownItem's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DropDownItemStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a DropDownItemStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownItemStyle() : base() { }
        /// <summary>
        /// Creates a new instance of a DropDownItemStyle with style.
        /// </summary>
        /// <param name="style">Create DropDownItemStyle by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownItemStyle(DropDownItemStyle style) : base(style)
        {
            if (style.Text!= null)
            {
                Text.CopyFrom(style.Text);
            }

            if (style.Icon!= null)
            {
                Icon.CopyFrom(style.Icon);
            }

            if (style.CheckImage!= null)
            {
                CheckImage.CopyFrom(style.CheckImage);
            }

            CheckImageGapToBoundary = style.CheckImageGapToBoundary;
            IsSelected = style.IsSelected;
        }

        /// <summary>
        /// Text's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle Text
        {
            get;
            set;
        }

        /// <summary>
        /// Icon's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Icon
        {
            get;
            set;
        }

        /// <summary>
        /// Check image's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle CheckImage
        {
            get;
            set;
        }

        /// <summary>
        /// Gap of Check image to boundary.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CheckImageGapToBoundary
        {
            get;
            set;
        }

        /// <summary>
        /// Flag to decide item is selected or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSelected
        {
            get;
            set;
        }
    }
}
