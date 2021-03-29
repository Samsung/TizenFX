/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.Linq;

using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding.Internals;
using static Tizen.NUI.Binding.BindableObject;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] LayoutGroup class providing container functionality.
    /// </summary>
    public class LayoutGroup : LayoutItem, ILayoutParent
    {
        /// <summary>
        /// [Draft] List of child layouts in this container.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected List<LayoutItem> LayoutChildren { get; } // Children of this LayoutGroup

        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LayoutGroup()
        {
            LayoutChildren = new List<LayoutItem>();
        }

        /// <summary>
        /// returns an enumerable collection of the child layouts that owner's <see cref="View.ExcludeLayouting"/> is false.
        /// </summary>
        /// <returns>An enumerable collection of the child layouts that affected by this layout.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected IEnumerable<LayoutItem> IterateLayoutChildren()
        {
            for (int i = 0; i < LayoutChildren.Count; i++)
            {
                LayoutItem childLayout = LayoutChildren[i];
                if (!childLayout?.Owner?.ExcludeLayouting ?? false)
                {
                    yield return childLayout;
                }
            }
        }

        /// <summary>
        /// From ILayoutParent.<br />
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when childLayout is null. </exception>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="childLayout">LayoutItem to add to the layout group.</param>
        public virtual void Add(LayoutItem childLayout)
        {
            if (null == childLayout)
            {
                throw new ArgumentNullException(nameof(childLayout));
            }
            LayoutChildren.Add(childLayout);
            childLayout.SetParent(this);
            // Child added to use a Add transition.
            childLayout.ConditionForAnimation = ConditionForAnimation | TransitionCondition.Add;
            // Child's parent sets all other children not being added to a ChangeOnAdd transition.
            SetConditionsForAnimationOnLayoutGroup(TransitionCondition.ChangeOnAdd);
            OnChildAdd(childLayout);
            RequestLayout();
        }

        /// <summary>
        /// Remove all layout children.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void RemoveAll()
        {
            foreach (LayoutItem childLayout in LayoutChildren)
            {
                childLayout.ConditionForAnimation = ConditionForAnimation | TransitionCondition.Remove;
                childLayout.Owner = null;
            }
            LayoutChildren.Clear();
            // todo ensure child LayoutItems are still not parented to this group.
            RequestLayout();
        }

        /// <summary>
        /// From ILayoutParent
        /// </summary>
        /// <param name="layoutItem">LayoutItem to remove from the layout group.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void Remove(LayoutItem layoutItem)
        {
            bool childRemoved = false;
            foreach (LayoutItem childLayout in LayoutChildren.ToList())
            {
                if (childLayout == layoutItem)
                {
                    childLayout.ClearReplaceFlag();
                    LayoutChildren.Remove(childLayout);

                    if (LayoutWithTransition)
                    {
                        if (!childLayout.IsReplaceFlag())
                        {
                            NUIApplication.GetDefaultWindow().LayoutController.AddToRemovalStack(childLayout);
                        }

                        childLayout.ConditionForAnimation = childLayout.ConditionForAnimation | TransitionCondition.Remove;
                        // Add LayoutItem to the transition stack so can animate it out.
                        NUIApplication.GetDefaultWindow().LayoutController.AddTransitionDataEntry(new LayoutData(layoutItem, ConditionForAnimation, 0, 0, 0, 0));
                    }

                    // Reset condition for animation ready for next transition when required.
                    // SetFrame usually would do this but this LayoutItem is being removed.
                    childLayout.ConditionForAnimation = TransitionCondition.Unspecified;
                    childRemoved = true;

                    break;
                }
            }

            if (childRemoved)
            {
                // If child removed then set all siblings not being added to a ChangeOnRemove transition.
                SetConditionsForAnimationOnLayoutGroup(TransitionCondition.ChangeOnRemove);
            }
            OnChildRemove(layoutItem);
            RequestLayout();
        }


        /// <summary>
        /// Sets the sibling order of the layout item so the layout can be defined within the same parent.
        /// </summary>
        /// <param name="order">the sibling order of the layout item</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ChangeLayoutSiblingOrder(int order)
        {
            if (Owner != null)
            {
                var ownerParent = Owner.GetParent() as View;
                if (ownerParent != null)
                {
                    var parent = ownerParent.Layout as LayoutGroup;

                    if (parent != null && parent.LayoutChildren.Count > order)
                    {
                        parent.LayoutChildren.Remove(this);
                        parent.LayoutChildren.Insert(order, this);
                    }
                }
            }
            RequestLayout();
        }

        // Attaches to View ChildAdded signal so called when a View is added to a view.
        private void AddChildToLayoutGroup(View child)
        {
            // Only give children a layout if their parent is an explicit container or a pure View.
            // Pure View meaning not derived from a View, e.g a Legacy container.
            // layoutSet flag is true when the View became a layout using the set Layout API opposed to automatically due to it's parent.
            // First time the set Layout API is used by any View the Window no longer has layoutingDisabled.

            // If child already has a Layout then don't change it.
            if (!View.LayoutingDisabled && (null == child.Layout))
            {
                // Only wrap View with a Layout if a child a pure View or Layout explicitly set on this Layout
                if ((true == Owner.LayoutSet || GetType() == typeof(View)))
                {
                    // If child of this layout is a pure View then assign it a LayoutGroup
                    // If the child is derived from a View then it may be a legacy or existing container hence will do layouting itself.
                    child.Layout = (child as TextLabel)?.CreateTextLayout() ?? new AbsoluteLayout();
                }
            }
            else
            {
                // Add child layout to this LayoutGroup (Setting parent in the process)
                if (child.Layout != null)
                {
                    Add(child.Layout);
                }
            }
            // Parent transitions are not attached to children.
        }

        /// <summary>
        /// If the child has a layout then it is removed from the parent layout.
        /// </summary>
        /// <param name="child">Child View to remove.</param>
        internal void RemoveChildFromLayoutGroup(View child)
        {
            if (child.Layout != null)
            {
                Remove(child.Layout);
            }
        }

        /// <summary>
        /// Set all children in a LayoutGroup to the supplied condition.
        /// Children with Add or Remove conditions should not be changed.
        /// </summary>
        private void SetConditionsForAnimationOnLayoutGroup(TransitionCondition conditionToSet)
        {
            foreach (LayoutItem childLayout in LayoutChildren)
            {
                switch (conditionToSet)
                {
                    case TransitionCondition.ChangeOnAdd:
                        {
                            // If other children also being added (TransitionCondition.Add) then do not change their
                            // conditions, Continue to use their Add transitions.
                            if (childLayout.ConditionForAnimation.HasFlag(TransitionCondition.Add))
                            {
                                break;  // Child being Added so don't update it's condition
                            }
                            else
                            {
                                // Set siblings for the child being added to use the ChangeOnAdd transition.
                                childLayout.ConditionForAnimation = TransitionCondition.ChangeOnAdd;
                            }
                            break;
                        }
                    case TransitionCondition.ChangeOnRemove:
                        {
                            if (childLayout.ConditionForAnimation.HasFlag(TransitionCondition.Remove))
                            {
                                break; // Child being Removed so don't update it's condition
                            }
                            else
                            {
                                childLayout.ConditionForAnimation = TransitionCondition.ChangeOnRemove;
                            }
                            break;
                        }
                    case TransitionCondition.LayoutChanged:
                        {
                            childLayout.ConditionForAnimation = TransitionCondition.LayoutChanged;
                            break;
                        }
                }
            }

        }

        /// <summary>
        /// Callback for View.ChildAdded event
        /// </summary>
        /// <param name="sender">The object triggering the event.</param>
        /// <param name="childAddedEvent">Arguments from the event.</param>
        void OnChildAddedToOwner(object sender, View.ChildAddedEventArgs childAddedEvent)
        {
            AddChildToLayoutGroup(childAddedEvent.Added);
        }

        /// <summary>
        /// Callback for View.ChildRemoved event
        /// </summary>
        /// <param name="sender">The object triggering the event.</param>
        /// <param name="childRemovedEvent">Arguments from the event.</param>
        void OnChildRemovedFromOwner(object sender, View.ChildRemovedEventArgs childRemovedEvent)
        {
            RemoveChildFromLayoutGroup(childRemovedEvent.Removed);
        }

        /// <summary>
        /// Calculate the right measure spec for this child.
        /// Does the hard part of MeasureChildren: figuring out the MeasureSpec to
        /// pass to a particular child. This method figures out the right MeasureSpec
        /// for one dimension (height or width) of one child view.<br />
        /// </summary>
        /// <param name="parentMeasureSpec">The requirements for this view. MeasureSpecification.</param>
        /// <param name="padding">The padding of this view for the current dimension and margins, if applicable. LayoutLength.</param>
        /// <param name="childDimension"> How big the child wants to be in the current dimension. LayoutLength.</param>
        /// <returns>a MeasureSpec for the child.</returns>
        public static MeasureSpecification GetChildMeasureSpecification(MeasureSpecification parentMeasureSpec, LayoutLength padding, LayoutLength childDimension)
        {
            MeasureSpecification.ModeType specMode = parentMeasureSpec.Mode;
            MeasureSpecification.ModeType resultMode = MeasureSpecification.ModeType.Unspecified;

            // Child only can use parent's size without parent's padding and own margin.
            LayoutLength resultSize = new LayoutLength(Math.Max(0.0f, (parentMeasureSpec.Size - padding).AsDecimal()));
            switch (specMode)
            {
                // Parent has imposed an exact size on us
                case MeasureSpecification.ModeType.Exactly:
                    {
                        if ((int)childDimension.AsRoundedValue() == LayoutParamPolicies.MatchParent)
                        {
                            resultMode = MeasureSpecification.ModeType.Exactly;
                        }
                        else if ((int)childDimension.AsRoundedValue() == LayoutParamPolicies.WrapContent)
                        {
                            resultMode = MeasureSpecification.ModeType.AtMost;
                        }
                        else
                        {
                            resultSize = childDimension;
                            resultMode = MeasureSpecification.ModeType.Exactly;
                        }

                        break;
                    }

                // Parent has imposed a maximum size on us
                case MeasureSpecification.ModeType.AtMost:
                    {
                        if (childDimension.AsRoundedValue() == LayoutParamPolicies.MatchParent)
                        {
                            // Crashed. Cannot calculate.

                            // Child wants to be our size, but our size is not fixed.
                            // Constrain child to not be bigger than us.
                            resultMode = MeasureSpecification.ModeType.AtMost;
                        }
                        else if (childDimension.AsRoundedValue() == LayoutParamPolicies.WrapContent)
                        {
                            // Child wants to determine its own size. It can't be
                            // bigger than us.

                            // Don't need parent's size. Size of this child will be determined by its children.
                            resultMode = MeasureSpecification.ModeType.AtMost;
                        }
                        else
                        {
                            // Child wants a specific size... so be it
                            resultSize = childDimension;
                            resultMode = MeasureSpecification.ModeType.Exactly;
                        }

                        break;
                    }

                // Parent asked to see how big we want to be
                case MeasureSpecification.ModeType.Unspecified:
                    {
                        if ((childDimension.AsRoundedValue() == LayoutParamPolicies.MatchParent))
                        {
                            // Child wants to be our size... find out how big it should be

                            // There is no one who has exact size in parent hierarchy.
                            // Cannot calculate.
                            resultMode = MeasureSpecification.ModeType.Unspecified;
                        }
                        else if (childDimension.AsRoundedValue() == (LayoutParamPolicies.WrapContent))
                        {
                            // Child wants to determine its own size.... find out how big
                            // it should be
                            resultMode = MeasureSpecification.ModeType.Unspecified;
                        }
                        else
                        {
                            // Child wants a specific size... let him have it
                            resultSize = childDimension;
                            resultMode = MeasureSpecification.ModeType.Exactly;
                        }
                        break;
                    }
            } // switch

            return new MeasureSpecification(resultSize, resultMode);
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.<br />
        /// If this method is overridden, it is the subclass's responsibility to make
        /// sure the measured height and width are at least the layout's minimum height
        /// and width. <br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            LayoutLength measuredWidth = new LayoutLength(0.0f);
            LayoutLength measuredHeight = new LayoutLength(0.0f);

            // Layout takes size of largest child width and largest child height dimensions
            foreach (LayoutItem childLayout in LayoutChildren)
            {
                if (childLayout != null)
                {
                    MeasureChildWithMargins(childLayout, widthMeasureSpec, new LayoutLength(0), heightMeasureSpec, new LayoutLength(0));
                    LayoutLength childWidth = new LayoutLength(childLayout.MeasuredWidth.Size);
                    LayoutLength childHeight = new LayoutLength(childLayout.MeasuredHeight.Size);

                    Extents childMargin = childLayout.Margin;
                    measuredWidth = new LayoutLength(Math.Max(measuredWidth.AsDecimal(), childWidth.AsDecimal() + childMargin.Start + childMargin.End));
                    measuredHeight = new LayoutLength(Math.Max(measuredHeight.AsDecimal(), childHeight.AsDecimal() + childMargin.Top + childMargin.Bottom));
                }
            }

            if (0 == LayoutChildren.Count)
            {
                // Must be a leaf as has no children
                measuredWidth = GetDefaultSize(SuggestedMinimumWidth, widthMeasureSpec);
                measuredHeight = GetDefaultSize(SuggestedMinimumHeight, heightMeasureSpec);
            }

            SetMeasuredDimensions(new MeasuredSize(measuredWidth, MeasuredSize.StateType.MeasuredSizeOK),
                                   new MeasuredSize(measuredHeight, MeasuredSize.StateType.MeasuredSizeOK));
        }

        internal override void OnMeasureIndependentChildren(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            foreach (LayoutItem childLayout in LayoutChildren.Where(item => item?.Owner?.ExcludeLayouting ?? false))
            {
                MeasureChildWithoutPadding(childLayout, widthMeasureSpec, heightMeasureSpec);
            }
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
        /// <since_tizen> 6 </since_tizen>
        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            foreach (LayoutItem childLayout in LayoutChildren)
            {
                if (childLayout != null)
                {
                    // Use position if explicitly set to child otherwise will be top left.
                    var childLeft = new LayoutLength(childLayout.Owner.PositionX);
                    var childTop = new LayoutLength(childLayout.Owner.PositionY);

                    View owner = Owner;

                    if (owner)
                    {
                        // Margin and Padding only supported when child anchor point is TOP_LEFT.
                        if (owner.PivotPoint == PivotPoint.TopLeft || (owner.PositionUsesPivotPoint == false))
                        {
                            childLeft = childLeft + owner.Padding.Start + childLayout.Margin.Start;
                            childTop = childTop + owner.Padding.Top + childLayout.Margin.Top;
                        }
                    }
                    childLayout.Layout(childLeft, childTop, childLeft + childLayout.MeasuredWidth.Size, childTop + childLayout.MeasuredHeight.Size);
                }
            }
        }

        /// <summary>
        /// Layout independent children those Owners have true ExcludeLayouting. <br />
        /// These children are required not to be affected by this layout. <br />
        /// </summary>
        internal override void OnLayoutIndependentChildren(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            foreach (LayoutItem childLayout in LayoutChildren.Where(item => item?.Owner?.ExcludeLayouting ?? false))
            {
                LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                LayoutLength childHeight = childLayout.MeasuredHeight.Size;

                LayoutLength childPositionX = new LayoutLength(childLayout.Owner.PositionX);
                LayoutLength childPositionY = new LayoutLength(childLayout.Owner.PositionY);

                childLayout.Layout(childPositionX, childPositionY, childPositionX + childWidth, childPositionY + childHeight, true);
            }
        }

        /// <summary>
        /// Overridden method called when the layout is attached to an owner.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnAttachedToOwner()
        {
            // Layout takes ownership of it's owner's children.
            foreach (View view in Owner.Children)
            {
                if (view is TextLabel)
                {
                    view.Layout = (view as TextLabel)?.CreateTextLayout();
                }
                AddChildToLayoutGroup(view);
            }

            // Connect to owner ChildAdded signal.
            Owner.ChildAdded += OnChildAddedToOwner;

            // Removing Child from the owners View will directly call the LayoutGroup removal API.
        }

        /// <summary>
        /// Virtual method to allow derived classes to remove any children before it is removed from
        /// its parent.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUnparent()
        {
            // Disconnect to owner ChildAdded signal.
            Owner.ChildAdded -= OnChildAddedToOwner;
        }

        // Virtual Methods that can be overridden by derived classes.

        /// <summary>
        /// Callback when child is added to container.<br />
        /// Derived classes can use this to set their own child properties on the child layout's owner.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnChildAdd(LayoutItem child)
        {
        }

        /// <summary>
        /// Callback when child is removed from container.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnChildRemove(LayoutItem child)
        {
        }

        /// <summary>
        /// Ask all of the children of this view to measure themselves, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// The heavy lifting is done in GetChildMeasureSpec.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">The width requirements for this view.</param>
        /// <param name="heightMeasureSpec">The height requirements for this view.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void MeasureChildren(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            foreach (LayoutItem childLayout in LayoutChildren)
            {
                MeasureChildWithMargins(childLayout, widthMeasureSpec, new LayoutLength(0), heightMeasureSpec, new LayoutLength(0));
            }
        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// The heavy lifting is done in GetChildMeasureSpecification.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        /// <exception cref="ArgumentNullException"> Thrown when child is null. </exception>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void MeasureChild(LayoutItem child, MeasureSpecification parentWidthMeasureSpec, MeasureSpecification parentHeightMeasureSpec)
        {
            if (null == child)
            {
                throw new ArgumentNullException(nameof(child));
            }

            View childOwner = child.Owner;

            MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification(
                        new MeasureSpecification(new LayoutLength(parentWidthMeasureSpec.Size), parentWidthMeasureSpec.Mode),
                        new LayoutLength(Padding.Start + Padding.End),
                        new LayoutLength(childOwner.WidthSpecification));

            MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification(
                        new MeasureSpecification(new LayoutLength(parentHeightMeasureSpec.Size), parentHeightMeasureSpec.Mode),
                        new LayoutLength(Padding.Top + Padding.Bottom),
                        new LayoutLength(childOwner.HeightSpecification));

            child.Measure(childWidthMeasureSpec, childHeightMeasureSpec);
        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// and margins. The heavy lifting is done in GetChildMeasureSpecification.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="widthUsed">Extra space that has been used up by the parent horizontally (possibly by other children of the parent).</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        /// <param name="heightUsed">Extra space that has been used up by the parent vertically (possibly by other children of the parent).</param>
        /// <exception cref="ArgumentNullException"> Thrown when child is null. </exception>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void MeasureChildWithMargins(LayoutItem child, MeasureSpecification parentWidthMeasureSpec, LayoutLength widthUsed, MeasureSpecification parentHeightMeasureSpec, LayoutLength heightUsed)
        {
            if (null == child)
            {
                throw new ArgumentNullException(nameof(child));
            }

            View childOwner = child.Owner;
            Extents margin = childOwner.Margin;

            MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification(
                        new MeasureSpecification(
                            new LayoutLength(parentWidthMeasureSpec.Size + widthUsed - (margin.Start + margin.End)),
                            parentWidthMeasureSpec.Mode),
                        new LayoutLength(Padding.Start + Padding.End),
                        new LayoutLength(childOwner.WidthSpecification));

            MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification(
                        new MeasureSpecification(
                            new LayoutLength(parentHeightMeasureSpec.Size + heightUsed - (margin.Top + margin.Bottom)),
                            parentHeightMeasureSpec.Mode),
                        new LayoutLength(Padding.Top + Padding.Bottom),
                        new LayoutLength(childOwner.HeightSpecification));
            child.Measure(childWidthMeasureSpec, childHeightMeasureSpec);

        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and without its padding.<br />
        /// and margins. The heavy lifting is done in GetChildMeasureSpecification.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void MeasureChildWithoutPadding(LayoutItem child, MeasureSpecification parentWidthMeasureSpec, MeasureSpecification parentHeightMeasureSpec)
        {
            View childOwner = child.Owner;

            MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification(
                        new MeasureSpecification(new LayoutLength(parentWidthMeasureSpec.Size), parentWidthMeasureSpec.Mode),
                        new LayoutLength(0),
                        new LayoutLength(childOwner.WidthSpecification));

            MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification(
                        new MeasureSpecification(new LayoutLength(parentHeightMeasureSpec.Size), parentHeightMeasureSpec.Mode),
                        new LayoutLength(0),
                        new LayoutLength(childOwner.HeightSpecification));

            child.Measure(childWidthMeasureSpec, childHeightMeasureSpec);
        }

        /// <summary>
        /// Gets the value that is contained in the attached BindableProperty.
        /// </summary>
        /// <typeparam name="T">The return type of property</typeparam>
        /// <param name="bindable">The bindable object.</param>
        /// <param name="property">The BindableProperty for which to get the value.</param>
        /// <returns>The value that is contained in the attached BindableProperty.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T GetAttachedValue<T>(Binding.BindableObject bindable, Binding.BindableProperty property)
        {
            if (bindable == null)
                throw new ArgumentNullException(nameof(bindable));

            return (T)bindable.GetValue(property);
        }

        /// <summary>
        /// Sets the value of the attached property.
        /// </summary>
        /// <param name="bindable">The bindable object.</param>
        /// <param name="property">The BindableProperty on which to assign a value.</param>
        /// <param name="value">The value to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetAttachedValue(Binding.BindableObject bindable, Binding.BindableProperty property, object value)
        {
            if (bindable == null)
                throw new ArgumentNullException(nameof(bindable));

            bindable.SetValueCore(property, value, SetValueFlags.None, SetValuePrivateFlags.ManuallySet, false);
        }
        internal static void OnChildPropertyChanged(Binding.BindableObject bindable, object oldValue, object newValue)
        {
            // Unused parameters
            _ = oldValue;
            _ = newValue;

            View view = bindable as View;
            view?.Layout?.RequestLayout();
        }

        internal static Binding.BindableProperty.ValidateValueDelegate ValidateEnum(int enumMin, int enumMax)
        {
            return (Binding.BindableObject bindable, object value) =>
            {
                int @enum = (int)value;
                return enumMin <= @enum && @enum <= enumMax;
            };
        }
    }
}
