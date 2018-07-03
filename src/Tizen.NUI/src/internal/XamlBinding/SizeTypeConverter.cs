using System;
using System.Linq;
using System.Reflection;
using System.Globalization;

using Tizen.NUI;

namespace Tizen.NUI.Binding
{
    internal class SizeTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 3)
                {
                    return new Size(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture), 
                                    Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture), 
                                    Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Size)}");
        }
    }

    internal class Size2DTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 2)
                {
                    return new Size2D(Int32.Parse(parts[0].Trim(), CultureInfo.InvariantCulture), 
                                    Int32.Parse(parts[1].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Size2D)}");
        }
    }
}
