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
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.EXaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    internal class EXamlCreateDataTemplate : EXamlCreateObject
    {
        public EXamlCreateDataTemplate(EXamlContext context, TypeReference type, string content) : base(context, null, type)
        {
            indexRangeOfContent = eXamlContext.GetLongStringIndexs(content);
        }

        private (int, int) indexRangeOfContent;

        internal override string Write()
        {
            if (false == IsValid)
            {
                return "";
            }

            string ret = String.Format("({0} ({1} {2} {3}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.CreateDataTemplate),
                         eXamlContext.GetValueString(eXamlContext.GetTypeIndex(Type)),
                         eXamlContext.GetValueString(indexRangeOfContent.Item1),
                         eXamlContext.GetValueString(indexRangeOfContent.Item2));

            return ret;
        }
    }
}
 
