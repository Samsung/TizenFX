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
    internal class GetObjectByProperty : Operation
    {
        public GetObjectByProperty(GlobalDataList globalDataList, int instanceIndex, string propertyName)
        {
            this.instanceIndex = instanceIndex;
            this.propertyName = propertyName;
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            var instance = globalDataList.GatheredInstances[instanceIndex];
            if (null == instance)
            {
                throw new Exception(String.Format("Can't get instance by index {0}", instanceIndex));
            }

            var property = instance.GetType().GetProperty(propertyName);

            if (null == property)
            {
                throw new Exception(String.Format("Can't find property {0} in type {1}", propertyName, instance.GetType().FullName));
            }

            var @object = property.GetMethod?.Invoke(instance, Array.Empty<object>());
            if (null == @object)
            {
                throw new Exception(String.Format("Can't get object of property {0} in type {1}", propertyName, instance.GetType().FullName));
            }

            globalDataList.ObjectsFromProperty.Add(@object);
        }

        private int instanceIndex;

        private string propertyName;
    }
}
