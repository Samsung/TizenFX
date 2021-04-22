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

namespace Tizen.NUI.EXaml
{
    internal class GatherTypesBlock : Action
    {
        public GatherTypesBlock(GlobalDataList globalDataList, Action parent)
        {
            this.parent = parent;
            this.globalDataList = globalDataList;
        }

        private Action parent;
        private GlobalDataList globalDataList;

        public Action DealChar(char c)
        {
            switch (c)
            {
                case ' ':
                case '\n':
                case '\r':
                    break;

                case '(':
                    childOp = new GetValueListAction(')', this);
                    return childOp;

                case '>':
                    parent?.OnActive();
                    return parent;
            }

            return this;
        }

        private GetValueListAction childOp;

        public void Init()
        {
            childOp = null;
        }

        public void OnActive()
        {
            globalDataList.Operations.Add(GatherType(childOp.ValueList));
            childOp = null;
        }

        private GatherType GatherType(List<object> valueList)
        {
            int assemblyIndex = int.Parse(valueList[0] as string);
            string typeName = valueList[valueList.Count - 1] as string;

            if (valueList.Count > 2)
            {
                List<int> genericTypeIndexs = new List<int>();
                var genericTypeIndexList = valueList[1] as List<object>;
                foreach (var index in genericTypeIndexList)
                {
                    genericTypeIndexs.Add((int)index);
                }

                return new GatherType(globalDataList, assemblyIndex, typeName, genericTypeIndexs);
            }
            else
            {
                return new GatherType(globalDataList, assemblyIndex, typeName);
            }
        }
    }
}
