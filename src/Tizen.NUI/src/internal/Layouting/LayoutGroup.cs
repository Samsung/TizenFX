/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using System.Linq;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] LayoutGroup class providing container functionality.
    /// </summary>
    internal class LayoutGroup : LayoutItem, ILayoutParent
    {
        protected List<LayoutItem> _children{ get;} // Children of this LayoutGroup

        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        public LayoutGroup()
        {
            _children = new List<LayoutItem>();
        }

        /// <summary>
        /// [Draft] Constructor setting the owner of this LayoutGroup.
        /// </summary>
        /// <param name="owner">Owning View of this layout, currently a View but may be extending for Windows/Layers.</param>
        public LayoutGroup(View owner) : base(owner)
        {
            _children = new List<LayoutItem>();
        }

        /// <summary>
        /// From ILayoutParent.<br />
        /// </summary>
        public virtual void Add(LayoutItem childLayout)
        {
            Log.Info("NUI","Add Layout:" + childLayout.Owner.Name + " to Layout:" + Owner.Name + "\n");
            _children.Add(childLayout);
            childLayout.SetParent(this);
            OnChildAdd(childLayout);
            RequestLayout();
        }

        /// <summary>
        /// Remove all layout children.<br />
        /// </summary>
        public void RemoveAll()
        {
            Log.Info("NUI","Removing:" + _children.Count + "\n");
            foreach( LayoutItem childLayout in _children )
            {
                childLayout.Owner = null;
            }
            _children.Clear();
            // todo ensure child LayoutItems are still not parented to this group.
            RequestLayout();
        }

        /// <summary>
        /// From ILayoutParent
        /// </summary>
        public virtual void Remove(LayoutItem layoutItem)
        {
            foreach( LayoutItem childLayout in _children.ToList() )
            {
                if( childLayout == layoutItem )
                {
                    childLayout.SetParent(null);
                    _children.Remove(childLayout);
                }
            }
            RequestLayout();
        }

        private void AddChildToLayoutGroup(View child)
        {
            Log.Info("NUI", "Adding child View:" + child.Name + " to Layout:" + Owner?.Name + "\n");

            // Only give children a layout if their parent is an explicit container or a pure View.
            // Pure View meaning not derived from a View, e.g a Legacy container.
            // layoutSet flag is true when the View became a layout using the set Layout API opposed to automatically due to it's parent.
            // First time the set Layout API is used by any View the Window no longer has layoutingDisabled.

            // If child already has a Layout then don't change it.
            if (! View.layoutingDisabled && (null == child.Layout))
            {
                // Only wrap View with a Layout if a child a pure View or Layout explicitly set on this Layout
                if ((true == Owner.layoutSet || GetType() == typeof(View)))
                {
                    Log.Info("NUI", "Parent[" + Owner.Name + "] Layout set[" + Owner.layoutSet.ToString() + "] Pure View[" + (!Owner.layoutSet).ToString() + "]\n");
                    // If child of this layout is a pure View then assign it a LayoutGroup
                    // If the child is derived from a View then it may be a legacy or existing container hence will do layouting itself.
                    if (child.GetType() == typeof(View))
                    {
                        Log.Info("NUI", "Creating LayoutGroup for " + child.Name +  "]\n");
                        child.Layout = new LayoutGroup();
                    }
                    else
                    {
                        // Adding child as a leaf, layouting will not propagate past this child.
                        // Legacy containers will be a LayoutItems too and layout their children how they wish.
                        Log.Info("NUI", "Creating LayoutItem for " + child.Name + "\n");
                        child.Layout = new LayoutItem();
                    }
                }
            }
            else
            {
                // Add child layout to this LayoutGroup (Setting parent in the process)
                if(child.Layout != null)
                {
                    Add(child.Layout);
                }
            }
        }

        /// <summary>
        /// If the child has a layout then it is removed from the parent layout.
        /// </summary>
        /// <param name="child">Child to remove.true</param>
        private void RemoveChildFromLayoutGroup(View child)
        {
            Log.Info("NUI", "Removing child View:" + child.Name + " from Layout:" + Owner?.Name + "\n");

            if(child.Layout != null)
            {
                Remove(child.Layout);
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
            LayoutLength resultSize = new LayoutLength(Math.Max( 0.0f, (parentMeasureSpec.Size.AsDecimal() - padding.AsDecimal() ) )); // reduce available size by the owners padding

            switch( specMode )
            {
                // Parent has imposed an exact size on us
                case MeasureSpecification.ModeType.Exactly:
                {
                if ((int)childDimension.AsRoundedValue() == LayoutParamPolicies.MatchParent)
                {
                    // Child wants to be our size. So be it.
                    resultMode = MeasureSpecification.ModeType.Exactly;
                }
                else if ((int)childDimension.AsRoundedValue() == LayoutParamPolicies.WrapContent)
                {
                    // Child wants to determine its own size. It can't be
                    // bigger than us.
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
                    // Child wants to be our size, but our size is not fixed.
                    // Constrain child to not be bigger than us.
                    resultMode = MeasureSpecification.ModeType.AtMost;
                }
                else if (childDimension.AsRoundedValue() == LayoutParamPolicies.WrapContent)
                {
                    // Child wants to determine its own size. It can't be
                    // bigger than us.
                    resultMode = MeasureSpecification.ModeType.AtMost;
                }
                else
                {
                    // Child wants a specific size... so be it
                    resultSize = childDimension + padding;
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
                    resultSize = childDimension + padding;
                    resultMode = MeasureSpecification.ModeType.Exactly;
                }
                break;
                }
            } // switch

            Log.Info("NUI", "MeasureSpecification resultSize:" + resultSize.AsRoundedValue()
                            + " resultMode:" + resultMode + "\n");
            return new MeasureSpecification( resultSize, resultMode );
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.<br />
        /// If this method is overridden, it is the subclass's responsibility to make
        /// sure the measured height and width are at least the layout's minimum height
        /// and width. <br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            Log.Info("NUI", "OnMeasure\n");
            LayoutLength measuredWidth = new LayoutLength(0.0f);
            LayoutLength measuredHeight = new LayoutLength(0.0f);

            // Layout takes size of largest child width and largest child height dimensions
            foreach( LayoutItem childLayout in _children )
            {
                if( childLayout != null )
                {
                    MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpec );
                    LayoutLength childWidth = new LayoutLength(childLayout.MeasuredWidth.Size);
                    LayoutLength childHeight = new LayoutLength( childLayout.MeasuredHeight.Size);
                    Extents childMargin = childLayout.Margin;
                    measuredWidth = new LayoutLength(Math.Max( measuredWidth.AsDecimal(), childWidth.AsDecimal() + childMargin.Start + childMargin.End));
                    measuredHeight = new LayoutLength(Math.Max( measuredHeight.AsDecimal(), childHeight.AsDecimal() + childMargin.Top + childMargin.Bottom));
                }
            }

            if( 0 == _children.Count )
            {
                // Must be a leaf as has no children
                measuredWidth = GetDefaultSize( SuggestedMinimumWidth, widthMeasureSpec );
                measuredHeight = GetDefaultSize( SuggestedMinimumHeight, heightMeasureSpec );
            }

            SetMeasuredDimensions( new MeasuredSize( measuredWidth, MeasuredSize.StateType.MeasuredSizeOK ),
                                   new MeasuredSize( measuredHeight, MeasuredSize.StateType.MeasuredSizeOK ) );
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
        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            Log.Info("NUI", "OnLayout\n");
            foreach( LayoutItem childLayout in _children )
            {
                if( childLayout !=null )
                {
                    // Use position if explicitly set to child otherwise will be top left.
                    var childLeft = new LayoutLength( childLayout.Owner.Position2D.X );
                    var childTop = new LayoutLength( childLayout.Owner.Position2D.Y );

                    View owner = Owner;

                    if ( owner )
                    {
                        // Margin and Padding only supported when child anchor point is TOP_LEFT.
                        if ( owner.PivotPoint == PivotPoint.TopLeft || ( owner.PositionUsesPivotPoint == false ) )
                        {
                            childLeft = childLeft + owner.Padding.Start + childLayout.Margin.Start;
                            childTop = childTop + owner.Padding.Top + childLayout.Margin.Top;
                        }
                    }
                    childLayout.Layout( childLeft, childTop, childLeft + childLayout.MeasuredWidth.Size, childTop + childLayout.MeasuredHeight.Size );
                }
            }
        }

        /// <summary>
        /// Overridden method called when the layout size changes.<br />
        /// </summary>
        /// <param name="newSize">The new size of the layout.</param>
        /// <param name="oldSize">The old size of the layout.</param>
        protected override void OnSizeChanged(LayoutSize newSize, LayoutSize oldSize)
        {
            // Do nothing
        }

        /// <summary>
        /// Overridden method called when the layout is attached to an owner.<br />
        /// </summary>
        protected override void OnAttachedToOwner()
        {
            Log.Info("NUI", "Attaching to Owner:" + Owner.Name + "\n");
            // Layout takes ownership of it's owner's children.
            foreach (View view in Owner.Children)
            {
                AddChildToLayoutGroup(view);
            }

            // Layout attached to owner so connect to ChildAdded and ChildRemoved signals.
            Owner.ChildAdded += OnChildAddedToOwner;
            Owner.ChildRemoved += OnChildRemovedFromOwner;
        }

        // Virtual Methods that can be overridden by derived classes.

        /// <summary>
        /// Callback when child is added to container.<br />
        /// Derived classes can use this to set their own child properties on the child layout's owner.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        protected virtual void OnChildAdd(LayoutItem child)
        {
        }

        /// <summary>
        /// Callback when child is removed from container.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
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
        protected virtual void MeasureChildren(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            foreach( LayoutItem childLayout in _children )
            {
                MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpec );
            }
        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// The heavy lifting is done in GetChildMeasureSpec.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        protected virtual void MeasureChild(LayoutItem child, MeasureSpecification parentWidthMeasureSpec, MeasureSpecification parentHeightMeasureSpec)
        {
            View childOwner = child.Owner;
            Log.Info("NUI", "LayoutGroup MeasureChild:" + childOwner.Name
                          + " child widthSpecification policy:" + childOwner.WidthSpecification
                          + " child heightSpecification policy:" + childOwner.HeightSpecification + "\n");

            Extents padding = child.Padding; // Padding of this layout's owner, not of the child being measured.

            MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification( parentWidthMeasureSpec,
                                                                                       new LayoutLength(padding.Start + padding.End ),
                                                                                       new LayoutLength(childOwner.WidthSpecification) );

            MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification( parentHeightMeasureSpec,
                                                                                        new LayoutLength(padding.Top + padding.Bottom),
                                                                                        new LayoutLength(childOwner.HeightSpecification) );

            child.Measure( childWidthMeasureSpec, childHeightMeasureSpec );
        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// and margins. The child must have MarginLayoutParams The heavy lifting is
        /// done in GetChildMeasureSpecification.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="widthUsed">Extra space that has been used up by the parent horizontally (possibly by other children of the parent).</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        /// <param name="heightUsed">Extra space that has been used up by the parent vertically (possibly by other children of the parent).</param>
        protected virtual void MeasureChildWithMargins(LayoutItem child, MeasureSpecification parentWidthMeasureSpec, LayoutLength widthUsed, MeasureSpecification parentHeightMeasureSpec, LayoutLength heightUsed)
        {
            View childOwner = child.Owner;
            int desiredWidth = childOwner.WidthSpecification;
            int desiredHeight = childOwner.HeightSpecification;

            Extents padding = child.Padding; // Padding of this layout's owner, not of the child being measured.

            MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification( parentWidthMeasureSpec,
                                                                                       new LayoutLength( padding.Start + padding.End ) +
                                                                                       widthUsed, new LayoutLength(desiredWidth) );


            MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification( parentHeightMeasureSpec,
                                                                                        new LayoutLength( padding.Top + padding.Bottom )+
                                                                                        heightUsed, new LayoutLength(desiredHeight) );

            child.Measure( childWidthMeasureSpec, childHeightMeasureSpec );
        }
    }
}
