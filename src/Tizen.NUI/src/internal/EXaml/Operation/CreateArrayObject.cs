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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.EXaml
{
    internal class CreateArrayObject : Operation
    {
        public CreateArrayObject(GlobalDataList globalDataList, List<object> operationInfos)
        {
            this.typeIndex = (int)operationInfos[0];
            if (2 == operationInfos.Count)
            {
                this.items = operationInfos[1] as List<object>;
            }
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            var type = globalDataList.GatheredTypes[typeIndex];
            var array = Array.CreateInstance(type, null == items ? 0 : items.Count);

            if (null != items)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i] is Instance instance)
                    {
                        ((IList)array)[i] = globalDataList.GatheredInstances[instance.Index];
                    }
                }
            }

            globalDataList.GatheredInstances.Add(array);
        }

        private int typeIndex;
        private List<object> items;
    }
}
