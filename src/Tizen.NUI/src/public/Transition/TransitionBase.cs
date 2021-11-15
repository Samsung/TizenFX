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
    /// TransitionBase class is a base class for all Transition.
    /// Each Transition child classes inherits this base class.
    /// </summary>
    /// <remarks>
    /// Transition changes propreties of View like Position, Scale, Orientation, and Opacity during transition.
    /// </remarks>
    /// <since_tizen> 9 </since_tizen>
    public class TransitionBase : Disposable
    {
        private AlphaFunction alphaFunction = null;
        private TimePeriod timePeriod = null;

        /// <summary>
        /// Create a TransitionBase
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TransitionBase()
        {
        }

        /// <summary>
        /// Set/Get the alpha function for a transition.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public AlphaFunction AlphaFunction
        {
            set
            {
                alphaFunction = value;
            }
            get
            {
                return alphaFunction;
            }
        }

        /// <summary>
        /// Set/Get time period that contains delay and duration.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TimePeriod TimePeriod
        {
            set
            {
                timePeriod = value;
            }
            get
            {
                return timePeriod;
            }
        }

        internal TimePeriod GetTimePeriod()
        {
            return timePeriod ??= new TimePeriod(0);
        }

        internal AlphaFunction GetAlphaFunction()
        {
            return alphaFunction ??= new AlphaFunction(AlphaFunction.BuiltinFunctions.Default);
        }

        internal TransitionItemBase CreateTransition(View view, bool appearingTransition)
        {
            return CreateTransition(view, appearingTransition, GetTimePeriod(), GetAlphaFunction());
        }

        internal virtual TransitionItemBase CreateTransition(View view, bool appearingTransition, TimePeriod timePeriod, AlphaFunction alphaFunction)
        {
            return new TransitionItemBase(view, appearingTransition, timePeriod, alphaFunction);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            alphaFunction?.Dispose();
            timePeriod?.Dispose();
            base.Dispose(type);
        }
    }
}
