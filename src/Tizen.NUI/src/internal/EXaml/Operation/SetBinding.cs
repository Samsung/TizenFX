using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class SetBinding : Operation
    {
        public SetBinding(int instanceIndex, int bindablePropertyIndex, int valueIndex)
        {
            this.instanceIndex = instanceIndex;
            this.bindablePropertyIndex = bindablePropertyIndex;
            this.valueIndex = valueIndex;
        }

        public void Do()
        {
            BindableObject bindableObject = LoadEXaml.GatheredInstances[instanceIndex] as BindableObject;
            var property = GatherBindableProperties.GatheredBindableProperties[bindablePropertyIndex];
            var value = LoadEXaml.GatheredInstances[valueIndex] as BindingBase;
            bindableObject?.SetBinding(property, value);
        }

        private int instanceIndex;
        private int bindablePropertyIndex;
        private int valueIndex;
    }
}
