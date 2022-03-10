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
using System.Linq;
using System.Xml;

using Mono.Cecil;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    static class BindablePropertyReferenceExtensions
    {
        public static TypeReference GetBindablePropertyType(this MemberReference bpRef, IXmlLineInfo iXmlLineInfo, ModuleDefinition module)
        {
            if (!bpRef.Name.EndsWith("Property", StringComparison.InvariantCulture))
                throw new XamlParseException($"The name of the bindable property {bpRef.Name} does not ends with \"Property\". This is the kind of convention the world is build upon, a bit like Planck's constant.", iXmlLineInfo);
            var bpName = bpRef.Name.Substring(0, bpRef.Name.Length - 8);
            var owner = bpRef.DeclaringType;
            TypeReference declaringTypeRef = null;

            var getter = owner.GetProperty(pd => pd.Name == bpName, out declaringTypeRef)?.GetMethod;
            if (getter == null || getter.IsStatic || !getter.IsPublic)
                getter = null;
            getter = getter ?? owner.GetMethods(md => md.Name == $"Get{bpName}" &&
                                                md.IsStatic &&
                                                md.IsPublic &&
                                                md.Parameters.Count == 1 &&
                                                md.Parameters[0].ParameterType.InheritsFromOrImplements(module.ImportReference((XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "BindableObject"))), module).SingleOrDefault()?.Item1;
            if (getter == null)
                throw new XamlParseException($"Missing a public static Get{bpName} or a public instance property getter for the attached property \"{bpRef.DeclaringType}.{bpRef.Name}\"", iXmlLineInfo);
            return getter.ResolveGenericReturnType(declaringTypeRef, module);
        }

        public static TypeReference GetBindablePropertyTypeConverter(this MemberReference bpRef, ModuleDefinition module)
        {
            TypeReference propertyDeclaringType;
            var owner = bpRef.DeclaringType;
            var bpName = bpRef.Name.EndsWith("Property", StringComparison.Ordinal) ? bpRef.Name.Substring(0, bpRef.Name.Length - 8) : bpRef.Name;
            var property = owner.GetProperty(pd => pd.Name == bpName, out propertyDeclaringType);
            var propertyType = property?.ResolveGenericPropertyType(propertyDeclaringType, module);
            var staticGetter = owner.GetMethods(md => md.Name == $"Get{bpName}" &&
                                                md.IsStatic &&
                                                md.IsPublic &&
                                                md.Parameters.Count == 1 &&
                                                md.Parameters[0].ParameterType.InheritsFromOrImplements(module.ImportReference((XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "BindableObject"))), module).SingleOrDefault()?.Item1;

            var attributes = new List<CustomAttribute>();
            if (property != null && property.HasCustomAttributes)
                attributes.AddRange(property.CustomAttributes);
            if (propertyType != null && propertyType.ResolveCached().HasCustomAttributes)
                attributes.AddRange(propertyType.ResolveCached().CustomAttributes);
            if (staticGetter != null && staticGetter.HasCustomAttributes)
                attributes.AddRange(staticGetter.CustomAttributes);
            if (staticGetter != null && staticGetter.ReturnType.ResolveCached().HasCustomAttributes)
                attributes.AddRange(staticGetter.ReturnType.ResolveCached().CustomAttributes);

            return attributes.FirstOrDefault(cad => TypeConverterAttribute.TypeConvertersType.Contains(cad.AttributeType.FullName))?.ConstructorArguments [0].Value as TypeReference;
        }
    }
}
 
