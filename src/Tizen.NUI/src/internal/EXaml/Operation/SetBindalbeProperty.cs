using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class SetBindalbeProperty : Operation
    {
        public SetBindalbeProperty(int instanceIndex, int bindalbePropertyIndex, object value)
        {
            this.instanceIndex = instanceIndex;
            this.bindalbePropertyIndex = bindalbePropertyIndex;
            this.value = value;
        }

        public void Do()
        {
            var instance = LoadEXaml.GatheredInstances[instanceIndex] as BindableObject;

            if (null != instance)
            {
                var property = GatherBindableProperties.GatheredBindableProperties[bindalbePropertyIndex];

                if (value is Instance)
                {
                    int valueIndex = (value as Instance).Index;
                    instance.SetValue(property, LoadEXaml.GatheredInstances[valueIndex]);
                }
                else
                {
                    instance.SetValue(property, value);
                }
            }
        }

        private int instanceIndex;
        private int bindalbePropertyIndex;
        private object value;
    }
}
