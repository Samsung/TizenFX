/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Reflection;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    [ProvideCompiled("Tizen.NUI.Core.XamlC.PassthroughValueProvider")]
    [AcceptEmptyServiceProvider]
    internal sealed class XamlPropertyCondition : Condition, IValueProvider
    {
        readonly BindableProperty _stateProperty;

        BindableProperty _property;
        object _triggerValue;

        public XamlPropertyCondition()
        {
            _stateProperty = BindableProperty.CreateAttached("State", typeof(bool), typeof(XamlPropertyCondition), false, propertyChanged: OnStatePropertyChanged);
        }

        public BindableProperty Property
        {
            get { return _property; }
            set
            {
                if (_property == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Property once the Trigger has been applied.");
                _property = value;

                //convert the value
                if (_property != null && s_valueConverter != null)
                {
                    Func<MemberInfo> minforetriever = () => Property.DeclaringType.GetRuntimeProperty(Property.PropertyName);
                    Value = s_valueConverter.Convert(Value, Property.ReturnType, minforetriever, null);
                }
            }
        }

        public object Value
        {
            get { return _triggerValue; }
            set
            {
                if (_triggerValue == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Value once the Trigger has been applied.");

                //convert the value
                if (_property != null && s_valueConverter != null)
                {
                    Func<MemberInfo> minforetriever = () => Property.DeclaringType.GetRuntimeProperty(Property.PropertyName);
                    value = s_valueConverter.Convert(value, Property.ReturnType, minforetriever, null);
                }
                _triggerValue = value;
            }
        }

        object IValueProvider.ProvideValue(IServiceProvider serviceProvider)
        {
            //This is no longer required
            return this;
        }

        internal override bool GetState(BindableObject bindable)
        {
            return (bool)bindable.GetValue(_stateProperty);
        }

        static IValueConverterProvider s_valueConverter = DependencyService.Get<IValueConverterProvider>();

        internal override void SetUp(BindableObject bindable)
        {
            object newvalue = bindable.GetValue(Property);
            bool newState = (newvalue == Value) || (newvalue != null && newvalue.Equals(Value));
            bindable.SetValue(_stateProperty, newState);
            bindable.PropertyChanged += OnAttachedObjectPropertyChanged;
        }

        internal override void TearDown(BindableObject bindable)
        {
            bindable.ClearValue(_stateProperty);
            bindable.PropertyChanged -= OnAttachedObjectPropertyChanged;
        }

        void OnAttachedObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var bindable = (BindableObject)sender;
            var oldState = (bool)bindable.GetValue(_stateProperty);

            if (Property == null)
                return;
            if (e.PropertyName != Property.PropertyName)
                return;
            object newvalue = bindable.GetValue(Property);
            bool newstate = (newvalue == Value) || (newvalue != null && newvalue.Equals(Value));
            if (oldState != newstate)
                bindable.SetValue(_stateProperty, newstate);
        }

        void OnStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)oldValue == (bool)newValue)
                return;

            ConditionChanged?.Invoke(bindable, (bool)oldValue, (bool)newValue);
        }
    }
}
 
