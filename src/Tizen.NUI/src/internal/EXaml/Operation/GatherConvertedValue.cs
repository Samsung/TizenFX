using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class GatherConvertedValue : Operation
    {
        public GatherConvertedValue(int converterIndex, string value)
        {
            this.converterIndex = converterIndex;
            this.value = value;
        }

        public void Do()
        {
            var converter = LoadEXaml.GatheredInstances[converterIndex] as TypeConverter;
            LoadEXaml.GatheredInstances.Add(converter.ConvertFromInvariantString(value));
        }

        private int converterIndex;
        private string value;
    }
}
