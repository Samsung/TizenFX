using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class AddEventAction : Action
    {
        public AddEventAction(Action parent)
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

                case '#':
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
                int elementIndex = (childOp.ValueList[1] as Instance).Index;
                int propertyIndex = (int)childOp.ValueList[2];
                int value = (int)childOp.ValueList[3];
                LoadEXaml.Operations.Add(new AddEvent(instanceIndex, elementIndex, propertyIndex, value));
            }
        }
    }
}
