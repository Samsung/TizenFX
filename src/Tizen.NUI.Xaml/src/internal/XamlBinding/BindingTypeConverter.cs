namespace Tizen.NUI.XamlBinding
{
    [Xaml.ProvideCompiled("Tizen.NUI.Xaml.Forms.XamlC.BindingTypeConverter")]
    [Xaml.TypeConversion(typeof(Binding))]
    internal sealed class BindingTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            return new Binding(value);
        }
    }
}