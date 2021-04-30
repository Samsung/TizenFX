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
        public SetProperty(GlobalDataList globalDataList, int instanceIndex, int propertyIndex, object value)
        {
            this.instanceIndex = instanceIndex;
            this.propertyIndex = propertyIndex;
            this.value = value;
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            object instance = globalDataList.GatheredInstances[instanceIndex];
            if (null == instance)
            {
                throw new Exception(String.Format("Can't get instance by index {0}", instanceIndex));
            }

            var property = globalDataList.GatheredProperties[propertyIndex];

            if (null == property)
            {
                throw new Exception(String.Format("Can't find property {0} in type {1}", property.Name, instance.GetType().FullName));
            }

            if (null == property.SetMethod)
            {
                throw new Exception(String.Format("Property {0} hasn't set method", property.Name));
            }

            if (value is Instance)
            {
                int valueIndex = (value as Instance).Index;
                object realValue = globalDataList.GatheredInstances[valueIndex];

                if (null == realValue)
                {
                    throw new Exception(String.Format("Can't get instance of value by index {0}", valueIndex));
                }

                property.SetMethod.Invoke(instance, new object[] { realValue });
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
