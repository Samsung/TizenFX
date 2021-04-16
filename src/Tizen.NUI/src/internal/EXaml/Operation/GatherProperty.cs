using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class GatherProperty : Operation
    {
        public GatherProperty(int typeIndex, string propertyName)
        {
            this.typeIndex = typeIndex;
            this.propertyName = propertyName;
        }

        public void Do()
        {
            var type = GatherType.GatheredTypes[typeIndex];
            GatheredProperties.Add(type.GetProperty(propertyName));
        }

        private int typeIndex;
        private string propertyName;
        internal static List<PropertyInfo> GatheredProperties = new List<PropertyInfo>();
    }
}
