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
    internal class CallAddMethod : Operation
    {
        public CallAddMethod(GlobalDataList globalDataList, int parentIndex, int childIndex, int methodIndex)
        {
            this.parentIndex = parentIndex;
            this.childIndex = childIndex;
            this.methodIndex = methodIndex;
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            object parent = globalDataList.GatheredInstances[parentIndex];
            object child = globalDataList.GatheredInstances[childIndex];
            var method = globalDataList.GatheredMethods[methodIndex];

            method.Invoke(parent, new object[] { child });
        }

        private int parentIndex;
        private int childIndex;
        private int methodIndex;
    }
}
