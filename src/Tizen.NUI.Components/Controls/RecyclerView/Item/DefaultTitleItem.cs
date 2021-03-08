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
using Tizen.NUI.Binding;
using Tizen.NUI.Components.Extension;
using Tizen.NUI.Accessibility;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// DefaultTitleItem is one kind of common component, a DefaultTitleItem clearly describes what action will occur when the user selects it.
    /// DefaultTitleItem may contain text or an icon.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultTitleItem : RecyclerViewItem
    {
        private TextLabel itemLabel;
        private View itemIcon;
        private View itemSeperator;
        private bool layoutChanged;
        private Size prevSize;
        private DefaultTitleItemStyle ItemStyle => ViewStyle as DefaultTitleItemStyle;

        /// <summary>
        /// Return a copied Style instance of DefaultTitleItem
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the DefaultTitleItem.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new DefaultTitleItemStyle Style
        {
            get
            {
                var result = new DefaultTitleItemStyle(ItemStyle);
                result.CopyPropertiesFromView(this);
                if (itemLabel) result.Label.CopyPropertiesFromView(itemLabel);
                if (itemIcon) result.Icon.CopyPropertiesFromView(itemIcon);
                if (itemSeperator) result.Seperator.CopyPropertiesFromView(itemSeperator);

                return result;
            }
        }

        static DefaultTitleItem() { }

        /// <summary>
        /// Creates a new instance of DefaultTitleItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultTitleItem() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a DefaultTitleItem with style.
        /// </summary>
        /// <param name="style">Create DefaultTitleItem by style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultTitleItem(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a DefaultTitleItem with style.
        /// </summary>
        /// <param name="itemStyle">Create DefaultTitleItem by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultTitleItem(DefaultTitleItemStyle itemStyle) : base(itemStyle)
        {
            Initialize();
        }

        /// <summary>
        /// Icon part of DefaultTitleItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Icon
        {
            get
            {
                if (itemIcon == null)
                {
                    itemIcon = CreateIcon(ItemStyle?.Icon);
                    if (itemIcon != null)
                    {
                        layoutChanged = true;
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
        /// DefaultTitleItem's text part of DefaultTitleItem
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
                        layoutChanged = true;
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
        /// The text of DefaultTitleItem.
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
        /// Seperator devider of DefaultTitleItem. it will place at the end of item.
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
                        ExcludeLayouting = true
                    };
                    layoutChanged = true;
                    Add(itemSeperator);
                }
                return itemSeperator;
            }
        }

        /// <summary>
        /// Apply style to DefaultTitleItemStyle.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {

            base.ApplyStyle(viewStyle);
            if (viewStyle != null && viewStyle is DefaultTitleItemStyle defaultStyle)
            {
                if (itemLabel != null)
                    itemLabel.ApplyStyle(defaultStyle.Label);
                if (itemIcon != null)
                    itemIcon.ApplyStyle(defaultStyle.Icon);
                if (itemSeperator != null)
                    itemSeperator.ApplyStyle(defaultStyle.Seperator);
            }
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
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
        /// Creates Item's text part.
        /// </summary>
        /// <return>The created Item's text part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual TextLabel CreateLabel(TextLabelStyle style)
        {
            return new TextLabel(style)
            {
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center
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
            if (itemLabel == null) return;

            layoutChanged = false;

            if (itemIcon != null)
            {
                RelativeLayout.SetLeftTarget(itemIcon, this);
                RelativeLayout.SetLeftRelativeOffset(itemIcon, 1.0F);
                RelativeLayout.SetRightTarget(itemIcon, this);
                RelativeLayout.SetRightRelativeOffset(itemIcon, 1.0F);
                RelativeLayout.SetTopTarget(itemIcon, this);
                RelativeLayout.SetTopRelativeOffset(itemIcon, 0.0F);
                RelativeLayout.SetBottomTarget(itemIcon, this);
                RelativeLayout.SetBottomRelativeOffset(itemIcon, 1.0F);
                RelativeLayout.SetVerticalAlignment(itemIcon, RelativeLayout.Alignment.Center);
                RelativeLayout.SetHorizontalAlignment(itemIcon, RelativeLayout.Alignment.End);
            }

            RelativeLayout.SetLeftTarget(itemLabel, this);
            RelativeLayout.SetLeftRelativeOffset(itemLabel, 0.0F);
            if (itemIcon)
            {
                RelativeLayout.SetRightTarget(itemLabel, itemIcon);
                RelativeLayout.SetRightRelativeOffset(itemLabel, 0.0F);
            }
            else
            {
                RelativeLayout.SetRightTarget(itemLabel, this);
                RelativeLayout.SetRightRelativeOffset(itemLabel, 1.0F);
            }

            RelativeLayout.SetTopTarget(itemLabel, this);
            RelativeLayout.SetTopRelativeOffset(itemLabel, 0.0F);
            RelativeLayout.SetBottomTarget(itemLabel, this);
            RelativeLayout.SetBottomRelativeOffset(itemLabel, 1.0F);
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

                if (itemIcon != null)
                {
                    Utility.Dispose(itemIcon);
                }
                if (itemLabel != null)
                {
                    Utility.Dispose(itemLabel);
                }
                if (itemSeperator != null)
                {
                    Utility.Dispose(itemSeperator);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Get DefaultTitleItem style.
        /// </summary>
        /// <returns>The default DefaultTitleItem style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new DefaultTitleItemStyle();
        }

        private void Initialize()
        {
            base.OnInitialize();
            Layout = new RelativeLayout();
            var seperator = Seperator;
            layoutChanged = true;
            LayoutDirectionChanged += OnLayoutDirectionChanged;
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
