using System;
using System.Globalization;

namespace Tizen.NUI.Binding
{
    internal class ExtentsTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 4)
                {
                    return new Extents(ushort.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                       ushort.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                       ushort.Parse(parts[2].Trim(), CultureInfo.InvariantCulture), 
                                       ushort.Parse(parts[3].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Extents)}");
        }
    }
}
