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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{

    [FlagsAttribute]
    enum LayoutFlags : short
    {
      None = 0,
      ForceLayout = 1,
      LayoutRequired = 2,
      MeasuredDimensionSet = 4
    };

    /// <summary>
    /// [Draft] Base class for layouts. It is used to layout a View
    /// It can be laid out by a LayoutGroup.
    /// </summary>
    internal class LayoutItem
    {
        private MeasureSpecification OldWidthMeasureSpec; // Store measure specification to compare against later
        private MeasureSpecification OldHeightMeasureSpec;// Store measure specification to compare against later

        private LayoutFlags Flags = LayoutFlags.None;

        private ILayoutParent Parent;

        private LayoutLength _left;
        private LayoutLength _right;
        private LayoutLength _top;
        private LayoutLength _bottom;
        private LayoutData _layoutData;

        /// <summary>
        /// The View that this Layout has been assigned to.
        /// </summary>
        public View Owner{get; set;}  // Should not keep a View alive.

        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        public LayoutItem()
        {
        }

        /// <summary>
        /// [Draft] Constructor setting the owner of this LayoutItem.
        /// </summary>
        /// <param name="owner">Owning View of this layout, currently a View but may be extending for Windows/Layers.</param>
        public LayoutItem(View owner)
        {
            Owner = owner;
            _layoutData = new LayoutData();
            _left = new LayoutLength(0);
            _top = new LayoutLength(0);
            _right = new LayoutLength(0);
            _bottom = new LayoutLength(0);
        }

        /// <summary>
        /// [Draft] Set parent to this layout.
        /// </summary>
        /// <param name="parent">Parent to set on this Layout.</param>
        public void SetParent( ILayoutParent parent)
        {
            Parent = parent as LayoutGroup;
            Log.Info("NUI", "Setting Parent Layout for:" +  Owner?.Name + " to (Parent):" + (parent == null ? "null":parent.ToString() ) + "\n");
        }

        /// <summary>
        /// Unparent this layout from it's owner, and remove any layout children in derived types. <br />
        /// </summary>
        public void Unparent()
        {
            // Enable directly derived types to first remove children
            OnUnparent();

            // Remove myself from parent
            Parent?.Remove( this );

            // Remove parent reference
            Parent = null;

            // Lastly, clear layout from owning View.
            Owner?.ResetLayout();
        }

        /// <summary>
        /// Get the View owning this LayoutItem
        /// </summary>
        internal View GetOwner()
        {
            return Owner;
        }

        /// <summary>
        /// Initialize the layout and allow derived classes to also perform any operations
        /// </summary>
        /// <param name="owner">Owner of this Layout.</param>
        internal void AttachToOwner(View owner)
        {
            // Assign the layout owner.
            Owner = owner;
            OnAttachedToOwner();
            // Add layout to parent layout if a layout container
            View parent = Owner.GetParent() as View;
            (parent?.Layout as LayoutGroup)?.Add( this );
        }

        /// <summary>
        /// This is called to find out how big a layout should be. <br />
        /// The parent supplies constraint information in the width and height parameters. <br />
        /// The actual measurement work of a layout is performed in OnMeasure called by this
        /// method. Therefore, only OnMeasure can and must be overridden by subclasses. <br />
        /// </summary>
        /// <param name="widthMeasureSpec"> Horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">Vertical space requirements as imposed by the parent.</param>
        internal void Measure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            // Check if relayouting is required.
            bool specChanged = (widthMeasureSpec.Size != OldWidthMeasureSpec.Size) ||
                               (heightMeasureSpec.Size != OldHeightMeasureSpec.Size) ||
                               (widthMeasureSpec.Mode != OldWidthMeasureSpec.Mode) ||
                               (heightMeasureSpec.Mode != OldHeightMeasureSpec.Mode);

            bool isSpecExactly = (widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly) &&
                                 (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly);

            bool matchesSpecSize = (MeasuredWidth.Size == widthMeasureSpec.Size) &&
                                   (MeasuredHeight.Size == heightMeasureSpec.Size);

            bool needsLayout = specChanged && ( !isSpecExactly || !matchesSpecSize);
            needsLayout = needsLayout || ((Flags & LayoutFlags.ForceLayout) == LayoutFlags.ForceLayout);

            Log.Info("NUI", "Measuring:" + Owner.Name + " needsLayout[" + needsLayout.ToString() + "]\n");

            if (needsLayout)
            {
                OnMeasure(widthMeasureSpec, heightMeasureSpec);
                Flags = Flags | LayoutFlags.LayoutRequired;
                Flags &= ~LayoutFlags.ForceLayout;
            }
            OldWidthMeasureSpec = widthMeasureSpec;
            OldHeightMeasureSpec = heightMeasureSpec;

            Log.Info("NUI", "LayoutItem Measure owner:" + Owner.Name + " width:" + widthMeasureSpec.Size.AsRoundedValue() + " height:" +  heightMeasureSpec.Size.AsRoundedValue() + "\n");
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
            Log.Info("NUI", "LayoutItem Layout owner:" + Owner.Name + "\n");

            bool changed = SetFrame(left, top, right, bottom);

            // Check if Measure needed before Layouting
            if (changed || ((Flags & LayoutFlags.LayoutRequired) == LayoutFlags.LayoutRequired))
            {
                Log.Info("NUI", "LayoutItem Layout Frame changed or Layout forced\n");
                OnLayout(changed, left, top, right, bottom);
                // Clear flag
                Flags &= ~LayoutFlags.LayoutRequired;
            }
        }

        /// <summary>
        /// Utility to return a default size.<br />
        /// Uses the supplied size if the MeasureSpecification imposed no constraints. Will get larger if allowed by the
        /// MeasureSpecification.<br />
        /// </summary>
        /// <param name="size"> Default size for this layout.</param>
        /// <param name="measureSpecification"> Constraints imposed by the parent.</param>
        /// <returns>The size this layout should be.</returns>
        public static LayoutLength GetDefaultSize(LayoutLength size, MeasureSpecification measureSpecification)
        {
            LayoutLength result = size;
            MeasureSpecification.ModeType specMode = measureSpecification.Mode;
            LayoutLength specSize = measureSpecification.Size;

            switch (specMode)
            {
                case MeasureSpecification.ModeType.Unspecified:
                {
                    result = size;
                    break;
                }
                case MeasureSpecification.ModeType.AtMost:
                {
                    // Ensure the default size does not exceed the spec size unless the default size is 0.
                    // Another container could provide a default size of 0.

                    // Do not set size to 0, use specSize in this case as could be a legacy container
                    if( ( size.AsDecimal() < specSize.AsDecimal()) && ( size.AsDecimal() >  0) )
                    {
                        result = size;
                    }
                    else
                    {
                        result = specSize;
                    }
                    break;
                }
                case MeasureSpecification.ModeType.Exactly:
                {
                    result = specSize;
                    break;
                }
            }

            Log.Info("NUI", "DefaultSize :" + result.AsRoundedValue() +  "\n");

            return result;
        }

        public ILayoutParent GetParent()
        {
            return Parent;
        }

        /// <summary>
        /// Request that this layout is re-laid out.<br />
        /// This will make this layout and all it's parent layouts dirty.<br />
        /// </summary>
        public void RequestLayout()
        {
            Log.Info("NUI", "RequestLayout on:" + Owner?.Name + "\n");
            Flags = Flags | LayoutFlags.ForceLayout;
            Window.Instance.LayoutController.RequestLayout(this);
        }

        /// <summary>
        /// Predicate to determine if this layout has been requested to re-layout.<br />
        /// </summary>
        public bool LayoutRequested
        {
            get
            {
                return ( Flags & LayoutFlags.ForceLayout) == LayoutFlags.ForceLayout;
            }
        }

        /// <summary>
        /// Get the measured width (without any measurement flags).<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        public MeasuredSize MeasuredWidth{ get; set; } = new MeasuredSize( new LayoutLength(-3), MeasuredSize.StateType.MeasuredSizeOK);

        /// <summary>
        /// Get the measured height (without any measurement flags).<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        public MeasuredSize MeasuredHeight{ get; set; } = new MeasuredSize( new LayoutLength(-3), MeasuredSize.StateType.MeasuredSizeOK);

        /// <summary>
        /// Get the measured width and state.<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        public MeasuredSize MeasuredWidthAndState
        {
            get
            {
                return MeasuredWidth; // Not bitmasking State unless proven to be required.
            }
        }


        /// <summary>
        /// Get the measured height and state.<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        public MeasuredSize MeasuredHeightAndState
        {
            get
            {
                return MeasuredHeight;  // Not bitmasking State unless proven to be required.
            }
        }

        /// <summary>
        /// Returns the suggested minimum width that the layout should use.<br />
        /// This returns the maximum of the layout's minimum width and the owner's natural width.<br />
        /// </summary>
        public LayoutLength SuggestedMinimumWidth
        {
            get
            {
                int naturalWidth = Owner.NaturalSize2D.Width;
                Log.Info("NUI", "NaturalWidth for: " + Owner.Name + " :" + naturalWidth +"\n");
                return new LayoutLength(Math.Max( MinimumWidth.AsDecimal(), naturalWidth ));
            }
        }

        /// <summary>
        /// Returns the suggested minimum height that the layout should use.<br />
        /// This returns the maximum of the layout's minimum height and the owner's natural height.<br />
        /// </summary>
        public LayoutLength SuggestedMinimumHeight
        {
            get
            {
                int naturalHeight = Owner.NaturalSize2D.Height;
                Log.Info("NUI", "NaturalHeight for: " + Owner.Name + " :" + naturalHeight +"\n");
                return new LayoutLength(Math.Max( MinimumHeight.AsDecimal(), naturalHeight ));
            }
        }

        /// <summary>
        /// Sets the minimum width of the layout.<br />
        /// It is not guaranteed the layout will be able to achieve this minimum width (for example, if its parent
        /// layout constrains it with less available width).<br />
        /// 1. if the owner's View.LayoutWidthSpecification has exact value, then that value overrides the minimum size.<br />
        /// 2. If the owner's View.LayoutWidthSpecification is set to View.LayoutParamPolicies.WrapContent, then the view's width is set based on the suggested minimum width. (@see GetSuggestedMinimumWidth()).<br />
        /// 3. If the owner's View.LayoutWidthSpecification is set to View.LayoutParamPolicies.MatchParent, then the parent width takes precedence over the minimum width.<br />
        /// </summary>
        public LayoutLength MinimumWidth {get; set;}

        /// <summary>
        /// Sets the minimum height of the layout.<br />
        /// It is not guaranteed the layout will be able to achieve this minimum height (for example, if its parent
        /// layout constrains it with less available height).<br />
        /// 1. if the owner's View.LayoutHeightSpecification has exact value, then that value overrides the minimum size.<br />
        /// 2. If the owner's View.LayoutHeightSpecification is set to View.LayoutParamPolicies.WrapContent, then the view's height is set based on the suggested minimum height. (@see GetSuggestedMinimumHeight()).<br />
        /// 3. If the owner's View.LayoutHeightSpecification is set to View.LayoutParamPolicies.MatchParent, then the parent height takes precedence over the minimum height.<br />
        /// </summary>
        public LayoutLength MinimumHeight {get; set;}

        ///<summary>
        /// Utility to reconcile a desired size and state, with constraints imposed by a MeasureSpecification.
        ///</summary>
        /// <param name="size"> How big the layout wants to be.</param>
        /// <param name="measureSpecification"> Constraints imposed by the parent.</param>
        /// <param name="childMeasuredState"> Size information bit mask for the layout's children.</param>
        /// <returns> A measured size, which may indicate that it is too small. </returns>
        protected MeasuredSize ResolveSizeAndState( LayoutLength size, MeasureSpecification measureSpecification, MeasuredSize.StateType childMeasuredState )
        {
            var specMode = measureSpecification.Mode;
            LayoutLength specSize = measureSpecification.Size;
            MeasuredSize result = new MeasuredSize( size, childMeasuredState);

            switch( specMode )
            {
                case MeasureSpecification.ModeType.AtMost:
                {
                    if (specSize.AsRoundedValue() < size.AsRoundedValue())
                    {
                        result = new MeasuredSize( specSize, MeasuredSize.StateType.MeasuredSizeTooSmall);
                    }
                    break;
                }

                case MeasureSpecification.ModeType.Exactly:
                {
                    result.Size = specSize;
                    break;
                }

                case MeasureSpecification.ModeType.Unspecified:
                default:
                {
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// This method must be called by OnMeasure(MeasureSpec,MeasureSpec) to store the measured width and measured height.
        /// </summary>
        /// <param name="measuredWidth">The measured width of this layout.</param>
        /// <param name="measuredHeight">The measured height of this layout.</param>
        protected void SetMeasuredDimensions( MeasuredSize measuredWidth, MeasuredSize measuredHeight )
        {
            Log.Info("NUI", "For " + Owner.Name + " MeasuredWidth:" + measuredWidth.Size.AsRoundedValue()
                                   + " MeasureHeight:" + measuredHeight.Size.AsRoundedValue() + "\n");

            MeasuredWidth = measuredWidth;
            MeasuredHeight = measuredHeight;
            Flags = Flags | LayoutFlags.MeasuredDimensionSet;
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
        protected virtual void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            // GetDefaultSize will limit the MeasureSpec to the suggested minimumWidth and minimumHeight
            SetMeasuredDimensions( GetDefaultSize( SuggestedMinimumWidth, widthMeasureSpec ),
                                   GetDefaultSize( SuggestedMinimumHeight, heightMeasureSpec ) );
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

        /// <summary>
        /// Virtual method to allow derived classes to remove any children before it is removed from
        /// its parent.
        /// </summary>
        public virtual void OnUnparent()
        {
        }

        /// <summary>
        /// Virtual method called when this Layout is attached to it's owner.
        /// Allows derived layouts to take ownership of child Views and connect to any Owner signals required.
        /// </summary>
        protected virtual void OnAttachedToOwner()
        {
        }

        private bool SetFrame(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            bool changed = false;

            if( _left != left || _right != right || _top != top || _bottom != bottom  )
            {
                changed = true;
            }

            LayoutLength oldWidth = _right - _left;
            LayoutLength oldHeight = _bottom - _top;
            LayoutLength newWidth = right - left;
            LayoutLength newHeight = bottom - top;
            bool sizeChanged = ( newWidth != oldWidth ) || ( newHeight != oldHeight );

            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;

            // Set actual positions of View.
            Owner.SetX(_left.AsRoundedValue());
            Owner.SetY(_top.AsRoundedValue());
            Owner.SetSize((int)newWidth.AsRoundedValue(), (int)newHeight.AsRoundedValue());

            Log.Info("NUI", "Frame set for " + Owner.Name + " to left:" + _left.AsRoundedValue() + " top:"
                            + _top.AsRoundedValue() + " width: " + newWidth.AsRoundedValue() + " height: "
                            + newHeight.AsRoundedValue() + "\n");

            return changed;
        }

    }
}
