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
    internal class AddToCollectionObject : Operation
    {
        public AddToCollectionObject(GlobalDataList globalDataList, List<object> operationInfo)
        {
            instanceIndex = (int)operationInfo[0];
            value = operationInfo[1];
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            var collection = globalDataList.GatheredInstances[instanceIndex] as IList;

            if (null != collection)
            {
                if (value is Instance)
                {
                    int valueIndex = (value as Instance).Index;
                    value = globalDataList.GatheredInstances[valueIndex];
                }

                if (value is IMarkupExtension markupExtension)
                {
                    value = markupExtension.ProvideValue(null);
                }

                collection.Add(value);
            }
        }

        private int instanceIndex;
        private object value;
    }
}
