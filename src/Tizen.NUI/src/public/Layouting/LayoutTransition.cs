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

using System.Collections.Generic;
using System;

namespace Tizen.NUI
{
    /// <summary>
    /// Define a List of LayoutTransitions
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class TransitionList : List<LayoutTransition> {}

    /// <summary>
    /// The conditions for transitions.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [FlagsAttribute] public enum TransitionCondition
    {
        /// <summary>
        /// Default when a condition has not been set.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Unspecified = 0,
        /// <summary>
        /// Animate changing layout to another layout.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        LayoutChanged = 1,
        /// <summary>
        /// Animate adding item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        Add = 2,
        /// <summary>
        /// Animate removing item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        Remove = 4,
        /// <summary>
        /// Animation when an item changes due to a  being added.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        ChangeOnAdd = 8,
        /// <summary>
        /// Animation when an item changes due to a  being removed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        ChangeOnRemove = 16
    }

    /// <summary>
    /// The properties that can be animated.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum AnimatableProperties
    {
        /// <summary>
        /// Position property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        Position,
        /// <summary>
        /// Size property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        Size,
        /// <summary>
        /// Opacity property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        Opacity
    }

    /// <summary>
    /// Parts of the transition that can be configured to provide a custom effect.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class TransitionComponents
    {
        /// <summary>
        /// TransitionComponents default constructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public TransitionComponents()
        {
            Delay = 0;
            Duration = 100;
            AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);
        }

        /// <summary>
        /// TransitionComponents constructor. Stores delay, duration and AlphaFunction.
        /// </summary>
        /// <param name="delay">The delay before the animator starts.</param>
        /// <param name="duration">the duration of the animator.</param>
        /// <param name="alphaFunction">alpha function to use .</param>
        /// <since_tizen> 6 </since_tizen>

        public TransitionComponents(int delay, int duration, AlphaFunction alphaFunction)
        {
            Delay = delay;
            Duration = duration;
            AlphaFunction = alphaFunction;
        }

        /// <summary>
        /// Get, Set the time transition should execute for . Milliseconds.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Duration;
        /// <summary>
        /// Get, Set the delay before the transition executes. Milliseconds.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Delay;
        /// <summary>
        /// Get, Set the function to alter the transition path over time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public AlphaFunction AlphaFunction;
    }

    /// <summary>
    /// LayoutTransition stores the animation setting for a transition conidition.
    /// </summary>
    public class LayoutTransition
    {
        /// <summary>
        /// LayoutTransition default constructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LayoutTransition()
        {
          Condition = TransitionCondition.Unspecified;
          AnimatableProperty = AnimatableProperties.Position;
          Animator = null;
          TargetValue = 0;
        }
        /// <summary>
        /// LayoutTransition constructor.
        /// </summary>
        /// <param name="condition">The animatable condition.</param>
        /// <param name="animatableProperty">the property to animate.</param>
        /// <param name="targetValue">target value of the property.</param>
        /// <param name="animator">Components to define the animator.</param>
        /// <since_tizen> 6 </since_tizen>
        public LayoutTransition( TransitionCondition condition,
                                 AnimatableProperties animatableProperty,
                                 object targetValue,
                                 TransitionComponents animator)
        {
            Condition = condition;
            AnimatableProperty = animatableProperty;
            Animator = animator;
            TargetValue = targetValue;
        }

        /// <summary>
        /// Condition for this Transition
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        public TransitionCondition Condition{get; set;}
        /// <summary>
        /// Property to animate.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        public AnimatableProperties AnimatableProperty{get; set;}
        /// <summary>
        /// Components of the Animator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        public TransitionComponents Animator{get; set;}
        /// <summary>
        /// Target value to animate to.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        public object TargetValue{get; set;}
    }


    /// <summary>
    /// Class to help manage the adding and updating of transitions.
    /// </summary>
    internal static class LayoutTransitionsHelper
    {
        /// <summary>
        /// Adds the given transition and condition to a transition list.
        /// </summary>
        /// <param name="targetTransitionList">The list to add the transition to.</param>
        /// <param name="condition">Condition for the transition.</param>
        /// <param name="transition">The transition to add.</param>
        /// <param name="explicitlySet">True is set explicitly, false if inherited.</param>
        static public void AddTransitionForCondition(
                              Dictionary<TransitionCondition, TransitionList> targetTransitionList,
                              TransitionCondition condition,
                              LayoutTransition transition,
                              bool explicitlySet)
        {
            bool replaced = false;
            bool conditionNotInDictionary = false;
            TransitionList transitionListMatchingCondition;
            if (targetTransitionList.TryGetValue(condition, out transitionListMatchingCondition))
            {
                if (transitionListMatchingCondition != null)
                {
                    for (var index = 0; index < transitionListMatchingCondition.Count; index++ )
                    {
                        if (transitionListMatchingCondition[index].AnimatableProperty == transition.AnimatableProperty)
                        {
                            if (explicitlySet)
                            {
                                transitionListMatchingCondition[index] = transition;
                                replaced = true;
                                continue;
                            }
                        }
                    }
                }
            }
            else
            {
                conditionNotInDictionary = true;
            }

            if (replaced == false)
            {
                if (transitionListMatchingCondition == null)
                {
                    transitionListMatchingCondition = new TransitionList();
                }
                transitionListMatchingCondition.Add(transition);
                // Update dictionary with new or replaced entry.
                if (conditionNotInDictionary)
                {
                    targetTransitionList.Add(condition, transitionListMatchingCondition); // new entry
                }
                else
                {
                    targetTransitionList[condition] = transitionListMatchingCondition; // replaced
                }
            }
        }

        /// <summary>
        /// Retreive the transition list for the given condition.
        /// </summary>
        /// <param name="sourceTransitionCollection">The source collection of transition lists to retrieve.</param>
        /// <param name="condition">Condition for the transition.</param>
        /// <param name="transitionsForCondition">transition list to return as out parameter.</param>
        /// <returns>True if a transition list found for the given condition></returns>
        static public bool GetTransitionsListForCondition(
                              Dictionary<TransitionCondition, TransitionList> sourceTransitionCollection,
                              TransitionCondition condition,
                              TransitionList transitionsForCondition )
        {
            TransitionCondition resolvedCondition = condition;
            bool matched = false;
            // LayoutChanged transitions overrides ChangeOnAdd and ChangeOnRemove as siblings will
            // reposition to the new layout not to the insertion/removal of a sibling.
            if ((condition & TransitionCondition.LayoutChanged) == TransitionCondition.LayoutChanged)
            {
                resolvedCondition = TransitionCondition.LayoutChanged;
            }

            if (sourceTransitionCollection.TryGetValue(resolvedCondition, out transitionsForCondition))
            {
                matched = true;
            }

            return matched;
        }

        /// <summary>
        /// Copy the transitions in the source list to the target list
        /// </summary>
        /// <param name="sourceTransitionList">The source transition list.</param>
        /// <param name="targetTransitionList">The target transition list to copy to.</param>
        static public void CopyTransitions( TransitionList sourceTransitionList,
                                            TransitionList targetTransitionList )
        {
            targetTransitionList.Clear();
            foreach (LayoutTransition transitionToApply in sourceTransitionList)
            {
                // Overwite existing transitions
                targetTransitionList.Add(transitionToApply);
            }

        }
    }

} // namespace Tizen.NUI