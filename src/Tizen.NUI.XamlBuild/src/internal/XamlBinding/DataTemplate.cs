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
using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    internal class DataTemplate : ElementTemplate
    {
        public DataTemplate()
        {
        }

        public DataTemplate(Type type) : base(type)
        {
        }

        public DataTemplate(Func<object> loadTemplate) : base(loadTemplate)
        {
        }

        public IDictionary<BindableProperty, BindingBase> Bindings { get; } = new Dictionary<BindableProperty, BindingBase>();

        public IDictionary<BindableProperty, object> Values { get; } = new Dictionary<BindableProperty, object>();

        public void SetBinding(BindableProperty property, BindingBase binding)
        {
            if (property == null)
                throw new ArgumentNullException("property");
            if (binding == null)
                throw new ArgumentNullException("binding");

            Values.Remove(property);
            Bindings[property] = binding;
        }

        public void SetValue(BindableProperty property, object value)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            Bindings.Remove(property);
            Values[property] = value;
        }

        internal override void SetupContent(object item)
        {
            ApplyBindings(item);
            ApplyValues(item);
        }

        void ApplyBindings(object item)
        {
            if (Bindings == null)
                return;

            var bindable = item as BindableObject;
            if (bindable == null)
                return;

            foreach (KeyValuePair<BindableProperty, BindingBase> kvp in Bindings)
            {
                if (Values.ContainsKey(kvp.Key))
                    throw new InvalidOperationException("Binding and Value found for " + kvp.Key.PropertyName);

                bindable.SetBinding(kvp.Key, kvp.Value.Clone());
            }
        }

        void ApplyValues(object item)
        {
            if (Values == null)
                return;

            var bindable = item as BindableObject;
            if (bindable == null)
                return;
            foreach (KeyValuePair<BindableProperty, object> kvp in Values)
                bindable.SetValue(kvp.Key, kvp.Value);
        }
    }
}
 
