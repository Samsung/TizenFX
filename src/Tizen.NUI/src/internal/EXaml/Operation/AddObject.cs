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
    internal class AddObject : Operation
    {
        public AddObject(GlobalDataList globalDataList, List<object> operationInfo)
        {
            parentIndex = (int)operationInfo[0];
            child = operationInfo[1];
            methodIndex = (int)operationInfo[2];
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            object parent = globalDataList.GatheredInstances[parentIndex];
            var method = globalDataList.GatheredMethods[methodIndex];

            if (child is Instance)
            {
                child = globalDataList.GatheredInstances[(child as Instance).Index];
            }

            method.Invoke(parent, new object[] { child });
        }

        private int parentIndex;
        private object child;
        private int methodIndex;
    }
}
