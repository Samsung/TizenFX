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

namespace Tizen.NUI
{
    using System;
    using System.ComponentModel;
    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// Fade class is a cluster of properties for the fade transition of a View.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Fade : TransitionBase
    {
        private float opacity = 0.0f;

        /// <summary>
        /// Create a Fade for the View pair.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Fade()
        {
        }

        /// <summary>
        /// Set Opacity for this fade transition.
        /// If this transition is for appearing, the opacity of target View is animated from this property.
        /// If this transition is for disappearing, the opacity of target View is animated to this property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        internal override TransitionItemBase CreateTransition(View view, bool isAppearing)
        {
            FadeItem fade = new FadeItem(view, Opacity, isAppearing, TimePeriod, AlphaFunction);
            return fade;
        }
    }
}
