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
    internal class CreateInstanceAction : Action
    {
        internal CreateInstanceAction(GlobalDataList globalDataList, Action parent)
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

                case '}':
                    parent?.OnActive();
                    return parent;

                case '(':
                    getParamListOp = new GetValueListAction(')', this);
                    return getParamListOp;

                case '[':
                    getXFactoryMethodIndexOp = new GetValueListAction(']', this);
                    return getXFactoryMethodIndexOp;

                case '{':
                    getStaticInstanceOp = new GetValueListAction('}', this);
                    return getStaticInstanceOp;

                default:
                    getTypeIndexOp = new GetValueAction(c, this);
                    return getTypeIndexOp;
            }

            return this;
        }

        public void Init()
        {
            getTypeIndexOp = null;
            getXFactoryMethodIndexOp = null;
            getParamListOp = null;
            getStaticInstanceOp = null;
        }

        public void OnActive()
        {
            if (null != getTypeIndexOp)
            {
                int typeIndex = (int)getTypeIndexOp.Value;
                if (null != getStaticInstanceOp)
                {
                    var propertyName = getStaticInstanceOp.ValueList[0] as string;
                    var fieldName = getStaticInstanceOp.ValueList[1] as string;
                    getStaticInstanceOp = null;

                    globalDataList.Operations.Add(new GatherStaticInstance(globalDataList, typeIndex, propertyName, fieldName));
                }
                else
                {
                    int xFactoryMethodIndex = (null == getXFactoryMethodIndexOp) ? -1 : (int)getXFactoryMethodIndexOp.ValueList[0];
                    getXFactoryMethodIndexOp = null;

                    if (null == getParamListOp)
                    {
                        globalDataList.Operations.Add(new CreateInstance(globalDataList, typeIndex, xFactoryMethodIndex));
                    }
                    else
                    {
                        globalDataList.Operations.Add(new CreateInstance(globalDataList, typeIndex, xFactoryMethodIndex, getParamListOp.ValueList));
                    }

                    getParamListOp = null;
                }
            }

            getTypeIndexOp = null;
        }

        private GetValueAction getTypeIndexOp;
        private GetValueListAction getXFactoryMethodIndexOp;
        private GetValueListAction getParamListOp;
        private GetValueListAction getStaticInstanceOp;
    }
}
