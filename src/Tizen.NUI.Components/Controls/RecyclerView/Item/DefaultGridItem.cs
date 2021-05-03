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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// DefaultGridItem is one kind of common component, a DefaultGridItem clearly describes what action will occur when the user selects it.
    /// DefaultGridItem may contain text or an icon.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultGridItem : RecyclerViewItem
    {
        private TextLabel itemCaption;
        private ImageView itemImage;
        private View itemBadge;
        private CaptionOrientation captionOrientation;
        private bool layoutChanged;

        private DefaultGridItemStyle ItemStyle => ViewStyle as DefaultGridItemStyle;

        static DefaultGridItem() { }

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
        /// Caption orientation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum CaptionOrientation
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
                itemImage = value;
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
                return itemBadge;

            }
            set
            {
                if (value == null)
                {
                    Remove(itemBadge);
                }
                itemBadge = value;
                if (itemBadge != null)
                {
                    itemBadge.ApplyStyle(ItemStyle.Badge);
                    Add(itemBadge);
                }
                layoutChanged = true;
            }
        }

        /* open when ImageView using Uri not string
                /// <summary>
                /// Image image's resource url in DefaultGridItem.
                /// </summary>
                [EditorBrowsable(EditorBrowsableState.Never)]
                public string ImageUrl
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
        */

        /// <summary>
        /// DefaultGridItem's text part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel Caption
        {
            get
            {
                if (itemCaption == null)
                {
                    itemCaption = CreateLabel(ItemStyle.Caption);
                    if (itemCaption != null)
                    {
                        Add(itemCaption);
                        layoutChanged = true;
                    }
                }
                return itemCaption;
            }
            internal set
            {
                itemCaption = value;
                layoutChanged = true;
                AccessibilityManager.Instance.SetAccessibilityAttribute(this, AccessibilityManager.AccessibilityAttribute.Label, itemCaption.Text);
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
                return Caption.Text;
            }
            set
            {
                Caption.Text = value;
            }
        }

        /// <summary>
        /// Caption relative orientation with image in DefaultGridItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CaptionOrientation CaptionRelativeOrientation
        {
            get
            {
                return captionOrientation;
            }
            set
            {
                captionOrientation = value;
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
                if (itemCaption != null)
                    itemCaption.ApplyStyle(defaultStyle.Caption);
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
            if (itemCaption)
            {
                var pad = Padding;
                var margin = itemCaption.Margin;
                itemCaption.SizeWidth = SizeWidth - pad.Start - pad.End - margin.Start - margin.End;
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

            if (itemCaption != null)
            {
                itemCaption.RaiseAbove(itemImage);
                RelativeLayout.SetLeftTarget(itemCaption, itemImage);
                RelativeLayout.SetLeftRelativeOffset(itemCaption, 0.0F);
                RelativeLayout.SetRightTarget(itemCaption, itemImage);
                RelativeLayout.SetRightRelativeOffset(itemCaption, 1.0F);
                RelativeLayout.SetHorizontalAlignment(itemCaption, RelativeLayout.Alignment.Center);
                RelativeLayout.SetFillHorizontal(itemCaption, true);
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
                RelativeLayout.SetLeftTarget(itemBadge, itemImage);
                RelativeLayout.SetLeftRelativeOffset(itemBadge, 1.0F);
                RelativeLayout.SetRightTarget(itemBadge, itemImage);
                RelativeLayout.SetRightRelativeOffset(itemBadge, 1.0F);
                RelativeLayout.SetHorizontalAlignment(itemBadge, RelativeLayout.Alignment.End);
            }

            switch (captionOrientation)
            {
                case CaptionOrientation.OutsideBottom:
                    if (itemCaption != null)
                    {
                        RelativeLayout.SetTopTarget(itemCaption, this);
                        RelativeLayout.SetTopRelativeOffset(itemCaption, 1.0F);
                        RelativeLayout.SetBottomTarget(itemCaption, this);
                        RelativeLayout.SetBottomRelativeOffset(itemCaption, 1.0F);
                        RelativeLayout.SetVerticalAlignment(itemCaption, RelativeLayout.Alignment.End);

                        RelativeLayout.SetTopTarget(itemImage, this);
                        RelativeLayout.SetTopRelativeOffset(itemImage, 0.0F);
                        RelativeLayout.SetBottomTarget(itemImage, itemCaption);
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

                case CaptionOrientation.OutsideTop:
                    if (itemCaption != null)
                    {
                        RelativeLayout.SetTopTarget(itemCaption, this);
                        RelativeLayout.SetTopRelativeOffset(itemCaption, 0.0F);
                        RelativeLayout.SetBottomTarget(itemCaption, this);
                        RelativeLayout.SetBottomRelativeOffset(itemCaption, 0.0F);
                        RelativeLayout.SetVerticalAlignment(itemCaption, RelativeLayout.Alignment.Start);

                        RelativeLayout.SetTopTarget(itemImage, itemCaption);
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

                case CaptionOrientation.InsideBottom:
                    if (itemCaption != null)
                    {
                        RelativeLayout.SetTopTarget(itemCaption, this);
                        RelativeLayout.SetTopRelativeOffset(itemCaption, 1.0F);
                        RelativeLayout.SetBottomTarget(itemCaption, this);
                        RelativeLayout.SetBottomRelativeOffset(itemCaption, 1.0F);
                        RelativeLayout.SetVerticalAlignment(itemCaption, RelativeLayout.Alignment.End);

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

                case CaptionOrientation.InsideTop:
                    if (itemCaption != null)
                    {
                        RelativeLayout.SetTopTarget(itemCaption, this);
                        RelativeLayout.SetTopRelativeOffset(itemCaption, 0.0F);
                        RelativeLayout.SetBottomTarget(itemCaption, this);
                        RelativeLayout.SetBottomRelativeOffset(itemCaption, 0.0F);
                        RelativeLayout.SetVerticalAlignment(itemCaption, RelativeLayout.Alignment.Start);

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
        /// Initializes AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            Layout = new RelativeLayout();
            layoutChanged = true;
            LayoutDirectionChanged += OnLayoutDirectionChanged;
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
                if (itemCaption != null)
                {
                    Utility.Dispose(itemCaption);
                    itemCaption = null;
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
