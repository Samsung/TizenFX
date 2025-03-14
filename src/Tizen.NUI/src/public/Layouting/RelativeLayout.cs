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
using System.Collections.Generic;
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
        public static readonly BindableProperty LeftTargetProperty = null;

        /// <summary>
        /// RightTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightTargetProperty = null;

        /// <summary>
        /// TopTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TopTargetProperty = null;

        /// <summary>
        /// BottomTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BottomTargetProperty = null;

        /// <summary>
        /// LeftRelativeOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeftRelativeOffsetProperty = null;

        /// <summary>
        /// RightRelativeOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightRelativeOffsetProperty = null;

        /// <summary>
        /// TopRelativeOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TopRelativeOffsetProperty = null;

        /// <summary>
        /// BottomRelativeOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BottomRelativeOffsetProperty = null;

        /// <summary>
        /// HorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;

        /// <summary>
        /// VerticalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = null;

        /// <summary>
        /// FillHorizontalProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FillHorizontalProperty = null;

        /// <summary>
        /// FillVerticalProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FillVerticalProperty = null;

        private static Dictionary<View, View> leftTargetMap = null;
        private static Dictionary<View, View> rightTargetMap = null;
        private static Dictionary<View, View> topTargetMap = null;
        private static Dictionary<View, View> bottomTargetMap = null;
        private static Dictionary<View, float> leftRelativeOffsetMap = null;
        private static Dictionary<View, float> rightRelativeOffsetMap = null;
        private static Dictionary<View, float> topRelativeOffsetMap = null;
        private static Dictionary<View, float> bottomRelativeOffsetMap = null;
        private static Dictionary<View, Alignment> horizontalAlignmentMap = null;
        private static Dictionary<View, Alignment> verticalAlignmentMap = null;
        private static Dictionary<View, bool> fillHorizontalMap = null;
        private static Dictionary<View, bool> fillVerticalMap = null;

        static RelativeLayout()
        {
            if (NUIApplication.IsUsingXaml)
            {
                LeftTargetProperty = BindableProperty.CreateAttached("LeftTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);
                RightTargetProperty = BindableProperty.CreateAttached("RightTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);
                TopTargetProperty = BindableProperty.CreateAttached("TopTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);
                BottomTargetProperty = BindableProperty.CreateAttached("BottomTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);
                LeftRelativeOffsetProperty = BindableProperty.CreateAttached("LeftRelativeOffset", typeof(float), typeof(RelativeLayout), 0.0f, propertyChanged: OnChildPropertyChanged);
                RightRelativeOffsetProperty = BindableProperty.CreateAttached("RightRelativeOffset", typeof(float), typeof(RelativeLayout), 1.0f, propertyChanged: OnChildPropertyChanged);
                TopRelativeOffsetProperty = BindableProperty.CreateAttached("TopRelativeOffset", typeof(float), typeof(RelativeLayout), 0.0f, propertyChanged: OnChildPropertyChanged);
                BottomRelativeOffsetProperty = BindableProperty.CreateAttached("BottomRelativeOffset", typeof(float), typeof(RelativeLayout), 1.0f, propertyChanged: OnChildPropertyChanged);
                HorizontalAlignmentProperty = BindableProperty.CreateAttached("HorizontalAlignment", typeof(Alignment), typeof(RelativeLayout), default(Alignment), propertyChanged: OnChildPropertyChanged);
                VerticalAlignmentProperty = BindableProperty.CreateAttached("VerticalAlignment", typeof(Alignment), typeof(RelativeLayout), default(Alignment), propertyChanged: OnChildPropertyChanged);
                FillHorizontalProperty = BindableProperty.CreateAttached("FillHorizontal", typeof(bool), typeof(RelativeLayout), false, propertyChanged: OnChildPropertyChanged);
                FillVerticalProperty = BindableProperty.CreateAttached("FillVertical", typeof(bool), typeof(RelativeLayout), false, propertyChanged: OnChildPropertyChanged);
            }
            else
            {
                leftTargetMap = new Dictionary<View, View>();
                rightTargetMap = new Dictionary<View, View>();
                topTargetMap = new Dictionary<View, View>();
                bottomTargetMap = new Dictionary<View, View>();
                leftRelativeOffsetMap = new Dictionary<View, float>();
                rightRelativeOffsetMap = new Dictionary<View, float>();
                topRelativeOffsetMap = new Dictionary<View, float>();
                bottomRelativeOffsetMap = new Dictionary<View, float>();
                horizontalAlignmentMap = new Dictionary<View, Alignment>();
                verticalAlignmentMap = new Dictionary<View, Alignment>();
                fillHorizontalMap = new Dictionary<View, bool>();
                fillVerticalMap = new Dictionary<View, bool>();
            }
        }

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
        public static View GetLeftTarget(BindableObject view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<View>(view, LeftTargetProperty);
            }
            else
            {
                if (leftTargetMap.TryGetValue((View)view, out var leftTarget))
                {
                    return leftTarget;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets right target object whose size and position is being used as reference.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The object whose size and position is being used as reference.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetRightTarget(BindableObject view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<View>(view, RightTargetProperty);
            }
            else
            {
                if (rightTargetMap.TryGetValue((View)view, out var rightTarget))
                {
                    return rightTarget;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets top target object whose size and position is being used as reference.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The object whose size and position is being used as reference.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetTopTarget(BindableObject view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<View>(view, TopTargetProperty);
            }
            else
            {
                if (topTargetMap.TryGetValue((View)view, out var topTarget))
                {
                    return topTarget;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets bottom target object whose size and position is being used as reference.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The object whose size and position is being used as reference.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetBottomTarget(BindableObject view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<View>(view, BottomTargetProperty);
            }
            else
            {
                if (bottomTargetMap.TryGetValue((View)view, out var bottomTarget))
                {
                    return bottomTarget;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets left relative offset.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The ratio between left and right of the <seealso cref="LeftTargetProperty"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static float GetLeftRelativeOffset(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<float>(view, LeftRelativeOffsetProperty);
            }
            else
            {
                if (leftRelativeOffsetMap.TryGetValue(view, out var leftRelativeOffset))
                {
                    return leftRelativeOffset;
                }
                else
                {
                    return 0.0f;
                }
            }
        }

        /// <summary>
        /// Gets right relative offset.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The ratio between left and right of the <seealso cref="RightTargetProperty"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static float GetRightRelativeOffset(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<float>(view, RightRelativeOffsetProperty);
            }
            else
            {
                if (rightRelativeOffsetMap.TryGetValue(view, out var rightRelativeOffset))
                {
                    return rightRelativeOffset;
                }
                else
                {
                    return 1.0f;
                }
            }
        }

        /// <summary>
        /// Gets top relative offset.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The ratio between top and bottom of the <seealso cref="TopTargetProperty"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static float GetTopRelativeOffset(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<float>(view, TopRelativeOffsetProperty);
            }
            else
            {
                if (topRelativeOffsetMap.TryGetValue(view, out var topRelativeOffset))
                {
                    return topRelativeOffset;
                }
                else
                {
                    return 0.0f;
                }
            }
        }

        /// <summary>
        /// Gets bottom relative offset.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <returns>The ratio between top and bottom of the <seealso cref="BottomRelativeOffsetProperty"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static float GetBottomRelativeOffset(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<float>(view, BottomRelativeOffsetProperty);
            }
            else
            {
                if (bottomRelativeOffsetMap.TryGetValue(view, out var bottomRelativeOffset))
                {
                    return bottomRelativeOffset;
                }
                else
                {
                    return 1.0f;
                }
            }
        }

        /// <summary>
        /// Gets the horizontal alignment
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The horizontal alignment of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static Alignment GetHorizontalAlignment(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<Alignment>(view, HorizontalAlignmentProperty);
            }
            else
            {
                if (horizontalAlignmentMap.TryGetValue(view, out var horizontalAlignment))
                {
                    return horizontalAlignment;
                }
                else
                {
                    return Alignment.Start;
                }
            }
        }

        /// <summary>
        /// Gets the vertical alignment
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The vertical alignment of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static Alignment GetVerticalAlignment(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<Alignment>(view, VerticalAlignmentProperty);
            }
            else
            {
                if (verticalAlignmentMap.TryGetValue(view, out var verticalAlignment))
                {
                    return verticalAlignment;
                }
                else
                {
                    return Alignment.Start;
                }
            }
        }

        /// <summary>
        /// Gets the boolean value whether child fills its horizontal space.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>True if to fill the space, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static bool GetFillHorizontal(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<bool>(view, FillHorizontalProperty);
            }
            else
            {
                if (fillHorizontalMap.TryGetValue(view, out var fillHorizontal))
                {
                    return fillHorizontal;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets the boolean value whether child fills its vertical space.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>True if to fill the space, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static bool GetFillVertical(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<bool>(view, FillVerticalProperty);
            }
            else
            {
                if (fillVerticalMap.TryGetValue(view, out var fillVertical))
                {
                    return fillVertical;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Specifies the left side edge of the child view relative to the target view. <br/>
        /// null <paramref name="reference"/> means parent relative layout.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="reference">The object whose size and position is being used as reference.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetLeftTarget(View view, View reference)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, LeftTargetProperty, reference);
            }
            else
            {
                leftTargetMap[view] = reference;
                OnChildPropertyChanged(view, null, reference);
            }
        }

        /// <summary>
        /// Specifies the right side edge of the child view relative to the target view. <br/>
        /// null <paramref name="reference"/> means parent relative layout.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="reference">The object whose size and position is being used as reference.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetRightTarget(View view, View reference)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, RightTargetProperty, reference);
            }
            else
            {
                rightTargetMap[view] = reference;
                OnChildPropertyChanged(view, null, reference);
            }
        }

        /// <summary>
        /// Specifies the top side edge of the child view relative to the target view. <br/>
        /// null <paramref name="reference"/> means parent relative layout.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="reference">The object whose size and position is being used as reference.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetTopTarget(View view, View reference)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, TopTargetProperty, reference);
            }
            else
            {
                topTargetMap[view] = reference;
                OnChildPropertyChanged(view, null, reference);
            }
        }

        /// <summary>
        /// Specifies the bottom side edge of the child view relative to the target view. <br/>
        /// null <paramref name="reference"/> means parent relative layout.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="reference">The object whose size and position is being used as reference.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetBottomTarget(View view, View reference)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, BottomTargetProperty, reference);
            }
            else
            {
                bottomTargetMap[view] = reference;
                OnChildPropertyChanged(view, null, reference);
            }
        }

        /// <summary>
        /// Sets the relative offset for left target.
        /// When <paramref name="value"/> is 0 the left edges of the left target and <paramref name="view"/> are aligned.<br/>
        /// When <paramref name="value"/> is 1 the left edge of the <paramref name="view"/> is aligned to the right edge of the left target.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="value">The ratio between left and right of the <seealso cref="LeftTargetProperty"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetLeftRelativeOffset(View view, float value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, LeftRelativeOffsetProperty, value);
            }
            else
            {
                leftRelativeOffsetMap[view] = value;
                OnChildPropertyChanged(view, null, value);
            }
        }

        /// <summary>
        /// Sets the relative offset for right target.
        /// When <paramref name="value"/> is 0 the right edge of the <paramref name="view"/> is aligned to the left edge of the right target.<br/>
        /// When <paramref name="value"/> is 1 the right edges of the right target and <paramref name="view"/> are aligned.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="value">The ratio between left and right of the <seealso cref="RightTargetProperty"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetRightRelativeOffset(View view, float value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, RightRelativeOffsetProperty, value);
            }
            else
            {
                rightRelativeOffsetMap[view] = value;
                OnChildPropertyChanged(view, null, value);
            }
        }

        /// <summary>
        /// Sets the relative offset for top target.
        /// When <paramref name="value"/> is 0 the top edges of the top target and <paramref name="view"/> are aligned.<br/>
        /// When <paramref name="value"/> is 1 the top edge of the <paramref name="view"/> is aligned to the bottom edge of the top target.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="value">The ratio between left and right of the <seealso cref="TopTargetProperty"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetTopRelativeOffset(View view, float value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, TopRelativeOffsetProperty, value);
            }
            else
            {
                topRelativeOffsetMap[view] = value;
                OnChildPropertyChanged(view, null, value);
            }
        }

        /// <summary>
        /// Sets the relative offset for bottom target.
        /// When <paramref name="value"/> is 0 the bottom edge of the <paramref name="view"/> is aligned to the top edge of the bottom target.<br/>
        /// When <paramref name="value"/> is 1 the bottom edges of the bottom target and <paramref name="view"/> are aligned.
        /// </summary>
        /// <param name="view">The child view whose size and position is being changed.</param>
        /// <param name="value">The ratio between left and right of the <seealso cref="BottomRelativeOffsetProperty"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetBottomRelativeOffset(View view, float value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, BottomRelativeOffsetProperty, value);
            }
            else
            {
                bottomRelativeOffsetMap[view] = value;
                OnChildPropertyChanged(view, null, value);
            }
        }

        /// <summary>
        /// Sets the horizontal alignment of this child view.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The horizontal alignment of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetHorizontalAlignment(View view, Alignment value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, HorizontalAlignmentProperty, value);
            }
            else
            {
                horizontalAlignmentMap[view] = value;
                OnChildPropertyChanged(view, null, value);
            }
        }

        /// <summary>
        /// Sets the vertical alignment of this child view.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The vertical alignment of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetVerticalAlignment(View view, Alignment value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, VerticalAlignmentProperty, value);
            }
            else
            {
                verticalAlignmentMap[view] = value;
                OnChildPropertyChanged(view, null, value);
            }
        }

        /// <summary>
        /// Sets the boolean value whether child fills its horizontal space.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">True if to fill the space, false otherwise.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetFillHorizontal(View view, bool value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, FillHorizontalProperty, value);
            }
            else
            {
                fillHorizontalMap[view] = value;
                OnChildPropertyChanged(view, null, value);
            }
        }

        /// <summary>
        /// Sets the boolean value whether child fills its vertical space.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">True if to fill the space, false otherwise.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void SetFillVertical(View view, bool value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, FillVerticalProperty, value);
            }
            else
            {
                fillVerticalMap[view] = value;
                OnChildPropertyChanged(view, null, value);
            }
        }

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

            // There are 2 cases which require to calculate children's MeasuredWidth/Height as follows.
            //
            // 1. Text with Ellipsis true
            //    TextLabel and TextField calculate MeasuredWidth/Height to cover their text string if they have WrapContent.
            //    This causes children's Ellipsis cannot be displayed with RelativeLayout.
            //    To resolve the above, RelativeLayout recalculates its children's MeasuredWidth/Height based on the children's space calculated by RelativeLayout APIs.
            //
            // 2. FillHorizontal/Vertical true
            //    If children set FillHorizontal/Vertical true, then children's MeasuredWidth/Height are not correctly alculated.
            //    Instead, children's size and position are correctly calculated in OnLayout().
            //    This causes that the grand children's MeasuredWidth/Height are calculated incorrectly.
            //    To resolve the above, RelativeLayout calculates its children's MeasuredWidth/Height based on the children's geometry calculated by RelativeLayout APIs.
            //
            //    e.g.
            //    Let parent have RelativeLayout and parent's size be 1920x1080.
            //    Let child have WrapContent with SetFillHorizontal/Vertical true.
            //    Let grand child have MatchParent.
            //    Then, child's size is 1920x1080 but child's MeasuredWidth/Height is 0x0.
            //    Then, grand child's MeasuredWidth/Height is 0x0 and size is 0x0.
            //
            // TODO: Not to do duplicate operations in OnLayout() again.
            bool needClearCache = false;

            for (int i = 0; i < LayoutChildren.Count; i++)
            {
                LayoutItem childLayout = LayoutChildren[i];
                if (childLayout != null)
                {
                    bool ellipsisTextWidth = false;
                    bool ellipsisTextHeight = false;
                    bool needMeasuredWidth = false;
                    bool needMeasuredHeight = false;

                    if (((childLayout.Owner is TextLabel textLabel) && textLabel.Ellipsis) || ((childLayout.Owner is TextField textField) && textField.Ellipsis))
                    {
                        Geometry horizontalSpace = GetHorizontalSpace(childLayout.Owner);
                        if (!horizontalSpace.Size.Equals(0))
                        {
                            ellipsisTextWidth = true;
                            needClearCache = true;
                        }

                        Geometry verticalSpace = GetVerticalSpace(childLayout.Owner);
                        if (!verticalSpace.Size.Equals(0))
                        {
                            ellipsisTextHeight = true;
                            needClearCache = true;
                        }
                    }

                    if (!ellipsisTextWidth && RelativeLayout.GetFillHorizontal(childLayout.Owner))
                    {
                        needMeasuredWidth = true;
                        needClearCache = true;
                    }

                    if (!ellipsisTextHeight && RelativeLayout.GetFillVertical(childLayout.Owner))
                    {
                        needMeasuredHeight = true;
                        needClearCache = true;
                    }

                    if ((ellipsisTextWidth == false) && (ellipsisTextHeight == false) && (needMeasuredWidth == false) && (needMeasuredHeight == false))
                    {
                        continue;
                    }

                    float width = childLayout.MeasuredWidth.Size.AsDecimal();
                    float height = childLayout.MeasuredHeight.Size.AsDecimal();

                    if (ellipsisTextWidth)
                    {
                        Geometry horizontalSpace = GetHorizontalSpace(childLayout.Owner);
                        if (!horizontalSpace.Size.Equals(0))
                        {
                            if ((width > horizontalSpace.Size) || ((width < horizontalSpace.Size) && RelativeLayout.GetFillVertical(childLayout.Owner)))
                            {
                                width = horizontalSpace.Size;
                            }
                        }
                    }
                    else if (needMeasuredWidth)
                    {
                        Geometry horizontalGeometry = GetHorizontalLayout(childLayout.Owner);
                        width = horizontalGeometry.Size;
                    }

                    if (ellipsisTextHeight)
                    {
                        Geometry verticalSpace = GetVerticalSpace(childLayout.Owner);
                        if (!verticalSpace.Size.Equals(0))
                        {
                            if ((height > verticalSpace.Size) || ((height < verticalSpace.Size) && RelativeLayout.GetFillHorizontal(childLayout.Owner)))
                            {
                                height = verticalSpace.Size;
                            }
                        }
                    }
                    else if (needMeasuredHeight)
                    {
                        Geometry verticalGeometry = GetVerticalLayout(childLayout.Owner);
                        height = verticalGeometry.Size;
                    }

                    // Padding sizes are added because Padding sizes will be subtracted in MeasureChild().
                    MeasureSpecification childWidthMeasureSpec = new MeasureSpecification(new LayoutLength(width + Padding.Start + Padding.End), MeasureSpecification.ModeType.Exactly);
                    MeasureSpecification childHeightMeasureSpec = new MeasureSpecification(new LayoutLength(height + Padding.Top + Padding.Bottom), MeasureSpecification.ModeType.Exactly);

                    // To calculate the grand children's Measure() with the mode type Exactly,
                    // children's Measure() is called with MatchParent if the children have WrapContent.
                    //
                    // i.e.
                    // If children have Wrapcontent and the grand children have MatchParent,
                    // then grand children's MeasuredWidth/Height do not fill the children
                    // because the grand children's Measure() is called with the mode type AtMost.
                    var origLayoutParamsWidth = childLayout.Owner.LayoutWidth;
                    var origLayoutParamsHeight = childLayout.Owner.LayoutHeight;

                    if (ellipsisTextWidth || needMeasuredWidth)
                    {
                        origLayoutParamsWidth = childLayout.Owner.LayoutWidth;
                        childLayout.Owner.LayoutWidth = LayoutDimension.MatchParent;
                    }
                    if (ellipsisTextHeight || needMeasuredHeight)
                    {
                        origLayoutParamsHeight = childLayout.Owner.LayoutHeight;
                        childLayout.Owner.LayoutHeight = LayoutDimension.MatchParent;
                    }

                    MeasureChild(childLayout, childWidthMeasureSpec, childHeightMeasureSpec);

                    if (ellipsisTextWidth || needMeasuredWidth)
                    {
                        childLayout.Owner.LayoutWidth = origLayoutParamsWidth;
                    }
                    if (ellipsisTextHeight || needMeasuredHeight)
                    {
                        childLayout.Owner.LayoutHeight = origLayoutParamsHeight;
                    }
                }
            }

            if (needClearCache)
            {
                HorizontalRelativeCache.Clear();
                VerticalRelativeCache.Clear();
            }
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
