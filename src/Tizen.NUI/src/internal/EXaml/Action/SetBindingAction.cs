using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class SetBindingAction : Action
    {
        public SetBindingAction(Action parent)
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

                case '%':
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
                var propertyIndex = (int)childOp.ValueList[1];
                int valueIndex = (childOp.ValueList[2] as Instance).Index;

                LoadEXaml.Operations.Add(new SetBinding(instanceIndex, propertyIndex, valueIndex));
            }
        }
    }
}
