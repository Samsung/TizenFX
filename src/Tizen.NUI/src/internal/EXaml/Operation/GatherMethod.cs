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
using System.Linq;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class GatherMethod : Operation
    {
        public GatherMethod(GlobalDataList globalDataList, List<object> operationInfo)
        {
            typeIndex = (int)operationInfo[0];
            methodName = operationInfo[1] as string;
            paramList = operationInfo[2] as List<object>;
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            List<Type> paramTypeList = new List<Type>();

            if (null != paramList)
            {
                foreach (var obj in paramList)
                {
                    int index = (int)obj;

                    if (null == paramTypeList)
                    {
                        paramTypeList = new List<Type>();
                    }

                    if (index >= 0)
                    {
                        paramTypeList.Add(globalDataList.GatheredTypes[index]);
                    }
                    else
                    {
                        paramTypeList.Add(GetBaseType.GetBaseTypeByIndex(index));
                    }
                }
            }

            Func<MethodInfo, bool> isMatch = m =>
            {
                if (m.Name != methodName)
                    return false;
                var p = m.GetParameters();
                if (p.Length != paramTypeList.Count)
                    return false;
                for (var i = 0; i < p.Length; i++)
                {
                    if (p[i].ParameterType != paramTypeList[i])
                    {
                        return false;
                    }
                }
                return true;
            };

            var type = globalDataList.GatheredTypes[typeIndex];
            var method = type.GetRuntimeMethods().FirstOrDefault(isMatch);

            if (null == method)
            {
                throw new Exception($"Can't get method {methodName} with {paramTypeList.Count} params");
            }
            globalDataList.GatheredMethods.Add(method);
        }

        private int typeIndex;
        private string methodName;
        private List<object> paramList;
    }
}
