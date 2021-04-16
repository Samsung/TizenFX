using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Tizen.NUI.EXaml
{
    internal class GatherTypesBlock : Action
    {
        public GatherTypesBlock(Action parent)
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
            LoadEXaml.Operations.Add(GatherType(childOp.ValueList));
            childOp = null;
        }

        private GatherType GatherType(List<object> valueList)
        {
            int assemblyIndex = int.Parse(valueList[0] as string);
            string typeName = valueList[valueList.Count - 1] as string;

            if (valueList.Count > 2)
            {
                List<int> genericTypeIndexs = new List<int>();
                var genericTypeIndexList = valueList[1] as List<object>;
                foreach (var index in genericTypeIndexList)
                {
                    genericTypeIndexs.Add((int)index);
                }

                return new GatherType(assemblyIndex, typeName, genericTypeIndexs);
            }
            else
            {
                return new GatherType(assemblyIndex, typeName);
            }
        }
    }
}
