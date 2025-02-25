/*
 * Copyright(c) 2019-2022 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{
    public partial class View
    {
        /// NOTE This can replace SetBackgroundColor(NUI.Color) after sufficient verification
        internal void SetBackgroundColor(UIColor color)
        {
            themeData?.selectorData?.ClearBackground(this);

            // Background property will be Color after now. Remove background image url information.
            backgroundImageUrl = null;

            if (backgroundExtraData == null)
            {
                Object.InternalSetPropertyColor(SwigCPtr, Property.BACKGROUND, color);
            }
            else
            {
                using var map = new PropertyMap()
                    .Append(Visual.Property.Type, (int)Visual.Type.Color)
                    .Append(ColorVisualProperty.MixColor, color)
                    .Append(Visual.Property.CornerSquareness, backgroundExtraData.CornerSquareness)
                    .Append(Visual.Property.BorderlineWidth, backgroundExtraData.BorderlineWidth)
                    .Append(Visual.Property.BorderlineColor, backgroundExtraData.BorderlineColor ?? Color.Black)
                    .Append(Visual.Property.BorderlineOffset, backgroundExtraData.BorderlineOffset);

                backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

                Object.InternalSetPropertyMap(SwigCPtr, Property.BACKGROUND, map.SwigCPtr);
            }

            NotifyPropertyChanged(nameof(BackgroundColor));
            NotifyBackgroundChanged();
        }

        /// NOTE This can replace SetInternalBoxShadowProperty() after sufficient verification
        internal void SetBoxShadow(UIShadow shadow)
        {
            themeData?.selectorData?.ClearShadow(this);

            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Shadow;

            using var map = shadow.BuildMap(this);

            Object.InternalSetPropertyMap(SwigCPtr, Property.SHADOW, map.SwigCPtr);
            NotifyPropertyChanged(nameof(BoxShadow));
        }

        internal UIShadow GetBoxShadow()
        {
            // Sync as current properties
            UpdateBackgroundExtraData();

            using PropertyValue shadowMapValue = Object.GetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, Property.SHADOW);
            if (shadowMapValue != null)
            {
                using PropertyMap map = new PropertyMap();
                if (shadowMapValue.Get(map))
                {
                    // FIXME do not use Shadow here
                    var shadow = new Shadow(map);
                    return new UIShadow()
                    {
                        Color = new UIColor(shadow.Color),
                        BlurRadius = shadow.BlurRadius,
                        OffsetX = shadow.Offset.X,
                        OffsetY = shadow.Offset.Y,
                        ExtraWidth = shadow.Extents.Width,
                        ExtraHeight = shadow.Extents.Height,
                        CutoutPolicy = (ColorVisualCutoutPolicyType)shadow.CutoutPolicy
                    };
                }
            }
            return UIShadow.Default;
        }

        internal bool UpdateBoxShadowColor(UIColor color)
        {
            // Sync as current properties
            UpdateBackgroundExtraData();

            using PropertyValue shadowMapValue = Object.GetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, Property.SHADOW);
            if (shadowMapValue != null)
            {
                using PropertyMap map = new PropertyMap();
                if (shadowMapValue.Get(map))
                {
                    map.Set(ColorVisualProperty.MixColor, color);
                    Object.InternalSetPropertyMap(SwigCPtr, Property.SHADOW, map.SwigCPtr);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets or sets the width of the view used to size the view within its parent layout container. It can be set to a fixed value, wrap content, or match parent.
        /// </summary>
        internal LayoutDimension LayoutWidth
        {
            get => layoutExtraData?.Width ?? LayoutDimension.WrapContent;
            set
            {
                var layoutExtraData = EnsureLayoutExtraData();
                if (layoutExtraData.Width != value)
                {
                    layoutExtraData.Width = value;
                    layoutExtraData.Layout?.RequestLayout();
                }
            }
        }

        /// <summary>
        /// Gets or sets the height of the view used to size the view within its parent layout container. It can be set to a fixed value, wrap content, or match parent.
        /// </summary>
        internal LayoutDimension LayoutHeight
        {
            get => layoutExtraData?.Height ?? LayoutDimension.WrapContent;
            set
            {
                var layoutExtraData = EnsureLayoutExtraData();
                if (layoutExtraData.Height != value)
                {
                    layoutExtraData.Height = value;
                    layoutExtraData.Layout?.RequestLayout();
                }
            }
        }

        internal float GetMinimumWidth()
        {
            return layoutExtraData?.MinimumWidth ?? 0;
        }

        internal void SetMinimumWidth(float minimumWidth, bool updateMinimumSize)
        {
            if (float.IsNaN(minimumWidth))
            {
                return;
            }

            var layoutExtraData = EnsureLayoutExtraData();
            if (layoutExtraData.MinimumWidth != minimumWidth)
            {
                if (updateMinimumSize)
                {
                    if (minimumWidth >= int.MaxValue)
                    {
                        MinimumSize.Width = int.MaxValue;
                    }
                    else if (minimumWidth <= int.MinValue)
                    {
                        MinimumSize.Width = int.MinValue;
                    }
                    else
                    {
                        MinimumSize.Width = (int)minimumWidth;
                    }
                }
                layoutExtraData.MinimumWidth = minimumWidth;
                layoutExtraData.Layout?.RequestLayout();
            }
        }

        internal float GetMinimumHeight()
        {
            return layoutExtraData?.MinimumHeight ?? 0;
        }

        internal void SetMinimumHeight(float minimumHeight, bool updateMinimumSize)
        {
            if (float.IsNaN(minimumHeight))
            {
                return;
            }

            var layoutExtraData = EnsureLayoutExtraData();
            if (layoutExtraData.MinimumHeight != minimumHeight)
            {
                if (updateMinimumSize)
                {
                    if (minimumHeight >= int.MaxValue)
                    {
                        MinimumSize.Height = int.MaxValue;
                    }
                    else if (minimumHeight <= int.MinValue)
                    {
                        MinimumSize.Height = int.MinValue;
                    }
                    else
                    {
                        MinimumSize.Height = (int)minimumHeight;
                    }
                }
                layoutExtraData.MinimumHeight = minimumHeight;
                layoutExtraData.Layout?.RequestLayout();
            }
        }

        internal float GetMaximumWidth()
        {
            return layoutExtraData?.MaximumWidth ?? int.MaxValue;
        }

        internal void SetMaximumWidth(float maximumWidth, bool updateMaximumSize)
        {
            if (float.IsNaN(maximumWidth))
            {
                return;
            }

            var layoutExtraData = EnsureLayoutExtraData();
            if (layoutExtraData.MaximumWidth != maximumWidth)
            {
                if (updateMaximumSize)
                {
                    if (maximumWidth >= int.MaxValue)
                    {
                        MaximumSize.Width = int.MaxValue;
                    }
                    else if (maximumWidth <= int.MinValue)
                    {
                        MaximumSize.Width = int.MinValue;
                    }
                    else
                    {
                        MaximumSize.Width = (int)maximumWidth;
                    }
                }
                layoutExtraData.MaximumWidth = maximumWidth;
                layoutExtraData.Layout?.RequestLayout();
            }
        }

        internal float GetMaximumHeight()
        {
            return layoutExtraData?.MaximumHeight ?? int.MaxValue;
        }

        internal void SetMaximumHeight(float maximumHeight, bool updateMaximumSize)
        {
            if (float.IsNaN(maximumHeight))
            {
                return;
            }

            var layoutExtraData = EnsureLayoutExtraData();
            if (layoutExtraData.MaximumHeight != maximumHeight)
            {
                if (updateMaximumSize)
                {
                    if (maximumHeight >= int.MaxValue)
                    {
                        MaximumSize.Height = int.MaxValue;
                    }
                    else if (maximumHeight <= int.MinValue)
                    {
                        MaximumSize.Height = int.MinValue;
                    }
                    else
                    {
                        MaximumSize.Height = (int)maximumHeight;
                    }
                }
                layoutExtraData.MaximumHeight = maximumHeight;
                layoutExtraData.Layout?.RequestLayout();
            }
        }

        internal UIExtents GetMargin()
        {
            return layoutExtraData?.Margin ?? 0;
        }

        internal void SetMargin(UIExtents margin, bool updateMargin)
        {
            if (margin.IsNaN)
            {
                return;
            }

            var layoutExtraData = EnsureLayoutExtraData();
            if (layoutExtraData.Margin != margin)
            {
                if (updateMargin)
                {
                    Margin = new Extents(margin);
                }
                layoutExtraData.Margin = margin;
                layoutExtraData.Layout?.RequestLayout();
            }
        }

        internal UIExtents GetPadding()
        {
            return layoutExtraData?.Padding ?? 0;
        }

        internal void SetPadding(UIExtents padding, bool updatePadding)
        {
            if (padding.IsNaN)
            {
                return;
            }

            var layoutExtraData = EnsureLayoutExtraData();
            if (layoutExtraData.Padding != padding)
            {
                if (updatePadding)
                {
                    Padding = new Extents(padding);
                }
                layoutExtraData.Padding = padding;
                layoutExtraData.Layout?.RequestLayout();
            }
        }
    }
}
