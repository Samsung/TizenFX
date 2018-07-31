namespace Tizen.NUI.Binding
{
    internal class AcceleratorTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value == null)
                return null;

            return Accelerator.FromString(value);
        }
    }
}
