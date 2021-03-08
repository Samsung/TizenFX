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

namespace Tizen.NUI
{
    /// <summary>
    /// RelativeLayout calculates the size and position of all the children based on their relationship to each other.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class RelativeLayout : LayoutGroup
    {
        /// <summary>
        /// LeftTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeftTargetProperty = BindableProperty.CreateAttached("LeftTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// RightTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightTargetProperty = BindableProperty.CreateAttached("RightTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// TopTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TopTargetProperty = BindableProperty.CreateAttached("TopTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// BottomTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BottomTargetProperty = BindableProperty.CreateAttached("BottomTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// LeftRelativeOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeftRelativeOffsetProperty = BindableProperty.CreateAttached("LeftRelativeOffset", typeof(float), typeof(RelativeLayout), 0.0f, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// RightRelativeOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightRelativeOffsetProperty = BindableProperty.CreateAttached("RightRelativeOffset", typeof(float), typeof(RelativeLayout), 0.0f, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// TopRelativeOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TopRelativeOffsetProperty = BindableProperty.CreateAttached("TopRelativeOffset", typeof(float), typeof(RelativeLayout), 0.0f, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// BottomRelativeOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BottomRelativeOffsetProperty = BindableProperty.CreateAttached("BottomRelativeOffset", typeof(float), typeof(RelativeLayout), 0.0f, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// HorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.CreateAttached("HorizontalAlignment", typeof(Alignment), typeof(RelativeLayout), default(Alignment), propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// VerticalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.CreateAttached("VerticalAlignment", typeof(Alignment), typeof(RelativeLayout), default(Alignment), propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// FillHorizontalProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FillHorizontalProperty = BindableProperty.CreateAttached("FillHorizontal", typeof(bool), typeof(RelativeLayout), false, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// FillVerticalProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FillVerticalProperty = BindableProperty.CreateAttached("FillVertical", typeof(bool), typeof(RelativeLayout), false, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public RelativeLayout() { }

        /// <summary>
        /// Gets left target object whose size and position is being used as reference.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The object whose size and position is being used as reference.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetLeftTarget(BindableObject view) => GetAttachedValue<View>(view, LeftTargetProperty);

        /// <summary>
        /// Gets right target object whose size and position is being used as reference.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The object whose size and position is being used as reference.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetRightTarget(BindableObject view) => GetAttachedValue<View>(view, RightTargetProperty);

        /// <summary>
        /// Gets top target object whose size and position is being used as reference.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The object whose size and position is being used as reference.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetTopTarget(BindableObject view) => GetAttachedValue<View>(view, TopTargetProperty);

        /// <summary>
        /// Gets bottom target object whose size and position is being used as reference.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The object whose size and position is being used as reference.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetBottomTarget(BindableObject view) => GetAttachedValue<View>(view, BottomTargetProperty);

        /// <summary>
        /// Gets left relative offset.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The ratio between left and right of the <seealso cref="LeftTargetProperty"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static float GetLeftRelativeOffset(View view) => GetAttachedValue<float>(view, LeftRelativeOffsetProperty);

        /// <summary>
        /// Gets right relative offset.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The ratio between left and right of the <seealso cref="RightTargetProperty"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static float GetRightRelativeOffset(View view) => GetAttachedValue<float>(view, RightRelativeOffsetProperty);

        /// <summary>
        /// Gets top relative offset.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The ratio between top and bottom of the <seealso cref="TopTargetProperty"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static float GetTopRelativeOffset(View view) => GetAttachedValue<float>(view, TopRelativeOffsetProperty);

        /// <summary>
        /// Gets bottom relative offset.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The ratio between top and bottom of the <seealso cref="BottomTargetProperty"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static float GetBottomRelativeOffset(View view) => GetAttachedValue<float>(view, BottomRelativeOffsetProperty);

        /// <summary>
        /// Gets the horizontal alignment
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The horizontal alignment of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static Alignment GetHorizontalAlignment(View view) => GetAttachedValue<Alignment>(view, HorizontalAlignmentProperty);

        /// <summary>
        /// Gets the vertical alignment
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The vertical alignment of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static Alignment GetVerticalAlignment(View view) => GetAttachedValue<Alignment>(view, VerticalAlignmentProperty);

        /// <summary>
        /// Gets the boolean value whether child fills its horizontal space.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>True if to fill the space, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static bool GetFillHorizontal(View view) => GetAttachedValue<bool>(view, FillHorizontalProperty);

        /// <summary>
        /// Gets the boolean value whether child fills its vertical space.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>True if to fill the space, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static bool GetFillVertical(View view) => GetAttachedValue<bool>(view, FillVerticalProperty);

        /// <summary>
        /// Specifies the left side edge of the child view relative to the target view. <br/>
        /// null <paramref name="reference"/> means parent relative layout.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="reference">The object whose size and position is being used as reference.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetLeftTarget(View view, View reference) => SetAttachedValue(view, LeftTargetProperty, reference);

        /// <summary>
        /// Specifies the right side edge of the child view relative to the target view. <br/>
        /// null <paramref name="reference"/> means parent relative layout.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="reference">The object whose size and position is being used as reference.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetRightTarget(View view, View reference) => SetAttachedValue(view, RightTargetProperty, reference);

        /// <summary>
        /// Specifies the top side edge of the child view relative to the target view. <br/>
        /// null <paramref name="reference"/> means parent relative layout.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="reference">The object whose size and position is being used as reference.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetTopTarget(View view, View reference) => SetAttachedValue(view, TopTargetProperty, reference);

        /// <summary>
        /// Specifies the bottom side edge of the child view relative to the target view. <br/>
        /// null <paramref name="reference"/> means parent relative layout.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="reference">The object whose size and position is being used as reference.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetBottomTarget(View view, View reference) => SetAttachedValue(view, BottomTargetProperty, reference);

        /// <summary>
        /// Sets the relative offset for left target.
        /// When <paramref name="value"/> is 0 the left edges of the left target and <paramref name="view"/> are aligned.<br/>
        /// When <paramref name="value"/> is 1 the left edge of the <paramref name="view"/> is aligned to the right edge of the left target.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="value">The ratio between left and right of the <seealso cref="LeftTargetProperty"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetLeftRelativeOffset(View view, float value) => SetAttachedValue(view, LeftRelativeOffsetProperty, value);

        /// <summary>
        /// Sets the relative offset for right target.
        /// When <paramref name="value"/> is 0 the right edge of the <paramref name="view"/> is aligned to the left edge of the right target.<br/>
        /// When <paramref name="value"/> is 1 the right edges of the right target and <paramref name="view"/> are aligned.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="value">The ratio between left and right of the <seealso cref="RightTargetProperty"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetRightRelativeOffset(View view, float value) => SetAttachedValue(view, RightRelativeOffsetProperty, value);

        /// <summary>
        /// Sets the relative offset for top target.
        /// When <paramref name="value"/> is 0 the top edges of the top target and <paramref name="view"/> are aligned.<br/>
        /// When <paramref name="value"/> is 1 the top edge of the <paramref name="view"/> is aligned to the bottom edge of the top target.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="value">The ratio between left and right of the <seealso cref="TopTargetProperty"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetTopRelativeOffset(View view, float value) => SetAttachedValue(view, TopRelativeOffsetProperty, value);

        /// <summary>
        /// Sets the relative offset for bottom target.
        /// When <paramref name="value"/> is 0 the bottom edge of the <paramref name="view"/> is aligned to the top edge of the bottom target.<br/>
        /// When <paramref name="value"/> is 1 the bottom edges of the bottom target and <paramref name="view"/> are aligned.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="value">The ratio between left and right of the <seealso cref="BottomTargetProperty"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetBottomRelativeOffset(View view, float value) => SetAttachedValue(view, BottomRelativeOffsetProperty, value);

        /// <summary>
        /// Sets the horizontal alignment of this child view.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The horizontal alignment of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetHorizontalAlignment(View view, Alignment value) => SetAttachedValue(view, HorizontalAlignmentProperty, value);

        /// <summary>
        /// Sets the vertical alignment of this child view.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The vertical alignment of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetVerticalAlignment(View view, Alignment value) => SetAttachedValue(view, VerticalAlignmentProperty, value);

        /// <summary>
        /// Sets the boolean value whether child fills its horizontal space.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">True if to fill the space, false otherwise.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetFillHorizontal(View view, bool value) => SetAttachedValue(view, FillHorizontalProperty, value);

        /// <summary>
        /// Sets the boolean value whether child fills its vertical space.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">True if to fill the space, false otherwise.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetFillVertical(View view, bool value) => SetAttachedValue(view, FillVerticalProperty, value);

        /// <inheritdoc/>
        /// <since_tizen> 9 </since_tizen>
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
            MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

            for (int i = 0; i < LayoutChildren.Count; i++)
            {
                LayoutItem childLayout = LayoutChildren[i];
                if (childLayout != null)
                {
                    MeasureChildWithMargins(childLayout, widthMeasureSpec, new LayoutLength(0), heightMeasureSpec, new LayoutLength(0));

                    if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                    {
                        childWidthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                    }
                    if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                    {
                        childHeightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                    }
                }
            }

            (float childrenWidth, float childrenHeight) = CalculateChildrenSize(widthMeasureSpec.Size.AsDecimal(), heightMeasureSpec.Size.AsDecimal());
            SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(childrenWidth), widthMeasureSpec, childWidthState),
                                  ResolveSizeAndState(new LayoutLength(childrenHeight), heightMeasureSpec, childHeightState));
        }

        /// <inheritdoc/>
        /// <since_tizen> 9 </since_tizen>
        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            for (int i = 0; i < LayoutChildren.Count; i++)
            {
                LayoutItem childLayout = LayoutChildren[i];
                if (childLayout != null)
                {
                    Geometry horizontalGeometry = GetHorizontalLayout(childLayout.Owner);
                    Geometry verticalGeometry = GetVerticalLayout(childLayout.Owner);

                    LayoutLength childLeft = new LayoutLength(horizontalGeometry.Position + Padding.Start + childLayout.Margin.Start);
                    LayoutLength childRight = new LayoutLength(horizontalGeometry.Position + horizontalGeometry.Size + Padding.Start - childLayout.Margin.End);
                    LayoutLength childTop = new LayoutLength(verticalGeometry.Position + Padding.Top + childLayout.Margin.Top);
                    LayoutLength childBottom = new LayoutLength(verticalGeometry.Position + verticalGeometry.Size + Padding.Top - childLayout.Margin.Bottom);
                    childLayout.Layout(childLeft, childTop, childRight, childBottom);
                }
            }
            HorizontalRelativeCache.Clear();
            VerticalRelativeCache.Clear();
        }

        /// <summary>The alignment of the relative layout child.</summary>
        /// <since_tizen> 9 </since_tizen>
        public enum Alignment
        {
            /// <summary>At the start of the container.</summary>
            /// <since_tizen> 9 </since_tizen>
            Start = 0,
            /// <summary>At the center of the container.</summary>
            /// <since_tizen> 9 </since_tizen>
            Center = 1,
            /// <summary>At the end of the container.</summary>
            /// <since_tizen> 9 </since_tizen>
            End = 2,
        }
    }

    // Extension Method of RelativeLayout.Alignment.
    internal static partial class RelativeLayoutAlignmentExtension
    {
        public static float ToFloat(this RelativeLayout.Alignment align)
        {
            return 0.5f * (float)align;
        }
    }
}
