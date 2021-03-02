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
    /// TransitionBase class is a base class for each Transitions.
    /// Each Transition child classes inherits this base class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TransitionBase : Disposable
    {
        private static readonly float DefaultDuration = 0.5f;
        protected internal AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default);
        protected internal TimePeriod timePeriod = new TimePeriod(DefaultDuration);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionBase()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
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

        [EditorBrowsable(EditorBrowsableState.Never)]
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

        internal TransitionItemBase CreateTransition(View target, bool isEntering)
        {
            return new TransitionItemBase(target, isEntering, timePeriod, alphaFunction);
        }

        protected override void Dispose(DisposeTypes type)
        {
            alphaFunction.Dispose();
            timePeriod.Dispose();
            base.Dispose(type);
        }
    }
}
