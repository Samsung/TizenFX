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

namespace Tizen.NUI
{
    /// <summary>
    /// SlideTransition class is a cluster of properties for the slide transition of a View.
    /// SlideTransition provides smoothly appearing/disappearing effects for target Control.
    /// The direction the target Control is comming from or going to can be selected in the pre-defined directions at the SlideTransitionDirection {UP, DOWN, LEFT, RIGHT}
    /// And, to use custom direction, the direction can be set by using Vector2.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class SlideTransition : TransitionBase
    {
        /// <summary>
        /// Create a SlideTransition for the View pair.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public SlideTransition()
        {
        }

        /// <summary>
        /// Set/get SlideDirection for this slide transition.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Vector2 Direction { get; set; } = SlideTransitionDirection.Right;

        internal override TransitionItemBase CreateTransition(View view, bool appearingTransition, TimePeriod timePeriod, AlphaFunction alphaFunction)
        {
            SlideTransitionItem slide = new SlideTransitionItem(view, Direction, appearingTransition, timePeriod, alphaFunction);
            return slide;
        }
    }
}
