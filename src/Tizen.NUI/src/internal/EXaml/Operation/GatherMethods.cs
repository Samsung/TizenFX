using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class GatherMethods : Operation
    {
        public GatherMethods(int typeIndex, string methodName)
        {
            this.typeIndex = typeIndex;
            this.methodName = methodName;
        }

        public void Do()
        {
            var type = GatherTypes.GatheredTypes[typeIndex];
            GatheredMethods.Add(type.GetMethod(methodName));
        }

        private int typeIndex;
        private string methodName;
        internal static List<MethodInfo> GatheredMethods = new List<MethodInfo>();
    }
}
