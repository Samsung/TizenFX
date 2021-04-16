using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class GatherEnumValue : Operation
    {
        public GatherEnumValue(int typeIndex, string value)
        {
            this.typeIndex = typeIndex;
            this.value = value;
        }

        public void Do()
        {
            var enumType = GatherType.GatheredTypes[typeIndex];
            LoadEXaml.GatheredInstances.Add(Enum.Parse(enumType, value));
        }

        private int typeIndex;
        private string value;
    }
}
