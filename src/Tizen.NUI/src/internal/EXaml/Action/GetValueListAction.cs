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

        private GetValueAction childOp;

        public void Init()
        {
            ValueList.Clear();
        }

        public void OnActive()
        {
            if (null != childOp)
            {
                ValueList.Add(childOp.Value);
            }
        }
    }
}
