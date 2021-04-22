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
using System.Reflection;
using System.Text;
using Tizen.NUI.Binding;

namespace Tizen.NUI.EXaml
{
    internal class GlobalDataList
    {
        internal List<Operation> Operations
        {
            get;
        } = new List<Operation>();

        internal List<object> GatheredInstances
        {
            get;
        } = new List<object>();

        internal List<object> ObjectsFromProperty
        {
            get;
        } = new List<object>();

        internal List<EventInfo> GatheredEvents
        {
            get;
        } = new List<EventInfo>();

        internal List<MethodInfo> GatheredMethods
        {
            get;
        } = new List<MethodInfo>();

        internal List<Type> GatheredTypes
        {
            get;
        } = new List<Type>();

        internal List<PropertyInfo> GatheredProperties
        {
            get;
        } = new List<PropertyInfo>();

        internal List<BindableProperty> GatheredBindableProperties
        {
            get;
        } = new List<BindableProperty>();

        private List<AssemblyName> assemblyNameList;
        internal List<AssemblyName> AssemblyNameList
        {
            get
            {
                if (null == assemblyNameList)
                {
                    assemblyNameList = new List<AssemblyName>();
                    assemblyNameList.Add(EXamlExtensions.MainAssembly.GetName());

                    var assemblyNames = EXamlExtensions.MainAssembly.GetReferencedAssemblies();

                    foreach (var name in assemblyNames)
                    {
                        assemblyNameList.Add(name);
                    }
                }

                return assemblyNameList;
            }
        }

        internal List<Assembly> GatheredAssemblies = new List<Assembly>();
    }
}
