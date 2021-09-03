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
    internal class GatherType : Operation
    {
        public GatherType(GlobalDataList globalDataList, List<object> operationInfo)
        {
            this.assemblyIndex = (int)operationInfo[0];
            this.typeName = operationInfo[1] as string;
            if (3 == operationInfo.Count)
            {
                this.genericTypeIndexs = operationInfo[2] as List<object>;
            }
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            var assembly = globalDataList.GatheredAssemblies[assemblyIndex];
            var type = assembly.GetType(typeName);

            if (null != genericTypeIndexs)
            {
                Type[] args = new Type[genericTypeIndexs.Count];

                for (int i = 0; i < genericTypeIndexs.Count; i++)
                {
                    int typeIndex = (int)genericTypeIndexs[i];

                    if (typeIndex >= 0)
                    {
                        args[i] = globalDataList.GatheredTypes[typeIndex];
                    }
                    else
                    {
                        args[i] = GetBaseType.GetBaseTypeByIndex(typeIndex);
                    }
                }

                type = type.MakeGenericType(args);
            }

            globalDataList.GatheredTypes.Add(type);
        }

        private int assemblyIndex;
        private string typeName;
        private List<object> genericTypeIndexs;
    }
}
