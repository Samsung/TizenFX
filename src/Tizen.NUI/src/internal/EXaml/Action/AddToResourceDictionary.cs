using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class AddToResourceDictionaryAction : Action
    {
        public AddToResourceDictionaryAction(Action parent)
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

                case '*':
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
                string key = childOp.ValueList[1] as string;
                var value = childOp.ValueList[2];
                LoadEXaml.Operations.Add(new AddToResourceDictionary(instanceIndex, key, value));
            }
        }
    }
}
