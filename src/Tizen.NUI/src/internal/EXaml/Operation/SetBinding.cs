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
    internal class SetBinding : Operation
    {
        public SetBinding(GlobalDataList globalDataList, int instanceIndex, int bindablePropertyIndex, int valueIndex)
        {
            this.instanceIndex = instanceIndex;
            this.bindablePropertyIndex = bindablePropertyIndex;
            this.valueIndex = valueIndex;
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            BindableObject bindableObject = globalDataList.GatheredInstances[instanceIndex] as BindableObject;
            var property = globalDataList.GatheredBindableProperties[bindablePropertyIndex];
            var value = globalDataList.GatheredInstances[valueIndex] as BindingBase;
            bindableObject?.SetBinding(property, value);
        }

        private int instanceIndex;
        private int bindablePropertyIndex;
        private int valueIndex;
    }
}
