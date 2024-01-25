/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// TransitionGroup class is a cluster of properties to use multiple Transitions on a target.
    /// FadeTransition, ScaleTransition, and SlideTransition can be added on this group with AddTransition method.
    /// The transitions can be started at the same time or can be started sequentially in order.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TransitionGroup : TransitionBase
    {
        private List<TransitionBase> transitionList = null;

        /// <summary>
        /// Create a FadeTransition for the View pair.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionGroup()
        {
        }

        /// <summary>
        /// Set/Get whether the child Transitions are affected by the TimePeriod of this TransitionGroup
        /// If UseGroupTimePeriod is true, child Transitions wait for a TimePeriod.DelayMilliseconds before starting.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UseGroupTimePeriod { set; get; } = false;

        /// <summary>
        /// Set/Get whether the child Transitions are started sequentially or not.
        /// If StepTransition is true, the child Transitions starts sequentially with an interval of "TimePeriod.DurationMilliseconds/#ofChildTransitions".
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StepTransition { set; get; } = false;

        /// <summary>
        /// Set/Get whether the child Transitions are affected by the AlphaFunction of this TransitionGroup
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UseGroupAlphaFunction { set; get; } = false;


        /// <summary>
        /// Adds a Transition to this TransitionGroup.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddTransition(TransitionBase transition)
        {
            if (transitionList == null)
            {
                transitionList = new List<TransitionBase>();
            }
            transitionList.Add(transition);
        }

        internal override TransitionItemBase CreateTransition(View view, bool appearingTransition, TimePeriod timePeriod, AlphaFunction alphaFunction)
        {
            TransitionGroupItem group = new TransitionGroupItem(view, transitionList, UseGroupTimePeriod, StepTransition, UseGroupAlphaFunction, appearingTransition, timePeriod, alphaFunction);
            return group;
        }
    }
}
