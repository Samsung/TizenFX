using System;

namespace Tizen.NUI.Binding
{
    [Xaml.TypeConversion(typeof(FileImageSource))]
    internal sealed class FileImageSourceConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
                return (FileImageSource)ImageSource.FromFile(value);

            throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(FileImageSource)));
        }
    }
}