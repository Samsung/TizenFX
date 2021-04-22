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
    internal class RegisterXName : Operation
    {
        public RegisterXName(GlobalDataList globalDataList, object instance, string name)
        {
            this.instance = instance;
            this.name = name;
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            object realInstance = null;
            if (instance is Instance)
            {
                realInstance = globalDataList.GatheredInstances[(instance as Instance).Index];
            }
            else
            {
                realInstance = instance;
            }

            var namescope = NameScope.GetNameScope(CreateInstance.Root as BindableObject);
            namescope?.RegisterName(name, realInstance);
        }

        private object instance;
        private string name;
    }
}
