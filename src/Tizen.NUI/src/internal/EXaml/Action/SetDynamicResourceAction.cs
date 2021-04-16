using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.EXaml
{
    internal class SetDynamicResourceAction : Action
    {
        public SetDynamicResourceAction(Action parent)
        {
            this.parent = parent;
        }

        private Action parent;

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

                case '$':
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
            if (null != childOp)
            {
                int instanceIndex = (childOp.ValueList[0] as Instance).Index;
                int propertyIndex = (int)childOp.ValueList[1];
                string key = childOp.ValueList[2] as string;

                LoadEXaml.Operations.Add(new SetDynamicResource(instanceIndex, propertyIndex, key));
            }
        }
    }
}
