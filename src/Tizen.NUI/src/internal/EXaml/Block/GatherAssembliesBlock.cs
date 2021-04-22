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
    internal class GatherAssembliesBlock : Action
    {
        public GatherAssembliesBlock(GlobalDataList globalDataList, Action parent)
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

                case '\"':
                    childOp = new GetValueAction(c, this);
                    return childOp;

                case '>':
                    parent?.OnActive();
                    return parent;
            }

            return this;
        }

        private GetValueAction childOp;

        public void Init()
        {
            childOp = null;
        }

        public void OnActive()
        {
            var readedAssemblyName = childOp.Value as string;
            globalDataList.Operations.Add(new GatherAssembly(globalDataList, readedAssemblyName));
            childOp = null;
        }
    }
}
