using System;
using System.Linq;
using System.Reflection;
using System.Globalization;

using Tizen.NUI.Xaml;
using Tizen.NUI;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiledAttribute("Tizen.NUI.Xaml.Forms.XamlC.Size2DTypeConverter")]
    public class SizeTypeConverter : TypeConverter
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiledAttribute("Tizen.NUI.Xaml.Forms.XamlC.Size2DTypeConverter")]
    public class Size2DTypeConverter : TypeConverter
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
