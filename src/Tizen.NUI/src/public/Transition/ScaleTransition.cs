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
    /// ScaleTransition provides smoothly appearing/disappearing scale effects for target View.
    /// If this transition is for appearing, the View comes out with the scale factor applied
    /// and will be animated at its original scale.
    /// If this transition is for disappearing, the View starts at its original size
    /// but will become the scale of scale factor and vanished.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScaleTransition : TransitionBase
    {
        /// <summary>
        /// Create a ScaleTransition.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScaleTransition()
        {
        }

        /// <summary>
        /// Set/get Scale factor for this scale transition.
        /// if AppearingTransition, transition starts from scaled by the ScaleFactor and is animated to the original size.
        /// And if DisappearingTransition, transition is finished to the scaled state by the ScaleFactor.
        ///
        /// Default ScaleFactor is Vector2(0.5f, 0.5f).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScaleFactor { get; set; } = new Vector2(0.5f, 0.5f);

        internal override TransitionItemBase CreateTransition(View view, bool isAppearing)
        {
            ScaleTransitionItem scale = new ScaleTransitionItem(view, ScaleFactor, isAppearing, GetTimePeriod(), GetAlphaFunction());
            return scale;
        }
    }
}
