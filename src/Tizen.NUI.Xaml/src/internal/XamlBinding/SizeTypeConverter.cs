using System;
using System.Linq;
using System.Reflection;
using System.Globalization;

using Tizen.NUI.Xaml;
using Tizen.NUI;

namespace Tizen.NUI.Binding
{
    [ProvideCompiledAttribute("Tizen.NUI.Xaml.Forms.XamlC.Size2DTypeConverter")]
    public class SizeTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 3)
                {
                    int x = (int)Tizen.NUI.GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[0].Trim());
                    int y = (int)Tizen.NUI.GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[1].Trim());
                    int z = (int)Tizen.NUI.GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[2].Trim());
                    return new Size(x, y, z);
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Size)}");
        }
    }

    [ProvideCompiledAttribute("Tizen.NUI.Xaml.Forms.XamlC.Size2DTypeConverter")]
    public class Size2DTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 2)
                {
                    int x = (int)Tizen.NUI.GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[0].Trim());
                    int y = (int)Tizen.NUI.GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[1].Trim());
                    return new Size2D(x, y);
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Size2D)}");
        }
    }
}
