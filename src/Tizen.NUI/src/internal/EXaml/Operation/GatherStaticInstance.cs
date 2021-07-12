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
    internal class GatherStaticInstance : Operation
    {
        public GatherStaticInstance(GlobalDataList globalDataList, int typeIndex, string propertyName, string fieldName)
        {
            this.typeIndex = typeIndex;
            this.propertyName = propertyName;
            this.fieldName = fieldName;
            this.globalDataList = globalDataList;
        }

        private string propertyName;
        private string fieldName;

        private GlobalDataList globalDataList;

        public void Do()
        {
            if (0 == globalDataList.GatheredInstances.Count && null != globalDataList.Root)
            {
                globalDataList.GatheredInstances.Add(globalDataList.Root);
            }
            else
            {
                var type = globalDataList.GatheredTypes[typeIndex];

                if (null != fieldName)
                {
                    var instance = type.GetField(fieldName, BindingFlags.Static | BindingFlags.Public).GetValue(null);
                    globalDataList.GatheredInstances.Add(instance);
                }
                else
                {
                    var instance = type.GetProperty(propertyName, BindingFlags.Static | BindingFlags.Public).GetValue(null);
                    globalDataList.GatheredInstances.Add(instance);
                }
            }

            if (1 == globalDataList.GatheredInstances.Count)
            {
                var rootObject = globalDataList.GatheredInstances[0] as BindableObject;
                if (null != rootObject)
                {
                    rootObject.IsCreateByXaml = true;
                    NameScope nameScope = new NameScope();
                    NameScope.SetNameScope(rootObject, nameScope);
                }
            }
        }

        private int typeIndex;
    }
}
