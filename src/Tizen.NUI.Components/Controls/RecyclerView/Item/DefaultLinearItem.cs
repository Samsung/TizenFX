/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Accessibility;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// DefaultLinearItem is one kind of common component, a DefaultLinearItem clearly describes what action will occur when the user selects it.
    /// DefaultLinearItem may contain text or an icon.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DefaultLinearItem : RecyclerViewItem
    {
        private View itemIcon;
        private TextLabel itemLabel;
        private TextLabel itemSubLabel;
        private View itemExtra;
        private View itemSeperator;
        private bool layoutChanged;
        private Size prevSize;
        private DefaultLinearItemStyle ItemStyle => ViewStyle as DefaultLinearItemStyle;

        static DefaultLinearItem()
        {
            if (NUIApplication.IsUsingXaml)
            {
                IconProperty = BindableProperty.Create(nameof(Icon), typeof(View), typeof(DefaultLinearItem), null,
                    propertyChanged: SetInternalIconProperty, defaultValueCreator: GetInternalIconProperty);
                TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(DefaultLinearItem), default(string),
                    propertyChanged: SetInternalTextProperty, defaultValueCreator: GetInternalTextProperty);
                SubTextProperty = BindableProperty.Create(nameof(SubText), typeof(string), typeof(DefaultLinearItem), default(string),
                    propertyChanged: SetInternalSubTextProperty, defaultValueCreator: GetInternalSubTextProperty);
                ExtraProperty = BindableProperty.Create(nameof(Extra), typeof(View), typeof(DefaultLinearItem), null,
                    propertyChanged: SetInternalExtraProperty, defaultValueCreator: GetInternalExtraProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of DefaultLinearItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultLinearItem() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a DefaultLinearItem with style.
        /// </summary>
        /// <param name="style">Create DefaultLinearItem by style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultLinearItem(string style) : base(style)
        {
        }

        /// <summary>
        /// Creates a new instance of a DefaultLinearItem with style.
        /// </summary>
        /// <param name="itemStyle">Create DefaultLinearItem by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultLinearItem(DefaultLinearItemStyle itemStyle) : base(itemStyle)
        {
        }

        /// <summary>
        /// Icon part of DefaultLinearItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Icon
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(IconProperty) as View;
                }
                else
                {
                    return InternalIcon;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IconProperty, value);
                }
                else
                {
                    InternalIcon = value;
                }
                NotifyPropertyChanged();
            }
        }
        private View InternalIcon
        {
            get
            {
                if (itemIcon == null)
                {
                    itemIcon = CreateIcon(ItemStyle?.Icon);
                    if (itemIcon != null)
                    {
                        Add(itemIcon);
                        itemIcon.Relayout += OnIconRelayout;
                        layoutChanged = true;
                        LayoutChild();
                    }
                }
                return itemIcon;
            }
            set
            {
                if (itemIcon != null) Remove(itemIcon);
                itemIcon = value;
                if (itemIcon != null)
                {
                    //FIXME: User applied icon's style can be overwritten!
                    if (ItemStyle != null) itemIcon.ApplyStyle(ItemStyle.Icon);
                    Add(itemIcon);
                    itemIcon.Relayout += OnIconRelayout;
                }
                layoutChanged = true;
                LayoutChild();
            }
        }

        /* open when imageView using Uri not string.
        /// <summary>
        /// Icon image's resource url. Only activatable for icon as ImageView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IconUrl
        {
            get
            {
                return (Icon as ImageView)?.ResourceUrl;
            }
            set
            {
                if (itemIcon != null && !(itemIcon is ImageView))
                {
                    // Tizen.Log.Error("IconUrl only can set Icon is ImageView");
                    return;
                }
                (Icon as ImageView).ResourceUrl = value;
            }
        }
        */

        /// <summary>
        /// DefaultLinearItem's text part of DefaultLinearItem
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel Label
        {
            get
            {
                if (itemLabel == null)
                {
                    itemLabel = CreateLabel(ItemStyle?.Label);
                    if (itemLabel != null)
                    {
                        Add(itemLabel);
                        layoutChanged = true;
                        LayoutChild();
                    }
                }
                return itemLabel;
            }
            internal set
            {
                itemLabel = value;
                layoutChanged = true;
                LayoutChild();
            }
        }

        /// <summary>
        /// The text of DefaultLinearItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TextProperty) as string;
                }
                else
                {
                    return InternalText;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextProperty, value);
                }
                else
                {
                    InternalText = value;
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalText
        {
            get
            {
                return Label.Text;
            }
            set
            {
                Label.Text = value;
            }
        }

        /// <summary>
        /// DefaultLinearItem's secondary text part of DefaultLinearItem
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel SubLabel
        {
            get
            {
                if (itemSubLabel == null)
                {
                    itemSubLabel = CreateLabel(ItemStyle?.SubLabel);
                    if (itemLabel != null)
                    {
                        Add(itemSubLabel);
                        layoutChanged = true;
                        LayoutChild();
                    }
                }
                return itemSubLabel;
            }
            internal set
            {
                itemSubLabel = value;
                layoutChanged = true;
                LayoutChild();
            }
        }

        /// <summary>
        /// The text of DefaultLinearItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SubText
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(SubTextProperty) as string;
                }
                else
                {
                    return InternalSubText;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SubTextProperty, value);
                }
                else
                {
                    InternalSubText = value;
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalSubText
        {
            get
            {
                return SubLabel.Text;
            }
            set
            {
                SubLabel.Text = value;
            }
        }

        /// <summary>
        /// Extra icon part of DefaultLinearItem. it will place next of label.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Extra
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ExtraProperty) as View;
                }
                else
                {
                    return InternalExtra;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ExtraProperty, value);
                }
                else
                {
                    InternalExtra = value;
                }
                NotifyPropertyChanged();
            }
        }
        private View InternalExtra
        {
            get
            {
                if (itemExtra == null)
                {
                    itemExtra = CreateIcon(ItemStyle?.Extra);
                    if (itemExtra != null)
                    {
                        Add(itemExtra);
                        itemExtra.Relayout += OnExtraRelayout;
                        layoutChanged = true;
                        LayoutChild();
                    }
                }
                return itemExtra;
            }
            set
            {
                if (itemExtra != null) Remove(itemExtra);
                itemExtra = value;
                if (itemExtra != null)
                {
                    //FIXME: User applied extra's style can be overwritten!
                    if (ItemStyle != null) itemExtra.ApplyStyle(ItemStyle.Extra);
                    Add(itemExtra);
                }
                layoutChanged = true;
                LayoutChild();
            }
        }

        /// <summary>
        /// Seperator divider of DefaultLinearItem. it will place at the end of item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Seperator
        {
            get
            {
                if (itemSeperator == null)
                {
                    itemSeperator = new View(ItemStyle?.Seperator)
                    {
                        //need to consider horizontal/vertical!
                        WidthSpecification = LayoutParamPolicies.MatchParent,
                        HeightSpecification = 2,
                        ExcludeLayouting = true,
                        AccessibilityHidden = true
                    };
                    layoutChanged = true;
                    Add(itemSeperator);
                }
                return itemSeperator;
            }
        }

        /// <summary>
        /// Apply style to DefaultLinearItemStyle.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);
            if (viewStyle != null && viewStyle is DefaultLinearItemStyle defaultStyle)
            {
                if (itemLabel != null)
                    itemLabel.ApplyStyle(defaultStyle.Label);
                if (itemSubLabel != null)
                    itemSubLabel.ApplyStyle(defaultStyle.SubLabel);
                if (itemIcon != null)
                    itemIcon.ApplyStyle(defaultStyle.Icon);
                if (itemExtra != null)
                    itemExtra.ApplyStyle(defaultStyle.Extra);
                if (itemSeperator != null)
                {
                    itemSeperator.ApplyStyle(defaultStyle.Seperator);
                    //FIXME : currently padding and margin are not applied by ApplyStyle automatically as missing binding features.
                    itemSeperator.Margin = new Extents(defaultStyle.Seperator.Margin);
                }
            }
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            LayoutChild();

            base.OnRelayout(size, container);

            if (prevSize != Size)
            {
                prevSize = Size;
                if (itemSeperator)
                {
                    var margin = itemSeperator.Margin;
                    itemSeperator.SizeWidth = SizeWidth - margin.Start - margin.End;
                    itemSeperator.SizeHeight = itemSeperator.HeightSpecification;
                    itemSeperator.Position = new Position(margin.Start, SizeHeight - margin.Bottom - itemSeperator.SizeHeight);
                }
            }
        }

        /// <summary>
        /// Gets accessibility name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override string AccessibilityGetName()
        {
            return Label.Text + ", " + SubLabel.Text;
        }

        /// <summary>
        /// Creates Item's text part.
        /// </summary>
        /// <return>The created Item's text part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual TextLabel CreateLabel(TextLabelStyle style)
        {
            return new TextLabel(style)
            {
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                AccessibilityHidden = true,
            };
        }

        /// <summary>
        /// Creates Item's icon part.
        /// </summary>
        /// <return>The created Item's icon part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateIcon(ViewStyle style)
        {
            return new ImageView(style);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void MeasureChild()
        {
            //Do Measure in here if necessary.
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void LayoutChild()
        {
            if (!layoutChanged) return;
            if (itemLabel == null) return;

            layoutChanged = false;

            if (itemIcon != null)
            {
                RelativeLayout.SetLeftTarget(itemIcon, this);
                RelativeLayout.SetLeftRelativeOffset(itemIcon, 0.0F);
                RelativeLayout.SetRightTarget(itemIcon, this);
                RelativeLayout.SetRightRelativeOffset(itemIcon, 0.0F);
                RelativeLayout.SetTopTarget(itemIcon, this);
                RelativeLayout.SetTopRelativeOffset(itemIcon, 0.0F);
                RelativeLayout.SetBottomTarget(itemIcon, this);
                RelativeLayout.SetBottomRelativeOffset(itemIcon, 1.0F);
                RelativeLayout.SetVerticalAlignment(itemIcon, RelativeLayout.Alignment.Center);
                RelativeLayout.SetHorizontalAlignment(itemIcon, RelativeLayout.Alignment.Start);
            }

            if (itemExtra != null)
            {
                RelativeLayout.SetLeftTarget(itemExtra, this);
                RelativeLayout.SetLeftRelativeOffset(itemExtra, 1.0F);
                RelativeLayout.SetRightTarget(itemExtra, this);
                RelativeLayout.SetRightRelativeOffset(itemExtra, 1.0F);
                RelativeLayout.SetTopTarget(itemExtra, this);
                RelativeLayout.SetTopRelativeOffset(itemExtra, 0.0F);
                RelativeLayout.SetBottomTarget(itemExtra, this);
                RelativeLayout.SetBottomRelativeOffset(itemExtra, 1.0F);
                RelativeLayout.SetVerticalAlignment(itemExtra, RelativeLayout.Alignment.Center);
                RelativeLayout.SetHorizontalAlignment(itemExtra, RelativeLayout.Alignment.End);
            }

            if (itemSubLabel != null)
            {
                RelativeLayout.SetLeftTarget(itemSubLabel,  ((itemIcon != null)? itemIcon : this));
                RelativeLayout.SetLeftRelativeOffset(itemSubLabel, ( (itemIcon != null)? 1.0F : 0.0F));
                RelativeLayout.SetRightTarget(itemSubLabel, ((itemExtra != null)? itemExtra : this));
                RelativeLayout.SetRightRelativeOffset(itemSubLabel, ((itemExtra != null)? 0.0F : 1.0F));
                RelativeLayout.SetTopTarget(itemSubLabel, this);
                RelativeLayout.SetTopRelativeOffset(itemSubLabel, 1.0F);
                RelativeLayout.SetBottomTarget(itemSubLabel, this);
                RelativeLayout.SetBottomRelativeOffset(itemSubLabel, 1.0F);
                RelativeLayout.SetVerticalAlignment(itemSubLabel, RelativeLayout.Alignment.End);
                RelativeLayout.SetHorizontalAlignment(itemSubLabel, RelativeLayout.Alignment.Center);
                RelativeLayout.SetFillHorizontal(itemSubLabel, true);
            }

            RelativeLayout.SetLeftTarget(itemLabel, ((itemIcon != null)? itemIcon : this));
            RelativeLayout.SetLeftRelativeOffset(itemLabel, ((itemIcon != null)? 1.0F : 0.0F));
            RelativeLayout.SetRightTarget(itemLabel, ((itemExtra != null)? itemExtra : this));
            RelativeLayout.SetRightRelativeOffset(itemLabel, ((itemExtra != null)? 0.0F : 1.0F));
            RelativeLayout.SetTopTarget(itemLabel, this);
            RelativeLayout.SetTopRelativeOffset(itemLabel, 0.0F);
            RelativeLayout.SetBottomTarget(itemLabel, ((itemSubLabel != null)? (View)itemSubLabel : this));
            RelativeLayout.SetBottomRelativeOffset(itemLabel, ((itemSubLabel != null)? 0.0F : 1.0F));
            RelativeLayout.SetVerticalAlignment(itemLabel, RelativeLayout.Alignment.Center);
            RelativeLayout.SetHorizontalAlignment(itemLabel, RelativeLayout.Alignment.Center);
            RelativeLayout.SetFillHorizontal(itemLabel, true);

            if (prevSize != Size)
            {
                prevSize = Size;
                if (itemSeperator)
                {
                    var margin = itemSeperator.Margin;
                    itemSeperator.SizeWidth = SizeWidth - margin.Start - margin.End;
                    itemSeperator.SizeHeight = itemSeperator.HeightSpecification;
                    itemSeperator.Position = new Position(margin.Start, SizeHeight - margin.Bottom - itemSeperator.SizeHeight);
                }
            }
        }

        /// <summary>
        /// Dispose Item and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Extension : Extension?.OnDispose(this);

                // Arugable to disposing user-created members.
                /*
                if (itemIcon != null)
                {
                    Utility.Dispose(itemIcon);
                }
                if (itemExtra != null)
                {
                    Utility.Dispose(itemExtra);
                }
                */
                if (itemLabel != null)
                {
                    Utility.Dispose(itemLabel);
                    itemLabel = null;
                }
                if (itemSubLabel != null)
                {
                    Utility.Dispose(itemSubLabel);
                    itemSubLabel = null;
                }
                if (itemSeperator != null)
                {
                    Utility.Dispose(itemSeperator);
                    itemSeperator = null;
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Get DefaultLinearItem style.
        /// </summary>
        /// <returns>The default DefaultLinearItem style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new DefaultLinearItemStyle();
        }

        /// <summary>
        /// Initializes AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            Layout = new RelativeLayout();
            var seperator = Seperator;
            layoutChanged = true;
            LayoutDirectionChanged += OnLayoutDirectionChanged;
            EnableControlStatePropagation = true;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            MeasureChild();
            LayoutChild();
        }

        private void OnIconRelayout(object sender, EventArgs e)
        {
            MeasureChild();
            LayoutChild();
        }

        private void OnExtraRelayout(object sender, EventArgs e)
        {
            MeasureChild();
            LayoutChild();
        }
    }
}
