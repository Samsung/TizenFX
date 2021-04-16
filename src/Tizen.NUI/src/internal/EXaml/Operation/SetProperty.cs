using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class SetProperty : Operation
    {
        public SetProperty(int instanceIndex, int propertyIndex, object value)
        {
            this.instanceIndex = instanceIndex;
            this.propertyIndex = propertyIndex;
            this.value = value;
        }

        public void Do()
        {
            object instance = LoadEXaml.GatheredInstances[instanceIndex];
            var property = GatherProperty.GatheredProperties[propertyIndex];

            if (value is Instance)
            {
                int valueIndex = (value as Instance).Index;
                property.SetMethod.Invoke(instance, new object[] { LoadEXaml.GatheredInstances[valueIndex] });
            }
            else
            {
                property.SetMethod.Invoke(instance, new object[] { value });
            }
        }

        private int instanceIndex;
        private int propertyIndex;
        private object value;
    }
}
