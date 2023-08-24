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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class LayoutTransitionManager : Disposable
    {
        private bool overrideCoreAnimation = false;
        private Animation coreAnimation;
        private List<LayoutData> layoutTransitionDataQueue;
        private List<LayoutItem> itemRemovalQueue;

        internal LayoutTransitionManager()
        {
            layoutTransitionDataQueue = new List<LayoutData>();

        }

        /// <summary>
        /// Dispose Explicit or Implicit
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (coreAnimation != null)
            {
                coreAnimation.Dispose();
                coreAnimation = null;
            }

            base.Dispose(type);
        }

        public Animation CoreAnimation => coreAnimation;

        public bool OverrideCoreAnimation
        {
            get
            {
                return overrideCoreAnimation;
            }
            set
            {
                overrideCoreAnimation = value;
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
        /// Play the animation.
        /// </summary>
        internal void SetupCoreAndPlayAnimation()
        {
            if (EnabledCoreAnimation())
            {
                SetupCoreAnimation();

                NUILog.Debug("LayoutController Playing, Core Duration:" + coreAnimation.Duration);
                coreAnimation.Play();
            }
        }

        /// <summary>
        /// Check if layout animation is needed
        /// </summary>
        private bool EnabledCoreAnimation()
        {
            return layoutTransitionDataQueue.Count > 0 && !OverrideCoreAnimation;
        }

        /// <summary>
        /// Set up the animation from each LayoutItems position data.
        /// Iterates the transition stack, adding an Animator to the core animation.
        /// </summary>
        private void SetupCoreAnimation()
        {
            NUILog.Debug("LayoutController SetupCoreAnimation for:" + layoutTransitionDataQueue.Count);

            if (!coreAnimation)
            {
                coreAnimation = new Animation();
                coreAnimation.EndAction = Animation.EndActions.StopFinal;
                coreAnimation.Finished += AnimationFinished;
            }

            // Iterate all items that have been queued for repositioning.
            foreach (var layoutPositionData in layoutTransitionDataQueue)
            {
                AddAnimatorsToAnimation(layoutPositionData);
            }
            // transitions have now been applied, clear stack, ready for new transitions on
            // next layout traversal.
            layoutTransitionDataQueue.Clear();
        }


        private void SetupAnimationForCustomTransitions(TransitionList transitionsToAnimate, View view)
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
                        if (item.GetParent() is LayoutGroup layoutGroup)
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

        private void SetupAnimationForPosition(LayoutData layoutPositionData, TransitionComponents positionTransitionComponents)
        {
            // A removed item does not have a valid target position within the layout so don't try to position.
            if (layoutPositionData.ConditionForAnimation != TransitionCondition.Remove)
            {
                var vector = new Vector3(layoutPositionData.Left,
                                        layoutPositionData.Top,
                                        layoutPositionData.Item.Owner.Position.Z);
                coreAnimation.AnimateTo(layoutPositionData.Item.Owner, "Position",
                            vector,
                            positionTransitionComponents.Delay,
                            positionTransitionComponents.Duration,
                            positionTransitionComponents.AlphaFunction);

                NUILog.Debug("LayoutController SetupAnimationForPosition View:" + layoutPositionData.Item.Owner.Name +
                                   " left:" + layoutPositionData.Left +
                                   " top:" + layoutPositionData.Top +
                                   " delay:" + positionTransitionComponents.Delay +
                                   " duration:" + positionTransitionComponents.Duration);
                vector.Dispose();
                vector = null;
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
                var vector = new Vector3(layoutPositionData.Right - layoutPositionData.Left,
                                                         layoutPositionData.Bottom - layoutPositionData.Top,
                                                         layoutPositionData.Item.Owner.Position.Z);
                coreAnimation.AnimateTo(layoutPositionData.Item.Owner, "Size",
                                         vector,
                                         sizeTransitionComponents.Delay,
                                         sizeTransitionComponents.Duration,
                                         sizeTransitionComponents.AlphaFunction);

                NUILog.Debug("LayoutController SetupAnimationForSize View:" + layoutPositionData.Item.Owner.Name +
                                   " width:" + (layoutPositionData.Right - layoutPositionData.Left) +
                                   " height:" + (layoutPositionData.Bottom - layoutPositionData.Top) +
                                   " delay:" + sizeTransitionComponents.Delay +
                                   " duration:" + sizeTransitionComponents.Duration);
                vector.Dispose();
                vector = null;
            }
        }
    }
}
