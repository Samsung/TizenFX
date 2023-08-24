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
using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// A template for multiple bindings, commonly used by RecylerView and CollectionView.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class DataTemplate : ElementTemplate
    {
        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public DataTemplate()
        {
        }

        /// <summary>
        /// Base constructor with specific Type.
        /// </summary>
        /// <param name="type">The Type of content.</param>
        /// <since_tizen> 9 </since_tizen>
        public DataTemplate(Type type) : base(type)
        {
        }

        /// <summary>
        /// Base constructor with loadTemplate function.
        /// </summary>
        /// <param name="loadTemplate">The function of loading templated object.</param>
         /// <since_tizen> 9 </since_tizen>
        public DataTemplate(Func<object> loadTemplate) : base(loadTemplate)
        {
        }

        /// <summary>
        /// Gets a dictionary of bindings, indexed by the bound properties.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public IDictionary<BindableProperty, BindingBase> Bindings { get; } = new Dictionary<BindableProperty, BindingBase>();


        /// <summary>
        /// Returns a dictionary of property values for this DataTemplate, indexed by property.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public IDictionary<BindableProperty, object> Values { get; } = new Dictionary<BindableProperty, object>();


        /// <summary>
        /// Sets the binding for property.
        /// </summary>
        /// <param name="property">The property to which to bind.</param>
        /// <param name="binding">The binding to use.</param>
        /// <since_tizen> 9 </since_tizen>
        public void SetBinding(BindableProperty property, BindingBase binding)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));
            if (binding == null)
                throw new ArgumentNullException(nameof(binding));

            Values.Remove(property);
            Bindings[property] = binding;
        }

        /// <summary>
        /// Sets the value of property.
        /// </summary>
        /// <param name="property">The property to set.</param>
        /// <param name="value">The new value.</param>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetValue(BindableProperty property, object value)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

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
