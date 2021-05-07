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
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class AddExistInstanceAction : Action
    {
        internal AddExistInstanceAction(GlobalDataList globalDataList, Action parent)
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

                case '@':
                    parent?.OnActive();
                    return parent;

                case '(':
                    getValueListOp = new GetValueListAction(')', this);
                    return getValueListOp;

                case 'o':
                case 'q':
                    sign = c;
                    break;
            }

            return this;
        }

        public void Init()
        {
        }

        public void OnActive()
        {
            if (null != getValueListOp)
            {
                object value0 = getValueListOp.ValueList[0];
                int index = (value0 is Instance) ? (value0 as Instance).Index : (int)value0;
                string value = getValueListOp.ValueList[1] as string;

                if ('q' == sign)
                {
                    globalDataList.Operations.Add(new GatherConvertedValue(globalDataList, index, value));
                }
                else if ('o' == sign)
                {
                    globalDataList.Operations.Add(new GatherEnumValue(globalDataList, index, value));
                }

                getValueListOp = null;
            }
        }

        private char sign;
        private GetValueListAction getValueListOp;
    }
}
