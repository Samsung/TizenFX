using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Tizen.NUI.EXaml
{
    internal class GatherAssembliesBlock : Action
    {
        public GatherAssembliesBlock(Action parent)
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

                case '\"':
                    childOp = new GetValueAction(c, this);
                    return childOp;

                case '>':
                    parent?.OnActive();
                    return parent;
            }

            return this;
        }

        private GetValueAction childOp;

        public void Init()
        {
            childOp = null;
        }

        public void OnActive()
        {
            var readedAssemblyName = childOp.Value as string;
            LoadEXaml.Operations.Add(new GatherAssembly(readedAssemblyName));
            childOp = null;
        }
    }
}
