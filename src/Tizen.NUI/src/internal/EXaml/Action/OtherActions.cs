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
    internal class OtherActions : Action
    {
        internal OtherActions(GlobalDataList globalDataList, Action parent)
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

                case 'a':
                    parent?.OnActive();
                    return parent;

                case '(':
                    getValues = new GetValueListAction(')', this);
                    return getValues;
            }

            return this;
        }

        public void Init()
        {
            getValues = null;
        }

        public void OnActive()
        {
            if (null != getValues)
            {
                int index = (int)getValues.ValueList[0];

                switch (index)
                {
                    case 0:
                        {
                            int typeIndex = (int)getValues.ValueList[1];
                            var items = getValues.ValueList[2] as List<object>;
                            var createArrayInstanceOp = new CreateArrayInstance(globalDataList, typeIndex, items);
                            globalDataList.Operations.Add(createArrayInstanceOp);
                        }
                        break;

                    case 1:
                        {
                            int typeIndex = (int)getValues.ValueList[1];
                            int startIndex = (int)getValues.ValueList[2];
                            int endIndex = (int)getValues.ValueList[3];
                            var createDataTemplateOp = new CreateDataTemplate(globalDataList, typeIndex, (startIndex, endIndex));
                            globalDataList.Operations.Add(createDataTemplateOp);
                        }
                        break;

                    case 2:
                        {
                            int instanceIndex = (getValues.ValueList[1] as Instance).Index;
                            var value = getValues.ValueList[2];
                            globalDataList.Operations.Add(new AddToCollectionInstance(globalDataList, instanceIndex, value));
                        }
                        break;

                    default:
                        break;
                }
            }

            getValues = null;
        }

        private GetValueListAction getValues;
    }
}
