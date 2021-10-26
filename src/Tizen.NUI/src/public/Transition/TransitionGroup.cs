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
    /// FadeTransition class is a cluster of properties for the fade transition of a View.
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UseGroupTimePeriod { set; get; } = false;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StepTransition { set; get; } = false;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UseGroupAlphaFunction { set; get; } = false;

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
