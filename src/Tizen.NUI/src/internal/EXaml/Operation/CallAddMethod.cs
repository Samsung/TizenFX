using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class CallAddMethod : Operation
    {
        public CallAddMethod(int parentIndex, int childIndex, int methodIndex)
        {
            this.parentIndex = parentIndex;
            this.childIndex = childIndex;
            this.methodIndex = methodIndex;
        }

        public void Do()
        {
            object parent = LoadEXaml.GatheredInstances[parentIndex];
            object child = LoadEXaml.GatheredInstances[childIndex];
            var method = GatherMethod.GatheredMethods[methodIndex];

            method.Invoke(parent, new object[] { child });
        }

        private int parentIndex;
        private int childIndex;
        private int methodIndex;
    }
}
