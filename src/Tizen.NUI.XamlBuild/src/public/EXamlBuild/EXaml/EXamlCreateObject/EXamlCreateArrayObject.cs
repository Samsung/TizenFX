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
    internal class EXamlCreateArrayObject : EXamlCreateObject
    {
        public EXamlCreateArrayObject(EXamlContext context, TypeReference type, List<object> items) : base(context, null, type)
        {
            this.items = items;
        }

        internal override string Write()
        {
            if (false == IsValid)
            {
                return "";
            }

            string itemsString = "";
            if (0 < items.Count)
            {
                itemsString += "(";

                foreach (var item in items)
                {
                    itemsString += $"{eXamlContext.GetValueString(item)} ";
                }

                itemsString += ")";
            }

            string ret = String.Format("({0} ({1} {2}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.CreateArrayObject),
                         eXamlContext.GetValueString(eXamlContext.GetTypeIndex(Type)),
                         itemsString);

            return ret;
        }

        private List<object> items;
    }
}
 
