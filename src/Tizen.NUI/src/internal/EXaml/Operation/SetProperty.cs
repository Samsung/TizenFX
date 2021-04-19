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
    internal class SetProperty : Operation
    {
        public SetProperty(int instanceIndex, int propertyIndex, object value)
        {
            this.instanceIndex = instanceIndex;
            this.propertyIndex = propertyIndex;
            this.value = value;
        }

        public void Do()
        {
            object instance = LoadEXaml.GatheredInstances[instanceIndex];
            var property = GatherProperty.GatheredProperties[propertyIndex];

            if (value is Instance)
            {
                int valueIndex = (value as Instance).Index;
                property.SetMethod.Invoke(instance, new object[] { LoadEXaml.GatheredInstances[valueIndex] });
            }
            else
            {
                property.SetMethod.Invoke(instance, new object[] { value });
            }
        }

        private int instanceIndex;
        private int propertyIndex;
        private object value;
    }
}
