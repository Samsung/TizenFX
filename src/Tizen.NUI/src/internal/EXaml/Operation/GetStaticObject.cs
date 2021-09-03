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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.EXaml
{
    internal class GetStaticObject : Operation
    {
        public GetStaticObject(GlobalDataList globalDataList, List<object> operationInfo)
        {
            typeIndex = (int)operationInfo[0];
            propertyName = operationInfo[1] as string;
            fieldName = operationInfo[2] as string;
            this.globalDataList = globalDataList;
        }

        private string propertyName;
        private string fieldName;

        private GlobalDataList globalDataList;

        public void Do()
        {
            object obj = null;

            if (0 == globalDataList.GatheredInstances.Count && null != globalDataList.Root)
            {
                obj = globalDataList.Root;
            }
            else
            {
                var type = globalDataList.GatheredTypes[typeIndex];

                if (null != fieldName)
                {
                    obj = type.GetField(fieldName, BindingFlags.Static | BindingFlags.Public).GetValue(null);
                }
                else
                {
                    obj = type.GetProperty(propertyName, BindingFlags.Static | BindingFlags.Public).GetValue(null);
                }
            }

            if (null != obj)
            {
                globalDataList.GatheredInstances.Add(obj);

                if (obj is BindableObject bindableObject)
                {
                    bindableObject.IsCreateByXaml = true;

                    if (1 == globalDataList.GatheredInstances.Count)
                    {
                        NameScope nameScope = new NameScope();
                        NameScope.SetNameScope(bindableObject, nameScope);
                    }
                }
            }
            else
            {
                string name = null;
                if (null != fieldName)
                {
                    name = fieldName;
                }
                else
                {
                    name = propertyName;
                }

                throw new Exception($"Can't gather static instance typeIndex:{typeIndex}, name:{name}");
            }
        }

        private int typeIndex;
    }
}
