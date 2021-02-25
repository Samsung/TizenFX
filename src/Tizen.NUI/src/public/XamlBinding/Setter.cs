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
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Value")]
    [ProvideCompiled("Tizen.NUI.Core.XamlC.SetterValueProvider")]
    public sealed class Setter : IValueProvider
    {
        readonly ConditionalWeakTable<BindableObject, object> originalValues = new ConditionalWeakTable<BindableObject, object>();

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindableProperty Property { get; set; }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Value { get; set; }

        object IValueProvider.ProvideValue(IServiceProvider serviceProvider)
        {
            if (Property == null)
            {
                var lineInfoProvider = serviceProvider.GetService(typeof(IXmlLineInfoProvider)) as IXmlLineInfoProvider;
                IXmlLineInfo lineInfo = lineInfoProvider != null ? lineInfoProvider.XmlLineInfo : new XmlLineInfo();
                throw new XamlParseException("Property not set", lineInfo);
            }
            var valueconverter = serviceProvider.GetService(typeof(IValueConverterProvider)) as IValueConverterProvider;

            Func<MemberInfo> minforetriever =
                () =>
                (MemberInfo)Property.DeclaringType.GetRuntimeProperty(Property.PropertyName) ?? (MemberInfo)Property.DeclaringType.GetRuntimeMethod("Get" + Property.PropertyName, new[] { typeof(BindableObject) });

            object value = valueconverter?.Convert(Value, Property.ReturnType, minforetriever, serviceProvider);
            Value = value;
            return this;
        }

        internal void Apply(BindableObject target, bool fromStyle = false)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (Property == null)
                return;

            object originalValue = target.GetValue(Property);
            if (!Equals(originalValue, Property.DefaultValue))
            {
                originalValues.Remove(target);
                originalValues.Add(target, originalValue);
            }

            var dynamicResource = Value as DynamicResource;
            var binding = Value as BindingBase;
            if (binding != null)
                target.SetBinding(Property, binding.Clone(), fromStyle);
            else if (dynamicResource != null)
                target.SetDynamicResource(Property, dynamicResource.Key, fromStyle);
            else
            {
                if (Value is IList<VisualStateGroup> visualStateGroupCollection)
                    target.SetValue(Property, visualStateGroupCollection.Clone(), fromStyle);
                else
                    target.SetValue(Property, Value, fromStyle);
            }
        }

        internal void UnApply(BindableObject target, bool fromStyle = false)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (Property == null)
                return;

            object actual = target.GetValue(Property);
            if (!Equals(actual, Value) && !(Value is Tizen.NUI.Binding.Binding) && !(Value is DynamicResource))
            {
                //Do not reset default value if the value has been changed
                originalValues.Remove(target);
                return;
            }

            object defaultValue;
            if (originalValues.TryGetValue(target, out defaultValue))
            {
                //reset default value, unapply bindings and dynamicResource
                target.SetValue(Property, defaultValue, fromStyle);
                originalValues.Remove(target);
            }
            else
                target.ClearValue(Property);
        }
    }
}
