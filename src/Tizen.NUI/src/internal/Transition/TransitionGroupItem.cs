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
    /// TransitionGroupItem is an object to set Fade transition of a View that will appear or disappear.
    /// TransitionGroupItem object is required to be added to the TransitionSet to play.
    /// </summary>
    internal class TransitionGroupItem : TransitionItemBase
    {
        private List<TransitionItemBase> transitionItemList = null;

        private bool useGroupTimePeriod = false;
        private bool stepTransition = false;
        private bool useGroupAlphaFunction = false;

        private View transitionView = null;

        /// <summary>
        /// Creates an initialized fade.<br />
        /// </summary>
        /// <remarks>DurationmSeconds must be greater than zero.</remarks>
        public TransitionGroupItem(View view, List<TransitionBase> transitionList, bool useGroupTimePeriod, bool stepTransition, bool useGroupAlphaFunction, bool appearingTransition, TimePeriod timePeriod, AlphaFunction alphaFunction)
        : base(view, appearingTransition, timePeriod, alphaFunction)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            this.useGroupTimePeriod = useGroupTimePeriod;
            this.stepTransition = stepTransition;
            this.useGroupAlphaFunction = useGroupAlphaFunction;
            transitionView = view;

            transitionItemList = new List<TransitionItemBase>();
            for (int index = 0; index < transitionList.Count; ++index)
            {
                TimePeriod localTimePeriod = new TimePeriod(transitionList[index].GetTimePeriod().DelayMilliseconds, transitionList[index].GetTimePeriod().DurationMilliseconds);
                AlphaFunction localAlphaFunction = transitionList[index].GetAlphaFunction();
                if (useGroupTimePeriod)
                {
                    int stepMilliseconds = 0;
                    if (stepTransition)
                    {
                        stepMilliseconds = TimePeriod.DurationMilliseconds / transitionList.Count;
                    }
                    localTimePeriod.DelayMilliseconds += TimePeriod.DelayMilliseconds + stepMilliseconds * index;
                }
                if (useGroupAlphaFunction)
                {
                    localAlphaFunction = AlphaFunction;
                }
                transitionItemList.Add(transitionList[index].CreateTransition(transitionView, AppearingTransition, localTimePeriod, localAlphaFunction));
            }
        }

        public int TransitionCount
        {
            get
            {
                if(transitionItemList != null)
                {
                    return transitionItemList.Count;
                }
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets whether the View moves with child or not.
        /// </summary>
        public override bool TransitionWithChild
        {
            set
            {
                foreach (TransitionItemBase item in transitionItemList)
                {
                    item.TransitionWithChild = value;
                }
            }
        }

        public TransitionItemBase GetTransitionAt(int index)
        {
            if (transitionItemList != null && index < transitionItemList.Count)
            {
                return transitionItemList[index];
            }
            return null;
        }
    }
}
