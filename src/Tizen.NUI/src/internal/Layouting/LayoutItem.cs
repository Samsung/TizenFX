/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] Base class for layouts. It is used to layout a control (or visual).
    /// It can be laid out by a LayoutGroup.
    /// </summary>
    internal class LayoutItem : LayoutItemWrapper
    {
        //It is called by LayoutGroupWrapper constructor.
        internal LayoutItem(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            System.IntPtr wrapperImpe_CPtr = Interop.LayoutItemWrapperImpl.LayoutItemWrapper_GetImplementation(cPtr);
            layoutItemWrapperImpl = new LayoutItemWrapperImpl(wrapperImpe_CPtr, true);
            LayoutItemInitialize(layoutItemWrapperImpl);
        }

        public LayoutItem() : base(new LayoutItemWrapperImpl())
        {
            LayoutItemInitialize(layoutItemWrapperImpl);
        }

        // This should be protected though but made internal because LayoutItemWrapperImpl is internal.
        internal void LayoutItemInitialize(LayoutItemWrapperImpl implementation)
        {
            layoutItemWrapperImpl = implementation;
            layoutItemWrapperImpl.OnMeasure = new LayoutItemWrapperImpl.OnMeasureDelegate(OnMeasure);
            layoutItemWrapperImpl.OnLayout = new LayoutItemWrapperImpl.OnLayoutDelegate(OnLayout);
            layoutItemWrapperImpl.OnSizeChanged = new LayoutItemWrapperImpl.OnSizeChangedDelegate(OnSizeChanged);
        }

        /// <summary>
        /// Unparent this layout from it's owner, and remove any layout children in derived types. <br />
        /// </summary>
        public void Unparent()
        {
            layoutItemWrapperImpl.Unparent();
        }

        protected void SetMeasuredDimensions(MeasuredSize measuredWidth, MeasuredSize measuredHeight)
        {
            layoutItemWrapperImpl.SetMeasuredDimensions(measuredWidth, measuredHeight);
        }

        /// <summary>
        /// This is called to find out how big a layout should be. <br />
        /// The parent supplies constraint information in the width and height parameters. <br />
        /// The actual measurement work of a layout is performed in OnMeasure called by this
        /// method. Therefore, only OnMeasure can and must be overridden by subclasses. <br />
        /// </summary>
        /// <param name="widthMeasureSpec"> Horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">Vertical space requirements as imposed by the parent.</param>
        internal void Measure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            layoutItemWrapperImpl.Measure(widthMeasureSpec, heightMeasureSpec);
        }

        /// <summary>
        /// Assign a size and position to a layout and all of its descendants. <br />
        /// This is the second phase of the layout mechanism.  (The first is measuring). In this phase, each parent
        /// calls layout on all of its children to position them.  This is typically done using the child<br />
        /// measurements that were stored in the measure pass.<br />
        /// </summary>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top">Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        public void Layout(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            Log.Info("NUI", "LayoutItem Layout\n");
            layoutItemWrapperImpl.Layout(left, top, right, bottom);
        }

        /// <summary>
        /// Utility to return a default size.<br />
        /// Uses the supplied size if the MeasureSpec imposed no constraints. Will get larger if allowed by the
        /// MeasureSpec.<br />
        /// </summary>
        /// <param name="size"> Default size for this layout.</param>
        /// <param name="measureSpec"> Constraints imposed by the parent.</param>
        /// <returns>The size this layout should be.</returns>
        public static LayoutLength GetDefaultSize(LayoutLength size, LayoutMeasureSpec measureSpec)
        {
            return LayoutItemWrapperImpl.GetDefaultSize(size, measureSpec);
        }

        public ILayoutParent GetParent
        {
            get
            {
                return layoutItemWrapperImpl.GetParent();
            }
        }

        /// <summary>
        /// Request that this layout is re-laid out.<br />
        /// This will make this layout and all it's parent layouts dirty.<br />
        /// </summary>
        public void RequestLayout()
        {
            layoutItemWrapperImpl.RequestLayout();
        }

        /// <summary>
        /// Predicate to determine if this layout has been requested to re-layout.<br />
        /// </summary>
        public bool LayoutRequested
        {
            get
            {
                return IsLayoutRequested();
            }
        }

        /// <summary>
        /// Predicate to determine if this layout has been requested to re-layout.<br />
        /// </summary>
        /// <returns>True if a layout request has occured on this layout.</returns>
        private bool IsLayoutRequested()
        {
            return layoutItemWrapperImpl.IsLayoutRequested();
        }

        /// <summary>
        /// Get the measured width (without any measurement flags).<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        public LayoutLength MeasuredWidth
        {
            get
            {
                return GetMeasuredWidth();
            }
        }

        /// <summary>
        /// Get the measured width (without any measurement flags).<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        private LayoutLength GetMeasuredWidth()
        {
            return layoutItemWrapperImpl.GetMeasuredWidth();
        }

        /// <summary>
        /// Get the measured height (without any measurement flags).<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        public LayoutLength MeasuredHeight
        {
            get
            {
                return GetMeasuredHeight();
            }
        }

        /// <summary>
        /// Get the measured height (without any measurement flags).<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        private LayoutLength GetMeasuredHeight()
        {
            return layoutItemWrapperImpl.GetMeasuredHeight();
        }

        /// <summary>
        /// Get the measured width and state.<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        public MeasuredSize MeasuredWidthAndState
        {
            get
            {
                return GetMeasuredWidthAndState();
            }
        }

        /// <summary>
        /// Get the measured width and state.<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        private MeasuredSize GetMeasuredWidthAndState()
        {
            return layoutItemWrapperImpl.GetMeasuredWidthAndState();
        }

        /// <summary>
        /// Get the measured height and state.<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        public MeasuredSize MeasuredHeightAndState
        {
            get
            {
                return GetMeasuredHeightAndState();
            }
        }

        /// <summary>
        /// Get the measured height and state.<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        private MeasuredSize GetMeasuredHeightAndState()
        {
            return layoutItemWrapperImpl.GetMeasuredHeightAndState();
        }

        /// <summary>
        /// Returns the suggested minimum width that the layout should use.<br />
        /// This returns the maximum of the layout's minimum width and the owner's natural width.<br />
        /// </summary>
        public LayoutLength SuggestedMinimumWidth
        {
            get
            {
                return GetSuggestedMinimumWidth();
            }
        }

        /// <summary>
        /// Returns the suggested minimum width that the layout should use.<br />
        /// This returns the maximum of the layout's minimum width and the owner's natural width.<br />
        /// </summary>
        /// <returns>The suggested minimum width of the layout.</returns>
        private LayoutLength GetSuggestedMinimumWidth()
        {
            return layoutItemWrapperImpl.GetSuggestedMinimumWidth();
        }

        /// <summary>
        /// Returns the suggested minimum height that the layout should use.<br />
        /// This returns the maximum of the layout's minimum height and the owner's natural height.<br />
        /// </summary>
        public LayoutLength SuggestedMinimumHeight
        {
            get
            {
                return GetSuggestedMinimumHeight();
            }
        }

        /// <summary>
        /// Returns the suggested minimum height that the layout should use.<br />
        /// This returns the maximum of the layout's minimum height and the owner's natural height.<br />
        /// </summary>
        /// <returns>The suggested minimum height of the layout.</returns>
        private LayoutLength GetSuggestedMinimumHeight()
        {
            return layoutItemWrapperImpl.GetSuggestedMinimumHeight();
        }

        /// <summary>
        /// Sets the minimum width of the layout.<br />
        /// It is not guaranteed the layout will be able to achieve this minimum width (for example, if its parent
        /// layout constrains it with less available width).<br />
        /// 1. if the owner's View.LayoutWidthSpecification has exact value, then that value overrides the minimum size.<br />
        /// 2. If the owner's View.LayoutWidthSpecification is set to View.ChildLayoutData.WrapContent, then the view's width is set based on the suggested minimum width. (@see GetSuggestedMinimumWidth()).<br />
        /// 3. If the owner's View.LayoutWidthSpecification is set to View.ChildLayoutData.MatchParent, then the parent width takes precedence over the minimum width.<br />
        /// </summary>
        public LayoutLength MinimumWidth
        {
            get
            {
                return GetMinimumWidth();
            }
            set
            {
                SetMinimumWidth(value);
            }
        }

        /// <summary>
        /// Sets the minimum width of the layout.<br />
        /// It is not guaranteed the layout will be able to achieve this minimum width (for example, if its parent
        /// layout constrains it with less available width).<br />
        /// </summary>
        /// <param name="minWidth">The minimum width the layout will try to be, in pixels.</param>
        private void SetMinimumWidth(LayoutLength minWidth)
        {
            layoutItemWrapperImpl.SetMinimumWidth(minWidth);
        }

        /// <summary>
        /// Sets the minimum height of the layout.<br />
        /// It is not guaranteed the layout will be able to achieve this minimum height (for example, if its parent
        /// layout constrains it with less available height).<br />
        /// 1. if the owner's View.LayoutHeightSpecification has exact value, then that value overrides the minimum size.<br />
        /// 2. If the owner's View.LayoutHeightSpecification is set to View.ChildLayoutData.WrapContent, then the view's height is set based on the suggested minimum height. (@see GetSuggestedMinimumHeight()).<br />
        /// 3. If the owner's View.LayoutHeightSpecification is set to View.ChildLayoutData.MatchParent, then the parent height takes precedence over the minimum height.<br />
        /// </summary>
        public LayoutLength MinimumHeight
        {
            get
            {
                return GetMinimumHeight();
            }
            set
            {
                SetMinimumHeight(value);
            }
        }

        /// <summary>
        /// Sets the minimum height of the layout.<br />
        /// It is not guaranteed the layout will be able to achieve this minimum height (for example, if its parent
        /// layout constrains it with less available height).<br />
        /// </summary>
        /// <param name="minHeight">The minimum height the layout will try to be, in pixels.</param>
        private void SetMinimumHeight(LayoutLength minHeight)
        {
            layoutItemWrapperImpl.SetMinimumHeight(minHeight);
        }

        /// <summary>
        /// Returns the minimum width of the layout.<br />
        /// </summary>
        /// <returns>the minimum width the layout will try to be, in pixels.</returns>
        private LayoutLength GetMinimumWidth()
        {
            return layoutItemWrapperImpl.GetMinimumWidth();
        }

        /// <summary>
        /// Returns the minimum height of the layout.<br />
        /// </summary>
        /// <returns>the minimum height the layout will try to be, in pixels.</returns>
        private LayoutLength GetMinimumHeight()
        {
            return layoutItemWrapperImpl.GetMinimumHeight();
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the
        /// measured height.<br />
        /// The base class implementation of measure defaults to the background size,
        /// unless a larger size is allowed by the MeasureSpec. Subclasses should
        /// override to provide better measurements of their content.<br />
        /// If this method is overridden, it is the subclass's responsibility to make sure the
        /// measured height and width are at least the layout's minimum height and width.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        protected virtual void OnMeasure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            layoutItemWrapperImpl.OnMeasureNative(widthMeasureSpec, heightMeasureSpec);
        }

        /// <summary>
        /// Called from Layout() when this layout should assign a size and position to each of its children. <br />
        /// Derived classes with children should override this method and call Layout() on each of their children. <br />
        /// </summary>
        /// <param name="changed">This is a new size or position for this layout.</param>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top">Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        protected virtual void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
        }

        /// <summary>
        /// Virtual method to inform derived classes when the layout size changed. <br />
        /// </summary>
        /// <param name="newSize">The new size of the layout.</param>
        /// <param name="oldSize">The old size of the layout.</param>
        protected virtual void OnSizeChanged(LayoutSize newSize, LayoutSize oldSize)
        {
        }
    }
}
