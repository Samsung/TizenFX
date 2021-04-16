using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class CreateObjectAction : Action
    {
        internal CreateObjectAction(Action parent)
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

                case '}':
                    parent?.OnActive();
                    return parent;

                case '(':
                    getParamListOp = new GetValueListAction(')', this);
                    return getParamListOp;

                default:
                    getTypeIndexOp = new GetValueAction(c, this);
                    return getTypeIndexOp;
            }

            return this;
        }

        public void Init()
        {
        }

        public void OnActive()
        {
            if (null != getTypeIndexOp)
            {
                int typeIndex = (int)getTypeIndexOp.Value;
                if (null == getParamListOp)
                {
                    LoadEXaml.Operations.Add(new CreateInstance(typeIndex));
                }
                else
                {
                    LoadEXaml.Operations.Add(new CreateInstance(typeIndex, getParamListOp.ValueList));
                }
                getParamListOp = null;
            }

            getTypeIndexOp = null;
        }

        private GetValueAction getTypeIndexOp;
        private GetValueListAction getParamListOp;

        internal static object Root
        {
            get
            {
                return CreateInstance.Root;
            }
            set
            {
                CreateInstance.Root = value;
            }
        }
    }
}
