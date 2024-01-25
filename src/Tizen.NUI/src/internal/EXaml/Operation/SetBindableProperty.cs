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
    internal class SetBindableProperty : Operation
    {
        public SetBindableProperty(GlobalDataList globalDataList, List<object> operationInfo)
        {
            instanceIndex = (int)operationInfo[0];
            bindablePropertyIndex = (int)operationInfo[1];
            value = operationInfo[2];
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            var instance = globalDataList.GatheredInstances[instanceIndex] as BindableObject;

            if (null != instance)
            {
                var property = globalDataList.GatheredBindableProperties[bindablePropertyIndex];

                if (value is Instance valueInstance)
                {
                    int valueIndex = valueInstance.Index;
                    value = globalDataList.GatheredInstances[valueIndex];
                }

                if (value is IMarkupExtension markupExtension)
                {
                    value = markupExtension.ProvideValue(null);
                }

                instance.SetValue(property, value);
            }
        }

        private int instanceIndex;
        private int bindablePropertyIndex;
        private object value;
    }
}
