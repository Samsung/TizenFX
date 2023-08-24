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
using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    internal sealed class MultiCondition : Condition
    {
        readonly BindableProperty _aggregatedStateProperty;

        public MultiCondition()
        {
            _aggregatedStateProperty = BindableProperty.CreateAttached("AggregatedState", typeof(bool), typeof(MultiCondition), false, propertyChanged: OnAggregatedStatePropertyChanged);
            Conditions = new TriggerBase.SealedList<Condition>();
        }

        public IList<Condition> Conditions { get; }

        internal override bool GetState(BindableObject bindable)
        {
            return (bool)bindable.GetValue(_aggregatedStateProperty);
        }

        internal override void OnSealed()
        {
            ((TriggerBase.SealedList<Condition>)Conditions).IsReadOnly = true;
            foreach (Condition condition in Conditions)
                condition.ConditionChanged = OnConditionChanged;
        }

        internal override void SetUp(BindableObject bindable)
        {
            foreach (Condition condition in Conditions)
                condition.SetUp(bindable);
        }

        internal override void TearDown(BindableObject bindable)
        {
            foreach (Condition condition in Conditions)
                condition.TearDown(bindable);
        }

        void OnAggregatedStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)oldValue == (bool)newValue)
                return;

            ConditionChanged?.Invoke(bindable, (bool)oldValue, (bool)newValue);
        }

        void OnConditionChanged(BindableObject bindable, bool oldValue, bool newValue)
        {
            var oldState = (bool)bindable.GetValue(_aggregatedStateProperty);
            var newState = true;
            foreach (Condition condition in Conditions)
            {
                if (!condition.GetState(bindable))
                {
                    newState = false;
                    break;
                }
            }
            if (newState != oldState)
                bindable.SetValue(_aggregatedStateProperty, newState);
        }
    }
}
