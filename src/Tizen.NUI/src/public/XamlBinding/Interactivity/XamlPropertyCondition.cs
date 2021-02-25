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
using System.Reflection;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiled("Tizen.NUI.Core.XamlC.PassthroughValueProvider")]
    [AcceptEmptyServiceProvider]
    public sealed class XamlPropertyCondition : Condition, IValueProvider
    {
        readonly BindableProperty stateProperty;

        BindableProperty property;
        object triggerValue;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlPropertyCondition()
        {
            stateProperty = BindableProperty.CreateAttached("State", typeof(bool), typeof(XamlPropertyCondition), false, propertyChanged: OnStatePropertyChanged);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindableProperty Property
        {
            get { return property; }
            set
            {
                if (property == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Property once the Trigger has been applied.");
                property = value;

                //convert the value
                if (property != null && s_valueConverter != null)
                {
                    Func<MemberInfo> minforetriever = () => property.DeclaringType.GetRuntimeProperty(property.PropertyName);
                    Value = s_valueConverter.Convert(Value, property.ReturnType, minforetriever, null);
                }
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
                    throw new InvalidOperationException("Can not change Value once the Trigger has been applied.");

                //convert the value
                if (property != null && s_valueConverter != null)
                {
                    Func<MemberInfo> minforetriever = () => property.DeclaringType.GetRuntimeProperty(property.PropertyName);
                    triggerValue = s_valueConverter.Convert(value, property.ReturnType, minforetriever, null);
                }
                else
                {
                    triggerValue = value;
                }

            }
        }

        object IValueProvider.ProvideValue(IServiceProvider serviceProvider)
        {
            //This is no longer required
            return this;
        }

        internal override bool GetState(BindableObject bindable)
        {
            return (bool)bindable.GetValue(stateProperty);
        }

        static IValueConverterProvider s_valueConverter = DependencyService.Get<IValueConverterProvider>();

        internal override void SetUp(BindableObject bindable)
        {
            object newvalue = bindable.GetValue(Property);
            bool newState = (newvalue == Value) || (newvalue != null && newvalue.Equals(Value));
            bindable.SetValue(stateProperty, newState);
            bindable.PropertyChanged += OnAttachedObjectPropertyChanged;
        }

        internal override void TearDown(BindableObject bindable)
        {
            bindable.ClearValue(stateProperty);
            bindable.PropertyChanged -= OnAttachedObjectPropertyChanged;
        }

        void OnAttachedObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var bindable = (BindableObject)sender;
            var oldState = (bool)bindable.GetValue(stateProperty);

            if (Property == null)
                return;
            if (e.PropertyName != Property.PropertyName)
                return;
            object newvalue = bindable.GetValue(Property);
            bool newstate = (newvalue == Value) || (newvalue != null && newvalue.Equals(Value));
            if (oldState != newstate)
                bindable.SetValue(stateProperty, newstate);
        }

        void OnStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)oldValue == (bool)newValue)
                return;

            ConditionChanged?.Invoke(bindable, (bool)oldValue, (bool)newValue);
        }
    }
}
