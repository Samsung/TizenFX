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
        private float userSizeWidth = 0.0f;
        private float userSizeHeight = 0.0f;

        /// <summary>
        /// StyleNameProperty (DALi json)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StyleNameProperty = null;

        internal static void SetInternalStyleNameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                string styleName = (string)newValue;

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.StyleName, styleName);

                view.styleName = styleName;

                if (string.IsNullOrEmpty(styleName)) return;

                var style = ThemeManager.GetUpdateStyleWithoutClone(styleName);

                if (style == null) return;

                view.ApplyStyle(style);
                view.SetThemeApplied();
            }
        }
        internal static object GetInternalStyleNameProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            if (!string.IsNullOrEmpty(view.styleName)) return view.styleName;

            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.StyleName);
        }

        /// <summary>
        /// KeyInputFocusProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty KeyInputFocusProperty = null;

        internal static void SetInternalKeyInputFocusProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
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

            if (NUIApplication.IsUsingXaml)
            {
                view.themeData?.selectorData?.ClearBackground(view);

                if (newValue is Selector<Color> selector)
                {
                    if (selector.HasAll()) view.SetBackgroundColor(selector.All);
                    else view.EnsureSelectorData().BackgroundColor = new TriggerableSelector<Color>(view, selector, view.SetBackgroundColor, true);
                }
                else
                {
                    view.SetBackgroundColor((Color)newValue);
                }

            }
            else
            {
                view.SetBackgroundColor((Color)newValue);
            }
        }
        internal static object GetInternalBackgroundColorProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            if (view.internalBackgroundColor == null)
            {
                view.internalBackgroundColor = new Color(view.OnBackgroundColorChanged, 0, 0, 0, 0);
            }

            int visualType = (int)Visual.Type.Invalid;
            Object.InternalRetrievingVisualPropertyInt(view.SwigCPtr, Property.BACKGROUND, Visual.Property.Type, out visualType);

            if (visualType == (int)Visual.Type.Color)
            {
                Object.InternalRetrievingVisualPropertyVector4(view.SwigCPtr, Property.BACKGROUND, ColorVisualProperty.MixColor, Color.getCPtr(view.internalBackgroundColor));
            }
            return view.internalBackgroundColor;
        }

        /// <summary>
        /// ColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorProperty = null;

        internal static void SetInternalColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;

            view.themeData?.selectorData?.Color?.Reset(view);

            if (newValue is Selector<Color> selector)
            {
                if (selector.HasAll()) view.SetColor(selector.All);
                else view.EnsureSelectorData().Color = new TriggerableSelector<Color>(view, selector, view.SetColor, true);
            }
            else
            {
                view.SetColor((Color)newValue);
            }
        }
        internal static object GetInternalColorProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            if (view.internalColor == null)
            {
                view.internalColor = new Color(view.OnColorChanged, 0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(view.SwigCPtr, View.Property.COLOR, view.internalColor.SwigCPtr);
            return view.internalColor;
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

            if (view.themeData?.selectorData != null)
            {
                view.themeData.selectorData.BackgroundColor?.Reset(view);
                view.themeData.selectorData.BackgroundImage?.Reset(view);
            }

            if (newValue is Selector<string> selector)
            {
                if (selector.HasAll()) view.SetBackgroundImage(selector.All);
                else view.EnsureSelectorData().BackgroundImage = new TriggerableSelector<string>(view, selector, view.SetBackgroundImage, true);
            }
            else
            {
                view.SetBackgroundImage((string)newValue);
            }
        }
        internal static object GetInternalBackgroundImageProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return (string)view.backgroundImageUrl;
        }


        /// <summary>
        /// BackgroundImageBorderProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageBorderProperty = null;

        internal static void SetInternalBackgroundImageBorderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;

            view.themeData?.selectorData?.BackgroundImageBorder?.Reset(view);

            if (newValue is Selector<Rectangle> selector)
            {
                if (selector.HasAll()) view.SetBackgroundImageBorder(selector.All);
                else view.EnsureSelectorData().BackgroundImageBorder = new TriggerableSelector<Rectangle>(view, selector, view.SetBackgroundImageBorder, true);
            }
            else
            {
                view.SetBackgroundImageBorder((Rectangle)newValue);
            }
        }
        internal static object GetInternalBackgroundImageBorderProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return view.backgroundExtraData?.BackgroundImageBorder;
        }

        /// <summary>
        /// BackgroundProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundProperty = null;

        internal static void SetInternalBackgroundProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                PropertyMap map = (PropertyMap)newValue;

                // Background extra data is not valid anymore. We should ignore lazy UpdateBackgroundExtraData
                view.backgroundExtraData = null;
                view.backgroundExtraDataUpdatedFlag = BackgroundExtraDataUpdatedFlag.None;

                // Update backgroundImageUrl and backgroundImageSynchronousLoading from Map
                foreach (int key in cachedNUIViewBackgroundImagePropertyKeyList)
                {
                    using PropertyValue propertyValue = map.Find(key);
                    if (propertyValue != null)
                    {
                        if (key == ImageVisualProperty.URL)
                        {
                            propertyValue.Get(out view.backgroundImageUrl);
                        }
                        else if (key == ImageVisualProperty.SynchronousLoading)
                        {
                            propertyValue.Get(out view.backgroundImageSynchronousLoading);
                        }
                    }
                }

                using var mapValue = new PropertyValue(map);
                Object.SetProperty(view.SwigCPtr, Property.BACKGROUND, mapValue);
            }
        }
        internal static object GetInternalBackgroundProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            // Sync as current properties
            view.UpdateBackgroundExtraData();

            PropertyMap tmp = new PropertyMap();
            var propertyValue = Object.GetProperty(view.SwigCPtr, Property.BACKGROUND);
            propertyValue.Get(tmp);
            propertyValue.Dispose();
            propertyValue = null;
            return tmp;
        }

        /// <summary>
        /// StateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StateProperty = null;

        internal static void SetInternalStateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.TOOLTIP, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalTooltipProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.TOOLTIP).Get(temp);
            return temp;
        }

        /// <summary>
        /// FlexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexProperty = null;

        internal static void SetInternalFlexProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector4(view.SwigCPtr, FlexContainer.ChildProperty.FlexMargin, ((Vector4)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalFlexMarginProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Object.InternalRetrievingPropertyVector4(view.SwigCPtr, FlexContainer.ChildProperty.FlexMargin, temp.SwigCPtr);
            return temp;
        }

        /// <summary>
        /// CellIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellIndexProperty = null;

        internal static void SetInternalCellIndexProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector2(view.SwigCPtr, TableView.ChildProperty.CellIndex, ((Vector2)newValue).SwigCPtr);
            }

        }
        internal static object GetInternalCellIndexProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalCellIndex == null)
            {
                view.internalCellIndex = new Vector2(view.OnCellIndexChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(view.SwigCPtr, TableView.ChildProperty.CellIndex, view.internalCellIndex.SwigCPtr);
            return view.internalCellIndex;

        }

        /// <summary>
        /// RowSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowSpanProperty = null;

        internal static void SetInternalRowSpanProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
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
            if (newValue != null) { view.LeftFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.LeftFocusableViewId = -1; }
        }
        internal static object GetInternalLeftFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.LeftFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.LeftFocusableViewId); }
            return null;
        }

        /// <summary>
        /// RightFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightFocusableViewProperty = null;

        internal static void SetInternalRightFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.RightFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.RightFocusableViewId = -1; }
        }
        internal static object GetInternalRightFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.RightFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.RightFocusableViewId); }
            return null;
        }

        /// <summary>
        /// UpFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UpFocusableViewProperty = null;

        internal static void SetInternalUpFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.UpFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.UpFocusableViewId = -1; }
        }
        internal static object GetInternalUpFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.UpFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.UpFocusableViewId); }
            return null;
        }

        /// <summary>
        /// DownFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DownFocusableViewProperty = null;

        internal static void SetInternalDownFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.DownFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.DownFocusableViewId = -1; }
        }
        internal static object GetInternalDownFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.DownFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.DownFocusableViewId); }
            return null;
        }

        /// <summary>
        /// ClockwiseFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ClockwiseFocusableViewProperty = null;

        internal static void SetInternalClockwiseFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null && (newValue is View)) { view.ClockwiseFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.ClockwiseFocusableViewId = -1; }
        }
        internal static object GetInternalClockwiseFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.ClockwiseFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.ClockwiseFocusableViewId); }
            return null;
        }

        /// <summary>
        /// CounterClockwiseFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CounterClockwiseFocusableViewProperty = null;

        internal static void SetInternalCounterClockwiseFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null && (newValue is View)) { view.CounterClockwiseFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.CounterClockwiseFocusableViewId = -1; }
        }
        internal static object GetInternalCounterClockwiseFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.CounterClockwiseFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.CounterClockwiseFocusableViewId); }
            return null;
        }

        /// <summary>
        /// FocusableProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableProperty = null;

        internal static void SetInternalFocusableProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.SetInternalFocusable((bool)newValue); }
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
            var view = (View)bindable;
            if (newValue != null) { view.SetInternalFocusableChildren((bool)newValue); }
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
            var view = (View)bindable;
            if (newValue != null) { view.SetInternalFocusableInTouch((bool)newValue); }
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
            var view = (View)bindable;
            if (newValue != null)
            {
                // Size property setter is only used by user.
                // Framework code uses SetSize() instead of Size property setter.
                // Size set by user is returned by GetUserSize2D() for SuggestedMinimumWidth/Height.
                // SuggestedMinimumWidth/Height is used by Layout calculation.
                int width = ((Size2D)newValue).Width;
                int height = ((Size2D)newValue).Height;
                view.userSizeWidth = (float)width;
                view.userSizeHeight = (float)height;

                if (view.HasLayoutWidth())
                    view.SetLayoutWidth(width);
                if (view.HasLayoutHeight())
                    view.SetLayoutHeight(height);

                bool relayoutRequired = false;
                // To avoid duplicated size setup, change internal policy directly.
                if (view.widthPolicy != width)
                {
                    view.widthPolicy = width;
                    relayoutRequired = true;
                }
                if (view.heightPolicy != height)
                {
                    view.heightPolicy = height;
                    relayoutRequired = true;
                }
                if (relayoutRequired)
                {
                    view.RequestLayout();
                }

                Object.InternalSetPropertyVector2ActualVector3(view.SwigCPtr, View.Property.SIZE, ((Size2D)newValue).SwigCPtr);
            }
        }

        internal static object GetInternalSize2DProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalSize2D == null)
            {
                view.internalSize2D = new Size2D(view.OnSize2DChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2ActualVector3(view.SwigCPtr, View.Property.SIZE, view.internalSize2D.SwigCPtr);

            return view.internalSize2D;
        }

        /// <summary>
        /// OpacityProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OpacityProperty = null;

        internal static void SetInternalOpacityProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;

            view.themeData?.selectorData?.Opacity?.Reset(view);

            if (newValue is Selector<float?> selector)
            {
                if (selector.HasAll()) view.SetOpacity(selector.All);
                else view.EnsureSelectorData().Opacity = new TriggerableSelector<float?>(view, selector, view.SetOpacity, true);
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
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector2ActualVector3(view.SwigCPtr, View.Property.POSITION, ((Position2D)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalPosition2DProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalPosition2D == null)
            {
                view.internalPosition2D = new Position2D(view.OnPosition2DChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2ActualVector3(view.SwigCPtr, View.Property.POSITION, view.internalPosition2D.SwigCPtr);
            return view.internalPosition2D;
        }

        /// <summary>
        /// PositionUsesPivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesPivotPointProperty = null;

        internal static void SetInternalPositionUsesPivotPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector3(view.SwigCPtr, View.Property.ParentOrigin, ((Position)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalParentOriginProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.ParentOrigin, temp.SwigCPtr);
            return temp;
        }


        /// <summary>
        /// PivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PivotPointProperty = null;

        internal static void SetInternalPivotPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetAnchorPoint((Position)newValue);
            }
        }
        internal static object GetInternalPivotPointProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalPivotPoint == null)
            {
                view.internalPivotPoint = new Position(view.OnPivotPointChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.AnchorPoint, view.internalPivotPoint.SwigCPtr);
            return view.internalPivotPoint;
        }

        /// <summary>
        /// SizeWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeWidthProperty = null;

        internal static void SetInternalSizeWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector3(view.SwigCPtr, View.Property.POSITION, ((Position)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalPositionProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalPosition == null)
            {
                view.internalPosition = new Position(view.OnPositionChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.POSITION, view.internalPosition.SwigCPtr);
            return view.internalPosition;
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
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ORIENTATION, new Tizen.NUI.PropertyValue((Rotation)newValue));
            }
        }
        internal static object GetInternalOrientationProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            Rotation temp = new Rotation();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ORIENTATION).Get(temp);
            return temp;
        }

        /// <summary>
        /// ScaleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleProperty = null;

        internal static void SetInternalScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetScale((Vector3)newValue);
            }

        }
        internal static object GetInternalScaleProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalScale == null)
            {
                view.internalScale = new Vector3(view.OnScaleChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.SCALE, view.internalScale.SwigCPtr);
            return view.internalScale;
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
            var view = (View)bindable;
            if (newValue != null)
            {
                view.internalName = (string)newValue;
                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.NAME, (string)newValue);
            }
        }
        internal static object GetInternalNameProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.internalName;
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
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.DispatchKeyEvents, (bool)newValue);
            }
        }
        internal static object GetInternalDispatchKeyEventsProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.DispatchKeyEvents);
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
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector3(view.SwigCPtr, View.Property.SizeModeFactor, ((Vector3)newValue).SwigCPtr);
            }

        }
        internal static object GetInternalSizeModeFactorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalSizeModeFactor == null)
            {
                view.internalSizeModeFactor = new Vector3(view.OnSizeModeFactorChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.SizeModeFactor, view.internalSizeModeFactor.SwigCPtr);
            return view.internalSizeModeFactor;
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
            var view = (View)bindable;
            if (newValue != null)
            {
                if (view.Layout != null)
                {
                    view.Layout.Padding = new Extents((Extents)newValue);
                    if ((view.Padding.Start != 0) || (view.Padding.End != 0) || (view.Padding.Top != 0) || (view.Padding.Bottom != 0))
                    {
                        var tmp = new PropertyValue(new Extents(0, 0, 0, 0));
                        Object.SetProperty(view.SwigCPtr, Property.PADDING, tmp);
                        tmp?.Dispose();
                    }
                    view.Layout.RequestLayout();
                }
                else
                {
                    var tmp = new PropertyValue((Extents)newValue);
                    Object.SetProperty(view.SwigCPtr, Property.PADDING, tmp);
                    tmp?.Dispose();
                }
            }
        }
        internal static object GetInternalPaddingProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if ((view.internalPadding == null) || (view.Layout != null))
            {
                ushort start = 0, end = 0, top = 0, bottom = 0;
                if (view.Layout != null)
                {
                    if (view.Layout.Padding != null)
                    {
                        start = view.Layout.Padding.Start;
                        end = view.Layout.Padding.End;
                        top = view.Layout.Padding.Top;
                        bottom = view.Layout.Padding.Bottom;
                    }
                }
                view.internalPadding = new Extents(view.OnPaddingChanged, start, end, top, bottom);
            }

            if (view.Layout == null)
            {
                var tmp = Object.GetProperty(view.SwigCPtr, Property.PADDING);
                tmp?.Get(view.internalPadding);
                tmp?.Dispose();
            }

            return view.internalPadding;
        }

        /// <summary>
        /// SizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeProperty = null;

        internal static void SetInternalSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                // Size property setter is only used by user.
                // Framework code uses SetSize() instead of Size property setter.
                // Size set by user is returned by GetUserSize2D() for SuggestedMinimumWidth/Height.
                // SuggestedMinimumWidth/Height is used by Layout calculation.
                float width = ((Size)newValue).Width;
                float height = ((Size)newValue).Height;
                float depth = ((Size)newValue).Depth;

                view.userSizeWidth = width;
                view.userSizeHeight = height;

                if (view.HasLayoutWidth())
                    view.SetLayoutWidth(width);
                if (view.HasLayoutHeight())
                    view.SetLayoutHeight(height);

                // Set Specification so when layouts measure this View it matches the value set here.
                // All Views are currently Layouts.
                int widthPolicy = (int)System.Math.Ceiling(width);
                int heightPolicy = (int)System.Math.Ceiling(height);

                bool relayoutRequired = false;
                // To avoid duplicated size setup, change internal policy directly.
                if (view.widthPolicy != widthPolicy)
                {
                    view.widthPolicy = widthPolicy;
                    relayoutRequired = true;
                }
                if (view.heightPolicy != heightPolicy)
                {
                    view.heightPolicy = heightPolicy;
                    relayoutRequired = true;
                }
                if (relayoutRequired)
                {
                    view.RequestLayout();
                }

                view.SetSize(width, height, depth);
            }
        }
        internal static object GetInternalSizeProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            if (view.internalSize == null)
            {
                view.internalSize = new Size(view.OnSizeChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.SIZE, view.internalSize.SwigCPtr);

            return view.internalSize;
        }

        /// <summary>
        /// MinimumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSizeProperty = null;

        internal static void SetInternalMinimumSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector2(view.SwigCPtr, View.Property.MinimumSize, ((Size2D)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalMinimumSizeProperty(BindableObject bindable)
        {

            var view = (View)bindable;
            if (view.internalMinimumSize == null)
            {
                view.internalMinimumSize = new Size2D(view.OnMinimumSizeChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(view.SwigCPtr, View.Property.MinimumSize, view.internalMinimumSize.SwigCPtr);
            return view.internalMinimumSize;
        }

        /// <summary>
        /// MaximumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaximumSizeProperty = null;

        internal static void SetInternalMaximumSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector2(view.SwigCPtr, View.Property.MaximumSize, ((Size2D)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalMaximumSizeProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            if (view.internalMaximumSize == null)
            {
                view.internalMaximumSize = new Size2D(view.OnMaximumSizeChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(view.SwigCPtr, View.Property.MaximumSize, view.internalMaximumSize.SwigCPtr);
            return view.internalMaximumSize;
        }

        /// <summary>
        /// InheritPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritPositionProperty = null;

        internal static void SetInternalInheritPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
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
            var view = (View)bindable;
            if (newValue != null)
            {
                if (view.Layout != null)
                {
                    view.Layout.Margin = new Extents((Extents)newValue);
                    if ((view.Margin.Start != 0) || (view.Margin.End != 0) || (view.Margin.Top != 0) || (view.Margin.Bottom != 0))
                    {
                        var tmp = new PropertyValue(new Extents(0, 0, 0, 0));
                        Object.SetProperty(view.SwigCPtr, Property.MARGIN, tmp);
                        tmp?.Dispose();
                    }
                    view.Layout.RequestLayout();
                }
                else
                {
                    var tmp = new PropertyValue((Extents)newValue);
                    Object.SetProperty(view.SwigCPtr, Property.MARGIN, tmp);
                    tmp?.Dispose();
                }
            }
        }
        internal static object GetInternalMarginProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if ((view.internalMargin == null) || (view.Layout != null))
            {
                ushort start = 0, end = 0, top = 0, bottom = 0;
                if (view.Layout != null)
                {
                    if (view.Layout.Margin != null)
                    {
                        start = view.Layout.Margin.Start;
                        end = view.Layout.Margin.End;
                        top = view.Layout.Margin.Top;
                        bottom = view.Layout.Margin.Bottom;
                    }
                }
                view.internalMargin = new Extents(view.OnMarginChanged, start, end, top, bottom);
            }

            if (view.Layout == null)
            {

                var tmp = Object.GetProperty(view.SwigCPtr, Property.MARGIN);
                tmp?.Get(view.internalMargin);
                tmp?.Dispose();
            }

            return view.internalMargin;
        }

        /// <summary>
        /// UpdateAreaHintProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UpdateAreaHintProperty = null;

        internal static void SetInternalUpdateAreaHintProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(view.SwigCPtr, Interop.ActorProperty.UpdateAreaHintGet(), ((Vector4)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalUpdateAreaHintProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);

            Object.InternalRetrievingPropertyVector4(view.SwigCPtr, Interop.ActorProperty.UpdateAreaHintGet(), temp.SwigCPtr);
            return temp;
        }

        /// <summary>
        /// ImageShadow Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageShadowProperty = null;

        internal static void SetInternalImageShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;

            view.themeData?.selectorData?.ClearShadow(view);

            if (newValue is Selector<ImageShadow> selector)
            {
                if (selector.HasAll()) view.SetShadow(selector.All);
                else view.EnsureSelectorData().ImageShadow = new TriggerableSelector<ImageShadow>(view, selector, view.SetShadow, true);
            }
            else
            {
                view.SetShadow((ImageShadow)newValue);
            }
        }
        internal static object GetInternalImageShadowProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            // Sync as current properties
            view.UpdateBackgroundExtraData();

            PropertyMap map = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SHADOW).Get(map);

            var shadow = new ImageShadow(map);
            return shadow.IsEmpty() ? null : shadow;
        }

        /// <summary>
        /// Shadow Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BoxShadowProperty = null;

        internal static void SetInternalBoxShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;

            view.themeData?.selectorData?.ClearShadow(view);

            if (newValue is Selector<Shadow> selector)
            {
                if (selector.HasAll()) view.SetShadow(selector.All);
                else view.EnsureSelectorData().BoxShadow = new TriggerableSelector<Shadow>(view, selector, view.SetShadow, true);
            }
            else
            {
                view.SetShadow((Shadow)newValue);
            }
        }
        internal static object GetInternalBoxShadowProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            // Sync as current properties
            view.UpdateBackgroundExtraData();

            PropertyMap map = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SHADOW).Get(map);

            var shadow = new Shadow(map);
            return shadow.IsEmpty() ? null : shadow;
        }

        /// <summary>
        /// CornerRadius Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusProperty = null;

        internal static void SetInternalCornerRadiusProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).CornerRadius = (Vector4)newValue;
            view.UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.CornerRadius);
        }
        internal static object GetInternalCornerRadiusProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? Vector4.Zero : view.backgroundExtraData.CornerRadius;
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

            view.themeData?.selectorData?.BorderlineColor?.Reset(view);

            if (newValue is Selector<Color> selector)
            {
                if (selector.HasAll()) view.SetBorderlineColor(selector.All);
                else view.EnsureSelectorData().BorderlineColor = new TriggerableSelector<Color>(view, selector, view.SetBorderlineColor, true);
            }
            else
            {
                view.SetBorderlineColor((Color)newValue);
            }
        }
        internal static object GetInternalBorderlineColorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? Color.Black : view.backgroundExtraData.BorderlineColor;
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

            view.themeData?.selectorData?.BorderlineColor?.Reset(view);

            if (newValue is Selector<Color> selector)
            {
                if (selector.HasAll()) view.SetBorderlineColor(selector.All);
                else view.EnsureSelectorData().BorderlineColor = new TriggerableSelector<Color>(view, selector, view.SetBorderlineColor, true);
            }
            else
            {
                view.SetBorderlineColor((Color)newValue);
            }
        }
        internal static object GetInternalBorderlineColorSelectorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            var selector = view.themeData?.selectorData?.BorderlineColor?.Get();
            return (null != selector) ? selector : new Selector<Color>();
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
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.AccessibilityName, (string)newValue);
            }
        }
        internal static object GetInternalAccessibilityNameProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.AccessibilityName);
        }

        /// <summary>
        /// AccessibilityDescriptionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityDescriptionProperty = null;

        internal static void SetInternalAccessibilityDescriptionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.AccessibilityDescription, (string)newValue);
            }
        }
        internal static object GetInternalAccessibilityDescriptionProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.AccessibilityDescription);
        }

        /// <summary>
        /// AccessibilityTranslationDomainProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityTranslationDomainProperty = null;

        internal static void SetInternalAccessibilityTranslationDomainProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.AccessibilityTranslationDomain, (string)newValue);
            }
        }
        internal static object GetInternalAccessibilityTranslationDomainProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.AccessibilityTranslationDomain);
        }

        /// <summary>
        /// AccessibilityRoleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityRoleProperty = null;

        internal static void SetInternalAccessibilityRoleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.AccessibilityRole, (int)newValue);
            }
        }
        internal static object GetInternalAccessibilityRoleProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return (Role)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.AccessibilityRole);
        }

        /// <summary>
        /// AccessibilityHighlightableProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityHighlightableProperty = null;

        internal static void SetInternalAccessibilityHighlightableProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHighlightable, (bool)newValue);
            }
        }
        internal static object GetInternalAccessibilityHighlightableProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHighlightable);
        }

        /// <summary>
        /// AccessibilityHiddenProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityHiddenProperty = null;

        internal static void SetInternalAccessibilityHiddenProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHidden, (bool)newValue);
            }
        }
        internal static object GetInternalAccessibilityHiddenProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHidden);
        }

        /// <summary>
        /// ExcludeLayoutingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExcludeLayoutingProperty = null;

        internal static void SetInternalExcludeLayoutingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (View)bindable;
            if (newValue != null)
            {
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
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalTooltipText = (string)newValue;
            }
        }
        internal static object GetInternalTooltipTextProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalTooltipText;
        }

        /// <summary>
        /// PositionUsesAnchorPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesAnchorPointProperty = null;

        internal static void SetInternalPositionUsesAnchorPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.SetInternalPositionUsesAnchorPoint((bool)newValue);
            }
        }
        internal static object GetInternalPositionUsesAnchorPointProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.GetInternalPositionUsesAnchorPoint();
        }

        /// <summary>
        /// AnchorPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnchorPointProperty = null;

        internal static void SetInternalAnchorPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalAnchorPoint = (Tizen.NUI.Position)newValue;
            }
        }
        internal static object GetInternalAnchorPointProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalAnchorPoint;
        }

        /// <summary>
        /// WidthSpecificationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthSpecificationProperty = null;

        internal static void SetInternalWidthSpecificationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.SetInternalWidthSpecification((int)newValue);
            }
        }
        internal static object GetInternalWidthSpecificationProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.GetInternalWidthSpecification();
        }

        /// <summary>
        /// HeightSpecificationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightSpecificationProperty = null;

        internal static void SetInternalHeightSpecificationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.SetInternalHeightSpecification((int)newValue);
            }
        }
        internal static object GetInternalHeightSpecificationProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.GetInternalHeightSpecification();
        }

        /// <summary>
        /// LayoutTransitionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutTransitionProperty = null;

        internal static void SetInternalLayoutTransitionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalLayoutTransition = (Tizen.NUI.LayoutTransition)newValue;
            }
        }
        internal static object GetInternalLayoutTransitionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalLayoutTransition;
        }

        /// <summary>
        /// PaddingEXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PaddingEXProperty = null;

        internal static void SetInternalPaddingEXProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalPaddingEX = (Tizen.NUI.Extents)newValue;
            }
        }
        internal static object GetInternalPaddingEXProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalPaddingEX;
        }

        /// <summary>
        /// LayoutProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutProperty = null;

        internal static void SetInternalLayoutProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalLayout = (Tizen.NUI.LayoutItem)newValue;
            }
        }
        internal static object GetInternalLayoutProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalLayout;
        }

        /// <summary>
        /// BackgroundImageSynchronosLoadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageSynchronosLoadingProperty = null;

        internal static void SetInternalBackgroundImageSynchronosLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.SetInternalBackgroundImageSynchronosLoading((bool)newValue);
            }
        }
        internal static object GetInternalBackgroundImageSynchronosLoadingProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.GetInternalBackgroundImageSynchronosLoading();
        }

        /// <summary>
        /// BackgroundImageSynchronousLoadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageSynchronousLoadingProperty = null;

        internal static void SetInternalBackgroundImageSynchronousLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.SetInternalBackgroundImageSynchronousLoading((bool)newValue);
            }
        }
        internal static object GetInternalBackgroundImageSynchronousLoadingProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.GetInternalBackgroundImageSynchronousLoading();
        }

        /// <summary>
        /// EnableControlStatePropagationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableControlStatePropagationProperty = null;

        internal static void SetInternalEnableControlStatePropagationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.SetInternalEnableControlStatePropagation((bool)newValue);
            }
        }
        internal static object GetInternalEnableControlStatePropagationProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.GetInternalEnableControlStatePropagation();
        }

        /// <summary>
        /// PropagatableControlStatesProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PropagatableControlStatesProperty = null;

        internal static void SetInternalPropagatableControlStatesProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalPropagatableControlStates = (ControlState)newValue;
            }
        }
        internal static object GetInternalPropagatableControlStatesProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalPropagatableControlStates;
        }

        /// <summary>
        /// GrabTouchAfterLeaveProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabTouchAfterLeaveProperty = null;

        internal static void SetInternalGrabTouchAfterLeaveProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.SetInternalGrabTouchAfterLeave((bool)newValue);
            }
        }
        internal static object GetInternalGrabTouchAfterLeaveProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.GetInternalGrabTouchAfterLeave();
        }

        /// <summary>
        /// AllowOnlyOwnTouchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AllowOnlyOwnTouchProperty = null;

        internal static void SetInternalAllowOnlyOwnTouchProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.SetInternalAllowOnlyOwnTouch((bool)newValue);
            }
        }
        internal static object GetInternalAllowOnlyOwnTouchProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.GetInternalAllowOnlyOwnTouch();
        }

        /// <summary>
        /// BlendEquationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BlendEquationProperty = null;

        internal static void SetInternalBlendEquationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.SetInternalBlendEquation((BlendEquationType)newValue);
            }
        }
        internal static object GetInternalBlendEquationProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.GetInternalBlendEquation();
        }

        /// <summary>
        /// TransitionOptionsProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TransitionOptionsProperty = null;

        internal static void SetInternalTransitionOptionsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalTransitionOptions = (Tizen.NUI.TransitionOptions)newValue;
            }
        }
        internal static object GetInternalTransitionOptionsProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalTransitionOptions;
        }

        /// <summary>
        /// AutomationIdProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutomationIdProperty = null;

        internal static void SetInternalAutomationIdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(instance.SwigCPtr, View.Property.AutomationId, (string)newValue);
            }
        }
        internal static object GetInternalAutomationIdProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;

            return Object.InternalGetPropertyString(instance.SwigCPtr, View.Property.AutomationId);
        }

        /// <summary>
        /// TouchAreaOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TouchAreaOffsetProperty = null;

        internal static void SetInternalTouchAreaOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalTouchAreaOffset = (Tizen.NUI.Offset)newValue;
            }
        }
        internal static object GetInternalTouchAreaOffsetProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalTouchAreaOffset;
        }

        /// <summary>
        /// DispatchTouchMotionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DispatchTouchMotionProperty = null;

        internal static void SetInternalDispatchTouchMotionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalDispatchTouchMotion = (bool)newValue;
            }
        }
        internal static object GetInternalDispatchTouchMotionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalDispatchTouchMotion;
        }

        /// <summary>
        /// DispatchHoverMotionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DispatchHoverMotionProperty = null;

        internal static void SetInternalDispatchHoverMotionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalDispatchHoverMotion = (bool)newValue;
            }
        }

        internal static object GetInternalDispatchHoverMotionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalDispatchHoverMotion;
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
                backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

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
            if (backgroundExtraData == null && !backgroundImageSynchronousLoading)
            {
                Object.InternalSetPropertyString(SwigCPtr, View.Property.BACKGROUND, value);
                return;
            }

            using var map = new PropertyMap();

            map.Add(ImageVisualProperty.URL, value)
               .Add(ImageVisualProperty.SynchronousLoading, backgroundImageSynchronousLoading);

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
                   .Add(Visual.Property.CornerRadiusPolicy, (int)backgroundExtraData.CornerRadiusPolicy)
                   .Add(Visual.Property.BorderlineWidth, backgroundExtraData.BorderlineWidth)
                   .Add(Visual.Property.BorderlineColor, backgroundExtraData.BorderlineColor == null ? Color.Black : backgroundExtraData.BorderlineColor)
                   .Add(Visual.Property.BorderlineOffset, backgroundExtraData.BorderlineOffset);
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

            map[NpatchImageVisualProperty.Border] = new PropertyValue(backgroundImageBorder);

            int visualType = 0;

            map.Find(Visual.Property.Type)?.Get(out visualType);

            if (visualType == (int)Visual.Type.Image)
            {
                map[Visual.Property.Type] = new PropertyValue((int)Visual.Type.NPatch);
            }

            // Background extra data flag is not meanful anymore.
            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

            Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.BACKGROUND, new PropertyValue(map));
        }

        private void SetBorderlineColor(Color value)
        {
            if (value == null)
            {
                return;
            }

            (backgroundExtraData ?? (backgroundExtraData = new BackgroundExtraData())).BorderlineColor = value;

            UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.Borderline);
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
               .Add(ColorVisualProperty.MixColor, value)
               .Add(Visual.Property.CornerRadius, backgroundExtraData.CornerRadius)
               .Add(Visual.Property.CornerSquareness, backgroundExtraData.CornerSquareness)
               .Add(Visual.Property.CornerRadiusPolicy, (int)(backgroundExtraData.CornerRadiusPolicy))
               .Add(Visual.Property.BorderlineWidth, backgroundExtraData.BorderlineWidth)
               .Add(Visual.Property.BorderlineColor, backgroundExtraData.BorderlineColor == null ? Color.Black : backgroundExtraData.BorderlineColor)
               .Add(Visual.Property.BorderlineOffset, backgroundExtraData.BorderlineOffset);

            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

            var mapValue = new PropertyValue(map);
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
            Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.SHADOW, value == null ? new PropertyValue() : value.ToPropertyValue(this));
        }
    }
}
