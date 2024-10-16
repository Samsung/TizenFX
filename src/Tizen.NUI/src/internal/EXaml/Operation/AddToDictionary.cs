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
    internal class AddToDictionary : Operation
    {
        public AddToDictionary(GlobalDataList globalDataList, List<object> operationInfo)
        {
            parentIndex = (int)operationInfo[0];
            key = operationInfo[1];
            value = operationInfo[2];
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            object dict = globalDataList.GatheredInstances[parentIndex];

            var type = dict.GetType();
            var method = type.GetMethods().FirstOrDefault(m => m.Name == "Add");

            method?.Invoke(dict, new object[] { key, value });
        }

        private int parentIndex;
        private object key;
        private object value;
    }
}
