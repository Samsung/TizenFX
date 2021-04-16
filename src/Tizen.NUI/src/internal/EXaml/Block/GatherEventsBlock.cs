using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Tizen.NUI.EXaml
{
    internal class GatherEventsBlock : Action
    {
        public GatherEventsBlock(Action parent)
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

                case '>':
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
            int typeIndex = int.Parse(childOp.ValueList[0] as string);
            string eventName = childOp.ValueList[1] as string;

            LoadEXaml.Operations.Add(new GatherEvent(typeIndex, eventName));
        }
    }
}
