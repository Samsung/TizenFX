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
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.PassthroughValueProvider")]
    [AcceptEmptyServiceProvider]
    public sealed class BindingCondition : Condition, IValueProvider
    {
        readonly BindableProperty boundProperty;

        BindingBase binding;
        object triggerValue;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingCondition()
        {
            boundProperty = BindableProperty.CreateAttached("Bound", typeof(object), typeof(BindingCondition), null, propertyChanged: OnBoundPropertyChanged);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingBase Binding
        {
            get { return binding; }
            set
            {
                if (binding == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Binding once the Condition has been applied.");
                binding = value;
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Value
        {
            get { return triggerValue; }
            set
            {
                if (triggerValue == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Value once the Condition has been applied.");
                triggerValue = value;
            }
        }

        object IValueProvider.ProvideValue(IServiceProvider serviceProvider)
        {
            //This is no longer required
            return this;
        }

        internal override bool GetState(BindableObject bindable)
        {
            object newValue = bindable.GetValue(boundProperty);
            return EqualsToValue(newValue);
        }

        internal override void SetUp(BindableObject bindable)
        {
            if (Binding != null)
                bindable.SetBinding(boundProperty, Binding.Clone());
        }

        internal override void TearDown(BindableObject bindable)
        {
            bindable.RemoveBinding(boundProperty);
            bindable.ClearValue(boundProperty);
        }

        static IValueConverterProvider s_valueConverter = DependencyService.Get<IValueConverterProvider>();

        bool EqualsToValue(object other)
        {
            if ((other == Value) || (other != null && other.Equals(Value)))
                return true;

            object converted = null;
            if (s_valueConverter != null)
                converted = s_valueConverter.Convert(Value, other != null ? other.GetType() : typeof(object), null, null);
            else
                return false;

            return (other == converted) || (other != null && other.Equals(converted));
        }

        void OnBoundPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            bool oldState = EqualsToValue(oldValue);
            bool newState = EqualsToValue(newValue);

            if (newState == oldState)
                return;

            if (ConditionChanged != null)
                ConditionChanged(bindable, oldState, newState);
        }
    }
}
