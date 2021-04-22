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

namespace Tizen.NUI.EXaml
{
    internal class CreateInstance : Operation
    {
        public CreateInstance(GlobalDataList globalDataList, int typeIndex, List<object> paramList = null)
        {
            this.typeIndex = typeIndex;
            this.paramList = paramList;
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            if (0 == globalDataList.GatheredInstances.Count && null != Root)
            {
                globalDataList.GatheredInstances.Add(Root);
            }
            else
            {
                var type = globalDataList.GatheredTypes[typeIndex];

                if (null == paramList)
                {
                    globalDataList.GatheredInstances.Add(Activator.CreateInstance(type));
                }
                else
                {
                    for (int i = 0; i < paramList.Count; i++)
                    {
                        if (paramList[i] is Instance)
                        {
                            paramList[i] = globalDataList.GatheredInstances[(paramList[i] as Instance).Index];
                        }
                    }
                    globalDataList.GatheredInstances.Add(Activator.CreateInstance(type, paramList.ToArray()));
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

        internal static object Root;

        private List<object> paramList;
    }
}
