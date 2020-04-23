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

using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] The class that initiates the Measuring and Layouting of the tree,
    ///         It sets a callback that becomes the entry point into the C# Layouting.
    /// </summary>
    internal class LayoutController : Disposable
    {
        static bool LayoutDebugController = false; // Debug flag

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate void Callback(int id);

        event Callback _instance;

        private Window _window;

        Animation _coreAnimation;

        private List<LayoutData> _layoutTransitionDataQueue;

        private List<LayoutItem> _itemRemovalQueue;

        /// <summary>
        /// Constructs a LayoutController which controls the measuring and layouting.<br />
        /// <param name="window">Window attach this LayoutController to.</param>
        /// </summary>
        public LayoutController(Window window) : this(Interop.LayoutController.LayoutController_New(), true)
        {
            _window = window;
            _instance = new Callback(Process);
            Interop.LayoutController.LayoutController_SetCallback(swigCPtr, _instance);

            _layoutTransitionDataQueue = new List<LayoutData>();
        }

        internal LayoutController(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Get the unique id of the LayoutController
        /// </summary>
        public int GetId()
        {
            return Interop.LayoutController.LayoutController_GetId(swigCPtr);
        }

        /// <summary>
        /// Request relayout of a LayoutItem and it's parent tree.
        /// </summary>
        /// <param name="layoutItem">LayoutItem that is required to be laid out again.</param>
        public void RequestLayout(LayoutItem layoutItem)
        {
            // Go up the tree and mark all parents to relayout
            ILayoutParent layoutParent = layoutItem.GetParent();
            if (layoutParent != null)
            {
                 LayoutGroup layoutGroup =  layoutParent as LayoutGroup;
                 if(! layoutGroup.LayoutRequested)
                 {
                    layoutGroup.RequestLayout();
                 }
            }
        }

        /// <summary>
        /// Get the Layouting animation object that transitions layouts and content.
        /// Use OverrideCoreAnimation to explicitly control Playback.
        /// </summary>
        /// <returns> The layouting core Animation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Animation GetCoreAnimation()
        {
            return _coreAnimation;
        }

        /// <summary>
        /// Set or Get Layouting core animation override property.
        /// Gives explicit control over the Layouting animation playback if set to True.
        /// Reset to False if explicit control no longer required.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OverrideCoreAnimation {get;set;} = false;

        /// <summary>
        /// Add transition data for a LayoutItem to the transition stack.
        /// </summary>
        /// <param name="transitionDataEntry">Transition data for a LayoutItem.</param>
        internal void AddTransitionDataEntry( LayoutData transitionDataEntry)
        {
            _layoutTransitionDataQueue.Add(transitionDataEntry);
        }

        /// <summary>
        /// Add LayoutItem to a removal stack for removal after transitions finish.
        /// </summary>
        /// <param name="itemToRemove">LayoutItem to remove.</param>
        internal void AddToRemovalStack( LayoutItem itemToRemove)
        {
            if (_itemRemovalQueue == null)
            {
                _itemRemovalQueue = new List<LayoutItem>();
            }
            _itemRemovalQueue.Add(itemToRemove);
        }

        /// <summary>
        /// Dispose Explict or Implicit
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                Interop.LayoutController.delete_LayoutController(swigCPtr);
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        // Traverse the tree looking for a root node that is a layout.
        // Once found, it's children can be assigned Layouts and the Measure process started.
        private void FindRootLayouts(View rootNode)
        {
            if (rootNode.Layout != null)
            {
                Debug.WriteLineIf( LayoutDebugController, "LayoutController Root found:" + rootNode.Name);
                // rootNode has a layout, start measuring and layouting from here.
                MeasureAndLayout(rootNode);
            }
            else
            {
                // Search children of supplied node for a layout.
                for (uint i = 0; i < rootNode.ChildCount; i++)
                {
                    View view = rootNode.GetChildAt(i);
                    FindRootLayouts(view);
                }
            }
        }

        // Starts of the actual measuring and layouting from the given root node.
        // Can be called from multiple starting roots but in series.
        void MeasureAndLayout(View root)
        {
            if (root !=null)
            {
                // Get parent MeasureSpecification, this could be the Window or View with an exact size.
                Container parentNode = root.GetParent();
                Size2D rootSize;
                Position2D rootPosition = root.Position2D;
                View parentView = parentNode as View;
                if (parentView)
                {
                    // Get parent View's Size.  If using Legacy size negotiation then should have been set already.
                    rootSize = new Size2D(parentView.Size2D.Width, parentView.Size2D.Height);
                }
                else
                {
                    // Parent not a View so assume it's a Layer which is the size of the window.
                    rootSize = new Size2D(_window.Size.Width, _window.Size.Height);
                }

                // Determine measure specification for root.
                // The root layout policy could be an exact size, be match parent or wrap children.
                // If wrap children then at most it can be the root parent size.
                // If match parent then should be root parent size.
                // If exact then should be that size limited by the root parent size.

                LayoutLength width = new LayoutLength(rootSize.Width);
                LayoutLength height = new LayoutLength(rootSize.Height);
                MeasureSpecification.ModeType widthMode = MeasureSpecification.ModeType.Unspecified;
                MeasureSpecification.ModeType heightMode = MeasureSpecification.ModeType.Unspecified;

                if ( root.WidthSpecification >= 0 )
                {
                    // exact size provided so match width exactly
                    width = new LayoutLength(root.WidthSpecification);
                    widthMode = MeasureSpecification.ModeType.Exactly;
                }
                else if (root.WidthSpecification == LayoutParamPolicies.MatchParent)
                {

                    widthMode = MeasureSpecification.ModeType.Exactly;
                }

                if (root.HeightSpecification >= 0 )
                {
                    // exact size provided so match height exactly
                    height = new LayoutLength(root.HeightSpecification);
                    heightMode = MeasureSpecification.ModeType.Exactly;
                }
                else if (root.HeightSpecification == LayoutParamPolicies.MatchParent)
                {
                    heightMode = MeasureSpecification.ModeType.Exactly;
                }

                MeasureSpecification parentWidthSpecification =
                    new MeasureSpecification( width, widthMode);

                MeasureSpecification parentHeightSpecification =
                    new MeasureSpecification( height, heightMode);

                // Start at root with it's parent's widthSpecification and heightSpecification
                MeasureHierarchy(root, parentWidthSpecification, parentHeightSpecification);

                // Start at root which was just measured.
                PerformLayout( root, new LayoutLength(rootPosition.X),
                                     new LayoutLength(rootPosition.Y),
                                     new LayoutLength(rootPosition.X) + root.Layout.MeasuredWidth.Size,
                                     new LayoutLength(rootPosition.Y) + root.Layout.MeasuredHeight.Size );

                bool readyToPlay = SetupCoreAnimation();

                if (readyToPlay && OverrideCoreAnimation==false)
                {
                    PlayAnimation();
                }
            }
        }

        /// <summary>
        /// Entry point into the C# Layouting that starts the Processing
        /// </summary>
        private void Process(int id)
        {
            // First layer in the Window should be the default layer (index 0 )
            uint numberOfLayers = _window.LayerCount;
            for (uint layerIndex = 0; layerIndex < numberOfLayers; layerIndex++)
            {
                Layer layer = _window.GetLayer(layerIndex);
                if (layer)
                {
                    for (uint i = 0; i < layer.ChildCount; i++)
                    {
                        View view = layer.GetChildAt(i);
                        FindRootLayouts(view);
                    }
                }
            }

        }

        /// <summary>
        /// Starts measuring the tree, starting from the root layout.
        /// </summary>
        private void MeasureHierarchy(View root, MeasureSpecification widthSpec, MeasureSpecification heightSpec)
        {
            // Does this View have a layout?
            // Yes - measure the layout. It will call this method again for each of it's children.
            // No -  reached leaf or no layouts set
            //
            // If in a leaf View with no layout, it's natural size is bubbled back up.

            if (root.Layout != null)
            {
                root.Layout.Measure(widthSpec, heightSpec);
            }
        }

        /// <summary>
        /// Performs the layouting positioning
        /// </summary>
        private void PerformLayout(View root, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            if(root.Layout != null)
            {
                root.Layout.Layout(left, top, right, bottom);
            }
        }

        /// <summary>
        /// Play the animation.
        /// </summary>
        private void PlayAnimation()
        {
            Debug.WriteLineIf( LayoutDebugController, "LayoutController Playing, Core Duration:" + _coreAnimation.Duration);
            _coreAnimation.Play();
        }

        private void AnimationFinished(object sender, EventArgs e)
        {
            // Iterate list of LayoutItem that were set for removal.
            // Now the core animation has finished their Views can be removed.
            if (_itemRemovalQueue != null)
            {
                foreach (LayoutItem item in _itemRemovalQueue)
                {
                    // Check incase the parent was already removed and the Owner was
                    // removed already.
                    if (item.Owner)
                    {
                        // Check again incase the parent has already been removed.
                        ILayoutParent layoutParent = item.GetParent();
                        LayoutGroup layoutGroup = layoutParent as LayoutGroup;
                        if (layoutGroup !=null)
                        {
                            layoutGroup.Owner?.RemoveChild(item.Owner);
                        }

                    }
                }
                _itemRemovalQueue.Clear();
                // If LayoutItems added to stack whilst the core animation is playing
                // they would have been cleared here.
                // Could have another stack to be added to whilst the animation is running.
                // After the running stack is cleared it can be populated with the content
                // of the other stack.  Then the main removal stack iterated when AnimationFinished
                // occurs again.
            }
            Debug.WriteLineIf( LayoutDebugController, "LayoutController AnimationFinished");
            _coreAnimation?.Clear();
        }

        /// <summary>
        /// Set up the animation from each LayoutItems position data.
        /// Iterates the transition stack, adding an Animator to the core animation.
        /// </summary>
        private bool SetupCoreAnimation()
        {
            // Initialize animation for this layout run.
            bool animationPending = false;

            Debug.WriteLineIf( LayoutDebugController,
                               "LayoutController SetupCoreAnimation for:" + _layoutTransitionDataQueue.Count);

            if (_layoutTransitionDataQueue.Count > 0 ) // Something to animate
            {
                if (!_coreAnimation)
                {
                    _coreAnimation = new Animation();
                }
                _coreAnimation.EndAction = Animation.EndActions.StopFinal;
                _coreAnimation.Finished += AnimationFinished;

                // Iterate all items that have been queued for repositioning.
                foreach (LayoutData layoutPositionData in _layoutTransitionDataQueue)
                {
                    AddAnimatorsToAnimation(layoutPositionData);
                }

                animationPending = true;

                // transitions have now been applied, clear stack, ready for new transitions on
                // next layout traversal.
                _layoutTransitionDataQueue.Clear();
            }
            return animationPending;
        }

        private void SetupAnimationForPosition(LayoutData layoutPositionData, TransitionComponents positionTransitionComponents)
        {
            // A removed item does not have a valid target position within the layout so don't try to position.
            if( layoutPositionData.ConditionForAnimation != TransitionCondition.Remove )
            {
                _coreAnimation.AnimateTo(layoutPositionData.Item.Owner, "Position",
                            new Vector3(layoutPositionData.Left,
                                        layoutPositionData.Top,
                                        layoutPositionData.Item.Owner.Position.Z),
                            positionTransitionComponents.Delay,
                            positionTransitionComponents.Duration,
                            positionTransitionComponents.AlphaFunction );

                Debug.WriteLineIf( LayoutDebugController,
                                   "LayoutController SetupAnimationForPosition View:" + layoutPositionData.Item.Owner.Name +
                                   " left:" + layoutPositionData.Left +
                                   " top:" + layoutPositionData.Top +
                                   " delay:" + positionTransitionComponents.Delay +
                                   " duration:" + positionTransitionComponents.Duration );
            }
        }

        private void SetupAnimationForSize(LayoutData layoutPositionData, TransitionComponents sizeTransitionComponents)
        {
            // Text size cant be animated so is set to it's final size.
            // It is due to the internals of the Text not being able to recalculate fast enough.
            if (layoutPositionData.Item.Owner is TextLabel || layoutPositionData.Item.Owner is TextField)
            {
                float itemWidth = layoutPositionData.Right-layoutPositionData.Left;
                float itemHeight = layoutPositionData.Bottom-layoutPositionData.Top;
                // Set size directly.
                layoutPositionData.Item.Owner.Size2D = new Size2D((int)itemWidth, (int)itemHeight);
            }
            else
            {
                _coreAnimation.AnimateTo(layoutPositionData.Item.Owner, "Size",
                                         new Vector3(layoutPositionData.Right-layoutPositionData.Left,
                                                     layoutPositionData.Bottom-layoutPositionData.Top,
                                                     layoutPositionData.Item.Owner.Position.Z),
                                         sizeTransitionComponents.Delay,
                                         sizeTransitionComponents.Duration,
                                         sizeTransitionComponents.AlphaFunction);

                Debug.WriteLineIf( LayoutDebugController,
                                  "LayoutController SetupAnimationForSize View:" + layoutPositionData.Item.Owner.Name +
                                   " width:" + (layoutPositionData.Right-layoutPositionData.Left) +
                                   " height:" + (layoutPositionData.Bottom-layoutPositionData.Top) +
                                   " delay:" + sizeTransitionComponents.Delay +
                                   " duration:" + sizeTransitionComponents.Duration );
            }
        }

        void SetupAnimationForCustomTransitions(TransitionList transitionsToAnimate, View view )
        {
            if (transitionsToAnimate?.Count > 0)
            {
                foreach (LayoutTransition transition in transitionsToAnimate)
                {
                    if ( transition.AnimatableProperty != AnimatableProperties.Position &&
                        transition.AnimatableProperty != AnimatableProperties.Size )
                    {
                        _coreAnimation.AnimateTo(view,
                                                 transition.AnimatableProperty.ToString(),
                                                 transition.TargetValue,
                                                 transition.Animator.Delay,
                                                 transition.Animator.Duration,
                                                 transition.Animator.AlphaFunction );

                        Debug.WriteLineIf( LayoutDebugController,
                                           "LayoutController SetupAnimationForCustomTransitions View:" + view.Name +
                                           " Property:" + transition.AnimatableProperty.ToString() +
                                           " delay:" + transition.Animator.Delay +
                                           " duration:" + transition.Animator.Duration );
                    }
                }
            }
        }

        /// <summary>
        /// Iterate transitions and replace Position Components if replacements found in list.
        /// </summary>
        private void FindAndReplaceAnimatorComponentsForProperty(TransitionList sourceTransitionList,
                                                                 AnimatableProperties propertyToMatch,
                                                                 ref TransitionComponents transitionComponentToUpdate)
        {
            foreach( LayoutTransition transition in sourceTransitionList)
            {
                if (transition.AnimatableProperty == propertyToMatch)
                {
                    // Matched property to animate is for the propertyToMatch so use provided Animator.
                    transitionComponentToUpdate = transition.Animator;
                }
            }
        }

        private TransitionComponents CreateDefaultTransitionComponent( int delay, int duration )
        {
            AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);
            return new TransitionComponents(delay, duration, alphaFunction);
        }

        /// <summary>
        /// Sets up the main animation with the animators for each item (each layoutPositionData structure)
        /// </summary>
        private void AddAnimatorsToAnimation( LayoutData layoutPositionData )
        {
            LayoutTransition positionTransition = new LayoutTransition();
            LayoutTransition sizeTransition = new LayoutTransition();
            TransitionCondition conditionForAnimators = layoutPositionData.ConditionForAnimation;

            // LayoutChanged transitions overrides ChangeOnAdd and ChangeOnRemove as siblings will
            // reposition to the new layout not to the insertion/removal of a sibling.
            if (layoutPositionData.ConditionForAnimation.HasFlag(TransitionCondition.LayoutChanged))
            {
                conditionForAnimators = TransitionCondition.LayoutChanged;
            }

            // Set up a default transitions, will be overwritten if inherited from parent or set explicitly.
            TransitionComponents positionTransitionComponents = CreateDefaultTransitionComponent(0, 300);
            TransitionComponents sizeTransitionComponents = CreateDefaultTransitionComponent(0, 300);

            bool matchedCustomTransitions = false;


            TransitionList transitionsForCurrentCondition = new TransitionList();
            // Note, Transitions set on View rather than LayoutItem so if the Layout changes the transition persist.

            // Check if item to animate has it's own Transitions for this condition.
            // If a key exists then a List of atleast 1 transition exists.
            if (layoutPositionData.Item.Owner.LayoutTransitions.ContainsKey(conditionForAnimators))
            {
                // Child has transitions for the condition
                matchedCustomTransitions = layoutPositionData.Item.Owner.LayoutTransitions.TryGetValue(conditionForAnimators, out transitionsForCurrentCondition);
            }

            if (!matchedCustomTransitions)
            {
                // Inherit parent transitions as none already set on View for the condition.
                ILayoutParent layoutParent = layoutPositionData.Item.GetParent();
                if (layoutParent !=null)
                {
                    // Item doesn't have it's own transitions for this condition so copy parents if
                    // has a parent with transitions.
                    LayoutGroup layoutGroup = layoutParent as LayoutGroup;
                    TransitionList parentTransitionList;
                    // Note TryGetValue returns null if key not matched.
                    if (layoutGroup !=null && layoutGroup.Owner.LayoutTransitions.TryGetValue(conditionForAnimators, out parentTransitionList))
                    {
                        // Copy parent transitions to temporary TransitionList. List contains transitions for the current condition.
                        LayoutTransitionsHelper.CopyTransitions(parentTransitionList,
                                                                transitionsForCurrentCondition);
                    }
                }
            }


            // Position/Size transitions can be displayed for a layout changing to another layout or an item being added or removed.

            // There can only be one position transition and one size position, they will be replaced if set multiple times.
            // transitionsForCurrentCondition represent all non position (custom) properties that should be animated.

            // Search for Position property in the transitionsForCurrentCondition list of custom transitions,
            // and only use the particular parts of the animator as custom transitions should not effect all parameters of Position.
            // Typically Delay, Duration and Alphafunction can be custom.
            FindAndReplaceAnimatorComponentsForProperty(transitionsForCurrentCondition,
                                                        AnimatableProperties.Position,
                                                        ref positionTransitionComponents);

            // Size
            FindAndReplaceAnimatorComponentsForProperty(transitionsForCurrentCondition,
                                                        AnimatableProperties.Size,
                                                        ref sizeTransitionComponents);

            // Add animators to the core Animation,

            SetupAnimationForCustomTransitions(transitionsForCurrentCondition, layoutPositionData.Item.Owner);

            SetupAnimationForPosition(layoutPositionData, positionTransitionComponents);

            SetupAnimationForSize(layoutPositionData, sizeTransitionComponents);
        }

    } // class LayoutController
} // namespace Tizen.NUI
