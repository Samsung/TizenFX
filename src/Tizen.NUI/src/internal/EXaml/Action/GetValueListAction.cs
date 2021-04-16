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
