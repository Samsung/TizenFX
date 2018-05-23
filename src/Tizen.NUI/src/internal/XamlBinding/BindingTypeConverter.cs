namespace Tizen.NUI.Binding
{
	// [Xaml.ProvideCompiled("Xamarin.Forms.Core.XamlC.BindingTypeConverter")]
	[Xaml.TypeConversion(typeof(Binding))]
	internal sealed class BindingTypeConverter : TypeConverter
	{
		public override object ConvertFromInvariantString(string value)
		{
			return new Binding(value);
		}
	}
}