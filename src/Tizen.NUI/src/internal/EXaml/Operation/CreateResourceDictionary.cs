/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Text;
using Tizen.NUI.Binding;

namespace Tizen.NUI.EXaml
{
    class CreateResourceDictionary : Operation
    {
        public CreateResourceDictionary(GlobalDataList globalDataList, List<object> operationInfo)
        {
            typeIndex = (int)operationInfo[0];
            indexRangeOfContent = ((int)operationInfo[1], (int)operationInfo[2]);
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;
        private int typeIndex;
        private (int, int) indexRangeOfContent;

        public void Do()
        {
            var content = globalDataList.LongStrings.Substring(indexRangeOfContent.Item1, indexRangeOfContent.Item2 - indexRangeOfContent.Item1 + 1);
            var resourceDictionary = EXamlExtensions.CreateObjectFromEXaml(content) as ResourceDictionary;

            globalDataList.GatheredInstances.Add(resourceDictionary);

            if (null == globalDataList.Root)
            {
                globalDataList.Root = resourceDictionary;
            }
        }
    }
}
