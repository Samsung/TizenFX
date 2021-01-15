/* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;
using Tizen.NUI.Components.Extension;
using Tizen.NUI.Accessibility;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// OutLineGridItem is one kind of common component, a OutLineGridItem clearly describes what action will occur when the user selects it.
    /// OutLineGridItem may contain text or an icon.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class OutLineGridItem : ViewItem
    {
        /// <summary>
        /// Extents padding around Image
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImagePaddingProperty = BindableProperty.Create(nameof(ImagePadding), typeof(Extents), typeof(OutLineGridItem), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (OutLineGridItem)bindable;
            instance.iconPadding = (Extents)((Extents)newValue).Clone();
            instance.UpdateContent();
        },
        defaultValueCreator: (bindable) => ((OutLineGridItem)bindable).iconPadding);

        /// <summary>
        /// Extents padding around badge from the icon top-right edge.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BadgePaddingProperty = BindableProperty.Create(nameof(BadgePadding), typeof(Extents), typeof(OutLineGridItem), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (OutLineGridItem)bindable;
            instance.badgePadding = (Extents)((Extents)newValue).Clone();
            instance.UpdateContent();
        },
        defaultValueCreator: (bindable) => ((OutLineGridItem)bindable).badgePadding);

        /// <summary>
        /// Extents padding around Label
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelPaddingProperty = BindableProperty.Create(nameof(LabelPadding), typeof(Extents), typeof(OutLineGridItem), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (OutLineGridItem)bindable;
            instance.labelPadding = (Extents)((Extents)newValue).Clone();
            instance.UpdateContent();
        },
        defaultValueCreator: (bindable) => ((OutLineGridItem)bindable).labelPadding);

        private ImageView itemImage;
        private View itemBadge;
        private TextLabel itemText;
        private Extents iconPadding;
        private Extents badgePadding;
        private Extents labelPadding;
        static OutLineGridItem() {}

        /// <summary>
        /// Creates a new instance of OutLineGridItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OutLineGridItem() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of OutLineGridItem with style
        /// </summary>
        /// <param name="style=">Create OutLineGridItem by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OutLineGridItem(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of OutLineGridItem with style
        /// </summary>
        /// <param name="itemStyle=">Create OutLineGridItem by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OutLineGridItem(ViewItemStyle itemStyle) : base(itemStyle)
        {
            Initialize();
        }

        /// <summary>
        /// OutLineGridItem's icon part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView Image
        {
            get
            {
                if ( itemImage == null)
                {
                    itemImage = CreateImage();
                    if (itemImage != null)
                    {
                        Add(itemImage);
                        itemImage.Relayout += OnImageRelayout;
                    }
                }
                return itemImage;
            }
            internal set
            {
                itemImage = value;
            }
        }


        /// <summary>
        /// OutLineGridItem's badge object. will be placed in right-top edge.
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
                Add(itemBadge);
            }
        }

/* open when ImageView using Uri not string
        /// <summary>
        /// Image image's resource url in OutLineGridItem.
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
        /// OutLineGridItem's text part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel Label
        {
            get
            {
                if (itemText == null)
                {
                    itemText = CreateLabel();
                    if (itemText != null)
                    {
                        Add(itemText);
                    }
                }
                return itemText;
            }
            internal set
            {
                itemText = value;
                AccessibilityManager.Instance.SetAccessibilityAttribute(this, AccessibilityManager.AccessibilityAttribute.Label, itemText.Text);
            }
        }

        /// <summary>
        /// The text of OutLineGridItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
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
        /// Image padding in ViewItem, work only when show icon and text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ImagePadding
        {
            get => (Extents)GetValue(ImagePaddingProperty) ?? new Extents();
            set => SetValue(ImagePaddingProperty, value);
        }

        /// <summary>
        /// Image padding in ViewItem, work only when show icon and text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents BadgePadding { get; set; }


        /// <summary>
        /// Text padding in ViewItem, work only when show icon and text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents LabelPadding
        {
            get => (Extents)GetValue(LabelPaddingProperty) ?? new Extents();
            set => SetValue(LabelPaddingProperty, value);
        }

        /// <summary>
        /// Creates Item's text part.
        /// </summary>
        /// <return>The created Item's text part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual TextLabel CreateLabel()
        {
            return new TextLabel
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.BottomCenter,
                PivotPoint = NUI.PivotPoint.BottomCenter,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        /// <summary>
        /// Creates Item's icon part.
        /// </summary>
        /// <return>The created Item's icon part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateImage()
        {
            return new ImageView
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.Center,
                PivotPoint = NUI.PivotPoint.Center
            };
        }

         /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void MeasureChild()
        {
            if (itemImage == null || itemText == null)
            {
                return;
            }
            itemText.WidthResizePolicy = ResizePolicyType.Fixed;
            itemText.HeightResizePolicy = ResizePolicyType.Fixed;

            var labelPadding = LabelPadding;
            int labelPaddingStart = labelPadding.Start;
            int labelPaddingEnd = labelPadding.End;
            int labelPaddingTop = labelPadding.Top;
            int labelPaddingBottom = labelPadding.Bottom;

            var iconPadding = ImagePadding;
            int iconPaddingStart = iconPadding.Start;
            int iconPaddingEnd = iconPadding.End;
            int iconPaddingTop = iconPadding.Top;
            int iconPaddingBottom = iconPadding.Bottom;

            itemText.SizeWidth = SizeWidth - labelPaddingStart - labelPaddingEnd;
            itemText.SizeHeight = SizeHeight - labelPaddingTop - labelPaddingBottom - iconPaddingTop - iconPaddingBottom - itemImage.SizeHeight;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void LayoutChild()
        {
            if (itemImage == null || itemText == null)
            {
                return;
            }

            var labelPadding = LabelPadding;
            var iconPadding = ImagePadding;
            var badgePadding = BadgePadding;

            itemImage.PositionUsesPivotPoint = true;
            itemImage.ParentOrigin = NUI.ParentOrigin.TopCenter;
            itemImage.PivotPoint = NUI.PivotPoint.TopCenter;
            itemImage.Position2D = new Position2D(0, iconPadding.Top);

            itemText.PositionUsesPivotPoint = true;
            itemText.ParentOrigin = NUI.ParentOrigin.BottomCenter;
            itemText.PivotPoint = NUI.PivotPoint.BottomCenter;
            itemText.Position2D = new Position2D(0, -labelPadding.Bottom);

            if (itemBadge)
            {
                itemBadge.PositionUsesPivotPoint = true;
                itemBadge.ParentOrigin = NUI.ParentOrigin.TopRight;
                itemBadge.PivotPoint = NUI.PivotPoint.TopRight;
                itemBadge.RaiseAbove(itemImage);
                itemBadge.Position2D = new Position2D(-(badgePadding.End + iconPadding.End), (badgePadding.Top + iconPadding.Top));
            }

           if (string.IsNullOrEmpty(itemText.Text))
            {
                itemImage.ParentOrigin = NUI.ParentOrigin.Center;
                itemImage.PivotPoint = NUI.PivotPoint.Center;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Initialize()
        {
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

                if (itemImage != null)
                {
                    Utility.Dispose(itemImage);
                }
                if (itemText != null)
                {
                    Utility.Dispose(itemText);
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
