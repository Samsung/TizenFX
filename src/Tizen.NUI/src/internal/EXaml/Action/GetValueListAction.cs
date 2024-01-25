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

namespace Tizen.NUI.EXaml
{
    internal class GetValueListAction : Action
    {
        public GetValueListAction(char sign, Action parent)
        {
            this.sign = sign;
            this.parent = parent;
        }

        private char sign;
        private Action parent;

        public Action DealChar(char c)
        {
            if (c == sign)
            {
                parent?.OnActive();
                return parent;
            }

            if ('\"' != sign)
            {
                switch (c)
                {
                    case ' ':
                    case '\n':
                    case '\r':
                        return this;

                    case '(':
                        childOp = new GetValueListAction(')', this);
                        return childOp;

                    default:
                        childOp = new GetValueAction(c, this);
                        return childOp;
                }
            }

            return this;
        }

        internal List<object> ValueList
        {
            get;
        } = new List<object>();

        private Action childOp;

        public void Init()
        {
            ValueList.Clear();
        }

        public void OnActive()
        {
            GetValueAction getValueAction;
            GetValueListAction getValueListAction;

            if (null != (getValueAction = (childOp as GetValueAction)))
            {
                ValueList.Add(getValueAction.Value);
            }
            else if (null != (getValueListAction = (childOp as GetValueListAction)))
            {
                ValueList.Add(getValueListAction.ValueList);
            }

            childOp = null;
        }
    }
}
