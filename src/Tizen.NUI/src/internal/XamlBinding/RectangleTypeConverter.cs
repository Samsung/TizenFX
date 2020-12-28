using System;
using System.Globalization;

using Tizen.NUI;

namespace Tizen.NUI.Binding
{
    [Xaml.ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.RectangleTypeConverter")]
    [Xaml.TypeConversion(typeof(Rectangle))]
    internal class RectangleTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                double x, y, w, h;
                string[] xywh = value.Split(',');
                if (xywh.Length == 4 && double.TryParse(xywh[0], NumberStyles.Number, CultureInfo.InvariantCulture, out x) && double.TryParse(xywh[1], NumberStyles.Number, CultureInfo.InvariantCulture, out y) &&
                    double.TryParse(xywh[2], NumberStyles.Number, CultureInfo.InvariantCulture, out w) && double.TryParse(xywh[3], NumberStyles.Number, CultureInfo.InvariantCulture, out h))
                    return new Rectangle((int)x, (int)y, (int)w, (int)h);
            }

            throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(Rectangle)));
        }

        public override string ConvertToString(object value)
        {
            Rectangle rec = (Rectangle)value;
            return rec.X.ToString() + " " + rec.Y.ToString() + " " + rec.Width.ToString() + " " + rec.Height.ToString();
        }
    }
}
