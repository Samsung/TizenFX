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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceBetweenButtonTextAndIconProperty = BindableProperty.Create(nameof(SpaceBetweenButtonTextAndIcon), typeof(int), typeof(DropDownStyle), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ListRelativeOrientationProperty = BindableProperty.Create(nameof(ListRelativeOrientation), typeof(ListOrientation?), typeof(DropDownStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ListMarginProperty = BindableProperty.Create(nameof(ListMargin), typeof(Extents), typeof(DropDownStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((DropDownStyle)bindable).listMargin = newValue == null ? null : new Extents((Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            return dropDownStyle.listMargin;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedItemIndexProperty = BindableProperty.Create(nameof(SelectedItemIndex), typeof(int), typeof(DropDownStyle), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ListPaddingProperty = BindableProperty.Create(nameof(ListPadding), typeof(Extents), typeof(DropDownStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((DropDownStyle)bindable).listPadding = newValue == null ? null : new Extents((Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var dropDownStyle = (DropDownStyle)bindable;
            return dropDownStyle.listPadding;
        });

        private Extents listMargin;
        private Extents listPadding;
        private int spaceBetweenButtonTextAndIcon = 0;
        private ListOrientation? listRelativeOrientation = ListOrientation.Left;
        private int selectedItemIndex = 0;

        static DropDownStyle() { }

        /// <summary>
        /// Creates a new instance of a DropDownStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a DropDownStyle with style.
        /// </summary>
        /// <param name="style">Create DropDownStyle by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownStyle(DropDownStyle style) : base(style)
        {
        }

        /// <summary>
        /// DropDown button's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ButtonStyle Button { get; set; } = new ButtonStyle();

        /// <summary>
        /// Header text's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle HeaderText { get; set; } = new TextLabelStyle();

        /// <summary>
        /// List background image's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle ListBackgroundImage { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Space between button text and button icon.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SpaceBetweenButtonTextAndIcon
        {
            get => (int)GetValue(SpaceBetweenButtonTextAndIconProperty);
            set => SetValue(SpaceBetweenButtonTextAndIconProperty, value);
        }

        /// <summary>
        /// List relative orientation.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListOrientation? ListRelativeOrientation
        {
            get => (ListOrientation?)GetValue(ListRelativeOrientationProperty);
            set => SetValue(ListRelativeOrientationProperty, value);
        }

        /// <summary>
        /// List margin.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ListMargin
        {
            get => (Extents)GetValue(ListMarginProperty);
            set => SetValue(ListMarginProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectedItemIndex
        {
            get => (int)GetValue(SelectedItemIndexProperty);
            set => SetValue(SelectedItemIndexProperty, value);
        }

        /// <summary>
        /// List padding.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ListPadding
        {
            get => (Extents)GetValue(ListPaddingProperty);
            set => SetValue(ListPaddingProperty, value);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is DropDownStyle dropDownStyle)
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
        }

        /// <summary>
        /// Text's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle Text { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Icon's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Icon { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Check image's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle CheckImage { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Gap of Check image to boundary.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CheckImageGapToBoundary { get; set; }

        /// <summary>
        /// Flag to decide item is selected or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSelected { get; set; }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is DropDownItemStyle dropDownItemStyle)
            {
                Text.CopyFrom(dropDownItemStyle.Text);
                Icon.CopyFrom(dropDownItemStyle.Icon);
                CheckImage.CopyFrom(dropDownItemStyle.CheckImage);
                CheckImageGapToBoundary = dropDownItemStyle.CheckImageGapToBoundary;
                IsSelected = dropDownItemStyle.IsSelected;
            }
        }
    }
}
