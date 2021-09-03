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
    internal class GetObjectConvertedFromString : Operation
    {
        public GetObjectConvertedFromString(GlobalDataList globalDataList, List<object> operationInfo)
        {
            object value0 = operationInfo[0];
            converterIndex = (value0 is Instance) ? (value0 as Instance).Index : (int)value0;
            value = operationInfo[1] as string;
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            var converter = globalDataList.GatheredInstances[converterIndex] as TypeConverter;
            globalDataList.GatheredInstances.Add(converter?.ConvertFromInvariantString(value));
        }

        private int converterIndex;
        private string value;
    }
}
