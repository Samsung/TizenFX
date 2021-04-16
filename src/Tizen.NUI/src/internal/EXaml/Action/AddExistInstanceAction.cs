using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class AddExistInstanceAction : Action
    {
        internal AddExistInstanceAction(Action parent)
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

                case '@':
                    parent?.OnActive();
                    return parent;

                case '(':
                    getValueListOp = new GetValueListAction(')', this);
                    return getValueListOp;

                case 'o':
                case 'q':
                    sign = c;
                    break;
            }

            return this;
        }

        public void Init()
        {
        }

        public void OnActive()
        {
            if (null != getValueListOp)
            {
                object value0 = getValueListOp.ValueList[0];
                int index = (value0 is Instance) ? (value0 as Instance).Index : (int)value0;
                string value = getValueListOp.ValueList[1] as string;

                if ('q' == sign)
                {
                    LoadEXaml.Operations.Add(new GatherConvertedValue(index, value));
                }
                else if ('o' == sign)
                {
                    LoadEXaml.Operations.Add(new GatherEnumValue(index, value));
                }

                getValueListOp = null;
            }
        }

        private char sign;
        private GetValueListAction getValueListOp;

        internal static object Root
        {
            get;
            set;
        }
    }
}
