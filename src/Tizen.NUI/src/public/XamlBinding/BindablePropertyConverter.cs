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
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.BindablePropertyConverter")]
    [TypeConversion(typeof(BindableProperty))]
    public sealed class BindablePropertyConverter : TypeConverter, IExtendedTypeConverter
    {
        object IExtendedTypeConverter.ConvertFrom(CultureInfo culture, object value, IServiceProvider serviceProvider)
        {
            return ((IExtendedTypeConverter)this).ConvertFromInvariantString(value as string, serviceProvider);
        }

        object IExtendedTypeConverter.ConvertFromInvariantString(string value, IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            if (serviceProvider == null)
                return null;
            var parentValuesProvider = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideParentValues;
            var typeResolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
            if (typeResolver == null)
                return null;
            IXmlLineInfo lineinfo = null;
            var xmlLineInfoProvider = serviceProvider.GetService(typeof(IXmlLineInfoProvider)) as IXmlLineInfoProvider;
            if (xmlLineInfoProvider != null)
                lineinfo = xmlLineInfoProvider.XmlLineInfo;
            string[] parts = value.Split('.');
            Type type = null;
            if (parts.Length == 1)
            {
                if (parentValuesProvider == null)
                {
                    string msg = string.Format("Can't resolve {0}", parts[0]);
                    throw new XamlParseException(msg, lineinfo);
                }
                object parent = parentValuesProvider.ParentObjects.Skip(1).FirstOrDefault();
                if (parentValuesProvider.TargetObject is Setter)
                {
                    var triggerBase = parent as TriggerBase;
                    var visualState = parent as VisualState;
                    if (triggerBase != null)
                        type = triggerBase.TargetType;
                    else if (visualState != null)
                        type = FindTypeForVisualState(parentValuesProvider, lineinfo);
                }
                else if (parentValuesProvider.TargetObject is Trigger)
                    type = (parentValuesProvider.TargetObject as Trigger).TargetType;
                else if (parentValuesProvider.TargetObject is XamlPropertyCondition && (parent as TriggerBase) != null)
                    type = (parent as TriggerBase).TargetType;

                if (type == null)
                    throw new XamlParseException($"Can't resolve {parts[0]}", lineinfo);

                return ConvertFrom(type, parts[0], lineinfo);
            }
            if (parts.Length == 2)
            {
                if (!typeResolver.TryResolve(parts[0], out type))
                {
                    string msg = string.Format("Can't resolve {0}", parts[0]);
                    throw new XamlParseException(msg, lineinfo);
                }
                return ConvertFrom(type, parts[1], lineinfo);
            }
            throw new XamlParseException($"Can't resolve {value}. Syntax is [[prefix:]Type.]PropertyName.", lineinfo);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            if (value.Contains(":"))
            {
                Console.WriteLine(null, "Can't resolve properties with xml namespace prefix.");
                return null;
            }
            string[] parts = value.Split('.');
            if (parts.Length != 2)
            {
                Console.WriteLine(null, $"Can't resolve {value}. Accepted syntax is Type.PropertyName.");
                return null;
            }
            Type type = Type.GetType("Tizen.NUI." + parts[0]);
            return ConvertFrom(type, parts[1], null);
        }

        BindableProperty ConvertFrom(Type type, string propertyName, IXmlLineInfo lineinfo)
        {
            string name = propertyName + "Property";
            FieldInfo bpinfo = type.GetField(fi => fi.Name == name && fi.IsStatic && fi.IsPublic && fi.FieldType == typeof(BindableProperty));
            if (bpinfo == null)
                throw new XamlParseException($"Can't resolve {name} on {type.Name}", lineinfo);
            var bp = bpinfo.GetValue(null) as BindableProperty;
            var isObsolete = bpinfo.GetCustomAttribute<ObsoleteAttribute>() != null;
            if (bp != null && bp.PropertyName != propertyName && !isObsolete)
                throw new XamlParseException($"The PropertyName of {type.Name}.{name} is not {propertyName}", lineinfo);
            return bp;
        }

        Type FindTypeForVisualState(IProvideParentValues parentValueProvider, IXmlLineInfo lineInfo)
        {
            var parents = parentValueProvider.ParentObjects.ToList();

            // Skip 0; we would not be making this check if TargetObject were not a Setter
            // Skip 1; we would not be making this check if the immediate parent were not a VisualState

            // VisualStates must be in a VisualStateGroup
            if (!(parents[2] is VisualStateGroup))
            {
                throw new XamlParseException($"Expected {nameof(VisualStateGroup)} but found {parents[2]}.", lineInfo);
            }

            var vsTarget = parents[3];

            // Are these Visual States directly on a VisualElement?
            if (vsTarget is /*VisualElement*/BaseHandle)
            {
                return vsTarget.GetType();
            }

            if (!(parents[3] is VisualStateGroupList))
            {
                throw new XamlParseException($"Expected {nameof(VisualStateGroupList)} but found {parents[3]}.", lineInfo);
            }

            if (!(parents[4] is Setter))
            {
                throw new XamlParseException($"Expected {nameof(Setter)} but found {parents[4]}.", lineInfo);
            }

            throw new XamlParseException("NUI doesn't support VisualState", lineInfo);

        }
    }
}
