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
    /// OneLineLinearItem is one kind of common component, a OneLineLinearItem clearly describes what action will occur when the user selects it.
    /// OneLineLinearItem may contain text or an icon.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class OneLineLinearItem : ViewItem
    {
        /// <summary>
        /// Extents padding around Icon
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconPaddingProperty = BindableProperty.Create(nameof(IconPadding), typeof(Extents), typeof(OneLineLinearItem), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (OneLineLinearItem)bindable;
            instance.iconPadding = (Extents)((Extents)newValue).Clone();
            instance.UpdateContent();
        },
        defaultValueCreator: (bindable) => ((OneLineLinearItem)bindable).iconPadding);

        /// <summary>
        /// Extents padding around Label
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelPaddingProperty = BindableProperty.Create(nameof(LabelPadding), typeof(Extents), typeof(OneLineLinearItem), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (OneLineLinearItem)bindable;
            instance.labelPadding = (Extents)((Extents)newValue).Clone();
            instance.UpdateContent();
        },
        defaultValueCreator: (bindable) => ((OneLineLinearItem)bindable).labelPadding);

        /// <summary>
        /// Extents padding around extra icon
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExtraPaddingProperty = BindableProperty.Create(nameof(ExtraPadding), typeof(Extents), typeof(OneLineLinearItem), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (OneLineLinearItem)bindable;
            instance.extraPadding = (Extents)((Extents)newValue).Clone();
            instance.UpdateContent();
        },
        defaultValueCreator: (bindable) => ((OneLineLinearItem)bindable).extraPadding);

        private View itemIcon;
        private TextLabel itemLabel;
        private View itemExtra;
        private Extents iconPadding;
        private Extents labelPadding;
        private Extents extraPadding;

        static OneLineLinearItem() {}

        /// <summary>
        /// Creates a new instance of OneLineLinearItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OneLineLinearItem() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a OneLineLinearItem with style.
        /// </summary>
        /// <param name="style">Create ViewItem by style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OneLineLinearItem(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a OneLineLinearItem with style.
        /// </summary>
        /// <param name="itemStyle">Create ViewItem by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OneLineLinearItem(ViewItemStyle itemStyle) : base(itemStyle)
        {
            Initialize();
        }

        /// <summary>
        /// Icon part of OneLineLinearItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Icon
        {
            get
            {
                if (itemIcon == null)
                {
                    itemIcon = CreateIcon();
                    if (itemIcon != null)
                    {
                        Add(itemIcon);
                        itemIcon.Relayout += OnIconRelayout;
                    }
                }
                return itemIcon;
            }
            set
            {
                itemIcon = value;
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
        /// OneLineLinearItem's text part of OneLineLinearItem
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel Label
        {
            get
            {
                if (itemLabel == null)
                {
                    itemLabel = CreateLabel();
                    if (itemLabel != null)
                    {
                        Add(itemLabel);
                    }
                }
                return itemLabel;
            }
            internal set
            {
                itemLabel = value;
                AccessibilityManager.Instance.SetAccessibilityAttribute(this, AccessibilityManager.AccessibilityAttribute.Label, itemLabel.Text);
            }
        }

        /// <summary>
        /// The text of OneLineLinearItem.
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
        /// Extra icon part of OneLineLinearItem. it will place next of label.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Extra
        {
            get
            {
                if (itemExtra == null)
                {
                    itemExtra = CreateIcon();
                    if (itemExtra != null)
                    {
                        Add(itemExtra);
                        itemExtra.Relayout += OnExtraRelayout;
                    }
                }
                return itemExtra;
            }
            set
            {
                if (itemExtra != null) Remove(itemExtra);
                itemExtra = value;
                Add(itemExtra);
            }
        }

        /// <summary>
        /// Icon padding in OneLineLinearItem, work only when show icon and text.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents IconPadding
        {
            get => (Extents)GetValue(IconPaddingProperty) ?? new Extents();
            set => SetValue(IconPaddingProperty, value);
        }

        /// <summary>
        /// Text padding in OneLineLinearItem, work only when show icon and text.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents LabelPadding
        {
            get => (Extents)GetValue(LabelPaddingProperty) ?? new Extents();
            set => SetValue(LabelPaddingProperty, value);
        }

        /// <summary>
        /// Extra padding in OneLineLinearItem, work only when show extra and text.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ExtraPadding
        {
            get => (Extents)GetValue(ExtraPaddingProperty) ?? new Extents();
            set => SetValue(ExtraPaddingProperty, value);
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
                ParentOrigin = NUI.ParentOrigin.Center,
                PivotPoint = NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        /// <summary>
        /// Creates Item's icon part.
        /// </summary>
        /// <return>The created Item's icon part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateIcon()
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
            if (itemLabel == null)
            {
                return;
            }
            itemLabel.WidthResizePolicy = ResizePolicyType.Fixed;
            itemLabel.HeightResizePolicy = ResizePolicyType.Fixed;

            var labelPadding = LabelPadding;
            var iconPadding = IconPadding;
            var extraPadding = ExtraPadding;

            var iconSize = (itemIcon?.SizeWidth ?? 0) + iconPadding.Start + iconPadding.End;
            var extraSize = (itemExtra?.SizeWidth ?? 0) + extraPadding.Start + extraPadding.End;

            itemLabel.SizeWidth = SizeWidth - labelPadding.Start - labelPadding.End - iconSize - extraSize;
            itemLabel.SizeHeight = SizeHeight - labelPadding.Top - labelPadding.Bottom;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void LayoutChild()
        {
            if (itemLabel == null)
            {
                return;
            }

            var labelPadding = LabelPadding;
            var iconPadding = IconPadding;

            if (itemIcon == null && itemExtra == null ||
                itemIcon != null && itemExtra != null)
            {
                itemLabel.PositionUsesPivotPoint = true;
                itemLabel.ParentOrigin = NUI.ParentOrigin.Center;
                itemLabel.PivotPoint = NUI.PivotPoint.Center;
                itemLabel.Position2D = new Position2D(0, 0);

                if (itemIcon != null && itemExtra != null)
                {
                    itemIcon.PositionUsesPivotPoint = true;
                    itemIcon.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    itemIcon.PivotPoint = NUI.PivotPoint.CenterLeft;
                    itemIcon.Position2D = new Position2D(iconPadding.Start, 0);

                    itemExtra.PositionUsesPivotPoint = true;
                    itemExtra.ParentOrigin = NUI.ParentOrigin.CenterRight;
                    itemExtra.PivotPoint = NUI.PivotPoint.CenterRight;
                    itemExtra.Position2D = new Position2D(-extraPadding.End, 0);
                }
            }
            else
            {
                if (itemIcon != null)
                {
                    itemIcon.PositionUsesPivotPoint = true;
                    itemIcon.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    itemIcon.PivotPoint = NUI.PivotPoint.CenterLeft;
                    itemIcon.Position2D = new Position2D(iconPadding.Start, 0);

                    itemLabel.PositionUsesPivotPoint = true;
                    itemLabel.ParentOrigin = NUI.ParentOrigin.CenterRight;
                    itemLabel.PivotPoint = NUI.PivotPoint.CenterRight;
                    itemLabel.Position2D = new Position2D(-labelPadding.End, 0);
                }
                else if (itemExtra != null)
                {
                    itemLabel.PositionUsesPivotPoint = true;
                    itemLabel.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    itemLabel.PivotPoint = NUI.PivotPoint.CenterLeft;
                    itemLabel.Position2D = new Position2D(labelPadding.Start, 0);

                    itemExtra.PositionUsesPivotPoint = true;
                    itemExtra.ParentOrigin = NUI.ParentOrigin.CenterRight;
                    itemExtra.PivotPoint = NUI.PivotPoint.CenterRight;
                    itemExtra.Position2D = new Position2D(-extraPadding.End, 0);
                }
            }

            if (string.IsNullOrEmpty(itemLabel.Text))
            {
                if (itemIcon != null && itemExtra == null)
                {
                    itemIcon.ParentOrigin = NUI.ParentOrigin.Center;
                    itemIcon.PivotPoint = NUI.PivotPoint.Center;
                }
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Initialize()
        {
            base.OnInitialize();
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

                if (itemIcon != null)
                {
                    Utility.Dispose(itemIcon);
                }
                if (itemLabel != null)
                {
                    Utility.Dispose(itemLabel);
                }
            }

            base.Dispose(type);
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
