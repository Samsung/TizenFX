using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class AddToResourceDictionary : Operation
    {
        internal AddToResourceDictionary(int instanceIndex, string key, object value)
        {
            this.instanceIndex = instanceIndex;
            this.key = key;
            this.value = value;
        }

        public void Do()
        {
            var instance = LoadEXaml.GatheredInstances[instanceIndex] as ResourceDictionary;
            var realValue = (value is Instance) ? LoadEXaml.GatheredInstances[(value as Instance).Index] : value;

            instance.Add(key, realValue);
        }

        private int instanceIndex;
        private string key;
        private object value;
    }
}
