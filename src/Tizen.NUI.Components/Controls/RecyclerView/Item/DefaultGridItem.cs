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
    /// DefaultGridItem is one kind of common component, a DefaultGridItem clearly describes what action will occur when the user selects it.
    /// DefaultGridItem may contain text or an icon.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DefaultGridItem : RecyclerViewItem
    {
        private TextLabel itemLabel;
        private ImageView itemImage;
        private View itemBadge;
        private LabelOrientation labelOrientation;
        private bool layoutChanged;

        private DefaultGridItemStyle ItemStyle => ViewStyle as DefaultGridItemStyle;

        static DefaultGridItem()
        {
            if (NUIApplication.IsUsingXaml)
            {
                BadgeProperty = BindableProperty.Create(nameof(Badge), typeof(View), typeof(DefaultGridItem), null,
                    propertyChanged: SetInternalBadgeProperty, defaultValueCreator: GetInternalBadgeProperty);
                TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(DefaultGridItem), default(string),
                    propertyChanged: SetInternalTextProperty, defaultValueCreator: GetInternalTextProperty);
                ResourceUrlProperty = BindableProperty.Create(nameof(ResourceUrl), typeof(string), typeof(DefaultGridItem), default(string),
                    propertyChanged: SetInternalResourceUrlProperty, defaultValueCreator: GetInternalResourceUrlProperty);
                LabelOrientationTypeProperty = BindableProperty.Create(nameof(LabelOrientationType), typeof(Tizen.NUI.Components.DefaultGridItem.LabelOrientation), typeof(DefaultGridItem), default(LabelOrientation),
                    propertyChanged: SetInternalLabelOrientationTypeProperty, defaultValueCreator: GetInternalLabelOrientationTypeProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of DefaultGridItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultGridItem() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of DefaultGridItem with style
        /// </summary>
        /// <param name="style=">Create DefaultGridItem by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultGridItem(string style) : base(style)
        {
        }

        /// <summary>
        /// Creates a new instance of DefaultGridItem with style
        /// </summary>
        /// <param name="itemStyle=">Create DefaultGridItem by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultGridItem(DefaultGridItemStyle itemStyle) : base(itemStyle)
        {
        }

        /// <summary>
        /// Label orientation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum LabelOrientation
        {
            /// <summary>
            /// Outside of image bottom edge.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            OutsideBottom,
            /// <summary>
            /// Outside of image top edge.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            OutsideTop,
            /// <summary>
            /// inside of image bottom edge.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            InsideBottom,
            /// <summary>
            /// inside of image top edge.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            InsideTop,
        }

        /// <summary>
        /// DefaultGridItem's icon part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView Image
        {
            get
            {
                if (itemImage == null)
                {
                    itemImage = CreateImage(ItemStyle.Image);
                    if (itemImage != null)
                    {
                        Add(itemImage);
                        itemImage.Relayout += OnImageRelayout;
                        layoutChanged = true;
                    }
                }
                return itemImage;
            }
            internal set
            {
                if (itemImage != null) Remove(itemImage);
                itemImage = value;
                if (itemImage != null)
                {
                    //FIXME: User applied image's style can be overwritten!
                    if (ItemStyle != null) itemImage.ApplyStyle(ItemStyle.Image);
                    Add(itemImage);
                    itemImage.Relayout += OnImageRelayout;
                }
                layoutChanged = true;
            }
        }


        /// <summary>
        /// DefaultGridItem's badge object. will be placed in right-top edge.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Badge
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(BadgeProperty) as View;
                }
                else
                {
                    return InternalBadge;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BadgeProperty, value);
                }
                else
                {
                    InternalBadge = value;
                }
                NotifyPropertyChanged();
            }
        }
        private View InternalBadge
        {
            get
            {
                return itemBadge;
            }
            set
            {
                if (itemBadge != null) Remove(itemBadge);
                itemBadge = value;
                if (itemBadge != null)
                {
                    //FIXME: User applied badge's style can be overwritten!
                    if (ItemStyle != null) itemBadge.ApplyStyle(ItemStyle.Badge);
                    Add(itemBadge);
                }
                layoutChanged = true;
            }
        }

        /// <summary>
        /// Image resource url in DefaultGridItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ResourceUrlProperty) as string;
                }
                else
                {
                    return InternalResourceUrl;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ResourceUrlProperty, value);
                }
                else
                {
                    InternalResourceUrl = value;
                }
                NotifyPropertyChanged();
            }
        }

        internal string InternalResourceUrl
        {
            get
            {
                return Image.ResourceUrl;
            }
            set
            {
                Image.ResourceUrl = value;
            }
        }


        /// <summary>
        /// DefaultGridItem's text part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel Label
        {
            get
            {
                if (itemLabel == null)
                {
                    itemLabel = CreateLabel(ItemStyle.Label);
                    if (itemLabel != null)
                    {
                        Add(itemLabel);
                        layoutChanged = true;
                    }
                }
                return itemLabel;
            }
            internal set
            {
                itemLabel = value;
                layoutChanged = true;
            }
        }

        /// <summary>
        /// The text of DefaultGridItem.
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
        /// Label relative orientation with image in DefaultGridItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LabelOrientation LabelOrientationType
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (LabelOrientation)GetValue(LabelOrientationTypeProperty);
                }
                else
                {
                    return InternalLabelOrientationType;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LabelOrientationTypeProperty, value);
                }
                else
                {
                    InternalLabelOrientationType = value;
                }
                NotifyPropertyChanged();
            }
        }
        private LabelOrientation InternalLabelOrientationType
        {
            get
            {
                return labelOrientation;
            }
            set
            {
                labelOrientation = value;
                layoutChanged = true;
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
            if (viewStyle != null && viewStyle is DefaultGridItemStyle defaultStyle)
            {
                if (itemLabel != null)
                    itemLabel.ApplyStyle(defaultStyle.Label);
                if (itemImage != null)
                    itemImage.ApplyStyle(defaultStyle.Image);
                if (itemBadge != null)
                    itemBadge.ApplyStyle(defaultStyle.Badge);
            }
        }

        /// <summary>
        /// Creates Item's text part.
        /// </summary>
        /// <return>The created Item's text part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual TextLabel CreateLabel(TextLabelStyle textStyle)
        {
            return new TextLabel(textStyle)
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        /// <summary>
        /// Creates Item's icon part.
        /// </summary>
        /// <return>The created Item's icon part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateImage(ImageViewStyle imageStyle)
        {
            return new ImageView(imageStyle);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void MeasureChild()
        {
            //nothing to do.
            if (itemLabel)
            {
                var pad = Padding;
                var margin = itemLabel.Margin;
                itemLabel.SizeWidth = SizeWidth - pad.Start - pad.End - margin.Start - margin.End;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void LayoutChild()
        {
            if (!layoutChanged) return;
            if (itemImage == null) return;

            layoutChanged = false;

            RelativeLayout.SetLeftTarget(itemImage, this);
            RelativeLayout.SetLeftRelativeOffset(itemImage, 0.0F);
            RelativeLayout.SetRightTarget(itemImage, this);
            RelativeLayout.SetRightRelativeOffset(itemImage, 1.0F);
            RelativeLayout.SetHorizontalAlignment(itemImage, RelativeLayout.Alignment.Center);
            RelativeLayout.SetFillHorizontal(itemImage, true);
            RelativeLayout.SetFillVertical(itemImage, true);

            if (itemLabel != null)
            {
                itemLabel.RaiseAbove(itemImage);
                RelativeLayout.SetLeftTarget(itemLabel, itemImage);
                RelativeLayout.SetLeftRelativeOffset(itemLabel, 0.0F);
                RelativeLayout.SetRightTarget(itemLabel, itemImage);
                RelativeLayout.SetRightRelativeOffset(itemLabel, 1.0F);
                RelativeLayout.SetHorizontalAlignment(itemLabel, RelativeLayout.Alignment.Center);
                RelativeLayout.SetFillHorizontal(itemLabel, true);
            }
            else
            {
                RelativeLayout.SetTopTarget(itemImage, this);
                RelativeLayout.SetTopRelativeOffset(itemImage, 0.0F);
                RelativeLayout.SetBottomTarget(itemImage, this);
                RelativeLayout.SetBottomRelativeOffset(itemImage, 1.0F);
                RelativeLayout.SetVerticalAlignment(itemImage, RelativeLayout.Alignment.Center);
            }

            if (itemBadge)
            {
                itemBadge.RaiseAbove(itemImage);
                RelativeLayout.SetLeftTarget(itemBadge, itemImage);
                RelativeLayout.SetLeftRelativeOffset(itemBadge, 1.0F);
                RelativeLayout.SetRightTarget(itemBadge, itemImage);
                RelativeLayout.SetRightRelativeOffset(itemBadge, 1.0F);
                RelativeLayout.SetHorizontalAlignment(itemBadge, RelativeLayout.Alignment.End);
            }

            switch (labelOrientation)
            {
                case LabelOrientation.OutsideBottom:
                    if (itemLabel != null)
                    {
                        RelativeLayout.SetTopTarget(itemLabel, this);
                        RelativeLayout.SetTopRelativeOffset(itemLabel, 1.0F);
                        RelativeLayout.SetBottomTarget(itemLabel, this);
                        RelativeLayout.SetBottomRelativeOffset(itemLabel, 1.0F);
                        RelativeLayout.SetVerticalAlignment(itemLabel, RelativeLayout.Alignment.End);

                        RelativeLayout.SetTopTarget(itemImage, this);
                        RelativeLayout.SetTopRelativeOffset(itemImage, 0.0F);
                        RelativeLayout.SetBottomTarget(itemImage, itemLabel);
                        RelativeLayout.SetBottomRelativeOffset(itemImage, 0.0F);
                        RelativeLayout.SetVerticalAlignment(itemImage, RelativeLayout.Alignment.Center);
                    }

                    if (itemBadge)
                    {
                        RelativeLayout.SetTopTarget(itemBadge, itemImage);
                        RelativeLayout.SetTopRelativeOffset(itemBadge, 0.0F);
                        RelativeLayout.SetBottomTarget(itemBadge, itemImage);
                        RelativeLayout.SetBottomRelativeOffset(itemBadge, 0.0F);
                        RelativeLayout.SetVerticalAlignment(itemBadge, RelativeLayout.Alignment.Start);
                    }
                    break;

                case LabelOrientation.OutsideTop:
                    if (itemLabel != null)
                    {
                        RelativeLayout.SetTopTarget(itemLabel, this);
                        RelativeLayout.SetTopRelativeOffset(itemLabel, 0.0F);
                        RelativeLayout.SetBottomTarget(itemLabel, this);
                        RelativeLayout.SetBottomRelativeOffset(itemLabel, 0.0F);
                        RelativeLayout.SetVerticalAlignment(itemLabel, RelativeLayout.Alignment.Start);

                        RelativeLayout.SetTopTarget(itemImage, itemLabel);
                        RelativeLayout.SetTopRelativeOffset(itemImage, 1.0F);
                        RelativeLayout.SetBottomTarget(itemImage, this);
                        RelativeLayout.SetBottomRelativeOffset(itemImage, 1.0F);
                        RelativeLayout.SetVerticalAlignment(itemImage, RelativeLayout.Alignment.Center);
                    }

                    if (itemBadge)
                    {
                        RelativeLayout.SetTopTarget(itemBadge, itemImage);
                        RelativeLayout.SetTopRelativeOffset(itemBadge, 1.0F);
                        RelativeLayout.SetBottomTarget(itemBadge, itemImage);
                        RelativeLayout.SetBottomRelativeOffset(itemBadge, 1.0F);
                        RelativeLayout.SetVerticalAlignment(itemBadge, RelativeLayout.Alignment.End);
                    }
                    break;

                case LabelOrientation.InsideBottom:
                    if (itemLabel != null)
                    {
                        RelativeLayout.SetTopTarget(itemLabel, this);
                        RelativeLayout.SetTopRelativeOffset(itemLabel, 1.0F);
                        RelativeLayout.SetBottomTarget(itemLabel, this);
                        RelativeLayout.SetBottomRelativeOffset(itemLabel, 1.0F);
                        RelativeLayout.SetVerticalAlignment(itemLabel, RelativeLayout.Alignment.End);

                        Console.WriteLine("Item Label Inside Bottom!");

                        RelativeLayout.SetTopTarget(itemImage, this);
                        RelativeLayout.SetTopRelativeOffset(itemImage, 0.0F);
                        RelativeLayout.SetBottomTarget(itemImage, this);
                        RelativeLayout.SetBottomRelativeOffset(itemImage, 1.0F);
                        RelativeLayout.SetVerticalAlignment(itemImage, RelativeLayout.Alignment.Center);
                    }

                    if (itemBadge)
                    {
                        RelativeLayout.SetTopTarget(itemBadge, itemImage);
                        RelativeLayout.SetTopRelativeOffset(itemBadge, 0.0F);
                        RelativeLayout.SetBottomTarget(itemBadge, itemImage);
                        RelativeLayout.SetBottomRelativeOffset(itemBadge, 0.0F);
                        RelativeLayout.SetVerticalAlignment(itemBadge, RelativeLayout.Alignment.Start);
                    }
                    break;

                case LabelOrientation.InsideTop:
                    if (itemLabel != null)
                    {
                        RelativeLayout.SetTopTarget(itemLabel, this);
                        RelativeLayout.SetTopRelativeOffset(itemLabel, 0.0F);
                        RelativeLayout.SetBottomTarget(itemLabel, this);
                        RelativeLayout.SetBottomRelativeOffset(itemLabel, 0.0F);
                        RelativeLayout.SetVerticalAlignment(itemLabel, RelativeLayout.Alignment.Start);

                        RelativeLayout.SetTopTarget(itemImage, this);
                        RelativeLayout.SetTopRelativeOffset(itemImage, 0.0F);
                        RelativeLayout.SetBottomTarget(itemImage, this);
                        RelativeLayout.SetBottomRelativeOffset(itemImage, 1.0F);
                        RelativeLayout.SetVerticalAlignment(itemImage, RelativeLayout.Alignment.Center);
                    }

                    if (itemBadge)
                    {
                        RelativeLayout.SetTopTarget(itemBadge, itemImage);
                        RelativeLayout.SetTopRelativeOffset(itemBadge, 1.0F);
                        RelativeLayout.SetBottomTarget(itemBadge, itemImage);
                        RelativeLayout.SetBottomRelativeOffset(itemBadge, 1.0F);
                        RelativeLayout.SetVerticalAlignment(itemBadge, RelativeLayout.Alignment.End);
                    }
                    break;
            }


        }

        /// <summary>
        /// Gets accessibility name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override string AccessibilityGetName()
        {
            return itemLabel.Text;
        }

        /// <summary>
        /// Initializes AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            Layout = new RelativeLayout();
            layoutChanged = true;
            LayoutDirectionChanged += OnLayoutDirectionChanged;
            EnableControlStatePropagation = true;
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
                if (itemBadge != null)
                {
                    Utility.Dispose(itemBadge);
                }
                */

                if (itemImage != null)
                {
                    Utility.Dispose(itemImage);
                    itemImage = null;
                }
                if (itemLabel != null)
                {
                    Utility.Dispose(itemLabel);
                    itemLabel = null;
                }

            }

            base.Dispose(type);
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            MeasureChild();
            LayoutChild();
        }
        private void OnImageRelayout(object sender, EventArgs e)
        {
            MeasureChild();
            LayoutChild();
        }
    }
}
