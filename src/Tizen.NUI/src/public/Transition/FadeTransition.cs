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
    /// FadeTransition class is a cluster of properties for the fade transition of a View.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class FadeTransition : TransitionBase
    {
        private float opacity = 0.0f;

        /// <summary>
        /// Create a FadeTransition for the View pair.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public FadeTransition()
        {
        }

        /// <summary>
        /// Set Opacity for this fade transition.
        /// If this transition is for appearing, the opacity of target View is animated from this property.
        /// If this transition is for disappearing, the opacity of target View is animated to this property.
        /// Default Opacity is 0.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                opacity = value;
            }
        }

        internal override TransitionItemBase CreateTransition(View view, bool appearingTransition, TimePeriod timePeriod, AlphaFunction alphaFunction)
        {
            FadeTransitionItem fade = new FadeTransitionItem(view, Opacity, appearingTransition, timePeriod, alphaFunction);
            return fade;
        }
    }
}
