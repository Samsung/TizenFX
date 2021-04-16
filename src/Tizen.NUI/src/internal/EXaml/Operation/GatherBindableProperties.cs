using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class GatherBindableProperties : Operation
    {
        public GatherBindableProperties(int typeIndex, string propertyName)
        {
            this.typeIndex = typeIndex;
            this.propertyName = propertyName;
        }

        public void Do()
        {
            var type = GatherType.GatheredTypes[typeIndex];
            var field = type.GetField(fi => fi.Name == propertyName && fi.IsStatic && fi.IsPublic);
            if (null == field)
            {
                field = type.GetField(fi => fi.Name == propertyName && fi.IsStatic && !fi.IsPublic);
            }

            GatheredBindableProperties.Add(field.GetValue(null) as BindableProperty);
        }

        private int typeIndex;
        private string propertyName;
        internal static List<BindableProperty> GatheredBindableProperties = new List<BindableProperty>();
    }
}
