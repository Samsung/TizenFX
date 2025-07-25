/*
 * Copyright(c) 2019-2025 Samsung Electronics Co., Ltd.
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

using global::System;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        /// <summary>
        /// StyleNameProperty (DALi json)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StyleNameProperty = null;
        internal static void SetInternalStyleNameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalStyleName((string)newValue);
            }
        }
        internal static object GetInternalStyleNameProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalStyleName();
        }

        /// <summary>
        /// KeyInputFocusProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty KeyInputFocusProperty = null;
        internal static void SetInternalKeyInputFocusProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalKeyInputFocus((bool)newValue);
            }
        }
        internal static object GetInternalKeyInputFocusProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalKeyInputFocus();
        }

        /// <summary>
        /// BackgroundColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundColorProperty = null;
        internal static void SetInternalBackgroundColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue is Selector<Color> selector)
            {
                view.SetInternalBackgroundColor(selector);
            }
            else
            {
                view.SetInternalBackgroundColor((Color)newValue);
            }
        }
        internal static object GetInternalBackgroundColorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalBackgroundColor();
        }

        /// <summary>
        /// ColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorProperty = null;
        internal static void SetInternalColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue is Selector<Color> selector)
            {
                view.SetInternalColor(selector);
            }
            else
            {
                view.SetInternalColor((Color)newValue);
            }
        }
        internal static object GetInternalColorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalColor();
        }

        /// <summary>
        /// ColorRedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorRedProperty = null;
        internal static void SetInternalColorRedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalColorRed((float)newValue);
        }
        internal static object GetInternalColorRedProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalColorRed();
        }

        /// <summary>
        /// ColorGreenProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorGreenProperty = null;
        internal static void SetInternalColorGreenProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalColorGreen((float)newValue);
        }
        internal static object GetInternalColorGreenProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalColorGreen();
        }

        /// <summary>
        /// ColorBlueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorBlueProperty = null;
        internal static void SetInternalColorBlueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalColorBlue((float)newValue);
        }
        internal static object GetInternalColorBlueProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalColorBlue();
        }

        /// <summary>
        /// BackgroundImageProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageProperty = null;
        internal static void SetInternalBackgroundImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (NUIApplication.IsUsingXaml)
            {
                if (String.Equals(oldValue, newValue))
                {
                    NUILog.Debug($"oldValue={oldValue} newValue={newValue} are same. just return here");
                    return;
                }
            }
            var view = (View)bindable;
            if (newValue is Selector<string> selector)
            {
                view.SetInternalBackgroundImage(selector);
            }
            else
            {
                view.SetInternalBackgroundImage((string)newValue);
            }
        }
        internal static object GetInternalBackgroundImageProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalBackgroundImage();
        }

        /// <summary>
        /// BackgroundImageBorderProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageBorderProperty = null;
        internal static void SetInternalBackgroundImageBorderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue is Selector<Rectangle> selector)
            {
                view.SetInternalBackgroundImageBorder(selector);
            }
            else
            {
                view.SetInternalBackgroundImageBorder((Rectangle)newValue);
            }
        }
        internal static object GetInternalBackgroundImageBorderProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalBackgroundImageBorder();
        }

        /// <summary>
        /// BackgroundProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundProperty = null;
        internal static void SetInternalBackgroundProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalBackground((PropertyMap)newValue);
            }
        }
        internal static object GetInternalBackgroundProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalBackground();
        }

        /// <summary>
        /// StateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StateProperty = null;
        internal static void SetInternalStateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalState((States)newValue);
            }
        }
        internal static object GetInternalStateProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalState();
        }

        /// <summary>
        /// SubStateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SubStateProperty = null;
        internal static void SetInternalSubStateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalSubState((States)newValue);
            }
        }
        internal static object GetInternalSubStateProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalSubState();
        }

        /// <summary>
        /// TooltipProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TooltipProperty = null;
        internal static void SetInternalTooltipProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalTooltip((PropertyMap)newValue);
            }
        }
        internal static object GetInternalTooltipProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalTooltip();
        }

        /// <summary>
        /// FlexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexProperty = null;
        internal static void SetInternalFlexProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalFlex((float)newValue);
            }
        }
        internal static object GetInternalFlexProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalFlex();
        }

        /// <summary>
        /// AlignSelfProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlignSelfProperty = null;
        internal static void SetInternalAlignSelfProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalAlignSelf((int)newValue);
            }
        }
        internal static object GetInternalAlignSelfProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalAlignSelf();
        }

        /// <summary>
        /// FlexMarginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexMarginProperty = null;
        internal static void SetInternalFlexMarginProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalFlexMargin((Vector4)newValue);
            }
        }
        internal static object GetInternalFlexMarginProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalFlexMargin();
        }

        /// <summary>
        /// CellIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellIndexProperty = null;
        internal static void SetInternalCellIndexProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalCellIndex((Vector2)newValue);
            }
        }
        internal static object GetInternalCellIndexProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalCellIndex();
        }

        /// <summary>
        /// RowSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowSpanProperty = null;
        internal static void SetInternalRowSpanProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalRowSpan((float)newValue);
            }
        }
        internal static object GetInternalRowSpanProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalRowSpan();
        }

        /// <summary>
        /// ColumnSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColumnSpanProperty = null;
        internal static void SetInternalColumnSpanProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalColumnSpan((float)newValue);
            }
        }
        internal static object GetInternalColumnSpanProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalColumnSpan();
        }

        /// <summary>
        /// CellHorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellHorizontalAlignmentProperty = null;
        internal static void SetInternalCellHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalCellHorizontalAlignment((HorizontalAlignmentType)newValue);
            }
        }
        internal static object GetInternalCellHorizontalAlignmentProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalCellHorizontalAlignment();
        }

        /// <summary>
        /// CellVerticalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellVerticalAlignmentProperty = null;
        internal static void SetInternalCellVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalCellVerticalAlignment((VerticalAlignmentType)newValue);
            }
        }
        internal static object GetInternalCellVerticalAlignmentProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalCellVerticalAlignment();
        }

        /// <summary>
        /// "DO not use this, that will be deprecated. Use 'View Weight' instead of BindableProperty"
        /// This needs to be hidden as inhouse API until all applications using it have been updated.  Do not make public.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WeightProperty = null;
        internal static void SetInternalWeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.Weight = (float)newValue;
            }
        }
        internal static object GetInternalWeightProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.Weight;
        }

        /// <summary>
        /// LeftFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeftFocusableViewProperty = null;
        internal static void SetInternalLeftFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalLeftFocusableView((View)newValue);
        }
        internal static object GetInternalLeftFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalLeftFocusableView();
        }

        /// <summary>
        /// RightFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightFocusableViewProperty = null;
        internal static void SetInternalRightFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalRightFocusableView((View)newValue);
        }
        internal static object GetInternalRightFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalRightFocusableView();
        }

        /// <summary>
        /// UpFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UpFocusableViewProperty = null;
        internal static void SetInternalUpFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalUpFocusableView((View)newValue);
        }
        internal static object GetInternalUpFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalUpFocusableView();
        }

        /// <summary>
        /// DownFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DownFocusableViewProperty = null;
        internal static void SetInternalDownFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalDownFocusableView((View)newValue);
        }
        internal static object GetInternalDownFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalDownFocusableView();
        }

        /// <summary>
        /// ClockwiseFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ClockwiseFocusableViewProperty = null;
        internal static void SetInternalClockwiseFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalClockwiseFocusableView((View)newValue);
        }
        internal static object GetInternalClockwiseFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalClockwiseFocusableView();
        }

        /// <summary>
        /// CounterClockwiseFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CounterClockwiseFocusableViewProperty = null;
        internal static void SetInternalCounterClockwiseFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalCounterClockwiseFocusableView((View)newValue);
        }
        internal static object GetInternalCounterClockwiseFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalCounterClockwiseFocusableView();
        }

        /// <summary>
        /// FocusableProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableProperty = null;
        internal static void SetInternalFocusableProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalFocusable((bool)newValue);
            }
        }
        internal static object GetInternalFocusableProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalFocusable();
        }

        /// <summary>
        /// FocusableChildrenProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableChildrenProperty = null;
        internal static void SetInternalFocusableChildrenProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalFocusableChildren((bool)newValue);
            }
        }
        internal static object GetInternalFocusableChildrenProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalFocusableChildren();
        }

        /// <summary>
        /// FocusableInTouchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableInTouchProperty = null;
        internal static void SetInternalFocusableInTouchProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalFocusableInTouch((bool)newValue);
            }
        }
        internal static object GetInternalFocusableInTouchProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalFocusableInTouch();
        }

        /// <summary>
        /// Size2DProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Size2DProperty = null;
        internal static void SetInternalSize2DProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalSize2D((Size2D)newValue);
            }
        }
        internal static object GetInternalSize2DProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalSize2D();
        }

        /// <summary>
        /// OpacityProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OpacityProperty = null;
        internal static void SetInternalOpacityProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue is Selector<float?> selector)
            {
                view.SetInternalOpacity(selector);
            }
            else
            {
                view.SetInternalOpacity((float)newValue);
            }
        }
        internal static object GetInternalOpacityProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalOpacity();
        }

        /// <summary>
        /// Position2DProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Position2DProperty = null;
        internal static void SetInternalPosition2DProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalPosition2D((Position2D)newValue);
            }
        }
        internal static object GetInternalPosition2DProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalPosition2D();
        }

        /// <summary>
        /// PositionUsesPivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesPivotPointProperty = null;
        internal static void SetInternalPositionUsesPivotPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalPositionUsesPivotPoint((bool)newValue);
            }
        }
        internal static object GetInternalPositionUsesPivotPointProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalPositionUsesPivotPoint();
        }

        /// <summary>
        /// SiblingOrderProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SiblingOrderProperty = null;
        internal static void SetInternalSiblingOrderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalSiblingOrder((int)newValue);
            }
        }
        internal static object GetInternalSiblingOrderProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalSiblingOrder();
        }

        /// <summary>
        /// ParentOriginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ParentOriginProperty = null;
        internal static void SetInternalParentOriginProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalParentOrigin((Position)newValue);
            }
        }
        internal static object GetInternalParentOriginProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalParentOrigin();
        }

        /// <summary>
        /// PivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PivotPointProperty = null;
        internal static void SetInternalPivotPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalPivotPoint((Position)newValue);
            }
        }
        internal static object GetInternalPivotPointProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalPivotPoint();
        }

        /// <summary>
        /// SizeWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeWidthProperty = null;
        internal static void SetInternalSizeWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalSizeWidth((float)newValue);
            }
        }
        internal static object GetInternalSizeWidthProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalSizeWidth();
        }

        /// <summary>
        /// SizeHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeHeightProperty = null;
        internal static void SetInternalSizeHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalSizeHeight((float)newValue);
            }
        }
        internal static object GetInternalSizeHeightProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalSizeHeight();
        }

        /// <summary>
        /// PositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionProperty = null;
        internal static void SetInternalPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalPosition((Position)newValue);
            }
        }
        internal static object GetInternalPositionProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalPosition();
        }

        /// <summary>
        /// PositionXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionXProperty = null;
        internal static void SetInternalPositionXProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalPositionX((float)newValue);
            }
        }
        internal static object GetInternalPositionXProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalPositionX();
        }

        /// <summary>
        /// PositionYProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionYProperty = null;
        internal static void SetInternalPositionYProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalPositionY((float)newValue);
            }
        }
        internal static object GetInternalPositionYProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalPositionY();
        }

        /// <summary>
        /// PositionZProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionZProperty = null;
        internal static void SetInternalPositionZProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalPositionZ((float)newValue);
            }
        }
        internal static object GetInternalPositionZProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalPositionZ();
        }

        /// <summary>
        /// OrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationProperty = null;
        internal static void SetInternalOrientationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalOrientation((Rotation)newValue);
            }
        }
        internal static object GetInternalOrientationProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalOrientation();
        }

        /// <summary>
        /// ScaleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleProperty = null;
        internal static void SetInternalScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalScale((Vector3)newValue);
            }
        }
        internal static object GetInternalScaleProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalScale();
        }

        /// <summary>
        /// ScaleXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleXProperty = null;
        internal static void SetInternalScaleXProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalScaleX((float)newValue);
            }
        }
        internal static object GetInternalScaleXProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalScaleX();
        }

        /// <summary>
        /// ScaleYProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleYProperty = null;
        internal static void SetInternalScaleYProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalScaleY((float)newValue);
            }
        }
        internal static object GetInternalScaleYProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalScaleY();
        }

        /// <summary>
        /// ScaleZProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleZProperty = null;
        internal static void SetInternalScaleZProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalScaleZ((float)newValue);
            }
        }
        internal static object GetInternalScaleZProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalScaleZ();
        }

        /// <summary>
        /// NameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NameProperty = null;
        internal static void SetInternalNameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalName((string)newValue);
            }
        }
        internal static object GetInternalNameProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalName();
        }

        /// <summary>
        /// SensitiveProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SensitiveProperty = null;
        internal static void SetInternalSensitiveProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalSensitive((bool)newValue);
            }
        }
        internal static object GetInternalSensitiveProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalSensitive();
        }

        /// <summary>
        /// IsEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = null;
        internal static void SetInternalIsEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalIsEnabled((bool)newValue);
            }
        }
        internal static object GetInternalIsEnabledProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalIsEnabled();
        }

        /// <summary>
        /// DispatchKeyEventsProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DispatchKeyEventsProperty = null;
        internal static void SetInternalDispatchKeyEventsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalDispatchKeyEvents((bool)newValue);
            }
        }
        internal static object GetInternalDispatchKeyEventsProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalDispatchKeyEvents();
        }

        /// <summary>
        /// LeaveRequiredProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeaveRequiredProperty = null;
        internal static void SetInternalLeaveRequiredProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalLeaveRequired((bool)newValue);
            }
        }
        internal static object GetInternalLeaveRequiredProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalLeaveRequired();
        }

        /// <summary>
        /// InheritOrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritOrientationProperty = null;
        internal static void SetInternalInheritOrientationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalInheritOrientation((bool)newValue);
            }
        }
        internal static object GetInternalInheritOrientationProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalInheritOrientation();
        }

        /// <summary>
        /// InheritScaleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritScaleProperty = null;
        internal static void SetInternalInheritScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalInheritScale((bool)newValue);
            }
        }
        internal static object GetInternalInheritScaleProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalInheritScale();
        }

        /// <summary>
        /// DrawModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DrawModeProperty = null;
        internal static void SetInternalDrawModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalDrawMode((DrawModeType)newValue);
            }
        }
        internal static object GetInternalDrawModeProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalDrawMode();
        }

        /// <summary>
        /// SizeModeFactorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeModeFactorProperty = null;
        internal static void SetInternalSizeModeFactorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalSizeModeFactor((Vector3)newValue);
            }
        }
        internal static object GetInternalSizeModeFactorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalSizeModeFactor();
        }

        /// <summary>
        /// WidthResizePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthResizePolicyProperty = null;
        internal static void SetInternalWidthResizePolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalWidthResizePolicy((ResizePolicyType)newValue);
            }
        }
        internal static object GetInternalWidthResizePolicyProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalWidthResizePolicy();
        }

        /// <summary>
        /// HeightResizePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightResizePolicyProperty = null;
        internal static void SetInternalHeightResizePolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalHeightResizePolicy((ResizePolicyType)newValue);
            }
        }
        internal static object GetInternalHeightResizePolicyProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalHeightResizePolicy();
        }

        /// <summary>
        /// SizeScalePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeScalePolicyProperty = null;
        internal static void SetInternalSizeScalePolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalSizeScalePolicy((SizeScalePolicyType)newValue);
            }
        }
        internal static object GetInternalSizeScalePolicyProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalSizeScalePolicy();
        }

        /// <summary>
        /// WidthForHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthForHeightProperty = null;
        internal static void SetInternalWidthForHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalWidthForHeight((bool)newValue);
            }
        }
        internal static object GetInternalWidthForHeightProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalWidthForHeight();
        }

        /// <summary>
        /// HeightForWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightForWidthProperty = null;
        internal static void SetInternalHeightForWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetInternalHeightForWidth((bool)newValue);
            }
        }
        internal static object GetInternalHeightForWidthProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalHeightForWidth();
        }

        /// <summary>
        /// PaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PaddingProperty = null;
        internal static void SetInternalPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalPadding((Extents)newValue);
            }
        }
        internal static object GetInternalPaddingProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalPadding();
        }

        /// <summary>
        /// SizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeProperty = null;
        internal static void SetInternalSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalSize((Size)newValue);
            }
        }
        internal static object GetInternalSizeProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalSize();
        }

        /// <summary>
        /// MinimumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSizeProperty = null;
        internal static void SetInternalMinimumSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalMinimumSize((Size2D)newValue);
            }
        }
        internal static object GetInternalMinimumSizeProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalMinimumSize();
        }

        /// <summary>
        /// MaximumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaximumSizeProperty = null;

        internal static void SetInternalMaximumSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalMaximumSize((Size2D)newValue);
            }
        }
        internal static object GetInternalMaximumSizeProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalMaximumSize();
        }

        /// <summary>
        /// InheritPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritPositionProperty = null;

        internal static void SetInternalInheritPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalInheritPosition((bool)newValue);
            }
        }
        internal static object GetInternalInheritPositionProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalInheritPosition();
        }

        /// <summary>
        /// ClippingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ClippingModeProperty = null;

        internal static void SetInternalClippingModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalClippingMode((ClippingModeType)newValue);
            }
        }
        internal static object GetInternalClippingModeProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalClippingMode();
        }

        /// <summary>
        /// InheritLayoutDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritLayoutDirectionProperty = null;

        internal static void SetInternalInheritLayoutDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalInheritLayoutDirection((bool)newValue);
            }
        }
        internal static object GetInternalInheritLayoutDirectionProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalInheritLayoutDirection();
        }

        /// <summary>
        /// LayoutDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutDirectionProperty = null;

        internal static void SetInternalLayoutDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalLayoutDirection((ViewLayoutDirectionType)newValue);
            }
        }
        internal static object GetInternalLayoutDirectionProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalLayoutDirection();
        }

        /// <summary>
        /// MarginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MarginProperty = null;

        internal static void SetInternalMarginProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalMargin((Extents)newValue);
            }
        }
        internal static object GetInternalMarginProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalMargin();
        }

        /// <summary>
        /// UpdateAreaHintProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UpdateAreaHintProperty = null;

        internal static void SetInternalUpdateAreaHintProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalUpdateAreaHint((Vector4)newValue);
            }
        }
        internal static object GetInternalUpdateAreaHintProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalUpdateAreaHint();
        }

        /// <summary>
        /// ImageShadow Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageShadowProperty = null;

        internal static void SetInternalImageShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue is Selector<ImageShadow> selector)
            {
                view.SetInternalImageShadow(selector);
            }
            else
            {
                view.SetInternalImageShadow((ImageShadow)newValue);
            }
        }
        internal static object GetInternalImageShadowProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalImageShadow();
        }

        /// <summary>
        /// Shadow Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BoxShadowProperty = null;

        internal static void SetInternalBoxShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue is Selector<Shadow> selector)
            {
                view.SetInternalBoxShadow(selector);
            }
            else
            {
                view.SetInternalBoxShadow((Shadow)newValue);
            }
        }
        internal static object GetInternalBoxShadowProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalBoxShadow();
        }

        /// <summary>
        /// CornerRadius Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusProperty = null;

        internal static void SetInternalCornerRadiusProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalCornerRadius((Vector4)newValue);
        }
        internal static object GetInternalCornerRadiusProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalCornerRadius();
        }

        /// <summary>
        /// CornerRadiusPolicy Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusPolicyProperty = null;

        internal static void SetInternalCornerRadiusPolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalCornerRadiusPolicy((VisualTransformPolicyType)newValue);
        }
        internal static object GetInternalCornerRadiusPolicyProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalCornerRadiusPolicy();
        }

        /// <summary>
        /// BorderlineWidth Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineWidthProperty = null;

        internal static void SetInternalBorderlineWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalBorderlineWidth((float)newValue);
        }
        internal static object GetInternalBorderlineWidthProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalBorderlineWidth();
        }

        /// <summary>
        /// BorderlineColor Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineColorProperty = null;

        internal static void SetInternalBorderlineColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue is Selector<Color> selector)
            {
                view.SetInternalBorderlineColor(selector);
            }
            else
            {
                view.SetInternalBorderlineColor((Color)newValue);
            }
        }
        internal static object GetInternalBorderlineColorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalBorderlineColor();
        }

        /// <summary>
        /// BorderlineColorSelector Property
        /// Like BackgroundColor, color selector typed BorderlineColor should be used in ViewStyle only.
        /// So this API is internally used only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineColorSelectorProperty = null;

        internal static void SetInternalBorderlineColorSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue is Selector<Color> selector)
            {
                view.SetInternalBorderlineColor(selector);
            }
            else
            {
                view.SetInternalBorderlineColor((Color)newValue);
            }
        }
        internal static object GetInternalBorderlineColorSelectorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalBorderlineColorSelector();
        }

        /// <summary>
        /// BorderlineOffset Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineOffsetProperty = null;

        internal static void SetInternalBorderlineOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalBorderlineOffset((float)newValue);
        }
        internal static object GetInternalBorderlineOffsetProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalBorderlineOffset();
        }

        /// <summary>
        /// EnableControlState property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableControlStateProperty = null;

        internal static void SetInternalEnableControlStateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalEnableControlState((bool)newValue);
        }
        internal static object GetInternalEnableControlStateProperty(BindableObject bindable)
        {
            return ((View)bindable).GetInternalEnableControlState();
        }

        /// <summary>
        /// ThemeChangeSensitive property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThemeChangeSensitiveProperty = null;

        internal static void SetInternalThemeChangeSensitiveProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetInternalThemeChangeSensitive((bool)newValue);
        }
        internal static object GetInternalThemeChangeSensitiveProperty(BindableObject bindable)
        {
            return ((View)bindable).GetInternalThemeChangeSensitive();
        }

        /// <summary>
        /// AccessibilityNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityNameProperty = null;

        internal static void SetInternalAccessibilityNameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalAccessibilityName((string)newValue);
            }
        }
        internal static object GetInternalAccessibilityNameProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalAccessibilityName();
        }

        /// <summary>
        /// AccessibilityDescriptionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityDescriptionProperty = null;

        internal static void SetInternalAccessibilityDescriptionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalAccessibilityDescription((string)newValue);
            }
        }
        internal static object GetInternalAccessibilityDescriptionProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalAccessibilityDescription();
        }

        /// <summary>
        /// AccessibilityTranslationDomainProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityTranslationDomainProperty = null;

        internal static void SetInternalAccessibilityTranslationDomainProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalAccessibilityTranslationDomain((string)newValue);
            }
        }
        internal static object GetInternalAccessibilityTranslationDomainProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalAccessibilityTranslationDomain();
        }

        /// <summary>
        /// AccessibilityRoleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityRoleProperty = null;

        internal static void SetInternalAccessibilityRoleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalAccessibilityRole((Role)newValue);
            }
        }
        internal static object GetInternalAccessibilityRoleProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalAccessibilityRole();
        }

        /// <summary>
        /// AccessibilityHighlightableProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityHighlightableProperty = null;

        internal static void SetInternalAccessibilityHighlightableProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalAccessibilityHighlightable((bool)newValue);
            }
        }
        internal static object GetInternalAccessibilityHighlightableProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalAccessibilityHighlightable();
        }

        /// <summary>
        /// AccessibilityHiddenProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityHiddenProperty = null;

        internal static void SetInternalAccessibilityHiddenProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var view = (View)bindable;
                view.SetInternalAccessibilityHidden((bool)newValue);
            }
        }
        internal static object GetInternalAccessibilityHiddenProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.GetInternalAccessibilityHidden();
        }

        /// <summary>
        /// ExcludeLayoutingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExcludeLayoutingProperty = null;

        internal static void SetInternalExcludeLayoutingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalExcludeLayouting((bool)newValue);
            }
        }
        internal static object GetInternalExcludeLayoutingProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalExcludeLayouting();
        }

        /// <summary>
        /// TooltipTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TooltipTextProperty = null;

        internal static void SetInternalTooltipTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalTooltipText((string)newValue);
            }
        }
        internal static object GetInternalTooltipTextProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalTooltipText();
        }

        /// <summary>
        /// PositionUsesAnchorPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesAnchorPointProperty = null;

        internal static void SetInternalPositionUsesAnchorPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalPositionUsesAnchorPoint((bool)newValue);
            }
        }
        internal static object GetInternalPositionUsesAnchorPointProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalPositionUsesAnchorPoint();
        }

        /// <summary>
        /// AnchorPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnchorPointProperty = null;

        internal static void SetInternalAnchorPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalAnchorPoint((Position)newValue);
            }
        }
        internal static object GetInternalAnchorPointProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalAnchorPoint();
        }

        /// <summary>
        /// WidthSpecificationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthSpecificationProperty = null;

        internal static void SetInternalWidthSpecificationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalWidthSpecification((int)newValue);
            }
        }
        internal static object GetInternalWidthSpecificationProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalWidthSpecification();
        }

        /// <summary>
        /// HeightSpecificationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightSpecificationProperty = null;

        internal static void SetInternalHeightSpecificationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalHeightSpecification((int)newValue);
            }
        }
        internal static object GetInternalHeightSpecificationProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalHeightSpecification();
        }

        /// <summary>
        /// LayoutTransitionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutTransitionProperty = null;

        internal static void SetInternalLayoutTransitionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalLayoutTransition((LayoutTransition)newValue);
            }
        }
        internal static object GetInternalLayoutTransitionProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalLayoutTransition();
        }

        /// <summary>
        /// PaddingEXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PaddingEXProperty = null;

        internal static void SetInternalPaddingEXProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalPaddingEX((Extents)newValue);
            }
        }
        internal static object GetInternalPaddingEXProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalPaddingEX();
        }

        /// <summary>
        /// LayoutProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutProperty = null;

        internal static void SetInternalLayoutProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalLayout((LayoutItem)newValue);
            }
        }
        internal static object GetInternalLayoutProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalLayout();
        }

        /// <summary>
        /// BackgroundImageSynchronosLoadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageSynchronosLoadingProperty = null;

        internal static void SetInternalBackgroundImageSynchronosLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalBackgroundImageSynchronosLoading((bool)newValue);
            }
        }
        internal static object GetInternalBackgroundImageSynchronosLoadingProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalBackgroundImageSynchronosLoading();
        }

        /// <summary>
        /// BackgroundImageSynchronousLoadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageSynchronousLoadingProperty = null;

        internal static void SetInternalBackgroundImageSynchronousLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalBackgroundImageSynchronousLoading((bool)newValue);
            }
        }
        internal static object GetInternalBackgroundImageSynchronousLoadingProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalBackgroundImageSynchronousLoading();
        }

        /// <summary>
        /// EnableControlStatePropagationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableControlStatePropagationProperty = null;

        internal static void SetInternalEnableControlStatePropagationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalEnableControlStatePropagation((bool)newValue);
            }
        }
        internal static object GetInternalEnableControlStatePropagationProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalEnableControlStatePropagation();
        }

        /// <summary>
        /// PropagatableControlStatesProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PropagatableControlStatesProperty = null;

        internal static void SetInternalPropagatableControlStatesProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.InternalPropagatableControlStates = (ControlState)newValue;
            }
        }
        internal static object GetInternalPropagatableControlStatesProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalPropagatableControlStates();
        }

        /// <summary>
        /// GrabTouchAfterLeaveProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabTouchAfterLeaveProperty = null;

        internal static void SetInternalGrabTouchAfterLeaveProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalGrabTouchAfterLeave((bool)newValue);
            }
        }
        internal static object GetInternalGrabTouchAfterLeaveProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalGrabTouchAfterLeave();
        }

        /// <summary>
        /// AllowOnlyOwnTouchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AllowOnlyOwnTouchProperty = null;

        internal static void SetInternalAllowOnlyOwnTouchProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalAllowOnlyOwnTouch((bool)newValue);
            }
        }
        internal static object GetInternalAllowOnlyOwnTouchProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalAllowOnlyOwnTouch();
        }

        /// <summary>
        /// BlendEquationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BlendEquationProperty = null;

        internal static void SetInternalBlendEquationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalBlendEquation((BlendEquationType)newValue);
            }
        }
        internal static object GetInternalBlendEquationProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalBlendEquation();
        }

        /// <summary>
        /// TransitionOptionsProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TransitionOptionsProperty = null;

        internal static void SetInternalTransitionOptionsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalTransitionOptions((TransitionOptions)newValue);
            }
        }
        internal static object GetInternalTransitionOptionsProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalTransitionOptions();
        }

        /// <summary>
        /// AutomationIdProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutomationIdProperty = null;

        internal static void SetInternalAutomationIdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalAutomationId((string)newValue);
            }
        }
        internal static object GetInternalAutomationIdProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalAutomationId();
        }

        /// <summary>
        /// TouchAreaOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TouchAreaOffsetProperty = null;

        internal static void SetInternalTouchAreaOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalTouchAreaOffset((Offset)newValue);
            }
        }
        internal static object GetInternalTouchAreaOffsetProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalTouchAreaOffset();
        }

        /// <summary>
        /// DispatchTouchMotionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DispatchTouchMotionProperty = null;

        internal static void SetInternalDispatchTouchMotionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalDispatchTouchMotion((bool)newValue);
            }
        }
        internal static object GetInternalDispatchTouchMotionProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalDispatchTouchMotion();
        }

        /// <summary>
        /// DispatchHoverMotionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DispatchHoverMotionProperty = null;

        internal static void SetInternalDispatchHoverMotionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (View)bindable;
                instance.SetInternalDispatchHoverMotion((bool)newValue);
            }
        }
        internal static object GetInternalDispatchHoverMotionProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.GetInternalDispatchHoverMotion();
        }

        /// <summary>
        /// Gets View's Size2D set by user.
        /// </summary>
        internal Size2D GetUserSize2D()
        {
            return new Size2D((int)userSizeWidth, (int)userSizeHeight);
        }

        private void SetBackgroundImage(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                backgroundImageUrl = null;

                var empty = new PropertyValue();
                // Clear background
                Object.SetProperty(SwigCPtr, Property.BACKGROUND, empty);
                empty.Dispose();
                return;
            }

            if (value.StartsWith("*Resource*"))
            {
                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                value = value.Replace("*Resource*", resource);
            }

            backgroundImageUrl = value;

            // Fast return for usual cases.
            if (backgroundExtraData == null && !_viewFlags.HasFlag(ViewFlags.BackgroundImageSynchronousLoading))
            {
                Object.InternalSetPropertyString(SwigCPtr, View.Property.BACKGROUND, value);
                return;
            }

            using var map = new PropertyMap();

            map.Add(ImageVisualProperty.URL, value)
               .Add(ImageVisualProperty.SynchronousLoading, _viewFlags.HasFlag(ViewFlags.BackgroundImageSynchronousLoading));

            if ((backgroundExtraData?.BackgroundImageBorder) != null)
            {
                map.Add(Visual.Property.Type, (int)Visual.Type.NPatch)
                   .Add(NpatchImageVisualProperty.Border, backgroundExtraData.BackgroundImageBorder);
            }
            else
            {
                map.Add(Visual.Property.Type, (int)Visual.Type.Image);
            }

            if (backgroundExtraData != null)
            {
                map.Add(Visual.Property.CornerRadius, backgroundExtraData.CornerRadius)
                   .Add(Visual.Property.CornerSquareness, backgroundExtraData.CornerSquareness)
                   .Add(Visual.Property.CornerRadiusPolicy, (int)backgroundExtraData.CornerRadiusPolicy);
            }

            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

            using var mapValue = new PropertyValue(map);
            Object.SetProperty(SwigCPtr, Property.BACKGROUND, mapValue);
        }

        private void SetBackgroundImageBorder(Rectangle value)
        {
            bool isEmptyValue = Rectangle.IsNullOrZero(value);

            var backgroundImageBorder = isEmptyValue ? null : value;

            (backgroundExtraData ?? (backgroundExtraData = new BackgroundExtraData())).BackgroundImageBorder = backgroundImageBorder;

            if (isEmptyValue)
            {
                return;
            }

            PropertyMap map = Background;

            if (map.Empty())
            {
                return;
            }

            map.Set(NpatchImageVisualProperty.Border, backgroundImageBorder);

            int visualType = 0;

            using (var pv = map.Find(Visual.Property.Type))
            {
                pv?.Get(out visualType);
            }

            if (visualType == (int)Visual.Type.Image)
            {
                map.Set(Visual.Property.Type, (int)Visual.Type.NPatch);
            }

            using (var pv = new PropertyValue(map))
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, View.Property.BACKGROUND, pv);
            }
        }

        private void SetBorderlineColor(Color value)
        {
            if (value == null)
            {
                return;
            }

            Object.InternalSetPropertyVector4(SwigCPtr, Property.BorderlineColor, value.SwigCPtr);
        }

        private void SetBackgroundColor(Color value)
        {
            if (value == null)
            {
                return;
            }

            // Background property will be Color after now. Remove background image url information.
            backgroundImageUrl = null;

            if (backgroundExtraData == null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, View.Property.BACKGROUND, ((Color)value).SwigCPtr);
                return;
            }

            using var map = new PropertyMap();

            map.Add(Visual.Property.Type, (int)Visual.Type.Color)
               .Add(ColorVisualProperty.MixColor, value);

            map.Add(Visual.Property.CornerRadius, backgroundExtraData.CornerRadius)
               .Add(Visual.Property.CornerSquareness, backgroundExtraData.CornerSquareness)
               .Add(Visual.Property.CornerRadiusPolicy, (int)backgroundExtraData.CornerRadiusPolicy);

            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

            using var mapValue = new PropertyValue(map);
            Object.SetProperty(SwigCPtr, Property.BACKGROUND, mapValue);
        }

        private void SetColor(Color value)
        {
            if (value == null)
            {
                return;
            }

            Interop.ActorInternal.SetColor(SwigCPtr, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetColorRed(float? value)
        {
            if (value == null)
            {
                return;
            }

            Object.InternalSetPropertyFloat(SwigCPtr, View.Property.ColorRed, (float)value);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetColorGreen(float? value)
        {
            if (value == null)
            {
                return;
            }

            Object.InternalSetPropertyFloat(SwigCPtr, View.Property.ColorGreen, (float)value);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetColorBlue(float? value)
        {
            if (value == null)
            {
                return;
            }

            Object.InternalSetPropertyFloat(SwigCPtr, View.Property.ColorBlue, (float)value);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetOpacity(float? value)
        {
            if (value == null)
            {
                return;
            }

            Object.InternalSetPropertyFloat(SwigCPtr, View.Property.OPACITY, (float)value);
        }

        private void SetShadow(ShadowBase value)
        {
            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Shadow;

            using var pv = value == null ? new PropertyValue() : value.ToPropertyValue(this);
            Tizen.NUI.Object.SetProperty(SwigCPtr, View.Property.SHADOW, pv);
        }

        private void SetInnerShadow(ShadowBase value)
        {
            using var pv = value == null ? new PropertyValue() : value.ToPropertyValue(this);
            Tizen.NUI.Object.SetProperty(SwigCPtr, View.Property.InnerShadow, pv);
        }
    }
}
