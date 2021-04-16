using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class SetDynamicResource : Operation
    {
        public SetDynamicResource(int instanceIndex, int propertyIndex, string key)
        {
            this.instanceIndex = instanceIndex;
            this.propertyIndex = propertyIndex;
            this.key = key;
        }

        public void Do()
        {
            var instance = LoadEXaml.GatheredInstances[instanceIndex] as BindableObject;
            var property = GatherBindableProperties.GatheredBindableProperties[propertyIndex];

            instance.SetDynamicResource(property, key);
        }

        private int instanceIndex;
        private int propertyIndex;
        private string key;
    }
}
