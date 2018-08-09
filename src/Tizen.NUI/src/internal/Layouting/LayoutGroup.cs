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
    /// LayoutGroup class providing container functionality.
    /// </summary>
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LayoutGroup : LayoutGroupWrapper
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LayoutGroup() : base(new LayoutGroupWrapperImpl())
        {
            // Initialize delegates of LayoutItem
            LayoutItemInitialize(layoutGroupWrapperImpl);

            layoutGroupWrapperImpl.OnMeasure = new LayoutGroupWrapperImpl.OnMeasureDelegate(OnMeasure);
            layoutGroupWrapperImpl.OnLayout = new LayoutGroupWrapperImpl.OnLayoutDelegate(OnLayout);
            layoutGroupWrapperImpl.OnSizeChanged = new LayoutGroupWrapperImpl.OnSizeChangedDelegate(OnSizeChanged);
            layoutGroupWrapperImpl.OnChildAdd = new LayoutGroupWrapperImpl.OnChildAddDelegate(OnChildAdd);
            layoutGroupWrapperImpl.OnChildRemove = new LayoutGroupWrapperImpl.OnChildRemoveDelegate(OnChildRemove);
            layoutGroupWrapperImpl.DoInitialize = new LayoutGroupWrapperImpl.DoInitializeDelegate(DoInitialize);
            layoutGroupWrapperImpl.DoRegisterChildProperties = new LayoutGroupWrapperImpl.DoRegisterChildPropertiesDelegate(DoRegisterChildProperties);
            layoutGroupWrapperImpl.MeasureChildren = new LayoutGroupWrapperImpl.MeasureChildrenDelegate(MeasureChildren);
            layoutGroupWrapperImpl.MeasureChild = new LayoutGroupWrapperImpl.MeasureChildDelegate(MeasureChild);
            layoutGroupWrapperImpl.MeasureChildWithMargins = new LayoutGroupWrapperImpl.MeasureChildWithMarginsDelegate(MeasureChildWithMargins);
        }

        /// <summary>
        /// Remove all layout children.<br />
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAll()
        {
            layoutGroupWrapperImpl.RemoveAll();
        }

        /// <summary>
        /// Get the child layout id of the given child.<br />
        /// </summary>
        /// <param name="child">The given Layout child.</param>
        internal uint GetChildId(LayoutItemWrapperImpl child)
        {
            return layoutGroupWrapperImpl.GetChildId(child);
        }

        /// <summary>
        /// Calculate the right measure spec for this child.
        /// Does the hard part of MeasureChildren: figuring out the MeasureSpec to
        /// pass to a particular child. This method figures out the right MeasureSpec
        /// for one dimension (height or width) of one child view.<br />
        /// </summary>
        /// <param name="measureSpec">The requirements for this view.</param>
        /// <param name="padding">The padding of this view for the current dimension and margins, if applicable.</param>
        /// <param name="childDimension"> How big the child wants to be in the current dimension.</param>
        /// <returns>a MeasureSpec for the child.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LayoutMeasureSpec GetChildMeasureSpec(LayoutMeasureSpec measureSpec, LayoutLength padding, LayoutLength childDimension)
        {
            return LayoutGroupWrapperImpl.GetChildMeasureSpec(measureSpec, padding, childDimension);
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.<br />
        /// If this method is overridden, it is the subclass's responsibility to make
        /// sure the measured height and width are at least the layout's minimum height
        /// and width. <br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnMeasure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            SetMeasuredDimensions(new MeasuredSize(LayoutItemWrapperImpl.GetDefaultSize(layoutItemWrapperImpl.GetSuggestedMinimumWidth(), widthMeasureSpec)),
                                   new MeasuredSize(LayoutItemWrapperImpl.GetDefaultSize(layoutItemWrapperImpl.GetSuggestedMinimumHeight(), heightMeasureSpec)));
        }

        /// <summary>
        /// Called from Layout() when this layout should assign a size and position to each of its children.<br />
        /// Derived classes with children should override this method and call Layout() on each of their children.<br />
        /// </summary>
        /// <param name="changed">This is a new size or position for this layout.</param>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top"> Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {

        }

        /// <summary>
        /// Virtual method to inform derived classes when the layout size changed.<br />
        /// </summary>
        /// <param name="newSize">The new size of the layout.</param>
        /// <param name="oldSize">The old size of the layout.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnSizeChanged(LayoutSize newSize, LayoutSize oldSize)
        {

        }

        /// <summary>
        /// Callback when child is added to container.<br />
        /// Derived classes can use this to set their own child properties on the child layout's owner.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        internal virtual void OnChildAdd(LayoutItemWrapperImpl child)
        {
        }

        /// <summary>
        /// Callback when child is removed from container.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        internal virtual void OnChildRemove(LayoutItemWrapperImpl child)
        {
        }

        /// <summary>
        /// Second stage initialization method for deriving classes to override.<br />
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void DoInitialize()
        {
        }

        /// <summary>
        /// Method for derived classes to implement in order to register child property types with the container.<br />
        /// </summary>
        /// <param name="containerType">The fully qualified typename of the container.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void DoRegisterChildProperties(string containerType)
        {
        }

        /// <summary>
        /// Ask all of the children of this view to measure themselves, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// The heavy lifting is done in GetChildMeasureSpec.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">The width requirements for this view.</param>
        /// <param name="heightMeasureSpec">The height requirements for this view.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void MeasureChildren(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            layoutGroupWrapperImpl.MeasureChildrenNative(widthMeasureSpec, heightMeasureSpec);
        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// The heavy lifting is done in GetChildMeasureSpec.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void MeasureChild(LayoutItem child, LayoutMeasureSpec parentWidthMeasureSpec, LayoutMeasureSpec parentHeightMeasureSpec)
        {
            layoutGroupWrapperImpl.MeasureChildNative(child, parentWidthMeasureSpec, parentHeightMeasureSpec);
        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// and margins. The child must have MarginLayoutParams The heavy lifting is
        /// done in GetChildMeasureSpec.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="widthUsed">Extra space that has been used up by the parent horizontally (possibly by other children of the parent).</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        /// <param name="heightUsed">Extra space that has been used up by the parent vertically (possibly by other children of the parent).</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void MeasureChildWithMargins(LayoutItem child, LayoutMeasureSpec parentWidthMeasureSpec, LayoutLength widthUsed, LayoutMeasureSpec parentHeightMeasureSpec, LayoutLength heightUsed)
        {
            layoutGroupWrapperImpl.MeasureChildWithMarginsNative(child, parentWidthMeasureSpec, widthUsed, parentHeightMeasureSpec, heightUsed);
        }
    }
}