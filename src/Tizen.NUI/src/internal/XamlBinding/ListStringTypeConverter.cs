using System;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.NUI.Binding
{
    [Xaml.ProvideCompiled("Tizen.NUI.Core.XamlC.ListStringTypeConverter")]
    [Xaml.TypeConversion(typeof(List<string>))]
    internal class ListStringTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value == null)
                return null;

            return value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
        }
    }
}
