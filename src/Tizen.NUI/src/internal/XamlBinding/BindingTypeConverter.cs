﻿namespace Tizen.NUI.Binding
{
    [Xaml.ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.BindingTypeConverter")]
    [Xaml.TypeConversion(typeof(Binding))]
    internal sealed class BindingTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            return new Binding(value);
        }
    }
}