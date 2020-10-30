/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using System.Diagnostics;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

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
    public class LayoutItem
    {
        static bool LayoutDebugFrameData = false; // Debug flag
        private MeasureSpecification OldWidthMeasureSpec; // Store measure specification to compare against later
        private MeasureSpecification OldHeightMeasureSpec;// Store measure specification to compare against later

        private LayoutFlags Flags = LayoutFlags.None;

        private ILayoutParent Parent;

        LayoutData _layoutPositionData;

        private Extents _padding;
        private Extents _margin;

        private bool parentReplacement = false;

        /// <summary>
        /// [Draft] Condition event that is causing this Layout to transition.
        /// </summary>
        internal TransitionCondition ConditionForAnimation{get; set;}

        /// <summary>
        /// [Draft] The View that this Layout has been assigned to.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public View Owner{get; set;}  // Should not keep a View alive.

        /// <summary>
        /// [Draft] Use transition for layouting child
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
         public bool LayoutWithTransition{get; set;}

        /// <summary>
        /// [Draft] Set position by layouting result
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetPositionByLayout{get;set;} = true;

        /// <summary>
        /// [Draft] Margin for this LayoutItem
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Extents Margin
        {
            get
            {
                return _margin;
            }
            set
            {
                _margin = value;
                RequestLayout();
            }
        }

        /// <summary>
        /// [Draft] Padding for this LayoutItem
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Extents Padding
        {
            get
            {
                return _padding;
            }
            set
            {
                _padding = value;
                RequestLayout();
            }
        }

        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LayoutItem()
        {
            Initialize();
        }

        /// <summary>
        /// [Draft] Set parent to this layout.
        /// </summary>
        /// <param name="parent">Parent to set on this Layout.</param>
        internal void SetParent( ILayoutParent parent)
        {
            Parent = parent as LayoutGroup;
        }

        /// <summary>
        /// Unparent this layout from it's owner, and remove any layout children in derived types. <br />
        /// </summary>
        internal void Unparent()
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

        private void Initialize()
        {
            LayoutWithTransition = false;
            _layoutPositionData = new LayoutData(this,TransitionCondition.Unspecified,0,0,0,0);
            _padding = new Extents(0,0,0,0);
            _margin = new Extents(0,0,0,0);
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

            // If Add or ChangeOnAdd then do not update condition
            if (ConditionForAnimation.Equals(TransitionCondition.Unspecified))
            {
                ConditionForAnimation = TransitionCondition.LayoutChanged;
            }
        }

        /// <summary>
        /// This is called to find out how big a layout should be. <br />
        /// The parent supplies constraint information in the width and height parameters. <br />
        /// The actual measurement work of a layout is performed in OnMeasure called by this
        /// method. Therefore, only OnMeasure can and must be overridden by subclasses. <br />
        /// </summary>
        /// <param name="widthMeasureSpec"> Horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">Vertical space requirements as imposed by the parent.</param>
        /// <since_tizen> 6 </since_tizen>
        public void Measure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
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

            if (needsLayout)
            {
                OnMeasure(widthMeasureSpec, heightMeasureSpec);
                Flags = Flags | LayoutFlags.LayoutRequired;
                Flags &= ~LayoutFlags.ForceLayout;
            }
            OldWidthMeasureSpec = widthMeasureSpec;
            OldHeightMeasureSpec = heightMeasureSpec;
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
        /// <since_tizen> 6 </since_tizen>
        public void Layout(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            bool changed = SetFrame(left.AsRoundedValue(),
                                    top.AsRoundedValue(),
                                    right.AsRoundedValue(),
                                    bottom.AsRoundedValue());

            // Check if Measure needed before Layouting
            if (changed || ((Flags & LayoutFlags.LayoutRequired) == LayoutFlags.LayoutRequired))
            {
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
        /// <since_tizen> 6 </since_tizen>
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

            return result;
        }

        /// <summary>
        /// Get the Layouts parent
        /// </summary>
        /// <returns>Layout parent with an LayoutParent interface</returns>
        /// <since_tizen> 6 </since_tizen>
        public ILayoutParent GetParent()
        {
            return Parent;
        }

        /// <summary>
        /// Request that this layout is re-laid out.<br />
        /// This will make this layout and all it's parent layouts dirty.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void RequestLayout()
        {
            Flags = Flags | LayoutFlags.ForceLayout;
            if (Parent != null)
            {
                 LayoutGroup layoutGroup =  Parent as LayoutGroup;
                 if(! layoutGroup.LayoutRequested)
                 {
                    layoutGroup.RequestLayout();
                 }
            }
			
        }

        /// <summary>
        /// Predicate to determine if this layout has been requested to re-layout.<br />
        /// </summary>

        internal bool LayoutRequested
        {
            get
            {
                return ( Flags & LayoutFlags.ForceLayout) == LayoutFlags.ForceLayout;
            }
        }

        internal void SetReplaceFlag()
        {
            parentReplacement = true;
        }

        internal bool IsReplaceFlag()
        {
            return parentReplacement;
        }

        internal void ClearReplaceFlag()
        {
            parentReplacement = false;
        }

        /// <summary>
        /// Get the measured width (without any measurement flags).<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public MeasuredSize MeasuredWidth{ get; set; } = new MeasuredSize( new LayoutLength(-3), MeasuredSize.StateType.MeasuredSizeOK);

        /// <summary>
        /// Get the measured height (without any measurement flags).<br />
        /// This method should be used only during measurement and layout calculations.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public MeasuredSize MeasuredHeight{ get; set; } = new MeasuredSize( new LayoutLength(-3), MeasuredSize.StateType.MeasuredSizeOK);

        /// <summary>
        /// Returns the suggested minimum width that the layout should use.<br />
        /// This returns the maximum of the layout's minimum width and the owner's natural width.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LayoutLength SuggestedMinimumWidth
        {
            get
            {
                float maximumWidth = Owner.MaximumSize.Width;
                float minimumWidth = Owner.MinimumSize.Width;

                float baseHeight = Owner.MaximumSize.Height > 0 ? Math.Min(Owner.MaximumSize.Height,Owner.NaturalSize.Height) : Owner.NaturalSize.Height;
                float baseWidth = Owner.GetWidthForHeight(baseHeight);

                float result = minimumWidth > 0 ? Math.Max(baseWidth, minimumWidth) : baseWidth;
                result = maximumWidth > 0 ? Math.Min(result, maximumWidth) : result;

                return new LayoutLength(result);
            }
        }

        /// <summary>
        /// Returns the suggested minimum height that the layout should use.<br />
        /// This returns the maximum of the layout's minimum height and the owner's natural height.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LayoutLength SuggestedMinimumHeight
        {
            get
            {
                float maximumHeight = Owner.MaximumSize.Height;
                float minimumHeight = Owner.MinimumSize.Height;

                float baseWidth = Owner.MaximumSize.Width > 0 ? Math.Min(Owner.MaximumSize.Width,Owner.NaturalSize.Width) : Owner.NaturalSize.Width;
                float baseHeight = Owner.GetHeightForWidth(baseWidth);

                float result = minimumHeight > 0 ? Math.Max(baseHeight, minimumHeight) : baseHeight;
                result = maximumHeight > 0 ? Math.Min(result, maximumHeight) : result;

                return new LayoutLength(result);
            }
        }

        /// <summary>
        /// Sets the minimum width of the layout.<br />
        /// It is not guaranteed the layout will be able to achieve this minimum width (for example, if its parent
        /// layout constrains it with less available width).<br />
        /// 1. if the owner's View.WidthSpecification has exact value, then that value overrides the minimum size.<br />
        /// 2. If the owner's View.WidthSpecification is set to View.LayoutParamPolicies.WrapContent, then the view's width is set based on the suggested minimum width. (@see GetSuggestedMinimumWidth()).<br />
        /// 3. If the owner's View.WidthSpecification is set to View.LayoutParamPolicies.MatchParent, then the parent width takes precedence over the minimum width.<br />
        /// </summary>
        internal LayoutLength MinimumWidth {get; set;}

        /// <summary>
        /// Sets the minimum height of the layout.<br />
        /// It is not guaranteed the layout will be able to achieve this minimum height (for example, if its parent
        /// layout constrains it with less available height).<br />
        /// 1. if the owner's View.HeightSpecification has exact value, then that value overrides the minimum size.<br />
        /// 2. If the owner's View.HeightSpecification is set to View.LayoutParamPolicies.WrapContent, then the view's height is set based on the suggested minimum height. (@see GetSuggestedMinimumHeight()).<br />
        /// 3. If the owner's View.HeightSpecification is set to View.LayoutParamPolicies.MatchParent, then the parent height takes precedence over the minimum height.<br />
        /// </summary>
        internal LayoutLength MinimumHeight {get; set;}

        ///<summary>
        /// Utility to reconcile a desired size and state, with constraints imposed by a MeasureSpecification.
        ///</summary>
        /// <param name="size"> How big the layout wants to be.</param>
        /// <param name="measureSpecification"> Constraints imposed by the parent.</param>
        /// <param name="childMeasuredState"> Size information bit mask for the layout's children.</param>
        /// <returns> A measured size, which may indicate that it is too small. </returns>
        /// <since_tizen> 6 </since_tizen>
        protected MeasuredSize ResolveSizeAndState( LayoutLength size, MeasureSpecification measureSpecification, MeasuredSize.StateType childMeasuredState )
        {
            var specMode = measureSpecification.Mode;
            LayoutLength specSize = measureSpecification.Size;
            MeasuredSize result = new MeasuredSize( size, childMeasuredState );

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
        /// <since_tizen> 6 </since_tizen>
        protected void SetMeasuredDimensions( MeasuredSize measuredWidth, MeasuredSize measuredHeight )
        {
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
        }

        /// <summary>
        /// Virtual method to allow derived classes to remove any children before it is removed from
        /// its parent.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnUnparent()
        {
        }

        /// <summary>
        /// Virtual method called when this Layout is attached to it's owner.
        /// Allows derived layouts to take ownership of child Views and connect to any Owner signals required.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnAttachedToOwner()
        {
        }

        private bool SetFrame(float left, float top, float right, float bottom)
        {
            bool changed = false;

            if ( _layoutPositionData.Left != left ||
                 _layoutPositionData.Right != right ||
                 _layoutPositionData.Top != top ||
                 _layoutPositionData.Bottom != bottom  )
            {
                changed = true;

                float oldWidth = _layoutPositionData.Right - _layoutPositionData.Left;
                float oldHeight = _layoutPositionData.Bottom - _layoutPositionData.Top;
                float newWidth = right - left;
                float newHeight = bottom - top;
                bool sizeChanged = ( newWidth != oldWidth ) || ( newHeight != oldHeight );

                // Set condition to layout changed as currently unspecified. Add, Remove would have specified a condition.
                if (ConditionForAnimation.Equals(TransitionCondition.Unspecified))
                {
                    ConditionForAnimation = TransitionCondition.LayoutChanged;
                }

                // Store new layout position data
                _layoutPositionData = new LayoutData(this, ConditionForAnimation, left, top, right, bottom);

                Debug.WriteLineIf( LayoutDebugFrameData, "LayoutItem FramePositionData View:" + _layoutPositionData.Item.Owner.Name +
                                                         " left:" + _layoutPositionData.Left +
                                                         " top:" + _layoutPositionData.Top +
                                                         " right:" + _layoutPositionData.Right +
                                                         " bottom:" + _layoutPositionData.Bottom );

                if (Owner.Parent != null && Owner.Parent.Layout != null && Owner.Parent.Layout.LayoutWithTransition)
                {
                    NUIApplication.GetDefaultWindow().LayoutController.AddTransitionDataEntry(_layoutPositionData);
                }
                else
                {
                    Owner.SetSize(right - left, bottom - top, Owner.Position.Z);
                    if(SetPositionByLayout)
                    {
                        Owner.SetPosition(left, top, Owner.Position.Z);
                    }
                }


                // Reset condition for animation ready for next transition when required.
                ConditionForAnimation = TransitionCondition.Unspecified;
            }

            return changed;
        }
    }
}
