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
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LayoutItem : LayoutItemWrapper
    {
        internal LayoutItem(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LayoutItem() : base(new LayoutItemWrapperImpl())
        {
            LayoutItemInitialize(layoutItemWrapperImpl);
        }

        // This should be protected though but made internal because LayoutItemWrapperImpl is internal.
        internal void LayoutItemInitialize(LayoutItemWrapperImpl implementation)
        {
            layoutItemWrapperImpl = implementation;
            layoutItemWrapperImpl.OnUnparent = new LayoutItemWrapperImpl.OnUnparentDelegate(OnUnparent);
            layoutItemWrapperImpl.OnRegisterChildProperties = new LayoutItemWrapperImpl.OnRegisterChildPropertiesDelegate(OnRegisterChildProperties);
            layoutItemWrapperImpl.OnMeasure = new LayoutItemWrapperImpl.OnMeasureDelegate(OnMeasure);
            layoutItemWrapperImpl.OnLayout = new LayoutItemWrapperImpl.OnLayoutDelegate(OnLayout);
            layoutItemWrapperImpl.OnSizeChanged = new LayoutItemWrapperImpl.OnSizeChangedDelegate(OnSizeChanged);
            layoutItemWrapperImpl.OnInitialize = new LayoutItemWrapperImpl.OnInitializeDelegate(OnInitialize);
        }

        /// <summary>
        /// Unparent this layout from it's owner, and remove any layout children in derived types. <br />
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Unparent()
        {
            layoutItemWrapperImpl.Unparent();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetMeasuredDimensions(MeasuredSize measuredWidth, MeasuredSize measuredHeight)
        {
            layoutItemWrapperImpl.SetMeasuredDimensions(measuredWidth, measuredHeight);
        }

        /// <summary>
        /// Register child properties of layout with owner type. <br />
        /// The Actor hierarchy uses these registered properties in the type
        /// system to ensure child custom properties are properly initialized. <br />
        /// </summary>
        /// <param name="containerType"> The type of the containing view (owner).</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterChildProperties(string containerType)
        {
            //layoutItemWrapperImpl.RegisterChildProperties(containerType);
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
            //layoutItemWrapperImpl.Measure(widthMeasureSpec, heightMeasureSpec);
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Layout(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LayoutLength GetDefaultSize(LayoutLength size, LayoutMeasureSpec measureSpec)
        {
            return LayoutItemWrapperImpl.GetDefaultSize(size, measureSpec);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestLayout()
        {
            layoutItemWrapperImpl.RequestLayout();
        }

        /// <summary>
        /// Predicate to determine if this layout has been requested to re-layout.<br />
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This returns the maximum of the layout's minimum width and the background's minimum width.<br />
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LayoutLength SuggestedMinimumWidth
        {
            get
            {
                return GetSuggestedMinimumWidth();
            }
        }

        /// <summary>
        /// Returns the suggested minimum width that the layout should use.<br />
        /// This returns the maximum of the layout's minimum width and the background's minimum width.<br />
        /// </summary>
        /// <returns>The suggested minimum width of the layout.</returns>
        private LayoutLength GetSuggestedMinimumWidth()
        {
            return layoutItemWrapperImpl.GetSuggestedMinimumWidth();
        }

        /// <summary>
        /// Returns the suggested minimum height that the layout should use.<br />
        /// This returns the maximum of the layout's minimum height and the background's minimum height.<br />
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LayoutLength SuggestedMinimumHeight
        {
            get
            {
                return GetSuggestedMinimumHeight();
            }
        }

        /// <summary>
        /// Returns the suggested minimum height that the layout should use.<br />
        /// This returns the maximum of the layout's minimum height and the background's minimum height.<br />
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
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Allow directly deriving classes to remove layout children when unparented.<br />
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnUnparent()
        {
            //layoutItemWrapperImpl.OnUnparentNative();
        }

        /// <summary>
        /// Ensure direct derived types register their child properties with the owner.<br />
        /// </summary>
        /// <param name="containerType">The type name of the owner container.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnRegisterChildProperties(string containerType)
        {
            //layoutItemWrapperImpl.OnRegisterChildPropertiesNative(containerType);
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnMeasure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            //layoutItemWrapperImpl.OnMeasureNative(widthMeasureSpec, heightMeasureSpec);
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            //layoutItemWrapperImpl.OnLayoutNative(changed, left, top, right, bottom);
        }

        /// <summary>
        /// Virtual method to inform derived classes when the layout size changed. <br />
        /// </summary>
        /// <param name="newSize">The new size of the layout.</param>
        /// <param name="oldSize">The old size of the layout.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnSizeChanged(LayoutSize newSize, LayoutSize oldSize)
        {
            //layoutItemWrapperImpl.OnSizeChangedNative(newSize, oldSize);
        }

        /// <summary>
        /// Initialization method for LayoutGroup to override. <br />
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnInitialize()
        {
            //layoutItemWrapperImpl.OnInitializeNative();
        }
    }
}