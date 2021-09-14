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

using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
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
        private static int layoutControllerID = 1;

        private int id;
        private Window window;
        private Animation coreAnimation;
        private List<LayoutData> layoutTransitionDataQueue;
        private List<LayoutItem> itemRemovalQueue;
        private float windowWidth;
        private float windowHeight;

        private bool subscribed;

        /// <summary>
        /// Constructs a LayoutController which controls the measuring and layouting.<br />
        /// <param name="window">Window attach this LayoutController to.</param>
        /// </summary>
        public LayoutController(Window window)
        {
            this.window = window;
            this.window.Resized += OnWindowResized;
            var windowSize = window.GetSize();
            windowWidth = windowSize.Width;
            windowHeight = windowSize.Height;

            layoutTransitionDataQueue = new List<LayoutData>();
            id = layoutControllerID++;

            windowSize.Dispose();
            windowSize = null;
        }

        private void OnWindowResized(object sender, Window.ResizedEventArgs e)
        {
            windowWidth = e.WindowSize.Width;
            windowHeight = e.WindowSize.Height;
        }

        /// <summary>
        /// Set or Get Layouting core animation override property.
        /// Gives explicit control over the Layouting animation playback if set to True.
        /// Reset to False if explicit control no longer required.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OverrideCoreAnimation { get; set; } = false;

        /// <summary>
        /// Get the unique id of the LayoutController
        /// </summary>
        public int GetId()
        {
            return id;
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
                LayoutGroup layoutGroup = layoutParent as LayoutGroup;
                if (layoutGroup != null && !layoutGroup.LayoutRequested)
                {
                    layoutGroup.RequestLayout();
                }
            }
        }


        /// <summary>
        /// Entry point into the C# Layouting that starts the Processing
        /// </summary>
        public void Process(object source, EventArgs e)
        {
            window.LayersChildren?.ForEach(layer =>
            {
                layer?.Children?.ForEach(view =>
                {
                    if (view != null)
                    {
                        FindRootLayouts(view, windowWidth, windowHeight);
                    }
                });
            });

            if (SetupCoreAnimation() && OverrideCoreAnimation == false)
            {
                PlayAnimation();
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
            return coreAnimation;
        }

        /// <summary>
        /// Create and set process callback
        /// </summary>
        internal void CreateProcessCallback()
        {
            if (!subscribed)
            {
                ProcessorController.Instance.LayoutProcessorEvent += Process;
                subscribed = true;
            }
        }

        /// <summary>
        /// Add transition data for a LayoutItem to the transition stack.
        /// </summary>
        /// <param name="transitionDataEntry">Transition data for a LayoutItem.</param>
        internal void AddTransitionDataEntry(LayoutData transitionDataEntry)
        {
            layoutTransitionDataQueue.Add(transitionDataEntry);
        }

        /// <summary>
        /// Add LayoutItem to a removal stack for removal after transitions finish.
        /// </summary>
        /// <param name="itemToRemove">LayoutItem to remove.</param>
        internal void AddToRemovalStack(LayoutItem itemToRemove)
        {
            if (itemRemovalQueue == null)
            {
                itemRemovalQueue = new List<LayoutItem>();
            }
            itemRemovalQueue.Add(itemToRemove);
        }

        /// <summary>
        /// Dispose Explicit or Implicit
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (subscribed)
            {
                ProcessorController.Instance.LayoutProcessorEvent -= Process;
                subscribed = false;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (SwigCPtr.Handle != global::System.IntPtr.Zero)
            {
                SwigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        // Traverse the tree looking for a root node that is a layout.
        // Once found, it's children can be assigned Layouts and the Measure process started.
        private void FindRootLayouts(View rootNode, float parentWidth, float parentHeight)
        {
            if (rootNode.Layout != null)
            {
                NUILog.Debug("LayoutController Root found:" + rootNode.Name);
                // rootNode has a layout, start measuring and layouting from here.
                MeasureAndLayout(rootNode, parentWidth, parentHeight);
            }
            else
            {
                float rootWidth = rootNode.SizeWidth;
                float rootHeight = rootNode.SizeHeight;
                // Search children of supplied node for a layout.
                for (uint i = 0; i < rootNode.ChildCount; i++)
                {
                    FindRootLayouts(rootNode.GetChildAt(i), rootWidth, rootHeight);
                }
            }
        }

        // Starts of the actual measuring and layouting from the given root node.
        // Can be called from multiple starting roots but in series.
        // Get parent View's Size.  If using Legacy size negotiation then should have been set already.
        // Parent not a View so assume it's a Layer which is the size of the window.
        private void MeasureAndLayout(View root, float parentWidth, float parentHeight)
        {
            if (root.Layout != null)
            {
                // Determine measure specification for root.
                // The root layout policy could be an exact size, be match parent or wrap children.
                // If wrap children then at most it can be the root parent size.
                // If match parent then should be root parent size.
                // If exact then should be that size limited by the root parent size.
                float widthSize = GetLengthSize(parentWidth, root.WidthSpecification);
                float heightSize = GetLengthSize(parentHeight, root.HeightSpecification);
                var widthMode = GetMode(root.WidthSpecification);
                var heightMode = GetMode(root.HeightSpecification);

                if (root.Layout.NeedsLayout(widthSize, heightSize, widthMode, heightMode))
                {
                    var widthSpec = CreateMeasureSpecification(widthSize, widthMode);
                    var heightSpec = CreateMeasureSpecification(heightSize, heightMode);

                    // Start at root with it's parent's widthSpecification and heightSpecification
                    MeasureHierarchy(root, widthSpec, heightSpec);
                }

                float positionX = root.PositionX;
                float positionY = root.PositionY;
                // Start at root which was just measured.
                PerformLayout(root, new LayoutLength(positionX),
                                     new LayoutLength(positionY),
                                     new LayoutLength(positionX) + root.Layout.MeasuredWidth.Size,
                                     new LayoutLength(positionY) + root.Layout.MeasuredHeight.Size);
            }
        }

        private float GetLengthSize(float size, int specification)
        {
            // exact size provided so match width exactly
            return (specification >= 0) ? specification : size;
        }

        private MeasureSpecification.ModeType GetMode(int specification)
        {
            if (specification >= 0 || specification == LayoutParamPolicies.MatchParent)
            {
                return MeasureSpecification.ModeType.Exactly;
            }
            return MeasureSpecification.ModeType.Unspecified;
        }

        private MeasureSpecification CreateMeasureSpecification(float size, MeasureSpecification.ModeType mode)
        {
            return new MeasureSpecification(new LayoutLength(size), mode);
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
            root.Layout?.Measure(widthSpec, heightSpec);
        }

        /// <summary>
        /// Performs the layouting positioning
        /// </summary>
        private void PerformLayout(View root, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            root.Layout?.Layout(left, top, right, bottom);
        }

        /// <summary>
        /// Play the animation.
        /// </summary>
        private void PlayAnimation()
        {
            NUILog.Debug("LayoutController Playing, Core Duration:" + coreAnimation.Duration);
            coreAnimation.Play();
        }

        private void AnimationFinished(object sender, EventArgs e)
        {
            // Iterate list of LayoutItem that were set for removal.
            // Now the core animation has finished their Views can be removed.
            if (itemRemovalQueue != null)
            {
                foreach (LayoutItem item in itemRemovalQueue)
                {
                    // Check incase the parent was already removed and the Owner was
                    // removed already.
                    if (item.Owner)
                    {
                        // Check again incase the parent has already been removed.
                        ILayoutParent layoutParent = item.GetParent();
                        LayoutGroup layoutGroup = layoutParent as LayoutGroup;
                        if (layoutGroup != null)
                        {
                            layoutGroup.Owner?.RemoveChild(item.Owner);
                        }

                    }
                }
                itemRemovalQueue.Clear();
                // If LayoutItems added to stack whilst the core animation is playing
                // they would have been cleared here.
                // Could have another stack to be added to whilst the animation is running.
                // After the running stack is cleared it can be populated with the content
                // of the other stack.  Then the main removal stack iterated when AnimationFinished
                // occurs again.
            }
            NUILog.Debug("LayoutController AnimationFinished");
            coreAnimation?.Clear();
        }

        /// <summary>
        /// Set up the animation from each LayoutItems position data.
        /// Iterates the transition stack, adding an Animator to the core animation.
        /// </summary>
        private bool SetupCoreAnimation()
        {
            // Initialize animation for this layout run.
            bool animationPending = false;

            NUILog.Debug("LayoutController SetupCoreAnimation for:" + layoutTransitionDataQueue.Count);

            if (layoutTransitionDataQueue.Count > 0) // Something to animate
            {
                if (!coreAnimation)
                {
                    coreAnimation = new Animation();
                }
                coreAnimation.EndAction = Animation.EndActions.StopFinal;
                coreAnimation.Finished += AnimationFinished;

                // Iterate all items that have been queued for repositioning.
                foreach (LayoutData layoutPositionData in layoutTransitionDataQueue)
                {
                    AddAnimatorsToAnimation(layoutPositionData);
                }

                animationPending = true;

                // transitions have now been applied, clear stack, ready for new transitions on
                // next layout traversal.
                layoutTransitionDataQueue.Clear();
            }
            return animationPending;
        }

        private void SetupAnimationForPosition(LayoutData layoutPositionData, TransitionComponents positionTransitionComponents)
        {
            // A removed item does not have a valid target position within the layout so don't try to position.
            if (layoutPositionData.ConditionForAnimation != TransitionCondition.Remove)
            {
                coreAnimation.AnimateTo(layoutPositionData.Item.Owner, "Position",
                            new Vector3(layoutPositionData.Left,
                                        layoutPositionData.Top,
                                        layoutPositionData.Item.Owner.Position.Z),
                            positionTransitionComponents.Delay,
                            positionTransitionComponents.Duration,
                            positionTransitionComponents.AlphaFunction);

                NUILog.Debug("LayoutController SetupAnimationForPosition View:" + layoutPositionData.Item.Owner.Name +
                                   " left:" + layoutPositionData.Left +
                                   " top:" + layoutPositionData.Top +
                                   " delay:" + positionTransitionComponents.Delay +
                                   " duration:" + positionTransitionComponents.Duration);
            }
        }

        private void SetupAnimationForSize(LayoutData layoutPositionData, TransitionComponents sizeTransitionComponents)
        {
            // Text size cant be animated so is set to it's final size.
            // It is due to the internals of the Text not being able to recalculate fast enough.
            if (layoutPositionData.Item.Owner is TextLabel || layoutPositionData.Item.Owner is TextField)
            {
                float itemWidth = layoutPositionData.Right - layoutPositionData.Left;
                float itemHeight = layoutPositionData.Bottom - layoutPositionData.Top;
                // Set size directly.
                layoutPositionData.Item.Owner.Size2D = new Size2D((int)itemWidth, (int)itemHeight);
            }
            else
            {
                coreAnimation.AnimateTo(layoutPositionData.Item.Owner, "Size",
                                         new Vector3(layoutPositionData.Right - layoutPositionData.Left,
                                                     layoutPositionData.Bottom - layoutPositionData.Top,
                                                     layoutPositionData.Item.Owner.Position.Z),
                                         sizeTransitionComponents.Delay,
                                         sizeTransitionComponents.Duration,
                                         sizeTransitionComponents.AlphaFunction);

                NUILog.Debug("LayoutController SetupAnimationForSize View:" + layoutPositionData.Item.Owner.Name +
                                   " width:" + (layoutPositionData.Right - layoutPositionData.Left) +
                                   " height:" + (layoutPositionData.Bottom - layoutPositionData.Top) +
                                   " delay:" + sizeTransitionComponents.Delay +
                                   " duration:" + sizeTransitionComponents.Duration);
            }
        }

        void SetupAnimationForCustomTransitions(TransitionList transitionsToAnimate, View view)
        {
            if (transitionsToAnimate?.Count > 0)
            {
                foreach (LayoutTransition transition in transitionsToAnimate)
                {
                    if (transition.AnimatableProperty != AnimatableProperties.Position &&
                        transition.AnimatableProperty != AnimatableProperties.Size)
                    {
                        coreAnimation.AnimateTo(view,
                                                 transition.AnimatableProperty.ToString(),
                                                 transition.TargetValue,
                                                 transition.Animator.Delay,
                                                 transition.Animator.Duration,
                                                 transition.Animator.AlphaFunction);

                        NUILog.Debug("LayoutController SetupAnimationForCustomTransitions View:" + view.Name +
                                           " Property:" + transition.AnimatableProperty.ToString() +
                                           " delay:" + transition.Animator.Delay +
                                           " duration:" + transition.Animator.Duration);
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
            foreach (LayoutTransition transition in sourceTransitionList)
            {
                if (transition.AnimatableProperty == propertyToMatch)
                {
                    // Matched property to animate is for the propertyToMatch so use provided Animator.
                    transitionComponentToUpdate = transition.Animator;
                }
            }
        }

        private TransitionComponents CreateDefaultTransitionComponent(int delay, int duration)
        {
            AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);
            return new TransitionComponents(delay, duration, alphaFunction);
        }

        /// <summary>
        /// Sets up the main animation with the animators for each item (each layoutPositionData structure)
        /// </summary>
        private void AddAnimatorsToAnimation(LayoutData layoutPositionData)
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
            // If a key exists then a List of at least 1 transition exists.
            if (layoutPositionData.Item.Owner.LayoutTransitions.ContainsKey(conditionForAnimators))
            {
                // Child has transitions for the condition
                matchedCustomTransitions = layoutPositionData.Item.Owner.LayoutTransitions.TryGetValue(conditionForAnimators, out transitionsForCurrentCondition);
            }

            if (!matchedCustomTransitions)
            {
                // Inherit parent transitions as none already set on View for the condition.
                ILayoutParent layoutParent = layoutPositionData.Item.GetParent();
                if (layoutParent != null)
                {
                    // Item doesn't have it's own transitions for this condition so copy parents if
                    // has a parent with transitions.
                    LayoutGroup layoutGroup = layoutParent as LayoutGroup;
                    TransitionList parentTransitionList;
                    // Note TryGetValue returns null if key not matched.
                    if (layoutGroup != null && layoutGroup.Owner.LayoutTransitions.TryGetValue(conditionForAnimators, out parentTransitionList))
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

            // Dispose components
            positionTransitionComponents.Dispose();
            sizeTransitionComponents.Dispose();
        }

    } // class LayoutController
} // namespace Tizen.NUI
